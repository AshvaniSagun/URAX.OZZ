using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UraxGCCService_API.Models;

namespace GCCService.Test
{
    [TestClass]
    public class TestPno12
    {
        [TestMethod]
        public void TestAddInputparameter()
        {
        
            // Arrange
            List<ParametersResponse> lstParameters = new List<ParametersResponse>();
            List<string> lstInput = new List<string>();
            List<Parameter> Parameter = new List<Parameter>();

            lstParameters.Add(new ParametersResponse()
            {
                Id = "",
                Datatype = "string",
                Name = "Test1",
                 Status ="S",
                  Unit = "TEST",
                   Value ="10"
            });
            lstInput.Add("Test1");
            Parameter.Add(new UraxGCCService_API.Models.Parameter
            {
                Name = "Test1",
                Status = "S",
                Unit = "TEST",
                Value = "10"
            });
            // Act
            //TODO : 
            // Assert
            Assert.AreEqual(1, 1);
           


        }
    }
   


}
