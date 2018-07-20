using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Filters;

namespace UraxBpcPno34Api
{
    public class CollectRequestDurationFilterAttribute : ActionFilterAttribute
    {
        private readonly ConcurrentDictionary<HttpRequestMessage, RequestInformation> requests = new ConcurrentDictionary<HttpRequestMessage, RequestInformation>();

        private readonly TelemetryClient client = new TelemetryClient();

        public override Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            this.requests.TryAdd(actionContext.Request, new RequestInformation { StartDate = DateTime.Now });

            return base.OnActionExecutingAsync(actionContext, cancellationToken);
        }
       
        public override Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            if (this.requests.TryRemove(actionExecutedContext.Request, out var request))
            {
                var httpRequest = actionExecutedContext.Request;
                var httpResponse = actionExecutedContext.Response;

                if (httpRequest != null && httpResponse != null)
                {
                    var duration = DateTime.Now - request.StartDate;


                    string correlationId = null;

                    if (httpRequest.Headers.TryGetValues("X-Request-ID", out var values) && values.Count() > 0)
                    {
                        correlationId = values.First();
                    }
                    else if (httpRequest.Headers.TryGetValues("X-Correlation-ID", out values) && values.Count() > 0)
                    {
                        correlationId = values.First();
                    }



                    var requestTelemetry = new RequestTelemetry(httpRequest.RequestUri.ToString(), DateTime.Now, duration, httpResponse.StatusCode.ToString(), httpResponse.IsSuccessStatusCode);
                    requestTelemetry.Properties["method"] = httpRequest.Method.Method;
                    requestTelemetry.Properties["url"] = httpRequest.RequestUri.ToString();
                    

                    if (correlationId != null)
                    {
                        requestTelemetry.Context.Operation.Id = correlationId;
                    }

                    client.TrackRequest(requestTelemetry);
                }
            }

            return base.OnActionExecutedAsync(actionExecutedContext, cancellationToken);
        }

        private struct RequestInformation
        {
            public DateTime StartDate { get; set; }
        }
    }
}
