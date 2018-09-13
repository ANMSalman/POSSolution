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
    
    public partial class PaymentBill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PaymentBill()
        {
            this.Payments = new HashSet<Payment>();
            this.PaymentBillItems = new HashSet<PaymentBillItem>();
            this.PaymentBillReturnItems = new HashSet<PaymentBillReturnItem>();
        }
    
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public Nullable<int> SupplierId { get; set; }
        public double SubTotal { get; set; }
        public double Discount { get; set; }
        public double ReturnAmount { get; set; }
        public double NetTotal { get; set; }
        public int BilledBy { get; set; }
        public int ShownBy { get; set; }
        public string Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PaymentBillItem> PaymentBillItems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PaymentBillReturnItem> PaymentBillReturnItems { get; set; }
    }
}