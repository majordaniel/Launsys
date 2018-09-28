using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using LaunSys.Models;

namespace LaunSys.Controllers
{
    public class HomeController : Controller
    {
        LaunSysDBEntities db = new LaunSysDBEntities();
        public ActionResult Index()
        {

            //Total Income
            var TotIncAmt = (from x in db.tb_Income select x.Amount).Sum();
            ViewBag.TotIncome = TotIncAmt;
            //Total Expensis
            var TotExpAmt = (from x in db.tb_Expenses select x.Amount).Sum();
            ViewBag.TotExpensis = TotExpAmt;

            // Gain so far
            var Gain = TotIncAmt - TotExpAmt;
            ViewBag.Gain = Gain;

            //total no of Fabrics
            var TotNoOfFabrics = (from x in db.tb_IncomingFabric select x.Id).Count();
            ViewBag.TotNoOfFabrics = TotNoOfFabrics;

            //total fabric by each customer

            var TotFabByCustomer = from x in db.tb_IncomingFabric
                                   group x by x.Qty into y
                                   select new
                                   {
                                       name = y.Key,
                                       TotFab = y.Count()
                                   };
            

            //Highest paid Customer
            var amt = (from x in db.tb_IncomingFabric select x.Amount).Max();

            var HighestCust = from x in db.tb_IncomingFabric
                              where x.Amount == amt
                              select x.Cust_Name;

            ViewBag.HighestPaidCust = HighestCust;


            //customers above 100 naira
            var CustomersAbove100 = db.tb_IncomingFabric.Where(x => x.Amount > 100).ToList();

            ViewBag.CustomersAbove100 = CustomersAbove100;

            //No of Active Customers

            //var ActCust = from x in db.tb_Customers where x.IsNotActive == 1 select x.
            var ActCust = db.tb_Customers.Where(x => x.IsNotActive == false).Count();

            ViewBag.NoOfActiveCustomers = ActCust;

            //No of InActive Customers
            var InActCust = db.tb_Customers.Where(x => x.IsNotActive == true).Count();
            ViewBag.NoOfInActiveCustomers = InActCust;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}