using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UraxBPCPNO34.Models;
using UraxGCCService_API.Models;

namespace UnitTestProject1
{
    [TestClass]
    public class HelperTest
    {
        [TestMethod]
        public void TestGetpno34DataDatakey()
        {
            // Arrange
            Dictionary<string, string> dicPno34DataDatakey = new Dictionary<string, string>();
            dicPno34DataDatakey.Add("Locale", "CalculateTaxProvideCO2Request.Locale");
            dicPno34DataDatakey.Add("Application", "CalculateTaxProvideCO2Request.ApplicationArea.Sender.Application");
            dicPno34DataDatakey.Add("RequestDatetimeCreated", "CalculateTaxProvideCO2Request.ApplicationArea.Sender.RequestDatetimeCreated");
            dicPno34DataDatakey.Add("SequenceId", "CalculateTaxProvideCO2Request.ApplicationArea.Sender.SequenceId");
            dicPno34DataDatakey.Add("CountryCode", "CalculateTaxCombinedRequest.DataArea.CountryCode");
            dicPno34DataDatakey.Add("TaxTerritory", "CalculateTaxProvideCO2Request.DataArea.TaxTerritory");
            dicPno34DataDatakey.Add("ModelYear", "CalculateTaxProvideCO2Request.DataArea.ModelYear");
            dicPno34DataDatakey.Add("TaxationDate", "CalculateTaxProvideCO2Request.DataArea.TaxationDate");
            dicPno34DataDatakey.Add("CountrySubdivisionCode", "CalculateTaxProvideCO2Request.DataArea.CountrySubdivisionCode");
            dicPno34DataDatakey.Add("SpecificationMarket", "CalculateTaxProvideCO2Request.DataArea.SpecificationMarket");
            // Act
            Dictionary<string, string> result = Helper.Getpno34DataDatakey();
            // Assert
            CollectionAssert.AreEqual(result, dicPno34DataDatakey);
        }

