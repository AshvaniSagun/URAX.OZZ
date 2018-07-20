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
using System.Data;
using System.Transactions;
#endregion

namespace UraxUIServiceWebApi.Models
{
    public class LookUpGroup
    {
        #region LookUpGroup Property
        [JsonProperty(PropertyName = "lookUpGroupId")]
        public long LookUpGroupId { get; set; }

        [JsonProperty(PropertyName = "taxId")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "TaxIdReq")]
        public long TaxId { get; set; }

        [JsonProperty(PropertyName = "lookupgroupName")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "LookUpGroupNameReq")]
        public string LookUpGroupName { get; set; }



        [JsonProperty(PropertyName = "isActive")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "IsActiveReq")]
        public bool IsActive { get; set; }

        [JsonProperty(PropertyName = "createdBy")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "CreatedByReq")]
        public string CreatedBy { get; set; }

        [JsonProperty(PropertyName = "createdOn")]
        public System.DateTime CreatedOn { get; set; }

        [JsonProperty(PropertyName = "updatedBy")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "UpdatedByReq")]
        public string UpdatedBy { get; set; }
        public System.DateTime UpdatedOn { get; set; }


        public string VariableIds { get; set; }

        public string RangeTypeId { get; set; }

       
        #endregion

        #region Get All LookUpGroup
        /// <summary>
        /// To Get all LookUp Group Details
        /// </summary>
        /// <returns>List of LookUp Group Details</returns>
        public static List<EF.LookUpGroup> GetLookUpGroup()
        {
            try
            {
                using (var lookupgroup = new UnitofWork())
                {
                    return lookupgroup.LookUpGroupRepository.GetAll().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException( ex.Message);
            }
        }
        #endregion

        #region Get LookUpGroup by Id
        /// <summary>
        /// To get LookUp Group Details by Id
        /// </summary>
        /// <param name="id">An integer which represents LookUp Group Id</param>
        /// <returns>List Of LookUp Group Details</returns>
        public static List<LookUpGroup> GetLookUpGroup(int id)
        {
            List<LookUpGroup> lstLookUpGroup = new List<LookUpGroup>();

            try
            {

                using (var lookupgroup = new UnitofWork())
                {

                    var lstLookUpGroupDetail = lookupgroup.LookupGroupDetailRepository.Find(p => p.LookUpGroupId == id).ToList();
                    var lstVariable = lookupgroup.VariableRepository.GetAll();
                    var lstParameterDetials = lookupgroup.ParameterDetailsRepository.GetAll();
                    var lstLookUpDetails = lookupgroup.LookUpDetailsRepository.GetAll();


                    var result1 = (from lg in lookupgroup.LookUpGroupRepository.GetAll()
                                   join lgd in lstLookUpGroupDetail on lg.LookUpGroupId equals lgd.LookUpGroupId
                                   join v in lstVariable on lgd.VariableId equals v.VariableId
                                   join v1 in lstVariable on lg.TaxId equals v1.TaxId
                                   join pd in lstParameterDetials on v.VariableTypeId equals pd.ParameterId
                                   join ld in lstLookUpDetails on lgd.GroupDetailsId equals ld.GroupDetailsId

                                   select new
                                   {
                                       lg.LookUpGroupId,
                                       lg.TaxId,
                                       lg.LookUpGroupName,
                                       lg.IsActive,
                                       lg.CreatedBy,
                                       lg.CreatedOn,
                                       lg.UpdatedBy,
                                       lg.UpdatedOn,
                                       lgd.GroupDetailsId,
                                       v.VariableId,
                                       ld.Value,
                                       v.VariableName,
                                       pd.ParameterId,
                                       VariableType = pd.Value

                                   }).Distinct().ToList();


                    foreach (var value in result1)
                    {
                        lstLookUpGroup.Add(new LookUpGroup()
                        {
                            LookUpGroupId = (int)value.LookUpGroupId,
                            TaxId = (int)value.TaxId,
                            LookUpGroupName = value.LookUpGroupName.Trim(),
                            IsActive = value.IsActive,
                            CreatedBy = value.CreatedBy,
                            CreatedOn = value.CreatedOn,
                            UpdatedBy = value.UpdatedBy,
                            UpdatedOn = value.UpdatedOn

                        });
                    }


                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException( ex.Message);
            }

            return lstLookUpGroup;
        }
        #endregion

        #region Get LookUpGroup by TaxFlowId
        /// <summary>
        /// To get LookUp Group Details by Tax Flow Id
        /// </summary>
        /// <param name="taxFlowId">An integer which represents Tax Flow id</param>
        /// <returns>List of LookUp group Details</returns>
        internal List<LookUpGrp> GetLookUpGroupByTaxFlowId(int taxFlowId)
        {

            try
            {
                List<LookUpGrp> lookUpgroup = new List<LookUpGrp>();
                using (var lookupgroup = new UnitofWork())
                {
                    var result = lookupgroup.LookUpGroupRepository.Find(x => x.TaxId == taxFlowId).OrderBy(x=>x.LookUpGroupName).ToList();
                    foreach (var data in result)
                    {
                        lookUpgroup.Add(new LookUpGrp()
                        {
                            ID = (int)data.LookUpGroupId,
                            Name = data.LookUpGroupName
                        });
                    }
                }
                return lookUpgroup;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException( ex.Message);
            }


        }
        #endregion




        #region Get Variables for the LookupGroupName
        /// <summary>
        /// To get Variable names by LookupGroupName and Tax Id
        /// </summary>
        /// <param name="taxId">An integer which represents Tax id</param>
        /// /// <param name="lookupgroupname">An string which represents lookupgroupname</param>
        /// <returns>List of Variable name details</returns>
        internal List<LookUpGrpVariable> GetVariableForLookUpGroup(int lookupGroupId)
        {

            try
            {
                List<LookUpGrpVariable> lstvariable = new List<LookUpGrpVariable>();
                using (var lookupgroup = new UnitofWork())
                {
                    var result = lookupgroup.LookUpGroupRepository.Find(x => x.LookUpGroupId == lookupGroupId).ToList();
                    var lookupgroupdetailresult = lookupgroup.LookupGroupDetailRepository.GetAll();
                    var variableresult = lookupgroup.VariableRepository.GetAll();
                  


                    var result1 = (from lg in lookupgroup.LookUpGroupRepository.GetAll()
                                   join lgr in result on lg.LookUpGroupId equals lgr.LookUpGroupId
                                   join lgdr in lookupgroupdetailresult on lgr.LookUpGroupId equals lgdr.LookUpGroupId
                                   join v in variableresult on lgdr.VariableId equals v.VariableId                                  

                                   select new { v.VariableName }).ToList();

                    foreach (var value in result1)
                    {
                        lstvariable.Add(new LookUpGrpVariable()
                        {
                            VariableName = value.VariableName
                        });
                     }


                }
                return lstvariable;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException( ex.Message);
            }


        }
        #endregion

        #region Add LookUpGroup
        /// <summary>
        /// To add LookUp Group Details
        /// </summary>
        /// <param name="lookupgroupValue">LookUp Group Details to Add</param>
        public void AddLookUpGroup(IEnumerable<LookUpGroup> lookupgroupValue)
        {
            try
            {

                using (TransactionScope scope = new TransactionScope())
                {
                    var numbers = lookupgroupValue.FirstOrDefault().VariableIds.Split(',').Select(Int32.Parse).ToList();
                    var rangeIds = lookupgroupValue.FirstOrDefault().RangeTypeId.Split(',').Select(Int32.Parse).ToList();
                   
                    var query = numbers.GroupBy(x => x).Where(g => g.Count() > 1).Select(x => x.Select(y => y.ToString())).ToList();
                   
                    if (query.Count > 0)
                    {
                       
                        throw new InvalidOperationException(Resource.GetResxValueByName("DupVarIdmsg"));

                    }
                  


                    string lookupgroupName = string.Empty;
                    int taxId = 0;
                    using (var lookupgroup = new UnitofWork())
                    {
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            var num = numbers[i];
                            var rangetype = rangeIds[i];
                            var lstVariable = lookupgroup.VariableRepository.Find(x => x.VariableId == num && x.VariableTypeId == Helper.iFixed).ToList();
                            if ((lstVariable.Count > 0) && (rangetype == Helper.iRange))
                            {
                                string VarName = lstVariable.FirstOrDefault().VariableName;
                                throw new InvalidOperationException(VarName + Resource.GetResxValueByName("FixedRangeTypemsg"));
                            }
                        }

                      
                        foreach (var param in lookupgroupValue)
                        {

                            lookupgroupName = param.LookUpGroupName;
                            taxId = (int)param.TaxId;


                            if (lookupgroup.LookUpGroupRepository.Find(x =>  (x.LookUpGroupName == lookupgroupName && x.TaxId == param.TaxId)).ToList().Count > 0)
                            {
                                throw new InvalidOperationException(Resource.GetResxValueByName("LookUpGroupDuplicatemsg"));
                            }
                            else if (lookupgroup.TaxRepository.Find(x => x.TaxId == param.TaxId).ToList().Count == 0)
                            {
                                throw new InvalidOperationException(Resource.GetResxValueByName("InvalidTaxIdmsg"));
                            }
                            

                            List<EF.LookUpGroup> lstlookupgroup = new List<EF.LookUpGroup>();
                            foreach (var item in lookupgroupValue)
                            {
                                lstlookupgroup.Add(new EF.LookUpGroup()
                                {
                                    LookUpGroupId = item.LookUpGroupId,
                                    TaxId = item.TaxId,
                                    LookUpGroupName = item.LookUpGroupName,
                                    IsActive = item.IsActive,
                                    CreatedBy = item.CreatedBy,
                                    CreatedOn = DateTime.UtcNow,
                                    UpdatedBy = item.UpdatedBy,
                                    UpdatedOn = DateTime.UtcNow
                                });
                            }
                            lookupgroup.LookUpGroupRepository.AddRange(lstlookupgroup);

                        }

                    }//Get LookUp GroupID 
                    using (var lookupGroupDetail = new UnitofWork())
                    {

                        var LookUpGroupID = lookupGroupDetail.LookUpGroupRepository.Find(x => x.LookUpGroupName == lookupgroupName && x.TaxId == taxId).Select(x => x.LookUpGroupId).ToList();
                        int Lid = 0;
                        Lid = Convert.ToInt32(LookUpGroupID.FirstOrDefault());

                        try
                        {
                            
                            string UserId = lookupgroupValue.FirstOrDefault().CreatedBy.ToString();
                            List<EF.LookupGroupDetail> lstLookGroupDetails = new List<EF.LookupGroupDetail>();
                            int i = 0;
                            foreach (var data in numbers)
                            {
                                lstLookGroupDetails.Add(new EF.LookupGroupDetail()
                                {
                                    GroupDetailsId = 0,
                                    CreatedBy = UserId,
                                    CreatedOn = DateTime.UtcNow,
                                    LookUpGroupId = Lid,
                                    VariableId = data,
                                    LookupRangeTypeId = rangeIds[i],
                                    IsActive = true,
                                    UpdatedBy = UserId,
                                    UpdatedOn = DateTime.UtcNow

                                });
                                i++;
                            }

                            lookupGroupDetail.LookupGroupDetailRepository.AddRange(lstLookGroupDetails);

                           
                        }
                        catch (Exception)
                        {
                            if (Lid != 0)
                            {
                                DeleteLookUpGroup(Lid);
                            }
                            throw;

                        }
                       
                    }
                   
                    scope.Complete();
                }

            }
            catch (Exception ex)
            {

                throw new InvalidOperationException( ex.Message);
            }

        }
        #endregion

        #region Update LookUpGroup
        /// <summary>
        /// To Update LookUp Group Details
        /// </summary>
        /// <param name="lookupgroupValue">LookUp Group Details to Update</param>
        public void UpdateLookUpGroup(LookUpGrpData lookupgroupValue)
        {
            try
            {

                using (TransactionScope scope = new TransactionScope())
                {
                    
                    List<string> lstField = new List<string>() { "LookUpGroupName" };
                    List<EF.LookUpGroup> lstlookupgroup = new List<EF.LookUpGroup>();
                    using (var lookupgroup = new UnitofWork())
                    {
                        
                            if (lookupgroup.LookUpGroupRepository.Find(x => x.LookUpGroupId == lookupgroupValue.ID ).ToList().Count== 0)
                            {
                                throw new InvalidOperationException(Resource.GetResxValueByName("InvalidLookupGroupIdmsg"));
                            }
                        else if (lookupgroup.TaxRepository.Find(x => x.TaxId == lookupgroupValue.TaxId).ToList().Count == 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("InvalidTaxIdmsg"));
                        }
                        else  if (lookupgroup.LookUpGroupRepository.Find(x =>x.LookUpGroupId!= lookupgroupValue.ID&& x.TaxId == lookupgroupValue.TaxId&& x.LookUpGroupName== lookupgroupValue.Name).ToList().Count > 0)
                            {
                                throw new InvalidOperationException(Resource.GetResxValueByName("LookupGroupNameDuplicatemsg"));
                            }
                           
                                lstlookupgroup.Add(new EF.LookUpGroup()
                                {
                                    LookUpGroupId = lookupgroupValue.ID,
                                    TaxId = lookupgroupValue.TaxId,
                                    LookUpGroupName = lookupgroupValue.Name,
                                    IsActive = true,
                                    CreatedBy = Helper.sDefaultUser,
                                    CreatedOn = DateTime.UtcNow,
                                    UpdatedBy =Helper.sDefaultUser,
                                    UpdatedOn = DateTime.UtcNow
                                });
                         
                    }

                    using (var LookupRepo = new UnitofWork())
                    {
                        LookupRepo.LookUpGroupRepository.UpdateRange(lstlookupgroup, lstField);

                    }
                    scope.Complete();
                }

            }
            catch (Exception ex)
            {

                throw new InvalidOperationException( ex.Message);
            }

        }
        #endregion


        #region Delete LookUpGroup
        /// <summary>
        /// To delete LookUp Groupd details
        /// </summary>
        /// <param name="lookupgroupId">An integer which represents LookUp Group Id</param>
        public void DeleteLookUpGroup(int lookupgroupId)
        {

            try
            {
                using (var lookupgroup = new UnitofWork())
                {
                    List<EF.LookUpGroup> lstlookupgroup  = lookupgroup.LookUpGroupRepository.Find(p => p.LookUpGroupId == lookupgroupId).ToList();
                    if (lstlookupgroup.Count == 0)
                    {
                        throw new InvalidOperationException(Resource.GetResxValueByName("CmnDataNotFound"));
                    }
                    List<EF.LookupGroupDetail> lstlookupgroupdetail = lookupgroup.LookupGroupDetailRepository.Find(p => p.LookUpGroupId == lookupgroupId).ToList();
                    List<EF.LookUpDetail> lstlookupdetails  = (from ld in lookupgroup.LookUpDetailsRepository.GetAll()
                                        join lgd in lstlookupgroupdetail on ld.GroupDetailsId equals lgd.GroupDetailsId
                                        select ld).ToList();
                    lookupgroup.LookUpDetailsRepository.RemoveRange(lstlookupdetails);
                    lookupgroup.LookupGroupDetailRepository.RemoveRange(lstlookupgroupdetail);
                    lookupgroup.LookUpGroupRepository.RemoveRange(lstlookupgroup);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException( ex.Message);
            }

        } 
        #endregion


    }

    public class LookUpGrpVariable
    {
        [JsonProperty(PropertyName = "variableName")]
        public string VariableName { get; set; }
    }

    public class LookUpGrp
    {
        #region LookUpGrp Property
        [JsonProperty(PropertyName = "id")]
        public int ID { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; } 
        #endregion
    }
    public class LookUpGrpData
    {
        #region LookUpGrp Property
        [JsonProperty(PropertyName = "id")]
        public int ID { get; set; }
        public int TaxId { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        #endregion
    }
    public class LookUpGroupList
    {
        #region LookUpGroupList Property
        [JsonProperty(PropertyName = "lookUpGroupId")]
        public long LookUpGroupId { get; set; }


        [JsonProperty(PropertyName = "taxId")]
        public long TaxId { get; set; }

        [JsonProperty(PropertyName = "lookUpGroupName")]
        public string LookUpGroupName { get; set; }

        [JsonProperty(PropertyName = "isActive")]
        public bool IsActive { get; set; }
        [JsonProperty(PropertyName = "lookUpGroupDeatailId")]
        public long LookUpGroupDetailId { get; set; }
        [JsonProperty(PropertyName = "variableId")]
        public long VariableId { get; set; }
        [JsonProperty(PropertyName = "variableName")]
        public string VariableName { get; set; }
        [JsonProperty(PropertyName = "variableType")]
        public string VariableType { get; set; }
        [JsonProperty(PropertyName = "parameterId")]
        public int ParameterId { get; set; }
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; } 
        #endregion
    }
    public class LookupReturn
    {
        #region LookupReturn
        [JsonProperty(PropertyName = "gridHeader")]
        public List<LookupList> GridHeader { get; set; }
        [JsonProperty(PropertyName = "gridData")]
        public DataTable GridData { get; set; }
        [JsonProperty(PropertyName = "gridVariable")]
        public List<GridVariableList> GridVariable { get; set; } 
        #endregion
    }

   
}


