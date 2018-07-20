using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EF = UraxUIServiceWebApi.EF;
using UraxUIServiceWebApi.Models;


namespace UraxUIServiceWebApi.Controllers
{
    // [Authorize] // security integration  

    public class VariablesController : ApiController
    {
        readonly Variable variableObj = new Variable();

        private  List<VariableList> GetVariableList()
        {
            List<VariableList> lstVariable = new List<VariableList>();
            try
            {
                var result = variableObj.GetVariableDetailWithUnitAndType();
                
                
                foreach (var param in result)
                {
                    lstVariable.Add(new VariableList()
                    {
                        VariableId = (int)param.VariableId,
                        TaxId = (int)param.TaxId,
                        VariableName = param.VariableName,
                        VariableValue=param.VariableValue,
                        UnitTypeId=(int)param.UnitTypeId,
                        VariableTypeId = param.VariableTypeId,
                        IsLookUp  = (bool)param.IsLookUp,
                        IsActive = param.IsActive,
                        CreatedBy = param.CreatedBy,
                        CreatedOn = param.CreatedOn,
                        UpdatedBy = param.UpdatedBy,
                        UpdatedOn = param.UpdatedOn,
                        UnitTypeName =param.UnitTypeName,                        
                        VariableTypeName=param.VariableTypeName,
                        TaxFlowValue=param.TaxFlowValue
                        
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }

            return lstVariable;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, GetVariableList());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, Error.ParameterEmpty(ex.Message.ToString()));
            }
        }

        [HttpPut]
        public HttpResponseMessage UpdateVariable(IEnumerable<Variable> variableValue)
        {
            try
            {
                if (ModelState.IsValid && variableValue != null)
                {
                    variableObj.UpdateVariable(variableValue);
                    return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails(Helper.sUpdateSuccess,true));

                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails(string.Join(", ", ModelState.Values
                                                .SelectMany(x => x.Errors)
                                                .Select(x => x.ErrorMessage))));

                 
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails(ex.Message.ToString()));

            }
        }


        [HttpPost]
        public HttpResponseMessage AddVariable(IEnumerable<Variable> variableValue)
        {
            try
            {

                if (ModelState.IsValid && (variableValue != null))
                {
                    variableObj.AddVariable(variableValue);

                    return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails(Helper.sInsertSuccess, true));

                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails(string.Join(", ", ModelState.Values
                                                     .SelectMany(x => x.Errors)
                                                     .Select(x => x.ErrorMessage))));
                }
            }
            catch (Exception ex)
            {
                
                
                return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails(ex.Message.ToString()));

            }

        }


        [HttpDelete]
        public HttpResponseMessage Delete(int variableId)
        {
            try
            {
               variableObj.DeleteVariable(variableId);
                return Request.CreateResponse(HttpStatusCode.OK,Error.GetErrorDetails(Helper.sDeleteSuccess,true));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails(ex.Message.ToString()));

            }
        }

        [HttpGet]
        public HttpResponseMessage Get(int Id)
        {
            try
            {
                List<Variable> lstVariable = new List<Variable>();
                var result = variableObj.GetVariable(Id);
                if (result.Count != 0)
                {
                    foreach (var param in result)
                    {
                        lstVariable.Add(new Variable()
                        {
                            VariableId = param.VariableId,
                            TaxId = param.TaxId,
                            VariableName = param.VariableName,
                             VariableValue = (decimal)param.Value,
                             UnitTypeId = (int)param.UnitTypeId,
                            VariableTypeId = param.VariableTypeId,
                           IsLookUp  = (bool)param.IslookUp,
                            IsActive = param.IsActive,
                            CreatedBy = param.CreatedBy,
                            CreatedOn = param.CreatedOn,
                            UpdatedBy = param.UpdatedBy,
                            UpdatedOn = param.UpdatedOn
                        });
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, lstVariable);
                }
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, Helper.sIdNotFound + Id);
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }

        [HttpGet]
        public HttpResponseMessage GetVariableDetail(int TaxId)
        {
            try
            {
                List<Variable> lstVariable  = GetVariabledetails( TaxId);
                if (lstVariable.Count >0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, lstVariable);
                }
                
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, Helper.sIdNotFound+ TaxId);
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }
        private List<Variable> GetVariabledetails(int TaxId)
        {
            List<Variable> lstVariable = new List<Variable>();

            var result = variableObj.GetVariableDetailWithUnitAndType(TaxId);
            if (result.Count != 0)
            {
                foreach (var param in result)
                {
                    lstVariable.Add(new Variable()
                    {
                        VariableId = param.VariableId,
                        TaxId = param.TaxId,
                        VariableName = param.VariableName,
                        VariableValue = param.VariableValue,
                        TestValue=param.TestValue,
                        UnitTypeId = (int)param.UnitTypeId,
                        VariableTypeId = param.VariableTypeId,
                        IsLookUp = (bool)param.IsLookUp,
                        IsActive = param.IsActive,
                        CreatedBy = param.CreatedBy,
                        CreatedOn = param.CreatedOn,
                        UpdatedBy = param.UpdatedBy,
                        UpdatedOn = param.UpdatedOn,
                        UnitTypeName = param.UnitTypeName,
                        VariableTypeName = param.VariableTypeName,
                        TaxFlowValue = param.TaxFlowValue

                    });
                }
            }
            return lstVariable;
        }

        [HttpGet]
        [Route("api/Variables/GetVariable")]
        public HttpResponseMessage GetVariableDetails()
        {
            try
            {

                return Request.CreateResponse(HttpStatusCode.OK, variableObj.GetVariableDetailWithUnitAndType());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, Error.ParameterEmpty(ex.Message.ToString()));
            }
        }

        [HttpGet]
        [Route("api/Variables/GetVariableDrp")]
        public HttpResponseMessage GetVariableDrp(int TaxFlowId)
        {
            try
            {
                List<VariableDropList> result = variableObj.GetVariableDetailForDrp(TaxFlowId);
                if(result.Count>0)
                return Request.CreateResponse(HttpStatusCode.OK, result);
                else
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,Helper.sIdNotFound + TaxFlowId);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, Error.ParameterEmpty(ex.Message.ToString()));
            }
        }

        // Dependency Parameters
        [HttpGet]
        [Route("api/Variables/GetDependencyParameter")]
        public HttpResponseMessage GetDependencyParameter(int TaxFlowId)
        {
            try
            {
                List<VariableDropList> result = variableObj.GetDependencyParameter(TaxFlowId);
                if (result.Count > 0)
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound,Helper.sIdNotFound + TaxFlowId);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, Error.ParameterEmpty(ex.Message.ToString()));
            }
        }
    }
}
