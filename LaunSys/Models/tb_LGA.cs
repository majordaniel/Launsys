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
    
    public partial class tb_LGA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_LGA()
        {
            this.tb_Branch = new HashSet<tb_Branch>();
            this.tb_City = new HashSet<tb_City>();
        }
    
        public int LGAId { get; set; }
        public string LGAname { get; set; }
        public Nullable<int> StateId { get; set; }
        public Nullable<int> CountryId { get; set; }
        public Nullable<int> StatusId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Branch> tb_Branch { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_City> tb_City { get; set; }
        public virtual tb_Country tb_Country { get; set; }
        public virtual tb_State tb_State { get; set; }
        public virtual tb_Status tb_Status { get; set; }
        public virtual tb_Status tb_Status1 { get; set; }
    }
}
