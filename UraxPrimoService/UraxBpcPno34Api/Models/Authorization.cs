using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using RestSharp;
using System.Runtime.Caching;

namespace UraxBpcPno34Api.Models
{
    public class Authorization
    {
        [JsonProperty(PropertyName = "token_type")]
        public string Token_type { get; set; }
        [JsonProperty(PropertyName = "scope")]
        public string Scope { get; set; }
        [JsonProperty(PropertyName = "expires_in")]
        public string Expires_in { get; set; }
        [JsonProperty(PropertyName = "ext_expires_in")]
        public string Ext_expires_in { get; set; }
        [JsonProperty(PropertyName = "expires_on")]
        public string Expires_on { get; set; }
        [JsonProperty(PropertyName = "not_before")]
        public string Not_before { get; set; }
        [JsonProperty(PropertyName = "resource")]
        public string Resource { get; set; }
        [JsonProperty(PropertyName = "access_token")]
        public string Access_token { get; set; }
        [JsonProperty(PropertyName = "refresh_token")]
        public string Refresh_token { get; set; }
        // methods for set authorization parameters
        public AuthorizationParameter SetAuthrizationValue()
        {
            try
            {
                AuthorizationParameter objsetparm = new AuthorizationParameter
                {
                    Tokenurl = Environment.GetEnvironmentVariable("TOKENURL"),
                    Redaresource = Environment.GetEnvironmentVariable("REDARESOURCE"),
                    Granttype = "password",
                    Clientid = Environment.GetEnvironmentVariable("AUTHCLIENTID"),
                    AuthResource = Environment.GetEnvironmentVariable("REDARESOURCE"),
                    Username = Environment.GetEnvironmentVariable("REDAUSERNAME"),
                    Password = Environment.GetEnvironmentVariable("REDAPASSWORD"),
                    AuthClient_secret = Environment.GetEnvironmentVariable("REDACLIENTSECRET"),
                    Redaserviceurl = Environment.GetEnvironmentVariable("REDASERVICEURL")
                };

                return objsetparm;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public Authorization GetAuthToken(bool Isfirst = true)
        {
            try
            {
                //Check Cache if exist 
                ObjectCache cache = MemoryCache.Default;
                if (cache.Contains("RedaAccessToken") && Isfirst == true)
                {
                    var cachedata = (Authorization)cache.Get("RedaAccessToken");
                    return cachedata;
                }
                else
                {
                    var objAuth = new Authorization();
                    var objAutParm = new AuthorizationParameter();
                    objAutParm = objAuth.SetAuthrizationValue();
                    var client = new RestClient(objAutParm.Tokenurl);
                    var request = new RestRequest(Method.POST);
                    request.AddHeader("cache-control", "no-cache");
                    request.AddHeader("content-type", "application/json");
                    request.AddParameter("grant_type", objAutParm.Granttype);
                    request.AddParameter("client_id", objAutParm.Clientid);
                    request.AddParameter("resource", objAutParm.AuthResource);
                    request.AddParameter("username", objAutParm.Username);
                    request.AddParameter("password", objAutParm.Password);
                    request.AddParameter("client_secret", objAutParm.AuthClient_secret);
                    request.RequestFormat = DataFormat.Json;
                    var response = client.Execute(request);
                    objAuth = JsonConvert.DeserializeObject<Authorization>(response.Content.ToString());
                    // store data in the cache    
                    CacheItemPolicy cacheitempolicy = new CacheItemPolicy
                    {
                        AbsoluteExpiration = DateTime.Now.AddMinutes(55)
                    };
                    cache.Add("RedaAccessToken", objAuth, cacheitempolicy);
                    //
                    return objAuth;
                }
            }
            catch (Exception ex)
            {
                new Microsoft.ApplicationInsights.TelemetryClient().TrackException(ex);

                throw;
            }

        }
    }
    public class AuthorizationParameter
    {
        public string Tokenurl { get; set; }
        public string Redaresource { get; set; }
        public string Granttype { get; set; }
        public string Clientid { get; set; }
        public string AuthResource { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Client_secret { get; set; }
        public string Redaserviceurl { get; set; }
        public string AuthClient_secret { get; internal set; }
    }

}
