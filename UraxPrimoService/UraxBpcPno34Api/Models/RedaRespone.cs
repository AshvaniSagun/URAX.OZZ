using Newtonsoft.Json;
using Pno34ReqRespWebApi.Models;
using RestSharp;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UraxBPCPNO34Api.Models;
using System.Diagnostics;
using System;
// vinod code for reda integration 
namespace UraxBpcPno34Api.Models
{
    public class REDAIndividualValuesResponse
    {
        public URAXResponse REDAIndividualValues { get; set; }
    }

    public class URAXRequest
    {
        public URAXREDAIndividualValuesRequest REDAIndividualValuesRequest { get; set; }
    }

    public class URAXREDAIndividualValuesRequest
    {
        public URAXHeader Header { get; set; }
        public URAXOrder Order { get; set; }
    }

    #region Response

    public class URAXResponse
    {
        public URAXHeader Header { get; set; }
        public URAXOrder Order { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public URAXVehicleInfo VehicleInfo { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public URAXWeight Weight { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public URAXCO2 CO2 { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public URAXFuelConsumption FuelConsumption { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public URAXElectricEnergyConsumption ElectricEnergyConsumption { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public URAXElectricRange ElectricRange { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ErrorMessage ErrorMessage { get; set; }
    }

    #endregion

    #region Properties

    #region Header
    public class ErrorMessage
    {
        public string messageText { get; set; }


    }

    public class URAXHeader
    {
        public string TimeStamp { get; set; }
        public string SchemaVersion { get; set; }
        public string RequestTimeStamp { get; set; }
        public string ResponseCode { get; set; }
    }

    #endregion

    #region PNO

    public class URAXOrder
    {
        public string Occurence_Cd { get; set; }
        public string Occurence_Desc { get; set; }
        public string StructureWeek { get; set; }
        public string PNO12 { get; set; }
        public string Colour_Code { get; set; }
        public string Upholstery_Code { get; set; }
        public string S_Msg_Code { get; set; }
        public string[] Options { get; set; }
    }

    #endregion

    #region VehicleInfo

    public class URAXVehicleInfo
    {
        public string Propulsion { get; set; }
    }

    #endregion

    #region Weight

    public class URAXWeight
    {
        public int? MassInRunningOrderTotal { get; set; }
        public int? HomologationCurbWeightTotal { get; set; }
        public int? TPMaxLadenMass { get; set; }

    }

    #endregion

    #region CO2

    public class URAXCO2
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public URAXNEDC_Conventional_CO2 NEDC_Conventional_CO2 { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public URAXWLTP_Conventional_CO2 WLTP_Conventional_CO2 { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public URAXNEDC_PHEV_CO2 NEDC_PHEV_CO2 { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public URAXWLTP_PHEV_CO2 WLTP_PHEV_CO2 { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public URAXNEDC_HEV_CO2 NEDC_HEV_CO2 { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public URAXWLTP_HEV_CO2 WLTP_HEV_CO2 { get; set; }
    }

    public class URAXNEDC_Conventional_CO2
    {
        public int? NEDC_CO2_Combined { get; set; }
        public int? NEDC_CO2_UDC { get; set; }
        public int? NEDC_CO2_EUDC { get; set; }
    }

    public class URAXWLTP_Conventional_CO2
    {
        public int? WLTP_CO2_Total { get; set; }
        public int? WLTP_CO2_Low { get; set; }
        public int? WLTP_CO2_Medium { get; set; }
        public int? WLTP_CO2_High { get; set; }
        public int? WLTP_CO2_Extra_High { get; set; }

    }

    public class URAXNEDC_PHEV_CO2
    {
        public int? NEDC_PHEV_CO2_Combined { get; set; }
        public int? NEDC_PHEV_CO2_Weighted_Combined { get; set; }
    }

    public class URAXWLTP_PHEV_CO2
    {
        public int? WLTP_PHEV_CO2_CS_Total { get; set; }
        public int? WLTP_PHEV_CO2_CS_Low { get; set; }
        public int? WLTP_PHEV_CO2_CS_Medium { get; set; }
        public int? WLTP_PHEV_CO2_CS_High { get; set; }
        public int? WLTP_PHEV_CO2_CS_Extra_High { get; set; }
        public int? WLTP_PHEV_CO2_CD_Total { get; set; }
        public int? WLTP_PHEV_CO2_Weighted_Total { get; set; }
    }

    public class URAXNEDC_HEV_CO2
    {
        public int? NEDC_HEV_CO2_Combined { get; set; }
        public int? NEDC_HEV_CO2_UDC { get; set; }
        public int? NEDC_HEV_CO2_EUDC { get; set; }
    }

    public class URAXWLTP_HEV_CO2
    {
        public int? WLTP_HEV_CO2_CS_Total { get; set; }
        public int? WLTP_HEV_CO2_CS_Low { get; set; }
        public int? WLTP_HEV_CO2_CS_Medium { get; set; }
        public int? WLTP_HEV_CO2_CS_High { get; set; }
        public int? WLTP_HEV_CO2_CS_Extra_High { get; set; }
    }

    #endregion

    #region FuelConsumption

    public class URAXFuelConsumption
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public URAXNEDC_Conventional_FC NEDC_Conventional_FC { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public URAXWLTP_Conventional_FC WLTP_Conventional_FC { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public URAXNEDC_PHEV_FC NEDC_PHEV_FC { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public URAXWLTP_PHEV_FC WLTP_PHEV_FC { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public URAXNEDC_HEV_FC NEDC_HEV_FC { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public URAXWLTP_HEV_FC WLTP_HEV_FC { get; set; }
    }

    public class URAXNEDC_Conventional_FC
    {
        public decimal? NEDC_FC_Combined { get; set; }
        public decimal? NEDC_FC_UDC { get; set; }
        public decimal? NEDC_FC_EUDC { get; set; }
    }

    public class URAXWLTP_Conventional_FC
    {
        public decimal? WLTP_FC_Total { get; set; }
        public decimal? WLTP_FC_Low { get; set; }
        public decimal? WLTP_FC_Medium { get; set; }
        public decimal? WLTP_FC_High { get; set; }
        public decimal? WLTP_FC_Extra_High { get; set; }
    }

    public class URAXNEDC_PHEV_FC
    {
        public decimal? NEDC_PHEV_FC_Combined { get; set; }
        public decimal? NEDC_PHEV_FC_Weighted_Combined { get; set; }
    }

    public class URAXWLTP_PHEV_FC
    {
        public decimal? WLTP_PHEV_FC_CS_Total { get; set; }
        public decimal? WLTP_PHEV_FC_CS_Low { get; set; }
        public decimal? WLTP_PHEV_FC_CS_Medium { get; set; }
        public decimal? WLTP_PHEV_FC_CS_High { get; set; }
        public decimal? WLTP_PHEV_FC_CS_Extra_High { get; set; }
        public decimal? WLTP_PHEV_FC_CD_Total { get; set; }
        public decimal? WLTP_PHEV_FC_Weighted_Total { get; set; }
    }

    public class URAXNEDC_HEV_FC
    {
        public decimal? NEDC_HEV_FC_Combined { get; set; }
        public decimal? NEDC_HEV_FC_UDC { get; set; }
        public decimal? NEDC_HEV_FC_EUDC { get; set; }
    }

    public class URAXWLTP_HEV_FC
    {
        public decimal? WLTP_HEV_FC_CS_Total { get; set; }
        public decimal? WLTP_HEV_FC_CS_Low { get; set; }
        public decimal? WLTP_HEV_FC_CS_Medium { get; set; }
        public decimal? WLTP_HEV_FC_CS_High { get; set; }
        public decimal? WLTP_HEV_FC_CS_Extra_High { get; set; }
    }

    #endregion FuelConsumption

    #region ElectricEnergyConsumption

    public class URAXElectricEnergyConsumption
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public URAXNEDC_PHEV_EC NEDC_PHEV_EC { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public URAXWLTP_PHEV_EC WLTP_PHEV_EC { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public URAXNEDC_BEV_EC NEDC_BEV_EC { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public URAXNWLTP_BEV_EC WLTP_BEV_EC { get; set; }
    }

    public class URAXNEDC_PHEV_EC
    {
        public int? NEDC_PHEV_EC_Combined { get; set; }
        public int? NEDC_PHEV_EC_Weighted_Combined { get; set; }
    }

    public class URAXWLTP_PHEV_EC
    {
        public int? WLTP_PHEV_EC_AC_CD_Total { get; set; }
        public int? WLTP_PHEV_EC_AC_Weighted_Total { get; set; }
        public int? WLTP_PHEV_EC_Total { get; set; }
        public int? WLTP_PHEV_EC_Low { get; set; }
        public int? WLTP_PHEV_EC_Medium { get; set; }
        public int? WLTP_PHEV_EC_High { get; set; }
        public int? WLTP_PHEV_EC_Extra_High { get; set; }
        public int? WLTP_PHEV_EC_City { get; set; }
    }

    public class URAXNEDC_BEV_EC
    {
        public int? NEDC_BEV_EC_Combined { get; set; }
    }

    public class URAXNWLTP_BEV_EC
    {
        public int? WLTP_BEV_EC_Total { get; set; }
        public int? WLTP_BEV_EC_Low { get; set; }
        public int? WLTP_BEV_EC_Medium { get; set; }
        public int? WLTP_BEV_EC_High { get; set; }
        public int? WLTP_BEV_EC_Extra_High { get; set; }
        public int? WLTP_BEV_EC_City { get; set; }
    }
    #endregion ElectricEnergyConsumption

    #region ElectricRange

    public class URAXElectricRange
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public URAXNEDC_PHEV_ER NEDC_PHEV_ER { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public URAXWLTP_PHEV_ER WLTP_PHEV_ER { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public URAXNEDC_BEV_ER NEDC_BEV_ER { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public URAXWLTP_BEV_ER WLTP_BEV_ER { get; set; }
    }

    public class URAXNEDC_PHEV_ER
    {
        public int? NEDC_PHEV_Electric_Range_Combined { get; set; }
    }

    public class URAXWLTP_PHEV_ER
    {
        public int? WLTP_PHEV_AER_Total { get; set; }
        public int? WLTP_PHEV_AER_City { get; set; }
        public int? WLTP_PHEV_EAER_Total { get; set; }
        public int? WLTP_PHEV_EAER_Low { get; set; }
        public int? WLTP_PHEV_EAER_Medium { get; set; }
        public int? WLTP_PHEV_EAER_High { get; set; }
        public int? WLTP_PHEV_EAER_Extra_High { get; set; }
        public int? WLTP_PHEV_EAER_City { get; set; }
    }

    public class URAXNEDC_BEV_ER
    {
        public int? NEDC_BEV_PER_Combined { get; set; }
    }

    public class URAXWLTP_BEV_ER
    {
        public int? WLTP_BEV_PER_Total { get; set; }
        public int? WLTP_BEV_PER_Low { get; set; }
        public int? WLTP_BEV_PER_Medium { get; set; }
        public int? WLTP_BEV_PER_High { get; set; }
        public int? WLTP_BEV_PER_Extra_High { get; set; }
        public int? WLTP_BEV_PER_City { get; set; }
    }

    #endregion

    #endregion
    public class RedaDictionaryList
    {
        public string Pno12 { get; set; }
        public Dictionary<string, string> RedaDictionary { get; set; }
    }
    public class RedaSendRequest
    {
        public static List<RedaDictionaryList> GetRedaParamInputDictionary(List<REDAIndividualValuesResponse> redaresponselist)
        {
            var lstDic = new List<RedaDictionaryList>();
            StringBuilder error = new StringBuilder();
            error.Append("Reda failed to provide parameters for following Pno12s-");
            if (redaresponselist.Contains(null))
            {
                UnitConversionData.LogRedaError("Reda failed to respond.");
            }
            else
            {
                foreach (var redaresponse in redaresponselist)
                {

                    if (redaresponse.REDAIndividualValues.ErrorMessage == null)
                    {
                        RedaDictionaryList dict = ConvertDataToDictionary(redaresponse);
                        lstDic.Add(dict);
                    }
                    else
                    {
                        error.Append("," + redaresponse.REDAIndividualValues.Order.PNO12);
                    }
                }
                if (error.ToString() != "Reda failed to provide parameters for following Pno12s-")
                {
                    UnitConversionData.LogRedaError(error.ToString());
                }
            }
            return lstDic;
        }
        public static RedaDictionaryList ConvertDataToDictionary(REDAIndividualValuesResponse redaresponse)
        {
            var dict = new Dictionary<string, string>();
            var order = redaresponse?.REDAIndividualValues?.Order?.ToDictionary();
            var vehicleInfo = redaresponse?.REDAIndividualValues?.VehicleInfo?.ToDictionary();
            var weight = redaresponse?.REDAIndividualValues?.Weight?.ToDictionary();
            var nedC_Conventional_CO2 = redaresponse?.REDAIndividualValues?.CO2?.NEDC_Conventional_CO2?.ToDictionary();
            var wLTP_Conventional_CO2 = redaresponse?.REDAIndividualValues?.CO2?.WLTP_Conventional_CO2?.ToDictionary();
            var nEDC_PHEV_CO2 = redaresponse?.REDAIndividualValues?.CO2?.NEDC_PHEV_CO2?.ToDictionary();
            var wLTP_PHEV_CO2 = redaresponse?.REDAIndividualValues?.CO2?.WLTP_PHEV_CO2?.ToDictionary();
            var nEDC_HEV_CO2 = redaresponse?.REDAIndividualValues?.CO2?.NEDC_HEV_CO2?.ToDictionary();
            var wLTP_HEV_CO2 = redaresponse?.REDAIndividualValues?.CO2?.WLTP_HEV_CO2?.ToDictionary();
            var nEDC_Conventional_FC = redaresponse?.REDAIndividualValues?.FuelConsumption?.NEDC_Conventional_FC?.ToDictionary();
            var wLTP_Conventional_FC = redaresponse?.REDAIndividualValues?.FuelConsumption?.WLTP_Conventional_FC?.ToDictionary();
            var nEDC_PHEV_FC = redaresponse?.REDAIndividualValues?.FuelConsumption?.NEDC_PHEV_FC?.ToDictionary();
            var wLTP_PHEV_FC = redaresponse?.REDAIndividualValues?.FuelConsumption?.WLTP_PHEV_FC?.ToDictionary();
            var nEDC_HEV_FC = redaresponse?.REDAIndividualValues?.FuelConsumption?.NEDC_HEV_FC?.ToDictionary();
            var wLTP_HEV_FC = redaresponse?.REDAIndividualValues?.FuelConsumption?.WLTP_HEV_FC?.ToDictionary();
            var nEDC_PHEV_EC = redaresponse?.REDAIndividualValues?.ElectricEnergyConsumption?.NEDC_PHEV_EC?.ToDictionary();
            var wLTP_PHEV_EC = redaresponse?.REDAIndividualValues?.ElectricEnergyConsumption?.WLTP_PHEV_EC?.ToDictionary();
            var nEDC_BEV_EC = redaresponse?.REDAIndividualValues?.ElectricEnergyConsumption?.NEDC_BEV_EC?.ToDictionary();
            var wLTP_BEV_EC = redaresponse?.REDAIndividualValues?.ElectricEnergyConsumption?.WLTP_BEV_EC?.ToDictionary();
            var nEDC_PHEV_ER = redaresponse?.REDAIndividualValues?.ElectricRange?.NEDC_PHEV_ER?.ToDictionary();
            var wLTP_PHEV_ER = redaresponse?.REDAIndividualValues?.ElectricRange?.WLTP_PHEV_ER?.ToDictionary();
            var nEDC_BEV_ER = redaresponse?.REDAIndividualValues?.ElectricRange?.NEDC_BEV_ER?.ToDictionary();
            var wLTP_BEV_ER = redaresponse?.REDAIndividualValues?.ElectricRange?.WLTP_BEV_ER?.ToDictionary();
            var lstDic = new List<IDictionary<string, string>>() { vehicleInfo, weight, nedC_Conventional_CO2 , wLTP_Conventional_CO2 ,
                            nEDC_PHEV_CO2,wLTP_PHEV_CO2,nEDC_HEV_CO2,wLTP_HEV_CO2,nEDC_Conventional_FC,wLTP_Conventional_FC,nEDC_PHEV_FC,
                            wLTP_PHEV_FC,nEDC_HEV_FC,wLTP_HEV_FC,nEDC_PHEV_EC,wLTP_PHEV_EC,nEDC_BEV_EC,wLTP_BEV_EC,nEDC_PHEV_ER,wLTP_PHEV_ER,
                            nEDC_BEV_ER,wLTP_BEV_ER};
            foreach (var item in lstDic)
            {
                if (item != null)
                {
                    dict = dict.Concat(item).ToDictionary(x => x.Key, x => x.Value);
                }
            }

            RedaDictionaryList result = new RedaDictionaryList
            {
                Pno12 = (string)order?["PNO12"],
                RedaDictionary = dict ?? null
            };
            return result;
        }
        public List<REDAIndividualValuesResponse> Getreadaresponselist(CalculateTaxCombined inputPno34Data)
        {
            try
            {
                Authorization authparm = new Authorization();
                var RedaRequestList = RedaRequest.CreateRedaRequest(inputPno34Data);// creata a requestlist to send for  reda request.
                List<REDAIndividualValuesResponse> REDAIndividualValuesResponse = new List<Models.REDAIndividualValuesResponse>();
                var authparmkey = authparm.GetAuthToken();// to get Authorization token.
                Parallel.ForEach(RedaRequestList, new ParallelOptions { MaxDegreeOfParallelism = 4 }, (redaitem) =>// (var redaitem in RedaRequestList)
                {
                    var tasks = GetRedaData(redaitem, authparmkey);
                    REDAIndividualValuesResponse.Add(tasks);

                });

                return REDAIndividualValuesResponse;

            }
            catch (Exception ex)
            {
                new Microsoft.ApplicationInsights.TelemetryClient().TrackException(ex);

                throw;
            }

        }

        private REDAIndividualValuesResponse GetRedaData(RedaRequest redaitem, Authorization authparm)
        {
            try
            {
                var clientreda = new RestClient(System.Environment.GetEnvironmentVariable("REDASERVICEURL"));
                var requestreda = new RestRequest(Method.POST);
                requestreda.AddParameter("Content-Type", "application/json", ParameterType.HttpHeader);
                requestreda.AddParameter("Authorization", authparm.Token_type + " " + authparm.Access_token, ParameterType.HttpHeader);
                requestreda.AddJsonBody(redaitem);
                IRestResponse redaresponse = clientreda.Execute(requestreda);
                if (redaresponse.StatusDescription == "Unauthorized")// if token experied
                {
                    authparm = authparm.GetAuthToken(false);
                    redaresponse = clientreda.Execute(requestreda);
                }
                var objNewRedaRespnse = JsonConvert.DeserializeObject<REDAIndividualValuesResponse>(redaresponse.Content.ToString());

                return objNewRedaRespnse;

            }
            catch (Exception ex)
            {
                new Microsoft.ApplicationInsights.TelemetryClient().TrackException(ex);

                throw;
            }

        }
    }
}
