using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UraxUIServiceWebApi.Models;

namespace UraxUIServiceWebApi.Controllers
{
    // [Authorize] // security integration  

    public class Pno12Controller : ApiController
    {
        readonly Pno12Data Pno12Obj = new Pno12Data();
      
        [HttpGet]
        [Route("api/Pno12/GetPno12AllData")]
        public HttpResponseMessage GetPno12AllData()
        {
            try
            {
                var result = Pno12Obj.GetAllData();
                return Request.CreateResponse(HttpStatusCode.OK, result);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails(ex.Message.ToString()));
            }
        }
        [HttpGet]
        [Route("api/Pno12/GetPno12HeaderDetails")]
        public HttpResponseMessage GetPno12HeaderDetails()
        {
            try
            {
                var result = Pno12Obj.GetHeader();
                return Request.CreateResponse(HttpStatusCode.OK, result);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails(ex.Message.ToString()));
            }
        }
    }
}
