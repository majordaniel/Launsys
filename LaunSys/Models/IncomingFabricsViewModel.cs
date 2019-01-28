using LaunSys.Data.Model_Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaunSys.Models
{
    public class IncomingFabricsViewModel
    {

        public int IncFabId { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public string Customer_Name { get; set; }
        public Nullable<System.DateTime> Date_Recorded { get; set; }
        public string Receipt_No { get; set; }
        public Nullable<int> Total_Amt { get; set; }
        public Nullable<int> BranchId { get; set; }
        public string Recorded_By { get; set; }

        public string Branchname { get; set; }



        public List<tb_Incoming_Fabric_Desc> Incoming_Fabric_Desc { get; set; }
    }
}