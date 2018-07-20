using Microsoft.ApplicationInsights.DataContracts;
using Newtonsoft.Json;
using Pno34ReqRespWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UraxBpcPno34Api.Models
{
    class AppInsightsLogTracker
    {
        /// <summary>
        /// LogTaxNotCalculated
        /// </summary>
        /// <param name="req"></param>
        /// <param name="res"></param>
        public void LogTaxNotCalculated(CalculateTaxCombined req, CalculateTaxCombinedResponseOutput res)
        {
            try
            {
                var reqJson = LogExcecptionsIntoAppInsights<CalculateTaxCombined>(req);
                var resJson = LogExcecptionsIntoAppInsights<CalculateTaxCombinedResponseOutput>(res);
                reqJson = new List<string>(reqJson.Concat(resJson));
                TrackIntoAppInsights(reqJson);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// LogExcecptionsIntoAppInsights
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public IList<string> LogExcecptionsIntoAppInsights<T>(T obj)
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(obj, Formatting.None, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                });
                var lstjson = jsonString.Chop(8000);
                return lstjson;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// TrackIntoAppInsights
        /// </summary>
        /// <param name="strdata"></param>
        private static void TrackIntoAppInsights(IList<string> strdata)
        {
            try
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();

                foreach (var item in strdata.Select((value, i) => new { i, value }))
                {
                    var value = item.value;
                    var index = "jsonData" + item.i;
                    dic.Add(index, item.value);
                }
                var telemetry = new Microsoft.ApplicationInsights.TelemetryClient();
                telemetry.TrackTrace("Tax could not be calculated for PRIMO/DCOM included configurations",
                               SeverityLevel.Warning,
                               dic);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
    public static class StringChop
    {
        public static string[] Chop(this string value, int length)
        {
            try
            {
                int strLength = value.Length;
                int strCount = (strLength + length - 1) / length;
                string[] result = new string[strCount];
                for (int i = 0; i < strCount; ++i)
                {
                    result[i] = value.Substring(i * length, Math.Min(length, strLength));
                    strLength -= length;
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

