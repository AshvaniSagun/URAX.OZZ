using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;
using Microsoft.ApplicationInsights;

namespace UraxBpcPno34Api
{
    public class AiWebApiExceptionLogger : ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {
            if (context != null && context.Exception != null)
            {
               
                var telmentryclient = new TelemetryClient();
                telmentryclient.TrackException(context.Exception);
            }
            base.Log(context);
        }
    }
}
