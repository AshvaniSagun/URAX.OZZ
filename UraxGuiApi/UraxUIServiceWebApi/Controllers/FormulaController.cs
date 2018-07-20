using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using UraxUIServiceWebApi.EF;
using UraxUIServiceWebApi.Models;

namespace UraxUIServiceWebApi.Controllers
{
    // [Authorize] // security integration  

    public class FormulaController : ApiController
    {
        readonly Formula formulaObj = new Formula();
        /// <summary>
        /// To Get formula 
        /// </summary>
        /// <param name="Id">an Integer which represents Formula Id</param>
        /// <returns>List of formulas</returns>
        [HttpGet]
        public HttpResponseMessage Get(int Id)
        {
            try
            {
                List<Formula> lstFormula = new List<Formula>();
                var result = formulaObj.GetFormulaById(Id);
                if (result.Count != 0)
                {
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
                    return Request.CreateResponse(HttpStatusCode.OK, lstFormula);
                }
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, Helper.sIdNotFound + Id);

            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }
        /// <summary>
        /// To Delete a formula Record
        /// </summary>
        /// <param name="formulaid">an Integer which represents Formula Id</param>
        /// <returns>Returns success message</returns>
        [HttpDelete]
        [Route("api/Formula/DeleteFormulaAndDependency")]
        public HttpResponseMessage Delete(int formulaid)
        {
            try
            {
              long TaxId=  formulaObj.DeleteFormulaAndDependency(formulaid);


                return Request.CreateResponse(HttpStatusCode.OK,formulaObj.GetFormulaByTaxFlowId(TaxId));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, Error.ParameterEmpty(ex.Message.ToString()));

            }
        }
        
