using Pno34ReqRespWebApi.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using UraxBPCPNO34.Models;
using UraxBpcPno34Api.Models;
using EF = UraxBpcPno34Api.EF;
namespace UraxBPCPNO34Api.Models
{
    public class TaxEngineService
    {


        /// <summary>
        /// Get Tax Result for each market
        /// </summary>
        /// <param name="result"></param>
        /// <param name="i"></param>
        /// <param name="data"></param>
        /// <param name="outResult"></param>
        private void GetTaxResult(List<ResultVatDetails> result, int i, ConcurrentDictionary<string, string> data, List<ResultVatDetails> outResult, List<TaxNameDetails> TaxLocaleName)
        {
            //change the Tax Name
            var Lstresult = TaxNameConversion.GetConvertTaxName(TaxLocaleName, outResult);

            foreach (var outdata in Lstresult)
            {
                result.Add(new ResultVatDetails()
                {
                    TaxName = outdata.TaxName,
                    Value = outdata.Value,
                    VatPosition = outdata.VatPosition,
                    VatPositionId = outdata.VatPositionId,
                    Pno34 = data["pno34"],
                    SequenceId = i

                });
            }
        }



        /// <summary>
        /// Add data to dictionary
        /// </summary>
        /// <param name="dicParamDatawithVal"></param>
        /// <param name="dicCalParamData"></param>
        private static void AddDataToDic(ConcurrentDictionary<string, string> dicParamDatawithVal, ConcurrentDictionary<string, string> dicCalParamData)
        {
            foreach (var data in dicCalParamData)
            {
                if (!dicParamDatawithVal.ContainsKey(data.Key.ToUpper()))
                {
                    dicParamDatawithVal.TryAdd(data.Key.ToUpper(), data.Value.ToString());
                }
            }
        }
        /// <summary>
        /// Get Lookup data
        /// </summary>
        /// <param name="lstDbMktData"></param>
        /// <param name="dicParamDatawithVal"></param>
        /// <returns></returns>
        public ConcurrentDictionary<string, string> GetLookUpParameterParameter(List<MarketData> lstDbMktData, ConcurrentDictionary<string, string> dicParamDatawithVal, int priorityId)
        {
            ConcurrentDictionary<string, string> dicLookUpData = new ConcurrentDictionary<string, string>();
            ConcurrentDictionary<string, string> Inputval = new ConcurrentDictionary<string, string>();
            var LookUpData = lstDbMktData.Where(x => x.LookUpGroup > 0).ToList<MarketData>();
            //List of InputParameter have isllokup true
            List<string> LookUpGroup = lstDbMktData.Where(x => x.IslookUp == true && x.LookUpGroupName != null).Select(x => x.LookUpGroupName).Distinct().ToList();
            List<string> varLookDependency = new List<string>();
            if (LookUpGroup.Count > 0)
            {
                foreach (var p in LookUpGroup)
                {
                    // string str = x.ToString();
                    var result1 = lstDbMktData.FirstOrDefault(x => x.LookUpGroupName == p).LookUpGroup;
                    var LookUpVariable = lstDbMktData.Where(x => x.LookUpGroupName == EF.URAXEntities.ParseString(p) && x.LookUpGroup == result1).ToList();
                    // varLookUpInput
                    Inputval = new ConcurrentDictionary<string, string>( (from x in (LookUpVariable.Where(x => x.VariableTypeId == Helper.iInput).Select(x => x.VariableName))
                                join y in dicParamDatawithVal on x equals y.Key
                                select new { y.Key, y.Value }).ToDictionary(x => x.Key, x => x.Value));
                    varLookDependency = LookUpVariable.Where(x => x.VariableTypeId == Helper.iDependency).Select(x => x.VariableName).ToList();


                    List<MarketData> result = new List<MarketData>();
                    int i = 0;
                    foreach (var data in Inputval)
                    {
                        int n;

                        if (int.TryParse(data.Value.Replace(".", ""), out n))
                        {

                            var dataInput = Convert.ToDouble(data.Value);
                            if (i == 0)
                            {
                                result = LookUpData.Where(x => x.VariableName == data.Key && x.LookUpGroupName == p && (dataInput >= EF.URAXEntities.ParseDouble(x.Value) && dataInput <= EF.URAXEntities.ParseDouble(x.ValueRange)) && x.TaxPriority == priorityId).ToList();
                            }
                            else
                            {
                                result = result.Where(x => x.VariableName == data.Key && x.LookUpGroupName == p && (dataInput >= EF.URAXEntities.ParseDouble(x.Value) && dataInput <= EF.URAXEntities.ParseDouble(x.ValueRange)) && x.TaxPriority == priorityId).ToList();
                            }

                        }
                        else
                        {
                            var dataInput = data.Value.ToUpper();
                            result = LookUpData.Where(x => x.VariableName == data.Key && x.LookUpGroupName == p && (dataInput == x.Value && dataInput == x.ValueRange)).ToList();

                        }
                        result = (from r1 in result
                                  join r2 in lstDbMktData.AsParallel() on new { r1.LookUpGroup, r1.LookUpGroupName } equals new { r2.LookUpGroup, r2.LookUpGroupName }
                                  select r2).ToList<MarketData>();
                        i++;
                    }
                    var outdic = (from r1 in result
                                  join r2 in varLookDependency.AsParallel() on r1.VariableName equals r2
                                  select new { r1.VariableName, r1.Value, r1.UnitTypeId }).ToDictionary(x => x.VariableName.ToUpper(), x => x.UnitTypeId == Helper.iPercentage ? (Convert.ToDouble(x.Value) / 100).ToString() : x.Value);
                    foreach (var a in outdic)
                    {
                        if (!dicLookUpData.ContainsKey(a.Key.ToUpperInvariant()))
                        {
                            dicLookUpData.TryAdd(a.Key.ToUpperInvariant(), a.Value);
                        }
                    }
                }
            }
            return dicLookUpData;
        }

