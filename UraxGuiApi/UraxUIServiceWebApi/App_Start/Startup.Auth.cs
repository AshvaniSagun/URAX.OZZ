using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens;
using System.Linq;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.ActiveDirectory;
using Owin;
using System.Net;
using System.Net.Http;
namespace UraxUIServiceWebApi
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            var tenant = ConfigurationManager.AppSettings["Tenant"];//"volvocars.onmicrosoft.com";
            var audience = ConfigurationManager.AppSettings["Audience"];//"93d03314-171a-4f36-bd2a-061aa7cb4ed2";
            app.UseWindowsAzureActiveDirectoryBearerAuthentication(
                new WindowsAzureActiveDirectoryBearerAuthenticationOptions
                {
                    Tenant = tenant,
                    TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidAudience = audience
                    }
#if DEBUG
                    ,
                    BackchannelHttpHandler = new HttpClientHandler { Proxy = new WebProxy("http://proxy:83") }
#endif
                });
        }
    }
}
