#region NameSpace
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
#endregion

namespace UraxUIServiceWebApi.Models
{
    public class FormulaDefinitionDependencyDetails
    {
        #region FormulaDefinitionDependencyDetails Property

        [JsonProperty(PropertyName = "frmDepId")]
        public long FrmDepId { get; set; }
        [JsonProperty(PropertyName = "formulaId")]
        public long FormulaId { get; set; }
        [JsonProperty(PropertyName = "variableId")]
        public long VariableId { get; set; } 
        #endregion
    }
}