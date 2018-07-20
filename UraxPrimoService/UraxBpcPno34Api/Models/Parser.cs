using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Globalization;
using URAX;

namespace UraxBPCPNO34.Models
{
    public  class Parser
    {
        /// <summary>
        /// ParseFormula ("Parse mathematical Expressions)
        /// </summary>
        /// <param name="formulaDefination"></param>
        /// <returns> Valuue will returns (Succcess / Errors)</returns>
        public decimal ParseFormula(string formulaDefination)
        {
            try
            {

                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws = wb.AddWorksheet("Sheet1");
                    ws.Cell("A1").FormulaA1 = formulaDefination;
                    var value = ws.Cell("A1").Value;
                    var status = decimal.Parse(value.ToString(), NumberStyles.Float);

                    return status;
                }
            }
            catch (Exception ex)
            {
                new Microsoft.ApplicationInsights.TelemetryClient().TrackException(ex);
                throw;
            }

        }

    }
}