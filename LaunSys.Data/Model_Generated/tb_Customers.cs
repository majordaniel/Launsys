//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LaunSys.Data.Model_Generated
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_Customers
    {
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
        public Nullable<int> StatusId { get; set; }
    
        public virtual tb_Gender tb_Gender { get; set; }
        public virtual tb_Status tb_Status { get; set; }
        public virtual tb_Titles tb_Titles { get; set; }
    }
}