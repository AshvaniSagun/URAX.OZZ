#region NameSpaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Web;
using EF = UraxUIServiceWebApi.EF;
using UraxUIServiceWebApi.Repository;
using UraxUIServiceWebApi.ResourceFiles; 
#endregion

namespace UraxUIServiceWebApi.Models
{
  public  class Market
    {
        #region Market Property
        [JsonProperty(PropertyName = "marketId")]
        public long MarketId { get; set; }
        [JsonProperty(PropertyName = "countryName")]
        
        public string MarketName { get; set; }
        [JsonProperty(PropertyName = "countryCodeId")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "CountryCodeIdReq")]
        

        public int CountryCodeId { get; set; }
        [JsonProperty(PropertyName = "submarketCode")]
        

       [StringLength(20, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "SubmarketCodeLength", MinimumLength =0)]
        public string SubmarketCode { get; set; }
        [JsonProperty(PropertyName = "currencyId")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "CurrencyIdReq")]
        public int CurrencyId { get; set; }
        [JsonProperty(PropertyName = "isActive")]
        public bool IsActive { get; set; }

        [JsonProperty(PropertyName = "createdBy")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "CreatedByReq")]
        public string CreatedBy { get; set; }

        [JsonProperty(PropertyName = "createdOn")]
        public System.DateTime CreatedOn { get; set; }

        [JsonProperty(PropertyName = "updatedBy")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "UpdatedByReq")]
        public string UpdatedBy { get; set; }
        [JsonProperty(PropertyName = "updatedOn")]
        public System.DateTime UpdatedOn { get; set; }
        [JsonProperty(PropertyName = "countryCode")]
        public string CountryCode { get; set; }
        [JsonProperty(PropertyName = "currencyCode")]
        public string CurrencyCode { get; set; }
        [JsonProperty(PropertyName = "taxTerritory")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "TaxTerritoryReq")]
        [MaxLength(50, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MaxLength50")]
        public string TaxTerritory { get; set; }
        [JsonProperty(PropertyName = "featureLevelTax")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "FeatureLevelTaxReq")]
        public bool FeatureLevelTax { get; set; }
        [JsonProperty(PropertyName = "subdivisionCode")]
        [MaxLength(50,ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MaxLength50")]
        public string SubdivisionCode { get; set; }
        #endregion

        #region Get All Market
        /// <summary>
        /// To get all Market
        /// </summary>
        /// <returns>List of all Market details</returns>
        public List<Market> GetMarket()
        {
            try
            {
                using (var market = new UnitofWork())
                {
                    List<EF.Market> lstmarket = market.MarketRepository.Find(x => x.IsActive == true).ToList();
                    var result = (from ld in market.CountryCodeRepository.GetAll()
                                  join tm in lstmarket on ld.CountryCodeId equals tm.CountryCodeId
                                  select new { tm.MarketId, ld.CountryName}).OrderBy(x => x.CountryName).ToList();
                    List<Market> lstData = new List<Market>(); 
                    foreach(var data in result)
                    {
                        lstData.Add(new Market()
                        {
                            MarketId = data.MarketId,
                            MarketName = data.CountryName
                        });
                    }
                    return lstData;
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }
        } 
        #endregion

        #region Get Market by Id
        /// <summary>
        /// To get Market by id
        /// </summary>
        /// <param name="id">An integer which represents Market Id</param>
        /// <returns>List of Market Details</returns>
        public List<EF.Market> GetMarket(int id)
        {
            try
            {
                using (var market = new UnitofWork())
                {
                    return market.MarketRepository.Find(p => p.MarketId == id && p.IsActive == true).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }
        } 
        #endregion

        #region Delete Market
        /// <summary>
        /// To delete Market details
        /// </summary>
        /// <param name="marketId">An integer which represents Market Id</param>
        public void DeleteMarket(int marketId)
        {


            try
            {
                using (var market = new UnitofWork())
                {
                    List<EF.Market> lstmarket  = market.MarketRepository.Find(p => p.MarketId == marketId).ToList();
                    if (lstmarket.Count == 0)
                    {
                        throw new InvalidOperationException(Resource.GetResxValueByName("CmnDataNotFound"));
                    }

                    List<EF.TaxMaster>  lsttaxmaster = market.TaxMasterRepository.Find(p => p.MarketId == marketId).ToList();
                    List<EF.LanguageDetail> lstlanguagedetails = (from ld in market.LanguageDetailsRepository.GetAll()
                                          join tm in lsttaxmaster on ld.TaxMasterId equals tm.TaxMasterId
                                          select ld).ToList();
                    List<EF.TaxVersion> lsttaxversion = (from tv in market.TaxVersionRepository.GetAll()
                                     join tm in lsttaxmaster on tv.TaxMasterId equals tm.TaxMasterId
                                     select tv).ToList();
                    List<EF.Tax> lsttax = (from t in market.TaxRepository.GetAll()
                              join tv in lsttaxversion on t.TaxVersionId equals tv.TaxVersionId
                              select t).ToList();
                    List<EF.Variable> lstvariable= (from v in market.VariableRepository.GetAll()
                                   join t in lsttax on v.TaxId equals t.TaxId
                                   select v).ToList();
                    List<EF.Formula> lstformula = (from f in market.FormulaRepository.GetAll()
                                  join v in lstvariable on f.VariableId equals v.VariableId
                                  select f).ToList();
                    List<EF.FormulaDefinitionDependencyDetail> lstformuladefinition = (from fd in market.FormulaDefinitionDependencyDetailsRepository.GetAll()
                                                                                       join f in lstformula on fd.FormulaId equals f.FormulaId
                                                                                        select fd).ToList();
                    List<EF.LookUpGroup> lstlookupgroup = (from lg in market.LookUpGroupRepository.GetAll()
                                                           join t in lsttax on lg.TaxId equals t.TaxId
                                                           select lg).ToList();
                    List<EF.LookupGroupDetail> lstlookupgroupdetail  = (from lgd in market.LookupGroupDetailRepository.GetAll()
                                            join v in lstvariable on lgd.VariableId equals v.VariableId
                                            join lg in lstlookupgroup on lgd.LookUpGroupId equals lg.LookUpGroupId
                                            select lgd).ToList();
                    List<EF.LookUpDetail> lstlookupdetails = (from ld in market.LookUpDetailsRepository.GetAll()
                                        join t in lstlookupgroupdetail on ld.GroupDetailsId equals t.GroupDetailsId
                                        select ld).ToList();

                    market.LookUpDetailsRepository.RemoveRange(lstlookupdetails);
                    market.LookupGroupDetailRepository.RemoveRange(lstlookupgroupdetail);
                    market.LookUpGroupRepository.RemoveRange(lstlookupgroup);
                    market.FormulaDefinitionDependencyDetailsRepository.RemoveRange(lstformuladefinition);
                    market.FormulaRepository.RemoveRange(lstformula);
                    market.VariableRepository.RemoveRange(lstvariable);
                    market.TaxRepository.RemoveRange(lsttax);
                    market.TaxVersionRepository.RemoveRange(lsttaxversion);
                    market.LanguageDetailsRepository.RemoveRange(lstlanguagedetails);
                    market.TaxMasterRepository.RemoveRange(lsttaxmaster);
                    market.MarketRepository.RemoveRange(lstmarket);

                }
            }

            catch (Exception ex)
            {
                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }

        }

        internal object GetCountry()
        {
            try
            {
                List<List> drpTaxTerritoryData = new List<List>();
                using (var market = new UnitofWork())
                {
                    List<EF.Market> lstmarket = market.MarketRepository.Find(x => x.IsActive == true).ToList();
                    var result = (from ld in market.CountryCodeRepository.GetAll()
                                  join tm in lstmarket on ld.CountryCodeId equals tm.CountryCodeId
                                  select new { tm.CountryCodeId, ld.CountryName }).OrderBy(x => x.CountryName).Distinct().ToList();
                    foreach (var data in result)
                    {
                        drpTaxTerritoryData.Add(new List()
                        {
                            Id = (int)data.CountryCodeId,
                            Name = data.CountryName
                        });
                    }
                    return drpTaxTerritoryData;
                }
               
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }
        }

            internal object GetTaxTerritoryList(int CountryCodeId)
        {
            try
            {
                List<List> drpTaxTerritoryData = new List<List>();
                using (var market = new UnitofWork())
                {
                   var  result = market.MarketRepository.Find(x => x.CountryCodeId == CountryCodeId&&x.IsActive==true).Select(x=> new {x.TaxTerritory, x.MarketId } ).ToList();
                    foreach(var data in result)
                    {
                        drpTaxTerritoryData.Add(new List()
                        {
                             Id = (int)data.MarketId,
                              Name = data.TaxTerritory
                        });
                    }
                    return drpTaxTerritoryData;
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        #endregion

        #region Get Market Details
        /// <summary>
        /// To get all Market
        /// </summary>
        /// <returns>List of all Market details</returns>
        public List<Market> GetMarketDetail()
        {
            List<Market> lstMarket = new List<Market>();
            try
            {
                //Get List of Country code

                //Get list of Currency
                using (var market = new UnitofWork())
                {
                    var lstCurrency = market.CurrencyDetailsRepository.GetAll();
                    var lstCountryCode = market.CountryCodeRepository.GetAll();
                    var result1 = (from ld in market.MarketRepository.GetAll()
                                   join t in lstCurrency on ld.currencyId equals t.CurrencyId
                                   join tt in lstCountryCode on ld.CountryCodeId equals tt.CountryCodeId

                                   select new { ld.MarketId, tt.CountryName,ld.FeatureLevelTax,ld.TaxTerritory,ld.SubdivisionCode, ld.TaxPartnerGroup, ld.IsActive, ld.CreatedBy, ld.CreatedOn, ld.UpdatedBy, ld.UpdatedOn, ld.CountryCodeId, ld.currencyId, t.CurrencyCode ,t.CurrencyName, tt.CountryCode1 }).OrderBy(x=>x.CountryName).ThenBy(x=>x.TaxTerritory).ToList();


                    foreach (var value in result1)
                    {
                        lstMarket.Add(new Market()
                        {
                            MarketId = (int)value.MarketId,
                            MarketName = value.CountryName.Trim(),
                            CountryCodeId = value.CountryCodeId,
                            SubmarketCode = value.TaxPartnerGroup,
                            FeatureLevelTax = value.FeatureLevelTax,
                            SubdivisionCode = value.SubdivisionCode,
                            TaxTerritory = value.TaxTerritory,
                            CurrencyId = value.currencyId,
                            IsActive = value.IsActive,
                            CreatedBy = value.CreatedBy,
                            CreatedOn = value.CreatedOn,
                            UpdatedBy = value.UpdatedBy,
                            UpdatedOn = value.UpdatedOn,
                            CountryCode = value.CountryCode1,
                            CurrencyCode = value.CurrencyCode + " - " + value.CurrencyName

                        });
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return lstMarket;
        } 
        #endregion

        #region Update Market
        /// <summary>
        /// To Update Market Details
        /// </summary>
        /// <param name="marketValue">Market Details to Update</param>
        /// <returns>List of Updated Market Details</returns>
        public List<EF.Market> UpdateMarket(IEnumerable<Market> marketValue)
        {
            try
            {
                using (var market = new UnitofWork())
                {
                    foreach (var data in marketValue)
                    {
                        long mId = data.MarketId;
                        long lCountryId = data.CountryCodeId;
                        string sTaxTerritory = data.TaxTerritory.Trim();
                       
                        if (market.MarketRepository.Find(x => x.MarketId == mId).ToList().Count == 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("CmnDataNotFound"));
                        }
                        else if (market.MarketRepository.Find(x =>x.MarketId!=data.MarketId&& x.TaxTerritory == data.TaxTerritory).ToList().Count > 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("TaxTerritoryDuplicate"));
                        }
                        else if (market.MarketRepository.Find(x => x.CountryCodeId == lCountryId && x.TaxTerritory == sTaxTerritory && x.MarketId != mId).ToList().Count > 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("MarketTaxTerritoryDuplicatemsg"));
                        }
                        
                    }
                }

                List<EF.Market> lstmarket = new List<EF.Market>();
                List<string> lstField = new List<string>();
                using (var market = new UnitofWork())
                {
                    foreach (var value in marketValue)
                    {
                            string marketName = market.CountryCodeRepository.Find(x => x.CountryCodeId == value.CountryCodeId).Select(x => x.CountryName).FirstOrDefault();


                        if (marketName != null)
                        {
                            lstmarket.Add(new EF.Market()
                            {
                                MarketId = value.MarketId,
                                //MarketName = marketName,
                                CountryCodeId = value.CountryCodeId,
                                TaxPartnerGroup = value.SubmarketCode,
                                SubdivisionCode = value.SubdivisionCode,
                                FeatureLevelTax = value.FeatureLevelTax,
                                TaxTerritory = value.TaxTerritory.Trim(),
                                currencyId = value.CurrencyId,
                                IsActive = value.IsActive,
                                CreatedBy = value.CreatedBy,
                                CreatedOn = value.CreatedOn,
                                UpdatedBy = value.UpdatedBy,
                                UpdatedOn = DateTime.UtcNow
                            });
                        }
                        else
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("InvalidMarNameMsg"));

                        } 
                        
                    } 
                }

                lstField.Add("CountryCodeId");
                lstField.Add("TaxPartnerGroup");
                lstField.Add("currencyId");
                lstField.Add("SubdivisionCode");
                lstField.Add("FeatureLevelTax");
                lstField.Add("TaxTerritory");

                lstField.Add("IsActive");
                lstField.Add("UpdatedBy");
                lstField.Add("UpdatedOn");


                using (var marketobj = new UnitofWork())
                {
                    marketobj.MarketRepository.UpdateRange(lstmarket, lstField);
                }
                return lstmarket;
            }


            catch (Exception ex)
            {

                throw new InvalidOperationException( ex.Message);
            }
        }
        #endregion

        #region Add Market
        /// <summary>
        /// To add Market Details
        /// </summary>
        /// <param name="marketValue">Market Details to Add</param>
        /// <returns>List of Added market Details</returns>
        public List<Market> AddMarket(IEnumerable<Market> marketValue)
        {

            try
            {
                using (var market = new UnitofWork())
                {
                    foreach (var item in marketValue)
                    {
                        int countryCodeId = item.CountryCodeId;
                        string subMarketCode = item.SubmarketCode;
                        int marketid = (int)item.MarketId;
                        string strTaxTerritory = item.TaxTerritory.Trim();
                       
                        if (market.MarketRepository.Find(x => x.MarketId == marketid  || (x.TaxPartnerGroup == subMarketCode && x.CountryCodeId == countryCodeId && x.TaxTerritory ==strTaxTerritory) || (x.TaxTerritory == strTaxTerritory && x.CountryCodeId == countryCodeId) ).ToList().Count > 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("MarketDuplicatemsg"));
                        }
                        else if(market.MarketRepository.Find(x=>x.TaxTerritory==item.TaxTerritory).ToList().Count >0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("TaxTerritoryDuplicate"));
                        }
                        else if (market.MarketRepository.Find(x => x.CountryCodeId == countryCodeId && x.TaxTerritory == strTaxTerritory && x.MarketId != marketid).ToList().Count > 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("MarketTaxTerritoryDuplicatemsg"));
                        } 
                    }
                    List<EF.Market> lstmarket = new List<EF.Market>();
                    foreach (var item in marketValue)
                    {
                        
                            string marketName = market.CountryCodeRepository.Find(x => x.CountryCodeId == item.CountryCodeId).Select(x=>x.CountryName).FirstOrDefault();

                        if (marketName != null)
                        {
                            lstmarket.Add(new EF.Market()
                            {
                                MarketId = item.MarketId,
                                // MarketName = marketName,
                                CountryCodeId = item.CountryCodeId,
                                TaxPartnerGroup = item.SubmarketCode,
                                currencyId = item.CurrencyId,
                                SubdivisionCode = item.SubdivisionCode.Trim(),
                                TaxTerritory = item.TaxTerritory.Trim(),
                                FeatureLevelTax = item.FeatureLevelTax,
                                IsActive = item.IsActive,
                                CreatedBy = item.CreatedBy.Trim(),
                                CreatedOn = DateTime.UtcNow,
                                UpdatedBy = item.UpdatedBy.Trim(),
                                UpdatedOn = DateTime.UtcNow
                                 
                                 

                            });
                        }
                        else
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("InvalidMarNameMsg"));
                        }
                        
                    }

                    market.MarketRepository.AddRange(lstmarket);



                    List<Market> lstMarket1 = new List<Market>();

                    using (var marketResponse = new UnitofWork())
                    {
                        foreach (var data in lstmarket)
                        {
                            int mId = (int)data.MarketId;


                            using (var market1 = new UnitofWork())
                            {
                                var lstCurrency = market.CurrencyDetailsRepository.GetAll();
                                var lstCountryCode = market.CountryCodeRepository.GetAll();
                                var result = GetMarket(mId);
                                var result1 = (from ld in market.MarketRepository.GetAll()
                                               join m in result on ld.MarketId equals m.MarketId
                                               join t in lstCurrency on ld.currencyId equals t.CurrencyId
                                               join tt in lstCountryCode on ld.CountryCodeId equals tt.CountryCodeId
                                               select new { ld.MarketId, tt.CountryName,ld.TaxTerritory,ld.SubdivisionCode,ld.FeatureLevelTax  , ld.TaxPartnerGroup, ld.IsActive, ld.CreatedBy, ld.CreatedOn, ld.UpdatedBy, ld.UpdatedOn, ld.CountryCodeId, ld.currencyId, t.CurrencyCode, tt.CountryCode1 }).ToList();
                                foreach (var value in result1)
                                {
                                    lstMarket1.Add(new Market()
                                    {
                                        MarketId = (int)value.MarketId,
                                        MarketName = value.CountryName.Trim(),
                                        CountryCodeId = value.CountryCodeId,
                                        SubmarketCode = value.TaxPartnerGroup,
                                        CurrencyId = value.currencyId,
                                        SubdivisionCode = value.SubdivisionCode,
                                        FeatureLevelTax = value.FeatureLevelTax,
                                        TaxTerritory = value.TaxTerritory,
                                        IsActive = value.IsActive,
                                        CreatedBy = value.CreatedBy,
                                        CreatedOn = value.CreatedOn,
                                        UpdatedBy = value.UpdatedBy,
                                        UpdatedOn = value.UpdatedOn,
                                        CountryCode = value.CountryCode1,
                                        CurrencyCode = value.CurrencyCode
                                    });
                                }
                            }
                        }

                        return lstMarket1;
                    }


                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }


        }
        #endregion

    }
    public class MarketList
    {
        #region MarketList Property

        [JsonProperty(PropertyName = "marketId")]
        public int MarketId { get; set; }
        [JsonProperty(PropertyName = "marketName")]
        public string MarketName { get; set; }
        [JsonProperty(PropertyName = "countryCodeId")]
        public int CountryCodeId { get; set; }
        [JsonProperty(PropertyName = "subMarketCode")]
        public string SubmarketCode { get; set; }
        [JsonProperty(PropertyName = "currencyId")]
        public int CurrencyId { get; set; }
        [JsonProperty(PropertyName = "isActive")]
        public bool IsActive { get; set; }
        [JsonProperty(PropertyName = "createdBy")]
        public string CreatedBy { get; set; }
        [JsonProperty(PropertyName = "createdOn")]
        public string CreatedOn { get; set; }
        [JsonProperty(PropertyName = "updatedBy")]
        public string UpdatedBy { get; set; }
        [JsonProperty(PropertyName = "updatedOn")]
        public string UpdatedOn { get; set; }
        [JsonProperty(PropertyName = "countryCode")]
        public string CountryCode { get; set; }
        [JsonProperty(PropertyName = "currencyCode")]
        public string CurrencyCode { get; set; } 
        #endregion
    }
}
