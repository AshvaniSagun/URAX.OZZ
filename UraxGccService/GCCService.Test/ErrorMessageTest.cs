using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UraxGCCService_API.Controllers;
using UraxGCCService_API.Models;

namespace GCCService.Test
{
    [TestClass]
    public class ErrorMessageTest
    {
        [TestMethod]
        public async Task TestcalculateTaxProvideCO2Request_NullAsync()
        {
            // Arrange
            var controller = new CalculateTaxController();
            CalculateTaxProvideCO2 pnoData = new CalculateTaxProvideCO2();
            var lstErrorMessage = new List<CustomErrorMessage>();
            lstErrorMessage.Add(    new CustomErrorMessage()
            {
                MessageType = Helper.strError,
                MessageText = Helper.sInvalidcontent,
                MessageTitle = Helper.sUraxApplicationServer,
                MessageId = "0",
                CallStack = "",
                IsRootMessage = true
            });
            // Act
            var response = await controller.CalculateTaxProvideCO2(null) as OkNegotiatedContentResult<List<CustomErrorMessage>>;
            //List<CustomErrorMessage> lstErrorMessageResponse
            var contentResult = response.Content.ToList<CustomErrorMessage>() ;

            // Assert
            foreach (var data in contentResult)
            {
                Assert.AreEqual(data.MessageText, lstErrorMessage.First().MessageText);
                Assert.AreEqual(data.MessageType, lstErrorMessage.First().MessageType);
                Assert.AreEqual(data.MessageTitle, lstErrorMessage.First().MessageTitle);
            }
        }
    }
}
