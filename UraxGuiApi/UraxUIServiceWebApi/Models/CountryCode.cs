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
    public class CountryCode
    {
        #region CountryCode Property
        [JsonProperty(PropertyName = "countryCodeId")]
        public int CountryCodeId { get; set; }
        [JsonProperty(PropertyName = "countryCode")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "CountryCodeReq")]
        public string CountryCode1 { get; set; }
        [JsonProperty(PropertyName = "countryName")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "CountryNameReq")]
        public string CountryName { get; set; }
        [JsonProperty(PropertyName = "cultureInfoDetails")]
        public string CultureInfoDetails { get; set; }
        [JsonProperty(PropertyName = "descriptions")]
        public string Descriptions { get; set; }
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
        #endregion
        #region     Get All CountryCode
        /// <summary>
        ///  fetch all stored Country datas from the database
        /// </summary>
        /// <returns>it returns list of CountryCode</returns>
        public List<EF.CountryCode> GetCountryCode()
        {
            try
            {
                using (var countryCode = new UnitofWork())
                {
                    return countryCode.CountryCodeRepository.GetAll().OrderBy(x=>x.CountryName).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }
        }
        #endregion
        #region     Get CountryCode by Id
        /// <summary>
        /// fetch CurrencyDetails data with specified Country Code Id
        /// </summary>
        /// <param name="id"> an integer which represents CountryCode Id</param>
        /// <returns>Returns a list of Country details with specified CountryCode Id</returns>
        public List<EF.CountryCode> GetCountryCode(int id)
        {
            try
            {
                using (var countryCode = new UnitofWork())
                {
                    return countryCode.CountryCodeRepository.Find(p => p.CountryCodeId == id).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }
        }
        #endregion
        #region Update CountryCode
        /// <summary>
        /// Update Country Code  Details 
        /// </summary>
        /// <param name="countryCodeValue">a CountryCode Object, 
        /// that contains all the 
        /// data for updating</param>
        /// <returns> list of updated  Country details as CountryCode objects </returns>
        public List<EF.CountryCode> UpdateCountryCode(IEnumerable<CountryCode> countryCodeValue)
        {
            try
            {
                using (var countrycode = new UnitofWork())
                {
                    foreach (var data in countryCodeValue)
                    {
                        if (countrycode.CountryCodeRepository.Find(x=>x.CountryCodeId!=data.CountryCodeId&&(x.CountryCode1==data.CountryCode1)).ToList().Count>0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("CountryCodeDuplicatemsg"));
                        }else if (countrycode.CountryCodeRepository.Find(x => x.CountryCodeId != data.CountryCodeId && (x.CountryName == data.CountryName)).ToList().Count > 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("CountryNameDuplicatemsg"));
                        }
                    }
                }
                List<EF.CountryCode> lstcountry = new List<EF.CountryCode>();
                List<string> lstField = new List<string>();
                foreach (var item in countryCodeValue)
                {
                    lstcountry.Add(new EF.CountryCode()
                    {
                        CountryCode1 = item.CountryCode1,
                        CountryName = item.CountryName,
                        CultureInfoDetails = item.CultureInfoDetails,
                        Descriptions = item.Descriptions,
                        IsActive = item.IsActive,
                        UpdatedBy = item.UpdatedBy,
                        UpdatedOn = DateTime.UtcNow
                    });
                }
                lstField.Add("CountryCode1");
                lstField.Add("CountryName");
                lstField.Add("CultureInfoDetails");
                lstField.Add("Descriptions");
                lstField.Add("IsActive");
                lstField.Add("UpdatedBy");
                lstField.Add("UpdatedOn");
                using (var countrycodeobj = new UnitofWork())
                {
                    countrycodeobj.CountryCodeRepository.UpdateRange(lstcountry, lstField);
                }
                return lstcountry;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }
        }
        #endregion
        #region Delete Country Code
        /// <summary>
        /// Delete data from CountryCode details
        /// </summary>
        /// <param name="countryCodeId">a CountryCode Object, 
        /// that contains all the 
        /// data for deleting</param>
        public void DeleteCountryCode(int countryCodeId)
        {
            try
            {
                using (var countryCode = new UnitofWork())
                {
                    List<EF.CountryCode> lstcountrycode = countryCode.CountryCodeRepository.Find(x => x.CountryCodeId == countryCodeId).ToList();
                    if (lstcountrycode.Count == 0)
                    {
                        throw new InvalidOperationException(Resource.GetResxValueByName("CmnDataNotFound"));
                    }
                 var   lstmarket = countryCode.MarketRepository.Find(x => x.CountryCodeId == countryCodeId).ToList();
                    var lsttaxmaster = (from tm in countryCode.TaxMasterRepository.GetAll()
                                    join m in lstmarket on tm.MarketId equals m.MarketId
                                    select tm).ToList();
                    var lsttaxversion = (from tv in countryCode.TaxVersionRepository.GetAll()
                                     join tm in lsttaxmaster on tv.TaxMasterId equals tm.TaxMasterId
                                     select tv).ToList();
                    var lsttax = (from t in countryCode.TaxRepository.GetAll()
                              join tv in lsttaxversion on t.TaxVersionId equals tv.TaxVersionId
                              select t).ToList();
                    var lstvariable = (from v in countryCode.VariableRepository.GetAll()
                                   join t in lsttax on v.TaxId equals t.TaxId
                                   select v).ToList();
                    var lstformula = (from f in countryCode.FormulaRepository.GetAll()
                                  join v in lstvariable on f.VariableId equals v.VariableId
                                  select f).ToList();
                    var lstformuladefinition = (from fd in countryCode.FormulaDefinitionDependencyDetailsRepository.GetAll()
                                            join v in lstvariable on fd.VariableId equals v.VariableId
                                            join f in lstformula on fd.FormulaId equals f.FormulaId
                                            select fd).ToList();
                    var lstlookupgroup = (from lg in countryCode.LookUpGroupRepository.GetAll()
                                      join t in lsttax on lg.TaxId equals t.TaxId
                                      select lg).ToList();
                    var lstlookupgroupdetail = (from lgd in countryCode.LookupGroupDetailRepository.GetAll()
                                            join v in lstvariable on lgd.VariableId equals v.VariableId
                                            join lg in lstlookupgroup on lgd.LookUpGroupId equals lg.LookUpGroupId
                                            select lgd).ToList();
                    var lstlookupdetails = (from ld in countryCode.LookUpDetailsRepository.GetAll()
                                        join t in lstlookupgroupdetail on ld.GroupDetailsId equals t.GroupDetailsId
                                        select ld).ToList();
                    countryCode.LookUpDetailsRepository.RemoveRange(lstlookupdetails);
                    countryCode.LookupGroupDetailRepository.RemoveRange(lstlookupgroupdetail);
                    countryCode.LookUpGroupRepository.RemoveRange(lstlookupgroup);
                    countryCode.FormulaDefinitionDependencyDetailsRepository.RemoveRange(lstformuladefinition);
                    countryCode.FormulaRepository.RemoveRange(lstformula);
                    countryCode.VariableRepository.RemoveRange(lstvariable);
                    countryCode.TaxRepository.RemoveRange(lsttax);
                    countryCode.TaxVersionRepository.RemoveRange(lsttaxversion);
                    countryCode.TaxMasterRepository.RemoveRange(lsttaxmaster);
                    countryCode.MarketRepository.RemoveRange(lstmarket);
                    countryCode.CountryCodeRepository.RemoveRange(lstcountrycode);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }
        }
        #endregion
        #region Add Country Code
        /// <summary>
        /// Add new Country details to CountryCode
        /// </summary>
        /// <param name="countryCodeValue">a CountryCode Object, 
        /// that contains all the 
        /// data for adding</param>
        public void AddCountryCode(IEnumerable<CountryCode> countryCodeValue)
        {
            try
            {
                using (var countryCodeObj = new UnitofWork())
                {
                    foreach (var item in countryCodeValue)
                    {
                        if (countryCodeObj.CountryCodeRepository.Find(x =>x.CountryCode1 == item.CountryCode1).ToList().Count > 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("CountryCodeDuplicatemsg"));
                        }
                        else if (countryCodeObj.CountryCodeRepository.Find(x => x.CountryName ==item.CountryName).ToList().Count > 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("CountryNameDuplicatemsg"));
                        }
                    }
                    List<EF.CountryCode> lstcountrycode = new List<EF.CountryCode>();
                    foreach (var item in countryCodeValue)
                    {
                        lstcountrycode.Add(new EF.CountryCode()
                        {
                            CountryCodeId = item.CountryCodeId,
                            CountryCode1 = item.CountryCode1,
                            CountryName = item.CountryName,
                            CultureInfoDetails = item.CultureInfoDetails,
                            Descriptions = item.Descriptions,
                            IsActive = item.IsActive,
                            CreatedBy = item.CreatedBy,
                            CreatedOn = DateTime.UtcNow,
                            UpdatedBy = item.UpdatedBy,
                            UpdatedOn = DateTime.UtcNow
                        });
                    }
                    countryCodeObj.CountryCodeRepository.AddRange(lstcountrycode);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException( ex.Message);
            }
        } 
        #endregion
    }
    public class CountryCodeList
    {
        #region Country Code List Property
        [JsonProperty(PropertyName = "countryCodeId")]
        public int CountryCodeId { get; set; }
        [JsonProperty(PropertyName = "countryCode")]
        public string CountryCode1 { get; set; }
        [JsonProperty(PropertyName = "countryName")]
        public string CountryName { get; set; } 
        #endregion
    }
}