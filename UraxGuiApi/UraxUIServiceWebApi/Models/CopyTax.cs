#region NameSpaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Transactions;
using EF = UraxUIServiceWebApi.EF;
using UraxUIServiceWebApi.Repository;
using UraxUIServiceWebApi.ResourceFiles;
using UraxUIServiceWebApi.Controllers;
#endregion

namespace UraxUIServiceWebApi.Models
{
    public class CopyTax
    {
        #region  CopyTax Property
        [JsonProperty(PropertyName = "taxMasterId")]
        public long TaxMasterId { get; set; }
        [JsonProperty(PropertyName = "taxName")]
        public string TaxName { get; set; }
        [JsonProperty(PropertyName = "createdBy")]
        public string CreatedBy { get; set; }
        #endregion
        #region Add Copy Tax
        /// <summary>
        /// To Copy Tax Details
        /// </summary>
        /// <param name="copyTaxValue">List of Tax Details to copy as input </param>
        public void AddCopyTax(List<CopyTax> copyTaxValue)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    foreach (var item in copyTaxValue)
                    {
                        using (var copyTaxRepo = new UnitofWork())
                        {
                            if (copyTaxRepo.VariableRepository.Find(x => x.VariableName == item.TaxName).ToList().Count > 0)
                            {
                                throw new InvalidOperationException(Resource.GetResxValueByName("InvalidTaxNamemsg"));

                            }
                            var taxmasterDetails = copyTaxRepo.TaxMasterRepository.Find(x => x.TaxMasterId == item.TaxMasterId).FirstOrDefault();
                            var exhistingPriority = copyTaxRepo.TaxMasterRepository.Find(x => x.MarketId == taxmasterDetails.MarketId).OrderByDescending(x => x.Priority).Select(x => x.Priority).FirstOrDefault();
                            TaxMaster taxMasterObj = new TaxMaster();
                            TaxMaster resultTaxMasterToCreate = new TaxMaster()
                            {
                                TaxMasterId = taxmasterDetails.TaxMasterId,
                                TaxName = item.TaxName,
                                MarketId = taxmasterDetails.MarketId,
                                TaxPositionId = taxmasterDetails.TaxPositionId,
                                Priority = (exhistingPriority + 1),
                                IsActive = taxmasterDetails.IsActive,
                                CreatedBy = item.CreatedBy,
                                CreatedOn = DateTime.UtcNow,
                                UpdatedBy = item.CreatedBy,
                                UpdatedOn = DateTime.UtcNow
                            };
                            List<TaxMaster> lstresultTaxMasterExisting = new List<TaxMaster>() { { resultTaxMasterToCreate } };
                            TaxMaster resultTaxMasterCreated = taxMasterObj.AddTaxMaster(lstresultTaxMasterExisting);
                            //Copy Taxversion Details
                            var lstresultTaxVersionExisting = copyTaxRepo.TaxVersionRepository.Find(x => x.TaxMasterId == taxmasterDetails.TaxMasterId).ToList();
                            List<TaxVersion> lstresultTaxVersionToCreate = new List<TaxVersion>();
                            foreach (var version in lstresultTaxVersionExisting)
                            {
                                lstresultTaxVersionToCreate.Add(new TaxVersion()
                                {
                                    TaxMasterId = resultTaxMasterCreated.TaxMasterId,
                                    StartDate = version.StartDate,
                                    EndDate = version.EndDate,
                                    IsActive = version.IsActive,
                                    CreatedBy = resultTaxMasterCreated.CreatedBy,
                                    CreatedOn = resultTaxMasterCreated.CreatedOn,
                                    UpdatedBy = resultTaxMasterCreated.CreatedBy,
                                    UpdatedOn = resultTaxMasterCreated.UpdatedOn,
                                    FeatureLevelTax = version.FeatureLevelTax,
                                    TaxVersionStatusId = version.TaxVersionStatusId
                                });
                            }
                            List<TaxVersion> lstresultTaxVersionCreated = taxMasterObj.AddTaxVersion(lstresultTaxVersionToCreate);
                            // Copy Tax details
                            List<long> OldVersionId = lstresultTaxVersionExisting.Select(x => x.TaxVersionId).ToList();
                            List<long> NewVersionId = lstresultTaxVersionCreated.Select(x => x.TaxVersionId).ToList();
                            var lstVersionId = OldVersionId.Join(NewVersionId, s => OldVersionId.IndexOf(s), i => NewVersionId.IndexOf(i), (s, i) => new { NewVersionId = i, OldVersionId = s }).ToList();
                            var lstresultTaxExisting = (from u in copyTaxRepo.TaxRepository.GetAll()
                                                        join tv in lstresultTaxVersionExisting on u.TaxVersionId equals tv.TaxVersionId
                                                        select u).ToList();
                            var lstresultTaxtoCreate = (from te in lstresultTaxExisting
                                                        join ld in lstVersionId on te.TaxVersionId equals ld.OldVersionId
                                                        select new Tax()
                                                        {
                                                            TaxVersionId = ld.NewVersionId,
                                                            TaxFlowId = te.TaxFlowId,
                                                            IsActive = te.IsActive,
                                                            CreatedBy = resultTaxMasterCreated.CreatedBy,
                                                            CreatedOn = resultTaxMasterCreated.CreatedOn,
                                                            UpdatedBy = resultTaxMasterCreated.UpdatedBy,
                                                            UpdatedOn = resultTaxMasterCreated.UpdatedOn
                                                        }).ToList();
                            var lstresultTaxCreated = taxMasterObj.AddTax(lstresultTaxtoCreate);
                            //Copy Language Details
                            List<EF.LanguageDetail> lstExhistingLanguagedetails = copyTaxRepo.LanguageDetailsRepository.Find(x => x.TaxMasterId == taxmasterDetails.TaxMasterId).ToList();
                            foreach (var param in lstExhistingLanguagedetails)
                            {
                                param.TaxMasterId = resultTaxMasterCreated.TaxMasterId;
                                param.CreatedBy = resultTaxMasterCreated.CreatedBy;
                                param.CreatedOn = resultTaxMasterCreated.CreatedOn;
                                param.UpdatedBy = resultTaxMasterCreated.UpdatedBy;
                                param.UpdatedOn = resultTaxMasterCreated.UpdatedOn;
                            }
                            copyTaxRepo.LanguageDetailsRepository.AddRange(lstExhistingLanguagedetails);
                            //Copy Variable Details
                            List<EF.Variable> lstresultVariableExisting = (from v in copyTaxRepo.VariableRepository.GetAll()
                                                                           join t in lstresultTaxExisting on v.TaxId equals t.TaxId
                                                                           select v).ToList();
                            List<long> OldTaxId = lstresultTaxExisting.Select(x => x.TaxId).ToList();
                            List<long> NewTaxId = lstresultTaxCreated.Select(x => x.TaxId).ToList();
                            var lstTaxId = OldTaxId.Join(NewTaxId, s => OldTaxId.IndexOf(s), i => NewTaxId.IndexOf(i), (s, i) => new { NewTaxId = i, OldTaxId = s }).ToList();
                            List<EF.Variable> lstresultVariableToCreate = (from v in copyTaxRepo.VariableRepository.GetAll()
                                                                           join t in lstTaxId on v.TaxId equals t.OldTaxId
                                                                           select new EF.Variable()
                                                                           {
                                                                               TaxId = t.NewTaxId,
                                                                               VariableName = v.VariableName,
                                                                               Value = v.Value,
                                                                               UnitTypeId = v.UnitTypeId,
                                                                               VariableTypeId = v.VariableTypeId,
                                                                               IsActive = v.IsActive,
                                                                               IslookUp = v.IslookUp,
                                                                               CreatedBy = resultTaxMasterCreated.CreatedBy,
                                                                               CreatedOn = resultTaxMasterCreated.CreatedOn,
                                                                               UpdatedBy = resultTaxMasterCreated.UpdatedBy,
                                                                               UpdatedOn = resultTaxMasterCreated.UpdatedOn
                                                                           }
                                                                     ).ToList();
                            copyTaxRepo.VariableRepository.AddRange(lstresultVariableToCreate);
                            List<EF.Variable> lstresultVariableCreated = (from u in copyTaxRepo.VariableRepository.GetAll()
                                                                          join t in lstresultTaxCreated on u.TaxId equals t.TaxId
                                                                          select u).ToList();
                            //Copy Lookup Details
                            var lstresultlookupgroupExhisting = (from lg in copyTaxRepo.LookUpGroupRepository.GetAll()
                                                                 join t in lstresultTaxExisting on lg.TaxId equals t.TaxId
                                                                 select lg).ToList();
                            var lstresultlookupgroupToCreate = (from lg in copyTaxRepo.LookUpGroupRepository.GetAll()
                                                                join t in lstTaxId on lg.TaxId equals t.OldTaxId
                                                                select new EF.LookUpGroup()
                                                                {
                                                                    TaxId = t.NewTaxId,
                                                                    LookUpGroupName = lg.LookUpGroupName,
                                                                    IsActive = lg.IsActive,
                                                                    CreatedBy = resultTaxMasterCreated.CreatedBy,
                                                                    CreatedOn = resultTaxMasterCreated.CreatedOn,
                                                                    UpdatedBy = resultTaxMasterCreated.UpdatedBy,
                                                                    UpdatedOn = resultTaxMasterCreated.UpdatedOn
                                                                }).ToList();
                            copyTaxRepo.LookUpGroupRepository.AddRange(lstresultlookupgroupToCreate);
                            List<EF.LookUpGroup> lstresultLookUpGroupCreated = (from u in copyTaxRepo.LookUpGroupRepository.GetAll()
                                                                                join t in lstresultTaxCreated on u.TaxId equals t.TaxId
                                                                                select u).ToList();
                            List<long> OldLookUpGroupId = lstresultlookupgroupExhisting.Select(x => x.LookUpGroupId).ToList();
                            List<long> NewLookUpGroupId = lstresultLookUpGroupCreated.Select(x => x.LookUpGroupId).ToList();
                            var lstLookUpGroupId = OldLookUpGroupId.Join(NewLookUpGroupId, s => OldLookUpGroupId.IndexOf(s), i => NewLookUpGroupId.IndexOf(i), (s, i) => new { NewLookUpGroupId = i, OldLookUpGroupId = s }).ToList();
                            List<long> OldVarId = lstresultVariableExisting.Select(x => x.VariableId).ToList();
                            List<long> NewVarId = lstresultVariableCreated.Select(x => x.VariableId).ToList();
                            var lstVarId = OldVarId.Join(NewVarId, s => OldVarId.IndexOf(s), i => NewVarId.IndexOf(i), (s, i) => new { NewVarId = i, OldVarId = s }).ToList();
                            var lstLookupGroupDetails = (from lg in copyTaxRepo.LookupGroupDetailRepository.GetAll()
                                                         join ld in lstresultlookupgroupExhisting on lg.LookUpGroupId equals ld.LookUpGroupId
                                                         select lg).ToList();
                            foreach (var LookupGroupDetails in lstLookupGroupDetails)
                            {
                                foreach (var LookUpGroupId in lstLookUpGroupId)
                                {
                                    if (LookupGroupDetails.LookUpGroupId == LookUpGroupId.OldLookUpGroupId)
                                    {
                                        LookupGroupDetails.LookUpGroupId = LookUpGroupId.NewLookUpGroupId;
                                    }
                                }
                            }
                            var lstresultLookupGroupDetailToCreate = (from lg in lstLookupGroupDetails
                                                                      join lv in lstresultVariableExisting on lg.VariableId equals lv.VariableId
                                                                      select lg).ToList();
                            foreach (var LookupGroupDetailToCreate in lstresultLookupGroupDetailToCreate)
                            {
                                foreach (var VarId in lstVarId)
                                {
                                    if (LookupGroupDetailToCreate.VariableId == VarId.OldVarId)
                                    {
                                        LookupGroupDetailToCreate.VariableId = VarId.NewVarId;
                                    }
                                }
                            }
                            copyTaxRepo.LookupGroupDetailRepository.AddRange(lstresultLookupGroupDetailToCreate);
                            var lstresultLookUpGDExhisting = (from le in copyTaxRepo.LookupGroupDetailRepository.GetAll()
                                                              join lc in lstresultlookupgroupExhisting on le.LookUpGroupId equals lc.LookUpGroupId
                                                              select le).ToList();
                            var lstresultLookUpGDCreated = (from le in copyTaxRepo.LookupGroupDetailRepository.GetAll()
                                                            join lc in lstresultLookUpGroupCreated on le.LookUpGroupId equals lc.LookUpGroupId
                                                            select le).ToList();
                            var OldGDId = lstresultLookUpGDExhisting.Select(x => x.GroupDetailsId).ToList();
                            var NewGDId = lstresultLookUpGDCreated.Select(x => x.GroupDetailsId).ToList();
                            var lstGDId = OldGDId.Join(NewGDId, s => OldGDId.IndexOf(s), i => NewGDId.IndexOf(i), (s, i) => new { NewGDId = i, OldGDId = s }).ToList();
                            var lstLookupDetailsToCreate = (from ld in copyTaxRepo.LookUpDetailsRepository.GetAll()
                                                            join lgd in lstresultLookUpGDExhisting on ld.GroupDetailsId equals lgd.GroupDetailsId
                                                            select ld).ToList();
                            foreach (var LookupDetailsToCreate in lstLookupDetailsToCreate)
                            {
                                foreach (var GDId in lstGDId)
                                {
                                    if (LookupDetailsToCreate.GroupDetailsId == GDId.OldGDId)
                                    {
                                        LookupDetailsToCreate.GroupDetailsId = GDId.NewGDId;
                                    }
                                }
                            }
                            copyTaxRepo.LookUpDetailsRepository.AddRange(lstLookupDetailsToCreate);
                            //Copy Formula Details
                            List<Formula> lstresultFormulaToCreate = (from f in copyTaxRepo.FormulaRepository.GetAll()
                                                                      join t in lstVarId on f.VariableId equals t.OldVarId
                                                                      select new Formula()
                                                                      {
                                                                          VariableId = t.NewVarId,
                                                                          FormulaDefination = f.FormulaDefination,
                                                                          MinValue = f.MinValue,
                                                                          MaxValue = f.MaxValue,
                                                                          Priority = f.Priority,
                                                                          IsActive = f.IsActive,
                                                                          CreatedBy = resultTaxMasterCreated.CreatedBy,
                                                                          CreatedOn = resultTaxMasterCreated.CreatedOn,
                                                                          UpdatedBy = resultTaxMasterCreated.UpdatedBy,
                                                                          UpdatedOn = resultTaxMasterCreated.UpdatedOn
                                                                      }
                                                                     ).ToList();
                            Formula formulaObj = new Formula();
                            formulaObj.AddFormuladependency(lstresultFormulaToCreate);
                        }
                    }
                    scope.Complete();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        #region Add Copy Tax with tax Version
        /// <summary>
        /// To Copy Tax Details with Tax Version Details
        /// </summary>
        /// <param name="copyTaxValue">List of Tax Details to copy as input </param>
        public string AddCopyTaxWithTaxVersion(List<CopyTaxVersion> copyTaxValue)
        {
            try
            {
                string response = string.Empty;
                using (TransactionScope scope = new TransactionScope())
                {
                    foreach (var item in copyTaxValue)
                    {
                        List<EF.TaxVersion> lstVersiontoChangeStatus = new List<EF.TaxVersion>();
                        using (var copyTaxRepo = new UnitofWork())
                        {
                            if (copyTaxRepo.VariableRepository.Find(x => x.VariableName == item.TaxName).ToList().Count > 0)
                            {
                                throw new InvalidOperationException(Resource.GetResxValueByName("InvalidTaxNamemsg"));
                            }else
                            if( (item.EndDate != "")&&(Convert.ToDateTime(item.StartDate) > Convert.ToDateTime(item.EndDate)))
                            {
                                
                                    throw new InvalidOperationException(Resource.GetResxValueByName("InvalidEndStartCombmsg"));
                            }
                            var taxmasterDetails = copyTaxRepo.TaxMasterRepository.Find(x => x.TaxMasterId == item.TaxMasterId).FirstOrDefault();
                            var exhistingPriority = copyTaxRepo.TaxMasterRepository.Find(x => x.MarketId == taxmasterDetails.MarketId).OrderByDescending(x => x.Priority).Select(x => x.Priority).FirstOrDefault();
                            TaxMaster taxMasterObj = new TaxMaster();
                            response = taxmasterDetails.TaxName;
                            TaxMaster resultTaxMasterToCreate = new TaxMaster()
                            {
                                TaxMasterId = taxmasterDetails.TaxMasterId,
                                TaxName = item.TaxName,
                                MarketId = taxmasterDetails.MarketId,
                                TaxPositionId = taxmasterDetails.TaxPositionId,
                                Priority = (exhistingPriority + 1),
                                IsActive = taxmasterDetails.IsActive,
                                CreatedBy = item.CreatedBy,
                                CreatedOn = DateTime.UtcNow,
                                UpdatedBy = item.CreatedBy,
                                UpdatedOn = DateTime.UtcNow
                            };
                            List<TaxMaster> lstresultTaxMasterExisting = new List<TaxMaster>() { { resultTaxMasterToCreate } };
                            TaxMaster resultTaxMasterCreated = taxMasterObj.AddTaxMaster(lstresultTaxMasterExisting);
                            //Copy Taxversion Details
                            var lstresultTaxVersionExisting = copyTaxRepo.TaxVersionRepository.Find(x => x.TaxVersionId == item.TaxVersionId).ToList();
                            List<TaxVersion> lstresultTaxVersionToCreate = new List<TaxVersion>();
                            foreach (var version in lstresultTaxVersionExisting)
                            {
                                lstresultTaxVersionToCreate.Add(new TaxVersion()
                                {
                                    TaxMasterId = resultTaxMasterCreated.TaxMasterId,
                                    StartDate = item.StartDate,
                                    EndDate = Convert.ToDateTime(item.EndDate == "" ? Helper.sEndDateIfNull : item.EndDate),
                                    IsActive = version.IsActive,
                                    CreatedBy = resultTaxMasterCreated.CreatedBy,
                                    CreatedOn = resultTaxMasterCreated.CreatedOn,
                                    UpdatedBy = resultTaxMasterCreated.CreatedBy,
                                    UpdatedOn = resultTaxMasterCreated.UpdatedOn,
                                    FeatureLevelTax = version.FeatureLevelTax,
                                    TaxVersionStatusId = Helper.iDraft
                                });
                            }
                            List<TaxVersion> lstresultTaxVersionCreated = taxMasterObj.AddTaxVersion(lstresultTaxVersionToCreate);
                            foreach (var version in lstresultTaxVersionCreated)
                            {
                                lstVersiontoChangeStatus.Add(new EF.TaxVersion
                                {
                                    TaxVersionId=version.TaxVersionId,
                                    TaxMasterId= version.TaxMasterId,
                                    StartDate=version.StartDate,
                                    EndDate=version.EndDate,
                                    FeatureLevelTax=version.FeatureLevelTax,
                                    TaxVersionStatusId=item.TaxVersionStatusId,
                                    IsActive=version.IsActive,
                                    CreatedBy = version.CreatedBy,
                                    CreatedOn = version.CreatedOn,
                                    UpdatedBy = version.CreatedBy,
                                    UpdatedOn = version.UpdatedOn
                                });
                            }
                            // Copy Tax details
                            List<long> OldVersionId = lstresultTaxVersionExisting.Select(x => x.TaxVersionId).ToList();
                            List<long> NewVersionId = lstresultTaxVersionCreated.Select(x => x.TaxVersionId).ToList();
                            var lstVersionId = OldVersionId.Join(NewVersionId, s => OldVersionId.IndexOf(s), i => NewVersionId.IndexOf(i), (s, i) => new { NewVersionId = i, OldVersionId = s }).ToList();
                            var lstresultTaxExisting = (from u in copyTaxRepo.TaxRepository.GetAll()
                                                        join tv in lstresultTaxVersionExisting on u.TaxVersionId equals tv.TaxVersionId
                                                        select u).ToList();
                            var lstresultTaxtoCreate = (from te in lstresultTaxExisting
                                                        join ld in lstVersionId on te.TaxVersionId equals ld.OldVersionId
                                                        select new Tax()
                                                        {
                                                            TaxVersionId = ld.NewVersionId,
                                                            TaxFlowId = te.TaxFlowId,
                                                            IsActive = te.IsActive,
                                                            CreatedBy = resultTaxMasterCreated.CreatedBy,
                                                            CreatedOn = resultTaxMasterCreated.CreatedOn,
                                                            UpdatedBy = resultTaxMasterCreated.UpdatedBy,
                                                            UpdatedOn = resultTaxMasterCreated.UpdatedOn
                                                        }).ToList();
                            var lstresultTaxCreated = taxMasterObj.AddTax(lstresultTaxtoCreate);
                            //Copy Language Details
                            List<EF.LanguageDetail> lstExhistingLanguagedetails = copyTaxRepo.LanguageDetailsRepository.Find(x => x.TaxMasterId == taxmasterDetails.TaxMasterId).ToList();
                            foreach (var param in lstExhistingLanguagedetails)
                            {
                                param.TaxMasterId = resultTaxMasterCreated.TaxMasterId;
                                param.CreatedBy = resultTaxMasterCreated.CreatedBy;
                                param.CreatedOn = resultTaxMasterCreated.CreatedOn;
                                param.UpdatedBy = resultTaxMasterCreated.UpdatedBy;
                                param.UpdatedOn = resultTaxMasterCreated.UpdatedOn;
                            }
                           
                            copyTaxRepo.LanguageDetailsRepository.AddRange(lstExhistingLanguagedetails);
                            //Copy Variable Details
                            List<EF.Variable> lstresultVariableExisting = (from v in copyTaxRepo.VariableRepository.GetAll()
                                                                           join t in lstresultTaxExisting on v.TaxId equals t.TaxId
                                                                           select v).ToList();
                            List<long> OldTaxId = lstresultTaxExisting.Select(x => x.TaxId).ToList();
                            List<long> NewTaxId = lstresultTaxCreated.Select(x => x.TaxId).ToList();
                            var lstTaxId = OldTaxId.Join(NewTaxId, s => OldTaxId.IndexOf(s), i => NewTaxId.IndexOf(i), (s, i) => new { NewTaxId = i, OldTaxId = s }).ToList();
                            List<EF.Variable> lstresultVariableToCreate = (from v in copyTaxRepo.VariableRepository.GetAll()
                                                                           join t in lstTaxId on v.TaxId equals t.OldTaxId
                                                                           select new EF.Variable()
                                                                           {
                                                                               TaxId = t.NewTaxId,
                                                                               VariableName = v.VariableName,
                                                                               Value = v.Value,
                                                                               UnitTypeId = v.UnitTypeId,
                                                                               VariableTypeId = v.VariableTypeId,
                                                                               IsActive = v.IsActive,
                                                                               IslookUp = v.IslookUp,
                                                                               CreatedBy = resultTaxMasterCreated.CreatedBy,
                                                                               CreatedOn = resultTaxMasterCreated.CreatedOn,
                                                                               UpdatedBy = resultTaxMasterCreated.UpdatedBy,
                                                                               UpdatedOn = resultTaxMasterCreated.UpdatedOn
                                                                           }
                                                                     ).ToList();
                            copyTaxRepo.VariableRepository.AddRange(lstresultVariableToCreate);
                            List<EF.Variable> lstresultVariableCreated = (from u in copyTaxRepo.VariableRepository.GetAll()
                                                                          join t in lstresultTaxCreated on u.TaxId equals t.TaxId
                                                                          select u).ToList();
                            //Copy Lookup Details
                            var lstresultlookupgroupExhisting = (from lg in copyTaxRepo.LookUpGroupRepository.GetAll()
                                                                 join t in lstresultTaxExisting on lg.TaxId equals t.TaxId
                                                                 select lg).ToList();
                            var lstresultlookupgroupToCreate = (from lg in copyTaxRepo.LookUpGroupRepository.GetAll()
                                                                join t in lstTaxId on lg.TaxId equals t.OldTaxId
                                                                select new EF.LookUpGroup()
                                                                {
                                                                    TaxId = t.NewTaxId,
                                                                    LookUpGroupName = lg.LookUpGroupName,
                                                                    IsActive = lg.IsActive,
                                                                    CreatedBy = resultTaxMasterCreated.CreatedBy,
                                                                    CreatedOn = resultTaxMasterCreated.CreatedOn,
                                                                    UpdatedBy = resultTaxMasterCreated.UpdatedBy,
                                                                    UpdatedOn = resultTaxMasterCreated.UpdatedOn
                                                                }).ToList();
                            copyTaxRepo.LookUpGroupRepository.AddRange(lstresultlookupgroupToCreate);
                            List<EF.LookUpGroup> lstresultLookUpGroupCreated = (from u in copyTaxRepo.LookUpGroupRepository.GetAll()
                                                                                join t in lstresultTaxCreated on u.TaxId equals t.TaxId
                                                                                select u).ToList();
                            List<long> OldLookUpGroupId = lstresultlookupgroupExhisting.Select(x => x.LookUpGroupId).ToList();
                            List<long> NewLookUpGroupId = lstresultLookUpGroupCreated.Select(x => x.LookUpGroupId).ToList();
                            var lstLookUpGroupId = OldLookUpGroupId.Join(NewLookUpGroupId, s => OldLookUpGroupId.IndexOf(s), i => NewLookUpGroupId.IndexOf(i), (s, i) => new { NewLookUpGroupId = i, OldLookUpGroupId = s }).ToList();
                            List<long> OldVarId = lstresultVariableExisting.Select(x => x.VariableId).ToList();
                            List<long> NewVarId = lstresultVariableCreated.Select(x => x.VariableId).ToList();
                            var lstVarId = OldVarId.Join(NewVarId, s => OldVarId.IndexOf(s), i => NewVarId.IndexOf(i), (s, i) => new { NewVarId = i, OldVarId = s }).ToList();
                            var lstLookupGroupDetails = (from lg in copyTaxRepo.LookupGroupDetailRepository.GetAll()
                                                         join ld in lstresultlookupgroupExhisting on lg.LookUpGroupId equals ld.LookUpGroupId
                                                         select lg).ToList();
                            foreach (var LookupGroupDetails in lstLookupGroupDetails)
                            {
                                foreach (var LookUpGroupId in lstLookUpGroupId)
                                {
                                    if (LookupGroupDetails.LookUpGroupId == LookUpGroupId.OldLookUpGroupId)
                                    {
                                        LookupGroupDetails.LookUpGroupId = LookUpGroupId.NewLookUpGroupId;
                                    }
                                }
                            }
                            var lstresultLookupGroupDetailToCreate = (from lg in lstLookupGroupDetails
                                                                      join lv in lstresultVariableExisting on lg.VariableId equals lv.VariableId
                                                                      select lg).ToList();
                            foreach (var LookupGroupDetailToCreate in lstresultLookupGroupDetailToCreate)
                            {
                                foreach (var VarId in lstVarId)
                                {
                                    if (LookupGroupDetailToCreate.VariableId == VarId.OldVarId)
                                    {
                                        LookupGroupDetailToCreate.VariableId = VarId.NewVarId;
                                    }
                                }
                            }
                            copyTaxRepo.LookupGroupDetailRepository.AddRange(lstresultLookupGroupDetailToCreate);
                            var lstresultLookUpGDExhisting = (from le in copyTaxRepo.LookupGroupDetailRepository.GetAll()
                                                              join lc in lstresultlookupgroupExhisting on le.LookUpGroupId equals lc.LookUpGroupId
                                                              select le).ToList();
                            var lstresultLookUpGDCreated = (from le in copyTaxRepo.LookupGroupDetailRepository.GetAll()
                                                            join lc in lstresultLookUpGroupCreated on le.LookUpGroupId equals lc.LookUpGroupId
                                                            select le).ToList();
                            var OldGDId = lstresultLookUpGDExhisting.Select(x => x.GroupDetailsId).ToList();
                            var NewGDId = lstresultLookUpGDCreated.Select(x => x.GroupDetailsId).ToList();
                            var lstGDId = OldGDId.Join(NewGDId, s => OldGDId.IndexOf(s), i => NewGDId.IndexOf(i), (s, i) => new { NewGDId = i, OldGDId = s }).ToList();
                            var lstLookupDetailsToCreate = (from ld in copyTaxRepo.LookUpDetailsRepository.GetAll()
                                                            join lgd in lstresultLookUpGDExhisting on ld.GroupDetailsId equals lgd.GroupDetailsId
                                                            select ld).ToList();
                            foreach (var LookupDetailsToCreate in lstLookupDetailsToCreate)
                            {
                                foreach (var GDId in lstGDId)
                                {
                                    if (LookupDetailsToCreate.GroupDetailsId == GDId.OldGDId)
                                    {
                                        LookupDetailsToCreate.GroupDetailsId = GDId.NewGDId;
                                    }
                                }
                            }
                            copyTaxRepo.LookUpDetailsRepository.AddRange(lstLookupDetailsToCreate);
                           

                            //Copy Formula Details
                            List<Formula> lstresultFormulaToCreate = (from f in copyTaxRepo.FormulaRepository.GetAll()
                                                                      join t in lstVarId on f.VariableId equals t.OldVarId
                                                                      select new Formula()
                                                                      {
                                                                          VariableId = t.NewVarId,
                                                                          FormulaDefination = f.FormulaDefination,
                                                                          MinValue = f.MinValue,
                                                                          MaxValue = f.MaxValue,
                                                                          Priority = f.Priority,
                                                                          IsActive = f.IsActive,
                                                                          CreatedBy = resultTaxMasterCreated.CreatedBy,
                                                                          CreatedOn = resultTaxMasterCreated.CreatedOn,
                                                                          UpdatedBy = resultTaxMasterCreated.UpdatedBy,
                                                                          UpdatedOn = resultTaxMasterCreated.UpdatedOn
                                                                      }
                                                                     ).ToList();
                            Formula formulaObj = new Formula();
                            formulaObj.AddFormuladependency(lstresultFormulaToCreate);
                            //Change taxVersion status Id 
                            List<string> lstField = new List<string>() { "TaxVersionStatusId" };
                            copyTaxRepo.TaxVersionRepository.UpdateRange(lstVersiontoChangeStatus, lstField);
                        }
                    }
                    scope.Complete();
                }
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion


        //public List<string> check(string value)
        //{
        //        List<string> lstcodefromvalue = new List<string>(value.ToUpper().Split(','));

        //    using (var repo =new  UnitofWork())
        //    {
        //        List<string> lstcodefromvalue1 = new List<string>();
        //        var lstcodefromdb = repo.CountryCodeRepository.GetAll().Select(x => x.CountryCode1.ToUpper()).ToList();
        //        foreach (var item in lstcodefromvalue)
        //        {
        //            lstcodefromvalue1.Add(item.TrimStart('\n'));
                  
        //        }
        //        List<string> result = new List<string>();
        //        foreach (var item in lstcodefromvalue1)
        //        {
        //            if (!lstcodefromdb.Contains(item.ToUpper().Trim()))
        //            {
        //                result.Add(item);
        //            }
        //        }
        //    return result;
        //    }
        //}
    }
    public class CopyTaxVersion
    {
        #region  CopyTaxVersion Property
        [JsonProperty(PropertyName = "taxMasterId")]
        public long TaxMasterId { get; set; }
        [JsonProperty(PropertyName = "taxName")]
        public string TaxName { get; set; }
        [JsonProperty(PropertyName = "taxVersionId")]
        public long TaxVersionId { get; set; }
        [JsonProperty(PropertyName = "startDate")]
        public DateTime StartDate { get; set; }
        [JsonProperty(PropertyName = "endDate")]
        public string EndDate { get; set; }
        [JsonProperty(PropertyName = "taxVersionStatusId")]
        public int? TaxVersionStatusId { get; set; }
        [JsonProperty(PropertyName = "createdBy")]
        public string CreatedBy { get; set; }
        #endregion
    }
}