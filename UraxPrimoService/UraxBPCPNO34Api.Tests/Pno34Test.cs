using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Pno34ReqRespWebApi.Models;
using UraxBpcPno34Api.Models;
using UraxBPCPNO34Api.Models;
using UraxBPCPNO34Api.Tests.MockData;

namespace UraxBPCPNO34Api.Tests
{
    [TestClass]
    public class Pno34Test
    {
        [TestMethod]
        public void TestPno34ResponseData_MultipleTaxList()
        {
            //Arrange
            ConvertJsonData objCon = new ConvertJsonData();
            Pno34 ObjPno = new Pno34();
             CalculateTaxCombined inputPno34Data = objCon.GetMockJsonData<CalculateTaxCombined>("inputPbo34Data.json");
            List<Dictionary<string, string>> lstDicCertifiedData = objCon.GetMockJsonListData<Dictionary<string, string>>("jsonlstDic.json");
            List<List<ResultVatDetails>> result = objCon.GetMockJsonListData<List<ResultVatDetails>>("lstresult.json");
            List<int> pnonos = null;
            List<CustomErrorMessage> lstErrorMessage = null;
            List<CustomErrorMessage> lstDbError = objCon.GetMockJsonListData<CustomErrorMessage>("lstDbError.json");
            List<MarketWiseInputData> lstMkt = objCon.GetMockJsonListData<MarketWiseInputData>("MarketData.json");
            //Act
            var lstResult = Pno34.CreateResponse(inputPno34Data, lstDicCertifiedData, result, lstMkt, pnonos, lstErrorMessage, lstDbError);
            //Assert
            Assert.AreEqual(lstResult.CalculateTaxCombinedResponse.DataArea.Pno[0].VatPositions[1].TaxList.Count, 2);
            Assert.AreEqual(lstResult.CalculateTaxCombinedResponse.DataArea.Pno[3].VatPositions[1].TaxList.Count, 1);
            Assert.AreEqual(lstResult.CalculateTaxCombinedResponse.DataArea.Pno[2].VatPositions[1].TaxList.Count, 1);

        }
    }
}
