using LaunSys.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaunSys.Controllers
{
    public class CustomersController : Controller
    {

        LaunSysDBEntities db = new LaunSysDBEntities();

        // GET: Customers
        public ActionResult Index()
        {
            List<tb_Titles> TitlesList = db.tb_Titles.ToList();
            ViewBag.ListOfTitles = new SelectList(TitlesList, "TitleID", "Title");

            List<tb_Gender> GendersList = db.tb_Gender.ToList();
            ViewBag.ListOfGenders = new SelectList(GendersList, "GenderID", "Gendername");




            return View();
        }

        public JsonResult GetCustomersList()
        {

            List<CustomersViewModel> CustList = db.tb_Customers.Where(x => x.IsNotActive==false).Select(x => new CustomersViewModel

            {
                CustID = x.CustID,
                Title = x.tb_Titles.Title,
                SurName= x.SurName,
                OtherNames = x.OtherNames,
                Gendername= x.tb_Gender.Gendername,
                Cust_Address = x.Cust_Address,
                Phone = x.Phone,
                Email=x.Email,
                CreatedDate =x.CreatedDate,
            
            }).ToList();

            return Json(CustList, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetData()
        {
            using (LaunSysDBEntities db = new LaunSysDBEntities())
            {
                List<tb_IncomingFabric> incFab = db.tb_IncomingFabric.ToList<tb_IncomingFabric>();
                return Json(new { data = incFab }, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult GetCustomerID(int CustID)
        {
          
            tb_Customers model = db.tb_Customers.Where(x => x.CustID == CustID).SingleOrDefault();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public JsonResult InsertCustomers(CustomersViewModel model)
        {
            var result = false;
            try
            {
                if (model.CustID > 0)
                {
                    tb_Customers Cust = db.tb_Customers.SingleOrDefault(x => x.IsNotActive == false && x.CustID == model.CustID);
                    Cust.TitleID = model.TitleID;
                    Cust.SurName = model.SurName;
                    Cust.OtherNames = model.OtherNames;
                    Cust.GenderID = model.GenderID;
                    Cust.Cust_Address = model.Cust_Address;
                    Cust.Phone = model.Phone;
                    Cust.Email = model.Email;
                    Cust.CreatedDate = model.CreatedDate;
                    //Cust.IsNotActive = false;
                    //3077145452
                    db.SaveChanges();
                    result = true;
                }
                else
                {
                    tb_Customers Cust = new tb_Customers();

                    Cust.TitleID = model.TitleID;
                    Cust.SurName = model.SurName;
                    Cust.OtherNames = model.OtherNames;
                    Cust.GenderID = model.GenderID;
                    Cust.Cust_Address = model.Cust_Address;
                    Cust.Phone = model.Phone;
                    Cust.Email = model.Email;
                    Cust.CreatedDate = model.CreatedDate;
                    Cust.IsNotActive = false;

                    db.tb_Customers.Add(Cust);
                    db.SaveChanges();
                    result = true;
                }

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                   throw ex;
            }
          
        }

        public JsonResult DeleteCustomerRecord(int CustID) {
            bool result = false;
            tb_Customers Cust = db.tb_Customers.SingleOrDefault(x => x.IsNotActive == false && x.CustID == CustID);
            if (Cust != null)
            {
                Cust.IsNotActive = true;
                db.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //public  JsonResult GetSearchingData(string SearchBy, string SearchValue)
        //{
        //    List<tb_Customers> CustList = new List<tb_Customers>();
        //    if (SearchBy == "CustID")
        //    {
        //        try
        //        {
        //            int CustID = Convert.ToInt32(SearchValue);
        //            CustList = db.tb_Customers.Where(x => x.CustID == CustID || SearchValue == null).ToList();
        //        }
        //        catch (FormatException)
        //        {

        //            Console.WriteLine("{0} Is Not a Valid ID", SearchValue);
        //        }
        //        return Json(CustList, JsonRequestBehavior.AllowGet);
        //    }
        //    else 
        //    {
        //        CustList = db.tb_Customers.Where(x => x.SurName.Contains(SearchValue) || SearchValue == null).ToList();
        //        return Json(CustList, JsonRequestBehavior.AllowGet);
        //    }
        //}
    }
}