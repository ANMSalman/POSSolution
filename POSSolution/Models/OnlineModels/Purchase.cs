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
    
    public partial class Purchase
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public System.DateTime Date { get; set; }
        public double Amount { get; set; }
    
        public virtual Supplier Supplier { get; set; }
    }
}
