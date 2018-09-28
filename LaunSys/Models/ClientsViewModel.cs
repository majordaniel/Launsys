using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LaunSys.Models
{
    public class ClientsViewModel
    {

        public int CustID { get; set; }
        [Required(ErrorMessage = "Please Enter Select Title")]
        public Nullable<int> TitleID { get; set; }
        [Required(ErrorMessage ="Please Enter Sur Name")]
        public string SurName { get; set; } 
        public string OtherNames { get; set; }
        public Nullable<int> GenderID { get; set; }
        [Required(ErrorMessage = "Please Enter the Address")]
        public string Cust_Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<bool> IsNotActive { get; set; }


        public string Title { get; set; }

        public string Gendername { get; set; }




    }
}