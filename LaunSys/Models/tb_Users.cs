//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LaunSys.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_Users
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Nullable<int> RoleId { get; set; }
        public Nullable<int> DivisionId { get; set; }
        public Nullable<int> BranchId { get; set; }
        public Nullable<int> DeptId { get; set; }
        public Nullable<int> StatusId { get; set; }
    
        public virtual tb_Division tb_Division { get; set; }
        public virtual tb_Role tb_Role { get; set; }
        public virtual tb_Status tb_Status { get; set; }
        public virtual tb_Branch tb_Branch { get; set; }
        public virtual tb_Department tb_Department { get; set; }
    }
}
