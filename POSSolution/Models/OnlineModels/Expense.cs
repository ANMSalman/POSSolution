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
    
    public partial class Expense
    {
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public int AddedBy { get; set; }
    
        public virtual User User { get; set; }
    }
}