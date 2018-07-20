using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UraxBpcPno34Api.Models
{
   public class TaxNameDetails
    {
        public int TaxMasterId { get; set; }
        public string TaxName { get; set; }
        public bool IsDefault { get; set; }
        public string LanguageCountrycode { get; set; }
    }
}
