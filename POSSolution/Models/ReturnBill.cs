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
    
    public partial class ReturnBill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ReturnBill()
        {
            this.Collections = new HashSet<Collection>();
            this.Payments = new HashSet<Payment>();
            this.ReturnBillItems = new HashSet<ReturnBillItem>();
        }
    
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public string Type { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public Nullable<int> SupplierId { get; set; }
        public double SubTotal { get; set; }
        public double Discount { get; set; }
        public Nullable<double> NetTotal { get; set; }
        public int BilledBy { get; set; }
        public int ShownBy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Collection> Collections { get; set; }
        public virtual Customer Customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReturnBillItem> ReturnBillItems { get; set; }
    }
}
