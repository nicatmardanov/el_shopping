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
    
    public partial class product_review
    {
        public int id { get; set; }
        public Nullable<int> product_id { get; set; }
        public Nullable<int> user_id { get; set; }
        public Nullable<int> reply_user_id { get; set; }
        public string text { get; set; }
    
        public virtual product product { get; set; }
        public virtual user user { get; set; }
        public virtual user user1 { get; set; }
    }
}
