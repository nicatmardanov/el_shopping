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
    
    public partial class order
    {
        public int id { get; set; }
        public Nullable<int> prod_id { get; set; }
        public Nullable<int> user_id { get; set; }
        public Nullable<int> order_info_id { get; set; }
        public Nullable<int> card_id { get; set; }
    
        public virtual card card { get; set; }
        public virtual order_info order_info { get; set; }
        public virtual product product { get; set; }
        public virtual user user { get; set; }
    }
}
