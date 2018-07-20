#region NameSpace
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Transactions;
using UraxUIServiceWebApi.Repository;
using UraxUIServiceWebApi.ResourceFiles;
#endregion

namespace UraxUIServiceWebApi.Models
{
    public class LookUpDetail
    {
        #region LookUpDetail Property
        [JsonProperty(PropertyName = "lookUpId")]
        public long LookUpId { get; set; }

        [JsonProperty(PropertyName = "lookUpGroup")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "LookUpGroupReq")]
        public int LookUpGroup { get; set; }

        [JsonProperty(PropertyName = "lookUpGroupDetailId")]
        public long LookUpGroupDetailId { get; set; }



        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        [JsonProperty(PropertyName = "createdBy")]
        //   [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "CreatedByReq")]
        public string CreatedBy { get; set; }

        [JsonProperty(PropertyName = "createdOn")]

        public System.DateTime CreatedOn { get; set; }

        [JsonProperty(PropertyName = "updatedBy")]
        //   [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "UpdatedByReq")]
        public string UpdatedBy { get; set; }
        [JsonProperty(PropertyName = "updatedOn")]

        public System.DateTime UpdatedOn { get; set; }
        #endregion

        #region Get All LookUp Details
        /// <summary>
        /// To get all LookUp Details
        /// </summary>
        /// <returns>List of LookUp Details</returns>
        public static List<EF.LookUpDetail> GetLookUpDetail()
        {
            try
            {
                using (var lookupdetail = new UnitofWork())
                {
                    return lookupdetail.LookUpDetailsRepository.GetAll().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error while loading Data. Error : " + ex.Message);
            }
        }
        #endregion

        #region Get LookUp Details by Id
        /// <summary>
        /// To get LookUp Details by Id
        /// </summary>
        /// <param name="id">An integer which represents LookUp Id</param>
        /// <returns>List pf LookUp Details</returns>
        public static List<EF.LookUpDetail> GetLookUpDetail(int id)
        {
            try
            {
                using (var lookupdetail = new UnitofWork())
                {
                    return lookupdetail.LookUpDetailsRepository.Find(p => p.LookUpId == id).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        #endregion

        #region Update LookUp details
        /// <summary>
        /// To update LookUp Details
        /// </summary>
        /// <param name="lookupdetailValue">LookUp Details to update</param>
        /// <returns>List of updated LookUp Details</returns>
        public List<EF.LookUpDetail> UpdateLookUpDetail(IEnumerable<LookUpDetail> lookupdetailValue)
        {
            try
            {
                using (var lookupdetail = new UnitofWork())
                {
                    foreach (var data in lookupdetailValue)
                    {
                        long luId = data.LookUpId;
                        //var TaxId = (from u in lookupdetail.LookUpGroupRepository.GetAll()
                        //             join lgd in lookupdetail.LookupGroupDetailRepository.GetAll() on u.LookUpGroupId equals lgd.LookUpGroupId
                        //             join l in lookupdetail.LookUpDetailsRepository.Find(x => x.LookUpId == luId) on lgd.GroupDetailsId equals l.GroupDetailsId
                        //             select u.TaxId).FirstOrDefault();
                        //int Id = (int)(from u in lookupdetail.TaxVersionRepository.GetAll()
                        //               join t in lookupdetail.TaxRepository.Find(x => x.TaxId == TaxId).ToList() on u.TaxVersionId equals t.TaxVersionId
                        //               select u.TaxVersionStatusId).FirstOrDefault();
                        //if (Id == 31)
                        //{
                        //    throw new InvalidOperationException(Resource.GetResxValueByName("PublishedLookupmsg"));

                        //}

                        if (lookupdetail.LookUpDetailsRepository.Find(x => x.LookUpId == luId).ToList().Count == 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("CmnDataNotFound"));
                        }
                        else
                            if (lookupdetail.LookUpGroupRepository.Find(x => x.LookUpGroupId == data.LookUpGroupDetailId).ToList().Count == 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("InvalidGroupDetailsIdmsg"));
                        }

                    }
                }

                List<EF.LookUpDetail> lstlookupdetail = new List<EF.LookUpDetail>();
                List<string> lstField = new List<string>();
                foreach (var value in lookupdetailValue)
                {
                    using (var lookupdetail = new UnitofWork())
                    {
                        //Add for validations
                        var variablelst = lookupdetail.LookupGroupDetailRepository.Find(x => x.GroupDetailsId == value.LookUpGroupDetailId).ToList();
                        int? VariableTypeId = variablelst.Find(x => x.GroupDetailsId == value.LookUpGroupDetailId).LookupRangeTypeId;
                        int? VariableId = (int)variablelst.Find(x => x.GroupDetailsId == value.LookUpGroupDetailId).VariableId;
                        bool firstRecords = false;
                        string lstResult = "";
                        int? UnitTypeId = 0;
                        try
                        {
                            lstResult = lookupdetail.LookUpDetailsRepository.Find(x => x.GroupDetailsId == value.LookUpGroupDetailId && x.LookUpId != LookUpId).OrderBy(x => x.LookUpGroup).FirstOrDefault().Value;
                            UnitTypeId = lookupdetail.VariableRepository.Find(x => x.VariableId == VariableId).FirstOrDefault().UnitTypeId;
                        }
                        catch (Exception)
                        {
                            firstRecords = true;
                        }

                        string sts = LookUpDetail.CheckLookUpValue(value.Value, VariableTypeId, UnitTypeId, firstRecords, lstResult);
                        if (sts != Helper.sSuccess)
                        {
                            throw new InvalidOperationException(sts);
                        }
                    }
                    //
                    lstlookupdetail.Add(new EF.LookUpDetail()
                    {
                        LookUpId = value.LookUpId,
                        LookUpGroup = value.LookUpGroup,
                        GroupDetailsId = value.LookUpGroupDetailId,
                        Value = value.Value.Trim(),
                        CreatedBy = value.CreatedBy,
                        CreatedOn = value.CreatedOn,
                        UpdatedBy = value.UpdatedBy,
                        UpdatedOn = DateTime.UtcNow
                    });
                }

                lstField.Add("LookUpGroup");
                lstField.Add("Value");
                lstField.Add("UpdatedBy");
                lstField.Add("UpdatedOn");


                using (var lookupdetailobj = new UnitofWork())
                {
                    lookupdetailobj.LookUpDetailsRepository.UpdateRange(lstlookupdetail, lstField);
                }
                return lstlookupdetail;
            }


            catch (Exception ex)
            {

                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }
        }
        #endregion

        #region Post Grid Data
        public long PostGridValues(List<LookUpList> lookupdetailsdata)
        {
            try
            {

                using (var lookupdetail = new UnitofWork())
                {
                    using (TransactionScope scope = new TransactionScope())
                    {

                        List<LookUpData> lstLookUpData = new List<LookUpData>();
                        foreach (var item in lookupdetailsdata)
                        {
                            lstLookUpData.AddRange(item.DataList);
                        }
                        var data = lstLookUpData.FirstOrDefault();
                        var GrpdDetId = lookupdetail.LookupGroupDetailRepository.Find(x => x.LookUpGroupId == data.LookUpGroupId && x.VariableId == data.VariableId).Select(x => x.GroupDetailsId).FirstOrDefault();
                        var LookupGroupId = lookupdetail.LookupGroupDetailRepository.Find(x => x.GroupDetailsId == GrpdDetId).Select(x => x.LookUpGroupId).FirstOrDefault();
                        List<EF.LookupGroupDetail> lstlookupgroupdetails = lookupdetail.LookupGroupDetailRepository.Find(x => x.LookUpGroupId == LookupGroupId).ToList();
                        List<EF.LookUpDetail> lstlookupdetails = lookupdetail.LookUpDetailsRepository.GetAll().OrderByDescending(x => x.LookUpGroup).ToList();
                        List<EF.LookUpDetail> result = (from lg in lstlookupgroupdetails
                                                        join ld in lstlookupdetails
                                                        on lg.GroupDetailsId equals ld.GroupDetailsId
                                                        select ld).ToList();
                        var lastrownumber = result.Select(x => x.LookUpGroup).FirstOrDefault();
                        lastrownumber = lastrownumber + 1;
                        LookUpGroupDetails lookupGroupDetailsObj = new LookUpGroupDetails();
                        List<DynamicLookupList> DataResult = lookupGroupDetailsObj.GetDatabyLookupGroupId((int)lstLookUpData[0].LookUpGroupId);
                        var dat = DataResult.OrderBy(x => x.LookUpGroup).GroupBy(x => x.LookUpGroup).ToList();
                        var lstinput = (from u in lstLookUpData select new { value = u.Value, varId = u.VariableId }).ToList();
                        foreach (var item in dat)
                        {
                            var lst = (from u in item select new { value = u.Value, varId = u.VariableId }).ToList();
                            if (lst.Count != 0)
                            {
                                int i = 0;
                                foreach (var input in lstinput)
                                {
                                    foreach (var param in lst)
                                    {
                                        if (param.value == input.value && param.varId == input.varId)
                                        {
                                            i++;
                                        }
                                    }
                                }

                                if (lst.Count == i)
                                {
                                    throw new InvalidOperationException(Resource.GetResxValueByName("DuplicateRowDatamsg"));

                                }
                            }
                        }
                        foreach (var parameter in lstLookUpData)
                        {

                            long GroupdDetailsId = 0;
                            GroupdDetailsId = lookupdetail.LookupGroupDetailRepository.Find(x => x.LookUpGroupId == parameter.LookUpGroupId && x.VariableId == parameter.VariableId).Select(x => x.GroupDetailsId).FirstOrDefault();
                            if (GroupdDetailsId == 0)
                            {
                                throw new InvalidOperationException(Resource.GetResxValueByName("InvalidGroupDetailsIdmsg"));
                            }

                            //Add for validations
                            var variablelst = lookupdetail.LookupGroupDetailRepository.Find(x => x.GroupDetailsId == GroupdDetailsId).ToList();
                            int? VariableTypeId = variablelst.Find(x => x.GroupDetailsId == GroupdDetailsId).LookupRangeTypeId;
                            bool firstRecords = false;
                            string lstResult = "";
                            int? UnitTypeId = 0;
                            try
                            {
                                lstResult = lookupdetail.LookUpDetailsRepository.Find(x => x.GroupDetailsId == GroupdDetailsId).OrderBy(x => x.LookUpGroup).FirstOrDefault().Value;
                                UnitTypeId = lookupdetail.VariableRepository.Find(x => x.VariableId == parameter.VariableId).FirstOrDefault().UnitTypeId;
                            }
                            catch (Exception)
                            {
                                firstRecords = true;
                            }

                            string sts = LookUpDetail.CheckLookUpValue(parameter.Value, VariableTypeId, UnitTypeId, firstRecords, lstResult);
                            if (sts != Helper.sSuccess)
                            {
                                throw new InvalidOperationException(sts);
                            }
                            //

                            List<EF.LookUpDetail> lstLookUpDetail = new List<EF.LookUpDetail>() {new EF.LookUpDetail() {
                                 LookUpId=parameter.LookUpId,
                                LookUpGroup = lastrownumber,
                                GroupDetailsId = GroupdDetailsId,
                                Value = parameter.Value.Trim(),
                                CreatedBy = parameter.LoginUser,
                                CreatedOn = DateTime.UtcNow,
                                UpdatedBy = parameter.LoginUser,
                                UpdatedOn = DateTime.UtcNow,

                            } };


                            lookupdetail.LookUpDetailsRepository.AddRange(lstLookUpDetail);
                        }
                        scope.Complete();
                        return LookupGroupId;
                    }

                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Update GridData
        public int UpdateGridData(List<LookUpList> lookupdetailsdata)
        {
            try
            {
                List<EF.LookUpDetail> lstLookUpDetail = new List<EF.LookUpDetail>();
                using (var lookupdetail = new UnitofWork())
                {

                    List<LookUpData> lstLookUpData = new List<LookUpData>();
                    foreach (var item in lookupdetailsdata)
                    {
                        lstLookUpData.AddRange(item.DataList);
                    }
                    foreach (var parameter in lstLookUpData)
                    {

                        long GroupDetailsId = 0;
                        GroupDetailsId = lookupdetail.LookupGroupDetailRepository.Find(x => x.LookUpGroupId == parameter.LookUpGroupId && x.VariableId == parameter.VariableId).Select(x => x.GroupDetailsId).FirstOrDefault();
                        long LookUpIdresult = (from lgd in lookupdetail.LookupGroupDetailRepository.Find(x => x.LookUpGroupId == parameter.LookUpGroupId).ToList()
                                               join lu in lookupdetail.LookUpDetailsRepository.GetAll() on lgd.GroupDetailsId equals lu.GroupDetailsId
                                               where lu.LookUpGroup == parameter.LookUpGroup && lgd.LookUpGroupId == parameter.LookUpGroupId && lu.GroupDetailsId == GroupDetailsId
                                               select lu.LookUpId).FirstOrDefault();
                        if (GroupDetailsId == 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("InvalidGroupDetailsIdmsg"));
                        }
                        else if (lookupdetail.LookUpDetailsRepository.Find(x => (x.LookUpId == LookUpIdresult) && (x.LookUpGroup == parameter.LookUpGroup) && (x.GroupDetailsId == GroupDetailsId)).ToList().Count == 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("CmnDataNotFound"));
                        }

                        //Add for validations
                        var variablelst = lookupdetail.LookupGroupDetailRepository.Find(x => x.GroupDetailsId == GroupDetailsId).ToList();
                        int? VariableTypeId = variablelst.Find(x => x.GroupDetailsId == GroupDetailsId).LookupRangeTypeId;
                        bool firstRecords = false;
                        int? UnitTypeId = 0;
                        string lstResult = "";
                        try
                        {
                            lstResult = lookupdetail.LookUpDetailsRepository.Find(x => x.GroupDetailsId == GroupDetailsId).OrderBy(x => x.LookUpGroup).FirstOrDefault().Value;
                            UnitTypeId = lookupdetail.VariableRepository.Find(x => x.VariableId == parameter.VariableId).FirstOrDefault().UnitTypeId;
                        }
                        catch (Exception)
                        {
                            firstRecords = true;
                        }

                        string sts = LookUpDetail.CheckLookUpValue(parameter.Value, VariableTypeId, UnitTypeId, firstRecords, lstResult);
                        if (sts != Helper.sSuccess)
                        {
                            throw new InvalidOperationException(sts);
                        }
                        //

                        LookUpGroupDetails lookupGroupDetailsObj = new LookUpGroupDetails();
                        List<DynamicLookupList> DataResult = lookupGroupDetailsObj.GetDatabyLookupGroupId((int)lstLookUpData[0].LookUpGroupId);
                        long lookupgroup = lstLookUpData[0].LookUpGroup;
                        var itemToRemove = (from u in DataResult where u.LookUpGroup == lookupgroup select u).ToList();
                        foreach (var paramter in itemToRemove)
                        {
                            DataResult.Remove(paramter);
                        }
                        var dat = DataResult.OrderBy(x => x.LookUpGroup).GroupBy(x => x.LookUpGroup).ToList();

                        var lstinput = (from u in lstLookUpData select new { value = u.Value, varId = u.VariableId }).ToList();
                        foreach (var item in dat)
                        {
                            var lst = (from u in item select new { value = u.Value, varId = u.VariableId }).ToList();
                            if (lst.Count != 0)
                            {
                                int i = 0;
                                foreach (var input in lstinput)
                                {
                                    foreach (var param in lst)
                                    {
                                        if (param.value == input.value && param.varId == input.varId)
                                        {
                                            i++;
                                        }
                                    }
                                }

                                if (lst.Count == i)
                                {
                                    throw new InvalidOperationException(Resource.GetResxValueByName("DuplicateRowDatamsg"));

                                }
                            }
                        }
                        lstLookUpDetail.Add(new EF.LookUpDetail()
                        {
                            LookUpId = LookUpIdresult,
                            LookUpGroup = parameter.LookUpGroup,
                            GroupDetailsId = (long)GroupDetailsId,
                            Value = parameter.Value.Trim(),
                            CreatedBy = parameter.LoginUser,
                            CreatedOn = DateTime.UtcNow,
                            UpdatedBy = parameter.LoginUser,
                            UpdatedOn = DateTime.UtcNow,


                        });

                    }



                }


                List<string> lstField = new List<string>() { "Value", "UpdatedBy", "UpdatedOn" };



                using (TransactionScope scope = new TransactionScope())
                {
                    using (var lookupdetailobj = new UnitofWork())
                    {
                        lookupdetailobj.LookUpDetailsRepository.UpdateRange(lstLookUpDetail, lstField);
                    }
                    scope.Complete();
                }

                int LookUpGroupId = (int)lookupdetailsdata[0].DataList[0].LookUpGroupId;

                return LookUpGroupId;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Delete  Grid Data
        /// <summary>
        /// To delete LookUp Details  by RowId
        /// </summary>
        /// <param name="lookupGroupRow">An integer which represents LookUpGroup</param>
        public void DeleteGridData(LookupGroupData lookupGroupRow)
        {

            try
            {
                using (var lookupdetail = new UnitofWork())
                {


                    List<EF.LookUpDetail> lstlookupdetail = new List<EF.LookUpDetail>();
                    List<long> lstGroupDetailsId = lookupdetail.LookupGroupDetailRepository.Find(x => x.LookUpGroupId == lookupGroupRow.LookUpGroupId).Select(x => x.GroupDetailsId).ToList();
                    foreach (var item in lstGroupDetailsId)
                    {
                        EF.LookUpDetail lookupdetails = lookupdetail.LookUpDetailsRepository.Find(x => x.GroupDetailsId == item && x.LookUpGroup == lookupGroupRow.LookUpGroup).FirstOrDefault();
                        if (lookupdetails != null)
                        {
                            lstlookupdetail.Add(lookupdetails);
                        }
                    }
                    if (lstlookupdetail.Count == 0)
                    {
                        throw new InvalidOperationException(Resource.GetResxValueByName("CmnDataNotFound"));
                    }
                    lookupdetail.LookUpDetailsRepository.RemoveRange(lstlookupdetail);


                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }

        }
        #endregion

        #region Add LookUp Details
        /// <summary>
        /// To add LookUp Details
        /// </summary>
        /// <param name="lookupdetailValue">LookUp Details to add</param>
        public void AddLookUpDetail(IEnumerable<LookUpDetail> lookupdetailValue)
        {

            try
            {
                using (var lookupdetail = new UnitofWork())
                {
                    foreach (var item in lookupdetailValue)
                    {

                        if (lookupdetail.LookupGroupDetailRepository.Find(x => x.GroupDetailsId == item.LookUpGroupDetailId).ToList().Count == 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("InvalidGroupDetailsIdmsg"));
                        }
                    }


                    List<EF.LookUpDetail> lstlookupdetail = new List<EF.LookUpDetail>();
                    foreach (var item in lookupdetailValue)
                    {
                        //Add for validations
                        var variablelst = lookupdetail.LookupGroupDetailRepository.Find(x => x.GroupDetailsId == item.LookUpGroupDetailId).ToList();
                        int? VariableTypeId = variablelst.Find(x => x.GroupDetailsId == item.LookUpGroupDetailId).LookupRangeTypeId;
                        int? VariableId = (int)variablelst.Find(x => x.GroupDetailsId == item.LookUpGroupDetailId).VariableId;
                        bool firstRecords = false;
                        string lstResult = "";
                        int? UnitTypeId = 0;
                        try
                        {
                            lstResult = lookupdetail.LookUpDetailsRepository.Find(x => x.GroupDetailsId == item.LookUpGroupDetailId).OrderBy(x => x.LookUpGroup).FirstOrDefault().Value;
                            UnitTypeId = lookupdetail.VariableRepository.Find(x => x.VariableId == VariableId).FirstOrDefault().UnitTypeId;
                        }
                        catch (Exception)
                        {
                            firstRecords = true;
                        }

                        string sts = LookUpDetail.CheckLookUpValue(item.Value, VariableTypeId, UnitTypeId, firstRecords, lstResult);
                        if (sts != Helper.sSuccess)
                        {
                            throw new InvalidOperationException(sts);
                        }
                        //
                        lstlookupdetail.Add(new EF.LookUpDetail()
                        {
                            LookUpId = item.LookUpId,
                            LookUpGroup = item.LookUpGroup,
                            GroupDetailsId = item.LookUpGroupDetailId,
                            Value = item.Value.Trim(),
                            CreatedBy = item.CreatedBy,
                            CreatedOn = DateTime.UtcNow,
                            UpdatedBy = item.UpdatedBy,
                            UpdatedOn = DateTime.UtcNow
                        });
                    }

                    lookupdetail.LookUpDetailsRepository.AddRange(lstlookupdetail);
                }

            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }

        }
        #endregion
        public static string CheckLookUpValue(string value, int? variableType, int? UnitTypeId, bool isFirstRecords = true, string firstvalue = "")
        {
            string sts = Helper.sSuccess;
            value = value.Trim(); //trim white space
            //Check variable type Range or Fixed
            if (Helper.iRange == variableType)
            {
                //Range format 0-0
                string[] values = value.Split('-');
                //check values count ==2
                if (values.Count() != 2)
                {
                    return "Value should be in range (ex: 0-10 )";
                }
                else if (!Common.IsNumeric(values[0]))
                {
                    return "Value should be in range format  and numeric (ex: 0-10 )";
                }
                else if (!Common.IsNumeric(values[1]))
                {
                    return "Value should be in range format  and numeric (ex: 0-10 )";
                }
            }
            else if (Helper.iFixedRange == variableType)
            {

                //check first variable is string  or numeric
                if (isFirstRecords)
                {
                    return sts;
                }
                else
                {
                    //bring the datatype of variable if text then text else numeric
                    //*************************************************//
                    //  ParameterID  ParameterGroupID  Value           //
                    //  11	                5	        %              //
                    //  14                  5           NULL           //
                    //  18                  5           Numeric        //
                    //  19                  5           Money          //
                    //  20                  5           Text           //
                    // ************************************************//
                    //check first value is numeric or string//
                    bool numericval = Common.IsNumeric(firstvalue);
                    if (UnitTypeId == 18 || UnitTypeId == 19)
                    {
                        //check value is numeric or not
                        if (!Common.IsNumeric(value))
                            return "Value should be numeric.";
                    }
                    else if (UnitTypeId == 20)
                    {
                        //check value is alpha numeric
                        if (!Common.isAlphaNumeric(value))
                            return "Value should be string.";
                    }

                }

            }
            return sts;
        }

        #region Delete LookUp Details
        /// <summary>
        /// To delete LookUp Details
        /// </summary>
        /// <param name="lookupdetailId">An integer which representsLookUp Details Id</param>
        public void DeleteLookUpDetail(int lookupdetailId)
        {

            try
            {
                using (var lookupdetail = new UnitofWork())
                {


                    List<EF.LookUpDetail> lstlookupdetail = new List<EF.LookUpDetail>();
                    lstlookupdetail = lookupdetail.LookUpDetailsRepository.Find(p => p.LookUpId == lookupdetailId).ToList();
                    if (lstlookupdetail.Count == 0)
                    {
                        throw new InvalidOperationException(Resource.GetResxValueByName("CmnDataNotFound"));
                    }


                    List<EF.LookupGroupDetail> lstlookupgroupdetails = (from lgd in lookupdetail.LookupGroupDetailRepository.GetAll()
                                                                        join ld in lstlookupdetail on lgd.GroupDetailsId equals ld.GroupDetailsId
                                                                        select lgd).ToList();

                    List<EF.LookUpGroup> lstlookupgroup = (from lg in lookupdetail.LookUpGroupRepository.GetAll()
                                                           join lgd in lstlookupgroupdetails on lg.LookUpGroupId equals lgd.LookUpGroupId
                                                           select lg).ToList();




                    lookupdetail.LookUpDetailsRepository.RemoveRange(lstlookupdetail);
                    lookupdetail.LookupGroupDetailRepository.RemoveRange(lstlookupgroupdetails);
                    lookupdetail.LookUpGroupRepository.RemoveRange(lstlookupgroup);

                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }

        }
        #endregion


    }



    public class LookupGroupData
    {

        [JsonProperty(PropertyName = "lookUpGroup")]
        public int LookUpGroup { get; set; }
        [JsonProperty(PropertyName = "lookUpGroupId")]
        public long LookUpGroupId { get; set; }
    }
    public class LookUpList
    {
        [JsonProperty(PropertyName = "dataList")]
        public List<LookUpData> DataList { get; set; }
    }
    public class LookUpData
    {
        [JsonProperty(PropertyName = "lookUpId")]
        public long LookUpId { get; set; }
        [JsonProperty(PropertyName = "lookUpGroupId")]
        public long LookUpGroupId { get; set; }

        [JsonProperty(PropertyName = "lookUpGroup")]
        public int LookUpGroup { get; set; }
        [JsonProperty(PropertyName = "variableId")]
        public int VariableId { get; set; }
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
        [JsonProperty(PropertyName = "LoginUser")]
        public string LoginUser { get; set; }

    }


    public class LookUpDetailList
    {
        #region LookUp Details List Property
        [JsonProperty(PropertyName = "luid")]
        public long LookUpId { get; set; }


        [JsonProperty(PropertyName = "lg")]
        public int LookUpGroup { get; set; }

        [JsonProperty(PropertyName = "ludId")]
        public long LookUpGroupDetailId { get; set; }

        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
        #endregion
    }
}