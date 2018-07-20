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
    
    public partial class TaxMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaxMaster()
        {
            this.LanguageDetails = new HashSet<LanguageDetail>();
            this.TaxVersions = new HashSet<TaxVersion>();
        }
    
        public long TaxMasterId { get; set; }
        public long MarketId { get; set; }
        public string TaxName { get; set; }
        public Nullable<int> TaxPositionId { get; set; }
        public int Priority { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime UpdatedOn { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LanguageDetail> LanguageDetails { get; set; }
        public virtual Market Market { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TaxVersion> TaxVersions { get; set; }
    }
}
