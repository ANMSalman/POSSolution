//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace POSSolution.Models.OnlineModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class Collection
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public System.DateTime Date { get; set; }
        public string Type { get; set; }
        public double Cash { get; set; }
        public double Cheque { get; set; }
        public double Total { get; set; }
        public Nullable<int> ReturnBillId { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual ReturnBill ReturnBill { get; set; }
    }
}