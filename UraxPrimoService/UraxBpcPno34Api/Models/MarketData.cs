using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using UraxBpcPno34Api.EF;
namespace UraxBPCPNO34Api.Models
{
    public struct MarketData
    {

        public string MarketName { get; set; }
        public string CountryCode { get; set; }
        public string TaxName { get; set; }
        public int TaxPriority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string TaxFlow { get; set; }
        public int TaxFlowId { get; set; }
        public string VariableName { get; set; }
        public bool IslookUp { get; set; }
        public int FormulaPriority { get; set; }
        public string VariableType { get; set; }
        public int VariableTypeId { get; set; }
        public string UnitType { get; set; }
        public int UnitTypeId { get; set; }
        public string FormulaDefination { get; set; }
        public string LookUpRange { get; set; }
        public int LookupRangeTypeId { get; set; }
        public string LookUpGroupName { get; set; }
        public int LookUpGroup { get; set; }
        public string GroupDetails { get; set; }
        public string Value { get; set; }
        public string ValueRange { get; set; }
        public int TaxPositionId { get; set; }
        public string VatPosition { get; set; }
        public decimal? MinValue { get; set; }
        public decimal? MaxValue { get; set; }
        public bool IsFormulaAvailable { get; set; }
        public int TaxMasterId { get; set; }
        public string DefaultValue { get; set; }

        public static List<MarketData> GetEntityMarketData(string bpcMarketCode, string priceDate, string bpctaxTerritory)
        {
            using (URAXEntities context = new URAXEntities())
            {
                try
                {
                    SqlParameter marketCode = new SqlParameter("@BPC_Market_Code", bpcMarketCode);
                    SqlParameter taxTerritory = new SqlParameter("@bpctaxTerritory", bpctaxTerritory);
                    SqlParameter PriceDate = new SqlParameter("@Price_Date", Convert.ToDateTime(priceDate));
                    List<MarketData> lstResult = context.Database.SqlQuery<MarketData>("GetMarketData  @BPC_Market_Code, @Price_Date ,@bpctaxTerritory ", marketCode, PriceDate, taxTerritory).ToList();
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