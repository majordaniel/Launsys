using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LaunSys.Models
{
    public class IncomesViewModel
    {


        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Date")]
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> Inc_SN { get; set; }
        [Required(ErrorMessage = "Select Income Description")]
        public string Description { get; set; }
        public string Inv_No { get; set; }
        [Required(ErrorMessage = "Enter Amount")]
        public Nullable<decimal> Amount { get; set; }


        [Required(ErrorMessage = "Select Branch")]
        public Nullable<int> BranchId { get; set; }

        [Required(ErrorMessage = "Select Status")]
        public Nullable<int> StatusId { get; set; }

        public string Branchname { get; set; }
        public Nullable<bool> Status { get; set; }
    }
}