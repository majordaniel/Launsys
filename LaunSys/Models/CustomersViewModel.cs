using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaunSys.Models
{
    public class CustomersViewModel
    {

        //public int CustID { get; set; }
        //public Nullable<int> TitleID { get; set; }
        //public string SurName { get; set; }
        //public string OtherNames { get; set; }
        //public Nullable<int> GenderID { get; set; }
        //public string Cust_Address { get; set; }
        //public string Phone { get; set; }
        //public Nullable<System.DateTime> CreatedDate { get; set; }
        //public string Email { get; set; }
        //public Nullable<bool> IsActive { get; set; }

        //public virtual tb_Gender tb_Gender { get; set; }
        //public virtual tb_Titles tb_Titles { get; set; }

        //public string  Title { get; set; }
        //public string Gendername { get; set; }

        public int CustID { get; set; }
        public Nullable<int> TitleID { get; set; }
        public string SurName { get; set; }
        public string OtherNames { get; set; }
        public Nullable<int> GenderID { get; set; }
        public string Cust_Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<bool> IsNotActive { get; set; }

        public string Title { get; set; }
        public string Gendername { get; set; }
        public virtual tb_Gender tb_Gender { get; set; }
        public virtual tb_Titles tb_Titles { get; set; }

    }
}