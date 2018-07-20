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

    public class MarketController : ApiController
    {
        readonly Market marketObj = new Market();

        [HttpGet]
        [Route("api/market/Get")]
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, GetMarketList());
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, Error.ParameterEmpty(ex.Message.ToString()));
            }
        }

        private List<MarketList> GetMarketList()
        {
            List<MarketList> lstMarket = new List<MarketList>();
            try
            {
                var result = marketObj.GetMarket();
               
                foreach (var param in result)
                {
                    lstMarket.Add(new MarketList()
                    {
                        MarketId = (int)param.MarketId,
                        MarketName = param.MarketName
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lstMarket;
        }

        [HttpGet]
        [Route("api/market/GetMarket")]
        public HttpResponseMessage GetMarketDetails()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, marketObj.GetMarketDetail());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, Error.ParameterEmpty(ex.Message.ToString()));
            }
        }

        [HttpPut]
        public HttpResponseMessage UpdateMarket([FromBody] IEnumerable<Market> marketValue)
        {
            try
            {
                if (ModelState.IsValid && marketValue != null)
                {
                   marketObj.UpdateMarket(marketValue);
                    return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails(Helper.sUpdateSuccess,true));
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK,
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
        public HttpResponseMessage AddMarket(IEnumerable<Market> marketValue)
        {
            try
            {
                if (ModelState.IsValid && (marketValue != null))
                {
                    marketObj.AddMarket(marketValue);
                    return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails(Helper.sInsertSuccess,true));
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK,
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
        public HttpResponseMessage Delete(int marketId)
        {
            try
            {
                marketObj.DeleteMarket(marketId);
                return Request.CreateResponse(HttpStatusCode.OK, Helper.sDeleteSuccess);
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
                List<Market> lstMarket = new List<Market>();
                var result = marketObj.GetMarket(Id);
                if (result.Count != 0)
                {
                    foreach (var param in result)
                    {
                        lstMarket.Add(new Market()
                        {
                            MarketId = param.MarketId,
                          //  MarketName = param.MarketName,
                            CountryCodeId = param.CountryCodeId,
                            SubmarketCode = param.TaxPartnerGroup,
                            CurrencyId = param.currencyId,
                            IsActive = param.IsActive,
                            CreatedBy = param.CreatedBy,
                            CreatedOn = param.CreatedOn,
                            UpdatedBy = param.UpdatedBy,
                            UpdatedOn = param.UpdatedOn
                        });
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, lstMarket);
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
        [Route("api/market/GetTaxTerritory")]
        public HttpResponseMessage GetTaxTerritory(int CountryCodeId)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, marketObj.GetTaxTerritoryList(CountryCodeId));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, Error.ParameterEmpty(ex.Message.ToString()));
            }
        }
        [HttpGet]
        [Route("api/market/GetCountry")]
        public HttpResponseMessage GetCountry()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, marketObj.GetCountry());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, Error.ParameterEmpty(ex.Message.ToString()));
            }
        }


    }
}
