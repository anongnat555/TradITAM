//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace inventory
{
    using System;
    using System.Collections.Generic;
    
    public partial class supplier
    {
        public int supplier_id { get; set; }
        public string company_name { get; set; }
        public string contact_person { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public Nullable<bool> is_active { get; set; }
        public Nullable<System.DateTime> create_date { get; set; }
        public Nullable<System.DateTime> modified_date { get; set; }
    }
}
