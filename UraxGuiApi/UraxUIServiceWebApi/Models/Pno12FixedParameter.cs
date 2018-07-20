using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UraxUIServiceWebApi.Models
{
    public class Pno12FixedParameter
    {
        public int Pno12Id { get; set; }
        public int Pno12PdId { get; set; }
        public string ParameterValue { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
    }
  
}