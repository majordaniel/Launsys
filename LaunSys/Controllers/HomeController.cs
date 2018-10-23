using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using LaunSys.Models;
using LaunSys.Data.Model_Generated;

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

            ViewBag.HighestPaidCust = HighestCust.FirstOrDefault();

            //-------------------------------------------------------------------------------------------

            //customers above 100 naira
            //var CustomersAbove100 = db.tb_IncomingFabric.Include("tb_Branch").Where(x => x.Amount > 100).ToList();

           // var CustomersAbove100 = db.tb_IncomingFabric.Where(x => x.Amount > 100).ToList();

            //-------------------------------------------------------------------------------------------
            var CustomersAbove100 = from x in db.tb_IncomingFabric
                                    join y in db.tb_Branch on x.tb_Branch.BranchId equals y.BranchId
                                    where  x.Amount > 100
                                    select x;

            ViewBag.CustomersAbove100 = CustomersAbove100.ToList();

  //-------------------------------------------------------------------------------------------

                                    //var CustomersAbove100 = db.tb_IncomingFabric.Select(x => new
                                    //{
                                    //    Cust_Name = x.Cust_Name,
                                    //    Inv_No = x.Inv_No,
                                    //    Branch = x.tb_Branch.Branchname
                                    //}).ToList();
                                    //-------------------------------------------------------------------------------------------

                                    //var CustomersAbove100 = from x in db.tb_IncomingFabric
                                    //                        join y in db.tb_Branch on x.tb_Branch.BranchId equals y.BranchId
                                    //                        select new
                                    //                        {
                                    //                            Cust_Name = x.Cust_Name,
                                    //                            Inv_No = x.Inv_No,
                                    //                            Branch = y.Branchname
                                    //                        };
                                    //-------------------------------------------------------------------------------------------
                                    //var Cus = (from x in db.tb_IncomingFabric where x.Amount > 100 join y in db.tb_Branch on x.BranchId equals y.BranchId
                                    //           select new
                                    //           {
                                    //               Cust_Name = x.Cust_Name,
                                    //               Inv_No = x.Inv_No,
                                    //           Branch = y.Branchname
                                    //           }).ToList();
                                    //ViewBag.CusAbove100 = Cus;

                                    //-------------------------------------------------------------------------------------------
                                    //No of Active Customers
                                    //var ActCust = from x in db.tb_Customers where x.IsNotActive == 1 select x.
            var ActCust = db.tb_Customers.Where(x => x.IsNotActive == false).Count();
            ViewBag.NoOfActiveCustomers = ActCust;

            //No of InActive Customers
            var InActCust = db.tb_Customers.Where(x => x.IsNotActive == true).Count();
            ViewBag.NoOfInActiveCustomers = InActCust;

            //Total No of  Customers
            var TotalCust = db.tb_Customers.Count();
            ViewBag.TotalCustomers = TotalCust;

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