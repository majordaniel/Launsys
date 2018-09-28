using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LaunSys.Models
{
    public class UsersViewModel
    {

        public int UserId { get; set; }
        [Required(ErrorMessage = "Please Enter Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }
        public Nullable<int> RoleId { get; set; }
        public Nullable<int> DivisionId { get; set; }
        public Nullable<int> BranchId { get; set; }
      
        public Nullable<int> DeptId { get; set; }
        public Nullable<int> StatusId { get; set; }




        public string Rolename { get; set; }
        public string Divisionname { get; set; }
        public string Branchname { get; set; }
        public string Deptname { get; set; }
        public Nullable<bool> Status { get; set; }

    
    }
}