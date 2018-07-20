using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Transactions;
using System.Web;
using UraxUIServiceWebApi.Repository;
using UraxUIServiceWebApi.ResourceFiles;

namespace UraxUIServiceWebApi.Models
{
    public class CalculationOrder
    {
        #region Property
        [JsonProperty(PropertyName = "taxMasterId")]
        public long TaxMasterId { get; set; }
        [JsonProperty(PropertyName = "taxName")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "TaxNameReq")]
        public string TaxName { get; set; }
        [JsonProperty(PropertyName = "calculationOrder")]
        [Required(ErrorMessage = "calculationOrder is required.")]
        public int CalOrder { get; set; }
        #endregion
        internal List<CalculationOrder> GetCalculationOrderByTaxId(long taxMasterId)
        {
            //TODO : Return order list of calculations order expect current Tax Master Id
            try
            {
                List<CalculationOrder> lstCalculationOrder = new List<CalculationOrder>();
                using (var taxMaster = new UnitofWork())
                {
                    var MarketID = taxMaster.TaxMasterRepository.Find(x => x.TaxMasterId == taxMasterId).Select(x => x.MarketId);
                    var result = taxMaster.TaxMasterRepository.Find(x => x.MarketId == MarketID.FirstOrDefault() && x.TaxMasterId != taxMasterId).Select(x => new { x.TaxMasterId, x.TaxName, x.Priority }).ToList();
                    foreach (var data in result)
                    {
                        lstCalculationOrder.Add(new CalculationOrder()
                        {
                            TaxMasterId = data.TaxMasterId,
                            CalOrder = data.Priority,
                            TaxName = data.TaxName
                        });
                    }
                }
                return lstCalculationOrder;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }
        }
        internal void SwapCalculationOrderDetails(long taxMasterId, long swaptaxMasterId, string loginUser)
        {
            using (TransactionScope tran = new TransactionScope())
            {
                try
                {
                    List<EF.TaxMaster> lstTaxMaster;
                    List<EF.TaxMaster> lstTaxMaster1;
                    int calOrder;
                    using (var taxMaster = new UnitofWork())
                    {

                        lstTaxMaster = taxMaster.TaxMasterRepository.Find(x => x.TaxMasterId == taxMasterId).ToList<EF.TaxMaster>();
                        lstTaxMaster1 = taxMaster.TaxMasterRepository.Find(x => x.TaxMasterId == swaptaxMasterId).ToList<EF.TaxMaster>();
                        calOrder = (int)lstTaxMaster1[0].Priority;
                        lstTaxMaster[0].UpdatedBy = loginUser;
                        lstTaxMaster[0].UpdatedOn = DateTime.UtcNow;
                        lstTaxMaster1[0].Priority = lstTaxMaster[0].Priority;
                        lstTaxMaster1[0].UpdatedBy = loginUser;
                        lstTaxMaster1[0].UpdatedOn = DateTime.UtcNow;
                        lstTaxMaster[0].Priority = 9999999;
                    }
                    List<string> lstField = new List<string>() { "Priority", "UpdatedBy" , "UpdatedOn" };
                    
                    using (var taxobj = new UnitofWork())
                    {
                        taxobj.TaxMasterRepository.UpdateRange(lstTaxMaster, lstField);
                    }
                    using (var taxobj = new UnitofWork())
                    {
                        taxobj.TaxMasterRepository.UpdateRange(lstTaxMaster1, lstField);
                    }
                    using (var taxobj = new UnitofWork())
                    {
                        lstTaxMaster[0].Priority = calOrder;
                        taxobj.TaxMasterRepository.UpdateRange(lstTaxMaster, lstField);
                    }
                    tran.Complete();
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
                }
            }
        }
        internal List<VariableDropList> GetNewCalculationOrderByTaxId(long taxTerritoryId)
        {
            List<VariableDropList> lstCalculationOrder = new List<VariableDropList>();
            try
            {
                using (var taxMaster = new UnitofWork())
                {
                    var result = taxMaster.TaxMasterRepository.Find(x => x.MarketId == taxTerritoryId).OrderByDescending(x=>x.Priority).First().Priority;
                    lstCalculationOrder.Add(new VariableDropList()
                    {
                        VariableName = "NewCalculationOrder",
                        VariableId = Convert.ToInt32( result) + 1
                    });
                }
                return lstCalculationOrder;
            }
            catch (Exception ex)
            {
                if(ex.Message == "Sequence contains no elements")
                {
                    lstCalculationOrder.Add(new VariableDropList()
                    {
                        VariableName = "NewCalculationOrder",
                        VariableId =  1
                    });
                    return lstCalculationOrder;
                }
                else
                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }
        }
    }
}