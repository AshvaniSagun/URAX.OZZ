using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UraxUIServiceWebApi.Repository;

namespace UraxUIServiceWebApi.Models
{
    public class SubdivisionCode
    {
        internal object GetSubdivisionCodeList()
        {
            List<VariableDropList> lstSubdivisionCode = new List<VariableDropList>();
                try
                {
                    using (var subdivisionCode = new UnitofWork())
                    {
                        var result = subdivisionCode.SubdivisionCodeRepository.GetAll().OrderBy(x => x.SubdivisionCode1).ToList();
                    foreach(var data in result)
                    {
                        lstSubdivisionCode.Add(new VariableDropList()
                        {
                            VariableId = data.SubdivisionCodeId,
                            VariableName = data.SubdivisionCode1
                        });
                    }
                    }
                return lstSubdivisionCode;
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
                }
            }

        internal object GetSubdivisionCodeListByCountryCodeId(int id)
        {
            List<VariableDropList> lstSubdivisionCode = new List<VariableDropList>();
            try
            {
                using (var subdivisionCode = new UnitofWork())
                {
                    var result = subdivisionCode.SubdivisionCodeRepository.Find(x=>x.CountryCodeId == id).OrderBy(x => x.SubdivisionCode1).ToList();
                    foreach (var data in result)
                    {
                        lstSubdivisionCode.Add(new VariableDropList()
                        {
                            VariableId = data.SubdivisionCodeId,
                            VariableName = data.SubdivisionCode1
                        });
                    }
                }
                return lstSubdivisionCode;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }
        }
    }
}