//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace elite_shopping.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class color_prod_pivot
    {
        public int id { get; set; }
        public Nullable<byte> color_id { get; set; }
        public Nullable<int> product_id { get; set; }
    
        public virtual color color { get; set; }
        public virtual product product { get; set; }
    }
}