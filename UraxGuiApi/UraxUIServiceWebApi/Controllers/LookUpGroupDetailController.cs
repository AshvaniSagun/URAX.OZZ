using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using EF = UraxUIServiceWebApi.EF;
using UraxUIServiceWebApi.Models;
using System.Globalization;

namespace UraxUIServiceWebApi.Controllers
{
    // [Authorize] // security integration  

    public class LookUpGroupDetailController : ApiController
    {
        readonly LookUpGroupDetails lookupgroupdetailObj = new LookUpGroupDetails();
       readonly  LookupPivot pivotObj = new LookupPivot();

        private  List<LookUpGroupDetailList> GetLookUpGroupDetailList()
        {
            List<LookUpGroupDetailList> lstLookUpGroupDetail = new List<LookUpGroupDetailList>();
            try
            {
                
                var result = lookupgroupdetailObj.GetLookUpGroupDetail();
                foreach (var param in result)
                {
                    lstLookUpGroupDetail.Add(new LookUpGroupDetailList()
                    {
                        LookUpGroupDetailId = (int)param.GroupDetailsId,
                        LookUpGroupId = (int)param.LookUpGroupId,
                        VariableId = (int)param.VariableId
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }

            return lstLookUpGroupDetail;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, GetLookUpGroupDetailList());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, Error.ParameterEmpty(ex.Message.ToString()));
            }
        }

        [HttpGet]
        [Route("api/LookUpGroupDetail/GetDatabyLookupGroupId")]
        public HttpResponseMessage GetDatabyLookupGroupId(int lookupgroupId)
        {
            try
            {
                List<LookupList> HeaderResult =lookupgroupdetailObj.GetHeaderbyLookupGroupId(lookupgroupId);
                List<DynamicLookupList> DataResult = lookupgroupdetailObj.GetDatabyLookupGroupId(lookupgroupId);
                DataTable finalData = pivotObj.GetPivotData(DataResult);
                List<GridVariableList> VariableResult = lookupgroupdetailObj.GetGridVariableDetails(lookupgroupId);
                List<LookupReturn> result = new List<LookupReturn>() { new LookupReturn() { GridHeader=HeaderResult,GridData=finalData,GridVariable=VariableResult} };
                return Request.CreateResponse(HttpStatusCode.OK, result);

            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, Error.ParameterEmpty(ex.Message.ToString()));
            }

        }

        [HttpPut]
        [Route("api/LookUpGroupDetail/UpdateGridVariables")]
        public HttpResponseMessage UpdateLookUpGroupDetail(IEnumerable<LookUpGroupDetails> lookupgroupdetailValue)
        {
            try
            {
                if (ModelState.IsValid && lookupgroupdetailValue != null)
                {
                    lookupgroupdetailObj.UpdateGridVariableValues(lookupgroupdetailValue);
                   
                    return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails(Helper.sInsertSuccess,true));

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
                string error = Resource.GetResxValueByName("LookUpGroupDetailDuplicatemsg");
                if (ex.Message.Contains(error))
                {
                    message = error;
                }else
                {
                    message = ex.Message.ToString();
                }
                return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails(message));
            }
        }


        [HttpPost]
        [Route("api/LookUpGroupDetail/InsertGridVariables")]
        public HttpResponseMessage AddLookUpGroupDetail(IEnumerable<LookUpGroupDetails> lookupgroupdetailValue)
        {
            try
            {
              
                if (ModelState.IsValid && (lookupgroupdetailValue != null))
                {
                   lookupgroupdetailObj.AddGridVariables(lookupgroupdetailValue);
                  
                    return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails(Helper.sInsertSuccess,true));
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
        [Route("api/LookUpGroupDetail/DeleteGridVariables")]
        public HttpResponseMessage DeleteGridVariables(long lookupgroupdetailId)
        {
            try
            {
              int lookupgroupId=   lookupgroupdetailObj.DeleteGridVariableDetail(lookupgroupdetailId);
                List<LookupList> HeaderResult = lookupgroupdetailObj.GetHeaderbyLookupGroupId(lookupgroupId);
                List<DynamicLookupList> DataResult = lookupgroupdetailObj.GetDatabyLookupGroupId(lookupgroupId);
                DataTable finalData = pivotObj.GetPivotData(DataResult);
                List<GridVariableList> VariableResult = lookupgroupdetailObj.GetGridVariableDetails(lookupgroupId);
                List<LookupReturn> result = new List<LookupReturn>() { new LookupReturn() { GridHeader = HeaderResult, GridData = finalData, GridVariable = VariableResult } };

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, Error.ParameterEmpty(ex.Message.ToString()));

            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int lookupgroupdetail)
        {
            try
            {
              int LookUpGroupId= lookupgroupdetailObj.DeleteLookUpGroupDetail(lookupgroupdetail);
                return Request.CreateResponse(HttpStatusCode.OK, lookupgroupdetailObj.GetLookUpGroupDetailsVariable(LookUpGroupId));
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
                List<LookUpGroupDetails> lstLookUpGroupDetail = new List<LookUpGroupDetails>();
                var result = lookupgroupdetailObj.GetLookupGroupDetail(Id);
                if (result.Count != 0)
                {
                    foreach (var param in result)
                    {
                        lstLookUpGroupDetail.Add(new LookUpGroupDetails()
                        {
                            LookUpGroupDetailId = param.GroupDetailsId,
                            LookUpGroupId = param.LookUpGroupId,                            
                            VariableId = param.VariableId,
                            LookUpRangeTypeId = (int)param.LookupRangeTypeId,
                            IsActive = param.IsActive,
                            CreatedBy = param.CreatedBy,
                            CreatedOn = param.CreatedOn,
                            UpdatedBy = param.UpdatedBy,
                            UpdatedOn = param.UpdatedOn
                        });
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, lstLookUpGroupDetail);
                }
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, Helper.sIdNotFound + Id);
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }


    }
}
