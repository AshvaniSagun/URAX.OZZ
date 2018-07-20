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
    public class Tax
    {
        #region Tax Property
        [JsonProperty(PropertyName = "taxId")]
        public long TaxId { get; set; }
        [JsonProperty(PropertyName = "taxVersionId")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "TaxVersionIdReq")]
        public long TaxVersionId { get; set; }
        [JsonProperty(PropertyName = "taxFlowId")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "TaxFlowIdReq")]
        public int TaxFlowId { get; set; }
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

        #region Get Tax by Version Id
        /// <summary>
        /// To get Tax Details by Id
        /// </summary>
        /// <param name="taxVersionId">An intger which represents Tax Version Id</param>
        /// <returns>List of TaxFlowName</returns>
        internal List<TaxFlowName> GetTaxByVersionId(int taxVersionId)
        {
            try
            {

                using (var taxobj = new UnitofWork())
                {
                    var lstTaxData = taxobj.TaxRepository.Find(x => x.TaxVersionId == taxVersionId).ToList<EF.Tax>();
                    var lstTaxFlow = taxobj.ParameterDetailsRepository.Find(x => x.ParameterGroupId == Helper.iTaxFlow).ToList<EF.ParameterDetail>();


                   
                var resultDistinct = (from ld in taxobj.TaxRepository.GetAll()
                                  join t in lstTaxData on ld.TaxVersionId equals t.TaxVersionId
                                  join tt in lstTaxFlow on ld.TaxFlowId equals tt.ParameterId
                                  select new { ld.TaxId, tt.Value }).Distinct().ToList();
                    List<TaxFlowName> lstTax = new List<TaxFlowName>();
                    foreach (var data in resultDistinct)
                    {
                        lstTax.Add(new TaxFlowName()
                        {
                            TaxId = (int)data.TaxId,
                            FlowName = data.Value

                        });
                    }

                    return lstTax;
                }

            }
            catch (Exception )
            {
                throw ;
            }
        }
        #endregion

        #region Get Tax Details by Tax Id
        /// <summary>
        /// To get Tax Details by Tax Id
        /// </summary>
        /// <param name="taxId">An long datatype value which represents TaxId</param>
        /// <returns>List of taxMaster Data</returns>
        internal List<TaxMasterData> GetTaxDetailsByTaxId(long taxId)
        {
            //  TaxName,
            //PriceBase,
            //VatRelation
            //VesrionStartDate
            //VersionEndDate
            List<TaxMasterData> lstTaxDetails = new List<TaxMasterData>();
            using (var taxobj = new UnitofWork())
            {
                var lstTax = taxobj.TaxRepository.Find(x => x.TaxId == taxId).ToList<EF.Tax>();
                var lstTaxFlow = taxobj.ParameterDetailsRepository.Find(x => x.ParameterGroupId == Helper.iTaxFlow).ToList<EF.ParameterDetail>();
                var lstTaxVersion = taxobj.TaxVersionRepository.GetAll().ToList<EF.TaxVersion>();

                var result = (from ld in taxobj.TaxMasterRepository.GetAll()
                              join ttt in lstTaxVersion on ld.TaxMasterId equals ttt.TaxMasterId
                              join t in lstTax on ttt.TaxVersionId equals t.TaxVersionId
                              join tt in lstTaxFlow on t.TaxFlowId equals tt.ParameterId
                              select new { t.TaxId, t.TaxVersionId, t.TaxFlowId, tt.Value, t.IsActive, t.CreatedBy, t.UpdatedBy, t.CreatedOn, t.UpdatedOn, ttt.StartDate, ttt.EndDate, ld.TaxMasterId, ld.MarketId, ld.TaxName, ld.TaxPositionId, ld.Priority, ttt.TaxVersionStatusId, ttt.FeatureLevelTax }).ToList();
                foreach (var data in result)
                {
                    lstTaxDetails.Add(new TaxMasterData()
                    {
                        IsActive = data.IsActive,
                        TaxFlowId = data.TaxFlowId,
                        TaxId = data.TaxId,
                        StartDate = Convert.ToDateTime(data.StartDate).ToString("yyyy-MM-dd"),
                        EndDate = Convert.ToDateTime(data.EndDate).ToString("yyyy-MM-dd") == Helper.sEndDateIfNull ? "" : Convert.ToDateTime(data.EndDate).ToString("yyyy-MM-dd"),
                        TaxMasterId = data.TaxMasterId,
                        TaxName = data.TaxName,
                        TaxPositionId = data.TaxPositionId,
                        TaxVersionId = data.TaxVersionId,
                        Priority = data.Priority,
                        MarketId = data.MarketId,
                        CreatedBy = data.CreatedBy,
                        CreatedOn = data.CreatedOn,
                        UpdatedBy = data.UpdatedBy,
                        UpdatedOn = data.UpdatedOn,
                        FeatureLevelTax = data.FeatureLevelTax,
                        TaxVersionStatusId = data.TaxVersionStatusId
                    });
                }
            }
            return lstTaxDetails;

        } 
        #endregion
    }

public class TaxFlowName
{
        #region TaxFlowName Property
        [JsonProperty(PropertyName = "taxId")]
        public int TaxId { get; set; }
        [JsonProperty(PropertyName = "flowName")]
        public string FlowName { get; set; } 
        #endregion
    }
}