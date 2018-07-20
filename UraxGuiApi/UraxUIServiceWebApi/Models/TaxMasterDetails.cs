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
     public class TaxMasterDetails
    {
        #region TaxMaster Details Property

        [JsonProperty(PropertyName = "taxMasterId")]
        public long TaxMasterId { get; set; }
        [JsonProperty(PropertyName = "taxVersionId")]
        public long TaxVersionId { get; set; }
        [JsonProperty(PropertyName = "taxId")]
        public long TaxId { get; set; }
        [JsonProperty(PropertyName = "marketId")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MarketIdReq")]
        public long MarketId { get; set; }
        [JsonProperty(PropertyName = "taxName")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "TaxNameReq")]
        public string TaxName { get; set; }
        [JsonProperty(PropertyName = "vatRelation")]
        public int? TaxPositionId { get; set; }
        [JsonProperty(PropertyName = "priority")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "PriorityReq")]
        public int Priority { get; set; }
        [JsonProperty(PropertyName = "priceBase")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "TaxFlowIdReq")]
        public int TaxFlowId { get; set; }
        [JsonProperty(PropertyName = "versionValidFrom")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "StartDateReq")]
        public System.DateTime StartDate { get; set; }
        [JsonProperty(PropertyName = "versionValidUpto")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "EndDateReq")]
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
    }
    public class TaxMasterData
    {
        #region TaxMaster Data Property

        [JsonProperty(PropertyName = "taxMasterId")]
        public long TaxMasterId { get; set; }
        [JsonProperty(PropertyName = "taxVersionId")]
        public long TaxVersionId { get; set; }
        [JsonProperty(PropertyName = "taxId")]
        public long TaxId { get; set; }
        [JsonProperty(PropertyName = "marketId")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MarketIdReq")]
        public long MarketId { get; set; }
        [JsonProperty(PropertyName = "taxName")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "TaxNameReq")]
        public string TaxName { get; set; }
        [JsonProperty(PropertyName = "vatRelation")]
        public int? TaxPositionId { get; set; }
        [JsonProperty(PropertyName = "priority")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "PriorityReq")]
        public int Priority { get; set; }
        [JsonProperty(PropertyName = "priceBase")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "TaxFlowIdReq")]
        public int TaxFlowId { get; set; }
        [JsonProperty(PropertyName = "versionValidFrom")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "StartDateReq")]
        [RegularExpression("^[0-9]{4}[-]{1}[0-9]{2}[-]{1}[0-9]{2}$", ErrorMessage = "'StartDate' date format is incorrect(YYYY-MM-DD)")]
        public string StartDate { get; set; }
        [JsonProperty(PropertyName = "versionValidUpto")]
       // [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "EndDateReq")]
        [RegularExpression("^[0-9]{4}[-]{1}[0-9]{2}[-]{1}[0-9]{2}$", ErrorMessage = "'EndDate' date format is incorrect(YYYY-MM-DD)")]
        public string EndDate { get; set; }
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
    }

    public class TaxVersionData
    {
        #region TaxMaster Data Property

        [JsonProperty(PropertyName = "taxMasterId")]
        public long TaxMasterId { get; set; }
        [JsonProperty(PropertyName = "taxVersionId")]
        public long TaxVersionId { get; set; }
        [JsonProperty(PropertyName = "taxId")]
        public long TaxId { get; set; }
        [JsonProperty(PropertyName = "marketId")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MarketIdReq")]
        public long MarketId { get; set; }
        [JsonProperty(PropertyName = "taxName")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "TaxNameReq")]
        public string TaxName { get; set; }
        [JsonProperty(PropertyName = "vatRelation")]
        public int? TaxPositionId { get; set; }
        [JsonProperty(PropertyName = "priority")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "PriorityReq")]
        public int Priority { get; set; }
        [JsonProperty(PropertyName = "priceBase")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "TaxFlowIdReq")]
        public int TaxFlowId { get; set; }
        [JsonProperty(PropertyName = "versionValidFrom")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "StartDateReq")]
        [RegularExpression("^[0-9]{4}[-]{1}[0-9]{2}[-]{1}[0-9]{2}$", ErrorMessage = "'StartDate' date format is incorrect(YYYY-MM-DD)")]
        public string StartDate { get; set; }
        [JsonProperty(PropertyName = "versionValidUpto")]
        // [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "EndDateReq")]
        [RegularExpression("^[0-9]{4}[-]{1}[0-9]{2}[-]{1}[0-9]{2}$", ErrorMessage = "'EndDate' date format is incorrect(YYYY-MM-DD)")]
        public string EndDate { get; set; }
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
    }
    public class TaxVersionDetail
    {
        #region TaxMaster Data Property

        [JsonProperty(PropertyName = "taxMasterId")]
        public long TaxMasterId { get; set; }
        [JsonProperty(PropertyName = "taxVersionId")]
        public long TaxVersionId { get; set; }
        [JsonProperty(PropertyName = "taxId")]
        public long TaxId { get; set; }
        [JsonProperty(PropertyName = "priceBase")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "TaxFlowIdReq")]
        public int TaxFlowId { get; set; }
        [JsonProperty(PropertyName = "versionValidFrom")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "StartDateReq")]
        [RegularExpression("^[0-9]{4}[-]{1}[0-9]{2}[-]{1}[0-9]{2}$", ErrorMessage = "'StartDate' date format is incorrect(YYYY-MM-DD)")]
        public string StartDate { get; set; }
        [JsonProperty(PropertyName = "versionValidUpto")]
        [RegularExpression("^[0-9]{4}[-]{1}[0-9]{2}[-]{1}[0-9]{2}$", ErrorMessage = "'EndDate' date format is incorrect(YYYY-MM-DD)")]
        public string EndDate { get; set; }
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
        public int TaxVersionStatusId { get; set; }
        [JsonProperty(PropertyName = "featureLevelTax")]
        public bool FeatureLevelTax { get; set; }

        #endregion
    }

    public class TaxVersionDetails
    {
        #region TaxMaster Details Property

        [JsonProperty(PropertyName = "taxMasterId")]
        public long TaxMasterId { get; set; }
        [JsonProperty(PropertyName = "taxVersionId")]
        public long TaxVersionId { get; set; }
        [JsonProperty(PropertyName = "taxId")]
        public long TaxId { get; set; }

        [JsonProperty(PropertyName = "priceBase")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "TaxFlowIdReq")]
        public int TaxFlowId { get; set; }
        [JsonProperty(PropertyName = "versionValidFrom")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "StartDateReq")]
        public System.DateTime StartDate { get; set; }
        [JsonProperty(PropertyName = "versionValidUpto")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "EndDateReq")]
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
        public int TaxVersionStatusId { get; set; }
        [JsonProperty(PropertyName = "featureLevelTax")]
        public bool FeatureLevelTax { get; set; }
        

        #endregion
    }
    public class TaxMasterDetailsList
    {
        #region TaxMasterDetailsList Property

        [JsonProperty(PropertyName = "taxId")]
        public long TaxId { get; set; }
        [JsonProperty(PropertyName = "taxName")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "TaxNameReq")]
        public string TaxName { get; set; } 
        #endregion
    }
}