//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UraxUIServiceWebApi.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class SubdivisionCode
    {
        public int SubdivisionCodeId { get; set; }
        public int CountryCodeId { get; set; }
        public string SubdivisionCode1 { get; set; }
        public string SubdivisionName { get; set; }
        public string LocalName { get; set; }
        public string Descriptions { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime UpdatedOn { get; set; }
    
        public virtual CountryCode CountryCode { get; set; }
    }
}