        /// <summary>
        /// Tax Calculator
        /// </summary>
        /// <param name="marketdata"></param>
        /// <returns></returns>
        public async Task<List<List<ResultVatDetails>>> TaxCalculationsAsync(List<MarketWiseInputData> marketdata, List<CustomErrorMessage> lstDbError, List<TaxNameDetails> TaxLocaleName)
        {

            List<List<ResultVatDetails>> lstResult = new List<List<ResultVatDetails>>();
            foreach (var m in marketdata)
            {
                foreach (var inputDataParam in m.PnoParameterData)
                {
                    var lstResult1 = await TaxCalculationAsync(m, inputDataParam.LstInputParam, lstDbError, TaxLocaleName);

                    lstResult.AddRange(lstResult1);
                }

            }
            return lstResult;
        }


    private async Task<List<List<ResultVatDetails>>> TaxCalculationAsync(MarketWiseInputData m, List<Dictionary<string, string>> lstInputParam, List<CustomErrorMessage> lstDbError, List<TaxNameDetails> taxLocaleName)
        {
            int inputParamCnt = lstInputParam.Count;
            List<List<ResultVatDetails>> lstResult = new List<List<ResultVatDetails>>();
            //Four parellel thread
            int noOfThread = inputParamCnt / 4;
            int remainingParam = inputParamCnt % 4;
            if (remainingParam > 0)
            {
                noOfThread = noOfThread + 1;
            }
            int position = 0;
            for (int i = 1; i <= noOfThread; i++)
            {
                if (i == noOfThread && remainingParam != 0)
                {
                    if (remainingParam == 1)
                    {
                        lstResult.Add(new List<ResultVatDetails>(TaxCalculation(m, new ConcurrentDictionary<string, string> (lstInputParam[position]), lstDbError, taxLocaleName, position)));
                        position = position++;
                    }
                    else if (remainingParam == 2)
                    {
                        List<CustomErrorMessage> lstDbError1 = new List<CustomErrorMessage>();
                        int position0 = position;
                        ConcurrentDictionary<string, string> list1 = new ConcurrentDictionary<string, string>(lstInputParam[position]);
                        var t1 = Task.Run(() => TaxCalculation(m, list1, lstDbError1, taxLocaleName, position0));
                        int position1 = position + 1;
                        List<CustomErrorMessage> lstDbError2 = new List<CustomErrorMessage>();
                        ConcurrentDictionary<string, string> list2 = new ConcurrentDictionary<string, string>(lstInputParam[position1]);
                        var t2 = Task.Run(() => TaxCalculation(m, list2, lstDbError2, taxLocaleName, position1));

                        await Task.WhenAll(t1, t2);
                        position = position + 2;
                        lstResult.Add(new List<ResultVatDetails>(t1.Result.ToList()));
                        lstResult.Add(new List<ResultVatDetails>(t2.Result.ToList()));
                        lstDbError.AddRange(lstDbError1);
                        lstDbError.AddRange(lstDbError2);

                    }
                    else if (remainingParam == 3)
                    {
                        List<CustomErrorMessage> lstDbError1 = new List<CustomErrorMessage>();
                        int position0 = position;
                        ConcurrentDictionary<string, string> list1 = new ConcurrentDictionary<string, string>(lstInputParam[position]);
                        var t1 = Task.Run(() => TaxCalculation(m, list1, lstDbError1, taxLocaleName, position0));
                        int position1 = position + 1;
                        // System.Threading.Thread.Sleep(60000);
                        List<CustomErrorMessage> lstDbError2 = new List<CustomErrorMessage>();
                        ConcurrentDictionary<string, string> list2 = new ConcurrentDictionary<string, string>(lstInputParam[position1]);
                        var t2 = Task.Run(() => TaxCalculation(m, list2, lstDbError2, taxLocaleName, position1));
                        int position2 = position + 2;
                        // System.Threading.Thread.Sleep(60000);
                        List<CustomErrorMessage> lstDbError3 = new List<CustomErrorMessage>();
                        ConcurrentDictionary<string, string> list3 = new ConcurrentDictionary<string, string>(lstInputParam[position2]);
                        var t3 = Task.Run(() => TaxCalculation(m, list3, lstDbError3, taxLocaleName, position2));
                        await Task.WhenAll(t1, t2, t3);
                        position = position + 3;
                        lstResult.Add(new List<ResultVatDetails>(t1.Result.ToList()));
                        lstResult.Add(new List<ResultVatDetails>(t2.Result.ToList()));
                        lstResult.Add(new List<ResultVatDetails>(t3.Result.ToList()));
                        lstDbError.AddRange(lstDbError1);
                        lstDbError.AddRange(lstDbError2);
                        lstDbError.AddRange(lstDbError3);
                    }
                }
                else
                {
                    List<CustomErrorMessage> lstDbError1 = new List<CustomErrorMessage>();
                    int position0 = position;
                    ConcurrentDictionary<string, string> list1 = new ConcurrentDictionary<string, string>(lstInputParam[position]);
                    var t1 = Task.Run(() => TaxCalculation(m, list1, lstDbError1, taxLocaleName, position0));
                    int position1 = position + 1;
                    List<CustomErrorMessage> lstDbError2 = new List<CustomErrorMessage>();
                    ConcurrentDictionary<string, string> list2 = new ConcurrentDictionary<string, string>(lstInputParam[position1]);
                    var t2 = Task.Run(() => TaxCalculation(m, list2, lstDbError2, taxLocaleName, position1));
                    int position2 = position + 2;
                    List<CustomErrorMessage> lstDbError3 = new List<CustomErrorMessage>();
                    ConcurrentDictionary<string, string> list3 = new ConcurrentDictionary<string, string>(lstInputParam[position2]);
                    var t3 = Task.Run(() => TaxCalculation(m, list3, lstDbError3, taxLocaleName, position2));
                    int position3 = position + 3;
                    List<CustomErrorMessage> lstDbError4 = new List<CustomErrorMessage>();
                    ConcurrentDictionary<string, string> list4 = new ConcurrentDictionary<string, string>(lstInputParam[position3]);
                    var t4 = Task.Run(() => TaxCalculation(m, list4, lstDbError4, taxLocaleName, position3));
                    await Task.WhenAll(t1, t2, t3, t4);
                    position = position + 4;
                    lstResult.Add(new List<ResultVatDetails>(t1.Result.ToList()));
                    lstResult.Add(new List<ResultVatDetails>(t2.Result.ToList()));
                    lstResult.Add(new List<ResultVatDetails>(t3.Result.ToList()));
                    lstResult.Add(new List<ResultVatDetails>(t4.Result.ToList()));
                    lstDbError.AddRange(lstDbError1);
                    lstDbError.AddRange(lstDbError2);
                    lstDbError.AddRange(lstDbError3);
                    lstDbError.AddRange(lstDbError4);

                }

            }
            return lstResult;
        }

