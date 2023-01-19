//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace POSDemo.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public Product()
        {
            this.prod_suppl = new HashSet<prod_suppl>();
            this.salesBillDetails = new HashSet<salesBillDetails>();
        }
    
        public int id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string Notes { get; set; }
        public string Image { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Nullable<decimal> weight { get; set; }
    
        public virtual Categories Categories { get; set; }
        public virtual ICollection<prod_suppl> prod_suppl { get; set; }
        public virtual ICollection<salesBillDetails> salesBillDetails { get; set; }
    }
}