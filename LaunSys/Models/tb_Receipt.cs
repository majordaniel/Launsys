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
    
    public partial class tb_Receipt
    {
        public int ReceiptId { get; set; }
        public string InvoiceNo { get; set; }
        public string CustomerName { get; set; }
        public string CustAddress { get; set; }
        public string CustPhone { get; set; }
        public string FabricDescription { get; set; }
        public Nullable<int> Qty { get; set; }
        public Nullable<int> UnitPrice { get; set; }
        public Nullable<long> Total { get; set; }
        public Nullable<System.DateTime> ReceiptDate { get; set; }
        public Nullable<System.DateTime> PickUpDate { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> BranchId { get; set; }
        public Nullable<int> StatusId { get; set; }
    
        public virtual tb_Branch tb_Branch { get; set; }
        public virtual tb_Status tb_Status { get; set; }
    }
}