        private List<ResultVatDetails> TaxCalculation(MarketWiseInputData m, ConcurrentDictionary<string, string> p, List<CustomErrorMessage> lstDbError, List<TaxNameDetails> TaxLocaleName, int position)
        {
#if DEBUG

            CultureInfo culture = new CultureInfo(Environment.GetEnvironmentVariable("DefaultCulture"));
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
#endif
            List<ResultVatDetails> Result = new List<ResultVatDetails>();
            try
            {

                //check MSRP or pritax
                List<ResultVatDetails> outcalTaxResult = new List<ResultVatDetails>();
                ConcurrentDictionary<string, string> dicTaxList = new ConcurrentDictionary<string, string>();
                int TaxType = 0;
                if (p["priceType"] == Helper.sPBPRETAX)
                {
                    TaxType = Helper.iPBPRETAX;
                }
                else if (p["priceType"] == Helper.sPBMSRP)
                {
                    TaxType = Helper.iPBMSRP;
                }
                if (!lstDbError.Any(x => x.CallStack == p["priceType"]))
                {
                    var BeforeVATTaxAmount = 0.0M;
                    var PriceAmount = 0.0M;
                    bool isChangesInPriceInput = false;
                    var PriceKey = TaxType == Helper.iPBPRETAX ? Helper.sPBPRETAX : Helper.sPBMSRP;
                    var lstPriority = m.MarketData.Where(x => x.TaxFlowId == TaxType).Select(x => new TaxPositionPriorityCombination() { PriorityId = x.TaxPriority, TaxPostionId = x.TaxPositionId }).GroupBy(o => new { o.PriorityId, o.TaxPostionId })
                                        .Select(o => o.FirstOrDefault()).ToList();
                    foreach (var priorityCombo in lstPriority)
                    {
                        var defaultValue = m.MarketData.Where(x => x.TaxPriority == priorityCombo.PriorityId && x.DefaultValue != null && x.VariableTypeId == 6).Select(x => new { x.VariableName, x.DefaultValue }).ToList();

                        if (priorityCombo.TaxPostionId == Helper.iVatId)
                        {
                            PriceAmount = Convert.ToDecimal(p[PriceKey]);
                            var SumPriceAmount = PriceAmount + BeforeVATTaxAmount;
                            BeforeVATTaxAmount = 0;
                            p[PriceKey] = SumPriceAmount.ToString();
                            isChangesInPriceInput = true;
                        }
                        else if (isChangesInPriceInput)
                        {
                            isChangesInPriceInput = false;
                            p[PriceKey] = PriceAmount.ToString();
                        }

                        ConcurrentDictionary<string, string> dicParamDatawithVal = new ConcurrentDictionary<string, string>(p.ToDictionary(x => x.Key.ToUpper(), x => x.Value));

                        foreach (var data in dicTaxList)
                        {
                            if (!dicParamDatawithVal.ContainsKey(data.Key.ToUpper()))
                            {
                                dicParamDatawithVal.TryAdd(data.Key.ToUpper(), data.Value.ToString());
                            }
                        }
                        defaultValue.ForEach(x =>
                        {
                            if (!dicParamDatawithVal.ContainsKey(x.VariableName))
                            {
                                dicParamDatawithVal.TryAdd(x.VariableName, x.DefaultValue);
                            }
                        });
                        List<Formula> dicFormula = new List<Formula>();
                        var formuladetails = m.MarketData.Where(x => x.TaxPriority == priorityCombo.PriorityId && x.TaxFlowId == TaxType && x.FormulaDefination != null && (x.VariableTypeId == Helper.iCalculated || x.VariableTypeId == Helper.iResult))
                        .Select(x => new { x.VariableName, x.FormulaDefination, x.MinValue, x.MaxValue, x.VariableTypeId, x.UnitTypeId }).ToList();
                        foreach (var data in formuladetails)
                        {
                            dicFormula.Add(new Formula()
                            {
                                FormulaDefination = data.FormulaDefination.ToUpper(),
                                VariableName = data.VariableName.ToUpper(),
                                MaxValue = data.MaxValue,
                                MinValue = data.MinValue,
                                VariableTypeId = data.VariableTypeId,
                                UnitTypeId = data.UnitTypeId

                            });
                        }
                        ConcurrentDictionary<string, string> dicCalParamData = new ConcurrentDictionary<string, string>(m.MarketData.Where(x => x.TaxPriority == priorityCombo.PriorityId && x.TaxFlowId == TaxType && x.VariableTypeId == Helper.iFixed)
                            .Select(x => new { x.VariableName, x.Value, x.UnitTypeId })
                            .ToDictionary(x => x.VariableName.ToUpper(), x => x.UnitTypeId == Helper.iPercentage ? (Convert.ToDecimal(x.Value) / 100).ToString() : x.Value));

                        AddDataToDic(dicParamDatawithVal, dicCalParamData);

                        ConcurrentDictionary<string, string> calLookUpData = GetLookUpParameterParameter(m.MarketData.Where(x => x.TaxPriority == priorityCombo.PriorityId && x.TaxFlowId == TaxType).ToList(), dicParamDatawithVal, priorityCombo.PriorityId);
                        AddDataToDic(dicParamDatawithVal, calLookUpData);

                        ConcurrentDictionary< string, decimal> outcalData = ParseFormula(dicParamDatawithVal, dicFormula);

                        decimal taxamount = outcalData.Sum(x => x.Value);
                        //chnage the Tax Name according to locale
                        var TaxDetails = m.MarketData.FirstOrDefault(x => x.TaxPriority == priorityCombo.PriorityId && x.TaxFlowId == TaxType);
                        outcalTaxResult.Add(new ResultVatDetails()
                        {
                            TaxName = TaxDetails.TaxName,
                            Value = taxamount,
                            VatPositionId = TaxDetails.TaxPositionId,
                            VatPosition = TaxDetails.VatPosition,
                            TaxId = TaxDetails.TaxMasterId

                        });
                        if (!dicTaxList.ContainsKey(TaxDetails.TaxName))
                            dicTaxList.TryAdd(TaxDetails.TaxName, taxamount.ToString());
                        if (priorityCombo.TaxPostionId == Helper.iBeforeVatId)
                        {
                            BeforeVATTaxAmount += taxamount;
                        }
                    }
                    GetTaxResult(Result, position, p, outcalTaxResult, TaxLocaleName);


                }
            }
            catch (Exception ex)
            {
                lstDbError.Add(new CustomErrorMessage()
                {
                    IsRootMessage = false,
                    MessageId = Convert.ToInt32(p["PnoSrlNo"]),
                    CallStack = ex.Message.ToString(),
                    MessageText = ex.Message.ToString(),
                    MessageTitle = p["pno34"],
                    MessageType = Helper.strWarning,
                    PnoSerialNo = Convert.ToInt32(p["PnoSrlNo"])
                });
            }
            return Result;
        }
        /// <summary>
        /// Formula Parsing
        /// </summary>
        /// <param name="dicInputVal"></param>
        /// <param name="dicFormula"></param>
        /// <returns></returns>
        public ConcurrentDictionary<string, decimal> ParseFormula(ConcurrentDictionary<string, string> dicInputVal, List<Formula> dicFormula)
        {
            ConcurrentDictionary<string, decimal> calParamData = new ConcurrentDictionary<string, decimal>();
            ConcurrentDictionary<string, decimal> outData = new ConcurrentDictionary<string, decimal>();
            foreach (var data in dicFormula)
            {
                var result = ParseFormulaData(data.FormulaDefination, dicInputVal);
                if (!string.IsNullOrEmpty(data.MinValue.ToString()))
                    result = result > Convert.ToDecimal(data.MinValue) ? result : Convert.ToDecimal(data.MinValue);
                if (!string.IsNullOrEmpty(data.MaxValue.ToString()))
                    result = result < Convert.ToDecimal(data.MaxValue) ? result : Convert.ToDecimal(data.MaxValue);
                if (data.UnitTypeId == Helper.iPercentage)
                    result = (Convert.ToDecimal(result) / 100);

                dicInputVal.TryAdd(data.VariableName, result.ToString());
                calParamData.TryAdd(data.VariableName, result);
                if (data.VariableTypeId != Helper.iCalculated)
                    outData.TryAdd(data.VariableName, result);
            }
            return outData;
        }
        /// <summary>
        /// Check value is decimal
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public bool IsDecimal(string val)
        {
            decimal number = 0;
            return decimal.TryParse(val, out number);
        }
        /// <summary>
        /// Parsing  formula
        /// </summary>
        /// <param name="formula"></param>
        /// <param name="calParamData"></param>
        /// <returns></returns>
        private decimal ParseFormulaData(string formula, ConcurrentDictionary<string, string> calParamData)
        {

            decimal formulaValue;
            try
            {
                var builder = new StringBuilder(formula);
                //get list of input into dictonary
                var lstformulaParm = ParseFormulaParameter(formula);
                //split the value into arrays
                foreach (var formualParam in lstformulaParm)
                {
                    try
                    {
                        if (!IsDecimal(formualParam) && !formualParam.Contains("\""))
                        {
                            builder.Replace(formualParam, !IsDecimal(calParamData[formualParam]) ? "\"" + calParamData[formualParam] + "\"" : calParamData[formualParam]);
                        }
                    }
                    catch (Exception)
                    {
                        throw new InvalidOperationException(formualParam + " value is not available  for Formula  :(" + formula + ")");
                    }
                }
                formulaValue = new Parser().ParseFormula(builder.ToString());


            }
            catch (Exception)
            {

                throw;
            }
            return formulaValue;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="formula"></param>
        /// <returns></returns>
        public List<string> ParseFormulaParameter(string formula)
        {
            try
            {
                var result = Regex.Split(formula, Helper.sPattern);
                result = result.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
                List<string> formulaParam = result.OrderByDescending(x => x.Length).Select(x => x.Trim()).ToList();
                List<string> XlFunctions = Enum.GetNames(typeof(ExclMetods)).ToList();
                formulaParam.RemoveAll(x => XlFunctions.Contains(x));
                return formulaParam;
            }
            catch (Exception)
            {

                throw;
            }

        }

    }

    public class ResultVatDetails
    {
        public int SequenceId { get; set; }
        public string TaxName { get; set; }
        public decimal Value { get; set; }
        public string VatPosition { get; set; }
        public int VatPositionId { get; set; }
        public string Pno34 { get; set; }
        public int TaxId { get; set; }
    }
    public struct MarketWiseInputData
    {
        public String MarketCode { get; set; }
        public string PriceDate { get; set; }
        public List<MarketData> MarketData { get; set; }
        public List<PnoParameterData> PnoParameterData { get; set; }
    }
    public struct Formula
    {
        public string VariableName { get; set; }
        public string FormulaDefination { get; set; }
        public decimal? MinValue { get; set; }
        public decimal? MaxValue { get; set; }
        public int VariableTypeId { get; set; }
        public int UnitTypeId { get; set; }
    }

}