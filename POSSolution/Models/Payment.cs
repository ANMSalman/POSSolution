//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace POSSolution.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Payment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Payment()
        {
            this.Cheques = new HashSet<Cheque>();
        }
    
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public System.DateTime Date { get; set; }
        public string Type { get; set; }
        public double Cash { get; set; }
        public double Cheque { get; set; }
        public double Total { get; set; }
        public Nullable<int> PaymentBillId { get; set; }
        public Nullable<int> ReturnBillId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cheque> Cheques { get; set; }
        public virtual PaymentBill PaymentBill { get; set; }
        public virtual ReturnBill ReturnBill { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
