namespace UraxBpcPno34Api
{
    using System.Web.Http;
    using System.Web.Http.Tracing;

    public static class ApplicationInsightsExtensions
    {
        public static void EnableApplicationInsights(this HttpConfiguration configuration)
        {
            ITraceWriter writer;
            var currentWriter = configuration.Services.GetTraceWriter();
            if (currentWriter != null)
            {
                writer = new CompositTraceWriter(
                    new ITraceWriter[]
                        {
                            new ApplicationInsightsTraceWriter(),
                            currentWriter,
                        });
            }
            else
            {
                writer = new ApplicationInsightsTraceWriter();
            }
 
            configuration.Services.Replace(
                typeof(ITraceWriter),
                writer);
        }
    }
}