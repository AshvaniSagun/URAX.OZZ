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
    
    public partial class Pno12ParameterDefinition
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pno12ParameterDefinition()
        {
            this.Pno12FixedParameters = new HashSet<Pno12FixedParameters>();
            this.Pno12FixedParameters1 = new HashSet<Pno12FixedParameters>();
            this.Pno12FixedParameters2 = new HashSet<Pno12FixedParameters>();
        }
    
        public int Pno12PdId { get; set; }
        public string DefinitionName { get; set; }
        public string ShortName { get; set; }
        public string DataType { get; set; }
        public int Pno12PtId { get; set; }
        public int Pno12UomId { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pno12FixedParameters> Pno12FixedParameters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pno12FixedParameters> Pno12FixedParameters1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pno12FixedParameters> Pno12FixedParameters2 { get; set; }
        public virtual Pno12ParameterType Pno12ParameterType { get; set; }
        public virtual Pno12UnitOfMeasurement Pno12UnitOfMeasurement { get; set; }
    }
}
