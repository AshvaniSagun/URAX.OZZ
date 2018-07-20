using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Routing;

namespace UraxUIServiceWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();
            //TODO : Commented for checking multiple methods in a single Controller
            config.Routes.MapHttpRoute("DefaultApiWithId", "api/{controller}/{id}", new { id = RouteParameter.Optional }, new { id = @"\d+" });
            config.Routes.MapHttpRoute("DefaultApiWithAction", "api/{controller}/{action}");
            config.Routes.MapHttpRoute("DefaultApiGet", "api/{controller}", new { action = "Get" }, new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) });
            config.Routes.MapHttpRoute("DefaultApiPost", "api/{controller}", new { action = "Post" }, new { httpMethod = new HttpMethodConstraint(HttpMethod.Post) });
            
        }

        public class MethodOverrideHandler : DelegatingHandler
        {
            readonly string[] _methods = { "DELETE", "HEAD", "PUT" };
            const string _header = "X-HTTP-Method-Override";

            protected override Task<HttpResponseMessage> SendAsync(
                HttpRequestMessage request, CancellationToken cancellationToken)
            {
                // Check for HTTP POST with the X-HTTP-Method-Override header.
                if (request.Method == HttpMethod.Post && request.Headers.Contains(_header))
                {
                    // Check if the header value is in our methods list.
                    var method = request.Headers.GetValues(_header).FirstOrDefault();
                    if (_methods.Contains(method, StringComparer.InvariantCultureIgnoreCase))
                    {
                        // Change the request method.
                        request.Method = new HttpMethod(method);
                    }
                }
                return base.SendAsync(request, cancellationToken);
            }
        }
    }
}