        [HttpPost]
        [Route("api/Formula/addFormulaAndDependency")]
        public HttpResponseMessage AddFormulaAndDependency(IEnumerable<Formula> formulaValue)
        {
            try
            {

                if (ModelState.IsValid && (formulaValue != null))
                {
                    new Formula().AddFormuladependency(formulaValue);
                    return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails("Formulae"+Helper.sInsertSuccess,true));
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest,
                        Error.GetErrorDetails(string.Join(", ", ModelState.Values
                                                .SelectMany(x => x.Errors)
                                                .Select(x => x.ErrorMessage))));
                }
            }
            catch (Exception ex)
            {
                 if (ex.Message.Contains(Resource.GetResxValueByName("InvalidVarIdmsg")))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails(Resource.GetResxValueByName("InvalidVarIdmsg")));
                }
                else if (ex.Message.Contains(Resource.GetResxValueByName("FormulaExpressionWrong")))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails(Resource.GetResxValueByName("FormulaExpressionWrong")));
                }
                
                return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails(ex.Message.ToString()));
            }

        }

        [HttpPost]
        [Route("api/Formula/CheckFormula")]
        public HttpResponseMessage Check([FromBody]string formula)
        {
           
            try
            {

                if (ModelState.IsValid && (formula != null))
                {
                    var result = formulaObj.CheckFormula(formula);
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest,
                        Error.ParameterEmpty(string.Join(", ", ModelState.Values
                                                .SelectMany(x => x.Errors)
                                                .Select(x => x.ErrorMessage))));
                }
            }
            catch (Exception ex)
            {

                string message = String.Empty;
                string error = Resource.GetResxValueByName("MarketDuplicatemsg");
                if (ex.Message.Contains(error))
                {
                    message = error;
                }
                else
                {
                    message = ex.Message.ToString();
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError, message);


            }
        }
        [HttpPost]
        [Route("api/Formula/TestFormula")]
        public HttpResponseMessage TestFormula(List<FormulaVariableTest> testFormulaVariables)
        {
            
            try
            {
                if (ModelState.IsValid && (testFormulaVariables != null))
                {
                    List<TestFormula> testFormula = new List<TestFormula>();
                    List<TestVariable> lst = new List<TestVariable>();
                    using (URAXEntities context = new URAXEntities())
                    {
                        
                        string CommandText = @"SELECT UPPER(v.VariableName) AS VariableName,v.UnitTypeId  AS VariableId FROM dbo.FormulaDefinitionDependencyDetails fddd
                                            INNER JOIN dbo.Formula f ON fddd.FormulaId = f.FormulaId
                                            INNER JOIN dbo.Variable v ON fddd.VariableId = v.VariableId
                                            INNER JOIN dbo.ParameterDetails pd ON pd.ParameterId = v.UnitTypeId
                                            WHERE fddd.FormulaId =" + testFormulaVariables[0].Variable[0].Definition;
                        var variableType = context.Database.SqlQuery<VariableDropList>(CommandText).ToList();

                    foreach (var data in testFormulaVariables)
                        {
                            foreach (var param in data.Variable)
                            {
                                string strValue = Regex.Replace(param.Value.ToUpper().Trim(), @"[\s+]", "");
                                if (variableType.Any(x => x.VariableName == param.Name && x.VariableId != Helper.iText))
                                {
                                    decimal num;
                                    if (!decimal.TryParse(strValue, out num))
                                    {
                                        return Request.CreateResponse(HttpStatusCode.OK,
                                                  Error.GetErrorDetails("Value should be decimal /numeric."));
                                    }
                                }
                                else if(variableType.Any(x => x.VariableName == param.Name && x.VariableId == Helper.iText))
                                {
                                    strValue = "\"" + strValue +"\"";
                                }
                                lst.Add(new TestVariable()
                                {
                                    VariableId=param.Id,
                                    Name = param.Name,
                                    Value = strValue
                                });
                            }
                        }
                    }

                    List<Formula> formuladetails = formulaObj.GetFormulaById(Convert.ToInt32(testFormulaVariables[0].Variable[0].Definition));
                    if(formuladetails.Count>0)
                    {
                        testFormula.Add(new TestFormula()
                        {
                            Definition = formuladetails[0].FormulaDefination.ToUpper().Trim(),
                            Variable = lst
                        });
                        string result = formulaObj.TestFormula(testFormula);
                        Boolean IsSuccess = true;
                        decimal value;
                        if (Decimal.TryParse(result, out value))
                        {
                            IsSuccess = true;
                            decimal? IsMinMax = Convert.ToDecimal(result);
                            if (formuladetails[0].MinValue != null && formuladetails[0].MinValue > IsMinMax)
                            {
                                IsMinMax = formuladetails[0].MinValue;
                            }
                            else if (formuladetails[0].MaxValue != null && formuladetails[0].MaxValue < IsMinMax)
                            {
                                IsMinMax = formuladetails[0].MaxValue;
                            }
                            result = IsMinMax.ToString();
                        }

                        else
                            IsSuccess = false;

                        return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails(result, IsSuccess));



                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK,
                   Error.GetErrorDetails("Formula is not available"));
                    }
                }
                else
                {
                    var  strMessage = string.Join("",ModelState.Values
                                                .SelectMany(x => x.Errors)
                                                .Select(x => x.ErrorMessage)).Trim();
                    if(strMessage=="")
                    {
                        return Request.CreateResponse(HttpStatusCode.OK,
                   Error.GetErrorDetails("Value should be decimal /numeric."));
                    }

                    return Request.CreateResponse(HttpStatusCode.OK,
                        Error.GetErrorDetails(string.Join(", ", ModelState.Values
                                                .SelectMany(x => x.Errors)
                                                .Select(x => x.ErrorMessage))));
                }
            }
            catch (Exception ex)
            {

                string message = String.Empty;
                string error = Resource.GetResxValueByName("MarketDuplicatemsg");
                if (ex.Message.Contains(error))
                {
                    message = error;
                }
                else
                {
                    message = ex.Message.ToString();
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError, message);


            }
        }
        [HttpGet]
        [Route("api/Formula/GetTestFormula")]
        public HttpResponseMessage GetTestFormula(int formulaId)
        {
            try
            {

                if (ModelState.IsValid && (formulaId != 0))
                {
                    var result = formulaObj.GetTestFormula(formulaId);
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest,
                        Error.ParameterEmpty(string.Join(", ", ModelState.Values
                                                .SelectMany(x => x.Errors)
                                                .Select(x => x.ErrorMessage))));
                }
            }
            catch (Exception ex)
            {

                string message = String.Empty;
                string error = Resource.GetResxValueByName("MarketDuplicatemsg");
                if (ex.Message.Contains(error))
                {
                    message = error;
                }
                else
                {
                    message = ex.Message.ToString();
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError, message);


            }
        }
       
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, GetFormulaList());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, Error.ParameterEmpty(ex.Message.ToString()));
            }
        }

        [HttpPut]
        [Route("api/Formula/UpdateFormulaAndDependency")]
        public HttpResponseMessage UpdateFormulaAndDependency([FromBody] IEnumerable<Formula> formulaValue)
        {
            try
            {
                if (ModelState.IsValid && formulaValue != null)
                {
                    formulaObj.UpdateFormuladependency(formulaValue);
                    return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails("Formulae" + Helper.sUpdateSuccess, true));
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest,
                         Error.GetErrorDetails(string.Join(", ", ModelState.Values
                                                 .SelectMany(x => x.Errors)
                                                 .Select(x => x.ErrorMessage))));

                }
            }
            catch (Exception ex)
            {

                if (ex.Message.Contains(Resource.GetResxValueByName("FormulaExpressionWrong")))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails(Resource.GetResxValueByName("FormulaExpressionWrong")));
                }
                return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails(ex.Message.ToString()));

            }
        }

        [HttpGet]
        [Route("api/Formula/GetFormulaDetails")]

        public HttpResponseMessage FormualaDetails(long TaxFlowId)
        {
            try
            {

                List<Formula> lstFormula = formulaObj.GetFormulaByTaxFlowId(TaxFlowId);
                if (lstFormula.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, lstFormula);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, Helper.sIdNotFound + TaxFlowId);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }

      
        private List<Formula> GetFormulaList()
        {
            List<Formula> lstFormula = new List<Formula>();
            try
            {
                var result = formulaObj.GetFormula();
                foreach (var param in result)
                {
                    lstFormula.Add(new Formula()
                    {
                       FormulaId = (int)param.FormulaId
                        
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }

            return lstFormula;
        }
      
        

        #region Calculation Order Swap
        [HttpGet]
        [Route("api/Formula/GetCalculationOrder")]
        public HttpResponseMessage GetCalculationOrder(long taxId, long formulaId)
        {
            try
            {
                List<FormulaCalculationOrder> lstCalculationOrder = formulaObj.GetFormulaCalculationOrderByTaxId(taxId,formulaId);

                return Request.CreateResponse(HttpStatusCode.OK, lstCalculationOrder);
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        [HttpPut]
        [Route("api/Formula/SwapCalculationOrder")]
        public HttpResponseMessage SwapCalculationOrder(long formulaId, long swapformulaId, string loginUser)
        {
            try
            {
                if (ModelState.IsValid && (loginUser != null))
                {
                    formulaObj.SwapformulaCalculationOrderDetails(formulaId, swapformulaId, loginUser);
                    return Request.CreateResponse(HttpStatusCode.Created, Error.GetErrorDetails(Helper.sUpdateSuccess, true));
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest,
                        Error.GetErrorDetails(string.Join(", ", ModelState.Values
                                                .SelectMany(x => x.Errors)
                                                .Select(x => x.ErrorMessage))));
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails(ex.Message.ToString()));
            }
        }
        [HttpGet]
        [Route("api/Formula/GetNewCalculationOrder")]
        public HttpResponseMessage GetNewCalculationOrder(long taxId)
        {
            try
            {
                List<VariableDropList> lstCalculationOrder = formulaObj.GetNewCalculationOrderByTaxId(taxId);

                return Request.CreateResponse(HttpStatusCode.OK, lstCalculationOrder);
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }
        #endregion

    }

}
