#region NameSpaces
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
using System.Transactions;
using System.Data;
#endregion

namespace UraxUIServiceWebApi.Models
{
    public class LookUpGroupDetails
    {
        #region Property
        [JsonProperty(PropertyName = "lookUpGroupDetailId")]
        public long LookUpGroupDetailId { get; set; }

        [JsonProperty(PropertyName = "lookUpGroupId")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "LookUpGroupIdReq")]
        public long LookUpGroupId { get; set; }

        [JsonProperty(PropertyName = "variableId")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "VariableIdReq")]
        public long VariableId { get; set; }
        [JsonProperty(PropertyName = "variableName")]
        public string VariableName { get; set; }
        [JsonProperty(PropertyName = "variableTypeName")]
        public string VariableTypeName { get; set; }
        [JsonProperty(PropertyName = "lookUpRangeTypeId")]
        public int LookUpRangeTypeId { get; set; }



        [JsonProperty(PropertyName = "isActive")]
        public bool IsActive { get; set; }

        [JsonProperty(PropertyName = "createdBy")]
        public string CreatedBy { get; set; }

        [JsonProperty(PropertyName = "createdOn")]
        public System.DateTime CreatedOn { get; set; }

        [JsonProperty(PropertyName = "updatedBy")]
        public string UpdatedBy { get; set; }
        [JsonProperty(PropertyName = "updatedOn")]
        public System.DateTime UpdatedOn { get; set; }

        #endregion

        #region Get LookUpGroupDetails by LookUpGroupId for MultiList
        /// <summary>
        /// To get LookUp Group Details by LookUp Group Id for MultiList
        /// </summary>
        /// <param name="LookUpGroupId">An integer which represents LookUp Group Id</param>
        /// <returns>List of LookUpList</returns>
        public List<LookupList> GetHeaderbyLookupGroupId(int LookUpGroupId)
        {
            List<LookupList> lstGroupVariableDetails = new List<LookupList>();
            try
            {
                using (var lookupgroupdetail = new UnitofWork())
                {
                    var lstGroup = lookupgroupdetail.LookupGroupDetailRepository.Find(x => x.LookUpGroupId == LookUpGroupId).ToList();
                    if (lstGroup.Count != 0)
                    {
                        int VarId = (int)lstGroup.FirstOrDefault().VariableId;
                        var lstTax = lookupgroupdetail.VariableRepository.Find(x => x.VariableId == VarId).Select(x => x.TaxId).ToList();
                        if (lstTax.Count!=0)
                        {
                            int TaxId = (int)lstTax.FirstOrDefault();
                            var lstVariableType = lookupgroupdetail.ParameterDetailsRepository.Find(x => x.ParameterGroupId == Helper.iVariableType).ToList();

                            var result = (from ld in lookupgroupdetail.VariableRepository.Find(x => x.TaxId == TaxId).ToList()
                                          join t in lstGroup on ld.VariableId equals t.VariableId
                                          join tt in lstVariableType on ld.VariableTypeId equals tt.ParameterId
                                          select new { ld.VariableName, t.VariableId, t.GroupDetailsId, }).ToList();
                            foreach (var data in result)
                            {
                                lstGroupVariableDetails.Add(new LookupList()
                                {
                                    LookUpGroupDetailId = data.GroupDetailsId,
                                    VariableId = data.VariableId,
                                    VariableName = data.VariableName
                                });
                            } 
                        }
                        else
                            return lstGroupVariableDetails;
                    }
                    else
                        return lstGroupVariableDetails;
                }
                return lstGroupVariableDetails;

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException( ex.Message);
            }
        }
        #endregion

        #region Get Dynamic Data by LookupGroupId
        public List<DynamicLookupList> GetDatabyLookupGroupId(int lookupGroupId)
        {
            try
            {
                List<EF.LookupGroupDetail> lstLookupGroupDetail = new List<EF.LookupGroupDetail>();
                using (var lookupdetails =new  UnitofWork())
                {
                    lstLookupGroupDetail = lookupdetails.LookupGroupDetailRepository.Find(x => x.LookUpGroupId == lookupGroupId).ToList();
                    var result = (from lgd in lstLookupGroupDetail
                                  join lg in lookupdetails.LookUpDetailsRepository.GetAll() on lgd.GroupDetailsId equals lg.GroupDetailsId
                                   select new {lgd.VariableId,lg.LookUpId,lg.GroupDetailsId,lg.LookUpGroup,lg.Value }).OrderBy(x=>x.LookUpGroup ).ThenBy(x=>x.VariableId).ToList();
                    List<DynamicLookupList> DataResult = new List<DynamicLookupList>();

                    foreach (var item in result)
                    { 
                        var variablename = lookupdetails.VariableRepository.Find(x => x.VariableId == item.VariableId).Select(x=>x.VariableName).First();
                        DataResult.Add(new DynamicLookupList()
                        {
                            LookUpId = item.LookUpId,
                            LookUpGroupDetailId = item.GroupDetailsId??0,
                            LookUpGroup=item.LookUpGroup,
                            VariableName=variablename,
                            Value=item.Value,
                            VariableId=item.VariableId
                        }
                            );
                    }
                    
                    return DataResult;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion


        #region Get LookUpGroupDetails by LookUpGroupId
        /// <summary>
        /// To get LookUp Group Details by LookUp Group Id
        /// </summary>
        /// <param name="LookUpGroupId">An integer which represents LookUp Group Id</param>
        /// <returns>List of LookUp Group details</returns>
        public List<LookUpGroupDetails> GetLookUpGroupDetailsVariable(int LookUpGroupId)
        {
            List<LookUpGroupDetails> lstGroupVariableDetails = new List<LookUpGroupDetails>();
            try
            {
                using (var lookupgroupdetail = new UnitofWork())
                {
                    var lstGroup = lookupgroupdetail.LookupGroupDetailRepository.Find(x => x.LookUpGroupId == LookUpGroupId).ToList();
                    int VarId = (int)lstGroup.FirstOrDefault().VariableId;
                    var lstTax = lookupgroupdetail.VariableRepository.Find(x => x.VariableId == VarId).Select(x => x.TaxId).ToList();
                    int TaxId = (int)lstTax.FirstOrDefault();
                    var lstVariableType = lookupgroupdetail.ParameterDetailsRepository.Find(x => x.ParameterGroupId == Helper.iVariableType).ToList();

                    var result = (from ld in lookupgroupdetail.VariableRepository.Find(x => x.TaxId == TaxId).ToList()
                                  join t in lstGroup on ld.VariableId equals t.VariableId
                                  join tt in lstVariableType on ld.VariableTypeId equals tt.ParameterId
                                  select new { ld.VariableName, t.VariableId, t.LookUpGroupId, t.GroupDetailsId, t.LookupRangeTypeId, t.UpdatedBy, t.CreatedBy, t.IsActive, tt.Value, t.CreatedOn, t.UpdatedOn }).ToList();
                    foreach (var data in result)
                    {
                        lstGroupVariableDetails.Add(new LookUpGroupDetails()
                        {
                            CreatedBy = data.CreatedBy,
                            CreatedOn = data.CreatedOn,
                            UpdatedOn = data.UpdatedOn,
                            IsActive = data.IsActive,
                            LookUpGroupId = data.LookUpGroupId,
                            VariableId = data.VariableId,
                            UpdatedBy = data.UpdatedBy,
                            VariableName = data.VariableName,
                            VariableTypeName = data.Value,
                            LookUpRangeTypeId = (int)data.LookupRangeTypeId,
                            LookUpGroupDetailId = data.GroupDetailsId
                        });
                    }
                }
                return lstGroupVariableDetails;

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException( ex.Message);
            }
        }
        #endregion

        #region Get All LookUpGroupDetails
        /// <summary>
        /// To get all LookUp Group Details
        /// </summary>
        /// <returns>List of LookUp group Details</returns>
        public  List<EF.LookupGroupDetail> GetLookUpGroupDetail()
        {
            try
            {
                using (var lookupgroupdetail = new UnitofWork())
                {
                    return lookupgroupdetail.LookupGroupDetailRepository.GetAll().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException( ex.Message);
            }
        }
        #endregion

        #region Get LookUpGroup Details by Id
        /// <summary>
        /// To get LookUpGroup details by Id
        /// </summary>
        /// <param name="id">An integer which represents Group Details Id</param>
        /// <returns>List of LookUp Group Details</returns>
        public  List<EF.LookupGroupDetail> GetLookupGroupDetail(int id)
        {
            try
            {
                using (var lookupgroupdetail = new UnitofWork())
                {
                    return lookupgroupdetail.LookupGroupDetailRepository.Find(p => p.GroupDetailsId == id).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException( ex.Message);
            }
        }
        #endregion
    
        #region Get Grid Variable List
        public List<GridVariableList> GetGridVariableDetails(int lookUpGroupId)
        {
            try
            {
                List<EF.LookupGroupDetail> lstLookupGroupDetails = new List<EF.LookupGroupDetail>();
                List<GridVariableList> VariableResult = new List<GridVariableList>();
                using (var lookupdetails = new UnitofWork())
                {
                    lstLookupGroupDetails = lookupdetails.LookupGroupDetailRepository.Find(x => x.LookUpGroupId == lookUpGroupId).ToList();
                    var result = (from lgd in lstLookupGroupDetails
                                  join v in lookupdetails.VariableRepository.GetAll() on lgd.VariableId equals v.VariableId
                                  join p in lookupdetails.ParameterDetailsRepository.GetAll() on lgd.LookupRangeTypeId equals p.ParameterId
                                  select new {lgd.GroupDetailsId,v.VariableName,v.VariableId,p.ParameterId,p.Value ,lgd.CreatedOn,lgd.CreatedBy,lgd.UpdatedBy,lgd.UpdatedOn }).OrderBy(x=>x.VariableName).ToList();
                    foreach (var item in result)
                    {
                        VariableResult.Add(new GridVariableList()
                        {
                            LookUpGroupDetailId = item.GroupDetailsId,
                            VariableName= item.VariableName,
                            VariableId=item.VariableId,
                            LookUpRangeType =item.Value,
                           LookUpRangeId=item.ParameterId,
                            CreatedBy=item.CreatedBy,
                            CreatedOn=item.CreatedOn,
                            UpdatedOn=item.UpdatedOn,
                            UpdatedBy=item.UpdatedBy


                        });
                    }
                    return VariableResult;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region Update Update Grid Variable 
        /// <summary>
        /// To update LookUp Group Details
        /// </summary>
        /// <param name="lookupgroupdetailValue">LookUp Group Details to Update</param>
        /// <returns>List of LookUp Group Details</returns>
        public int UpdateGridVariableValues(IEnumerable<LookUpGroupDetails> lookupgroupdetailValue)
        {
            try
            {
                using (var lookupgroupdetail = new UnitofWork())
                {
                    foreach (var data in lookupgroupdetailValue)
                    {
                        var lstVariable = lookupgroupdetail.VariableRepository.Find(x => x.VariableId == data.VariableId && x.VariableTypeId == Helper.iFixed).ToList();
                        if ((lstVariable.Count > 0) && (data.LookUpRangeTypeId == Helper.iRange))
                        {
                            string VarName = lstVariable.FirstOrDefault().VariableName;
                            throw new InvalidOperationException(VarName + Resource.GetResxValueByName("FixedRangeTypemsg"));
                        }

                        if (lookupgroupdetail.LookupGroupDetailRepository.Find(x => x.GroupDetailsId == data.LookUpGroupDetailId).ToList().Count == 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("CmnDataNotFound"));
                        }else
                        if (lookupgroupdetail.LookupGroupDetailRepository.Find(x =>x.GroupDetailsId!=data.LookUpGroupDetailId && x.LookUpGroupId == data.LookUpGroupId && x.VariableId == data.VariableId).ToList().Count > 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("LookUpGroupDetailDuplicatemsg"));
                        }
                        else
                            if ((data.LookUpRangeTypeId != Helper.iRange) && (data.LookUpRangeTypeId != Helper.iFixedRange))
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("InvalidRangeTypemsg"));
                        }
                        else
                                if (lookupgroupdetail.VariableRepository.Find(x => x.VariableId == data.VariableId).ToList().Count == 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("InvalidVarIdmsg"));
                        }
                        else
                                if (lookupgroupdetail.LookUpGroupRepository.Find(x => x.LookUpGroupId == data.LookUpGroupId).ToList().Count == 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("InvalidlgIdmsg"));
                        }
                   

                    }
                }
                int lugId;
                List<EF.LookupGroupDetail> lstlookupgroupdetail = new List<EF.LookupGroupDetail>();
                List<string> lstField = new List<string>();
                using (var lookuGroupDetailsrepo = new UnitofWork())
                {
                    foreach (var value in lookupgroupdetailValue)
                    { var Count = lookuGroupDetailsrepo.LookUpDetailsRepository.Find(x => x.GroupDetailsId == value.LookUpGroupDetailId).Count();
                        if ((Count > 0) &&
                             (lookuGroupDetailsrepo.LookupGroupDetailRepository.Find(x => x.GroupDetailsId == value.LookUpGroupDetailId).FirstOrDefault().LookupRangeTypeId != value.LookUpRangeTypeId))
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("RangeTypLookUpgroupeMisMatchmsg"));

                        }

                        lstlookupgroupdetail.Add(new EF.LookupGroupDetail()
                        {
                            GroupDetailsId = value.LookUpGroupDetailId,
                            LookUpGroupId = value.LookUpGroupId,
                            VariableId = value.VariableId,
                            LookupRangeTypeId = value.LookUpRangeTypeId,
                            IsActive = value.IsActive,
                            CreatedBy = value.UpdatedBy,
                            CreatedOn = DateTime.UtcNow,
                            UpdatedBy = value.UpdatedBy,
                            UpdatedOn = DateTime.UtcNow

                        });
                    }
                }
                lugId = (int)lookupgroupdetailValue.FirstOrDefault().LookUpGroupId;
                lstField.Add("LookupRangeTypeId");
                lstField.Add("VariableId");
                lstField.Add("UpdatedBy");
                lstField.Add("UpdatedOn");


                using (var lookupgroupdetailobj = new UnitofWork())
                {
                    lookupgroupdetailobj.LookupGroupDetailRepository.UpdateRange(lstlookupgroupdetail, lstField);
                }
                return lugId;
            }


            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }
        }
        #endregion

        #region Add LookUpGroupDetail
        /// <summary>
        /// To add LookUp group details
        /// </summary>
        /// <param name="lookupgroupdetailValue">LookUp Group Details to Add</param>
        /// <returns>An integer which represents LookUp Group Id</returns>
        public long AddGridVariables(IEnumerable<LookUpGroupDetails> lookupgroupdetailValue)
        {

            try
            {
                long lookupgroupid = 0;
                using (TransactionScope scope =new TransactionScope())
                {
                    using (var lookupgroupdetail = new UnitofWork())
                    {
                        
                        foreach (var item in lookupgroupdetailValue)
                        {
                           
                                var lstVariable = lookupgroupdetail.VariableRepository.Find(x => x.VariableId == item.VariableId && x.VariableTypeId == Helper.iFixed).ToList();
                                if ((lstVariable.Count > 0) && (item.LookUpRangeTypeId == Helper.iRange))
                                {
                                    string VarName = lstVariable.FirstOrDefault().VariableName;
                                    throw new InvalidOperationException(VarName + Resource.GetResxValueByName("FixedRangeTypemsg"));
                                }
                            

                            lookupgroupid = item.LookUpGroupId;

                            if (lookupgroupdetail.LookupGroupDetailRepository.Find(x => x.LookUpGroupId == item.LookUpGroupId && x.VariableId == item.VariableId).ToList().Count > 0)
                            {
                                throw new InvalidOperationException(Resource.GetResxValueByName("LookUpGroupDetailDuplicatemsg"));
                            }else
                            if ((item.LookUpRangeTypeId != Helper.iRange) && (item.LookUpRangeTypeId != Helper.iFixedRange))
                            {
                                throw new InvalidOperationException(Resource.GetResxValueByName("InvalidRangeTypemsg"));
                            }else
                                if (lookupgroupdetail.VariableRepository.Find(x=>x.VariableId==item.VariableId).ToList().Count==0)
                            {
                                throw new InvalidOperationException(Resource.GetResxValueByName("InvalidVarIdmsg"));
                            }
                            else
                                if (lookupgroupdetail.LookUpGroupRepository.Find(x => x.LookUpGroupId == item.LookUpGroupId).ToList().Count == 0)
                            {
                                throw new InvalidOperationException(Resource.GetResxValueByName("InvalidlgIdmsg"));
                            }
                        }
                        List<EF.LookupGroupDetail> lstlookupgroupdetail = new List<EF.LookupGroupDetail>();
                        foreach (var item in lookupgroupdetailValue)
                        {
                            lstlookupgroupdetail.Add(new EF.LookupGroupDetail()
                            {
                                GroupDetailsId = item.LookUpGroupDetailId,
                                LookUpGroupId = item.LookUpGroupId,
                                VariableId = item.VariableId,
                                LookupRangeTypeId = item.LookUpRangeTypeId,
                                IsActive = item.IsActive,
                                CreatedBy = item.CreatedBy,
                                CreatedOn = DateTime.UtcNow,
                                UpdatedBy = item.CreatedBy,
                                UpdatedOn = DateTime.UtcNow
                            });
                        }

                        lookupgroupdetail.LookupGroupDetailRepository.AddRange(lstlookupgroupdetail);
                    }

                    using (var lookupgroupRepo = new UnitofWork())
                    {

                        foreach (var item in lookupgroupdetailValue)
                        {

                            long groupDetailsIdFirst = lookupgroupRepo.LookupGroupDetailRepository.Find(x => x.LookUpGroupId == item.LookUpGroupId).Select(x => x.GroupDetailsId).FirstOrDefault();
                            long groupDetailsIdAdd = lookupgroupRepo.LookupGroupDetailRepository.Find(x => x.LookUpGroupId == item.LookUpGroupId && x.VariableId == item.VariableId).Select(x => x.GroupDetailsId).First();
                            List<int> lstLookupGroup = lookupgroupRepo.LookUpDetailsRepository.Find(x => x.GroupDetailsId == groupDetailsIdFirst).Select(x => x.LookUpGroup).ToList();
                            List<EF.LookUpDetail> lstlookup = new List<EF.LookUpDetail>();
                            if (lstLookupGroup.Count!=0)
                            {
                                foreach (var param in lstLookupGroup)
                                {
                                    lstlookup.Add(new EF.LookUpDetail()
                                    {
                                        LookUpGroup = param,
                                        GroupDetailsId = groupDetailsIdAdd,
                                        Value = null,
                                        CreatedBy = item.CreatedBy,
                                        CreatedOn = DateTime.UtcNow,
                                        UpdatedBy = item.CreatedBy,
                                        UpdatedOn = DateTime.UtcNow
                                    }
                                    );

                                }
                            }
                           
                            if (lstlookup.Count!=0)
                            {
                                lookupgroupRepo.LookUpDetailsRepository.AddRange(lstlookup); 
                            }
                        }
                    }
                    scope.Complete();
                }
                return lookupgroupid;

            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }

        }
        #endregion

        #region Delete Grid Variable
        public int DeleteGridVariableDetail(long lookupgroupdetailId)
        {
            try
            {
                
                using (var lookupgroupdetail = new UnitofWork())
                {
                    List<EF.LookupGroupDetail> lstlookupgroupdetail= lookupgroupdetail.LookupGroupDetailRepository.Find(p => p.GroupDetailsId == lookupgroupdetailId).ToList();
                    int lookupgroupId = (int)lstlookupgroupdetail.FirstOrDefault().LookUpGroupId;
                    if (lstlookupgroupdetail.Count == 0)
                    {
                        throw new InvalidOperationException(Resource.GetResxValueByName("CmnDataNotFound"));
                    }
                   
                    List<EF.LookUpDetail> lstlookupdetails= lookupgroupdetail.LookUpDetailsRepository.Find(p => p.GroupDetailsId == lookupgroupdetailId).ToList();
                    lookupgroupdetail.LookUpDetailsRepository.RemoveRange(lstlookupdetails);
                    lookupgroupdetail.LookupGroupDetailRepository.RemoveRange(lstlookupgroupdetail);
                    return lookupgroupId;
                }

               
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException( ex.Message);
            }
        }
        #endregion

        #region Delete LookUpGroupDetail
        /// <summary>
        /// /To delete LookUp Group Details
        /// </summary>
        /// <param name="lookupgroupdetailId">An integer which represents LookUp Group Details Id</param>
        /// <returns></returns>
        public int DeleteLookUpGroupDetail(int lookupgroupdetailId)
        {

            try
            {
                int LookupGrpId = 0;
                using (var lookupgroupdetail = new UnitofWork())
                {

                    List<EF.LookupGroupDetail> lstlookupgroupdetail  = lookupgroupdetail.LookupGroupDetailRepository.Find(p => p.GroupDetailsId == lookupgroupdetailId).ToList();
                    if (lstlookupgroupdetail.Count == 0)
                    {
                        throw new InvalidOperationException(Resource.GetResxValueByName("CmnDataNotFound"));
                    }
                    LookupGrpId = (int)lstlookupgroupdetail.FirstOrDefault().LookUpGroupId;
                    List<EF.LookUpDetail> lstlookupdetails = lookupgroupdetail.LookUpDetailsRepository.Find(p => p.GroupDetailsId == lookupgroupdetailId).ToList();
                    lookupgroupdetail.LookUpDetailsRepository.RemoveRange(lstlookupdetails);
                    lookupgroupdetail.LookupGroupDetailRepository.RemoveRange(lstlookupgroupdetail);
                }
                return LookupGrpId;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException( ex.Message);
            }

        }
        #endregion

        internal List<LookupReturn> GetAllGridDetailsbyLookupGroupId(int LookUpGroupId)
        {
            LookupPivot pivotObj = new LookupPivot();

            List<LookupList> HeaderResult = GetHeaderbyLookupGroupId(LookUpGroupId);
            List<DynamicLookupList> DataResult = GetDatabyLookupGroupId(LookUpGroupId);
            DataTable finalData = pivotObj.GetPivotData(DataResult);
            List<GridVariableList> VariableResult = GetGridVariableDetails(LookUpGroupId);
            List<LookupReturn> result = new List<LookupReturn>() { new LookupReturn() { GridHeader = HeaderResult, GridData = finalData, GridVariable = VariableResult } };
            return result;
        }

    }

    public class LookUpGroupDetailList
    {
        #region LookUpGroup Detail List Property
    
        [JsonProperty(PropertyName = "lookUpGroupDetailId")]
        public long LookUpGroupDetailId { get; set; }


        [JsonProperty(PropertyName = "lookUpGroupId")]
        public long LookUpGroupId { get; set; }

        [JsonProperty(PropertyName = "variableId")]
        public long VariableId { get; set; } 
        #endregion
    }

    public class LookupList
    {
        #region LookupList Property
        [JsonProperty(PropertyName = "lookUpGroupDetailId")]
        public long LookUpGroupDetailId { get; set; }

        [JsonProperty(PropertyName = "variableId")]
        public long VariableId { get; set; }

        [JsonProperty(PropertyName = "variableName")]
        public string VariableName { get; set; } 
        #endregion

    }
    public class DynamicLookupList
    {
        #region DynamicLookupList Property
        [JsonProperty(PropertyName = "lookUpId")]
        public long LookUpId { get; set; }

        [JsonProperty(PropertyName = "lookUpGroup")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "LookUpGroupReq")]
        public int LookUpGroup { get; set; }
        [JsonProperty(PropertyName = "lookUpGrouDetailId")]
        public long LookUpGroupDetailId { get; set; }

        [JsonProperty(PropertyName = "variableId")]
        public long VariableId { get; set; }

        [JsonProperty(PropertyName = "variableName")]
        public string VariableName { get; set; }

        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; } 
        #endregion

    }
    public class LookupGroupInfo
    {

        [JsonProperty(PropertyName = "variableId")]
        public int VariableId { get; set; }
        [JsonProperty(PropertyName = "lookUpGroupId")]
        public long LookUpGroupId { get; set; }
    }
    public class GridVariableList
    {
        #region GridVariableList Property
        [JsonProperty(PropertyName = "lookUpGroupDetailId")]
        public long LookUpGroupDetailId { get; set; }
        [JsonProperty(PropertyName = "variableId")]
        public long VariableId { get; set; }
        [JsonProperty(PropertyName = "variableName")]
        public string VariableName { get; set; }
        [JsonProperty(PropertyName = "lookUpRangeType")]
        public string LookUpRangeType { get; set; }
        [JsonProperty(PropertyName = "lookUpRangeId")]
        public int LookUpRangeId { get; set; }
        [JsonProperty(PropertyName = "createdBy")]
        public string CreatedBy { get; set; }

        [JsonProperty(PropertyName = "createdOn")]
        public System.DateTime CreatedOn { get; set; }

        [JsonProperty(PropertyName = "updatedBy")]
        public string UpdatedBy { get; set; }
        [JsonProperty(PropertyName = "updatedOn")]
        public System.DateTime UpdatedOn { get; set; }
        #endregion
    }
}


