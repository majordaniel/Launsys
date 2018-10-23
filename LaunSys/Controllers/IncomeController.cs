using LaunSys.Data.Model_Generated;
using LaunSys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;




namespace LaunSys.Controllers
{
    public class IncomeController : Controller
    {
              LaunSysDBEntities db = new LaunSysDBEntities();


        //------------------------to set the data for the drop downn----------------
        public void AllDropDown()
        {
            List<tb_Branch> BranchList = db.tb_Branch.ToList();
            ViewBag.VBranchLists = new SelectList(BranchList, "BranchId", "Branchname");


            List<tb_Status> StatusList = db.tb_Status.ToList();
            ViewBag.VStatusLists = new SelectList(StatusList, "StatusId", "Status");

        }
        // GET: Income
        public ActionResult Index()
        {

            AllDropDown();
            // the Listings

            List<IncomesViewModel> IncomeList = db.tb_Income.Where(x => x.tb_Status.Status == true).Select(x => new IncomesViewModel { Date = x.Date, Inc_SN = x.Inc_SN, Description = x.Description, Inv_No = x.Inv_No, Amount = x.Amount, Branchname = x.tb_Branch.Branchname, Id = x.Id }).ToList();
            ViewBag.ListOfIncomeData = IncomeList;


            return View();
        }

   

        [HttpPost]
        public ActionResult Index(IncomesViewModel Model)
        {

            try
            {
                //LaunSysDBEntities db = new LaunSysDBEntities();
                //if (ModelState.IsValid == true)
                //{

                //------------------------To populate the drop down lists---------------------------

                //List<tb_Branch> BranchList = db.tb_Branch.ToList();
                //ViewBag.VBranchLists = new SelectList(BranchList, "BranchId", "Branchname");

                //List<tb_Status> StatusList = db.tb_Status.ToList();
                //ViewBag.VStatusLists = new SelectList(StatusList, "StatusId", "Status");
                AllDropDown();
                ////----------------------------------------------------------------------------------
                if (Model.Id > 0)
                {
                    //UPDATE EXISTING RECORD
                    tb_Income IncomeData = db.tb_Income.SingleOrDefault(x => x.Id == Model.Id && x.tb_Status.Status == true);

                    IncomeData.Id = Model.Id;
                    IncomeData.Date = Model.Date;
                    IncomeData.Inc_SN = Model.Inc_SN;
                    IncomeData.Description = Model.Description;
                    IncomeData.Inv_No = Model.Inv_No;
                     IncomeData.Amount = Model.Amount;
                    IncomeData.BranchId = Model.BranchId;
                    IncomeData.StatusId = Model.StatusId;
                    db.SaveChanges();
                }

                else
                {
                    //INSERT NEW RECORD
                    tb_Income IncomeData = new tb_Income();
                    IncomeData.Id = Model.Id;
                    IncomeData.Date = Model.Date;
                    IncomeData.Inc_SN = Model.Inc_SN;
                    IncomeData.Description = Model.Description;
                    IncomeData.Inv_No = Model.Inv_No;
                    IncomeData.Amount = Model.Amount;
                    IncomeData.BranchId = Model.BranchId;
                    IncomeData.StatusId = Model.StatusId;

                    db.tb_Income.Add(IncomeData);
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

        //-----------------------------Delete Income----------------------------
        public JsonResult DeleteIncome(int Id)
        {
            LaunSysDBEntities db = new LaunSysDBEntities();
            bool result = false;
            tb_Income Income = db.tb_Income.SingleOrDefault(x => x.tb_Status.Status == true && x.Id == Id);

            if (Income != null)
            {
                //set the customer id to true, there fore hide it from the table\
                Income.tb_Status.Status = false;
                db.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //-----------------------------to view Income details individually----------------------------
        public ActionResult ViewIncome(int Id)
        {
            LaunSysDBEntities db = new LaunSysDBEntities();

            List<IncomesViewModel> IncomeDetail = db.tb_Income.Where(x => x.tb_Status.Status == true && x.Id == Id).Select(
                x => new IncomesViewModel
                { Date = x.Date,
                    Inc_SN = x.Inc_SN,
                    Description = x.Description,
                    Inv_No = x.Inv_No,
                    Amount = x.Amount,
                    Branchname = x.tb_Branch.Branchname,
                    Id = x.Id,
                    Status = x.tb_Status.Status }).ToList();

            ViewBag.SingleIncomeDetail = IncomeDetail;
            return PartialView("SingleIncomeView");
        }



        //-----------------------------Add Edit----------------------------
        public ActionResult AddEdit(int Id)
        {
            LaunSysDBEntities db = new LaunSysDBEntities();

            List<tb_Branch> BranchList = db.tb_Branch.ToList();
            ViewBag.VBranchLists = new SelectList(BranchList, "BranchId", "Branchname");

            List<tb_Status> StatusList = db.tb_Status.ToList();
            ViewBag.VStatusLists = new SelectList(StatusList, "StatusId", "Status");

            IncomesViewModel Model = new IncomesViewModel();

            if (Id > 0)
            {
                tb_Income Income = db.tb_Income.SingleOrDefault(x => x.Id == Id && x.tb_Status.Status == true);
                Model.Id = Income.Id;
                Model.Date = Income.Date;
                Model.Inc_SN = Income.Inc_SN;
                Model.Description = Income.Description;
                Model.Inv_No = Income.Inv_No;
                Model.Amount = Income.Amount;
                Model.BranchId = Income.BranchId;
                Model.StatusId = Income.StatusId;

            }


            return PartialView("AddEditViewPartialView", Model);

        }

    }
}