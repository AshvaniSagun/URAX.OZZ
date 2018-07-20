using System;
using System.Collections.Generic;
using GCCServiceWebApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UraxBPCPNO34.Models;
using UraxGCCService_API.Models;

namespace UnitTestProject1
{
    [TestClass]
    public class TaxEngineServiceTest
    {
        [TestMethod]
        public void TestParseFormulaParameter()
        {
            // Arrange
            var formula = "PRETAX * VATRATE";
            var formula1 = "10 +  VATRATE * PRETAX ";
            List<string> lstForumulaParameter = new List<string> { "VATRATE", "PRETAX" };
            List<string> lstForumulaParameter1 = new List<string> { "VATRATE", "PRETAX", "10" };
            // Act
            List<string> result = TaxEngineService.ParseFormulaParameter(formula);
            List<string> result1 = TaxEngineService.ParseFormulaParameter(formula1);
            // Assert
            CollectionAssert.AreEqual(result, lstForumulaParameter);
            CollectionAssert.AreEqual(result1, lstForumulaParameter1);
        }

        [TestMethod]
        public void TestIsDecimal()
        {
            // Arrange
            string val = "10.12";
            string val1 = "ABC";
            // Act
            var result = TaxEngineService.IsDecimal(val);
            var result1 = TaxEngineService.IsDecimal(val1);
            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result1);
            Assert.AreEqual(result, true);
            Assert.AreEqual(result1, false);
        }
        [TestMethod]
        public void TestParseFormula()
        {
            // Arrange
            Dictionary<string, string> dicInputVal = new Dictionary<string, string>();
            List<Formula> dicFormula = new List<Formula>();
            List<PnoVariable> varlsitVariable = new List<PnoVariable>();
            string taxCalcBasedOn = string.Empty;
            // Act
            var result = TaxEngineService.ParseFormula(dicInputVal, dicFormula, varlsitVariable,out taxCalcBasedOn);
            // Assert
            Assert.AreEqual(result.Count ,0);
        }


        [TestMethod]
        public void TestGetCalculatedBasedOnIfNull()
        {
            // Arrange
            List<Formula> dicFormula = new List<Formula>();
            dicFormula.Add(new Formula() { FormulaDefination = @"IF(PROPULSION = ""ICE"", 0, 10)", VariableName = "FUEL_DISCOUNT", MaxValue = null, MinValue = null, UnitTypeId = 14, VariableTypeId = 9 });
            dicFormula.Add(new Formula() { FormulaDefination = "CO2_BASED_TAX - FUEL_DISCOUNT", VariableName = "VED", MaxValue = null, MinValue = null, UnitTypeId = 14, VariableTypeId = 9 });
            dicFormula.Add(new Formula() { FormulaDefination = "IF(VED>=0,VED,0)", VariableName = "VED_OUT", MaxValue = null, MinValue = null, UnitTypeId = 14, VariableTypeId = 8 });

            List<PnoVariable> inputVariableList = new List<PnoVariable>();
            inputVariableList.Add(new PnoVariable() { TaxCalcBasedOn="NEDC", VariableGuiName= "NEDC CO2 COMBINED", VariableName= "FUELTYPE" });
            string taxCalcBasedOn = "NULL";
            List<LookupDetail> lookupVariable = new List<LookupDetail>();
            lookupVariable.Add(new LookupDetail() { LookUpGroupName = "TESTCO2", VariableName = "NEDC CO2 COMBINED", VariableTypeId = 6 });
            lookupVariable.Add(new LookupDetail() { LookUpGroupName = "TESTCO2", VariableName = "Test", VariableTypeId = 10 });
            lookupVariable.Add(new LookupDetail() { LookUpGroupName = "CO2 BASED TAX TABLE", VariableName = "NEDC CO2 COMBINED", VariableTypeId = 6 });
            lookupVariable.Add(new LookupDetail() { LookUpGroupName = "CO2 BASED TAX TABLE", VariableName = "CO2_BASED_TAX", VariableTypeId = 10 });

            // Act
            var result = TaxEngineService.GetCalculatedBasedOnIfNull(lookupVariable,  inputVariableList,  dicFormula, taxCalcBasedOn);
            // Assert
            Assert.AreEqual(result.ToString(), "NEDC");
        }


    }


}
