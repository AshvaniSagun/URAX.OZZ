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
    
    public partial class PnoVariableMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PnoVariableMaster()
        {
            this.PnoParameters = new HashSet<PnoParameter>();
        }
    
        public int VariableMasterId { get; set; }
        public int PnoGroupId { get; set; }
        public string VariableName { get; set; }
        public string VariableCode { get; set; }
        public string Datatype { get; set; }
        public bool Isactive { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime UpdatedOn { get; set; }
        public string GuiName { get; set; }
        public int GroupTypeId { get; set; }
    
        public virtual PnoGroupMaster PnoGroupMaster { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PnoParameter> PnoParameters { get; set; }
    }
}
