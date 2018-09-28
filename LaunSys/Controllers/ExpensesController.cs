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
        // GET: Expenses
        public ActionResult Index()
        {
            //LaunSysDBEntities db = new LaunSysDBEntities();

            //List<tb_Branch> BranchList = db.tb_Branch.ToList();
            //ViewBag.VBranchLists = new SelectList(BranchList, "BranchId", "Branchname");


            //List<tb_Status> StatusList = db.tb_Status.ToList();
            //ViewBag.VStatusLists = new SelectList(StatusList, "StatusId", "Status");

            //List<IncomesViewModel> IncomeList = db.tb_Income.Where(x => x.tb_Status.Status == true).Select(x => new IncomesViewModel { Date = x.Date, Inc_SN = x.Inc_SN, Description = x.Description, Inv_No = x.Inv_No, Amount = x.Amount, Branchname = x.tb_Branch.Branchname, Id = x.Id }).ToList();

            //ViewBag.ListOfIncomeData = IncomeList;

            return View();
        }
    }
}