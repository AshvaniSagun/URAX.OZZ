using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EF = UraxUIServiceWebApi.EF;
using UraxUIServiceWebApi.Models;
using System.Data;

namespace UraxUIServiceWebApi.Controllers
{
    // [Authorize] // security integration  

    public class LookUpDetailController : ApiController
    {
     readonly   LookUpDetail lookupdetailObj = new LookUpDetail();


        private static List<LookUpDetailList> GetLookUpDetailList()
        {
            List<LookUpDetailList> lstLookUpDetail = new List<LookUpDetailList>();
            try
            {
                var result = LookUpDetail.GetLookUpDetail();
                foreach (var param in result)
                {
                    lstLookUpDetail.Add(new LookUpDetailList()
                    {
                        LookUpId = (int)param.LookUpId,
                        LookUpGroup = (int)param.LookUpGroup,
                        LookUpGroupDetailId = (int)param.GroupDetailsId,
                        Value=param.Value

                    });
                }
            }
            catch (Exception)
            {
                throw;
            }

            return lstLookUpDetail;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, GetLookUpDetailList());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, Error.ParameterEmpty(ex.Message.ToString()));
            }
        }

       


        [HttpDelete]
        public HttpResponseMessage Delete(int lookupdetailId)
        {
            try
            {
                lookupdetailObj.DeleteLookUpDetail(lookupdetailId);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, Error.ParameterEmpty(ex.Message.ToString()));

            }
        }

        [HttpGet]
        public HttpResponseMessage Get(int Id)
        {
            try
            {
                List<LookUpDetail> lstLookUpDetail = new List<LookUpDetail>();
                var result = LookUpDetail.GetLookUpDetail(Id);
                if (result.Count != 0)
                {
                    foreach (var param in result)
                    {
                        lstLookUpDetail.Add(new LookUpDetail()
                        {
                            LookUpId = param.LookUpId,
                            LookUpGroup = param.LookUpGroup,
                            LookUpGroupDetailId = (int)param.GroupDetailsId,
                            Value = param.Value,
                            CreatedBy = param.CreatedBy,
                            CreatedOn = (DateTime)param.CreatedOn,
                            UpdatedBy = param.UpdatedBy,
                            UpdatedOn = (DateTime)param.UpdatedOn
                        });
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, lstLookUpDetail);
                }
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, Helper.sIdNotFound + Id);
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }

        [HttpPut]
        [Route("api/LookupDetail/UpdateGridRowData")]
        public HttpResponseMessage UpdateGridRowData(List<LookUpList> lookupdetailValue)
        {
            try
            {
                if (ModelState.IsValid && lookupdetailValue != null)
                {
                 lookupdetailObj.UpdateGridData(lookupdetailValue);
                    return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails(Helper.sUpdateSuccess,true));
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
        [Route("api/LookupDetail/InsertGridRowData")]
        public HttpResponseMessage InsertGridRowData(List<LookUpList> lookupdetailsdata)
        {
            try
            {
            lookupdetailObj.PostGridValues(lookupdetailsdata);

                return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails(Helper.sInsertSuccess,true));
                
            }
            catch (Exception ex)
            {
                
                return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails(ex.Message.ToString()));
            }
        }

        [HttpDelete]
        [Route("api/LookupDetail/DeleteGridRowData")]
        public HttpResponseMessage DeleteGridRowData([FromUri]  LookupGroupData lookupGroupRow)
        {
            try
            {
                lookupdetailObj.DeleteGridData(lookupGroupRow);
                return Request.CreateResponse(HttpStatusCode.OK, Helper.sDeleteSuccess);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails(ex.Message.ToString()));

            }
        }

    }
}
