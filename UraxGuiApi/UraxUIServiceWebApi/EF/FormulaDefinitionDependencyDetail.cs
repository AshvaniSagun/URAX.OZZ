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
    
    public partial class FormulaDefinitionDependencyDetail
    {
        public long FrmDepId { get; set; }
        public long FormulaId { get; set; }
        public long VariableId { get; set; }
    
        public virtual Formula Formula { get; set; }
        public virtual Variable Variable { get; set; }
    }
}
