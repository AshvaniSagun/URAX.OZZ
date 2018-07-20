﻿namespace UraxBpcPno34Api
{
    using System;
    using System.Net.Http;
    using System.Web.Http.Tracing;
    using Microsoft.ApplicationInsights.DataContracts;
    using Microsoft.ApplicationInsights;
    using System.Linq;

    internal sealed class ApplicationInsightsTraceWriter : ITraceWriter
    {
        private readonly SystemDiagnosticsTraceWriter systemDiagnosticsTraceWriter = new SystemDiagnosticsTraceWriter();

        private readonly TelemetryClient client = new TelemetryClient();

        private readonly char[] separator = new[] { ',' };

        public void Trace(HttpRequestMessage request, string category, TraceLevel level, Action<TraceRecord> traceAction)
        {
            if (category == null)
            {
                throw new ArgumentNullException();
            }

            if (traceAction == null)
            {
                throw new ArgumentNullException();
            }

            if (level < TraceLevel.Off || level > TraceLevel.Fatal)
            {
                throw new ArgumentOutOfRangeException();
            }

            var traceRecord = new TraceRecord(request, category, level);
            traceAction(traceRecord);

            this.systemDiagnosticsTraceWriter.TranslateHttpResponseException(traceRecord);

            string message = this.systemDiagnosticsTraceWriter.Format(traceRecord);
            if (!string.IsNullOrEmpty(message))
            {
                var exception = traceRecord.Exception;
                if (exception != null)
                {
                    ExceptionTelemetry et = new ExceptionTelemetry(exception);
                    et.SeverityLevel = GetSeverityLevel(level);

                    var swh = exception as System.Web.Http.HttpResponseException;

                    // Add additional message because exception message is useless
                    if (swh != null)
                    {
                        et.Properties.Add("Response Message", message);
                    }

                    this.client.TrackException(et);
                    
                }
                else
                {
                    var traceTelemetry = new TraceTelemetry(message, GetSeverityLevel(level));

                    if (string.IsNullOrEmpty(message) == false)
                    {
                        var splittedProperties = message.Split(separator, StringSplitOptions.RemoveEmptyEntries);

                        foreach (var property in splittedProperties)
                        {
                            var propertySplit = property.Split('=');

                            if (propertySplit.Length >= 2)
                            {
                                var propertyName = propertySplit[0].Trim();

                                if (traceTelemetry.Properties.ContainsKey(propertyName) == false)
                                {
                                    var propertyValue = string.Join("=", propertySplit.Skip(1)).Trim();
                                    traceTelemetry.Properties.Add(propertySplit[0], propertyValue);
                                }
                            }
                        }
                    }

                    this.client.TrackTrace(traceTelemetry);
                }
            }
        }

        public static SeverityLevel GetSeverityLevel(TraceLevel level)
        {
            switch (level)
            {
                case TraceLevel.Debug: return SeverityLevel.Verbose;
                case TraceLevel.Error: return SeverityLevel.Error;
                case TraceLevel.Fatal: return SeverityLevel.Critical;
                case TraceLevel.Info: return SeverityLevel.Information;
                case TraceLevel.Warn: return SeverityLevel.Warning;
            }

            throw new InvalidOperationException("Unexpected level" + level);
        }
    }
}