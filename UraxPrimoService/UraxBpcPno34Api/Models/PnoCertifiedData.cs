using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UraxBpcPno34Api.EF;

namespace UraxBPCPNO34.Models
{
    public class PnoCertifiedData
    {
        public string Pno12 { get; set; }
        public string ModelYear { get; set; }
        public string Value { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public string CarLine { get; set; }
        public static List<PnoCertifiedData> GetPnoCertifiedData(string modelYear, string bpctaxTerritory,string specificationMarket)
        {
            using (URAXEntities context = new URAXEntities())
            {
                try
                {
                    SqlParameter taxTerritory = new SqlParameter("@TaxTerritory", bpctaxTerritory);
                    SqlParameter imodelYear = new SqlParameter("@ModelYear", modelYear);
                    SqlParameter ispecificationMarket = new SqlParameter("@specificationMarket", specificationMarket);
                    List<PnoCertifiedData> lstResult = context.Database.SqlQuery<PnoCertifiedData>("GetPno12CommercialDataPrimo  @TaxTerritory, @ModelYear,@specificationMarket ", taxTerritory, imodelYear, ispecificationMarket).ToList();
                    return lstResult;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}