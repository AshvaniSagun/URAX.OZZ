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
using UraxUIServiceWebApi.Models;
using UraxUIServiceWebApi.Repository;
using UraxUIServiceWebApi.ResourceFiles;
using System.Text.RegularExpressions;
using System.Data;
using System.Transactions;
using System.Net.Http;
using System.Net.Http.Headers;
#endregion

namespace UraxUIServiceWebApi.Controllers
{

    public class Formula
    {
        #region Formula Property
        [JsonProperty(PropertyName = "formulaId")]
        public long FormulaId { get; set; }
        [JsonProperty(PropertyName = "variableId")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "VariableIdReq")]
        public long VariableId { get; set; }
        [JsonProperty(PropertyName = "formulaName")]
        public string FormulaName { get; set; }
        [JsonProperty(PropertyName = "formulaDefinition")]
        public string FormulaDefination { get; set; }
        [JsonProperty(PropertyName = "minValue")]
        public Nullable<decimal> MinValue { get; set; }
        [JsonProperty(PropertyName = "maxValue")]
        public Nullable<decimal> MaxValue { get; set; }
        [JsonProperty(PropertyName = "priority")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "PriorityReq")]
        public int Priority { get; set; }
        [JsonProperty(PropertyName = "isActive")]
        public bool IsActive { get; set; }
        [JsonProperty(PropertyName = "createdBy")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "CreatedByReq")]
        public string CreatedBy { get; set; }
        [JsonProperty(PropertyName = "createdOn")]
        public Nullable<System.DateTime> CreatedOn { get; set; }
        [JsonProperty(PropertyName = "updatedBy")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "UpdatedByReq")]
        public string UpdatedBy { get; set; }
        [JsonProperty(PropertyName = "updatedOn")]
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        #endregion
        #region     Get Formula Definition Dependency Details
        /// <summary>
        /// Get Formula Definition Dependency Details
        /// </summary>
        /// <returns> List of Formula definition Dependency Details</returns>
        public List<EF.FormulaDefinitionDependencyDetail> GetFormulaDefinitionDependencyDetails()
        {
            try
            {
                using (var formulaDependency = new UnitofWork())
                {
                    return formulaDependency.FormulaDefinitionDependencyDetailsRepository.GetAll().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }
        }
        #endregion
        #region Get All Formula
        /// <summary>
        /// Get All Formula
        /// </summary>
        /// <returns>List of Formulas</returns>
        public List<EF.Formula> GetFormula()
        {
            try
            {
                using (var formula = new UnitofWork())
                {
                    return formula.FormulaRepository.GetAll().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }
        }
        #endregion
        #region Get Formula by Id
        /// <summary>
        /// Get Formula by Id
        /// </summary>
        /// <param name="formulaId">an Integer which represents Formula Id</param>
        /// <returns>List of formulas</returns>
        public List<Formula> GetFormulaById(int formulaId)
        {
            List<Formula> lstFormula = new List<Formula>();
            try
            {
                using (var formula = new UnitofWork())
                {
                    var result = formula.FormulaRepository.Find(p => p.FormulaId == formulaId).ToList();
                    foreach (var data in result)
                    {
                        lstFormula.Add(new Formula()
                        {
                            FormulaId = data.FormulaId,
                            VariableId = data.VariableId,
                            FormulaDefination = data.FormulaDefination,
                            MinValue = data.MinValue,
                            MaxValue = data.MaxValue,
                            Priority = data.Priority,
                            IsActive = data.IsActive,
                            CreatedBy = data.CreatedBy,
                            CreatedOn = data.CreatedOn,
                            UpdatedBy = data.UpdatedBy,
                            UpdatedOn = data.UpdatedOn
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error while loading Data. Error : " + ex.Message);
            }
            return lstFormula;
        }
        #endregion
        #region Get Formula by TaxFlowId
        /// <summary>
        /// Get Formula by TaxFlowId
        /// </summary>
        /// <param name="TaxFlowId">a Long datatype Value which represents TaxFlow Id</param>
        /// <returns>List of Formulas</returns>
        public List<Formula> GetFormulaByTaxFlowId(long TaxFlowId)
        {
            List<Formula> lstFormula = new List<Formula>();
            try
            {
                using (var formula = new UnitofWork())
                {
                    var lstVariable = formula.VariableRepository.Find(x => x.TaxId == TaxFlowId).ToList<EF.Variable>();
                    var result = (from ld in formula.FormulaRepository.GetAll()
                                  join t in lstVariable on ld.VariableId equals t.VariableId
                                  select new { ld.FormulaId, ld.VariableId, ld.MaxValue, ld.MinValue, ld.IsActive, ld.CreatedBy, ld.Priority, ld.CreatedOn, ld.FormulaDefination, ld.UpdatedBy, ld.UpdatedOn, t.VariableName }).ToList();
                    foreach (var data in result)
                    {
                        lstFormula.Add(new Formula()
                        {
                            FormulaId = data.FormulaId,
                            VariableId = data.VariableId,
                            FormulaDefination = data.FormulaDefination,
                            MinValue = data.MinValue,
                            FormulaName = data.VariableName,
                            MaxValue = data.MaxValue,
                            Priority = data.Priority,
                            IsActive = data.IsActive,
                            CreatedBy = data.CreatedBy,
                            CreatedOn = data.CreatedOn,
                            UpdatedBy = data.UpdatedBy,
                            UpdatedOn = data.UpdatedOn
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error while loading Data. Error : " + ex.Message);
            }
            return lstFormula;
        }
        #endregion
        #region Add Formula
        /// <summary>
        /// Add Formula
        /// </summary>
        /// <param name="formulaValue">Formula Details to add</param>
        /// <returns>long datatype value which represents TaxFlow Id</returns>
        public long AddFormula(IEnumerable<Formula> formulaValue)
        {
            try
            {
                long TaxFlowId = 0;
                using (var formula = new UnitofWork())
                {
                    foreach (var item in formulaValue)
                    {
                        long formulaId = item.FormulaId;
                        if (formula.FormulaRepository.Find(x => x.FormulaId == formulaId).ToList().Count > 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("FormulaDuplication"));
                        }
                        else if (formula.FormulaRepository.Find(x => x.VariableId == item.VariableId).ToList().Count > 0)
                        {
                            using (var VariableRepo = new UnitofWork())
                            {
                                var variableName = VariableRepo.VariableRepository.Find(x => x.VariableId == item.VariableId).Select(x => x.VariableName).FirstOrDefault();
                                throw new InvalidOperationException(variableName + Resource.GetResxValueByName("VariableIdDuplication"));
                            }

                        }
                    }
                    List<EF.Formula> lstFormula = new List<EF.Formula>();
                    foreach (var data in formulaValue)
                    {
                        lstFormula.Add(new EF.Formula()
                        {
                            FormulaId = data.FormulaId,
                            VariableId = data.VariableId,
                            FormulaDefination = data.FormulaDefination,
                            MinValue = data.MinValue,
                            MaxValue = data.MaxValue,
                            Priority = data.Priority,
                            IsActive = data.IsActive,
                            CreatedBy = data.CreatedBy,
                            CreatedOn = DateTime.UtcNow,
                            UpdatedBy = data.UpdatedBy,
                            UpdatedOn = DateTime.UtcNow
                        });
                    }
                    formula.FormulaRepository.AddRange(lstFormula);
                    int VariableID = (int)lstFormula.First().VariableId;
                    var Id = formula.VariableRepository.Find(x => x.VariableId == VariableID).Select(x => x.TaxId).ToList();
                    TaxFlowId = Convert.ToInt32(Id.FirstOrDefault().ToString());
                }
                return TaxFlowId;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }
        }
        #endregion
        #region Update Formula
        /// <summary>
        ///  To Update Formula
        /// </summary>
        /// <param name="FormulaValue">Formula Details to Update</param>
        /// <returns>a long datatype value which represents TaxFlow Id</returns>
        public long UpdateFormula(IEnumerable<Formula> FormulaValue)
        {
            try
            {
                long TaxFlowId = 0;
                using (var formula = new UnitofWork())
                {
                    foreach (var data in FormulaValue)
                    {
                        long fId = data.FormulaId;
                        if (formula.FormulaRepository.Find(X => X.FormulaId == fId).ToList().Count == 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("CmnDataNotFound"));
                        }
                        else if (formula.FormulaRepository.Find(x => x.FormulaId != data.FormulaId && (x.VariableId==data.VariableId)).ToList().Count > 0)
                        {
                            using (var VariableRepo = new UnitofWork())
                            {
                                var variableName = VariableRepo.VariableRepository.Find(x => x.VariableId == data.VariableId).Select(x => x.VariableName).FirstOrDefault();
                                throw new InvalidOperationException(variableName + Resource.GetResxValueByName("VariableIdDuplication"));
                            }
                        }
                    }
                }
                List<EF.Formula> lstFormula = new List<EF.Formula>();
                List<string> lstField = new List<string>();
                foreach (var data in FormulaValue)
                {
                    lstFormula.Add(new EF.Formula()
                    {
                        FormulaId = data.FormulaId,
                        VariableId = data.VariableId,
                        FormulaDefination = data.FormulaDefination,
                        MinValue = data.MinValue,
                        MaxValue = data.MaxValue,
                        Priority = data.Priority,
                        IsActive = data.IsActive,
                        CreatedBy = data.CreatedBy,
                        CreatedOn = data.CreatedOn,
                        UpdatedBy = data.UpdatedBy,
                        UpdatedOn = DateTime.UtcNow
                    });
                }
                lstField.Add("FormulaDefination");
                lstField.Add("MinValue");
                lstField.Add("MaxValue");
                lstField.Add("Priority");
                lstField.Add("UpdatedBy");
                lstField.Add("UpdatedOn");
                using (var formulaObj = new UnitofWork())
                {
                    formulaObj.FormulaRepository.UpdateRange(lstFormula, lstField);
                    int VariableID = (int)lstFormula.First().VariableId;
                    var Id = formulaObj.VariableRepository.Find(x => x.VariableId == VariableID).Select(x => x.TaxId).ToList();
                    TaxFlowId = Convert.ToInt32(Id.FirstOrDefault().ToString());
                }
                return TaxFlowId;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        #endregion
        #region Delete Formula
        /// <summary>
        /// Delete Formula
        /// </summary>
        /// <param name="formulaId">An integer Value which represents Formula Id</param>
        /// <returns>A Long datatype value which represents TaxFlow Id</returns>
        public long DeleteFormula(int formulaId)
        {
            try
            {
                long TaxFlowId = 0;
                using (var formula = new UnitofWork())
                {
                    List<EF.Formula> lstFormula = formula.FormulaRepository.Find(p => p.FormulaId == formulaId).ToList();
                    if (lstFormula.Count == 0)
                    {
                        throw new InvalidOperationException(Resource.GetResxValueByName("CmnDataNotFound"));
                    }
                    int VariableID = (int)lstFormula.First().VariableId;
                    var Id = formula.VariableRepository.Find(x => x.VariableId == VariableID).Select(x => x.TaxId).ToList();
                    TaxFlowId = Convert.ToInt32(Id.FirstOrDefault().ToString());
                    formula.FormulaRepository.RemoveRange(lstFormula);
                }
                return TaxFlowId;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }
        }
        #endregion
        #region Formuladependency Details
        #region Delete Formula and Dependency
        /// <summary>
        /// To delete formula and dependency
        /// </summary>
        /// <param name="formulaId">An integer which represents Formula Id</param>
        /// <returns>long datatype TaxFlow Id</returns>
        public long DeleteFormulaAndDependency(int formulaId)
        {
            try
            {
                long TaxFlowId = 0;
                using (var formula = new UnitofWork())
                {
                    List<EF.Formula> lstFormula = formula.FormulaRepository.Find(p => p.FormulaId == formulaId).ToList();
                    if (lstFormula.Count == 0)
                    {
                        throw new InvalidOperationException(Resource.GetResxValueByName("CmnDataNotFound"));
                    }
                    var VarId = formula.FormulaRepository.Find(x => x.FormulaId == formulaId).Select(x => x.VariableId).FirstOrDefault();
                    var TaxId = formula.VariableRepository.Find(x => x.VariableId == VarId).Select(x => x.TaxId).FirstOrDefault();
                    int TaxversionStatusId = (int)(from u in formula.TaxVersionRepository.GetAll()
                                   join t in formula.TaxRepository.Find(x => x.TaxId == TaxId).ToList() on u.TaxVersionId equals t.TaxVersionId
                                   select u.TaxVersionStatusId).FirstOrDefault();
                    if (TaxversionStatusId == 31)
                    {
                        throw new InvalidOperationException(Resource.GetResxValueByName("Publishedformulamsg"));

                    }
                    int VariableID = (int)lstFormula.First().VariableId;
                    var Id = formula.VariableRepository.Find(x => x.VariableId == VariableID).Select(x => x.TaxId).ToList();
                    TaxFlowId = Convert.ToInt32(Id.FirstOrDefault().ToString());
                    List<EF.FormulaDefinitionDependencyDetail> lstFormulaDependency = new List<EF.FormulaDefinitionDependencyDetail>();
                    foreach (var item in lstFormula)
                    {
                        lstFormulaDependency = formula.FormulaDefinitionDependencyDetailsRepository.Find(x => x.FormulaId == item.FormulaId).ToList();
                    }
                    using (TransactionScope scope = new TransactionScope())
                    {
                        formula.FormulaDefinitionDependencyDetailsRepository.RemoveRange(lstFormulaDependency);
                        formula.FormulaRepository.RemoveRange(lstFormula);
                        scope.Complete();
                    }
                }
                return TaxFlowId;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }
        }
        #endregion
        /// <summary>
        /// SwapformulaCalculationOrderDetails
        /// </summary>
        /// <param name="formulaId"></param>
        /// <param name="swapformulaId"></param>
        /// <param name="loginUser"></param>
        internal void SwapformulaCalculationOrderDetails(long formulaId, long swapformulaId, string loginUser)
        {
            using (TransactionScope tran = new TransactionScope())
            {
                try
                {
                    List<EF.Formula> lstFormula;
                    List<EF.Formula> lstFormula1;
                    int calOrder;
                    using (var formula = new UnitofWork())
                    {
                        lstFormula = formula.FormulaRepository.Find(x => x.FormulaId == formulaId).ToList<EF.Formula>();
                        lstFormula1 = formula.FormulaRepository.Find(x => x.FormulaId == swapformulaId).ToList<EF.Formula>();
                        calOrder = (int)lstFormula1[0].Priority;
                        lstFormula[0].UpdatedBy = loginUser;
                        lstFormula[0].UpdatedOn = DateTime.UtcNow;
                        lstFormula1[0].Priority = lstFormula[0].Priority;
                        lstFormula1[0].UpdatedBy = loginUser;
                        lstFormula1[0].UpdatedOn = DateTime.UtcNow;
                        lstFormula[0].Priority = 9999999;
                    }
                    List<string> lstField = new List<string>() { "Priority", "UpdatedBy", "UpdatedOn" };

                    using (var taxobj = new UnitofWork())
                    {
                        taxobj.FormulaRepository.UpdateRange(lstFormula, lstField);
                    }
                    using (var taxobj = new UnitofWork())
                    {
                        taxobj.FormulaRepository.UpdateRange(lstFormula1, lstField);
                    }
                    using (var taxobj = new UnitofWork())
                    {
                        lstFormula[0].Priority = calOrder;
                        taxobj.FormulaRepository.UpdateRange(lstFormula, lstField);
                    }
                    tran.Complete();
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
                }
            }
        }
        internal List<VariableDropList> GetNewCalculationOrderByTaxId(long taxId)
        {
            List<VariableDropList> lstCalculationOrder = new List<VariableDropList>();
            try
            {
                using (var tax = new UnitofWork())
                {
                    var VariableIdDetails = tax.VariableRepository.Find(x => x.TaxId == taxId  && (x.VariableTypeId == Helper.iCalculated || x.VariableTypeId == Helper.iResult)).Select(x => new { x.VariableId, x.VariableName });
                    var result = (from ld in tax.FormulaRepository.GetAll()
                                  join tm in VariableIdDetails on ld.VariableId equals tm.VariableId
                                  orderby ld.Priority descending
                                  select  new { ld.Priority }).First();
                        lstCalculationOrder.Add(new VariableDropList()
                        {
                            VariableName = "NewCalculationOrder",
                            VariableId = Convert.ToInt32(result) + 1
                        });
                }
                return lstCalculationOrder;
            }
            catch (Exception ex)
            {
                if (ex.Message == "Sequence contains no elements")
                {
                    lstCalculationOrder.Add(new VariableDropList()
                    {
                        VariableName = "NewCalculationOrder",
                        VariableId = 1
                    });
                    return lstCalculationOrder;
                }
                else
                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }
        }
        /// <summary>
        /// GetFormulaCalculationOrder  By TaxId and formulaId
        /// </summary>
        /// <param name="taxId"></param>
        /// <param name="formulaId"></param>
        /// <returns></returns>
        internal List<FormulaCalculationOrder> GetFormulaCalculationOrderByTaxId(long taxId, long formulaId)
        {
            try
            {
                List<FormulaCalculationOrder> lstCalculationOrder = new List<FormulaCalculationOrder>();
                using (var tax = new UnitofWork())
                {
                    var Variable = tax.FormulaRepository.Find(x => x.FormulaId == formulaId).Select(x => x.VariableId);
                    var VariableIdDetails = tax.VariableRepository.Find(x => x.TaxId == taxId && x.VariableId != Variable.FirstOrDefault() && (x.VariableTypeId == Helper.iCalculated || x.VariableTypeId == Helper.iResult)).Select(x =>new { x.VariableId ,x.VariableName});
                    var result = (from ld in tax.FormulaRepository.GetAll()
                                  join tm in VariableIdDetails on ld.VariableId equals tm.VariableId
                                  select new { ld.FormulaId,ld.Priority,tm.VariableName}).ToList();
                    foreach (var data in result)
                    {
                        lstCalculationOrder.Add(new FormulaCalculationOrder()
                        {
                             FormulaId = data.FormulaId,
                            CalculationOrder = data.Priority,
                             FormulaName = data.VariableName
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
        #region Add Formula Dependency Details
        /// <summary>
        /// To Add Formula and Dependency Details
        /// </summary>
        /// <param name="formulaValue">List of Formula Details to add</param>
        public void AddFormuladependency(IEnumerable<Formula> formulaValue)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    using (var formula = new UnitofWork())
                    {
                    List<long> lstId = new List<long>();
                    List<long> lstVariableId = new List<long>();
                    List<EF.Formula> lstFormula = new List<EF.Formula>();
                    var lstOperator = Regex.Split(Resource.GetResxValueByName("OperatorsList"), ",");
                        foreach (var item in formulaValue)
                        {
                            long formulaId = item.FormulaId;
                            var TaxId = formula.VariableRepository.Find(x => x.VariableId == item.VariableId).Select(x => x.TaxId).FirstOrDefault();
                            int Id = (int)(from u in formula.TaxVersionRepository.GetAll()
                                           join t in formula.TaxRepository.Find(x => x.TaxId == TaxId).ToList() on u.TaxVersionId equals t.TaxVersionId
                                           select u.TaxVersionStatusId).FirstOrDefault();
                            if (Id == 31)
                            {
                                throw new InvalidOperationException(Resource.GetResxValueByName("Publishedformulamsg"));

                            }
                            if (formula.FormulaRepository.Find(x => x.FormulaId == formulaId).ToList().Count > 0)
                            {
                                throw new InvalidOperationException(Resource.GetResxValueByName("FormulaDuplication"));
                            }
                           if (formula.FormulaRepository.Find(x => x.VariableId == item.VariableId).ToList().Count > 0)
                            {
                                using (var VariableRepo = new UnitofWork())
                                {
                                    var variableName = VariableRepo.VariableRepository.Find(x => x.VariableId == item.VariableId).Select(x => x.VariableName).FirstOrDefault();
                                    throw new InvalidOperationException(variableName + Resource.GetResxValueByName("VariableIdDuplication"));
                                }
                            }
                             if ((item.MinValue != null) && (item.MaxValue != null) && (item.MinValue > item.MaxValue))
                            {
                                throw new InvalidOperationException(Resource.GetResxValueByName("MinMaxMsg"));

                            }
                            if (formula.VariableRepository.Find(x => x.VariableId == item.VariableId).ToList().Count == 0)
                            {
                                throw new InvalidOperationException(Resource.GetResxValueByName("InvalidVarIdmsg"));
                            }
                            var taxId = formula.VariableRepository.Find(x => x.VariableId == item.VariableId).Select(x => x.TaxId).FirstOrDefault();
                            var taxVersionId = formula.TaxRepository.Find(x => x.TaxId == taxId).Select(x => x.TaxVersionId).FirstOrDefault();
                            var taxFlowId = formula.TaxRepository.Find(x => x.TaxId == taxId).Select(x => x.TaxFlowId);
                            var lsttax = formula.TaxRepository.Find(x => x.TaxVersionId == taxVersionId && x.TaxFlowId == taxFlowId.FirstOrDefault()).ToList();
                            var lstPriority = (from tv in lsttax
                                               join v in formula.VariableRepository.GetAll() on tv.TaxId equals v.TaxId
                                               join f in formula.FormulaRepository.GetAll() on v.VariableId equals f.VariableId
                                               select new { f.Priority }).ToList();
                            foreach (var param in lstPriority)
                            {
                                if (param.Priority == item.Priority)
                                {
                                    throw new InvalidOperationException(Resource.GetResxValueByName("PriorityDuplicatemsg"));
                                }
                            }
                            var variableNames = GetVariables(item.FormulaDefination.ToUpper().Trim());
                            List<string> lsterrorId = new List<string>();
                            List<string> lstvariable = new List<string>();
                            foreach (var data in variableNames)
                            {
                                var trimmedData = data.ToString().ToUpper().Trim();
                                var content = formula.VariableRepository.Find(x => x.VariableName.ToUpper() == trimmedData && x.TaxId== taxId).FirstOrDefault();
                                if (content != null)
                                {
                                    lstId.Add(content.VariableId);
                                    lstvariable.Add(content.VariableName.ToUpper().Trim());
                                }
                                else if(!data.Contains("\""))
                                {
                                    decimal decimalData = 0;
                                    if ((!lstOperator.Contains(data)) && (!decimal.TryParse(data, out decimalData)) && data != " ")
                                    {
                                        lsterrorId.Add(data.ToUpper().Trim());
                                    }
                                }
                            }
                            lstId = lstId.Distinct().ToList();
                            if (lstId.Contains(item.VariableId))
                            {
                                using (var VarRepo = new UnitofWork())
                                {
                                    var variableName = VarRepo.VariableRepository.Find(x => x.VariableId == item.VariableId).Select(x => x.VariableName).FirstOrDefault();
                                    throw new InvalidOperationException(variableName + Resource.GetResxValueByName("VariableIdmsg"));
                                }
                            }
                            using (var VariableRepo = new UnitofWork())
                            {
                                var lstVarName = (from tv in lsttax
                                                  join v in VariableRepo.VariableRepository.GetAll() on tv.TaxId equals v.TaxId
                                                  join f in VariableRepo.FormulaRepository.GetAll() on v.VariableId equals f.VariableId
                                                  where f.Priority > item.Priority
                                                  select v).Select(x=>x.VariableName).ToList();
                                foreach (var error in lstVarName)
                                {
                                    if (lstvariable.Contains(error))
                                    {
                                        throw new InvalidOperationException(error + Resource.GetResxValueByName("VariableIdmsg"));
                                    }
                                }

                            }
                            var builder = new System.Text.StringBuilder(item.FormulaDefination.ToUpper());
                            if (lsterrorId.Count > 0)
                            {
                                using (var taxMasterRepo = new UnitofWork())
                                {
                                    var LstTxMrId = (from tm in taxMasterRepo.TaxMasterRepository.GetAll()
                                                    join tv in taxMasterRepo.TaxVersionRepository.Find(x => x.TaxVersionId == taxVersionId).ToList()
                                                     on tm.TaxMasterId equals tv.TaxMasterId select new { tm.MarketId ,tm.TaxMasterId,tm.Priority}).FirstOrDefault();
                                    var lstValidTaxName = (from tm in taxMasterRepo.TaxMasterRepository.Find(x => x.TaxMasterId != LstTxMrId.TaxMasterId).ToList()
                                                           join m in taxMasterRepo.MarketRepository.Find(x => x.MarketId == LstTxMrId.MarketId).ToList()
                                                           on tm.MarketId equals m.MarketId
                                                           where tm.Priority < LstTxMrId.Priority
                                                           select tm.TaxName).ToList();

                                    foreach (var ValidTaxName in lstValidTaxName)
                                    {
                                        if (lsterrorId.Contains(ValidTaxName.ToUpper()))
                                        {
                                            builder.Replace(ValidTaxName.Trim().ToUpper(), ((ValidTaxName.Length + 1.01) * (ValidTaxName.Length * 1.01)).ToString());

                                            lsterrorId.Remove(ValidTaxName.ToUpper());
                                        }
                                    }
                                }


                                if (lsterrorId.Count > 0)
                                {
                                    string variables = "'" + String.Join("','", lsterrorId);
                                    variables = variables + "'";
                                    if (lsterrorId.Count!=1)
                                    {
                                        throw new InvalidOperationException(variables + Resource.GetResxValueByName("Invarmsg"));
                                    }
                                    else
                                        throw new InvalidOperationException(variables + Resource.GetResxValueByName("SingleInvarmsg"));
                                }
                            }
                            try
                            {
                                var lstresult = lstvariable.OrderByDescending(x => x.Length).ToList<String>();
                                foreach (var formualParam in lstresult)
                                {
                                    builder.Replace(formualParam.Trim().ToUpper(), ((lstvariable.IndexOf(formualParam)+1.01) * (lstvariable.IndexOf(formualParam)+1.01)).ToString());
                                }
                                var result = CheckFormula(builder.ToString());
                                decimal decimalOut;
                                if (!(decimal.TryParse(result, out decimalOut)))
                                {
                                    throw new InvalidOperationException(result);
                                }
                            }
                            catch (Exception)
                            {
                                throw new InvalidOperationException(Resource.GetResxValueByName("FormulaExpressionWrong"));
                            }

                            lstVariableId.Add(item.VariableId);
                            lstFormula.Add(new EF.Formula()
                            {
                                FormulaId = item.FormulaId,
                                VariableId = item.VariableId,
                                FormulaDefination = item.FormulaDefination,
                                MinValue = item.MinValue,
                                MaxValue = item.MaxValue,
                                Priority = item.Priority,
                                IsActive = item.IsActive,
                                CreatedBy = item.CreatedBy,
                                CreatedOn =DateTime.UtcNow,
                                UpdatedBy = item.UpdatedBy,
                                UpdatedOn =DateTime.UtcNow
                            });
                            formula.FormulaRepository.AddRange(lstFormula);
                            foreach (var variableitem in lstVariableId)
                            {
                                var formuladata = formula.FormulaRepository.Find(x => x.VariableId == variableitem).FirstOrDefault();
                                List<EF.FormulaDefinitionDependencyDetail> lstdependency = new List<EF.FormulaDefinitionDependencyDetail>();
                                foreach (var param in lstId)
                                {
                                    lstdependency.Add(new EF.FormulaDefinitionDependencyDetail()
                                   {
                                      FormulaId = formuladata.FormulaId,
                                      VariableId = param
                                    });
                                }
                                 formula.FormulaDefinitionDependencyDetailsRepository.AddRange(lstdependency);
                            }
                            lstVariableId.Clear();
                            lstId.Clear();
                            lstFormula.Clear();
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
        #region Update Formula Dependency Details
        /// <summary>
        /// To Update Formula and Dependency Details
        /// </summary>
        /// <param name="formulaValue">List of Formula Details to Upload</param>
        public void UpdateFormuladependency(IEnumerable<Formula> formulaValue)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    long TaxIdValue = 0 ;
                    long VersionId = 0;
                    List<long> lstVariableId = new List<long>();
                    List<string> lstFormulaFields = new List<string>();
                    var lstOperator = Regex.Split(Resource.GetResxValueByName("OperatorsList"), ",");
                    lstFormulaFields.Add("VariableId");
                    lstFormulaFields.Add("FormulaDefination");
                    lstFormulaFields.Add("MinValue");
                    lstFormulaFields.Add("MaxValue");
                    lstFormulaFields.Add("Priority");
                    lstFormulaFields.Add("IsActive");
                    lstFormulaFields.Add("UpdatedBy");
                    lstFormulaFields.Add("UpdatedOn");
                    using (var formula = new UnitofWork())
                    {
                        foreach (var data in formulaValue)
                        {
                            long fId = data.FormulaId;
                            var TaxId = formula.VariableRepository.Find(x => x.VariableId == data.VariableId).Select(x => x.TaxId).FirstOrDefault();
                            int Id = (int)(from u in formula.TaxVersionRepository.GetAll()
                                           join t in formula.TaxRepository.Find(x => x.TaxId == TaxId).ToList() on u.TaxVersionId equals t.TaxVersionId
                                           select u.TaxVersionStatusId).FirstOrDefault();
                            if (Id == 31)
                            {
                                throw new InvalidOperationException(Resource.GetResxValueByName("Publishedformulamsg"));

                            }
                            if (formula.FormulaRepository.Find(X => X.FormulaId == fId).ToList().Count == 0)
                            {
                                throw new InvalidOperationException(Resource.GetResxValueByName("CmnDataNotFound"));
                            }
                            else if (formula.FormulaRepository.Find(x => x.FormulaId != data.FormulaId && (x.VariableId == data.VariableId)).ToList().Count > 0)
                            {
                                using (var VariableRepo = new UnitofWork())
                                {
                                    var variableName = VariableRepo.VariableRepository.Find(x=>x.VariableId==data.VariableId).Select(x=>x.VariableName).FirstOrDefault();
                                    throw new InvalidOperationException(variableName + Resource.GetResxValueByName("VariableIdDuplication"));
                                }
                            }
                            if ((data.MinValue != null) && (data.MaxValue != null) && (data.MinValue > data.MaxValue))
                            {
                                throw new InvalidOperationException(Resource.GetResxValueByName("MinMaxMsg"));

                            }
                            var taxId = formula.VariableRepository.Find(x => x.VariableId == data.VariableId).Select(x => x.TaxId).FirstOrDefault();
                            TaxIdValue = taxId;
                            var taxFlowId = formula.TaxRepository.Find(x => x.TaxId == taxId).Select(x => x.TaxFlowId);
                            var taxVersionId = formula.TaxRepository.Find(x => x.TaxId == taxId).Select(x => x.TaxVersionId).FirstOrDefault();
                            var lsttax = formula.TaxRepository.Find(x => x.TaxVersionId == taxVersionId && x.TaxFlowId == taxFlowId.FirstOrDefault()).ToList();
                            var lstformula = formula.FormulaRepository.Find(x => x.FormulaId != data.FormulaId).ToList();
                            VersionId = taxVersionId;
                            var lstPriority = (from tv in lsttax
                                               join v in formula.VariableRepository.GetAll() on tv.TaxId equals v.TaxId
                                               join f in lstformula on v.VariableId equals f.VariableId
                                               select new { f.Priority }).ToList();
                            foreach (var param in lstPriority)
                            {
                                if (param.Priority == data.Priority)
                                {
                                    throw new InvalidOperationException(Resource.GetResxValueByName("PriorityDuplicatemsg"));
                                }
                            }
                        }
                    }
                    using (var formulaDependency = new UnitofWork())
                    {
                        List<EF.Formula> lstFormula = new List<EF.Formula>();
                        foreach (var data in formulaValue)
                        {
                            lstVariableId.Add(data.VariableId);
                            lstFormula.Add(new EF.Formula()
                            {
                                FormulaId = data.FormulaId,
                                VariableId = data.VariableId,
                                FormulaDefination = data.FormulaDefination,
                                MinValue = data.MinValue,
                                MaxValue = data.MaxValue,
                                Priority = data.Priority,
                                IsActive = data.IsActive,
                                CreatedBy = data.CreatedBy,
                                CreatedOn = data.CreatedOn,
                                UpdatedBy = data.UpdatedBy,
                                UpdatedOn = DateTime.UtcNow
                            });
                             var variableNames = GetVariables(data.FormulaDefination.ToUpper());
                            List<long> lstId = new List<long>();
                            List<string> lstvariable = new List<string>();
                            List<string> lsterrorId = new List<string>();
                            foreach (var content in variableNames)
                            {
                                var trimmedData = content.ToUpper().Trim();
                                var lstVariable = formulaDependency.VariableRepository.Find(x => x.VariableName.ToUpper() == trimmedData && x.TaxId == TaxIdValue).FirstOrDefault();
                                if (lstVariable != null)
                                {
                                    lstId.Add(lstVariable.VariableId);
                                    lstvariable.Add(lstVariable.VariableName.ToUpper().Trim());
                                }
                                else if (!content.Contains("\"") )
                                {
                                    decimal decimalData = 0;
                                    if ((!lstOperator.Contains(content)) && (!decimal.TryParse(content, out decimalData)) && content != " ")
                                    {
                                        lsterrorId.Add(content);
                                    }
                                }
                                else if(content.Contains("\"") && Regex.Matches(Regex.Escape(content), "\"").Count != 2)
                                {
                                    lsterrorId.Add(content);
                                }
                            }
                            if (lstId.Contains(data.VariableId))
                            {
                                using (var VarRepo = new UnitofWork())
                                {
                                    var variableName = VarRepo.VariableRepository.Find(x => x.VariableId == data.VariableId).Select(x => x.VariableName).FirstOrDefault();
                                    throw new InvalidOperationException(variableName + Resource.GetResxValueByName("VariableIdmsg"));
                                }
                            }
                            var builder = new System.Text.StringBuilder(data.FormulaDefination.ToUpper());
                            if (lsterrorId.Count > 0)
                            {
                                using (var taxMasterRepo = new UnitofWork())
                                {
                                    var LstTxMrId = (from tm in taxMasterRepo.TaxMasterRepository.GetAll()
                                                     join tv in taxMasterRepo.TaxVersionRepository.Find(x => x.TaxVersionId == VersionId).ToList()
                                                      on tm.TaxMasterId equals tv.TaxMasterId
                                                     select new { tm.MarketId, tm.TaxMasterId, tm.Priority }).FirstOrDefault();
                                    var lstValidTaxName = (from tm in taxMasterRepo.TaxMasterRepository.Find(x => x.TaxMasterId != LstTxMrId.TaxMasterId).ToList()
                                                           join m in taxMasterRepo.MarketRepository.Find(x => x.MarketId == LstTxMrId.MarketId).ToList()
                                                           on tm.MarketId equals m.MarketId
                                                           where tm.Priority < LstTxMrId.Priority
                                                           select tm.TaxName).ToList();
                                    foreach (var ValidTaxName in lstValidTaxName)
                                    {
                                        if (lsterrorId.Contains(ValidTaxName.ToUpper()))
                                        {
                                            builder.Replace(ValidTaxName.Trim().ToUpper(), ((ValidTaxName.Length + 1.01) * (ValidTaxName.Length * 1.01)).ToString());
                                            lsterrorId.Remove(ValidTaxName.ToUpper());
                                        }
                                    }
                                }
                                if (lsterrorId.Count > 0)
                                {
                                    string variables = "'" + String.Join("','", lsterrorId);
                                    variables = variables + "'";
                                    if (lsterrorId.Count != 1)
                                    {
                                        throw new InvalidOperationException(variables + Resource.GetResxValueByName("Invarmsg"));
                                    }
                                    else
                                        throw new InvalidOperationException(variables + Resource.GetResxValueByName("SingleInvarmsg"));
                                }
                            }
                            try
                            {
                                foreach (var formualParam in lstvariable)
                                {
                                    builder.Replace(formualParam.Trim().ToUpper(), ((lstvariable.IndexOf(formualParam) + 1.01) * (lstvariable.IndexOf(formualParam) + 1.01)).ToString());
                                }
                                var result = CheckFormula(builder.ToString());
                                if(result== "Input string was not in a correct format.")
                                {
                                    throw new InvalidOperationException(Resource.GetResxValueByName("FormulaExpressionWrong"));
                                }
                                decimal decimalOut;
                                if (!(decimal.TryParse(result, out decimalOut)))
                                {
                                    throw new InvalidOperationException(result);
                                }
                            }
                            catch (Exception)
                            {
                                throw new InvalidOperationException(Resource.GetResxValueByName("FormulaExpressionWrong"));
                            }
                            List<EF.FormulaDefinitionDependencyDetail> lstDelete = formulaDependency.FormulaDefinitionDependencyDetailsRepository.Find(x => x.FormulaId == data.FormulaId).ToList();
                            formulaDependency.FormulaDefinitionDependencyDetailsRepository.RemoveRange(lstDelete); ;
                            List<EF.FormulaDefinitionDependencyDetail> lstdependency = new List<EF.FormulaDefinitionDependencyDetail>();
                            foreach (var param in lstId)
                            {
                                lstdependency.Add(new EF.FormulaDefinitionDependencyDetail()
                                {
                                    FormulaId = data.FormulaId,
                                    VariableId = param
                                });
                            }
                            formulaDependency.FormulaDefinitionDependencyDetailsRepository.AddRange(lstdependency);
                        }
                        formulaDependency.FormulaRepository.UpdateRange(lstFormula, lstFormulaFields);
                    }
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        #endregion
        public List<TestVariable> GetTestFormula(int formulaId)
        {
            try
            {
                using (var formula= new UnitofWork())
                {
                    var lstformuladependents = formula.FormulaDefinitionDependencyDetailsRepository.Find(x => x.FormulaId == formulaId).ToList();
                   var lstvariables = (from v in formula.VariableRepository.GetAll()
                                       join f in lstformuladependents on v.VariableId equals f.VariableId
                                       select v).ToList();
                    string formulaDefinition = formula.FormulaRepository.Find(x => x.FormulaId == formulaId).Select(x => x.FormulaDefination).FirstOrDefault();
                    formulaDefinition = formulaDefinition.ToUpper();
                    var variableNames = GetVariables(formulaDefinition);
                    var lstOperator = Regex.Split(Resource.GetResxValueByName("OperatorsList"), ",");
                    foreach (var item in lstOperator)
                    {
                        if (variableNames.Contains(item))
                        {
                            variableNames.Remove(item);
                        }
                    }
                    List<TestVariable> variables = new List<TestVariable>();
                    var distinctVariableNames = (from d in variableNames select d.ToUpper().Trim()).Distinct().ToList();
                    foreach (var param in distinctVariableNames)
                    {
                        foreach (var variableitem in lstvariables)
                        {
                            if (variableitem.VariableName.ToUpper()==param.ToUpper())
                            {
                                variables.Add(new TestVariable()
                                {
                                    VariableId = variableitem.VariableId,
                                    Name = param,
                                    Value = null,
                                    VariableTypeId =variableitem.VariableTypeId,
                                    TestValue=variableitem.TestValue
                                });

                            }

                        };
                    }
                    //TODO : Get Fixed variable value from database
                    var variableIds = formula.FormulaDefinitionDependencyDetailsRepository.Find(x => x.FormulaId == formulaId).Select(x => x.VariableId);
                    var variabledetails = (from ld in formula.VariableRepository.GetAll()
                                           join tm in variableIds on ld.VariableId equals tm
                                           where ld.VariableTypeId== Helper.iFixed
                                           select new {  ld.VariableName, ld.Value, ld.UnitTypeId,ld.VariableId,ld.VariableTypeId,ld.TestValue }).ToList();
                    List<TestVariable> variables1 = new List<TestVariable>();
                    foreach(var data in variabledetails)
                    {
                        variables1.Add(new TestVariable()
                        {
                            VariableId=data.VariableId,
                            Name = data.VariableName.ToUpper().Trim(),
                            Value=data.Value.ToString().Trim(),
                            VariableTypeId=data.VariableTypeId,
                            TestValue=data.TestValue
                         //   Value = data.UnitTypeId == Helper.iPercentage ? data.Value / 100 : data.Value
                        });
                    }
                    var notMatchedVariables = variables
    .Where(p2 => !variables1
    .Any(p1 => p1.Name == p2.Name ))
    .ToList();
                    foreach (var data in notMatchedVariables)
                    {
                        variables1.Add(new TestVariable()
                        {VariableId=data.VariableId,
                            Name = data.Name,
                            Value = data.Value,
                            VariableTypeId=data.VariableTypeId,
                            TestValue=data.TestValue
                        });
                    }
                    return variables1;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string TestFormula(List<TestFormula> testFormula)
        {
            using (var formulaRepo = new UnitofWork())
            {
                foreach (var item in testFormula)
                {item.Definition=item.Definition.Replace(" ", "");
                    foreach (var param in item.Variable)
                    {
                        param.Name=param.Name.Replace(" ", "");

                        if (formulaRepo.VariableRepository.Find(x=>x.VariableId==param.VariableId&&x.UnitTypeId==Helper.iPercentage).ToList().Count>0)
                        {
                            param.Value =(Convert.ToDecimal( param.Value) / 100).ToString();
                        }
                        else
                                {
                            param.Value = param.Value.Replace("\"", "");
                        }
                    }
                }
            }
            var result = GetParseFormula(testFormula);
            return result;

        }
        public string CheckFormula(string testFormula)
        {
            try
            {
                var result = ValidateFormula(testFormula);
                return result;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        #region test Formula
        public static string GetParseFormula(List<TestFormula> testformula)
        {
            string result = string.Empty;
            HttpClient client = new HttpClient();
            string url = System.Configuration.ConfigurationManager.AppSettings["TaxEngineUrl"]; //Environment.GetEnvironmentVariable("TaxEngineUrl"),
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.PostAsJsonAsync("api/TaxEngine/TestFormula", testformula).Result;
            if (response.IsSuccessStatusCode)
            {
             string    value = response.Content.ReadAsStringAsync().Result;


                result = value.Trim(new char[] { '\"' });
            }
            else
            {
                result = ("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
                return result;
        }
        #endregion
        #region Validate Formula
        public static dynamic ValidateFormula(string testformula)
        {
            try
            {
                string result = string.Empty;
                HttpClient client = new HttpClient();
                string url = System.Configuration.ConfigurationManager.AppSettings["TaxEngineUrl"]; //Environment.GetEnvironmentVariable("TaxEngineUrl"),
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("api/TaxEngine/Post", testformula).Result;
                if (response.IsSuccessStatusCode)
                {
                    string value = response.Content.ReadAsStringAsync().Result.ToString();
                    result = value.Trim(new char[] { '\"' });
                    return result;
                }
                else
                {
                    result = ("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
                    throw new InvalidOperationException(result);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException( ex.Message);
            }
        }
        #endregion
        #region Method to Get Variables
        /// <summary>
        /// Method to get variable names from formula definition
        /// </summary>
        /// <param name="formula">formula definition</param>
        /// <returns>List of variable names as strings</returns>
        public List<string> GetVariables(string formula)
        {
            var operators = new List<string> {"<>","<=",">=",">","<","+","-","*","/","^","%","(",")","=",","};
            int tempVariableNames;
            var result = formula
                .Split(operators.ToArray(), StringSplitOptions.RemoveEmptyEntries)
                .Where(operand => !int.TryParse(operand[0].ToString(), out tempVariableNames))
                .Where(s => !string.IsNullOrWhiteSpace(s)).OrderByDescending(s=>s.Length).Select(s=>s.Trim()).Distinct().ToList<string>();
            List<string> lstData = new List<string>();
            foreach(var data in result)
            {
               if( !Common.IsNumeric(data))
                {
                    lstData.Add(data);
                }
            }
            return lstData;
        }
        #endregion
        #endregion
    }
    public class TestFormula
    {
        public string Definition { get; set; }
        public List<TestVariable> Variable { get; set; }
    }
    public class TestVariable
    {
        [JsonProperty(PropertyName = "variableId")]
        public long VariableId { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
        [JsonProperty(PropertyName = "variableTypeId")]
        public int VariableTypeId { get; set; }
        [JsonProperty(PropertyName = "testValue")]
        public string TestValue { get; set; }

    }
   public class FormulaVariableTest
    {
        [JsonProperty(PropertyName = "variable")]
        public List<VariableTest> Variable { get; set; }
    }
    public class VariableTest
    {
        [JsonProperty(PropertyName = "variableId")]
        [Required(ErrorMessage = "variable id is required")]
        public long Id { get; set; }
        [JsonProperty(PropertyName ="name")]
        [Required(ErrorMessage ="variable name is required")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "value")]
        [Required(ErrorMessage = "Value is required")]
        public string Value { get; set; }
        [JsonProperty(PropertyName = "definition")]
        public string Definition { get; set; }
    }

    public class FormulaCalculationOrder
    {
        [JsonProperty(PropertyName = "formulaName")]
        public string FormulaName { get; set; }
        [JsonProperty(PropertyName = "formulaId")]
        public long FormulaId { get; set; }
        [JsonProperty(PropertyName = "calculationOrder")]
        public int CalculationOrder { get; set; }
    }
}