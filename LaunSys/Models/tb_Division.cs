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
    
    public partial class tb_Division
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_Division()
        {
            this.tb_Users = new HashSet<tb_Users>();
            this.tb_Employees = new HashSet<tb_Employees>();
        }
    
        public int DivisionId { get; set; }
        public string Divisionname { get; set; }
        public string MIScode { get; set; }
        public Nullable<int> StatusId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Users> tb_Users { get; set; }
        public virtual tb_Status tb_Status { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Employees> tb_Employees { get; set; }
    }
}
