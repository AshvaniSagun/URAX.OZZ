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
    public class TaxVersionController : ApiController
    {
   // [Authorize] // security integration  
        
        readonly TaxMaster taxMasterObj = new TaxMaster();
        [HttpPost]
        [Route("api/TaxVersion/AddVersionDetails")]
        public HttpResponseMessage AddVersionDetails(IEnumerable<TaxVersionDetail> taxVersionDetailsValue)
        {


            try
            {

                if (ModelState.IsValid && (taxVersionDetailsValue != null))
                {
                   string response= taxMasterObj.AddTaxVersionDetails(taxVersionDetailsValue);
                    List<string> lstresponse = new List<string>() { Helper.sInsertVersionSuccess };
                    if (!(string.IsNullOrEmpty(response)))
                    {
                        lstresponse.Add(response);
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails(string.Join(" ", lstresponse.ToArray()), true));
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest,
                        Error.GetErrorDetails(string.Join(", ", ModelState.Values
                                                .SelectMany(x => x.Errors)
                                                .Select(x => x.ErrorMessage))));
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails(ex.Message.ToString()));
            }
        }

        [HttpPost]
        [Route("api/TaxVersion/CheckVersionDetails")]
        public HttpResponseMessage CheckVersionDetails(IEnumerable<TaxVersionDetail> taxVersionDetailsValue)
        {


            try
            {

                if (ModelState.IsValid && (taxVersionDetailsValue != null))
                {
                    string response = taxMasterObj.CheckVersionDetails(taxVersionDetailsValue);
                  
                    return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails(response, true));
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest,
                        Error.GetErrorDetails(string.Join(", ", ModelState.Values
                                                .SelectMany(x => x.Errors)
                                                .Select(x => x.ErrorMessage))));
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails(ex.Message.ToString()));
            }
        }
        [HttpPut]
        [Route("api/TaxVersion/UpdateVersionDetails")]
        public HttpResponseMessage UpdateVersionDetails(IEnumerable<TaxVersionDetail> taxVersionDetailsValue)
        {


            try
            {

                if (ModelState.IsValid && (taxVersionDetailsValue != null))
                {
                    string response = taxMasterObj.UpdateTaxVersionDetails(taxVersionDetailsValue);
                    List<string> lstresponse = new List<string>() { Helper.sUpdateSuccess };
                    if (!(string.IsNullOrEmpty(response)))
                    {
                        lstresponse.Add(response);
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails(string.Join(" ", lstresponse.ToArray()), true));
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest,
                        Error.ParameterEmpty(string.Join(", ", ModelState.Values
                                                .SelectMany(x => x.Errors)
                                                .Select(x => x.ErrorMessage))));
                }
            }
            catch (Exception ex)
            {
                string message = String.Empty;
                if (ex.Message.Contains(Resource.GetResxValueByName("MarketIdPriorityCombDuplicatemsg")))
                {
                    message = Resource.GetResxValueByName("MarketIdPriorityCombDuplicatemsg");
                }
                else if (ex.Message.Contains(Resource.GetResxValueByName("VersionConflictmsg")))
                {
                    message = Resource.GetResxValueByName("VersionConflictmsg");
                }
                else
                {
                    message = ex.Message.ToString();
                }
                return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails(message));

            }

        }
    }
}
