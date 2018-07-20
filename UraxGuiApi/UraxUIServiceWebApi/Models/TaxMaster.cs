#region NameSpace
using System;
using System.Data.SqlTypes;
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
using System.Transactions;
using System.Globalization;
#endregion

namespace UraxUIServiceWebApi.Models
{
   public class TaxMaster
    {

        #region TaxMaster Property

        [JsonProperty(PropertyName = "taxMasterId")]
        public long TaxMasterId { get; set; }
        [JsonProperty(PropertyName = "marketId")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MarketIdReq")]
        public long MarketId { get; set; }
        [JsonProperty(PropertyName = "taxName")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "TaxNameReq")]
        [MaxLength(200)]
        public string TaxName { get; set; }
        [JsonProperty(PropertyName = "taxPositionId")]
        public int? TaxPositionId { get; set; }
        [JsonProperty(PropertyName = "priority")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "PriorityReq")]
        public int Priority { get; set; }
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


        #region Get all TaxMaster Details
        /// <summary>
        /// Toget All TaxMaster Details
        /// </summary>
        /// <returns>List of TaxMaster Details</returns>
        public List<EF.TaxMaster> GetTaxMaster()
        {
            try
            {
                using (var taxMaster = new UnitofWork())
                {
                    return taxMaster.TaxMasterRepository.GetAll().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        #endregion

        #region Get TaxMaster Details by Id
        /// <summary>
        /// To get TaxMaster Details by Tax Id
        /// </summary>
        /// <param name="Id">List of long datatype values which represents Tax Id</param>
        /// <returns>List of Tax Version Ids</returns>
        public List<long> GetTaxMasterDetails(List<long> Id)
        {
            try
            {
                List<long> lstTaxVersionId = new List<long>();
                using (var taxDetail = new UnitofWork())
                {
                    foreach (var item in Id)
                    {
                        var tax = taxDetail.TaxRepository.Find(x => x.TaxId == item).FirstOrDefault();
                        long taxversionId = tax.TaxVersionId;
                        lstTaxVersionId.Add(taxversionId);
                    }
                    return lstTaxVersionId;
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        internal object GetDrpList(int marketId, string loginUser, int taxMasterId=0,int taxVersionId =0 )
        {
           
                throw new NotImplementedException();
        }
        #endregion

        #region Get Tax Name Details by TaxVersionId
        /// <summary>
        /// To get TaxName Details by Tax version Id
        /// </summary>
        /// <param name="Id">List of long datatype An intger which represents TaxVersion Ids</param>
        /// <returns>List of strings An intger which represents TaxNames</returns>
        public List<string> GetTaxNameDetails(List<long> Id)
        {
            try
            {
                List<long> lstTaxMasterId = new List<long>();
                List<string> lstTaxName = new List<string>();
                using (var taxMasterDetail = new UnitofWork())
                {
                    foreach (var item in Id)
                    {
                        var taxVersion = taxMasterDetail.TaxVersionRepository.Find(x => x.TaxVersionId == item).FirstOrDefault();

                        long taxMasterId = taxVersion.TaxMasterId;
                        lstTaxMasterId.Add(taxMasterId);
                    }
                    foreach (var param in lstTaxMasterId)
                    {
                        var taxmaster = taxMasterDetail.TaxMasterRepository.Find(x => x.TaxMasterId == param).FirstOrDefault();

                        string taxName = taxmaster.TaxName;
                        lstTaxName.Add(taxName);
                    }

                    return lstTaxName;
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        #endregion

        #region Get taxMaster by Id
        /// <summary>
        /// To get TaxMaster by TaxMaster Id
        /// </summary>
        /// <param name="id">An intger which represents TaxMaster Id</param>
        /// <returns>List of TaxMaster Details</returns>
        public List<EF.TaxMaster> GetTaxMaster(int id)
        {
            try
            {
                using (var taxMaster = new UnitofWork())
                {
                    return taxMaster.TaxMasterRepository.Find(p => p.TaxMasterId == id).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        #endregion

        #region Get TaxMaster Details by MarketId
        /// <summary>
        /// To get TaxMaster Details by Market Id
        /// </summary>
        /// <param name="Id">long datatype which represents Market Id</param>
        /// <returns>List of TaxMaster Details</returns>
        public List<EF.TaxMaster> GetTaxMasterByMarketId(long Id)
        {
            try
            {

                using (var taxmasterobj = new UnitofWork())
                {
                    return taxmasterobj.TaxMasterRepository.Find(x => x.MarketId == Id).ToList();
                }

            }
            catch (Exception )
            {
                throw ;
            }


        }
        #endregion

        #region Add TaxMaster Details
        /// <summary>
        /// To Add TaxMaster Details
        /// </summary>
        /// <param name="taxMasterDetailsData">List of TaxMAster Details to add</param>
        /// <returns>List of long datatypes which represents added Tax Ids</returns>
        public TaxMaster AddTaxMasterDetails(IEnumerable<TaxMasterData> taxMasterDetailsData)
        {
            try
            {

                List<TaxMaster> lsttaxmaster = new List<TaxMaster>();
                List<TaxMasterDetails> taxMasterDetailsValue = new List<TaxMasterDetails>();
                using (TransactionScope scope = new TransactionScope())
                {

                    foreach (var data in taxMasterDetailsData)
                    {
                        if ((data.TaxFlowId != Helper.iMSRPFlow) && (data.TaxFlowId != Helper.iPRETAXFlow))
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("InvalidTaxFlowIdmsg"));
                        }
                        else
                        if (!(data.TaxPositionId < Helper.iTaxPositionCount))
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("InvalidTaxPositionmsg"));
                        }
                        else if ((data.EndDate != "")&& (Convert.ToDateTime(data.StartDate) > Convert.ToDateTime(data.EndDate)))
                        {
                               throw new InvalidOperationException(Resource.GetResxValueByName("InvalidEndStartCombmsg"));
                           
                            
                        }
                       

                        using (var taxmObj = new UnitofWork())
                        {
                            var lstTaxMaster = taxmObj.TaxMasterRepository.Find(x => x.MarketId == data.MarketId).ToList();
                            var lstVariableNames = (from v in taxmObj.VariableRepository.GetAll()
                                                    join t in taxmObj.TaxRepository.GetAll() on v.TaxId equals t.TaxId
                                                    join tv in taxmObj.TaxVersionRepository.GetAll() on t.TaxVersionId equals tv.TaxVersionId
                                                    join tm in lstTaxMaster on tv.TaxMasterId equals tm.TaxMasterId
                                                    select v.VariableName.Trim()).ToList();
                            if (lstVariableNames.Contains(data.TaxName.Trim()))
                            {
                                throw new InvalidOperationException(Resource.GetResxValueByName("InvalidTaxNamemsg"));

                            }
                            if (taxmObj.TaxMasterRepository.Find(x => x.TaxName == data.TaxName && x.MarketId == data.MarketId).ToList().Count > 0)
                            {
                                throw new InvalidOperationException(Resource.GetResxValueByName("DuplicateTaxNamemsg"));

                            }
                        }



                        taxMasterDetailsValue.Add(new TaxMasterDetails()
                        {
                            TaxMasterId = data.TaxMasterId,
                            MarketId = data.MarketId,
                            TaxName = data.TaxName.Trim(),
                            TaxPositionId = data.TaxPositionId,
                            Priority = data.Priority,
                            StartDate = Convert.ToDateTime(data.StartDate),
                            EndDate = Convert.ToDateTime(data.EndDate == "" ? Helper.sEndDateIfNull : data.EndDate),
                            TaxFlowId = data.TaxFlowId,
                            IsActive = data.IsActive,
                            CreatedBy = data.CreatedBy,
                            CreatedOn = DateTime.UtcNow,
                            UpdatedBy = data.UpdatedBy,
                            UpdatedOn = DateTime.UtcNow,
                            FeatureLevelTax = data.FeatureLevelTax,
                            TaxVersionStatusId = data.TaxVersionStatusId
                        });
                    }

                    using (var taxMasterDetails = new UnitofWork())
                    {
                        List<TaxVersion> lsttaxversion = new List<TaxVersion>();
                        List<Tax> lsttax = new List<Tax>();
                        foreach (var item in taxMasterDetailsValue)
                        {
                            lsttaxmaster.Add(new TaxMaster()
                            {
                                TaxMasterId = item.TaxMasterId,
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
                        AddTaxMaster(lsttaxmaster);

                        var lstTaxMasterId = (from fd in taxMasterDetails.TaxMasterRepository.GetAll()
                                              join v in lsttaxmaster on new { fd.MarketId, fd.TaxName, fd.TaxPositionId } equals new { v.MarketId, v.TaxName, v.TaxPositionId }
                                              select new { fd.TaxMasterId }).ToList();
                        int i = 0;
                        foreach (var item in taxMasterDetailsValue)
                        {
                            lsttaxversion.Add(new TaxVersion()
                            {
                                TaxMasterId = lstTaxMasterId[i].TaxMasterId,
                                StartDate = item.StartDate,
                                EndDate = item.EndDate,
                                IsActive = item.IsActive,
                                CreatedBy = item.CreatedBy,
                                CreatedOn = item.CreatedOn,
                                UpdatedBy = item.UpdatedBy,
                                UpdatedOn = item.UpdatedOn,
                                FeatureLevelTax = item.FeatureLevelTax,
                                TaxVersionStatusId = item.TaxVersionStatusId

                            });
                            i++;
                        }
                        AddTaxVersion(lsttaxversion);
                        var lstTaxVersionId = (from tv in taxMasterDetails.TaxVersionRepository.GetAll()
                                               join v in lsttaxversion on new { tv.TaxMasterId, tv.StartDate, tv.EndDate } equals new { v.TaxMasterId, v.StartDate, v.EndDate }
                                               select new { tv.TaxVersionId, tv.TaxMasterId }).First();

                        foreach (var item in taxMasterDetailsValue)
                        {

                            lsttax.Add(new Tax()
                            {

                                TaxVersionId = lstTaxVersionId.TaxVersionId,
                                TaxFlowId = item.TaxFlowId,
                                IsActive = item.IsActive,
                                CreatedBy = item.CreatedBy,
                                CreatedOn = item.CreatedOn,
                                UpdatedBy = item.UpdatedBy,
                                UpdatedOn = item.UpdatedOn
                            });

                        }
                        AddTax(lsttax);

                    }
                    scope.Complete();
                }
                using (var taxmasterResponse = new UnitofWork())
                {
                    long txId = (from fd in taxmasterResponse.TaxMasterRepository.GetAll()
                                 join v in lsttaxmaster on new { fd.MarketId, fd.TaxName, fd.TaxPositionId } equals new { v.MarketId, v.TaxName, v.TaxPositionId }
                                 select new { fd.TaxMasterId }).Select(x => x.TaxMasterId).FirstOrDefault();
                    EF.TaxMaster result = taxmasterResponse.TaxMasterRepository.Find(x => x.TaxMasterId == txId).FirstOrDefault();

                    TaxMaster taxMaster = new TaxMaster()
                    {
                        TaxMasterId = result.TaxMasterId,
                        TaxName = result.TaxName,
                        TaxPositionId = result.TaxPositionId,
                        Priority = result.Priority,
                        MarketId = result.MarketId,
                        IsActive = result.IsActive,
                        CreatedBy = result.CreatedBy,
                        CreatedOn = result.CreatedOn,
                        UpdatedBy = result.UpdatedBy,
                        UpdatedOn = result.UpdatedOn
                    };




                    return taxMaster;
                }




            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }

        }
        #endregion

        #region Update TaxMaster Details
        /// <summary>
        /// Update TaxMaster Details
        /// </summary>
        /// <param name="taxMasterDetailsData">Taxmaster Details Data to update</param>
        /// <returns>List of Updated Data</returns>
        public List<TaxData> UpdateTaxMasterDetails(IEnumerable<TaxMasterData> taxMasterDetailsData)
        {
            try
            {
                using (var taxMaster = new UnitofWork())
                {
                    foreach (var item in taxMasterDetailsData)
                    {
                        if (taxMaster.MarketRepository.Find(x => x.MarketId == item.MarketId).ToList().Count == 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("InvalidMarketIdmsg"));
                        }
                        else if(item.EndDate == "")
                        {
                            item.EndDate = Helper.sEndDateIfNull;
                        }

                        if (item.EndDate != "")
                        {
                            if (Convert.ToDateTime(item.StartDate) > Convert.ToDateTime(item.EndDate))
                            {
                                throw new InvalidOperationException(Resource.GetResxValueByName("InvalidEndStartCombmsg"));
                            }
                            else if (((Convert.ToDateTime(item.EndDate).Date)<DateTime.UtcNow.Date) &&(item.TaxVersionStatusId==31))
                            {
                                throw new InvalidOperationException(Resource.GetResxValueByName("RestrictedTaxVersionStatusIdmsg"));

                            }
                        }
                        else if ((item.TaxFlowId != Helper.iMSRPFlow) && (item.TaxFlowId != Helper.iPRETAXFlow))
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("InvalidTaxFlowIdmsg"));
                        }
                        else if (!(item.TaxPositionId < Helper.iTaxPositionCount))
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("InvalidTaxPositionmsg"));
                        }
                        using (var taxmObj = new UnitofWork())
                        {
                            var lstTaxMaster = taxmObj.TaxMasterRepository.Find(x => x.MarketId == item.MarketId).ToList();
                            var lstVariableNames = (from v in taxmObj.VariableRepository.GetAll()
                                                    join t in taxmObj.TaxRepository.GetAll() on v.TaxId equals t.TaxId
                                                    join tv in taxmObj.TaxVersionRepository.GetAll() on t.TaxVersionId equals tv.TaxVersionId
                                                    join tm in lstTaxMaster on tv.TaxMasterId equals tm.TaxMasterId
                                                    select v.VariableName.Trim()).ToList();
                            if (lstVariableNames.Contains(item.TaxName.Trim()))
                            {
                                throw new InvalidOperationException(Resource.GetResxValueByName("InvalidTaxNamemsg"));

                            }
                        }
                        var lsttaxVersionData = taxMaster.TaxVersionRepository.Find(x => x.TaxMasterId == item.TaxMasterId).ToList();
                        var updatingtaxversiondata = taxMaster.TaxVersionRepository.Find(x => x.TaxMasterId == item.TaxMasterId && x.TaxVersionId == item.TaxVersionId).FirstOrDefault();
                        if (lsttaxVersionData.Contains(updatingtaxversiondata))
                        {
                            lsttaxVersionData.Remove(updatingtaxversiondata);
                        }
                        var lsttaxMasterData = taxMaster.TaxMasterRepository.Find(x=>x.TaxMasterId!=item.TaxMasterId).ToList();
                        var updatingtaxmasterdata = taxMaster.TaxMasterRepository.Find(x => x.TaxMasterId == item.TaxMasterId).FirstOrDefault();
                        if (lsttaxMasterData.Contains(updatingtaxmasterdata))
                        {
                            lsttaxMasterData.Remove(updatingtaxmasterdata);
                        }
                        foreach (var param in lsttaxMasterData)
                        {
                            if (param.MarketId == item.MarketId && param.Priority == item.Priority)
                            {
                                throw new InvalidOperationException(Resource.GetResxValueByName("MarketIdPriorityCombDuplicatemsg"));
                            }
                        }
                        foreach (var data in lsttaxVersionData)
                        {

                            if (!((data.StartDate > Convert.ToDateTime(item.StartDate) && data.StartDate > Convert.ToDateTime(item.EndDate)) || (data.EndDate < Convert.ToDateTime(item.StartDate) && data.EndDate < Convert.ToDateTime(item.EndDate))))
                            {

                                throw new InvalidOperationException(Resource.GetResxValueByName("VersionConflictmsg"));
                            }

                        }
                    }
                }
                List<TaxMasterDetails> taxMasterDetailsValue = new List<TaxMasterDetails>();
                foreach (var data in taxMasterDetailsData)
                {
                    taxMasterDetailsValue.Add(new TaxMasterDetails()
                    {
                        TaxMasterId = data.TaxMasterId,
                        TaxVersionId = data.TaxVersionId,
                        TaxId = data.TaxId,
                        MarketId = data.MarketId,
                        TaxName = data.TaxName.Trim(),
                        TaxPositionId = data.TaxPositionId,
                        Priority = data.Priority,
                        StartDate = Convert.ToDateTime(data.StartDate),
                        EndDate = Convert.ToDateTime(data.EndDate == "" ? Helper.sEndDateIfNull : data.EndDate),
                        TaxFlowId = data.TaxFlowId,
                        IsActive = data.IsActive,
                        CreatedBy = data.CreatedBy,
                        CreatedOn = data.CreatedOn,
                        UpdatedBy = data.UpdatedBy,
                        UpdatedOn = DateTime.UtcNow,
                        FeatureLevelTax = data.FeatureLevelTax,
                        TaxVersionStatusId = data.TaxVersionStatusId

                    });
                }
                using (var taxMasterDetails = new UnitofWork())
                {
                    List<TaxMaster> lsttaxmaster = new List<TaxMaster>();
                    List<TaxVersion> lsttaxversion = new List<TaxVersion>();
                    List<Tax> lsttax = new List<Tax>();
                    foreach (var item in taxMasterDetailsValue)
                    {
                        lsttaxmaster.Add(new TaxMaster()
                        {
                            TaxMasterId = item.TaxMasterId,
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


                    foreach (var item in taxMasterDetailsValue)
                    {
                        lsttaxversion.Add(new TaxVersion()
                        {
                            TaxVersionId = item.TaxVersionId,
                            TaxMasterId = item.TaxMasterId,
                            StartDate = item.StartDate,
                            EndDate = item.EndDate,
                            IsActive = item.IsActive,
                            CreatedBy = item.CreatedBy,
                            CreatedOn = item.CreatedOn,
                            UpdatedBy = item.UpdatedBy,
                            UpdatedOn = item.UpdatedOn,
                            FeatureLevelTax = item.FeatureLevelTax,
                            TaxVersionStatusId = item.TaxVersionStatusId
                        });

                    }


                    foreach (var item in taxMasterDetailsValue)
                    {
                        lsttax.Add(new Tax()
                        {
                            TaxId = item.TaxId,
                            TaxVersionId = item.TaxVersionId,
                            TaxFlowId = item.TaxFlowId,
                            IsActive = item.IsActive,
                            CreatedBy = item.CreatedBy,
                            CreatedOn = item.CreatedOn,
                            UpdatedBy = item.UpdatedBy,
                            UpdatedOn = item.UpdatedOn
                        });

                    }
                    using (TransactionScope scope = new TransactionScope())
                    {
                        UpdateTax(lsttax);
                        UpdateTaxVersion(lsttaxversion);
                        UpdateTaxMaster(lsttaxmaster);
                        scope.Complete();
                    }
                    List<TaxData> lstUpdatedDetails = new List<TaxData>() { new TaxData() { ListTaxMaster=lsttaxmaster,ListTaxVersion= lsttaxversion,ListTax= lsttax } };
                    
                    return lstUpdatedDetails;



                }

            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }
        }
        #endregion

        #region Update Tax Details
        /// <summary>
        /// Update Tax Details
        /// </summary>
        /// <param name="taxValue">List of Tax details to update</param>
        /// <returns>List of updated Tax Details</returns>
        public List<EF.Tax> UpdateTax(IEnumerable<Tax> taxValue)
        {
            try
            {
                using (var tax = new UnitofWork())
                {
                    foreach (var item in taxValue)
                    {
                        long taxVersionId = item.TaxVersionId;
                        long taxId = item.TaxId;
                        if (tax.TaxRepository.Find(x => x.TaxVersionId == taxVersionId && x.TaxId == taxId).ToList().Count == 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("CmnDataNotFound"));

                        }
                        if ((item.TaxFlowId != Helper.iMSRPFlow) && (item.TaxFlowId != Helper.iPRETAXFlow))
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("InvalidTaxFlowIdmsg"));
                        }
                        if (tax.TaxRepository.Find(x => x.TaxVersionId == item.TaxVersionId && x.TaxFlowId == item.TaxFlowId&&x.TaxId!=item.TaxId).ToList().Count > 0)
                        {

                            throw new InvalidOperationException(Resource.GetResxValueByName("TaxFlowIdDuplicatemsg"));
                        }
                    }
                    

                        
                    
                }
                List<EF.Tax> lsttax = new List<EF.Tax>();
                List<string> lstField = new List<string>();
                foreach (var item in taxValue)
                {
                    lsttax.Add(new EF.Tax()
                    {
                        TaxId = item.TaxId,
                        TaxVersionId = item.TaxVersionId,
                        TaxFlowId = item.TaxFlowId,
                        IsActive = item.IsActive,
                        CreatedBy = item.CreatedBy,
                        CreatedOn = item.CreatedOn,
                        UpdatedBy = item.UpdatedBy,
                        UpdatedOn = DateTime.UtcNow
                    });
                }


                lstField.Add("TaxFlowId");
                lstField.Add("IsActive");
                lstField.Add("UpdatedBy");
                lstField.Add("UpdatedOn");
                using (var taxobj = new UnitofWork())
                {
                    taxobj.TaxRepository.UpdateRange(lsttax, lstField);
                }
                return lsttax;
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }
        }
        #endregion

        #region Update Tax Version 
        /// <summary>
        /// to Update Tax Version Details
        /// </summary>
        /// <param name="taxVersionValue">List of TaxVersion Details to update</param>
        /// <returns>List of updated TaxVersion Details</returns>
        public List<EF.TaxVersion> UpdateTaxVersion(IEnumerable<TaxVersion> taxVersionValue)
        {
            try
            {
                using (var taxversion = new UnitofWork())
                {
                    foreach (var item in taxVersionValue)
                    {
                        long taxVersionId = item.TaxVersionId;
                        long taxMatersId = item.TaxMasterId;
                        if (taxversion.TaxVersionRepository.Find(x => x.TaxVersionId == taxVersionId && x.TaxMasterId == taxMatersId).ToList().Count == 0)
                        {
                            List<EF.TaxVersion> returnNullLst = new List<EF.TaxVersion>();
                            return returnNullLst;
                        }
                        

                    }
                }
                List<EF.TaxVersion> lsttaxversion = new List<EF.TaxVersion>();
                List<string> lstField = new List<string>();
                foreach (var item in taxVersionValue)
                {
                    lsttaxversion.Add(new EF.TaxVersion()
                    {
                        TaxVersionId = item.TaxVersionId,
                        TaxMasterId = item.TaxMasterId,
                        StartDate = item.StartDate,
                        EndDate = item.EndDate,
                        IsActive = item.IsActive,
                        CreatedBy = item.CreatedBy,
                        CreatedOn = item.CreatedOn,
                        UpdatedBy = item.UpdatedBy,
                        UpdatedOn = DateTime.UtcNow,
                        FeatureLevelTax = item.FeatureLevelTax,
                        TaxVersionStatusId =(int)item.TaxVersionStatusId
                    });
                }

                lstField.Add("StartDate");
                lstField.Add("EndDate");
                lstField.Add("IsActive");
                lstField.Add("UpdatedBy");
                lstField.Add("UpdatedOn");
                lstField.Add("FeatureLevelTax");
                lstField.Add("TaxVersionStatusId");
                using (var taxversionobj = new UnitofWork())
                {
                    taxversionobj.TaxVersionRepository.UpdateRange(lsttaxversion, lstField);
                }
                return lsttaxversion;
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException( ex.Message);
            }
        }
        #endregion

        #region Update TaxMaster
        /// <summary>
        /// To update Tax Master
        /// </summary>
        /// <param name="taxMasterValue">List of TaxMaster data to update</param>
        /// <returns>List of  updated Taxmaster Data</returns>
        public List<EF.TaxMaster> UpdateTaxMaster(IEnumerable<TaxMaster> taxMasterValue)
        {
            try
            {
                using (var taxmaster = new UnitofWork())
                {
                    foreach (var item in taxMasterValue)
                    {
                        long taxMasterId = item.TaxMasterId;
                        long marketId = item.MarketId;

                        if (taxmaster.TaxMasterRepository.Find(x => x.TaxMasterId == taxMasterId).ToList().Count == 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("CmnDataNotFound"));
                        }
                        else if (taxmaster.TaxMasterRepository.Find(x => x.TaxMasterId != taxMasterId && (x.MarketId == marketId && x.TaxName ==item.TaxName)).ToList().Count > 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("TaxMasterDuplicatemsg"));
                        }
                    }
                }
                List<EF.TaxMaster> lsttaxmaster = new List<EF.TaxMaster>();
                List<string> lstField = new List<string>();
                foreach (var item in taxMasterValue)
                {
                    lsttaxmaster.Add(new EF.TaxMaster()
                    {
                        TaxMasterId = item.TaxMasterId,
                        MarketId = item.MarketId,
                        TaxName = item.TaxName,
                        TaxPositionId = item.TaxPositionId,
                        Priority = item.Priority,
                        IsActive = item.IsActive,
                        CreatedBy = item.CreatedBy,
                        CreatedOn = item.CreatedOn,
                        UpdatedBy = item.UpdatedBy,
                        UpdatedOn = DateTime.UtcNow
                    });
                }


                lstField.Add("TaxName");
                lstField.Add("TaxPositionId");
                lstField.Add("Priority");
                lstField.Add("IsActive");
                lstField.Add("UpdatedBy");
                lstField.Add("UpdatedOn");
                using (var taxmasterobj = new UnitofWork())
                {
                    taxmasterobj.TaxMasterRepository.UpdateRange(lsttaxmaster, lstField);
                }
                return lsttaxmaster;
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }
        }
        #endregion

        #region Delete TaxMaster 
        /// <summary>
        /// To Delete TaxMasterDetails
        /// </summary>
        /// <param name="taxMasterId">An intger which represents TaxMaster Id</param>
        public void DeletetaxMaster(int taxMasterId)
        {

            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    using (var taxMaster = new UnitofWork())
                    {
                        List<EF.TaxMaster> lsttaxmaster = new List<EF.TaxMaster>();
                        lsttaxmaster = taxMaster.TaxMasterRepository.Find(p => p.TaxMasterId == taxMasterId).ToList();

                        if (lsttaxmaster.Count == 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("CmnDataNotFound"));
                        }


                        List<EF.LanguageDetail> lstlanguagedetails= (from ld in taxMaster.LanguageDetailsRepository.GetAll()
                                              join tm in lsttaxmaster on ld.TaxMasterId equals tm.TaxMasterId
                                              select ld).ToList();

                        List<EF.TaxVersion> lsttaxversion = (from tv in taxMaster.TaxVersionRepository.GetAll()
                                         join tm in lsttaxmaster on tv.TaxMasterId equals tm.TaxMasterId
                                         select tv).ToList();
                        List<EF.Tax> lsttax = (from t in taxMaster.TaxRepository.GetAll()
                                  join tv in lsttaxversion on t.TaxVersionId equals tv.TaxVersionId
                                  select t).ToList();
                        List<EF.Variable> lstvariable = (from v in taxMaster.VariableRepository.GetAll()
                                       join t in lsttax on v.TaxId equals t.TaxId
                                       select v).ToList();
                        List<EF.Formula> lstformula = (from f in taxMaster.FormulaRepository.GetAll()
                                      join v in lstvariable on f.VariableId equals v.VariableId
                                      select f).ToList();
                        List<EF.FormulaDefinitionDependencyDetail> lstformuladefinition = (from fd in taxMaster.FormulaDefinitionDependencyDetailsRepository.GetAll()
                                                join v in lstvariable on fd.VariableId equals v.VariableId
                                                join f in lstformula on fd.FormulaId equals f.FormulaId
                                                select fd).ToList();
                        List<EF.LookUpGroup> lstlookupgroup =  (from lg in taxMaster.LookUpGroupRepository.GetAll()
                                          join t in lsttax on lg.TaxId equals t.TaxId
                                          select lg).ToList();
                        List<EF.LookupGroupDetail> lstlookupgroupdetail = (from lgd in taxMaster.LookupGroupDetailRepository.GetAll()
                                                join v in lstvariable on lgd.VariableId equals v.VariableId
                                                join lg in lstlookupgroup on lgd.LookUpGroupId equals lg.LookUpGroupId
                                                select lgd).ToList();
                        List<EF.LookUpDetail> lstlookupdetails = (from ld in taxMaster.LookUpDetailsRepository.GetAll()
                                            join t in lstlookupgroupdetail on ld.GroupDetailsId equals t.GroupDetailsId
                                            select ld).ToList();



                        taxMaster.LookUpDetailsRepository.RemoveRange(lstlookupdetails);
                        taxMaster.LookupGroupDetailRepository.RemoveRange(lstlookupgroupdetail);
                        taxMaster.LookUpGroupRepository.RemoveRange(lstlookupgroup);
                        taxMaster.FormulaDefinitionDependencyDetailsRepository.RemoveRange(lstformuladefinition);
                        taxMaster.FormulaRepository.RemoveRange(lstformula);
                        taxMaster.VariableRepository.RemoveRange(lstvariable);
                        taxMaster.TaxRepository.RemoveRange(lsttax);
                        taxMaster.TaxVersionRepository.RemoveRange(lsttaxversion);
                        taxMaster.LanguageDetailsRepository.RemoveRange(lstlanguagedetails);
                        taxMaster.TaxMasterRepository.RemoveRange(lsttaxmaster);


                    }
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }

        }
        #endregion

        #region Check Version Details
        /// <summary>
        /// To Add New Version details to existing Taxmaster Record
        /// </summary>
        /// <param name="taxVersionData">List of Taxversion Details to add</param>
        public string CheckVersionDetails(IEnumerable<TaxVersionDetail> taxVersionData)
        {
            List<TaxVersionDetails> taxVersionDetailsValue = new List<TaxVersionDetails>();
            string response = string.Empty;

                foreach (var data in taxVersionData)
                {
                    using (var taxmasterRepo = new UnitofWork())
                    {
                        
                        if (taxmasterRepo.TaxMasterRepository.Find(x => x.TaxMasterId == data.TaxMasterId).ToList().Count == 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("InvalidTaxMasterIdmsg"));

                        }
                    }
                    if ((data.TaxFlowId != Helper.iMSRPFlow) && (data.TaxFlowId != Helper.iPRETAXFlow))
                    {
                        throw new InvalidOperationException(Resource.GetResxValueByName("InvalidTaxFlowIdmsg"));
                    }

                    if ((data.EndDate != "")&& Convert.ToDateTime(data.StartDate) > Convert.ToDateTime(data.EndDate))
                    {
                        
                            throw new InvalidOperationException(Resource.GetResxValueByName("InvalidEndStartCombmsg"));
                       
                    }
                    taxVersionDetailsValue.Add(new TaxVersionDetails()
                    {
                        TaxMasterId = data.TaxMasterId,

                        StartDate = Convert.ToDateTime(data.StartDate),
                        EndDate = Convert.ToDateTime(data.EndDate == "" ? Helper.sEndDateIfNull : data.EndDate),
                        TaxFlowId = data.TaxFlowId,
                        IsActive = data.IsActive,
                        CreatedBy = data.CreatedBy,
                        CreatedOn = DateTime.UtcNow,
                        UpdatedBy = data.UpdatedBy,
                        UpdatedOn = DateTime.UtcNow,
                        FeatureLevelTax = data.FeatureLevelTax,
                        TaxVersionStatusId = data.TaxVersionStatusId
                    });
                }
                List<TaxVersion> lsttaxversion = new List<TaxVersion>();

                using (var taxMasterDetails = new UnitofWork())
                {

                    foreach (var item in taxVersionDetailsValue)
                    {
                        lsttaxversion.Add(new TaxVersion()
                        {
                            TaxMasterId = item.TaxMasterId,
                            StartDate = item.StartDate,
                            EndDate = item.EndDate,
                            IsActive = item.IsActive,
                            CreatedBy = item.CreatedBy,
                            CreatedOn = DateTime.UtcNow,
                            UpdatedBy = item.UpdatedBy,
                            UpdatedOn = item.UpdatedOn,
                            TaxVersionStatusId = item.TaxVersionStatusId,
                            FeatureLevelTax = item.FeatureLevelTax
                        });

                    }

                    using (UnitofWork taxVersion = new UnitofWork())
                    {
                        DateTime endDate = Convert.ToDateTime(Helper.sEndDateIfNull);

                        foreach (var item in lsttaxversion)
                        {
                            var lsttaxVersionData = taxVersion.TaxVersionRepository.Find(x => x.TaxMasterId == item.TaxMasterId && x.EndDate != endDate).ToList();
                            foreach (var data in lsttaxVersionData)
                            {

                                if ((item.EndDate != Convert.ToDateTime(Helper.sEndDateIfNull)) && (!((data.StartDate > item.StartDate && data.StartDate > item.EndDate) || (data.EndDate < item.StartDate && data.EndDate < item.EndDate))))
                                {

                                    throw new InvalidOperationException(Resource.GetResxValueByName("VersionConflictmsg"));
                                }
                            }

                            if (taxVersion.TaxVersionRepository.Find(x => x.TaxVersionId == item.TaxVersionId).ToList().Count > 0)
                            {

                                throw new InvalidOperationException(Resource.GetResxValueByName("TaxVersionDuplicatemsg"));
                            }
                            var lstVersionsWithNullEndDate = taxVersion.TaxVersionRepository.Find(x => x.TaxMasterId == item.TaxMasterId && x.EndDate == endDate).FirstOrDefault();


                            if (lstVersionsWithNullEndDate != null)

                            {
                                List<EF.TaxVersion> lstversion = new List<EF.TaxVersion>();
                                if (item.StartDate > lstVersionsWithNullEndDate.StartDate)
                                {
                                    lstversion.Add(new EF.TaxVersion()
                                    {
                                        TaxMasterId = lstVersionsWithNullEndDate.TaxMasterId,
                                        CreatedBy = lstVersionsWithNullEndDate.CreatedBy,
                                        CreatedOn = lstVersionsWithNullEndDate.CreatedOn,
                                        EndDate = item.StartDate.AddDays(-1),
                                        IsActive = lstVersionsWithNullEndDate.IsActive,
                                        StartDate = lstVersionsWithNullEndDate.StartDate,
                                        TaxVersionId = lstVersionsWithNullEndDate.TaxVersionId,
                                        UpdatedBy = item.UpdatedBy,
                                        UpdatedOn = item.UpdatedOn,
                                        FeatureLevelTax = item.FeatureLevelTax,
                                        TaxVersionStatusId = (int)item.TaxVersionStatusId
                                    });
                                    using (UnitofWork taxVersionUpdate = new UnitofWork())
                                    {
                                        response = "Existing version of " + taxVersionUpdate.TaxMasterRepository.Find(x => x.TaxMasterId == lstVersionsWithNullEndDate.TaxMasterId).Select(x => x.TaxName).FirstOrDefault() + " with the start date " + lstVersionsWithNullEndDate.StartDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + " will be updated with the end date " + item.StartDate.AddDays(-1).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)+" Do you want to continue?";
                                    }
                                }
                                else if (item.EndDate == Convert.ToDateTime(Helper.sEndDateIfNull))
                                {
                                    throw new InvalidOperationException(Resource.GetResxValueByName("InvalidStartDatemsg"));
                                }

                            }
                            else if (item.EndDate == Convert.ToDateTime(Helper.sEndDateIfNull))
                            {
                                var lastEndDate = taxVersion.TaxVersionRepository.Find(x => x.TaxMasterId == item.TaxMasterId).OrderByDescending(x => x.EndDate).Select(x => x.EndDate).FirstOrDefault();
                                if (lastEndDate > item.StartDate)
                                {
                                    throw new InvalidOperationException(Resource.GetResxValueByName("VersionConflictmsg"));

                                }
                            }


                        }
                        
                    }

                
                }
               

            return response;
        }
        #endregion

