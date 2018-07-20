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
    public class TreeStructue
    {
        #region Tree Structure Property
        [JsonProperty(PropertyName = "marketId")]
        public long MarketId { get; set; }

        [JsonProperty(PropertyName = "marketName")]
        public string MarketName { get; set; }


        [JsonProperty(PropertyName = "marketChildren")]
        public List<TreeStructureTaxMaster> MarketChildren { get; set; }
        #endregion

        #region Get Tree Structure Details By MarketId
        /// <summary>
        /// To get Tree Structure Details by Market Id
        /// </summary>
        /// <param name="MktId">An Integer which represents Market Id</param>
        /// <returns>List of Tree structure Details</returns>
        internal  List<TreeStructue> GetTreeStructureDetails(int MktId)
        {
            List<TreeStructue> lstTreeStructue = new List<TreeStructue>();
            List<TreeStructureTaxMaster> lstTreeStructueTaxMaster = new List<TreeStructureTaxMaster>();
            List<TreeStructureTaxFlow> lstTreeStructueTaxFlow = new List<TreeStructureTaxFlow>();

            long _masterId;
            long _taxVersionId;

            try
            {

                using (var treestructure = new UnitofWork())
                {

                    //Market

                    var lstMarket = (from m in treestructure.MarketRepository.Find(x => x.MarketId == MktId).ToList<EF.Market>()
                                     select new { m.MarketId });
                    foreach (var mktResult in lstMarket)
                    {
                        lstTreeStructue.Add(new TreeStructue()
                        {
                            MarketId = mktResult.MarketId,
                           // MarketName = mktResult.MarketName,
                            MarketChildren = lstTreeStructueTaxMaster

                        });

                        //TaxMaster
                        using (var treestructuretaxmaster = new UnitofWork())
                        {

                            var lstTaxMaster = (from tm in treestructuretaxmaster.TaxMasterRepository.Find(x => x.MarketId == MktId).ToList<EF.TaxMaster>()
                                                select new { tm.TaxMasterId, tm.TaxName });

                            foreach (var taxMstrResult in lstTaxMaster)
                            {
                                List<TreeStructureTaxVersion> lstTreeStructueTaxVersion = new List<TreeStructureTaxVersion>();
                                lstTreeStructueTaxMaster.Add(new TreeStructureTaxMaster()
                                {
                                    TaxMasterId = taxMstrResult.TaxMasterId,
                                    TaxName = taxMstrResult.TaxName,
                                    TaxMasterChildren = lstTreeStructueTaxVersion

                                });

                                _masterId = taxMstrResult.TaxMasterId;



                                //Getting all the Version details based on each TaxMasterId.   
                                using (var treestructuretaxversion = new UnitofWork())
                                {
                                    var lstTaxMaster1 = treestructuretaxversion.TaxMasterRepository.Find(x => x.MarketId == MktId).ToList<EF.TaxMaster>();

                                    var lstTaxVersion1 = (from tv1 in treestructuretaxversion.TaxVersionRepository.Find(x => x.TaxMasterId == _masterId)
                                                          join tm1 in lstTaxMaster1 on tv1.TaxMasterId equals tm1.TaxMasterId
                                                          select new { tm1.TaxName, tm1.TaxMasterId, tv1.TaxVersionId, tv1.StartDate, tv1.EndDate }).Distinct();

                                    foreach (var taxVerResult1 in lstTaxVersion1)
                                    {

                                        lstTreeStructueTaxVersion.Add(new TreeStructureTaxVersion()
                                        {
                                            TaxVersionId = taxVerResult1.TaxVersionId,
                                            TaxVersionName = taxVerResult1.TaxName.ToString().ToUpper() + " " + taxVerResult1.StartDate.ToString("yyyy-MM-dd") + " - " + (taxVerResult1.EndDate != null ? taxVerResult1.EndDate.Value.ToString("yyyy-MM-dd") : "n/a"),
                                            TaxVersionChildren = lstTreeStructueTaxFlow

                                        });

                                        _taxVersionId = taxVerResult1.TaxVersionId;

                                        //Getting all the Tax Flow details based on each TaxMasterId.
                                        using (var treestructuretaxflow = new UnitofWork())
                                        {

                                            var lstTaxMaster2 = treestructuretaxflow.TaxMasterRepository.Find(x => x.MarketId == MktId).ToList<EF.TaxMaster>();
                                            var lstTaxTax2 = treestructuretaxflow.TaxRepository.Find(x => x.TaxVersionId == _taxVersionId);

                                            var lstVariable = treestructuretaxflow.VariableRepository.GetAll();
                                            var lstParameterDetails = treestructuretaxflow.ParameterDetailsRepository.GetAll();



                                            var lstTax = (from t1 in treestructuretaxflow.TaxVersionRepository.GetAll()
                                                          join tm in lstTaxMaster2 on t1.TaxMasterId equals tm.TaxMasterId
                                                          join t in lstTaxTax2 on t1.TaxVersionId equals t.TaxVersionId
                                                          join v1 in lstVariable on t.TaxId equals v1.VariableId
                                                          join p1 in lstParameterDetails on t.TaxFlowId equals p1.ParameterId
                                                          select new { t.TaxId, t.TaxFlowId, v1.VariableTypeId, p1.Value }).Distinct();

                                            foreach (var taxResult in lstTax)
                                            {

                                                lstTreeStructueTaxFlow.Add(new TreeStructureTaxFlow()
                                                {
                                                    TaxFlowId = taxResult.TaxFlowId,
                                                    TaxFlowName = taxResult.Value,
                                                    TaxFlowChildren = null

                                                });
                                            }


                                        }


                                    }




                                }


                            }



                        }


                    }




                }

            }



            catch (Exception)
            {
                throw;
            }

            return lstTreeStructue;

        } 
        #endregion

    }




        public class TreeStructureTaxMaster
        {
        #region TreeStructureTaxMaster Property
        [JsonProperty(PropertyName = "taxMasterId")]
        public long TaxMasterId { get; set; }

        [JsonProperty(PropertyName = "taxName")]
        public string TaxName { get; set; }

        [JsonProperty(PropertyName = "taxMasterChildren")]
        public List<TreeStructureTaxVersion> TaxMasterChildren { get; set; } 
        #endregion
        }

        public class TreeStructureTaxVersion
        {
        #region TreeStructureTaxVersion Property
        [JsonProperty(PropertyName = "taxVersionId")]
        public long TaxVersionId { get; set; }

        [JsonProperty(PropertyName = "taxVersionName")]
        public string TaxVersionName { get; set; }

        [JsonProperty(PropertyName = "taxVersionChildren")]
        public List<TreeStructureTaxFlow> TaxVersionChildren { get; set; } 
        #endregion
    }

        public class TreeStructureTaxFlow
        {

        #region TreeStructureTaxFlow Property
        [JsonProperty(PropertyName = "taxFlowId")]
        public int TaxFlowId { get; set; }

        [JsonProperty(PropertyName = "taxFlowName")]
        public string TaxFlowName { get; set; }

        [JsonProperty(PropertyName = "taxFlowChildren")]
        public string TaxFlowChildren { get; set; } 
        #endregion
    }

    public class TreeStructureList
    {

        #region TreeStructureList Property
        [JsonProperty(PropertyName = "marketId")]
        public long MarketId { get; set; }

        [JsonProperty(PropertyName = "marketName")]
        public string MarketName { get; set; }

        [JsonProperty(PropertyName = "marketChildren")]
        public List<TreeStructureTaxMaster> MarketChildren { get; set; } 
        #endregion

     }


    
}


