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
    
    public partial class message
    {
        public int id { get; set; }
        public Nullable<int> from_user_id { get; set; }
        public Nullable<int> to_user_id { get; set; }
        public Nullable<bool> see { get; set; }
        public string text { get; set; }
    
        public virtual user user { get; set; }
        public virtual user user1 { get; set; }
    }
}