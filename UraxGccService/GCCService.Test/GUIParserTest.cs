using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FP = TaxEngineApi.Models.FormulaParser;
namespace GCCService.Test
{
    [TestClass]
    public class GUIParserTest
    {
        [TestMethod]
        public void TestParseFormula()
        {
            // Arrange
            FP.GUIParser obj = new FP.GUIParser();
            string input = "(12+3)";
            // Act
          var result =  obj.ParseFormula(input);
            // Assert
            Assert.AreEqual(result, 15M);
        }
       
        [TestMethod]
        public void TestParseListFormula()
        {
            // Arrange
            List<FP.Variable> lsvariable = new List<FP.Variable>();
            lsvariable.Add(new FP.Variable()
            {
                Name = "MASS IN RUNNING ORDER TOTAL",
                Value = "12"
            });
           
            IEnumerable<FP.Formula> formulas = new FP.Formula[] { new FP.Formula { Definition = "MASS IN RUNNING ORDER TOTAL*1", Variable = lsvariable } };

            // Act
            var result =new FP.GUIParser().ParseListFormula(formulas);
            // Assert
            Assert.AreEqual(result, "12");
        }
    }

}
