using LaunSys.Data.Model_Generated;
using LaunSys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;




namespace LaunSys.Controllers
{
    public class ExpensesController : Controller
    {
        LaunSysDBEntities db = new LaunSysDBEntities();


        //------------------------to set the data for the drop downn----------------
        public void AllDropDowns()
        {
            List<tb_Branch> BranchList = db.tb_Branch.ToList();
            ViewBag.VBranchLists = new SelectList(BranchList, "BranchId", "Branchname");

            //Common comm = 

            List<tb_Status> StatusList = db.tb_Status.ToList();
            ViewBag.VStatusLists = new SelectList(StatusList, "StatusId", "Status");

        }

        // GET: Expenses
        public ActionResult Index()
        {

            AllDropDowns();


            
            List<ExpensesViewModel> ExpensesList = db.tb_Expenses.Where(x => x.tb_Status.Status == true).Select(x => new ExpensesViewModel {
                Date = x.Date,
                Exp_SN = x.Exp_SN,
                Description = x.Description,
                Inv_No = x.Inv_No,
                Amount = x.Amount,
                Branchname = x.tb_Branch.Branchname,
                Id = x.Id,
                Status = x.tb_Status.Status,
                StatusId = x.StatusId
            }).ToList();
            ViewBag.ListOfExpensesData = ExpensesList;

            return View();
        }



        [HttpPost]
        public ActionResult Index(ExpensesViewModel Model)
        {
            try
            {
                AllDropDowns();

                //TO UPDATE EXISITING RECORD
                if (Model.Id > 0)
                {
                    tb_Expenses ExpensesData = db.tb_Expenses.SingleOrDefault(x => x.Id == Model.Id && x.tb_Status.Status == true);
                    ExpensesData.Id = Model.Id;
                    ExpensesData.Date = Model.Date;
                    ExpensesData.Exp_SN = Model.Exp_SN;
                    ExpensesData.Description = Model.Description;
                    ExpensesData.Inv_No = Model.Inv_No;
                    ExpensesData.Amount = Model.Amount;
                    ExpensesData.BranchId = Model.BranchId;
                    ExpensesData.StatusId = Model.StatusId;

                    db.SaveChanges();
                }
                else
                { //TO INSERT NEW EXPENSES DATA
                    tb_Expenses ExpensesData = new tb_Expenses();
                    ExpensesData.Id = Model.Id;
                    ExpensesData.Date = Model.Date;
                    ExpensesData.Exp_SN = Model.Exp_SN;
                    ExpensesData.Description = Model.Description;
                    ExpensesData.Inv_No = Model.Inv_No;
                    ExpensesData.Amount = Model.Amount;
                    ExpensesData.BranchId = Model.BranchId;
                    ExpensesData.StatusId = Model.StatusId;
                    db.tb_Expenses.Add(ExpensesData);
                    db.SaveChanges();

                }

                return View(Model);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //-DELETE EXPENSES
        public JsonResult DeleteExpenses(int Id)
        {
            bool result = false;
            tb_Expenses Expenses = db.tb_Expenses.SingleOrDefault
                (x => x.tb_Status.Status == true && x.Id == Id);
        if(Expenses !=null)
            {
                Expenses.StatusId =2;
            
                db.SaveChanges();
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //----- to view expensis detail Individually
        public ActionResult ViewExpenses(int Id)
        {
            List<ExpensesViewModel> ExpensesDetail = db.tb_Expenses.Where(x => x.tb_Status.Status == true && x.Id == Id).Select(
                x => new ExpensesViewModel
                {
                    Date = x.Date,
                    Exp_SN = x.Exp_SN,
                    Description = x.Description,
                    Inv_No = x.Inv_No,
                    Amount = x.Amount,
                    Branchname = x.tb_Branch.Branchname,
                    Status = x.tb_Status.Status

                }).ToList();
            ViewBag.SingleExpensesDetail = ExpensesDetail;
            return PartialView("SingleExpensesView");
        }
        //---------------------Add Edit-------------------------------
    public ActionResult AddEdit(int Id)
        {
            AllDropDowns();
            //initialize the viewModel responsible for the  Editing
            //To get the record that is to be edited

            ExpensesViewModel Model = new ExpensesViewModel();
            if (Id > 0)
            {
                tb_Expenses Expenses = db.tb_Expenses.SingleOrDefault(x => x.Id == Id && x.tb_Status.Status == true);
                Model.Id = Expenses.Id;
                Model.Date = Expenses.Date;
                Model.Exp_SN = Expenses.Exp_SN;
                Model.Description = Expenses.Description;
                Model.Inv_No = Expenses.Inv_No;
                Model.Amount = Expenses.Amount;
                Model.BranchId = Expenses.BranchId;
                Model.StatusId = Expenses.StatusId;
            }
            //returning resultclass (string viewName, Object Model)
            // return View();

            return PartialView("AddEditViewPartialView", Model);
            
        }
    }
}