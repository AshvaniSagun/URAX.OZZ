#region NameSpace
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using UraxUIServiceWebApi.Repository;
using UraxUIServiceWebApi.ResourceFiles;
using UraxUIServiceWebApi.Controllers;
using System.Transactions;
using System.Text.RegularExpressions;
#endregion

namespace UraxUIServiceWebApi.Models
{
    public class Variable
    {
        #region Variable Property
        [JsonProperty(PropertyName = "variableId")]
        public long VariableId { get; set; }
        [JsonProperty(PropertyName = "taxId")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "TaxIdReq")]
        public long TaxId { get; set; }
        [JsonProperty(PropertyName = "variableName")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "VariableNameReq")]
        public string VariableName { get; set; }

        [JsonProperty(PropertyName = "variableValue")]
        public Nullable<decimal> VariableValue { get; set; }
        [JsonProperty(PropertyName = "testValue")]
        public string TestValue { get; set; }
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "UnitTypeIdReq")]
        [JsonProperty(PropertyName = "unitTypeId")]
        public int UnitTypeId { get; set; }
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "VariableTypeIdReq")]
        [JsonProperty(PropertyName = "variableTypeId")]
        public int VariableTypeId { get; set; }
        [JsonProperty(PropertyName = "isLookup")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "IsLookUpReq")]
        public bool IsLookUp { get; set; }
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
        [JsonProperty(PropertyName = "unitTypeName")]
        public string UnitTypeName { get; set; }
        [JsonProperty(PropertyName = "variableTypeName")]
        public string VariableTypeName { get; set; }
        [JsonProperty(PropertyName = "taxFlowValue")]
        public string TaxFlowValue { get; set; }
        #endregion
        #region Get All Varable Details
        /// <summary>
        /// To get all Variable Details
        /// </summary>
        /// <returns>List  of Variables</returns>
        public  List<EF.Variable> GetVariable()
        {
            try
            {
                using (var variable = new UnitofWork())
                {
                    return variable.VariableRepository.GetAll().OrderBy(x=>x.VariableName).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        #endregion

        #region Get Variable Details by Variable Id
        /// <summary>
        /// To get Variable details by Varaible Id
        /// </summary>
        /// <param name="id">An integer which represents Variable Id</param>
        /// <returns>List of Variables</returns>
        public  List<EF.Variable> GetVariable(int id)
        {
            try
            {
                using (var variable = new UnitofWork())
                {
                    return variable.VariableRepository.Find(p => p.VariableId == id).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        #endregion
       readonly ParameterDetails parameterDetaisObj = new ParameterDetails();

        #region Update Variable Details
        /// <summary>
        /// to update Variable Details
        /// </summary>
        /// <param name="variableValue">List Variable Details to update</param>
        /// <returns>List of updated variable Details</returns>
        public List<EF.Variable> UpdateVariable(IEnumerable<Variable> variableValue)
        {
            try
            {
                 List<EF.Variable> lstvariable = new List<EF.Variable>();
                List<string> lstField = new List<string>();
                using (TransactionScope scope = new TransactionScope())
                {
                    List<string> OperatorsList = new List<string>(Resource.GetResxValueByName("OperatorsList").Split(','));
                    List<string> MasterVariableList = new List<string>(Resource.GetResxValueByName("MasterVariableList").Split(','));

                    using (var variable = new UnitofWork())
                    {
                        foreach (var data in variableValue)
                        {
                            long vId = data.VariableId;
                            var parameterlst = parameterDetaisObj.GetInputParameter((int)data.TaxId, 7);
                            List<string> RestrictedInputVariables = parameterlst.Select(x => x.VariableName.ToUpper().Replace(" ", "")).ToList();
                            string VarNameWithoutSpace = data.VariableName.Replace(" ", "");


                            int Id = (int)(from u in variable.TaxVersionRepository.GetAll()
                                      join t in variable.TaxRepository.Find(x => x.TaxId == data.TaxId).ToList() on u.TaxVersionId equals t.TaxVersionId
                                      select u.TaxVersionStatusId).FirstOrDefault();
                            if (Id==31)
                            {
                                throw new InvalidOperationException(Resource.GetResxValueByName("PublishedVarmsg"));

                            }
                            if ((RestrictedInputVariables.Contains(VarNameWithoutSpace.ToUpper().Replace(" ", ""))) && (data.VariableTypeId != Helper.iInput))
                            {
                                throw new InvalidOperationException(Resource.GetResxValueByName("RestrictedInputmsg"));

                            }
                            if (MasterVariableList.Contains(VarNameWithoutSpace.ToUpper().Trim()))
                            {
                                throw new InvalidOperationException(Resource.GetResxValueByName("MasterVariablemsg"));

                            }
                            if (variable.VariableRepository.Find(x => x.VariableId == vId).ToList().Count == 0)
                            {
                                throw new InvalidOperationException(Resource.GetResxValueByName("CmnDataNotFound"));
                            }
                            var varlst = variable.VariableRepository.Find(x => x.VariableId != vId && (x.TaxId == data.TaxId && x.VariableName == VarNameWithoutSpace)).ToList();
                            var details = (from tm in variable.TaxMasterRepository.GetAll()
                                           join tv in variable.TaxVersionRepository.GetAll() on tm.TaxMasterId equals tv.TaxMasterId
                                           join t in variable.TaxRepository.GetAll() on tv.TaxVersionId equals t.TaxVersionId
                                           join v in varlst on t.TaxId equals v.TaxId
                                           select new { taxname = tm.TaxName, varName = v.VariableName }).FirstOrDefault();
                            if (varlst.Count>0)
                            {
                                throw new InvalidOperationException(Resource.GetResxValueByName("TaxIdVarNameComboDuplicatemsg")+" '"+details.taxname+"' and Variable '"+details.varName+"' combination.");
                            }
                            List<char> datalist = new List<char>();
                            datalist.AddRange(VarNameWithoutSpace.ToUpper().Trim());
                            foreach (var param in datalist)
                            {
                                if ((OperatorsList.Contains(VarNameWithoutSpace.ToUpper().Trim())) || (OperatorsList.Contains(param.ToString())))
                                {
                                    throw new InvalidOperationException(Resource.GetResxValueByName("VariableNameFunmsg"));
                                }
                            }
                            var taxMasterData = (from tm in variable.TaxMasterRepository.GetAll()
                                                 join tv in variable.TaxVersionRepository.GetAll() on tm.TaxMasterId equals tv.TaxMasterId
                                                 join t in variable.TaxRepository.GetAll() on tv.TaxVersionId equals t.TaxVersionId
                                                 where t.TaxId == data.TaxId
                                                 select tm).FirstOrDefault();
                            var InvalidTaxNamelst = variable.TaxMasterRepository.Find(x => x.MarketId == taxMasterData.MarketId && x.Priority >= taxMasterData.Priority).Select(x => x.TaxName.ToUpper()).ToList();
                            if (InvalidTaxNamelst.Contains(VarNameWithoutSpace.ToUpper()))
                            {
                                throw new InvalidOperationException("'" + VarNameWithoutSpace + "'" + Resource.GetResxValueByName("InvalidVarmsg"));
                            }
                            else if (variable.VariableRepository.Find(x => x.VariableId == vId).Select(x => x.VariableName).First() != VarNameWithoutSpace)
                            {
                                var lstformulaid = variable.FormulaDefinitionDependencyDetailsRepository.Find(x => x.VariableId == vId).Select(x => x.FormulaId).ToList();
                                if (lstformulaid.Count != 0)
                                {
                                    List<long> lstvariableid = new List<long>();
                                    foreach (var item in lstformulaid)
                                    {
                                        long variableid = variable.FormulaRepository.Find(x => x.FormulaId == item).Select(x => x.VariableId).First();
                                        lstvariableid.Add(variableid);
                                    }
                                    List<string> lstvariablename = new List<string>();
                                    foreach (var param in lstvariableid)
                                    {
                                        string variablename = variable.VariableRepository.Find(x => x.VariableId == param).Select(x => x.VariableName).First();
                                        lstvariablename.Add(variablename);
                                    }
                                    throw new InvalidOperationException(Resource.GetResxValueByName("formsg") + String.Join(",", lstvariablename) + " formulas");
                                }
                            }
                            else if (variable.VariableRepository.Find(x => x.VariableId == vId).Select(x => x.VariableTypeId).First() != data.VariableTypeId)
                            {
                                var lstformulaId = variable.FormulaRepository.Find(x => x.VariableId == data.VariableId).Select(x => x.FormulaId).ToList();
                                Formula formulaObj = new Formula();
                                foreach (var formulaid in lstformulaId)
                                {
                                    formulaObj.DeleteFormulaAndDependency((int)formulaid);
                                }
                            }
                        }

                        //foreach (var param in variableValue)
                        //{ var checkData = variable.PnoVariableMasterRepository.Find(x => x.GuiName.ToUpper() == param.VariableName.ToUpper()).FirstOrDefault();
                        //    if (checkData!=null)
                        //    {
                        //        param.VariableName = checkData.VariableName;
                        //    }
                        //}

                        foreach (var value in variableValue)
                        {
                            lstvariable.Add(new EF.Variable()
                            {
                                VariableId = value.VariableId,
                                TaxId = value.TaxId,
                                VariableName = value.VariableName.Trim(),
                                Value = value.VariableValue,
                                TestValue = (value.TestValue == null || value.TestValue.Trim() == string.Empty) ? null : value.TestValue.Trim(),
                                UnitTypeId = value.UnitTypeId,
                                VariableTypeId = value.VariableTypeId,
                                IslookUp = value.IsLookUp,
                                IsActive = value.IsActive,
                                CreatedBy = value.CreatedBy,
                                CreatedOn = value.CreatedOn,
                                UpdatedBy = value.UpdatedBy,
                                UpdatedOn = DateTime.UtcNow
                            });
                        }
                    }
                    scope.Complete();
                }




                lstField.Add("TaxId");
                lstField.Add("VariableName");
                lstField.Add("Value");
                lstField.Add("TestValue");
                lstField.Add("UnitTypeId");
                lstField.Add("VariableTypeId");
                lstField.Add("IslookUp");
                lstField.Add("IsActive");
                lstField.Add("UpdatedBy");
                lstField.Add("UpdatedOn");
                using (var variableobj = new UnitofWork())
                {
                    variableobj.VariableRepository.UpdateRange(lstvariable, lstField);
                }
                return lstvariable;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException( ex.Message);
            }
        }
        #endregion
        #region Add Variable Details
        /// <summary>
        /// To add variable Details
        /// </summary>
        /// <param name="variableValue">List of Variable Details to add</param>
        public List<Variable> AddVariable(IEnumerable<Variable> variableValue)
        {
            try
            {

                using (var variable = new UnitofWork())
                {
                    List<string> OperatorsList = new List<string>(Resource.GetResxValueByName("OperatorsList").Split(','));
                   List<string> MasterVariableList = new List<string>(Resource.GetResxValueByName("MasterVariableList").Split(','));

                    foreach (var item in variableValue)
                    {
                        var parameterlst = parameterDetaisObj.GetInputParameter((int)item.TaxId, 7);
                        List<string> RestrictedInputVariables = parameterlst.Select(x => x.VariableName.ToUpper().Replace(" ", "")).ToList();

                        string VarNameWithoutSpace = item.VariableName.ToUpper().Replace(" ", "");
                        int Id = (int)(from u in variable.TaxVersionRepository.GetAll()
                                       join t in variable.TaxRepository.Find(x => x.TaxId == item.TaxId).ToList() on u.TaxVersionId equals t.TaxVersionId
                                       select u.TaxVersionStatusId).FirstOrDefault();
                        if (Id == 31)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("PublishedVarmsg"));

                        }
                        if ((RestrictedInputVariables.Contains(VarNameWithoutSpace.ToUpper().Replace(" ", "")))&&(item.VariableTypeId!=Helper.iInput))
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("RestrictedInputmsg"));

                        }
                        if (MasterVariableList.Contains(VarNameWithoutSpace.ToUpper().Trim()))
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("MasterVariablemsg"));

                        }
                        if (item.VariableTypeId == Helper.iFixed && item.VariableValue == null)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("ValueRequired"));
                        }
                        var taxMasterData = (from tm in variable.TaxMasterRepository.GetAll()
                                        join tv in variable.TaxVersionRepository.GetAll() on tm.TaxMasterId equals tv.TaxMasterId
                                        join t in variable.TaxRepository.GetAll() on tv.TaxVersionId equals t.TaxVersionId
                                        where t.TaxId == item.TaxId
                                        select tm).FirstOrDefault();
                        var InvalidTaxNamelst = variable.TaxMasterRepository.Find(x => x.MarketId == taxMasterData.MarketId&&x.Priority>=taxMasterData.Priority).Select(x=>x.TaxName.ToUpper()).ToList();
                        if (InvalidTaxNamelst.Contains(VarNameWithoutSpace.ToUpper()))
                        {
                            throw new InvalidOperationException("'"+ VarNameWithoutSpace + "'"+Resource.GetResxValueByName("InvalidVarmsg"));
                        }

                        var varlst = variable.VariableRepository.Find(x => x.TaxId == item.TaxId && x.VariableName.ToUpper() == VarNameWithoutSpace.ToUpper().Trim()).ToList();
                        var details = (from tm in variable.TaxMasterRepository.GetAll()
                                       join tv in variable.TaxVersionRepository.GetAll() on tm.TaxMasterId equals tv.TaxMasterId
                                       join t in variable.TaxRepository.GetAll() on tv.TaxVersionId equals t.TaxVersionId
                                       join v in varlst on t.TaxId equals v.TaxId
                                       select new { taxname = tm.TaxName, varName = v.VariableName }).FirstOrDefault();
                        if (varlst.Count > 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("TaxIdVarNameComboDuplicatemsg") + " '" + details.taxname + "' and Variable '" + details.varName + "' combination.");
                        }
                        List<char> datalist = new List<char>();
                        datalist.AddRange(VarNameWithoutSpace.ToUpper().Trim());
                        foreach (var param in datalist)
                        {
                            if ((OperatorsList.Contains(VarNameWithoutSpace.ToUpper().Trim())) || (OperatorsList.Contains(param.ToString())))
                            {
                                throw new InvalidOperationException(Resource.GetResxValueByName("VariableNameFunmsg"));
                            }
                        }
                    }

                    List<EF.Variable> lstvariable = new List<EF.Variable>();
                    foreach (var item in variableValue)
                    {
                        lstvariable.Add(new EF.Variable()
                        {
                            VariableId = item.VariableId,
                            TaxId = item.TaxId,
                            VariableName = item.VariableName,
                            Value = item.VariableValue,
                            TestValue = (item.TestValue == null || item.TestValue.Trim() == string.Empty) ? null : item.TestValue.Trim(),
                            UnitTypeId = item.UnitTypeId,
                            VariableTypeId = item.VariableTypeId,
                            IslookUp = item.IsLookUp,
                            IsActive = item.IsActive,
                            CreatedBy = item.CreatedBy,
                            CreatedOn = DateTime.UtcNow,
                            UpdatedBy = item.UpdatedBy,
                            UpdatedOn = DateTime.UtcNow
                        });
                    }
                    variable.VariableRepository.AddRange(lstvariable);
                    List<Variable> lstVariableDetails = new List<Variable>();
                    using (var marketResponse = new UnitofWork())
                    {
                        foreach (var data in lstvariable)
                        {
                            int vId = (int)data.VariableId;
                            int tId = (int)data.TaxId;
                            using (var variable1 = new UnitofWork())
                            {
                                var result = GetVariable(vId);
                                var lstTax = variable.TaxRepository.Find(x => x.TaxId == tId).ToList<EF.Tax>();
                                var lstParameter = variable.ParameterDetailsRepository.GetAll();
                                var lstParameter1 = variable.ParameterDetailsRepository.GetAll();
                                var lstTaxFlow = variable.ParameterDetailsRepository.Find(x => x.ParameterGroupId == Helper.iTaxFlow).ToList<EF.ParameterDetail>();
                                var result2 = (from v in variable1.VariableRepository.GetAll()
                                               join v1 in result on v.VariableId equals v1.VariableId
                                               join t in lstTax on v.TaxId equals t.TaxId
                                               join tf in lstTaxFlow on t.TaxFlowId equals tf.ParameterId
                                               join p in lstParameter on v.UnitTypeId equals p.ParameterId
                                               join p1 in lstParameter1 on v.VariableTypeId equals p1.ParameterId
                                               select new
                                               {
                                                   v.VariableId,
                                                   v.TaxId,
                                                   v.VariableName,
                                                   v.Value,
                                                   v.TestValue,
                                                   v.UnitTypeId,
                                                   v.VariableTypeId,
                                                   v.IslookUp,
                                                   v.IsActive,
                                                   v.CreatedBy,
                                                   v.CreatedOn,
                                                   v.UpdatedBy,
                                                   v.UpdatedOn,
                                                   UnitTypeName = p.Value,
                                                   VaraibleTypeName = p1.Value,
                                                   TaxFlowValue = tf.Value
                                               }).ToList();
                                foreach (var value in result2)
                                {

                                    lstVariableDetails.Add(new Variable()
                                    {
                                        VariableId = (int)value.VariableId,
                                        TaxId = (int)value.TaxId,
                                        VariableName = value.VariableName.Trim(),
                                        VariableValue = value.Value,
                                        TestValue= (value.TestValue == null || value.TestValue.Trim() == string.Empty) ? null : value.TestValue.Trim(),
                                        UnitTypeId = (int)value.UnitTypeId,
                                        VariableTypeId = (int)value.VariableTypeId,
                                        IsLookUp = (bool)value.IslookUp,
                                        IsActive = value.IsActive,
                                        CreatedBy = value.CreatedBy,
                                        CreatedOn = value.CreatedOn,
                                        UpdatedBy = value.UpdatedBy,
                                        UpdatedOn = value.UpdatedOn,
                                        UnitTypeName = value.UnitTypeName,
                                        VariableTypeName = value.VaraibleTypeName,
                                        TaxFlowValue = value.TaxFlowValue
                                    });
                                }
                            }
                        }
                    }
                    return lstVariableDetails;
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException( ex.Message);
            }
        }
        #endregion

        #region Get Variable by TaxId
        /// <summary>
        /// To get Variable by TaxId
        /// </summary>
        /// <param name="taxId">An integer which represents TaxId</param>
        /// <returns>List of Variables</returns>
        internal  List<EF.Variable> GetVariableByTaxId(int taxId)
        {
            try
            {
                using (var variable = new UnitofWork())
                {
                    return variable.VariableRepository.Find(p => p.TaxId == taxId).OrderBy(x=>x.VariableName).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException( ex.Message);
            }
        }
        #endregion

        #region Delete Variable details
        /// <summary>
        /// To delete Variable Details
        /// </summary>
        /// <param name="variableId">An integer which represents Variable Id</param>
        /// <returns>An integer which represents TaxId deleted</returns>
        public  void DeleteVariable(int variableId)
        {
            try
            {
                List<EF.Formula> lstformula = new List<EF.Formula>();
                using (var variable = new UnitofWork())
                {
                    var vId = variableId;
                    List<EF.Variable> lstvariable = variable.VariableRepository.Find(p => p.VariableId == variableId).ToList();
                    if (lstvariable.Count == 0)
                    {
                        throw new InvalidOperationException(Resource.GetResxValueByName("CmnDataNotFound"));
                    }
                    var VarTaxId = variable.VariableRepository.Find(x => x.VariableId == vId).Select(x => x.TaxId).FirstOrDefault();
                    int TaxversionStatusId = (int)(from u in variable.TaxVersionRepository.GetAll()
                                                   join t in variable.TaxRepository.Find(x => x.TaxId == VarTaxId).ToList() on u.TaxVersionId equals t.TaxVersionId
                                                   select u.TaxVersionStatusId).FirstOrDefault();
                    if (TaxversionStatusId == 31)
                    {
                        throw new InvalidOperationException(Resource.GetResxValueByName("PublishedVarmsg"));

                    }
                    var lstformulaid = variable.FormulaDefinitionDependencyDetailsRepository.Find(x => x.VariableId == vId).Select(x => x.FormulaId).ToList();
                    if (lstformulaid.Count>0)
                    {
                        List<long> lstvariableid = new List<long>();
                        foreach (var item in lstformulaid)
                        {
                            long variableid = variable.FormulaRepository.Find(x => x.FormulaId == item).Select(x => x.VariableId).First();
                            lstvariableid.Add(variableid);
                        }
                        List<string> lstvariablename = new List<string>();
                        foreach (var param in lstvariableid)
                        {
                            string variablename = variable.VariableRepository.Find(x => x.VariableId == param).Select(x => x.VariableName).First();
                            lstvariablename.Add(variablename);
                        }
                        throw new InvalidOperationException(Resource.GetResxValueByName("formsg") + String.Join(",", lstvariablename) + " formulas");
                    }
                    lstformula = variable.FormulaRepository.Find(p => p.VariableId == variableId).ToList();
                   var lstformuladefinition = (from tv in variable.FormulaDefinitionDependencyDetailsRepository.GetAll()
                                            join tm in lstformula on tv.FormulaId equals tm.FormulaId
                                            select tv).ToList();
                    List<long> lstGroupdetailsId = variable.LookupGroupDetailRepository.Find(x => x.VariableId == variableId).Select(x => x.GroupDetailsId).ToList();
                        LookUpGroupDetails lookupObj = new LookUpGroupDetails();
                    foreach (var item in lstGroupdetailsId)
                    {
                        lookupObj.DeleteLookUpGroupDetail((int)item);
                    }
                    variable.FormulaDefinitionDependencyDetailsRepository.RemoveRange(lstformuladefinition);
                    variable.FormulaRepository.RemoveRange(lstformula);
                    foreach (var param in lstvariable)
                    {
                        variable.VariableRepository.Remove(param);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException( ex.Message);
            }
        }
        #endregion
        #region Get Variable Details by TaxId
        /// <summary>
        /// To get Variable details by TaxId
        /// </summary>
        /// <param name="taxId">An integer which represents TaxId</param>
        /// <returns>List of VariableDropList</returns>
        internal List<VariableDropList> GetVariableDetailForDrp(int taxId)
        {
            try
            {
                List<VariableDropList> lstvariableDrp = new List<VariableDropList>();
                using (var variable = new UnitofWork())
                {
                    var result = variable.VariableRepository.Find(p => p.TaxId == taxId && (p.VariableTypeId ==Helper.iResult || p.VariableTypeId == Helper.iCalculated)).OrderBy(x=>x.VariableName).ToList();
                    foreach (var data in result)
                    {
                        lstvariableDrp.Add(new VariableDropList()
                        {
                            VariableId = (int)data.VariableId,
                            VariableName = data.VariableName
                        });
                    }
                }
                return lstvariableDrp;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException( ex.Message);
            }
        }
        #endregion
        #region Get Dependency Parameter by TaxId
        /// <summary>
        /// To get Dependency Parameter by TaxId
        /// </summary>
        /// <param name="taxId">An integer which represents TaxId</param>
        /// <returns>List of VariableDropList</returns>
        internal List<VariableDropList> GetDependencyParameter(int taxId)
        {
            try
            {
                List<VariableDropList> lstvariableDrp = new List<VariableDropList>();
                using (var variable = new UnitofWork())
                {
                    var result = variable.VariableRepository.Find(p => p.TaxId == taxId && p.IslookUp == true  && (p.VariableTypeId == Helper.iInput || p.VariableTypeId == Helper.iDependency|| p.VariableTypeId == Helper.iFixed)).OrderBy(x=>x.VariableName).ToList();
                    foreach (var data in result)
                    {
                        lstvariableDrp.Add(new VariableDropList()
                        {
                            VariableId = (int)data.VariableId,
                            VariableName = data.VariableName
                        });
                    }
                }
                return lstvariableDrp;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException( ex.Message);
            }
        }
        #endregion
        #region Get Variable Details With Unit And Type
        /// <summary>
        /// To get Variable Details with unit and type
        /// </summary>
        /// <returns>List of Variables</returns>
        internal  List<Variable> GetVariableDetailWithUnitAndType()
        {
            List<Variable> lstVariable = new List<Variable>();
            try
            {
                using (var variable = new UnitofWork())
                {
                    var lstTax = variable.TaxRepository.GetAll();
                    var lstParameter = variable.ParameterDetailsRepository.GetAll();
                    var lstParameter1 = variable.ParameterDetailsRepository.GetAll();
                    var lstTaxFlow = variable.ParameterDetailsRepository.Find(x => x.ParameterGroupId == Helper.iTaxFlow).ToList<EF.ParameterDetail>();
                    var result2 = (from v in variable.VariableRepository.GetAll()
                                   join t in lstTax on v.TaxId equals t.TaxId
                                   join tf in lstTaxFlow on t.TaxFlowId equals tf.ParameterId
                                   join p in lstParameter on v.UnitTypeId equals p.ParameterId
                                   join p1 in lstParameter1 on v.VariableTypeId equals p1.ParameterId
                                   select new
                                   {
                                       v.VariableId,
                                       v.TaxId,
                                       v.VariableName,
                                       v.Value,
                                       v.TestValue,
                                       v.UnitTypeId,
                                       v.VariableTypeId,
                                       v.IslookUp,
                                       v.IsActive,
                                       v.CreatedBy,
                                       v.CreatedOn,
                                       v.UpdatedBy,
                                       v.UpdatedOn,
                                       UnitTypeName = p.Value,
                                       VaraibleTypeName = p1.Value,
                                       TaxFlowValue = tf.Value
                                   }).OrderBy(x=>x.VariableName).ToList();
                    foreach (var value in result2)
                    {
                        lstVariable.Add(new Variable()
                        {
                            VariableId = (int)value.VariableId,
                            TaxId = (int)value.TaxId,
                            VariableName = value.VariableName.Trim(),
                            VariableValue = value.Value,
                            TestValue=value.TestValue,
                            UnitTypeId = (int)value.UnitTypeId,
                            VariableTypeId = (int)value.VariableTypeId,
                            IsLookUp = (bool)value.IslookUp,
                            IsActive = value.IsActive,
                            CreatedBy = value.CreatedBy,
                            CreatedOn = value.CreatedOn,
                            UpdatedBy = value.UpdatedBy,
                            UpdatedOn = value.UpdatedOn,
                            UnitTypeName = value.UnitTypeName,
                            VariableTypeName = value.VaraibleTypeName,
                            TaxFlowValue = value.TaxFlowValue
                        });
                    }
                    lstVariable = lstVariable.OrderBy(x => x.VariableName).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lstVariable;
        }
        #endregion
        #region Get Variable Details With Unit And Type by TaxId
        /// <summary>
        /// To get Variable Details with unit and type
        /// </summary>
        /// <param name="taxId">An integer which represents TaxId</param>
        /// <returns>List of Variables</returns>
        internal  List<Variable> GetVariableDetailWithUnitAndType(int taxId)
        {
            List<Variable> lstVariable = new List<Variable>();
            try
            {
                using (var variable = new UnitofWork())
                {
                    var lstTax = variable.TaxRepository.Find(x => x.TaxId == taxId).ToList<EF.Tax>();
                    var lstParameter = variable.ParameterDetailsRepository.GetAll();
                    var lstParameter1 = variable.ParameterDetailsRepository.GetAll();
                    var lstTaxFlow = variable.ParameterDetailsRepository.Find(x => x.ParameterGroupId == Helper.iTaxFlow).ToList<EF.ParameterDetail>();
                    var result2 = (from v in variable.VariableRepository.GetAll()
                                   join t in lstTax on v.TaxId equals t.TaxId
                                   join tf in lstTaxFlow on t.TaxFlowId equals tf.ParameterId
                                   join p in lstParameter on v.UnitTypeId equals p.ParameterId
                                   join p1 in lstParameter1 on v.VariableTypeId equals p1.ParameterId
                                   select new
                                   {
                                       v.VariableId,
                                       v.TaxId,
                                       v.VariableName,
                                       v.Value,
                                       v.TestValue,
                                       v.UnitTypeId,
                                       v.VariableTypeId,
                                       v.IslookUp,
                                       v.IsActive,
                                       v.CreatedBy,
                                       v.CreatedOn,
                                       v.UpdatedBy,
                                       v.UpdatedOn,
                                       UnitTypeName = p.Value,
                                       VaraibleTypeName = p1.Value,
                                       TaxFlowValue = tf.Value
                                   }).OrderBy(x=>x.VariableName).ToList();
                    foreach (var value in result2)
                    {

                        lstVariable.Add(new Variable()
                        {
                            VariableId = (int)value.VariableId,
                            TaxId = (int)value.TaxId,
                            VariableName = value.VariableName.Trim(),
                            VariableValue = value.Value,
                            TestValue=value.TestValue,
                            UnitTypeId = (int)value.UnitTypeId,
                            VariableTypeId = (int)value.VariableTypeId,
                            IsLookUp = (bool)value.IslookUp,
                            IsActive = value.IsActive,
                            CreatedBy = value.CreatedBy,
                            CreatedOn = value.CreatedOn,
                            UpdatedBy = value.UpdatedBy,
                            UpdatedOn = value.UpdatedOn,
                            UnitTypeName = value.UnitTypeName,
                            VariableTypeName = value.VaraibleTypeName,
                            TaxFlowValue = value.TaxFlowValue
                        });
                    }
                    lstVariable = lstVariable.OrderBy(x => x.VariableName).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lstVariable;
        }
        #endregion
    }
    public class VariableList
    {
        #region VariableListProperty
        [JsonProperty(PropertyName = "variableId")]
        public int VariableId { get; set; }
        [JsonProperty(PropertyName = "taxId")]
        public int TaxId { get; set; }
        [JsonProperty(PropertyName = "variableName")]
        public string VariableName { get; set; }
        [JsonProperty(PropertyName = "variableValue")]
        public Nullable<decimal> VariableValue { get; set; }
        [JsonProperty(PropertyName = "unitTypeId")]
        public int UnitTypeId { get; set; }
        [JsonProperty(PropertyName = "varaibleTypeId")]
        public int VariableTypeId { get; set; }
        [JsonProperty(PropertyName = "isLookUp")]
        public bool IsLookUp { get; set; }
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
        [JsonProperty(PropertyName = "unitTypeName")]
        public string UnitTypeName { get; set; }
        [JsonProperty(PropertyName = "variableTypeName")]
        public string VariableTypeName { get; set; }
        [JsonProperty(PropertyName = "taxFlowValue")]
        public string TaxFlowValue { get; set; }
        #endregion
    }
    public class VariableDropList
    {
        #region VariableDropList Property
        [JsonProperty(PropertyName = "variableId")]
        public int VariableId { get; set; }
        [JsonProperty(PropertyName = "variableName")]
        public string VariableName { get; set; }
        #endregion
    }
}