        [TestMethod]
        public void TestGetpnoDataDatakey()
        {
            // Arrange
            Dictionary<string, string> dicPno34DataDatakey = new Dictionary<string, string>();
            dicPno34DataDatakey.Add("Pno12", "Pno12");
            dicPno34DataDatakey.Add("PriceBase", "PriceBase");
            dicPno34DataDatakey.Add("StructureWeek", "StructureWeek");
            dicPno34DataDatakey.Add("Price", "Price");
            // Act
            Dictionary<string, string> result = Helper.GetpnoDataDatakey();
            // Assert
            CollectionAssert.AreEqual(result, dicPno34DataDatakey);
        }
        [TestMethod]
        public void TestGetParameterkeyValue()
        {
            // Arrange
            Dictionary<string, string> dicParameter = new Dictionary<string, string>();
            dicParameter.Add("FUELTYPE", "FUEL TYPE");
            dicParameter.Add("CC", "CYLINDER CAPACITY");
            dicParameter.Add("KW", "KW");
            dicParameter.Add("HP", "HP");
            dicParameter.Add("NOX", "NOX");
            dicParameter.Add("CYL", "NO OF CYLINDERS");
            dicParameter.Add("CARLENGTH", "CAR LENGTH");
            dicParameter.Add("EMISSIONCLASS", "EMISSION CLASS");
            dicParameter.Add("PROPULSION", "PROPULSION");
            dicParameter.Add("PARTICULATEMATTERWEIGHT", "PM WEIGHT");
            dicParameter.Add("PARTICULATEMATTERQUANTITY", "PM QUANTITY");
            dicParameter.Add("PRICELISTTYPE", "PRICELIST TYPE");
            dicParameter.Add("FUELCONSUMPTION", "FUEL CONSUMPTION");
            dicParameter.Add("NEDC_FC_COMBINED", "NEDC FUEL CONSUMPTION COMBINED");
            dicParameter.Add("NEDC_CO2_COMBINED", "NEDC CO2 COMBINED");
            dicParameter.Add("WLTP_CO2_TOTAL", "WLTP CO2 TOTAL");
            dicParameter.Add("WLTP_FC_TOTAL", "WLTP FUEL CONSUMPTION TOTAL");
            dicParameter.Add("WLTP_FC_HEV_CS_TOTAL", "WLTP FUEL CONSUMPTION HEV CS TOTAL");
            dicParameter.Add("WLTP_PHEV_EC_TOTAL", "WLTP PHEV ELECTRIC CONSUMPTION TOTAL");
            dicParameter.Add("WLTP_BEV_EC_TOTAL", "WLTP BEV ELECTRIC CONSUMPTION TOTAL");
            dicParameter.Add("TP_MAX_LADEN_MASS", "TP MAX LADEN MASS");
            dicParameter.Add("HOMOLOGATION_CURB_WEIGHT_TOTAL", "HOMOLOGATION CURB WEIGHT TOTAL");
            dicParameter.Add("NEDC_PHEV_CO2_WEIGHTED_COMBINED", "NEDC PHEV CO2 WEIGHTED COMBINED");
            dicParameter.Add("NEDC_HEV_CO2_COMBINED", "NEDC HEV CO2  COMBINED");
            dicParameter.Add("NEDC_PHEV_FC_COMBINED", "NEDC PHEV FUEL CONSUMPTION");
            dicParameter.Add("NEDC_PHEV_FC_WEIGHTED_COMBINED", "NEDC PHEV FUEL CONSUMPTION WEIGHTED COMBINED");
            dicParameter.Add("NEDC_PHEV_ER_COMBINED", "NEDC PHEV ELECTRIC RANGE COMBINED");
            dicParameter.Add("NEDC_BEV_PER_COMBINED", "NEDC BEV PURE ELECTRIC RANGE COMBINED");
            dicParameter.Add("NEDC_PHEV_EC_COMBINED", "NEDC PHEV ELECTRIC CONSUMPTION COMBINED");
            dicParameter.Add("NEDC_PHEV_EC_WEIGHTED_COMBINED", "NEDC PHEV ELECTRIC CONSUMPTION WEIGHTED COMBINED");
            dicParameter.Add("WLTP_PHEV_CO2_WEIGHTED_TOTAL", "WLTP PHEV CO2 WEIGHTED TOTAL");
            dicParameter.Add("WLTP_HEV_CO2_CS_TOTAL", "WLTP HEV CO2 CS TOTAL");
            dicParameter.Add("WLTP_FC_PHEV_WEIGHTED_TOTAL", "WLTP FUEL CONSUMPTION PHEV WEIGHTED TOTAL");
            dicParameter.Add("WLTP_ER_PHEV_AER_TOTAL", "WLTP ELECTRIC RANGE PHEV AER TOTAL");
            dicParameter.Add("WLTP_ER_PHEV_EAER_TOTAL", "WLTP ELECTRIC RANGE PHEV EAER TOTAL");
            dicParameter.Add("WLTP_ER_BEV_PER_TOTAL", "WLTP ELECTRIC RANGE BEV PER TOTAL");
            dicParameter.Add("WLTP_PHEV_EC_AC_CD_TOTAL", "WLTP PHEV ELECTRIC CONSUMPTION AC CD TOTAL");
            dicParameter.Add("WLTP_PHEV_EC_AC_WEIGHTED_TOTAL", "WLTP PHEV ELECTRIC CONSUMPTION WEIGHTED TOTAL");
            dicParameter.Add("MASS_IN_RUNNING_ORDER_TOTAL", "MASS IN RUNNING ORDER TOTAL");
            dicParameter.Add("NEDC_HEV_FC_COMBINED", "NEDC FUEL CONSUMPTION");
            dicParameter.Add("NEDC_BEV_EC_COMBINED", "NEDC BEV ELECTRIC CONSUMPTION COMBINED");
            dicParameter.Add("PMQUANTITY", "PM QUANTITY");
            dicParameter.Add("NEDC_PHEV_ELECTRIC_RANGE_COMBINED", "NEDC PHEV ELECTRIC RANGE COMBINED");
            dicParameter.Add("EURONCAPRATING", "EURO NCAP RATING");
            dicParameter.Add("MODEL", "MODEL NUMBER");
            dicParameter.Add("WVTA", "WVTA APPROVED");
            // Act
            Dictionary<string, string> result = Helper.GetParameterkeyValue();
            // Assert
            CollectionAssert.AreEqual(result, dicParameter);
        }

    }
}
