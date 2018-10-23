using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaunSys.Data.Model_Generated;
using System.Web;


namespace LaunSys.Common
{
    class Controls
    {       
        LaunSysDBEntities db = new LaunSysDBEntities();


        //------------------------to set the data for the drop downn----------------
        public void AllDropDowns()
        {
            List<tb_Branch> BranchList = db.tb_Branch.ToList();


            //ViewBag.VBranchLists = new SelectList(BranchList, "BranchId", "Branchname");


            //List<tb_Status> StatusList = db.tb_Status.ToList();
            //ViewBag.VStatusLists = new SelectList(StatusList, "StatusId", "Status");

        }
    }
}
