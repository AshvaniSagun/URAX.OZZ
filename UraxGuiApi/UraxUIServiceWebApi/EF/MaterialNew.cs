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
    
    public partial class MaterialNew
    {
        public int MNId { get; set; }
        public Nullable<long> ContentTypeId { get; set; }
        public string ContentHeading { get; set; }
        public string ContentText { get; set; }
        public Nullable<System.DateTime> PublishStartDate { get; set; }
        public Nullable<System.DateTime> PublishEndDate { get; set; }
        public string ImageUrl { get; set; }
        public string ImageName { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public byte[] ImageData { get; set; }
    }
}
