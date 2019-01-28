using LaunSys.Data.Model_Generated;
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
           select new NewCustomer{ Name = E.SurName + " " + E.OtherNames, Id = E.CustID }; 

            ViewBag.AllCustomers = Customers.ToList();


            //------------ select all the Branches-----------

            var Branch = from A in db.tb_Branch
                         //select A.Branchname;
                         select new NewBranch{ BranchName = A.Branchname, BranchId = A.BranchId };

            ViewBag.AllBranches = Branch.ToList();
            //--------------------------------------------------------------------
            return View();
        }
    }
}