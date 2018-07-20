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
    public class Language
    {
        #region Language Property
        [JsonProperty(PropertyName = "languageId")]
        public int LanguageId { get; set; }

        [JsonProperty(PropertyName = "countryCode")]
        public string CountryCode { get; set; }


        [JsonProperty(PropertyName = "languageName")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "LanguageNameReq")]

        public string LanguageName { get; set; }


        [JsonProperty(PropertyName = "languageCountryCode")]
        public string LanguageCountryCode { get; set; }


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


        #region Get All Language 
        /// <summary>
        /// Get All Language
        /// </summary>
        /// <returns>List of languge details</returns>
        public List<EF.Language> GetLanguage()
        {
            try
            {
                using (var language = new UnitofWork())
                {
                    return language.LanguagesRepository.GetAll().OrderBy(x=>x.Language1).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }
        }
        #endregion

        #region Update Language
        /// <summary>
        /// To Update Langugae
        /// </summary>
        /// <param name="languageValue">Langugae Details to update</param>
        /// <returns> Updated Language Details</returns>
        public List<EF.Language> UpdateLanguage(IEnumerable<Language> languageValue)
        {
            try
            {
                using (var language = new UnitofWork())
                {
                    foreach (var data in languageValue)
                    {
                        int lId = data.LanguageId;
                        string languageName = data.LanguageName;
                        if (language.LanguagesRepository.Find(x => x.LanguageId == lId).ToList().Count == 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("CmnDataNotFound"));
                        }
                        else if (language.LanguagesRepository.Find(x => x.LanguageId != lId && (x.Language1 == languageName)).ToList().Count > 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("LanguageDuplicatemsg"));
                        }
                    }
                }

                List<EF.Language> lstlanguage = new List<EF.Language>();
                List<string> lstField = new List<string>();
                foreach (var value in languageValue)
                {
                    lstlanguage.Add(new EF.Language()
                    {
                        LanguageId = value.LanguageId,
                        CountryCode = value.CountryCode,
                        Language1 = value.LanguageName.Trim(),
                        LanguageCountrycode = value.LanguageCountryCode,

                        IsActive = value.IsActive,
                        CreatedBy = value.CreatedBy,
                        CreatedOn = value.CreatedOn,
                        UpdatedBy = value.UpdatedBy,
                        UpdatedOn = DateTime.UtcNow
                    });
                }

                lstField.Add("LanguageName");
                lstField.Add("LanguageCountryCode");

                lstField.Add("IsActive");
                lstField.Add("UpdatedBy");
                lstField.Add("UpdatedOn");


                using (var languageobj = new UnitofWork())
                {
                    languageobj.LanguagesRepository.UpdateRange(lstlanguage, lstField);
                }
                return lstlanguage;
            }


            catch (Exception ex)
            {

                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }
        }

        #endregion

        #region Add Language
        /// <summary>
        /// To add language
        /// </summary>
        /// <param name="languageValue">Language Details to add</param>
        public void AddLanguage(IEnumerable<Language> languageValue)
        {

            try
            {
                using (var language = new UnitofWork())
                {
                    foreach (var item in languageValue)
                    {
                        string languageCountryCode = item.LanguageCountryCode;
                        string countryCode = item.CountryCode;
                        int languageId = item.LanguageId;
                        if (language.LanguagesRepository.Find(x => x.LanguageId == languageId || (x.LanguageCountrycode == languageCountryCode && x.CountryCode == countryCode)).ToList().Count > 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("LanguageDuplicatemsg"));
                        }
                    }
                    List<EF.Language> lstlanguage = new List<EF.Language>();
                    foreach (var item in languageValue)
                    {
                        lstlanguage.Add(new EF.Language()
                        {
                            LanguageId = item.LanguageId,
                            CountryCode = item.CountryCode,
                            Language1 = item.LanguageName,
                            LanguageCountrycode = item.LanguageCountryCode,


                            IsActive = item.IsActive,
                            CreatedBy = item.CreatedBy,
                            CreatedOn = DateTime.UtcNow,
                            UpdatedBy = item.UpdatedBy,
                            UpdatedOn = DateTime.UtcNow
                        });
                    }

                    language.LanguagesRepository.AddRange(lstlanguage);
                }

            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }




        }
        #endregion


        #region Delete Language
        /// <summary>
        /// Delete Language Details
        /// </summary>
        /// <param name="languageId">An integer which represents Language Id</param>
        public void DeleteLanguage(int languageId)
        {


            try
            {
                using (var language = new UnitofWork())
                {
                    List<EF.Language> lstlanguage = language.LanguagesRepository.Find(p => p.LanguageId == languageId).ToList();
                    if (lstlanguage.Count == 0)
                    {
                        throw new InvalidOperationException(Resource.GetResxValueByName("CmnDataNotFound"));
                    }
                    List<EF.TaxMaster> lsttaxmaster = new List<EF.TaxMaster>();



                    List<EF.TaxVersion> lsttaxversion = (from tv in language.TaxVersionRepository.GetAll()
                                     join tm in lsttaxmaster on tv.TaxMasterId equals tm.TaxMasterId
                                     select tv).ToList();
                    List<EF.Tax> lsttax =  (from t in language.TaxRepository.GetAll()
                              join tv in lsttaxversion on t.TaxVersionId equals tv.TaxVersionId
                              select t).ToList();
                    List<EF.Variable> lstvariable =  (from v in language.VariableRepository.GetAll()
                                   join t in lsttax on v.TaxId equals t.TaxId
                                   select v).ToList();

                    List<EF.Formula> lstformula = (from f in language.FormulaRepository.GetAll()
                                  join v in lstvariable on f.VariableId equals v.VariableId
                                  select f).ToList();
                    List<EF.FormulaDefinitionDependencyDetail> lstformuladefinition = (from fd in language.FormulaDefinitionDependencyDetailsRepository.GetAll()
                                            join v in lstvariable on fd.VariableId equals v.VariableId
                                            join f in lstformula on fd.FormulaId equals f.FormulaId
                                            select fd).ToList();
                    List<EF.LookUpGroup> lstlookupgroup = (from lg in language.LookUpGroupRepository.GetAll()
                                      join t in lsttax on lg.TaxId equals t.TaxId
                                      select lg).ToList();
                    List<EF.LookupGroupDetail> lstlookupgroupdetail = (from lgd in language.LookupGroupDetailRepository.GetAll()
                                            join v in lstvariable on lgd.VariableId equals v.VariableId
                                            join lg in lstlookupgroup on lgd.LookUpGroupId equals lg.LookUpGroupId
                                            select lgd).ToList();
                    List<EF.LookUpDetail> lstlookupdetails = (from ld in language.LookUpDetailsRepository.GetAll()
                                        join t in lstlookupgroupdetail on ld.GroupDetailsId equals t.GroupDetailsId
                                        select ld).ToList();



                    language.LookUpDetailsRepository.RemoveRange(lstlookupdetails);
                    language.LookupGroupDetailRepository.RemoveRange(lstlookupgroupdetail);
                    language.LookUpGroupRepository.RemoveRange(lstlookupgroup);
                    language.FormulaDefinitionDependencyDetailsRepository.RemoveRange(lstformuladefinition);
                    language.FormulaRepository.RemoveRange(lstformula);
                    language.VariableRepository.RemoveRange(lstvariable);
                    language.TaxRepository.RemoveRange(lsttax);
                    language.TaxVersionRepository.RemoveRange(lsttaxversion);
                    language.TaxMasterRepository.RemoveRange(lsttaxmaster);
                    language.LanguagesRepository.RemoveRange(lstlanguage);

                }
            }

            catch (Exception ex)
            {
                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }

        }


        #endregion

        #region Get Language by Id
        /// <summary>
        /// To Get language by Id
        /// </summary>
        /// <param name="id">An integer which represents Language Id</param>
        /// <returns>List of Languages</returns>
        public List<EF.Language> GetLanguage(int id)
        {
            try
            {
                using (var language = new UnitofWork())
                {
                    return language.LanguagesRepository.Find(p => p.LanguageId == id).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }
        } 
        #endregion


    }

    public class LanguageList
    {
        #region LanguageList Property
        [JsonProperty(PropertyName = "languageId")]
        public int LanguageId { get; set; }


        [JsonProperty(PropertyName = "language")]
        public string Language { get; set; } 
        #endregion
    }
}