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
using System.Web.Http;
using Microsoft.ApplicationInsights.Extensibility;

namespace UraxBpcPno34Api
{
    public static class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public static void ConfigureApp(IAppBuilder appBuilder)
        {
            TelemetryConfiguration.Active.InstrumentationKey = Environment.GetEnvironmentVariable("ApplicationInsightsInstrumentationKey"); ;

            var tenant = Environment.GetEnvironmentVariable("TENANT"); //"volvocars.onmicrosoft.com";
            var audience = Environment.GetEnvironmentVariable("AUDIENCE"); //"8a937989-e469-445f-88a6-e6a24f49da53";
            appBuilder.UseWindowsAzureActiveDirectoryBearerAuthentication(
                new WindowsAzureActiveDirectoryBearerAuthenticationOptions
                {
                    Tenant = tenant,
                    TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidAudience = audience
                    }

//#if DEBUG
//                            ,
//                    BackchannelHttpHandler = new HttpClientHandler { Proxy = new WebProxy("http://proxy:83") }
//#endif
                });
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            config.Filters.Add(new CollectRequestDurationFilterAttribute());
            config.EnableApplicationInsights();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            appBuilder.UseWebApi(config);
        }
    }
}
