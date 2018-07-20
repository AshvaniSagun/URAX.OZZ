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
    public class TaxVersion
    {
        #region TaxVersion Property

        [JsonProperty(PropertyName = "taxVersionId")]
        public long TaxVersionId { get; set; }
        [JsonProperty(PropertyName = "taxMasterId")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "TaxMasterIdReq")]
        public long TaxMasterId { get; set; }
        [JsonProperty(PropertyName = "startDate")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "StartDateReq")]
        public DateTime StartDate { get; set; }
        [JsonProperty(PropertyName = "endDate")]
        public Nullable<System.DateTime> EndDate { get; set; }
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
        [JsonProperty(PropertyName = "taxVersionStatusId")]
        public int? TaxVersionStatusId { get; set; }
        [JsonProperty(PropertyName = "featureLevelTax")]
        public bool FeatureLevelTax { get; set; }
        #endregion

        #region     Get TaxVersion by TaxMaster Id
        /// <summary>
        /// To get TaxVersion by taxMaster Id
        /// </summary>
        /// <param name="TaxMasterId">An intger which represents TaxMaster Id</param>
        /// <returns>List of TaxVersionName</returns>
        internal List<TaxVersionName> GetTaxVersionByTaxMasterId(int TaxMasterId)
        {
            try
            {

                using (var taxversionobj = new UnitofWork())
                {
                    var lstTaxVersion = taxversionobj.TaxVersionRepository.Find(x => x.TaxMasterId == TaxMasterId).ToList();
                    var result = (from ld in taxversionobj.TaxMasterRepository.GetAll()
                                  join t in lstTaxVersion on ld.TaxMasterId equals t.TaxMasterId
                                  select new { ld.TaxName, t.TaxVersionId, t.StartDate, t.EndDate }).ToList();

                    List<TaxVersionName> lstVersion = new List<TaxVersionName>();
                    foreach (var data in result)
                    {
                        var strEndDate = data.EndDate.ToString() == "12/31/9999 12:00:00 AM" ? "" : DateTime.Parse(data.EndDate.ToString()).ToString("yyyy-MM-dd");
                        lstVersion.Add(new TaxVersionName()
                        {
                            TaxVersionId = (int)data.TaxVersionId,
                            VersionName = (string)data.TaxName + "-(" + data.StartDate.ToString("yyyy-MM-dd") + " TO " + strEndDate + ")"
                        });
                    }

                    return lstVersion;
                }

            }
            catch (Exception )
            {
                throw ;
            }

        }
        #endregion


        #region Get all TaxVersion Details 
        /// <summary>
        /// To get all TaxVersion Details
        /// </summary>
        /// <returns>List of TaxVersion Details</returns>
        public List<EF.TaxVersion> GetTaxVerionDetails()
        {
            try
            {
                using (var taxVersion = new UnitofWork())
                {
                    return taxVersion.TaxVersionRepository.GetAll().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }
        }
        #endregion

        #region Update TaxVersion Details
        /// <summary>
        /// To update TaxVerion Details
        /// </summary>
        /// <param name="taxVersionValue">List of TaxVersion Details to Update</param>
        /// <returns>List of Updated TaxVersion details</returns>
        public List<EF.TaxVersion> UpdateTaxVersion(IEnumerable<TaxVersion> taxVersionValue)
        {
            try
            {
                using (var taxVersion = new UnitofWork())
                {
                    foreach (var data in taxVersionValue)
                    {
                        int tVersionId = (int)data.TaxVersionId;


                        if (taxVersion.TaxVersionRepository.Find(x => x.TaxVersionId == tVersionId).ToList().Count == 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("CmnDataNotFound"));
                        }

                    }
                }

                List<EF.TaxVersion> lsttaxVersion = new List<EF.TaxVersion>();
                List<string> lstField = new List<string>();
                foreach (var value in taxVersionValue)
                {
                    lsttaxVersion.Add(new EF.TaxVersion()
                    {
                        TaxVersionId = value.TaxVersionId,
                        TaxMasterId = value.TaxMasterId,
                        StartDate = value.StartDate,
                        EndDate = value.EndDate,

                        IsActive = value.IsActive,
                        CreatedBy = value.CreatedBy,
                        CreatedOn = value.CreatedOn,
                        UpdatedBy = value.UpdatedBy,
                        UpdatedOn = DateTime.UtcNow


                    });
                }

                lstField.Add("TaxMasterId");
                lstField.Add("StartDate");
                lstField.Add("EndDate");
                lstField.Add("IsActive");              
                lstField.Add("UpdatedBy");
                lstField.Add("UpdatedOn");


                using (var taxVersionobj = new UnitofWork())
                {
                    taxVersionobj.TaxVersionRepository.UpdateRange(lsttaxVersion, lstField);
                }
                return lsttaxVersion;
            }


            catch (Exception ex)
            {

                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }
        }
        #endregion


        #region Add TaxVersion
        /// <summary>
        /// To Add Tax Version Details
        /// </summary>
        /// <param name="taxVersionValue">List of TaxVersion Details to add</param>
        public void AddTaxVersion(IEnumerable<TaxVersion> taxVersionValue)
        {

            try
            {
                using (var taxVersion = new UnitofWork())
                {
                    foreach (var item in taxVersionValue)
                    {
                        long taxVersionId = item.TaxVersionId;

                        if (taxVersion.TaxVersionRepository.Find(x => x.TaxVersionId == taxVersionId).ToList().Count > 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("TaxVersionDuplicatemsg"));
                        }
                    }
                    List<EF.TaxVersion> lsttaxVersion = new List<EF.TaxVersion>();
                    foreach (var item in taxVersionValue)
                    {
                        lsttaxVersion.Add(new EF.TaxVersion()
                        {
                            TaxVersionId = (int)item.TaxVersionId,
                            TaxMasterId = (int)item.TaxMasterId,
                            StartDate = item.StartDate,
                            EndDate = item.EndDate,
                            IsActive = true,
                            CreatedBy = item.CreatedBy,
                            CreatedOn = DateTime.UtcNow,
                            UpdatedBy = item.UpdatedBy,
                            UpdatedOn = DateTime.UtcNow
                        });
                    }

                    taxVersion.TaxVersionRepository.AddRange(lsttaxVersion);
                }

            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }




        }
        #endregion

        #region Get TaxVersion Details by TaxVersion Id
        /// <summary>
        /// To Get TaxVersion Details by TaxVersion Id
        /// </summary>
        /// <param name="id">An integer which represents TaxVersion Id</param>
        /// <returns>List of TaxVersion Details</returns>
        public  List<EF.TaxVersion> GetTaxVersion(int id)
        {
            try
            {
                using (var taxVersion = new UnitofWork())
                {
                    return taxVersion.TaxVersionRepository.Find(p => p.TaxVersionId == id).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }
        }
        #endregion


        #region     Delete TaxVersion
        /// <summary>
        /// To delete TaxVersion Details
        /// </summary>
        /// <param name="taxVersionId">An Integer which represents TaxVersionId</param>
        public void DeleteTaxVersion(int taxVersionId)
        {

            try
            {
                using (var taxVersion = new UnitofWork())
                {
                    List<EF.TaxVersion> lsttaxVersion  = taxVersion.TaxVersionRepository.Find(p => p.TaxVersionId == taxVersionId).ToList();
                    if (lsttaxVersion.Count == 0)
                    {
                        throw new InvalidOperationException(Resource.GetResxValueByName("CmnDataNotFound"));
                    }

                    taxVersion.TaxVersionRepository.RemoveRange(lsttaxVersion);

                }
            }

            catch (Exception ex)
            {
                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }

        } 
        #endregion

      

    }
    public class TaxVersionName
    {
        #region TaxVersionName Property

        [JsonProperty(PropertyName = "taxVersionId")]
        public long TaxVersionId { get; set; }
        [JsonProperty(PropertyName = "taxMasterId")]
        public long TaxMasterId { get; set; }
        [JsonProperty(PropertyName = "versionName")]
        public string VersionName { get; set; } 
        #endregion
    }
}