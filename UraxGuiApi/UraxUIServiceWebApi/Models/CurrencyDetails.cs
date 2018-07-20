#region NameSpace
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
    public class CurrencyDetails
    {
        #region CurrencyDetails Property
        [JsonProperty(PropertyName = "currencyId")]
        public int CurrencyId { get; set; }
        [JsonProperty(PropertyName = "currencyCode")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "CurrencyCodeReq")]
        public string CurrencyCode { get; set; }
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
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        #endregion
        #region Get All Currency Details
        /// <summary>
        /// Get All Currency Details
        /// </summary>
        /// <returns>List Of Currency Details</returns>
        public List<EF.CurrencyDetail> GetCurrencyDetails()
        {
            try
            {
                using (var currencyDetails = new UnitofWork())
                {
                    return currencyDetails.CurrencyDetailsRepository.GetAll().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }
        }
        #endregion
        #region Get Currency Detail By Id
        /// <summary>
        /// Get Currency Details By Id
        /// </summary>
        /// <param name="id">An integer Value which represents Currency id</param>
        /// <returns>List Of Currency Details</returns>
        public List<EF.CurrencyDetail> GetCurrencyDetails(int id)
        {
            try
            {
                using (var currencyDetails = new UnitofWork())
                {
                    return currencyDetails.CurrencyDetailsRepository.Find(p => p.CurrencyId == id).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }
        }
        #endregion
        #region Delete Currency Details
        /// <summary>
        /// Delete Currency Details
        /// </summary>
        /// <param name="currencyDetailsId">An Integer Which represents Currency Details Id</param>
        public void DeleteCurrencyDetails(int currencyDetailsId)
        {
            try
            {
                using (var currencyDetails = new UnitofWork())
                {
                    List<EF.CurrencyDetail> lstcurrencydetails = currencyDetails.CurrencyDetailsRepository.Find(x => x.CurrencyId == currencyDetailsId).ToList();
                    if (lstcurrencydetails.Count == 0)
                    {
                        throw new InvalidOperationException(Resource.GetResxValueByName("CmnDataNotFound"));
                    }
                    List<EF.Market> lstmarket = currencyDetails.MarketRepository.Find(x => x.currencyId == currencyDetailsId).ToList();
                    List<EF.TaxMaster> lsttaxmaster = (from tm in currencyDetails.TaxMasterRepository.GetAll()
                                    join m in lstmarket on tm.MarketId equals m.MarketId
                                    select tm).ToList();
                    List<EF.TaxVersion> lsttaxversion = (from tv in currencyDetails.TaxVersionRepository.GetAll()
                                     join tm in lsttaxmaster on tv.TaxMasterId equals tm.TaxMasterId
                                     select tv).ToList();
                    List<EF.Tax> lsttax = (from t in currencyDetails.TaxRepository.GetAll()
                              join tv in lsttaxversion on t.TaxVersionId equals tv.TaxVersionId
                              select t).ToList();
                    List<EF.Variable> lstvariable = (from v in currencyDetails.VariableRepository.GetAll()
                                   join t in lsttax on v.TaxId equals t.TaxId
                                   select v).ToList();
                    List<EF.Formula> lstformula = (from f in currencyDetails.FormulaRepository.GetAll()
                                  join v in lstvariable on f.VariableId equals v.VariableId
                                  select f).ToList();
                    List<EF.FormulaDefinitionDependencyDetail> lstformuladefinition = (from fd in currencyDetails.FormulaDefinitionDependencyDetailsRepository.GetAll()
                                            join v in lstvariable on fd.VariableId equals v.VariableId
                                            join f in lstformula on fd.FormulaId equals f.FormulaId
                                            select fd).ToList();
                    List<EF.LookUpGroup> lstlookupgroup = (from lg in currencyDetails.LookUpGroupRepository.GetAll()
                                      join t in lsttax on lg.TaxId equals t.TaxId
                                      select lg).ToList();
                    List<EF.LookupGroupDetail> lstlookupgroupdetail = (from lgd in currencyDetails.LookupGroupDetailRepository.GetAll()
                                            join v in lstvariable on lgd.VariableId equals v.VariableId
                                            join lg in lstlookupgroup on lgd.LookUpGroupId equals lg.LookUpGroupId
                                            select lgd).ToList();
                    List<EF.LookUpDetail> lstlookupdetails = (from ld in currencyDetails.LookUpDetailsRepository.GetAll()
                                        join t in lstlookupgroupdetail on ld.GroupDetailsId equals t.GroupDetailsId
                                        select ld).ToList();
                    currencyDetails.LookUpDetailsRepository.RemoveRange(lstlookupdetails);
                    currencyDetails.LookupGroupDetailRepository.RemoveRange(lstlookupgroupdetail);
                    currencyDetails.LookUpGroupRepository.RemoveRange(lstlookupgroup);
                    currencyDetails.FormulaDefinitionDependencyDetailsRepository.RemoveRange(lstformuladefinition);
                    currencyDetails.FormulaRepository.RemoveRange(lstformula);
                    currencyDetails.VariableRepository.RemoveRange(lstvariable);
                    currencyDetails.TaxRepository.RemoveRange(lsttax);
                    currencyDetails.TaxVersionRepository.RemoveRange(lsttaxversion);
                    currencyDetails.TaxMasterRepository.RemoveRange(lsttaxmaster);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }
        }
        #endregion
        #region Add Currency Details
        /// <summary>
        /// Add Currency Details
        /// </summary>
        /// <param name="currencydetailsValue"> Currency Details to add</param>
        public void AddCurrencyDetails(IEnumerable<CurrencyDetails> currencydetailsValue)
        {
            try
            {
                using (var currencyDetails = new UnitofWork())
                {
                    foreach (var item in currencydetailsValue)
                    {
                        if(currencyDetails.CurrencyDetailsRepository.Find(x => x.CurrencyCode == item.CurrencyCode).ToList().Count > 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("CurrencyCodeDuplicatemsg"));
                        }
                    }
                    List<EF.CurrencyDetail> lstcurrencydetails = new List<EF.CurrencyDetail>();
                    foreach (var item in currencydetailsValue)
                    {
                        lstcurrencydetails.Add(new EF.CurrencyDetail()
                        {
                            CurrencyId = item.CurrencyId,
                            CurrencyCode = item.CurrencyCode,
                            Descriptions = item.Descriptions,
                            IsActive = item.IsActive,
                            CreatedBy = item.CreatedBy,
                            CreatedOn = DateTime.UtcNow,
                            UpdatedBy = item.UpdatedBy,
                            UpdatedOn = DateTime.UtcNow
                        });
                        currencyDetails.CurrencyDetailsRepository.AddRange(lstcurrencydetails);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }
        }
        #endregion
        #region Update Currency Details
        /// <summary>
        /// Update Currency Details
        /// </summary>
        /// <param name="currencyDetailsValue">Currency details to update </param>
        /// <returns>Returns Updated Currency Details</returns>
        public List<EF.CurrencyDetail> UpdateCurrency(IEnumerable<CurrencyDetails> currencyDetailsValue)
        {
            try
            {
                using (var currencydetails = new UnitofWork())
                {
                    foreach (var data in currencyDetailsValue)
                    {
                        if (currencydetails.CurrencyDetailsRepository.Find(x => x.CurrencyId!=data.CurrencyId&&(x.CurrencyCode==data.CurrencyCode)).ToList().Count>0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("CurrencyCodeDuplicatemsg"));
                        }
                    }
                }
                List<EF.CurrencyDetail> lstcurrencyDetails = new List<EF.CurrencyDetail>();
                List<string> lstField = new List<string>();
                foreach (var item in currencyDetailsValue)
                {
                    lstcurrencyDetails.Add(new EF.CurrencyDetail()
                    {
                        CurrencyCode = item.CurrencyCode,
                        Descriptions = item.Descriptions,
                        IsActive = item.IsActive,
                        UpdatedBy = item.UpdatedBy,
                        UpdatedOn = DateTime.UtcNow
                    });
                }
                lstField.Add("CurrencyCode");
                lstField.Add("Descriptions");
                lstField.Add("IsActive");
                lstField.Add("UpdatedBy");
                lstField.Add("UpdatedOn");
                using (var currencydetailsobj = new UnitofWork())
                {
                    currencydetailsobj.CurrencyDetailsRepository.UpdateRange(lstcurrencyDetails, lstField);
                }
                return lstcurrencyDetails;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }
        } 
        #endregion
    }
    public class CurrencyDetailsList
    {
        #region CurrencyDetailsList Property
        [JsonProperty(PropertyName = "currencyId")]
        public int CurrencyId { get; set; }
        [JsonProperty(PropertyName = "currencyCode")]
        public string CurrencyCode { get; set; } 
        #endregion
    }
}