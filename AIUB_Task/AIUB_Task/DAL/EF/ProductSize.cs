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
    
    public partial class ProductSize
    {
        public int Id { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<int> SizeId { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual Size Size { get; set; }
    }
}
