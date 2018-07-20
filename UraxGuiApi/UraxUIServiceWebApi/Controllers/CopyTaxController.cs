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
    public class CopyTaxController : ApiController
    {
     readonly   CopyTax copyTaxObj = new CopyTax();

       

        /// <summary>
        /// To Copy Tax Details With Specific Tax Version Details
        /// </summary>
        /// <param name="copyTaxValue">List of Tax Details to copy as input </param>
        /// <returns>returns success Message</returns>
        [HttpPost]
        [Route("api/CopyTax/AddCopyTaxWithTaxVersion")]

        public HttpResponseMessage AddCopyTaxWithTaxVersion(List<CopyTaxVersion> copyTaxValue)
        {
            try
            {
                if ((copyTaxValue != null))
                {
                  string response=  copyTaxObj.AddCopyTaxWithTaxVersion(copyTaxValue);
                    return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails("Copied tax '"+response+"' successfully", true));
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
                string message = String.Empty;
                string error = Resource.GetResxValueByName("CopyTaxDuplicatemsg");
                if (ex.Message.Contains(error))
                {
                    message = error;
                }
                else
                {
                    message = ex.Message.ToString();
                }
                return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails(message));

            }

        }

        //[HttpPost]

        //public HttpResponseMessage Check(string value)
        //{
        //    try
        //    {
        //        if ((value != null))
        //        {
        //            var response = copyTaxObj.check(value);
        //            return Request.CreateResponse(HttpStatusCode.OK, response);
        //        }
        //        else
        //        {
        //            return Request.CreateResponse(HttpStatusCode.BadRequest,
        //                Error.GetErrorDetails(string.Join(", ", ModelState.Values
        //                                        .SelectMany(x => x.Errors)
        //                                        .Select(x => x.ErrorMessage))));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
              
        //     return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails(ex.ToString()));

        //    }

        //}


    }


}