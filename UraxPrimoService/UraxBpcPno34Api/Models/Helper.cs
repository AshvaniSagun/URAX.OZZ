using System.Collections.Generic;
namespace UraxBpcPno34Api.Models
{
    enum ExclMetods { ROUND, ROUNDUP, MAX, MIN, ROUNDDOWN, IF,EXP };
    public static class Helper
    {
        public const int iBeforeVat = 1;
        public const int iVat = 2;
        public const int iAfterVat = 3;
        public const int iMSRPFlow = 5;
        public const int iPRETAXFlow = 4;
        public const int iInput = 6;
        public const int iFixed = 7;
        public const int iResult = 8;
        public const int iCalculated = 9;
        public const int iDependency = 10;
        public const int iPercentage = 11;
        public const int iRange = 12;
        public const int iFixedRange = 13;
        public const string sPBMSRP = "MSRP";
        public const string sPBPRETAX = "PRETAX";
        public const string sPattern = @"[=><,\(\)*+/-]";
        public const int iPBPRETAX = 5;
        public const int iPBMSRP = 4;
        public const string sBeforeVat = "BEFORE";
        public const int iBeforeVatId = 1;
        public const string sVat = "VAT";
        public const int iVatId = 2;
        public const string sAfterVat = "AFTER";

        public const string strPno34 = "pno34";
        public const string strpriceType = "priceType";
        public const string strstructureWeek = "structureWeek";
        public const string strCountryCode = "CountryCode";
        public const string strGCCTaxPartnerGroup = "GCCTaxPartnerGroup";
        public const string strTaxTerritory = "TaxTerritory";
        public const string strModelYear = "ModelYear";
        public const string strPriceDate = "PriceDate";
        public const string strSpecificationMarket = "SpecificationMarket";
        public const string strCurrencyCode = "CurrencyCode";

        public const string strNotCertified = "NOTCERTIFIED";
        public const string strCertified = "PRODUCTION";

        public const string strError = "Error";
        public const string sUraxApplicationServer = "Urax Apllication";
        public const string strWarning = "Warning";

        public const string KeyPrefix = "OG_";

        public static Dictionary<string, string>  Getpno34DataDatakey()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("Locale", "CalculateTaxCombinedRequest.Locale");
            dic.Add("Environment", "CalculateTaxCombinedRequest.Environment");
            dic.Add("Revision", "CalculateTaxCombinedRequest.Revision");
            dic.Add("Application", "CalculateTaxCombinedRequest.ApplicationArea.Sender.Application");
            dic.Add("RequestDatetimeCreated", "CalculateTaxCombinedRequest.ApplicationArea.Sender.RequestCreatedDatetime");
            dic.Add("SequenceId", "CalculateTaxCombinedRequest.ApplicationArea.Sender.SequenceId");
            dic.Add("CountryCode", "CalculateTaxCombinedRequest.DataArea.CountryCode");
            dic.Add("TaxTerritory", "CalculateTaxCombinedRequest.DataArea.TaxTerritory");
            dic.Add("ModelYear", "CalculateTaxCombinedRequest.DataArea.ModelYear");
            dic.Add("TaxationDate", "CalculateTaxCombinedRequest.DataArea.TaxationDate");
            dic.Add("CountrySubdivisionCode", "CalculateTaxCombinedRequest.DataArea.CountrySubdivisionCode");
            dic.Add("CurrencyCode", "CalculateTaxCombinedRequest.DataArea.CurrencyCode");
            dic.Add("SpecificationMarket", "CalculateTaxCombinedRequest.DataArea.SpecificationMarket");
            dic.Add("GccTaxPartnerGroupCode", "CalculateTaxCombinedRequest.DataArea.GccTaxPartnerGroupCode");
            dic.Add("Partner", "CalculateTaxCombinedRequest.DataArea.Partner");
            

            return dic;
        }
        public static Dictionary<string, string> GetpnoDataDatakey()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("Pno34Options", "Pno34Options");
            dic.Add("PriceBase", "PriceBase");
            dic.Add("StructureWeek", "StructureWeek");
            dic.Add("Price", "Price");
           

            return dic;
        }
    }
}
