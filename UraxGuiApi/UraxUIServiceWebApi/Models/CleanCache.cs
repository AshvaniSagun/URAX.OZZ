using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace UraxUIServiceWebApi.Models
{
    public class CleanCache
    {
        public static void ClearMarketCache()
        {
            try
            {
                string result = string.Empty;
                HttpClient client = new HttpClient();
                string url = System.Configuration.ConfigurationManager.AppSettings["TaxEngineUrl"]; 
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("api/CalculateTax/ClearMarketDataCache").Result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //ClearLocalTaxNameCache
        public static void ClearLocalTaxNameCache()
        {
            try
            {
                string result = string.Empty;
                HttpClient client = new HttpClient();
                string url = System.Configuration.ConfigurationManager.AppSettings["TaxEngineUrl"];
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("api/CalculateTax/ClearLocalTaxNameCache").Result;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}