using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UraxBPCPNO34.Models;
namespace GCCService.Test
{
    [TestClass]
    public class FormulaEvaluationTests
    {
      

        [TestMethod]
        public  void TestFormula()
        {
            var additiveFormulaString = "10+10";

            var result = new Parser().ParseFormula(additiveFormulaString);

            Assert.AreEqual(20, result);
        }

        [TestMethod]
        public void Test_ShouldSumValues_IfFormulaIsSubtraction()
        {
            var subtractionFormula = "10-5-2";

            var result = new Parser().ParseFormula(subtractionFormula);

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Test_ShouldDivideValues_IfFormulaIsDivision()
        {
            var divisionFormula = "9/3";

            var result = new Parser().ParseFormula(divisionFormula);

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Test_ShouldMultiplyValues_IfFormulaIsMultiplication()
        {
            var mulitplicativeFormula = "9*3";

            var result = new Parser().ParseFormula(mulitplicativeFormula);

            Assert.AreEqual(27, result);
        }

        [TestMethod]
        public void Test_ShouldGiveTheBiggestNumber_GivenAMaxFormula()
        {
            var maxFormulaOne = "MAX(1, 2, 3, 4, 5)";
            var maxFormulaTwo = "MAX(10, 2)";
            var maxFormulaThree = "MAX(12, 23, 3)";
            var maxFormulaFour = "MAX(1, 22, 3, 42)";

            Assert.AreEqual(5, new Parser().ParseFormula(maxFormulaOne));
            Assert.AreEqual(10, new Parser().ParseFormula(maxFormulaTwo));
            Assert.AreEqual(23, new Parser().ParseFormula(maxFormulaThree));
            Assert.AreEqual(42, new Parser().ParseFormula(maxFormulaFour));
        }

        [TestMethod]
        public void Test_ShouldGiveTheSmallestNumber_GivenAMinFormula()
        {
            var minFormulaOne = "MIN(1, 2, 3, 4, 5)";
            var minFormulaTwo = "MIN(10, 2)";
            var minFormulaThree = "MIN(12, 23, 3)";
            var minFormulaFour = "MIN(1, 22, 3, 42)";

            Assert.AreEqual(1, new Parser().ParseFormula(minFormulaOne));
            Assert.AreEqual(2, new Parser().ParseFormula(minFormulaTwo));
            Assert.AreEqual(3, new Parser().ParseFormula(minFormulaThree));
            Assert.AreEqual(1, new Parser().ParseFormula(minFormulaFour));
        }

        [TestMethod]
        public void Test_ShouldRoundUpValue_GivenAnyDecimalValue()
        {
            var formula = "ROUNDUP(2.3, 0)";

            Assert.AreEqual(3, new Parser().ParseFormula(formula));
        }

        [TestMethod]
        public void Test_ShouldRoundDownValue_GivenAnyDecimalValue()
        {
            var formula = "ROUNDDOWN(2.7, 0)";

            Assert.AreEqual(2, new Parser().ParseFormula(formula));
        }

        [TestMethod]
        public void Test_ShouldRoundResult_IfValueIsDecimal()
        {
            var firstValue = "ROUND(2.51, 0)";
            var secondValue = "ROUND(2.149, 1)";

            var firstResult = new Parser().ParseFormula(firstValue);
            var secondResult = new Parser().ParseFormula(secondValue);

            Assert.AreEqual(3, firstResult);
            Assert.AreEqual(2.1M, secondResult);
        }

        [TestMethod]
        public void Test_ShouldReturn2_IfNumberIsAbove100()
        {
            var formula = "IF(101>100, 2, 0)";

            var result = new Parser().ParseFormula(formula);

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Test_ShouldReturn1_IfStringsAreTheEqual()
        {
            var formula = "IF(\"String1\"=\"String1\", 1, 2)";

            var result = new Parser().ParseFormula(formula);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Test_ShouldReturn2_IfStringsAreNotEqual()
        {
            var formula = "IF(\"String1\"=\"String2\", 1, 2)";

            var result = new Parser().ParseFormula(formula);

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Test_ShouldUseEXPOfOperator_IfFormulaIsExp()
        {
            var formula = "EXP(2)";
            var result = new Parser().ParseFormula(formula);
            
            Assert.AreEqual(7.38905609893065M, result);
        }
        [TestMethod]
        public void Test_ShouldUsePowerOfOperator_IfFormulaIsExp()
        {
            var formula = "POWER(2,2)";
            var result = new Parser().ParseFormula(formula);

            Assert.AreEqual(4M, result);
        }


        [TestMethod]
        public void Test_ShouldBeAbleToCompareValues_IfFormulaContainsComparer()
        {
            var formulaBiggerThan = "IF(2 > 1, 10, 20)";
            var formulaSmallerThan = "IF(1 < 2, 10, 20)";
            var formulaBiggerThanOrEquals = "IF(2 >= 2, 20, 10)";
            var formulaSmallerThanOrEquals = "IF(1 <= 2, 20, 10)";
            var formulaEquals = "IF(1 = 1, 20, 10)";

            var resultBiggerThan = new Parser().ParseFormula(formulaBiggerThan);
            var resultSmallerThan = new Parser().ParseFormula(formulaSmallerThan);
            var resultBiggerThanOrEquals = new Parser().ParseFormula(formulaBiggerThanOrEquals);
            var resultSmallerThanOrEquals = new Parser().ParseFormula(formulaSmallerThanOrEquals);
            var resultEquals = new Parser().ParseFormula(formulaEquals);

            Assert.AreEqual(10, resultBiggerThan);
            Assert.AreEqual(10, resultSmallerThan);
            Assert.AreEqual(20, resultBiggerThanOrEquals);
            Assert.AreEqual(20, resultSmallerThanOrEquals);
            Assert.AreEqual(20, resultEquals);
        }

        [TestMethod]
        public void Test_ShouldPrioritizeParenthesisedEvaluations_GivenThatAdditionIsParenthesised()
        {
            var formula = "(10 + 10) * 2";

            var result = new Parser().ParseFormula(formula);

            Assert.AreEqual(40, result);
        }

        [TestMethod]
        public void Test_ShouldThrowException_IfFormulaHasBadFormat()
        {
            bool sts = false;
            try
            {
                var badlyFormatedFormula = "10+10+";
                new Parser().ParseFormula(badlyFormatedFormula);
            }
           catch(Exception )
            {
                sts = true;
            }

            Assert.AreEqual(true, sts);
        }
       
    }
}
