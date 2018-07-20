using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EF = UraxUIServiceWebApi.EF;
using UraxUIServiceWebApi.Models;

namespace UraxUIServiceWebApi.Controllers
{
    // [Authorize] // security integration  

    public class ParameterController : ApiController
    {
       readonly  ParameterDetails parameterDetaisObj = new ParameterDetails();
        [HttpGet]
        public HttpResponseMessage Get(int Id)
        {
            try
            {
                List<Parameterlist> lstparameterlist = parameterDetaisObj.GetParameterByGroupId(Id);
                    return Request.CreateResponse(HttpStatusCode.OK, lstparameterlist);
               

            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }
        [HttpGet]
        public HttpResponseMessage GetInputParameter(int TaxId , int TypeId)
        {
            try
            {
                List<VariableDropList> lstparameterlist = parameterDetaisObj.GetInputParameter(TaxId, TypeId);
                return Request.CreateResponse(HttpStatusCode.OK, lstparameterlist);


            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }
    }
}
