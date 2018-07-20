using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pno34ReqRespWebApi.Models;
using System.Collections.Generic;
using UraxBpcPno34Api.Models;
using UraxBPCPNO34Api.Models;

namespace UraxBPCPNO34Api.Tests
{
    [TestClass]
    public class BeforeVatValidation
    {
        [TestMethod]
        public void CreateResponseMethod_Should_Return_Correct_VAT_For_Taxes_With_BEFORE_VAT()
        {
            //Arrange
            var input = MockPrimoInput.CreateMockInput();
            List<int> pnonos = null;
            var lstErrorMessage = new List<CustomErrorMessage>();
            var lstDbError = new List<CustomErrorMessage>();
            List<TaxNameDetails> TaxLocaleName = new List<TaxNameDetails>();
            //Act
            TaxEngineService taxEngineService = new TaxEngineService();
            var lstResult= taxEngineService.TaxCalculationsAsync(input.Item4, lstDbError, TaxLocaleName);
            var output = Pno34.CreateResponse(input.Item1, input.Item2, lstResult.Result, input.Item4, pnonos, lstErrorMessage, lstDbError);
            //Assert
            Assert.AreEqual("10000", input.Item1.CalculateTaxCombinedRequest.DataArea.PnoList[0].Price.Amount);
            Assert.AreEqual("1,011,220.95", output.CalculateTaxCombinedResponse.DataArea.Pno[0].Msrp);
            Assert.AreEqual("12.00", output.CalculateTaxCombinedResponse.DataArea.Pno[0].VatPositions[0].VatPositionTotalAmount);
            Assert.AreEqual("10000", output.CalculateTaxCombinedResponse.DataArea.Pno[0].Pretax);
            Assert.AreEqual("1,001,200.00", output.CalculateTaxCombinedResponse.DataArea.Pno[0].VatPositions[1].VatPositionTotalAmount);
            Assert.AreEqual("8.95", output.CalculateTaxCombinedResponse.DataArea.Pno[0].VatPositions[2].VatPositionTotalAmount);
            Assert.AreEqual("1,001,220.95", output.CalculateTaxCombinedResponse.DataArea.Pno[0].TotalTax);
        }
        [TestMethod]
        public void Root_Level_ErrorMessage_Should_Return_True()
        {
            //Arrange
            var input = MockPrimoInput.CreateMockInput();
            List<int> pnonos = null;
            var lstErrorMessage = new List<CustomErrorMessage>();
            var lstDbError = new List<CustomErrorMessage>();
            //Act
            var output = Pno34.CreateResponse(input.Item1, input.Item2, input.Item3, input.Item4, pnonos, lstErrorMessage, lstDbError);
            //Assert
            Assert.AreEqual(true, output.CalculateTaxCombinedResponse.ErrorMessage.IsRootMessage);
           
        }
        
        [TestMethod]
        public void ConvertFromRedatoDictionary_Should_Not_Fail_If_Reda_Sends_No_Value()
        {
            //Arrange
            var redaInput = new REDAIndividualValuesResponse();

            //Act
            var output = RedaSendRequest.ConvertDataToDictionary(redaInput);

            //Assert
            Assert.AreEqual(null, output.Pno12);

        }

    }
}
