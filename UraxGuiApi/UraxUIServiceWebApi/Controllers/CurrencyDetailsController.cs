using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UraxUIServiceWebApi.Models;

namespace UraxUIServiceWebApi.Controllers
{
    //TODO : need to add Authroze once GUI is ready to take authorize value
    // [Authorize]
    public class CurrencyDetailsController : ApiController
    {
       readonly CurrencyDetails currencyDetailsObj = new CurrencyDetails();
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, GetCurrencyDetailsList());
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

                return Request.CreateResponse(HttpStatusCode.InternalServerError, Error.ParameterEmpty(ex.Message.ToString()));
            }
        }
        private List<CurrencyDetailsList> GetCurrencyDetailsList()
        {
            List<CurrencyDetailsList> lstCurrencydetails = new List<CurrencyDetailsList>();
            
                var result = currencyDetailsObj.GetCurrencyDetails();
                foreach (var param in result)
                {
                    lstCurrencydetails.Add(new CurrencyDetailsList()
                    {
                        CurrencyCode=param.CurrencyCode + " - "+ param.CurrencyName,
                        CurrencyId=param.CurrencyId,
                    });
                }
            return lstCurrencydetails;
            
           

        }



        [HttpGet]
        public HttpResponseMessage Get(int Id)
        {
            try
            {
                List<CurrencyDetails> lstcurrencyDetails = new List<CurrencyDetails>();
                var result = currencyDetailsObj.GetCurrencyDetails(Id);
                if (result.Count != 0)
                {
                    foreach (var item in result)
                    {
                        lstcurrencyDetails.Add(new CurrencyDetails()
                        {
                            CurrencyId=item.CurrencyId,
                            CurrencyCode=item.CurrencyCode,
                            Descriptions = item.Descriptions,
                            IsActive = item.IsActive,
                            CreatedBy = item.CreatedBy,
                            CreatedOn = item.CreatedOn,
                            UpdatedBy = item.UpdatedBy,
                            UpdatedOn = item.UpdatedOn??DateTime.UtcNow
                        });
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, lstcurrencyDetails);
                }
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "");

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }
    }
}
