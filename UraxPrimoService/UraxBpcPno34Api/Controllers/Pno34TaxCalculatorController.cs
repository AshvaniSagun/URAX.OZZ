using Pno34ReqRespWebApi.Models;
using System;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using UraxBpcPno34Api.Models;

namespace UraxBPCPNO34.Controllers
{
    public class CalculateTaxCombinedController : ApiController
    {

        /// <summary>
        /// Calculating Tax with respect to Pno34 data provide by Endusers
        /// </summary>
        /// <param name="pno34Data"></param>
        /// <returns>Returning list of Tax with Input data </returns>
        // [Authorize]
        [HttpPost]
        public IHttpActionResult CalculateTaxCombined([FromBody] CalculateTaxCombined pno34Data)
        {
#if DEBUG

            CultureInfo culture = new CultureInfo(Environment.GetEnvironmentVariable("DefaultCulture"));
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
#endif
            try
            {

                if (ModelState.IsValid && (!pno34Data.Equals(null)))
                {

                    Pno34 ObjPno = new Pno34();
                    var lstResponse = ObjPno.Pno34ResponseData(pno34Data);
                    return Ok(lstResponse);
                }

                else
                {
                    var result = new CustomErrorMessage().GetErrorDetails(pno34Data,ModelState);
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                new Microsoft.ApplicationInsights.TelemetryClient().TrackException(ex);
                var result = new CustomErrorMessage().GetCustomErrorDetails(pno34Data, ex.Message);
                    return Ok(result);
            }
        }
    }
}
