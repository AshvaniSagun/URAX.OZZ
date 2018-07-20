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
    
    public partial class LookupGroupDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LookupGroupDetail()
        {
            this.LookUpDetails = new HashSet<LookUpDetail>();
        }
    
        public long GroupDetailsId { get; set; }
        public long LookUpGroupId { get; set; }
        public long VariableId { get; set; }
        public Nullable<int> LookupRangeTypeId { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime UpdatedOn { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LookUpDetail> LookUpDetails { get; set; }
        public virtual LookUpGroup LookUpGroup { get; set; }
        public virtual ParameterDetail ParameterDetail { get; set; }
        public virtual Variable Variable { get; set; }
    }
}
