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

    public class CountryCodeController : ApiController
    {
       readonly CountryCode countryCodeObj = new CountryCode();
        /// <summary>
        /// To Get all country Records
        /// </summary>
        /// <returns>Returns list of country Records</returns>
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, GetCountryCodeList());
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

                return Request.CreateResponse(HttpStatusCode.InternalServerError, Error.ParameterEmpty(ex.Message.ToString()));
            }
        }
        private List<CountryCodeList> GetCountryCodeList()
        {
            List<CountryCodeList> lstCountryCode = new List<CountryCodeList>();
            try
            {
                var result = countryCodeObj.GetCountryCode();
                foreach (var param in result)
                {
                    lstCountryCode.Add(new CountryCodeList()
                    {
                      CountryCode1=param.CountryCode1,
                      CountryCodeId=param.CountryCodeId,
                      CountryName=param.CountryName
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }

            return lstCountryCode;
        }


       
        /// <summary>
        /// To Get country Records by Country Code Id
        /// </summary>
        /// <param name="Id">An integer input which represents Country code Id</param>
        /// <returns>Returns success message</returns>
        [HttpGet]
        public HttpResponseMessage Get(int Id)
        {
            try
            {
                List<CountryCode> lstCountryCode = new List<CountryCode>();
                var result = countryCodeObj.GetCountryCode(Id);
                if (result.Count != 0)
                {
                    foreach (var item in result)
                    {
                        lstCountryCode.Add(new CountryCode()
                        {
                            CountryCodeId = item.CountryCodeId,
                            CountryCode1 = item.CountryCode1,
                            CountryName = item.CountryName,
                            CultureInfoDetails = item.CultureInfoDetails,
                            Descriptions = item.Descriptions,
                            IsActive = item.IsActive,
                            CreatedBy = item.CreatedBy,
                            CreatedOn = item.CreatedOn,
                            UpdatedBy = item.UpdatedBy,
                            UpdatedOn = item.UpdatedOn
                        });
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, lstCountryCode);
                }
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound,Helper.sIdNotFound + Id);

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }
    }
}
