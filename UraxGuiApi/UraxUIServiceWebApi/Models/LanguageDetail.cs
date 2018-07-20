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
    public class LanguageDetail
    {
        #region LanguageDetail Property
        [JsonProperty(PropertyName = "languageDetailid")]

        public int LanguageDetailId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "TaxMasterIdReq")]
        [JsonProperty(PropertyName = "taxMasterId")]
        public long TaxMasterId { get; set; }


        [JsonProperty(PropertyName = "languageId")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "LanguageIdReq")]
        public int LanguageId { get; set; }

        [JsonProperty(PropertyName = "languageName")]
        public string LanguageName { get; set; }

        [JsonProperty(PropertyName = "taxName")]

        public string TaxName { get; set; }


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
        [JsonProperty(PropertyName = "isDefault")]
        public bool IsDefault { get; set; }
        #endregion

        #region Get All Language Details
        /// <summary>
        /// Get all Language Details
        /// </summary>
        /// <returns>List of Language Details</returns>
        public List<EF.LanguageDetail> GetLanguageDetails()
        {
            try
            {
                using (var languageDetails = new UnitofWork())
                {
                    return languageDetails.LanguageDetailsRepository.GetAll().OrderBy(x=>x.TaxName).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }
        }
        #endregion


        #region Get Language Details with language name
        /// <summary>
        /// To get Language Details with language Name
        /// </summary>
        /// <returns>List of Language Details</returns>
        public List<LanguageDetail> GetLanguageDetailWithLanguageName()
        {
            List<LanguageDetail> lstLanguageDetail = new List<LanguageDetail>();
            try
            {



                using (var languagedetails = new UnitofWork())
                {
                    var lstLanuages = languagedetails.LanguagesRepository.GetAll();

                    var result1 = (from ld in languagedetails.LanguageDetailsRepository.GetAll()
                                   join l in lstLanuages on ld.LanguageId equals l.LanguageId


                                   select new { ld.LanguageDetailsId, ld.TaxMasterId, ld.LanguageId, ld.TaxName,ld.IsDefault,
                                   ld.IsActive, ld.CreatedBy, ld.CreatedOn, ld.UpdatedBy, ld.UpdatedOn, l.Language1 }).ToList();


                    foreach (var value in result1)
                    {
                        lstLanguageDetail.Add(new LanguageDetail()
                        {
                            LanguageDetailId = (int)value.LanguageDetailsId,
                            TaxMasterId = (int)value.TaxMasterId,
                            LanguageId = (int)value.LanguageId,
                            TaxName = value.TaxName,
                            IsActive = value.IsActive,
                            CreatedBy = value.CreatedBy,
                            CreatedOn = value.CreatedOn,
                            UpdatedBy = value.UpdatedBy,
                            UpdatedOn = value.UpdatedOn,
                            LanguageName = value.Language1,
                            IsDefault=value.IsDefault


                        });
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return lstLanguageDetail;
        }
        #endregion

        #region Update Language Details
        /// <summary>
        /// To update Language Details
        /// </summary>
        /// <param name="languageDetailsValue">Language Details to update</param>
        /// <returns>List of Language Details</returns>
        public List<EF.LanguageDetail> UpdateLanguageDetails(IEnumerable<LanguageDetail> languageDetailsValue)
        {
            try
            {
                using (var languageDetails = new UnitofWork())
                {
                    foreach (var data in languageDetailsValue)
                    {
                        int lDetailsId = data.LanguageDetailId;
                        long taxMasterId = data.TaxMasterId;
                        int languageId = data.LanguageId;
                        if (languageDetails.LanguageDetailsRepository.Find(x => x.LanguageDetailsId == lDetailsId).ToList().Count == 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("CmnDataNotFound"));
                        }
                        else if (languageDetails.LanguageDetailsRepository.Find(x => x.LanguageDetailsId != lDetailsId && (x.TaxMasterId == taxMasterId && x.LanguageId == languageId)).ToList().Count > 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("LanguageDuplicatemsg"));
                        }
                        else if (languageDetails.LanguagesRepository.Find(x => x.LanguageId == data.LanguageId).ToList().Count == 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("InvalidLangIdmsg"));
                        }
                        else if (languageDetails.TaxMasterRepository.Find(x => x.TaxMasterId == data.TaxMasterId).ToList().Count == 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("InvalidTaxMasterIdmsg"));
                        }
                        else if (languageDetails.LanguageDetailsRepository.Find(x => x.TaxMasterId == data.TaxMasterId && x.IsActive == true&&x.LanguageDetailsId!=data.LanguageDetailId&&data.IsActive==true).ToList().Count > 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("illegalDefaultmsg"));

                        }
                    }
                }

                List<EF.LanguageDetail> lstlanguageDetails = new List<EF.LanguageDetail>();
                List<string> lstField = new List<string>() { "TaxMasterId", "LanguageId", "TaxName", "IsDefault", "IsActive", "CreatedBy", "UpdatedBy", "UpdatedOn" };
                foreach (var value in languageDetailsValue)
                {
                    lstlanguageDetails.Add(new EF.LanguageDetail()
                    {
                        LanguageDetailsId = value.LanguageDetailId,
                        TaxMasterId = value.TaxMasterId,
                        TaxName = value.TaxName.Trim(),
                        LanguageId = value.LanguageId,
                        IsDefault=value.IsDefault,
                        IsActive = value.IsActive,
                        CreatedBy = value.CreatedBy,
                        CreatedOn = value.CreatedOn,
                        UpdatedBy = value.UpdatedBy,
                        UpdatedOn = DateTime.UtcNow
                    });
                }

              


                using (var languageDetailsobj = new UnitofWork())
                {
                    languageDetailsobj.LanguageDetailsRepository.UpdateRange(lstlanguageDetails, lstField);
                }
                return lstlanguageDetails;
            }


            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }
        }
        #endregion

        #region Add Language Details
        /// <summary>
        /// To add Langugae Details
        /// </summary>
        /// <param name="languageDetailsValue">Language Details to add</param>
        public List<LanguageDetail> AddLanguageDetails(IEnumerable<LanguageDetail> languageDetailsValue)
        {

            try
            {
                using (var languageDetails = new UnitofWork())
                {
                    foreach (var item in languageDetailsValue)
                    {
                        long taxMasterId = item.TaxMasterId;
                        int languageId = item.LanguageId;
                        if (languageDetails.LanguageDetailsRepository.Find(x => x.LanguageId == languageId && x.TaxMasterId == taxMasterId).ToList().Count > 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("LanguageDuplicatemsg"));
                        }else if (languageDetails.LanguagesRepository.Find(x=>x.LanguageId==item.LanguageId).ToList().Count==0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("InvalidLangIdmsg"));
                        }else if (languageDetails.TaxMasterRepository.Find(x=>x.TaxMasterId==item.TaxMasterId).ToList().Count==0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("InvalidTaxMasterIdmsg"));
                        }
                        else if (languageDetails.LanguageDetailsRepository.Find(x =>x.TaxMasterId==item.TaxMasterId&&x.IsActive==true&&item.IsActive==true).ToList().Count > 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("illegalDefaultmsg"));

                        }
                    }
                    List<EF.LanguageDetail> lstlanguageDetails = new List<EF.LanguageDetail>();
                    foreach (var item in languageDetailsValue)
                    {
                        lstlanguageDetails.Add(new EF.LanguageDetail()
                        {
                            LanguageDetailsId = item.LanguageDetailId,
                            LanguageId = item.LanguageId,
                            TaxMasterId = item.TaxMasterId,
                            TaxName = item.TaxName,
                            IsActive = item.IsActive,
                            IsDefault=item.IsDefault,
                            CreatedBy = item.CreatedBy,
                            CreatedOn = DateTime.UtcNow,
                            UpdatedBy = item.UpdatedBy,
                            UpdatedOn = DateTime.UtcNow
                        });
                    }

                    languageDetails.LanguageDetailsRepository.AddRange(lstlanguageDetails);

                    List<LanguageDetail> lstLanguageDetail1 = new List<LanguageDetail>();

                    using (var lstlanguageDetailsResponse = new UnitofWork())
                    {
                        foreach (var data in lstlanguageDetails)
                        {

                            int tmId = (int)data.TaxMasterId;


                            using (var languageDetails1 = new UnitofWork())
                            {


                                var lstLanguage = languageDetails.LanguagesRepository.GetAll();
                                var result = (from ld in languageDetails.LanguageDetailsRepository.Find(p => p.TaxMasterId == tmId).ToList()
                                              join t in lstLanguage on ld.LanguageId equals t.LanguageId


                                              select new { ld.LanguageId, ld.LanguageDetailsId,ld.IsDefault, ld.TaxMasterId, ld.TaxName, t.Language1, ld.IsActive, ld.CreatedBy, ld.CreatedOn, ld.UpdatedBy, ld.UpdatedOn }).ToList();

                                foreach (var param in result)
                                {
                                    lstLanguageDetail1.Add(new LanguageDetail()
                                    {
                                        LanguageDetailId = param.LanguageDetailsId,
                                        TaxMasterId = param.TaxMasterId,
                                        LanguageId = param.LanguageId,
                                        LanguageName = param.Language1,
                                        TaxName = param.TaxName,
                                        IsDefault=param.IsDefault,
                                        IsActive = param.IsActive,
                                        CreatedBy = param.CreatedBy,
                                        CreatedOn = param.CreatedOn,
                                        UpdatedBy = param.UpdatedBy,
                                        UpdatedOn = param.UpdatedOn
                                    });
                                }
                            }
                        }
                    }
                    return lstLanguageDetail1;

                }

            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }




        }
        #endregion

        #region Delete Langugae Details
        /// <summary>
        /// To delete Language details
        /// </summary>
        /// <param name="languageDetailsId">an integer which represents Language details Id</param>
        /// <returns>returns TaxId</returns>
        public void DeleteLanguageDetails(int languageDetailsId)
        {

            try
            {
                
                using (var languageDetails = new UnitofWork())
                {
                    List<EF.LanguageDetail> lstlanguageDetails = languageDetails.LanguageDetailsRepository.Find(p => p.LanguageDetailsId == languageDetailsId).ToList();
                    if (lstlanguageDetails.Count == 0)
                    {
                        throw new InvalidOperationException(Resource.GetResxValueByName("CmnDataNotFound"));
                    }
                  
                    languageDetails.LanguageDetailsRepository.RemoveRange(lstlanguageDetails);

                }
              
            }

            catch (Exception ex)
            {
                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }

        }
        #endregion


        #region Get Language Details by Id
        /// <summary>
        /// To get Language details by Id
        /// </summary>
        /// <param name="id">An integer which represents Language Details Id</param>
        /// <returns>List of language Details</returns>
        public List<EF.LanguageDetail> GetLanguageDetails(int id)
        {
            try
            {
                using (var languageDetails = new UnitofWork())
                {
                    return languageDetails.LanguageDetailsRepository.Find(p => p.LanguageDetailsId == id || (p.TaxMasterId == id)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }
        }
        #endregion



        #region Get Language Details By Tax Id
        /// <summary>
        /// To get Language Details by Tax Id
        /// </summary>
        /// <param name="TaxId">An integer which represents Tax Id</param>
        /// <returns>List of Language Details</returns>
        public List<LanguageDetail> GetLanguageDetailsByTaxId(int TaxId)
        {
            try
            {
                List<LanguageDetail> lstLanguageDetail = new List<LanguageDetail>();
                using (var languageDetails = new UnitofWork())
                {

                    var lstLanguage = languageDetails.LanguagesRepository.GetAll();
                    var result = (from  ld in languageDetails.LanguageDetailsRepository.Find(p => p.TaxMasterId == TaxId).ToList()
                                  join t in lstLanguage on ld.LanguageId equals t.LanguageId


                                  select new { ld.LanguageId, ld.LanguageDetailsId, ld.TaxMasterId,ld.IsDefault, ld.TaxName, t.Language1, ld.IsActive, ld.CreatedBy, ld.CreatedOn, ld.UpdatedBy, ld.UpdatedOn }).OrderBy(x=>x.Language1).ToList();

                    foreach (var param in result)
                    {
                        lstLanguageDetail.Add(new LanguageDetail()
                        {
                            LanguageDetailId = param.LanguageDetailsId,
                            TaxMasterId = param.TaxMasterId,
                            LanguageId = param.LanguageId,
                            LanguageName = param.Language1,
                            TaxName = param.TaxName,
                            IsDefault=param.IsDefault,
                            IsActive = param.IsActive,
                            CreatedBy = param.CreatedBy,
                            CreatedOn = param.CreatedOn,
                            UpdatedBy = param.UpdatedBy,
                            UpdatedOn = param.UpdatedOn
                        });
                    }
                }
                return lstLanguageDetail;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException( ex.Message);
            }
        } 
        #endregion
    }

    public class LanguageDetailList
    {
        #region LanguageDetailList Property
        [JsonProperty(PropertyName = "languageDetailsId")]
        public int LanguageDetailsId { get; set; }

        [JsonProperty(PropertyName = "languageName")]
        public string LanguageName { get; set; }



        [JsonProperty(PropertyName = "taxName")]
        public string TaxName { get; set; } 
        #endregion
    }
}