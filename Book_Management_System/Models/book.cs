//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace karad.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class book
    {
        public int book_id { get; set; }
        public string book_name { get; set; }
        public string author { get; set; }
        public string category { get; set; }
        public double price { get; set; }
        public int user_id { get; set; }
    
        public virtual User User { get; set; }
    }
}
