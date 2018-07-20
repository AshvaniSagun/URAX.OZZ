using System;
using System.Globalization;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UraxBPCPNO34.Models;
namespace GCCService.Test
{
    [TestClass]
    public class Common
    {
        [TestMethod]
        public void TestToDecimal()
        {
            // Arrange
            string Amount = "37600";
            string Amount1 = "37600.1234";
            string Amount2 = "37600.567";
            // Act
            var result = Amount.ToDecimal(new CultureInfo("en-US", false).NumberFormat).ToString();
            var result1 = Amount1.ToDecimal(new CultureInfo("en-US", false).NumberFormat).ToString();
            var result2 = Amount2.ToDecimal(new CultureInfo("en-US", false).NumberFormat).ToString();
            // Assert
            Assert.AreEqual(result, Amount);
            Assert.AreEqual(result1, Amount1);
            Assert.AreEqual(result2, Amount2);


        }
        
              [TestMethod]
        public void TestToString2DecimalPlace()
        {
            // Arrange
            string Amount = "37600";
            string Amount1 = "37600.1234";
            string Amount2 = "37600.00";
            string Amount4 = "0";
            // Act
            var result = Amount.ToString2DecimalPlace();
            var result1 = Amount1.ToString2DecimalPlace();
            var result2 = Amount2.ToString2DecimalPlace();
            var result4 = Amount4.ToString2DecimalPlace();
            // Assert
            Assert.AreEqual(result, "37600.00");
            Assert.AreEqual(result1, "37600.12");
            Assert.AreEqual(result2, Amount2);
            Assert.AreEqual(result4, "0.00");
        }
        [TestMethod]
        public void TestToCultureDecimal()
        {
            // Arrange
            decimal Amount = 37600M;
            var Amount1 = 37600.1234M;
            decimal Amount2 = 37600.567M;

            // Act
            var result = Amount.ToCultureDecimal(new CultureInfo("en-US", false).NumberFormat, "GCC").ToString();
            var result1 = Amount1.ToCultureDecimal(new CultureInfo("en-US", false).NumberFormat, "GCC").ToString();
            var result2 = Amount2.ToCultureDecimal(new CultureInfo("en-US", false).NumberFormat,"GCC").ToString();

            // Assert
            Assert.AreEqual(result, "37600.00");
            Assert.AreEqual(result1, "37600.12");
            Assert.AreEqual(result2, "37600.57");


        }
    }
}
