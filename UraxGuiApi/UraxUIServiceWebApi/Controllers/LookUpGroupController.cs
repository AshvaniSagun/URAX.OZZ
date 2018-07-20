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
    
    public class LookUpGroupController : ApiController
    {
        readonly LookUpGroup lookupgroupObj = new LookUpGroup();


        private static List<LookUpGroupList> GetLookUpGroupList()
        {
            List<LookUpGroupList> lstLookUpGroup = new List<LookUpGroupList>();
            try
            {
                var result = LookUpGroup.GetLookUpGroup();
                foreach (var param in result)
                {
                    lstLookUpGroup.Add(new LookUpGroupList()
                    {
                        LookUpGroupId = (int)param.LookUpGroupId,
                        TaxId = (int)param.TaxId,
                        LookUpGroupName = param.LookUpGroupName
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }

            return lstLookUpGroup;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, GetLookUpGroupList());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, Error.ParameterEmpty(ex.Message.ToString()));
            }
        }


        [HttpPut]
        public HttpResponseMessage UpdateLookUpGroup([FromUri]int lookupgroupId, [FromUri] int taxid, [FromUri] string lookupgroupname)
        {
            try
            {
                LookUpGrpData lookupgroupValue = new LookUpGrpData() { ID=lookupgroupId,TaxId=taxid,Name=lookupgroupname};
                    lookupgroupObj.UpdateLookUpGroup(lookupgroupValue);
                    return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails(Helper.sUpdateSuccess,true));
               
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails(ex.Message.ToString()));

            }

        }

        [HttpPost]
        public HttpResponseMessage AddLookUpGroup(IEnumerable<LookUpGroup> lookupgroupValue)
        {
            try
            {

                if (ModelState.IsValid && (lookupgroupValue != null))
                {
                    lookupgroupObj.AddLookUpGroup(lookupgroupValue);
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
        public HttpResponseMessage Delete(int lookupgroupId)
        {
            try
            {
                lookupgroupObj.DeleteLookUpGroup(lookupgroupId);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Error.ParameterEmpty(ex.Message.ToString()));

            }
        }

        [HttpGet]
        public HttpResponseMessage Get(int Id)
        {
            try
            {
                List<LookUpGroup> lstLookUpGroup = new List<LookUpGroup>();
                var result = LookUpGroup.GetLookUpGroup(Id);
                if (result.Count != 0)
                {
                    foreach (var param in result)
                    {
                        lstLookUpGroup.Add(new LookUpGroup()
                        {
                            LookUpGroupId = param.LookUpGroupId,
                            TaxId = param.TaxId,
                            LookUpGroupName = param.LookUpGroupName,                            
                            IsActive = param.IsActive,
                            CreatedBy = param.CreatedBy,
                            CreatedOn = param.CreatedOn,
                            UpdatedBy = param.UpdatedBy,
                            UpdatedOn = param.UpdatedOn
                            
                        });
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, lstLookUpGroup);
                }
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No data is associated with  Id:" + Id);
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }

        [HttpGet]
        public HttpResponseMessage GetLookUpGroup(int TaxFlowId)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, lookupgroupObj.GetLookUpGroupByTaxFlowId(TaxFlowId));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, Error.ParameterEmpty(ex.Message.ToString()));
            }
        }

        [HttpGet]
        public HttpResponseMessage GetVariableForLookUpGroup(int lookupgroupId)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, lookupgroupObj.GetVariableForLookUpGroup(lookupgroupId));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, Error.ParameterEmpty(ex.Message.ToString()));
            }
        }

    }
}
