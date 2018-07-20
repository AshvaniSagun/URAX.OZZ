using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Http.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using Pno34ReqRespWebApi.Models;
using UraxBPCPNO34.Controllers;
using UraxBpcPno34Api.Models;

namespace UraxBPCPNO34Api.Tests
{
    [TestClass]
    public class Pno34InputRequestValidationTest
    {

        [TestMethod]
        public  void CalculateTaxCombined_Should_Return_Error_ifModelState_isNotValid()
        {
            //Arrange
            Environment.SetEnvironmentVariable("DefaultCulture", "en-US");
            var inputPnoData = MockPrimoInput.CreateMockPrimoInputWithInvalidLocale();
            // Act
            var controller = new CalculateTaxCombinedController();
            controller.ModelState.AddModelError("CalculateTaxCombinedRequest.Locale", "locale is required");
            var response = controller.CalculateTaxCombined(inputPnoData) as OkNegotiatedContentResult<CalculateTaxCombinedResponseOutput>;
            var output= (CalculateTaxCombinedResponseOutput)response.Content;
            // Assert
            Assert.AreEqual("CalculateTaxCombinedRequest.Locale", output.CalculateTaxCombinedResponse.ErrorMessage.CallStack);
        }
        
    }
}
