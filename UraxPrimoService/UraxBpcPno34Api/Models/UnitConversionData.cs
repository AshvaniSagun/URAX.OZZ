using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using UraxBpcPno34Api.EF;
using System.Runtime.Caching;
using UraxBpcPno34Api.Models;

namespace UraxBPCPNO34Api.Models
{
public    class UnitConversionData
    {
        public string TaxTerritory { get; set; }
        public int FromUnitOfMeasurementId { get; set; }
        public int ToUnitOfMeasurementId { get; set; }
        public Decimal ConversionRate { get; set; }
        public string DefinitionName { get; set; }
      
        public static List<UnitConversionData> GetUnitConversionData(string bpccountrycode)
        {
            using (URAXEntities context = new URAXEntities())
            {
                try
                {
                    SqlParameter countryCode = new SqlParameter("@CountryCode", bpccountrycode);
                    List<UnitConversionData> lstResult = context.Database.SqlQuery<UnitConversionData>("GetUnitConversionData  @CountryCode", countryCode).ToList();
                    return lstResult;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        public static  void LogRedaError(string error)
        {
            new Microsoft.ApplicationInsights.TelemetryClient().TrackTrace(error);
        }
        public static List<RedaDictionaryList> GetUnitConvertedData(string countrycode,string taxTerritory, List<RedaDictionaryList> DictRedaParamList)
        {
            ObjectCache cache = MemoryCache.Default;
            var result = new List<UnitConversionData>();
            if (cache.Contains(countrycode))
            {
                var cachedata = (List<UnitConversionData>)cache.Get(countrycode);
                result.AddRange(cachedata);
            }
            else
            {
                var dataFromDb = GetUnitConversionData(countrycode);
                // store data in the cache    
                CacheItemPolicy cacheitempolicy = new CacheItemPolicy
                {
                    AbsoluteExpiration = DateTime.Now.AddHours(1.0)
                };
                cache.Add(countrycode, dataFromDb, cacheitempolicy);

                result = dataFromDb;
            }
            var conversionFormulaList = result.FindAll(x => x.TaxTerritory == taxTerritory).ToList();

            if (conversionFormulaList.Count > 0)
            {
                foreach (var DictReda in DictRedaParamList)
                {
                    foreach (var convdata in conversionFormulaList)
                    {
                        if (DictReda.RedaDictionary.ContainsKey(convdata.DefinitionName))
                        {
                            var Value = Convert.ToDecimal(DictReda.RedaDictionary[convdata.DefinitionName]);
                            var convRate = convdata.ConversionRate;
                            Value = convRate / Value;
                            DictReda.RedaDictionary[convdata.DefinitionName] = Value.ToString().Replace(",", ".");
                        }
                    }
                }
                
            }
            return DictRedaParamList;
        }
        public static List<RedaDictionaryList> GetMockRedaData()
        {
            var lstDic = new List<RedaDictionaryList>();
            Dictionary<string, string> DicRedaParamInput = new Dictionary<string, string>();
            DicRedaParamInput.Add("NEDC_FC_COMBINED", "110");
            DicRedaParamInput.Add("MassInRunningOrderTotal", "1000");
            DicRedaParamInput.Add("HomologationCurbWeightTotal", "1000");
            DicRedaParamInput.Add("TPMaxLadenMass", "1000");
            DicRedaParamInput.Add("WLTP_BEV_EC_Total", "1000");
            DicRedaParamInput.Add("WLTP_BEV_EC_Low", "1000");
            DicRedaParamInput.Add("WLTP_BEV_EC_Medium", "1000");
            DicRedaParamInput.Add("WLTP_BEV_EC_High", "1000");
            DicRedaParamInput.Add("WLTP_BEV_EC_Extra_High", "1000");
            DicRedaParamInput.Add("WLTP_BEV_EC_City", "1000");
            
            List<Dictionary<string, Dictionary<string, string>>> mockresult = new List<Dictionary<string, Dictionary<string, string>>>
                                                                {new Dictionary<string, Dictionary<string, string>>{{ "246A8MA04110", DicRedaParamInput }}};

            RedaDictionaryList dict = new RedaDictionaryList
            {
                RedaDictionary = DicRedaParamInput,
                Pno12 = "246A8MA04110"
            };
            dict.RedaDictionary.Add("ErrorMessageText", "");
            lstDic.Add(dict);
            return lstDic;
        }
        public static Dictionary<string, string> MapRedaToDefinitionName(Dictionary<string, string> dictionaryReda)
        {
            const string redaMapper = "REDAMAPPER";
            var result = new Dictionary<string, string>();
            ObjectCache cache = MemoryCache.Default;
            var lstmasterdata = new List<ParameterNameMapper>();
            if (cache.Contains(redaMapper))
            {
                var cachedata = (List<ParameterNameMapper>)cache.Get(redaMapper);
                lstmasterdata.AddRange(cachedata);
            }
            else
            {
                var dataFromDb = GetDefinitionNameMappingMasterData();
                // store data in the cache    
                CacheItemPolicy cacheitempolicy = new CacheItemPolicy
                {
                    AbsoluteExpiration = DateTime.Now.AddHours(1.0)
                };
                cache.Add(redaMapper, dataFromDb, cacheitempolicy);

                lstmasterdata = dataFromDb;
            }
            foreach (var data in dictionaryReda)
            {
                var masterdata = lstmasterdata.Where(x => x.ShortName.ToUpper() == data.Key.ToUpper()).FirstOrDefault();
                if (masterdata != null)
                {
                    result.Add(masterdata.DefinitionName.ToUpper(), data.Value);
                }
                else
                {
                    result.Add(data.Key, data.Value);
                }
            }
            return result;
        }

        public static List<ParameterNameMapper> GetDefinitionNameMappingMasterData()
        {
            var result = new List<ParameterNameMapper>();
            using (URAXEntities context = new URAXEntities())
            {
                try
                {
                    string commandtext = @"SELECT ppd.DefinitionName AS DefinitionName,ppd.ShortName AS ShortName FROM dbo.Pno12ParameterDefinition ppd";
                    result = context.Database.SqlQuery<ParameterNameMapper>(commandtext).ToList();
                    return result;
                }
                catch (Exception)
                {

                    throw;
                }
            }

        }

    }
    public class ParameterNameMapper
    {
        public string DefinitionName { get; set; }
        public string ShortName { get; set; }
    }
}