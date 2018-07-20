using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UraxBpcPno34Api.EF;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UraxBPCPNO34Api.Models;
using Moq;
using UraxBpcPno34Api.Models;

namespace UraxBPCPNO34Api.Tests
{
    [TestClass]
    public  class UnitConversionTests
    {
        [TestMethod]
        public void Conversion_Method_Should_Return_Converted_Value_For_FuelConsumption()
        {
            //Arrange
            string countryCode = "US";
            string taxTerritory = "US";
            string DefinitionName = "NEDC_FC_COMBINED";
            var MockData = UnitConversionData.GetMockRedaData();
            
            //Act
            var result = UnitConversionData.GetUnitConvertedData(countryCode, taxTerritory, MockData);
            string testValue = "2.1383144029775181818181818182";
            var dictresult=result.FirstOrDefault().RedaDictionary;
            //Assert
            Assert.AreEqual(testValue, dictresult[DefinitionName]);
        }
        [TestMethod]
        public void Conversion_Method_Should_Return_Same_Value_If_No_Formula_available_For_FuelConsumption()
        {
            //Arrange
            string countryCode = "UAE";
            string taxTerritory = "UAE";
            string DefinitionName = "NEDC_FC_COMBINED";
            var MockData = UnitConversionData.GetMockRedaData();
            //Act
            var result = UnitConversionData.GetUnitConvertedData(countryCode, taxTerritory, MockData);
            string testValue = "110";
            var dictresult = result.FirstOrDefault().RedaDictionary;
            //Assert
            Assert.AreEqual(testValue, dictresult[DefinitionName]);
        }

    }
}
