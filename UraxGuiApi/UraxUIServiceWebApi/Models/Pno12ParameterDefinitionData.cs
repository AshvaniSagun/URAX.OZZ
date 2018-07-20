using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UraxUIServiceWebApi.Models
{
    public class Pno12ParameterDefinitionData
    {
        public int Pno12PdId { get; set; }
        public string DefinitionName { get; set; }
        public string ShortName { get; set; }
        public string DataType { get; set; }
        public Nullable<int> Pno12PtId { get; set; }
        public Nullable<int> Pno12UomId { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
    }
}