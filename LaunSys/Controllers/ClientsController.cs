using LaunSys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vereyon.Web;

namespace LaunSys.Controllers
{
    public class ClientsController : Controller
    {
        [HttpGet]
        
        //-----------------------------Populate clients on the table----------------------------
        public ActionResult Index()
        {
            LaunSysDBEntities db = new LaunSysDBEntities();

            List<tb_Titles> TitleList = db.tb_Titles.ToList();
            ViewBag.VTitleLists = new SelectList(TitleList, "TitleID", "Title");

            List<tb_Gender> GenderList = db.tb_Gender.ToList();
            ViewBag.VGenderLists = new SelectList(GenderList, "GenderID", "Gendername");

            List<ClientsViewModel> ClientsList = db.tb_Customers.Where(x => x.IsNotActive == false).Select(x => new ClientsViewModel
            { Title=x.tb_Titles.Title,
                SurName =x.SurName,
                OtherNames =x.OtherNames,
                Gendername =x.tb_Gender.Gendername,
                Cust_Address =x.Cust_Address,
                Phone =x.Phone,
                Email =x.Email,
                CreatedDate =x.CreatedDate,
                CustID =x.CustID
            }).ToList();

            ViewBag.ListOfClients = ClientsList;

            return View();
        }

        //-----------------------------to get active client ID----------------------------
        [HttpPost]
        // to activate Authorization = [AuthorizeRoles(admin,accountant)]
        // to add default route = [Route("x/x/{parameter 1}/{parameter 2}")]
        // to pass parameter by exception = public ActionResult Index( string Id, ClientsViewModel Model)
        public ActionResult Index(ClientsViewModel Model)
        {

            try
            {
                //if (ModelState.IsValid == true)
                //{
                   LaunSysDBEntities db = new LaunSysDBEntities();
                    //------------------------To populate the drop down lists---------------------------
                    List<tb_Titles> TitleList = db.tb_Titles.ToList();
                    ViewBag.VTitleLists = new SelectList(TitleList, "TitleID", "Title");

                    List<tb_Gender> GenderList = db.tb_Gender.ToList();
                    ViewBag.VGenderLists = new SelectList(GenderList, "GenderID", "Gendername");
                    //----------------------------------------------------------------------------------
                 


                if (Model.CustID>0)
                {
                    //UPDATE EXISTING RECORD
                    tb_Customers Clients = db.tb_Customers.SingleOrDefault(x => x.CustID == Model.CustID && x.IsNotActive == false);

                    Clients.TitleID= Model.TitleID;
                    Clients.SurName= Model.SurName;
                    Clients.OtherNames= Model.OtherNames;
                    Clients.GenderID= Model.GenderID;
                    Clients.Cust_Address= Model.Cust_Address;
                    Clients.Phone = Model.Phone;
                    Clients.Email= Model.Email;
                    Clients.CreatedDate= Model.CreatedDate;
                    db.SaveChanges();
                }

                else
                {
                    //INSERT NEW RECORD
                    tb_Customers Clients = new tb_Customers();
                    Clients.TitleID = Model.TitleID;
                    Clients.SurName = Model.SurName;
                    Clients.OtherNames = Model.OtherNames;
                    Clients.GenderID = Model.GenderID;
                    Clients.Cust_Address = Model.Cust_Address;
                    Clients.Phone = Model.Phone;
                    Clients.Email = Model.Email;
                    Clients.CreatedDate = Model.CreatedDate;
                    Clients.IsNotActive = false;


                    db.tb_Customers.Add(Clients);
                    db.SaveChanges();
                }
                return View(Model);
                //}

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        //-----------------------------Delete client----------------------------
        public JsonResult DeleteClient(int CustID)
        {
            LaunSysDBEntities db = new LaunSysDBEntities();
            bool result = false;
            tb_Customers Cust = db.tb_Customers.SingleOrDefault(x => x.IsNotActive == false && x.CustID == CustID);

            if (Cust!=null)
            {
                //set the customer id to true, there fore hide it from the table\
                Cust.IsNotActive = true;
                db.SaveChanges();
                result = true;
            }

            //FlashMessage.Info("Invalid Login Details");
            return Json(result,JsonRequestBehavior.AllowGet);
        }


        //-----------------------------to view client details individually----------------------------
        public ActionResult ViewClient(int CustID)
        {
            LaunSysDBEntities db = new LaunSysDBEntities();

          
            List<ClientsViewModel> ClientDetail = db.tb_Customers.Where
                (x => x.IsNotActive == false && x.CustID== CustID)
                .Select(x => new ClientsViewModel
                { Title = x.tb_Titles.Title,
                    SurName = x.SurName,
                    OtherNames = x.OtherNames,
                    Gendername = x.tb_Gender.Gendername,
                    Cust_Address = x.Cust_Address,
                    Phone = x.Phone,
                    Email = x.Email,
                    CreatedDate = x.CreatedDate,
                    CustID = x.CustID
                }).ToList();

            ViewBag.SingleClientDetail = ClientDetail;

          
            return PartialView("SingleClientView");

        }

        //-----------------------------Add Edit----------------------------
        public ActionResult AddEdit(int CustID)
        {
            LaunSysDBEntities db = new LaunSysDBEntities();

            List<tb_Titles> TitleList = db.tb_Titles.ToList();
            ViewBag.VTitleLists = new SelectList(TitleList, "TitleID", "Title");

            List<tb_Gender> GenderList = db.tb_Gender.ToList();
            ViewBag.VGenderLists = new SelectList(GenderList, "GenderID", "Gendername");

            ClientsViewModel Model = new ClientsViewModel();

            if (CustID >  0)
            {
                tb_Customers Cust = db.tb_Customers.SingleOrDefault(x => x.CustID == CustID && x.IsNotActive == false);
                Model.CustID = Cust.CustID;
                Model.TitleID = Cust.TitleID;
                Model.SurName = Cust.SurName;
                Model.OtherNames = Cust.OtherNames;
                Model.GenderID = Cust.GenderID;
                Model.Cust_Address = Cust.Cust_Address;
                Model.Phone = Cust.Phone;
                Model.Email = Cust.Email;
                Model.CreatedDate = Cust.CreatedDate;
            }


            return PartialView("AddEditViewPartialView", Model);

        }

        
    }
}