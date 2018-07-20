using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace UraxBpcPno34Api.Models
{

    public static class ApiCommunicator
        {
            public static dynamic GetParseFormula(string formula)
            {
            try
            {
                string result = string.Empty;
                HttpClient client = new HttpClient();
                string url = Environment.GetEnvironmentVariable("TaxEngineUrl");
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("api/TaxEngine", formula).Result;
                if (response.IsSuccessStatusCode)
                {
                    var str = response.Content.ReadAsStringAsync().Result;
                    dynamic json = JsonConvert.DeserializeObject(str);
                    return json;
                }
                else
                {
                    result = ("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
                }
                return result;
            }
            catch (Exception ex)
            {
                new Microsoft.ApplicationInsights.TelemetryClient().TrackException(ex);
                throw;
            }
            }
        }
  
}
