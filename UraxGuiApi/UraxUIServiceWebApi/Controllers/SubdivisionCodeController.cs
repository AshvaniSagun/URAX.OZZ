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

    public class SubdivisionCodeController : ApiController
    {
        readonly SubdivisionCode subdivisionCodeObj = new SubdivisionCode();
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, subdivisionCodeObj.GetSubdivisionCodeList());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, Error.ParameterEmpty(ex.Message.ToString()));
            }
        }
        public HttpResponseMessage GetByCountryCodeId(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, subdivisionCodeObj.GetSubdivisionCodeListByCountryCodeId(id));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, Error.ParameterEmpty(ex.Message.ToString()));
            }
        }
    }
}
