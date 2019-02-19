using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using LaunSys.Models;
using LaunSys.Data.Model_Generated;

namespace LaunSys.Controllers
{
    public class HighCustomers
    {
        public string IncFabId { get; set; }
        public string Customer_Name { get; set; }
        public string Branchname { get; set; }
        public string Total_Amt { get; set; }


    }
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

            var Balance = TotIncAmt - TotExpAmt;
            var RoundPerc = Balance / TotIncAmt * 100;
            var PercProgress = (int) Math.Round(RoundPerc.Value);
           

            //% gain = 
           
            ViewBag.Gain = PercProgress;

            //total no of Fabrics
            // var TotNoOfFabrics = (from x in db.tb_Incoming_Fabrics select x.IncFabId).Count();

            var TotNoOfFabrics = (from x in db.tb_Incoming_Fabric_Desc select x.Qty).Sum();
            ViewBag.TotNoOfFabrics = TotNoOfFabrics;

            //total fabric by each customer

            var TotFabByCustomer = from x in db.tb_Incoming_Fabric_Desc
                                   group x by x.Qty into y
                                   select new
                                   {
                                       name = y.Key,
                                       TotFab = y.Count()
                                   };


            //Highest paid Customer
            //get the highest amount
            var amt = (from x in db.tb_Incoming_Fabrics select x.Total_Amt).Max();
            //check the name of the person with the highest amount

            //var HighestCust = from x in db.tb_Incoming_Fabrics
            //                  where x.Total_Amt == amt
            //                  //select x.Customer_Name;
            //                  select x.CustomerId;


            var HighestCust = from x in db.tb_Incoming_Fabrics
                              join y in db.tb_Customers
                                on x.CustomerId equals y.CustID

                              //where x.Total_Amt == amt
                              //select y.SurName.ToString() + " " + y.OtherNames.ToString();


                                where y.CustID == x.CustomerId && x.Total_Amt == amt

                              select y.SurName.ToString() + " " + y.OtherNames.ToString();


            //select new
            //{
            //    Name = y.OtherNames.ToString() + " " + y.OtherNames.ToString()
            //};

            //hold the ID of the Highest paid customer
            ViewBag.HighestPaidCust = HighestCust.FirstOrDefault();


            // checked the customers table to know the exact name with the ID shown
            //string ActCust = db.tb_Customers.Where(x => x.CustID  C);

            //var Q = (from e in db.tb_Customers
            //         where e.CustID == HighestCust.FirstOrDefault 
            //         select e).


            //-------------------------------------------------------------------------------------------

            //customers above 100 naira
            //var CustomersAbove100 = db.tb_IncomingFabric.Include("tb_Branch").Where(x => x.Amount > 100).ToList();

            // var CustomersAbove100 = db.tb_IncomingFabric.Where(x => x.Amount > 100).ToList();

            //-------------------------------------------------------------------------------------------

            //var CustomersAbove100 = from x in db.tb_Incoming_Fabrics
            //                        join y in db.tb_Branch on x.tb_Branch.BranchId equals y.BranchId
            //                        where  x.Total_Amt > 100
            //                        select x;

            //ViewBag.CustomersAbove100 = CustomersAbove100.ToList();

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

            //ViewBag.CustomersAbove100 = CustomersAbove100.ToList();
            //---------------------------------------------------------------
            // tb_IncomingFabric-------IncFabId, Customer_Name, BranchId
            // tb_IncomingFabric_Desc --------IncFabId, Total_Amt
            //tb_Branch-----------BranchId, Branchname


            //select a.IncFabId, a.Customer_Name, b.Total_Amt, c.Branchname from tb_IncomingFabric a join tb_IncomingFabric_Desc b where a.IncFabId =b.IncFabId
            // join tb_Branch c where c. tb_Branch =a.BranchId

            var highCustomers = from a in db.tb_Incoming_Fabrics
                                join b in db.tb_Branch on a.BranchId equals b.BranchId
                                join n in db.tb_Customers on a.CustomerId equals n.CustID
                                join c in db.tb_Incoming_Fabric_Desc on a.IncFabId equals c.IncFabId
                                where c.Total_Amt > 10000

                                select new
                                {
                                    IncFabId = a.IncFabId.ToString(),
                                    Customer_Name = n.SurName + " " + n.OtherNames,
                                    Branchname = b.Branchname,
                                    Total_Amt = c.Total_Amt.ToString(),
                                };

            var myList = highCustomers.ToList();
            List<HighCustomers> listOfHighCustomers = new List<HighCustomers>();
            foreach (var customer in myList)
            {
                HighCustomers tempCustomer = new HighCustomers()
                {
                    Branchname = customer.Branchname,
                    Customer_Name = customer.Customer_Name,
                    IncFabId = customer.IncFabId,
                    Total_Amt = customer.Total_Amt
                };

                listOfHighCustomers.Add(tempCustomer);
            }

            ViewBag.CustomersAbove100 = listOfHighCustomers;

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

    }
}