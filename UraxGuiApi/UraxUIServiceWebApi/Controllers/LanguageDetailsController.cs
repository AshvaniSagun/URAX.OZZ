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

    public class LanguageDetailsController : ApiController
    {
        readonly LanguageDetail languageDetailsObj = new LanguageDetail();



        [HttpGet]
        [Route("api/languagedetail/GetLanguageDetail")]
        public HttpResponseMessage GetMarketDetails()
        {
            try
            {

                return Request.CreateResponse(HttpStatusCode.OK, languageDetailsObj.GetLanguageDetailWithLanguageName());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, Error.ParameterEmpty(ex.Message.ToString()));
            }
        }


        [HttpGet]
        [Route("api/languagedetail/Get")]
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, GetLanguageDetailsList());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, Error.ParameterEmpty(ex.Message.ToString()));
            }
        }


        [HttpPut]
        public HttpResponseMessage UpdateLanguageDetails([FromBody] IEnumerable<LanguageDetail> languageDetailValue)
        {
            try
            {
                if (ModelState.IsValid && languageDetailValue != null)
                {
                    languageDetailsObj.UpdateLanguageDetails(languageDetailValue);
                    //Clear the cache
                    CleanCache.ClearLocalTaxNameCache();
                    return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails(Helper.sUpdateSuccess, true));
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
        public HttpResponseMessage AddLanguageDetails(IEnumerable<LanguageDetail> languageDetailValue)
        {
            try
            {

                if (ModelState.IsValid && (languageDetailValue != null))
                {
                    languageDetailsObj.AddLanguageDetails(languageDetailValue);
                    //Clear the cache
                    CleanCache.ClearLocalTaxNameCache();

                    return Request.CreateResponse(HttpStatusCode.Created, Error.GetErrorDetails(Helper.sInsertSuccess, true));
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

        [HttpDelete]
        public HttpResponseMessage Delete(int languageDetailsId)
        {
            try
            {
                languageDetailsObj.DeleteLanguageDetails(languageDetailsId);
                //Clear the cache
                CleanCache.ClearLocalTaxNameCache();
                return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails(Helper.sDeleteSuccess, true));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails(ex.Message.ToString()));
            }
        }


        [HttpGet]
        public HttpResponseMessage Get(int Id)
        {
            try
            {
                List<LanguageDetail> lstLanguageDetail = new List<LanguageDetail>();
                var result = languageDetailsObj.GetLanguageDetails(Id);
                if (result.Count != 0)
                {
                    foreach (var param in result)
                    {
                        lstLanguageDetail.Add(new LanguageDetail()
                        {
                            LanguageDetailId = param.LanguageDetailsId,
                            TaxMasterId = param.TaxMasterId,
                            LanguageId = param.LanguageId,
                            TaxName = param.TaxName,
                            IsActive = param.IsActive,
                            CreatedBy = param.CreatedBy,
                            CreatedOn = param.CreatedOn,
                            UpdatedBy = param.UpdatedBy,
                            UpdatedOn = param.UpdatedOn
                        });
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, lstLanguageDetail);
                }
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, Helper.sIdNotFound + Id);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }

        [HttpGet]
        public HttpResponseMessage GetDetails(int TaxId)
        {
            try
            {
                var result = GetLanguageDetailByTaxId(TaxId);
                if (result.Count != 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, Helper.sIdNotFound + TaxId);
            }

            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }

        private List<LanguageDetailList> GetLanguageDetailsList()
        {
            List<LanguageDetailList> lstLanguageDetail = new List<LanguageDetailList>();
            try
            {
                var result = languageDetailsObj.GetLanguageDetails();

                foreach (var param in result)
                {
                    lstLanguageDetail.Add(new LanguageDetailList()
                    {
                        LanguageDetailsId = (int)param.LanguageDetailsId,

                        TaxName = param.TaxName
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lstLanguageDetail;
        }



        private List<LanguageDetail> GetLanguageDetailByTaxId(int TaxId)
        {
            List<LanguageDetail> lstLanguageDetail = languageDetailsObj.GetLanguageDetailsByTaxId(TaxId);

            return lstLanguageDetail;
        }
    }

}