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
    public class TaxMasterController : ApiController
    {
        // [Authorize] // security integration  

        readonly Errorlist ErrorList = new Errorlist();
        #region TaxMaster
      readonly  TaxMaster taxMasterObj = new TaxMaster();
        [HttpGet]
        public HttpResponseMessage GetTaxMasterName(int MarketId)
        {
            try
            {
                List<TaxMasterName> lstTax = new List<TaxMasterName>();
                var result = taxMasterObj.GetTaxMasterByMarketId(MarketId);
                if (result.Count != 0)
                {
                    foreach (var item in result)
                    {
                        lstTax.Add(new TaxMasterName()
                        {
                            TaxId = (int)item.TaxMasterId,
                            TaxName = item.TaxName,
                            
                        });
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, lstTax);
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, Resource.GetResxValueByName("CmnDataNotFound"));
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

      
        [HttpPut]
        [Route("api/TaxMaster/UpdateTaxMasterDetails")]
        public HttpResponseMessage UpdateTaxMasterDetails(IEnumerable<TaxMasterData> taxMasterDetailsValue)
        {
            try
            {
                if (ModelState.IsValid && (taxMasterDetailsValue != null))
                {
                  taxMasterObj.UpdateTaxMasterDetails(taxMasterDetailsValue);
                    List<string> lstresponse = new List<string>() { Helper.sUpdateSuccess };
                    //call clear cache if tax status is published
                    if (taxMasterDetailsValue.FirstOrDefault().TaxVersionStatusId == 31)
                    {
                        CleanCache.ClearMarketCache();
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
                if (ex.Message.Contains(Resource.GetResxValueByName("MarketIdPriorityCombDuplicatemsg")))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails(Resource.GetResxValueByName("MarketIdPriorityCombDuplicatemsg")));
                }
                else if (ex.Message.Contains(Resource.GetResxValueByName("VersionConflictmsg")))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails(Resource.GetResxValueByName("VersionConflictmsg")));
                }
                return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails(ex.Message.ToString()));
            }
        }
        [HttpPost]
        [Route("api/TaxMaster/AddTaxMasterDetails")]
        public HttpResponseMessage AddTaxMasterDetails(IEnumerable<TaxMasterData> taxMasterDetailsValue)
        {
            try
            {
                if (ModelState.IsValid && (taxMasterDetailsValue != null))
                {
                    taxMasterObj.AddTaxMasterDetails(taxMasterDetailsValue);
                    ErrorList.SuccessMsg = Helper.sInsertSuccess;
                    //call clear cache if tax status is published
                    if (taxMasterDetailsValue.FirstOrDefault().TaxVersionStatusId == 31)
                    {
                        CleanCache.ClearMarketCache();
                    }

                    return Request.CreateResponse(HttpStatusCode.Created, Error.GetErrorDetails(Helper.sInsertSuccess,true));
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
                if (ex.Message.Contains(Resource.GetResxValueByName("MarketIdPriorityCombDuplicatemsg")))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails(Resource.GetResxValueByName("MarketIdPriorityCombDuplicatemsg")));
                }
                else if (ex.Message.Contains(Resource.GetResxValueByName("VersionConflictmsg")))

                {
                    return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails(Resource.GetResxValueByName("VersionConflictmsg")));
                }
                return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails(ex.Message.ToString()));
            }
        }



        

       
        [HttpGet]
        [Route("api/TaxMaster/Get/{Id}")]
        public HttpResponseMessage Get(int Id)
        {
            try
            {
                List<TaxMaster> lstTaxMaster = new List<TaxMaster>();
                var result = taxMasterObj.GetTaxMaster(Id);
                if (result.Count != 0)
                {
                    foreach (var item in result)
                    {
                        lstTaxMaster.Add(new TaxMaster()
                        {   TaxMasterId=item.TaxMasterId,
                            MarketId = item.MarketId,
                            TaxName = item.TaxName,
                            TaxPositionId = item.TaxPositionId,
                            Priority = item.Priority,
                            IsActive = item.IsActive,
                            CreatedBy = item.CreatedBy,
                            CreatedOn = item.CreatedOn,
                            UpdatedBy = item.UpdatedBy,
                            UpdatedOn = item.UpdatedOn
                        });
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, lstTaxMaster);
                }
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound,Helper.sIdNotFound+ Id);

            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }

        readonly

        #endregion

        #region TaxVersion
        TaxVersion taxVersionObj = new TaxVersion();
        [HttpGet]
        public HttpResponseMessage GetTaxVersionName(int TaxMasterId)
        {
            try
            {
                List<TaxVersionName> lstTaxVersion = taxVersionObj.GetTaxVersionByTaxMasterId(TaxMasterId);
                return Request.CreateResponse(HttpStatusCode.OK, lstTaxVersion);
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        readonly

        #endregion
        #region Tax Flow
        Tax taxObj = new Tax();
             [HttpGet]
        public HttpResponseMessage GetTaxFlowName(int TaxVersionId)
        {
            try
            {
                List<TaxFlowName> lstTax = taxObj.GetTaxByVersionId(TaxVersionId);
                return Request.CreateResponse(HttpStatusCode.OK, lstTax);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }
        [HttpGet]
        public HttpResponseMessage GetTaxDetails(long TaxId)
        {
            try
            {
                List<TaxMasterData> lstTaxMaster = taxObj.GetTaxDetailsByTaxId(TaxId);
                
                    return Request.CreateResponse(HttpStatusCode.OK, lstTaxMaster);
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }
        #endregion


        #region Calculation Order Swap
        [HttpGet]
        public HttpResponseMessage GetCalculationOrder(long TaxMasterId)
        {
            try
            {
                List<CalculationOrder> lstCalculationOrder = new CalculationOrder().GetCalculationOrderByTaxId(TaxMasterId);

                return Request.CreateResponse(HttpStatusCode.OK, lstCalculationOrder);
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        [HttpPut]
        [Route("api/TaxMaster/SwapCalculationOrder")]
        public HttpResponseMessage SwapCalculationOrder(long taxMasterId, long swaptaxMasterId , string loginUser)
        {
            try
            {
                if (ModelState.IsValid && (loginUser != null) )
                {
                    new CalculationOrder().SwapCalculationOrderDetails(taxMasterId , swaptaxMasterId , loginUser);
                    return Request.CreateResponse(HttpStatusCode.Created, Error.GetErrorDetails(Helper.sUpdateSuccess, true));
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

        [HttpGet]
        public HttpResponseMessage GetNewCalculationOrder(long taxTerritoryId)
        {
            try
            {
                List<VariableDropList> lstCalculationOrder = new CalculationOrder().GetNewCalculationOrderByTaxId(taxTerritoryId);

                return Request.CreateResponse(HttpStatusCode.OK, lstCalculationOrder);
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }
        #endregion
    }

   
}
