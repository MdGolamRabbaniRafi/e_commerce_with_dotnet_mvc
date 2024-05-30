//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AIUB_Task.DAL.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.ProductColorOrderMappers = new HashSet<ProductColorOrderMapper>();
            this.ProductColors = new HashSet<ProductColor>();
            this.ProductOrderMappers = new HashSet<ProductOrderMapper>();
            this.ProductOrderSizeMappers = new HashSet<ProductOrderSizeMapper>();
            this.ProductSizes = new HashSet<ProductSize>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> price { get; set; }
        public string Description { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string Image { get; set; }
        public Nullable<int> Category_Id { get; set; }
    
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductColorOrderMapper> ProductColorOrderMappers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductColor> ProductColors { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductOrderMapper> ProductOrderMappers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductOrderSizeMapper> ProductOrderSizeMappers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductSize> ProductSizes { get; set; }
    }
}