        #region Add New  Version Details
        /// <summary>
        /// To Add New Version details to existing Taxmaster Record
        /// </summary>
        /// <param name="taxVersionData">List of Taxversion Details to add</param>
        public string AddTaxVersionDetails(IEnumerable<TaxVersionDetail> taxVersionData)
        {
            try
            {
                List<TaxVersionDetails> taxVersionDetailsValue = new List<TaxVersionDetails>();
                string response = string.Empty;
                using (TransactionScope scope = new TransactionScope())
                {

                    foreach (var data in taxVersionData)
                    {
                        using (var taxmasterRepo = new UnitofWork())
                        {
                          
                            if (taxmasterRepo.TaxMasterRepository.Find(x => x.TaxMasterId == data.TaxMasterId).ToList().Count == 0)
                            {
                                throw new InvalidOperationException(Resource.GetResxValueByName("InvalidTaxMasterIdmsg"));

                            }
                        }
                        if ((data.TaxFlowId != Helper.iMSRPFlow) && (data.TaxFlowId != Helper.iPRETAXFlow))
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("InvalidTaxFlowIdmsg"));
                        }

                        if ((data.EndDate != "")&& (Convert.ToDateTime(data.StartDate) > Convert.ToDateTime(data.EndDate)))
                        {
                            
                                throw new InvalidOperationException(Resource.GetResxValueByName("InvalidEndStartCombmsg"));
                            
                            
                        }
                        taxVersionDetailsValue.Add(new TaxVersionDetails()
                        {
                            TaxMasterId = data.TaxMasterId,

                            StartDate = Convert.ToDateTime(data.StartDate),
                            EndDate = Convert.ToDateTime(data.EndDate == "" ? Helper.sEndDateIfNull : data.EndDate),
                            TaxFlowId = data.TaxFlowId,
                            IsActive = data.IsActive,
                            CreatedBy = data.CreatedBy,
                            CreatedOn = DateTime.UtcNow,
                            UpdatedBy = data.UpdatedBy,
                            UpdatedOn = DateTime.UtcNow,
                            FeatureLevelTax = data.FeatureLevelTax,
                            TaxVersionStatusId = data.TaxVersionStatusId
                        });
                    }
                    List<TaxVersion> lsttaxversion = new List<TaxVersion>();

                    using (var taxMasterDetails = new UnitofWork())
                    {
                     List<Tax> lsttax = new List<Tax>();

                        foreach (var item in taxVersionDetailsValue)
                        {
                            lsttaxversion.Add(new TaxVersion()
                            {
                                TaxMasterId = item.TaxMasterId,
                                StartDate = item.StartDate,
                                EndDate = item.EndDate,
                                IsActive = item.IsActive,
                                CreatedBy = item.CreatedBy,
                                CreatedOn = DateTime.UtcNow,
                                UpdatedBy = item.UpdatedBy,
                                UpdatedOn = item.UpdatedOn,
                                TaxVersionStatusId = item.TaxVersionStatusId,
                                FeatureLevelTax = item.FeatureLevelTax
                            });

                        }

                        using (UnitofWork taxVersion = new UnitofWork())
                        {
                            DateTime endDate = Convert.ToDateTime(Helper.sEndDateIfNull);

                            foreach (var item in lsttaxversion)
                            {
                                var lsttaxVersionData = taxVersion.TaxVersionRepository.Find(x => x.TaxMasterId == item.TaxMasterId && x.EndDate != endDate).ToList();
                                foreach (var data in lsttaxVersionData)
                                {

                                    if ((item.EndDate != Convert.ToDateTime(Helper.sEndDateIfNull)) && (!((data.StartDate > item.StartDate && data.StartDate > item.EndDate) || (data.EndDate < item.StartDate && data.EndDate < item.EndDate))))
                                    {

                                        throw new InvalidOperationException(Resource.GetResxValueByName("VersionConflictmsg"));
                                    }
                                }

                                if (taxVersion.TaxVersionRepository.Find(x => x.TaxVersionId == item.TaxVersionId).ToList().Count > 0)
                                {

                                    throw new InvalidOperationException(Resource.GetResxValueByName("TaxVersionDuplicatemsg"));
                                }
                                var lstVersionsWithNullEndDate = taxVersion.TaxVersionRepository.Find(x => x.TaxMasterId == item.TaxMasterId && x.EndDate == endDate).FirstOrDefault();


                                if (lstVersionsWithNullEndDate != null)

                                {
                                    List<EF.TaxVersion> lstversion = new List<EF.TaxVersion>();
                                    List<string> lstField = new List<string>() { "EndDate", "UpdatedBy", "UpdatedOn" };
                                    if (item.StartDate > lstVersionsWithNullEndDate.StartDate)
                                    {
                                        lstversion.Add(new EF.TaxVersion()
                                        {
                                            TaxMasterId = lstVersionsWithNullEndDate.TaxMasterId,
                                            CreatedBy = lstVersionsWithNullEndDate.CreatedBy,
                                            CreatedOn = lstVersionsWithNullEndDate.CreatedOn,
                                            EndDate = item.StartDate.AddDays(-1),
                                            IsActive = lstVersionsWithNullEndDate.IsActive,
                                            StartDate = lstVersionsWithNullEndDate.StartDate,
                                            TaxVersionId = lstVersionsWithNullEndDate.TaxVersionId,
                                            UpdatedBy = item.UpdatedBy,
                                            UpdatedOn = item.UpdatedOn,
                                            FeatureLevelTax = item.FeatureLevelTax,
                                            TaxVersionStatusId =(int)item.TaxVersionStatusId
                                        });
                                        using (UnitofWork taxVersionUpdate = new UnitofWork())
                                        {
                                        response = "Note: Existing version of " + taxVersionUpdate.TaxMasterRepository.Find(x=>x.TaxMasterId== lstVersionsWithNullEndDate.TaxMasterId).Select(x=>x.TaxName).FirstOrDefault() + " with the start date " + lstVersionsWithNullEndDate.StartDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + " has been updated with the end date " + item.StartDate.AddDays(-1).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                                            taxVersionUpdate.TaxVersionRepository.UpdateRange(lstversion, lstField);
                                        }
                                    }
                                    else if (item.EndDate == Convert.ToDateTime(Helper.sEndDateIfNull))
                                    {
                                        throw new InvalidOperationException(Resource.GetResxValueByName("InvalidStartDatemsg"));
                                    }

                                }
                                else if (item.EndDate == Convert.ToDateTime(Helper.sEndDateIfNull))
                                {
                                    var lastEndDate = taxVersion.TaxVersionRepository.Find(x => x.TaxMasterId == item.TaxMasterId).OrderByDescending(x => x.EndDate).Select(x => x.EndDate).FirstOrDefault();
                                    if (lastEndDate >=item.StartDate)
                                    {
                                        throw new InvalidOperationException(Resource.GetResxValueByName("VersionConflictmsg"));

                                    }
                                }


                            }
                            List<EF.TaxVersion> lsttaxVersion = new List<EF.TaxVersion>();
                            foreach (var item in lsttaxversion)
                            {
                                lsttaxVersion.Add(new EF.TaxVersion()
                                {
                                    TaxMasterId = item.TaxMasterId,
                                    StartDate = Convert.ToDateTime(item.StartDate),
                                    EndDate = item.EndDate,
                                    IsActive = item.IsActive,
                                    CreatedBy = item.CreatedBy,
                                    CreatedOn = item.CreatedOn,
                                    UpdatedBy = item.UpdatedBy,
                                    UpdatedOn = item.UpdatedOn,
                                    TaxVersionStatusId =(int)item.TaxVersionStatusId,
                                    FeatureLevelTax = item.FeatureLevelTax
                                });
                            }
                            taxVersion.TaxVersionRepository.AddRange(lsttaxVersion);
                        }

                        var lstTaxVersionId = (from tv in taxMasterDetails.TaxVersionRepository.GetAll()
                                               join v in lsttaxversion on new { tv.TaxMasterId, tv.StartDate, tv.EndDate } equals new { v.TaxMasterId, v.StartDate, v.EndDate }
                                               select new { tv.TaxVersionId, tv.TaxMasterId }).First();

                        foreach (var item in taxVersionDetailsValue)
                        {

                            lsttax.Add(new Tax()
                            {

                                TaxVersionId = lstTaxVersionId.TaxVersionId,
                                TaxFlowId = item.TaxFlowId,
                                IsActive = item.IsActive,
                                CreatedBy = item.CreatedBy,
                                CreatedOn = DateTime.UtcNow,
                                UpdatedBy = item.UpdatedBy,
                                UpdatedOn = item.UpdatedOn
                            });

                        }
                        AddTax(lsttax);
                    }
                    scope.Complete();
                }



