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
        public void BranchList()
        {
           
            List<tb_Branch> BranchList = db.tb_Branch.ToList();

            //ViewBag.VBranchLists = new SelectList(BranchList, "BranchId", "Branchname");
            //ViewBag.VStatusLists = new SelectList(StatusList, "StatusId", "Status");
            

        }
        public void StatusList()
        {
            List<tb_Status> StatusList = db.tb_Status.ToList();
        }
    }
}
