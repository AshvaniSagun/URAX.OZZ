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
    public class ParameterDetails
    {

        #region     ParameterDetails Property

        [JsonProperty(PropertyName = "parameterId")]
        public int ParameterId { get; set; }
        [JsonProperty(PropertyName = "parameterGroupId")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "ParameterGroupIdReq")]
        public int ParameterGroupId { get; set; }
        [JsonProperty(PropertyName = "value")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "ValueReq")]
        public string Value { get; set; }
        [JsonProperty(PropertyName = "isActive")]
        public bool IsActive { get; set; }

        [JsonProperty(PropertyName = "createdBy")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "CreatedByReq")]
        public string CreatedBy { get; set; }

        internal List<VariableDropList> GetInputParameter(int taxId, int typeId)
        {
            try
            {
                int id = 0;
               
                using (var parameterDetailsobj = new UnitofWork())
                {
                    var taxFlow = parameterDetailsobj.TaxRepository.Find(x => x.TaxId == taxId).Select(x => x.TaxFlowId).FirstOrDefault();
                    switch (taxFlow)
                    {
                        case 4:
                            id = 27;
                            break;
                        case 5:
                            id = 26;
                            break;
                        default:
                            id = 0;
                            break;
                    }
                    var  lstparameterDetails = parameterDetailsobj.ParameterDetailsRepository.Find(x => x.ParameterGroupId == 9 && x.IsActive == true && x.ParameterId != id).OrderBy(x => x.Value).ToList();
                    if (lstparameterDetails.Count == 0)
                    {
                        throw new InvalidOperationException(Resource.GetResxValueByName("CmnDataNotFound"));
                    }
                   // 26 MSRP 27 PRETAX
                    List<VariableDropList> lstparameterlist = new List<VariableDropList>();
                    foreach (var item in lstparameterDetails)
                    {
                        
                            lstparameterlist.Add(new VariableDropList()
                            {
                                VariableId = item.ParameterId,
                                VariableName = item.Value
                            });
                        
                        

                    }
                    //Get Pno12 parameter
                    var lstPno12parameterDetails = parameterDetailsobj.PnoVariableMasterRepository.Find(x=>x.Isactive==true&&x.GuiName!=null).OrderBy(x=>x.VariableName).ToList();
                    foreach(var data in lstPno12parameterDetails)
                    {

                        lstparameterlist.Add(new VariableDropList()
                        {
                            VariableId = data.VariableMasterId,
                            VariableName = data.GuiName.ToUpper()
                        });
                    }
                    lstparameterlist = lstparameterlist.OrderBy(x => x.VariableName).ToList();
                    return lstparameterlist;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        [JsonProperty(PropertyName = "createdOn")]
        public System.DateTime CreatedOn { get; set; }

        [JsonProperty(PropertyName = "updatedBy")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "UpdatedByReq")]
        public string UpdatedBy { get; set; }
        [JsonProperty(PropertyName = "updatedOn")]
        public System.DateTime UpdatedOn { get; set; }

        #endregion

        #region Get Parameter by Group Id
        /// <summary>
        /// To Get Parameter Details by Group Id
        /// </summary>
        /// <param name="Id">An intger which represents Parameter Group Id</param>
        /// <returns>List of parameter List</returns>
        public List<Parameterlist> GetParameterByGroupId(int Id)
        {
            try
            {
                using (var parameterDetailsobj = new UnitofWork())
                {
                    List<EF.ParameterDetail> lstparameterDetails = parameterDetailsobj.ParameterDetailsRepository.Find(x => x.ParameterGroupId == Id && x.IsActive == true).OrderBy(x=>x.Value).ToList();
                    if (lstparameterDetails.Count == 0)
                    {
                        throw new InvalidOperationException(Resource.GetResxValueByName("CmnDataNotFound"));
                    }

                    List<Parameterlist> lstparameterlist = new List<Parameterlist>();
                    foreach (var item in lstparameterDetails)
                    {
                        lstparameterlist.Add(new Parameterlist()
                        {
                            ParameterId = item.ParameterId,
                            Value = item.Value
                        });

                    }
                    return lstparameterlist;
                }

            }
            catch (Exception)
            {

                throw;
            }
        } 
        #endregion
    }
        public class Parameterlist
    {
        #region ParameterList Property
        [JsonProperty(PropertyName = "parameterId")]
        public int ParameterId { get; set; }
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; } 
        #endregion
    }
}