                return response;

            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }

        }
        #endregion

        #region Update  Version Details
        public string UpdateTaxVersionDetails(IEnumerable<TaxVersionDetail> taxVersionData)
        {
            try
            {
                List<string> lstFields = new List<string>() { "IsActive", "StartDate", "EndDate", "UpdatedBy", "UpdatedOn", "TaxVersionStatusId", "FeatureLevelTax" };
                List<EF.TaxVersion> lsttaxVersion = new List<EF.TaxVersion>();
                List<TaxVersionDetails> taxVersionDetailsValue = new List<TaxVersionDetails>();
                DateTime endDate = Convert.ToDateTime(Helper.sEndDateIfNull);
                string response = string.Empty;
                using (TransactionScope scope = new TransactionScope())
                {

                    foreach (var data in taxVersionData)
                    {
                        using (var taxmasterRepo = new UnitofWork())
                        {
                            if (taxmasterRepo.TaxMasterRepository.Find(x => x.TaxMasterId == data.TaxMasterId).ToList().Count == 0)
                            {
                                throw new InvalidOperationException(Resource.GetResxValueByName("InvalidTaxMasterIdmsg"));

                            }
                            if (taxmasterRepo.TaxVersionRepository.Find(x => x.TaxVersionId == data.TaxVersionId && x.TaxMasterId == data.TaxMasterId).ToList().Count == 0)
                            {
                                throw new InvalidOperationException(Resource.GetResxValueByName("InvalidTaxVersionIdmsg"));

                            }
                            else if (taxmasterRepo.TaxRepository.Find(x => x.TaxId == data.TaxId && x.TaxVersionId == data.TaxVersionId).ToList().Count == 0)
                            {
                                throw new InvalidOperationException(Resource.GetResxValueByName("InvalidTaxIdmsg"));

                            }
                            var lstTaxDetails = taxmasterRepo.TaxRepository.Find(x => x.TaxVersionId == data.TaxVersionId).ToList();
                            foreach (var taxversion in lstTaxDetails)
                            {
                                if (taxmasterRepo.TaxRepository.Find(x => x.TaxVersionId == taxversion.TaxVersionId && x.TaxFlowId == data.TaxFlowId && x.TaxId != data.TaxId).ToList().Count > 0)
                                {

                                    throw new InvalidOperationException(Resource.GetResxValueByName("TaxFlowIdDuplicatemsg"));
                                }
                            }

                            if ((data.TaxFlowId != Helper.iMSRPFlow) && (data.TaxFlowId != Helper.iPRETAXFlow))
                            {
                                throw new InvalidOperationException(Resource.GetResxValueByName("InvalidTaxFlowIdmsg"));
                            }
                            var lsttaxVersionData = taxmasterRepo.TaxVersionRepository.Find(x => x.TaxMasterId == data.TaxMasterId && x.EndDate != endDate && x.TaxVersionId != data.TaxVersionId).ToList();
                            foreach (var Version in lsttaxVersionData)
                            {

                                if ((data.EndDate != Helper.sEndDateIfNull) && (!((Version.StartDate > Convert.ToDateTime(data.StartDate) && Version.StartDate > Convert.ToDateTime(data.EndDate)) || (Version.EndDate < Convert.ToDateTime(data.StartDate) && Version.EndDate < Convert.ToDateTime(data.EndDate)))))
                                {

                                    throw new InvalidOperationException(Resource.GetResxValueByName("VersionConflictmsg"));
                                }
                            }

                            if ((data.EndDate != "")&& (Convert.ToDateTime(data.StartDate) > Convert.ToDateTime(data.EndDate)))
                            {
                                
                                    throw new InvalidOperationException(Resource.GetResxValueByName("InvalidEndStartCombmsg"));
                                
                               
                            }
                        }

                        taxVersionDetailsValue.Add(new TaxVersionDetails()
                        {
                            TaxVersionId = data.TaxVersionId,
                            TaxMasterId = data.TaxMasterId,
                            TaxId = data.TaxId,
                            StartDate = Convert.ToDateTime(data.StartDate),
                            EndDate = Convert.ToDateTime(data.EndDate == "" ? Helper.sEndDateIfNull : data.EndDate),
                            TaxFlowId = data.TaxFlowId,
                            IsActive = data.IsActive,
                            CreatedBy = data.CreatedBy,
                            CreatedOn = data.CreatedOn,
                            UpdatedBy = data.UpdatedBy,
                            UpdatedOn = DateTime.UtcNow,
                            FeatureLevelTax = data.FeatureLevelTax,
                            TaxVersionStatusId = data.TaxVersionStatusId

                        });
                    }
                    List<TaxVersion> lsttaxversion = new List<TaxVersion>();

                    using (var taxMasterDetails = new UnitofWork())
                    {



                        List<Tax> lsttax = new List<Tax>();

                        foreach (var item in taxVersionDetailsValue)
                        {
                            lsttaxversion.Add(new TaxVersion()
                            {
                                TaxVersionId = item.TaxVersionId,
                                TaxMasterId = item.TaxMasterId,
                                StartDate = item.StartDate,
                                EndDate = item.EndDate,
                                IsActive = item.IsActive,
                                CreatedBy = item.CreatedBy,
                                CreatedOn = item.CreatedOn,
                                UpdatedBy = item.UpdatedBy,
                                UpdatedOn = DateTime.UtcNow,
                                FeatureLevelTax = item.FeatureLevelTax,
                                TaxVersionStatusId = item.TaxVersionStatusId
                            });

                        }

                        using (UnitofWork taxVersion = new UnitofWork())
                        {

                            foreach (var item in lsttaxversion)
                            {
                               
                                
                                var lstVersionsWithNullEndDate = taxVersion.TaxVersionRepository.Find(x => x.TaxMasterId == item.TaxMasterId && x.EndDate == endDate&&x.TaxVersionId!=item.TaxVersionId).FirstOrDefault();


                                if (lstVersionsWithNullEndDate != null)

                                {
                                    List<EF.TaxVersion> lstversion = new List<EF.TaxVersion>();
                                    List<string> lstField = new List<string>() { "EndDate", "UpdatedBy", "UpdatedOn" };
                                    if (item.StartDate > lstVersionsWithNullEndDate.StartDate)
                                    {
                                        lstversion.Add(new EF.TaxVersion()
                                        {
                                            TaxVersionId = lstVersionsWithNullEndDate.TaxVersionId,
                                            TaxMasterId = lstVersionsWithNullEndDate.TaxMasterId,
                                            StartDate = lstVersionsWithNullEndDate.StartDate,
                                            EndDate = item.StartDate.AddDays(-1),
                                            IsActive = lstVersionsWithNullEndDate.IsActive,
                                            CreatedBy = lstVersionsWithNullEndDate.CreatedBy,
                                            CreatedOn = lstVersionsWithNullEndDate.CreatedOn,
                                            UpdatedBy = item.UpdatedBy,
                                            UpdatedOn = item.UpdatedOn,
                                            FeatureLevelTax = item.FeatureLevelTax,
                                            TaxVersionStatusId =(int)item.TaxVersionStatusId
                                        });

                                        using (UnitofWork taxVersionUpdate = new UnitofWork())
                                        {
                                            response = "Note: Existing version of " + taxVersionUpdate.TaxMasterRepository.Find(x => x.TaxMasterId == lstVersionsWithNullEndDate.TaxMasterId).Select(x => x.TaxName).FirstOrDefault() + " with the start date " + lstVersionsWithNullEndDate.StartDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + " has been updated with the end date " + item.StartDate.AddDays(-1).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

                                            taxVersionUpdate.TaxVersionRepository.UpdateRange(lstversion, lstField);
                                        }
                                    }
                                    else if (item.EndDate == Convert.ToDateTime(Helper.sEndDateIfNull))
                                    {
                                        throw new InvalidOperationException(Resource.GetResxValueByName("InvalidStartDatemsg"));
                                    }

                                }
                                else if (item.EndDate == Convert.ToDateTime(Helper.sEndDateIfNull))
                                {
                                    var lastEndDate = taxVersion.TaxVersionRepository.Find(x => x.TaxMasterId == item.TaxMasterId).OrderByDescending(x => x.EndDate).Select(x => x.EndDate).FirstOrDefault();
                                    if (lastEndDate >=item.StartDate)
                                    {
                                        throw new InvalidOperationException(Resource.GetResxValueByName("VersionConflictmsg"));

                                    }
                                }


                            }
                           
                            foreach (var item in lsttaxversion)
                            {
                                lsttaxVersion.Add(new EF.TaxVersion()
                                {
                                    TaxVersionId=item.TaxVersionId,
                                    TaxMasterId = item.TaxMasterId,
                                    StartDate = Convert.ToDateTime(item.StartDate),
                                    EndDate = item.EndDate,
                                    IsActive = item.IsActive,
                                    CreatedBy = item.CreatedBy,
                                    CreatedOn = item.CreatedOn,
                                    UpdatedBy = item.UpdatedBy,
                                    UpdatedOn = item.UpdatedOn,
                                     FeatureLevelTax = item.FeatureLevelTax,
                                      TaxVersionStatusId =(int)item.TaxVersionStatusId
                                });
                            }
                            taxVersion.TaxVersionRepository.UpdateRange(lsttaxVersion, lstFields);
                        }

                        var lstTaxVersionId = (from tv in taxMasterDetails.TaxVersionRepository.GetAll()
                                               join v in lsttaxversion on new { tv.TaxMasterId, tv.StartDate, tv.EndDate } equals new { v.TaxMasterId, v.StartDate, v.EndDate }
                                               select new { tv.TaxVersionId, tv.TaxMasterId }).First();

                        foreach (var item in taxVersionDetailsValue)
                        {

                            lsttax.Add(new Tax()
                            {
                                TaxId=item.TaxId,
                                TaxVersionId = lstTaxVersionId.TaxVersionId,
                                TaxFlowId = item.TaxFlowId,
                                IsActive = item.IsActive,
                                CreatedBy = item.CreatedBy,
                                CreatedOn =item.CreatedOn,
                                UpdatedBy = item.UpdatedBy,
                                UpdatedOn = DateTime.UtcNow
                            });

                        }
                        UpdateTax(lsttax);
                    }
                    scope.Complete();
                }



                return response;

            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }
        }
        #endregion



        #region Add TaxMaster
        /// <summary>
        /// To add TaxMaster
        /// </summary>
        /// <param name="taxMasterValue">List of TaxMaster Datas to Add</param>
        public TaxMaster AddTaxMaster(IEnumerable<TaxMaster> taxMasterValue)
            {
            try
            {
                using (var taxMaster = new UnitofWork())
                {
                    foreach (var item in taxMasterValue)
                    {
                      
                        if (taxMaster.MarketRepository.Find(x => x.MarketId == item.MarketId).ToList().Count == 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("InvalidMarketIdmsg"));
                        }
                        else if (taxMaster.TaxMasterRepository.Find(x => x.MarketId == item.MarketId && x.Priority == item.Priority).ToList().Count > 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("MarketIdPriorityCombDuplicatemsg"));
                        }
                        else if(taxMaster.TaxMasterRepository.Find(x => x.MarketId == item.MarketId && x.TaxName == item.TaxName).ToList().Count > 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("DuplicateTaxNamemsg"));

                        }
                    }
                    List<EF.TaxMaster> lsttaxmaster = new List<EF.TaxMaster>();
                    foreach (var item in taxMasterValue)
                    {
                        var preexhistdata = taxMaster.TaxMasterRepository.Find(x => x.MarketId == item.MarketId && x.TaxName == item.TaxName).FirstOrDefault();
                        if (preexhistdata == null)
                        {
                            lsttaxmaster.Add(new EF.TaxMaster()
                            {

                                MarketId = item.MarketId,
                                TaxName = item.TaxName,
                                TaxPositionId = item.TaxPositionId,
                                Priority = item.Priority,
                                IsActive = item.IsActive,
                                CreatedBy = item.CreatedBy,
                                CreatedOn = DateTime.UtcNow,
                                UpdatedBy = item.UpdatedBy,
                                UpdatedOn = DateTime.UtcNow
                            });
                        }

                    }
                    taxMaster.TaxMasterRepository.AddRange(lsttaxmaster);
                }
                using (var taxmasterResponse = new UnitofWork())
                {
                    long txId = (from fd in taxmasterResponse.TaxMasterRepository.GetAll()
                                 join v in taxMasterValue on new { fd.MarketId, fd.TaxName, fd.TaxPositionId } equals new { v.MarketId, v.TaxName, v.TaxPositionId }
                                 select new { fd.TaxMasterId }).Select(x => x.TaxMasterId).FirstOrDefault();
                    EF.TaxMaster result = taxmasterResponse.TaxMasterRepository.Find(x => x.TaxMasterId == txId).FirstOrDefault();

                    TaxMaster taxMaster = new TaxMaster()
                    {
                        TaxMasterId = result.TaxMasterId,
                        TaxName = result.TaxName,
                        TaxPositionId = result.TaxPositionId,
                        Priority = result.Priority,
                        MarketId = result.MarketId,
                        IsActive = result.IsActive,
                        CreatedBy = result.CreatedBy,
                        CreatedOn = result.CreatedOn,
                        UpdatedBy = result.UpdatedBy,
                        UpdatedOn = result.UpdatedOn
                    };




                    return taxMaster;
                }
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException( ex.Message);
            }


        }
        #endregion

        #region Add TaxVersion
        /// <summary>
        /// To add Tax Version Details
        /// </summary>
        /// <param name="taxVersionValue">List of TaxVersion Details to Add</param>
        public List<TaxVersion> AddTaxVersion(List<TaxVersion> taxVersionValue)
        {
            try
            {
                using (UnitofWork taxVersion = new UnitofWork())
                {
                    foreach (var item in taxVersionValue)
                    {
                        
                        var lsttaxVersionData = taxVersion.TaxVersionRepository.Find(x => x.TaxMasterId == item.TaxMasterId).ToList();
                        foreach (var data in lsttaxVersionData)
                        {

                            if (!((data.StartDate > item.StartDate && data.StartDate > item.EndDate) || (data.EndDate < item.StartDate && data.EndDate < item.EndDate)))
                            {
                                throw new InvalidOperationException(Resource.GetResxValueByName("VersionConflictmsg"));
                            }
                        }
                        long taxVersionId = item.TaxVersionId;
                        if (taxVersion.TaxVersionRepository.Find(x => x.TaxVersionId == taxVersionId).ToList().Count > 0)
                        {

                            throw new InvalidOperationException(Resource.GetResxValueByName("TaxVersionDuplicatemsg"));
                        }
                        

                    }
                    List<EF.TaxVersion> lsttaxversion = new List<EF.TaxVersion>();
                    foreach (var item in taxVersionValue)
                    {
                        lsttaxversion.Add(new EF.TaxVersion()
                        {
                            TaxMasterId = item.TaxMasterId,
                            StartDate = Convert.ToDateTime(item.StartDate),
                            EndDate = item.EndDate,
                            IsActive = item.IsActive,
                            CreatedBy = item.CreatedBy,
                            CreatedOn = DateTime.UtcNow,
                            UpdatedBy = item.UpdatedBy,
                            UpdatedOn = DateTime.UtcNow,
                             FeatureLevelTax = item.FeatureLevelTax,
                              TaxVersionStatusId =(int)item.TaxVersionStatusId

                        });
                    }
                    taxVersion.TaxVersionRepository.AddRange(lsttaxversion);
                }
                using (var taxVersionRepo = new UnitofWork())
                {
                    var taxMasterId = taxVersionValue[0].TaxMasterId;


                   List< EF.TaxVersion> lstresult = taxVersionRepo.TaxVersionRepository.Find(x => x.TaxMasterId == taxMasterId).ToList();
                    List<TaxVersion> lsttaxVersionData = new List<TaxVersion>();
                    foreach (var result in lstresult)
                    {
                         lsttaxVersionData.Add(new  TaxVersion()
                        {
                            TaxVersionId = result.TaxVersionId,
                            TaxMasterId = result.TaxMasterId,
                            StartDate = result.StartDate,
                            EndDate = result.EndDate,
                            IsActive = result.IsActive,
                            CreatedBy = result.CreatedBy,
                            CreatedOn = result.CreatedOn,
                            UpdatedBy = result.UpdatedBy,
                            UpdatedOn = result.UpdatedOn,
                             FeatureLevelTax = result.FeatureLevelTax,
                             TaxVersionStatusId = (int)result.TaxVersionStatusId
                         });
                    }

                     return lsttaxVersionData;
                }
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }


        }
        #endregion


        #region Add Tax
        /// <summary>
        /// To Add Tax Details
        /// </summary>
        /// <param name="taxValue">List of Tax Details to Add</param>
        public List<Tax> AddTax(IEnumerable<Tax> taxValue)
        {
            try
            {
                using (var tax = new UnitofWork())
                {
                    foreach (var item in taxValue)
                    {
                        if (tax.TaxVersionRepository.Find(x => x.TaxVersionId == item.TaxVersionId ).ToList().Count== 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("InvalidTaxVersionIdmsg"));

                        }
                        if ((item.TaxFlowId != Helper.iMSRPFlow) && (item.TaxFlowId != Helper.iPRETAXFlow))
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("InvalidTaxFlowIdmsg"));
                        }

                        if (tax.TaxRepository.Find(x => x.TaxVersionId == item.TaxVersionId && x.TaxFlowId == item.TaxFlowId).ToList().Count > 0)
                        {

                            throw new InvalidOperationException(Resource.GetResxValueByName("TaxFlowIdDuplicatemsg"));
                        }
                        if (tax.TaxVersionRepository.Find(x=>x.TaxVersionId==item.TaxVersionId).Select(x=>x.TaxVersionStatusId).FirstOrDefault()==31)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("PublishedVermsg"));
                        }
                    }
                    List<EF.Tax> lsttax = new List<EF.Tax>();
                    foreach (var item in taxValue)
                    {
                        lsttax.Add(new EF.Tax()
                        {
                            TaxVersionId = item.TaxVersionId,
                            TaxFlowId = item.TaxFlowId,
                            IsActive = item.IsActive,
                            CreatedBy = item.CreatedBy,
                            CreatedOn = DateTime.UtcNow,
                            UpdatedBy = item.UpdatedBy,
                            UpdatedOn = DateTime.UtcNow
                        });
                    }
                    tax.TaxRepository.AddRange(lsttax);
                }
                using (var taxRepo = new UnitofWork())
                {

                    List<EF.Tax> lstresult = (from u in taxRepo.TaxRepository.GetAll()
                                              join t in taxValue on u.TaxVersionId equals t.TaxVersionId
                                              select u).Distinct().ToList();
                    
                    List<Tax> lsttaxData = new List<Tax>();
                    foreach (var result in lstresult)
                    {
                        lsttaxData.Add(new Tax()
                        {
                            TaxId =result.TaxId,
                            TaxVersionId = result.TaxVersionId,
                            TaxFlowId=result.TaxFlowId,
                            IsActive = result.IsActive,
                            CreatedBy = result.CreatedBy,
                            CreatedOn = result.CreatedOn,
                            UpdatedBy = result.UpdatedBy,
                            UpdatedOn = result.UpdatedOn
                        });
                    }

                    return lsttaxData;
                }
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }


        }
        #endregion

    

    }

    public class TaxData
    {
        public List<TaxMaster> ListTaxMaster { get; set; }
        public List<TaxVersion> ListTaxVersion { get; set; }
        public List<Tax> ListTax { get; set; }
    }
        public class TaxMasterList
        {
        #region TaxMasterList Property
        [JsonProperty(PropertyName = "taxMasterId")]
        public long TaxMasterId { get; set; }
        [JsonProperty(PropertyName = "marketId")]
        public long MarketId { get; set; }
        [JsonProperty(PropertyName = "taxName")]
        public string TaxName { get; set; } 
        #endregion
    }
    public class TaxMasterName
    {
        #region TaxMasterName Property
        [JsonProperty(PropertyName = "taxId")]
        public int TaxId { get; set; }
        [JsonProperty(PropertyName = "taxName")]
        public string TaxName { get; set; } 
        #endregion
    }
    public class LeftMenuDrpId
    {
        public int MarketId { get; set; }
        public int TaxMasterId { get; set; }
        public int TaxVersionId { get; set; }
        public int TaxType { get; set; }
    }
}