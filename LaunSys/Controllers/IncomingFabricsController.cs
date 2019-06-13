using LaunSys.Data.Model_Generated;
using LaunSys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaunSys.Controllers
{


    public class NewCustomer
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }

    public class NewBranch
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }
    }
    public class IncomingFabricsController : Controller
    {

        LaunSysDBEntities db = new LaunSysDBEntities();

        // GET: IncomingFabrics
        public ActionResult Index()
        {

            List<tb_Branch> BranchList = db.tb_Branch.ToList();
            ViewBag.VBranchLists = new SelectList(BranchList, "BranchId", "Branchname");

            List<tb_Customers> CustomersList = db.tb_Customers.ToList();
            ViewBag.VCustList = new SelectList(CustomersList, "CustID", "SurName");


            //-----------------WHEN USING SELECT INPLACE OF THE RAZOR DROPDOWN HELPER TAG--------------
            //----------list all the ustomers name
            var Customers = from E in db.tb_Customers
                                // select E.SurName + " " + E.OtherNames;
                            select new NewCustomer { Name = E.SurName + " " + E.OtherNames, Id = E.CustID };

            ViewBag.AllCustomers = Customers.ToList();


            //------------ select all the Branches-----------

            var Branch = from A in db.tb_Branch
                             //select A.Branchname;
                         select new NewBranch { BranchName = A.Branchname, BranchId = A.BranchId };

            ViewBag.AllBranches = Branch.ToList();
            //--------------------------------------------------------------------
            return View();
        }


        public JsonResult SaveIncomingfabric(IncomingFabricsViewModel IncfabricData)
        {
            bool status = false;

            //if (ModelState.IsValid)
            //{

            //------------------alternatively--------------

            //tb_Incoming_Fabrics incFab = new tb_Incoming_Fabrics();

            //incFab.BranchId = IncfabricData.BranchId;
            //incFab.Branch_Name = IncfabricData.Branchname;
            //incFab.CustomerId = IncfabricData.CustomerId;
            //incFab.Customer_Name = IncfabricData.Customer_Name;
            //incFab.Date_Recorded = DateTime.Now;
            //incFab.Receipt_No = IncfabricData.Receipt_No;
            //incFab.Total_Amt = IncfabricData.Total_Amt;
            //incFab.Recorded_By = Session["Email"].ToString();

            //db.tb_Incoming_Fabrics.Add(incFab);

            //foreach (var IndFab in IncfabricData.Incoming_Fabric_Desc)
            //{
            //    IndFab.IncFabId = incFab.IncFabId;
            //    incFab.tb_Incoming_Fabric_Desc.Add(IndFab);
            //}
            //db.tb_Incoming_Fabrics.Add(incFab);
            //db.SaveChanges();
            //status = true;

            //------------------end of alternatively--------------
            using (LaunSysDBEntities IncFabDetail = new LaunSysDBEntities())
            {
                tb_Incoming_Fabrics FabInfo = new tb_Incoming_Fabrics
                {
                    BranchId = IncfabricData.BranchId,
                    //Branch_Name = IncfabricData.Branch_Name,
                    CustomerId = IncfabricData.CustomerId,
                    //Customer_Name = IncfabricData.Customer_Name,
                    Date_Recorded = DateTime.Now,
                    Receipt_No = IncfabricData.Receipt_No,
                    Total_Amt = IncfabricData.Total_Amt,
                    Recorded_By = Session["Email"].ToString(),
                };
                //tb_Incoming_Fabrics FabInfo = new tb_Incoming_Fabrics
                //{                    
                //    CustomerId = 990
                //};
                IncFabDetail.tb_Incoming_Fabrics.Add(FabInfo);
                IncFabDetail.SaveChanges();

                foreach (var IndfabDetail in IncfabricData.Incoming_Fabric_Desc)
                {
                    //FabInfo.tb_Incoming_Fabric_Desc.Add(IndfabDetail);
                    
                    IndfabDetail.IncFabId = FabInfo.IncFabId;
                    IncFabDetail.tb_Incoming_Fabric_Desc.Add(IndfabDetail);
                }

                //IncFabDetail.tb_Incoming_Fabrics.Add(FabInfo);
                //tb_Incoming_Fabric_Desc FabDescription = new tb_Incoming_Fabric_Desc()
                //{
                //    Description = IncfabricData.Incoming_Fabric_Desc.
                //};
                //IncFabDetail.tb_Incoming_Fabric_Desc.Add()

                //IncFabDetail.tb_Incoming_Fabrics.Add(FabInfo);
                IncFabDetail.SaveChanges();
                status = true;
            }
            //----------------------------------------------------------

            //using (LaunSysDBEntities IncFabDetail = new LaunSysDBEntities())
            //    {
            //        tb_Incoming_Fabrics FabInfo = new tb_Incoming_Fabrics
            //        {
            //            BranchId = IncfabricData.BranchId,
            //            Branch_Name = IncfabricData.Branch_Name,
            //            CustomerId = IncfabricData.CustomerId,
            //            Customer_Name = IncfabricData.Customer_Name,
            //            Date_Recorded = DateTime.Now,
            //            Receipt_No = IncfabricData.Receipt_No,
            //            Total_Amt = IncfabricData.Total_Amt,
            //            Recorded_By = Session["Email"].ToString(),
            //        };


            //    IncFabDetail.tb_Incoming_Fabrics.Add(FabInfo);
            //    IncFabDetail.SaveChanges();
            //    int X = FabInfo.IncFabId;

            //        foreach(var IndfabDetail in IncfabricData.Incoming_Fabric_Desc)

            //        {
            //        IndfabDetail.IncFabId = X;
            //        FabInfo.tb_Incoming_Fabric_Desc.Add(IndfabDetail);
            //        IncFabDetail.SaveChanges();
            //        };

            //        status = true;
            //    }
            //-----------------------------------------------another---------------------
            //}

            //else
            //{
            //    status = false;
            //}


            return new JsonResult { Data = new { status = status } };
        }
    }
}