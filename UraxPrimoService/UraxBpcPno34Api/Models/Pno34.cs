using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using UraxBPCPNO34.Models;
using UraxBpcPno34Api.Models;
using UraxBPCPNO34Api.Models;
using EF = UraxBpcPno34Api.EF;

namespace Pno34ReqRespWebApi.Models
{
    public class Pno34
    {
        /// <summary>
        /// Convert Json input data to list of data for calculations
        /// </summary>
        /// <param name="inputPno34Data"></param>
        /// <returns>Returns list of calculations data with input</returns>
        public CalculateTaxCombinedResponseOutput Pno34ResponseData(CalculateTaxCombined inputPno34Data, List<int> pnoCount = null, List<CustomErrorMessage> lstErrorMessage = null)
        {
            var countryCode = inputPno34Data.CalculateTaxCombinedRequest.DataArea.CountryCode;
            var taxTerritory = inputPno34Data.CalculateTaxCombinedRequest.DataArea.TaxTerritory;
            Dictionary<string, string> dicCertifiedData = new Dictionary<string, string>();
            List<Dictionary<string, string>> lstDicCertifiedData = new List<Dictionary<string, string>>();
            Dictionary<string, string> dicMktData = new Dictionary<string, string>();
            List<Dictionary<string, string>> lstInputParam = new List<Dictionary<string, string>>();
            List<Dictionary<string, string>> lstdicPnoCertifiedData = new List<Dictionary<string, string>>();
            List<PnoParameterData> lstPnoParamData = new List<PnoParameterData>();
            List<MarketWiseParameterData> lstMktWParamData = new List<MarketWiseParameterData>();
            //Get Certified Data from PNO12
            string redaActive = System.Environment.GetEnvironmentVariable("REDAACTIVE").ToString();
            var objRedaSendRequest = new RedaSendRequest();
            List<PnoCertifiedData> lstPnoCertifiedData = PnoCertifiedData.GetPnoCertifiedData(inputPno34Data.CalculateTaxCombinedRequest.DataArea.ModelYear, inputPno34Data.CalculateTaxCombinedRequest.DataArea.TaxTerritory, inputPno34Data.CalculateTaxCombinedRequest.DataArea.SpecificationMarket);
            //Get Certified Data from Reda
            var unitConvertedRedaParameters = new List<RedaDictionaryList>();
            if (redaActive == "1")
            {
                var redaResponseList = objRedaSendRequest.Getreadaresponselist(inputPno34Data);


                var dicRedaParamInputlist = RedaSendRequest.GetRedaParamInputDictionary(redaResponseList);
                //Get Conversion Data from Cache or Database and Convert if Required
                unitConvertedRedaParameters = UnitConversionData.GetUnitConvertedData(countryCode, taxTerritory, dicRedaParamInputlist);
            }
            int i = 0;
            foreach (var paramdata in inputPno34Data.CalculateTaxCombinedRequest.DataArea.PnoList)
            {
                var parameterDictionary = paramdata.Parameters!=null ? paramdata.Parameters.ToDictionary(x => x.Name.ToUpper(), x => x.Value.ToUpper()) :new Dictionary<string, string>() ;
                var pnos = lstPnoCertifiedData.Where(x => x.Pno12 == EF.URAXEntities.ToPno12SubString(paramdata.Pno34Options)).ToList();
                var pnoCertifiedData = pnos.Select(x => new { x.Name, x.Value }).ToDictionary(x => x.Name, x => x.Value);
                if ( pnos.Count > 0)
                {
                    pnoCertifiedData.Add("MODEL NUMBER", pnos.FirstOrDefault().CarLine);
                }
                else
                {
                    dicCertifiedData.Add("MODEL NUMBER", "0");
                }
                parameterDictionary.CreateNewOrUpdateExistingDic<string, string>(pnoCertifiedData);
                dicCertifiedData = pnoCertifiedData;

                if (redaActive == "1")
                {
                    var dictionaryReda = unitConvertedRedaParameters.Where(x => x.Pno12 == EF.URAXEntities.ToPno12SubString(paramdata.Pno34Options)).Select(x => x.RedaDictionary).FirstOrDefault();
                    if (dictionaryReda != null)
                    {
                        var finalReda = UnitConversionData.MapRedaToDefinitionName(dictionaryReda);
                        parameterDictionary.CreateNewOrUpdateExistingDic<string, string>(finalReda);
                        dicCertifiedData.CreateNewOrUpdateExistingDic<string, string>(finalReda);
                    }

                }

                if (pnoCount == null)
                {
                    GetParameterList(paramdata, parameterDictionary, inputPno34Data.CalculateTaxCombinedRequest.Locale);
                }
                else if ((pnoCount != null) && !pnoCount.Any(x => x == i))
                {
                    GetParameterList(paramdata, parameterDictionary, inputPno34Data.CalculateTaxCombinedRequest.Locale);
                }
                else
                {
                    parameterDictionary = new Dictionary<string, string>();
                }
                if (pnoCertifiedData.Count == 0)
                {
                    pnoCertifiedData.Add(Helper.strPno34, paramdata.Pno34Options);
                }
                if (parameterDictionary.Count > 0)
                {
                    parameterDictionary.Add("PnoSrlNo", i.ToString());
                    lstInputParam.Add(new Dictionary<string, string>(parameterDictionary));
                    lstDicCertifiedData.Add(new Dictionary<string, string>(dicCertifiedData));
                }
                lstdicPnoCertifiedData.Add(new Dictionary<string, string>(pnoCertifiedData));

                i++;
            }
            dicMktData.Add(Helper.strCountryCode, inputPno34Data.CalculateTaxCombinedRequest.DataArea.CountryCode);
            dicMktData.Add(Helper.strCurrencyCode, inputPno34Data.CalculateTaxCombinedRequest.DataArea.CurrencyCode);
            dicMktData.Add(Helper.strGCCTaxPartnerGroup, inputPno34Data.CalculateTaxCombinedRequest.DataArea.GccTaxPartnerGroupCode);
            dicMktData.Add(Helper.strModelYear, inputPno34Data.CalculateTaxCombinedRequest.DataArea.ModelYear);
            dicMktData.Add(Helper.strPriceDate, inputPno34Data.CalculateTaxCombinedRequest.DataArea.TaxationDate);
            dicMktData.Add(Helper.strSpecificationMarket, inputPno34Data.CalculateTaxCombinedRequest.DataArea.SpecificationMarket);
            dicMktData.Add(Helper.strTaxTerritory, inputPno34Data.CalculateTaxCombinedRequest.DataArea.TaxTerritory);
            lstPnoParamData.Add(new PnoParameterData()
            {
                LstInputParam = lstInputParam
            });

            //Check Pno Certifed data is exist then take certified data else take request data for calculations.

            lstInputParam = new List<Dictionary<string, string>>();
            lstMktWParamData.Add(new MarketWiseParameterData()
            {
                PnoParameterData = lstPnoParamData,
                DicMarketData = dicMktData
            });
            lstPnoParamData = new List<PnoParameterData>();
            dicMktData = new Dictionary<string, string>();
            var lstDbError = new List<CustomErrorMessage>();
            var lstMkt = GetMarketDatafromDB(lstMktWParamData, lstDbError);
            var lstResult = new List<List<ResultVatDetails>>();
            if (!(lstDbError.Any(x => x.CallStack == Helper.sPBMSRP) && lstDbError.Any(x => x.CallStack == Helper.sPBPRETAX)))
            {
                //bring the locale Tax Name
                var LstTaxName = TaxNameConversion.GetTaxNameByLocale(inputPno34Data.CalculateTaxCombinedRequest.Locale.ToUpper());
                TaxEngineService taxEngineService = new TaxEngineService();
                lstResult = taxEngineService.TaxCalculationsAsync(lstMkt, lstDbError, LstTaxName).Result;
            }
            //Sending List of onputPno34Data for Calculations
            var lstResponse = Pno34.CreateResponse(inputPno34Data, lstDicCertifiedData, lstResult, lstMkt, pnoCount, lstErrorMessage, lstDbError);

            return lstResponse;
        }
        private static List<MarketWiseInputData> GetMarketDatafromDB(List<MarketWiseParameterData> lstMrktWParamData, List<CustomErrorMessage> lstDbError)
        {
            List<MarketWiseInputData> lstMkt = new List<MarketWiseInputData>();
            //Get All Market list Data check data and check data is exist or not//If not then returns data is not exists
            foreach (var param in lstMrktWParamData)
            {
                //MarketData from DataBase with respect to
                List<MarketData> lstMktData = MarketData.GetEntityMarketData(param.DicMarketData["CountryCode"], param.DicMarketData["PriceDate"], param.DicMarketData["TaxTerritory"]);
                //divide lst of Market Data to MSRP Flow and PRETAX flow Data
                int CntMSRPFlowMarketData = lstMktData.Count(s => s.TaxFlowId == Helper.iMSRPFlow);
                int CntPRETAXFlowMarketData = lstMktData.Count(s => s.TaxFlowId == Helper.iPRETAXFlow);
                foreach (var p in param.PnoParameterData)
                {
                    foreach (var x in p.LstInputParam)
                    {
                        if (CntMSRPFlowMarketData == 0 && x["priceType"] == Helper.sPBPRETAX && (!lstDbError.Any(s => s.CallStack == Helper.sPBPRETAX)))
                        {
                            lstDbError.Add(new CustomErrorMessage()
                            {
                                IsRootMessage = false,
                                CallStack = Helper.sPBPRETAX,
                                MessageId = 0,
                                MessageText = "Data is not available  for Market " + param.DicMarketData["CountryCode"] + ", Date :" + param.DicMarketData["PriceDate"] + ", TaxTerritory : " + param.DicMarketData["TaxTerritory"] + " PriceBase : " + x["priceType"],
                                MessageTitle = x["pno34"],
                                PnoSerialNo = 0,
                                MessageType = Helper.strError
                            });
                        }
                        else if (CntMSRPFlowMarketData >= 0 && x["priceType"] == Helper.sPBPRETAX && lstMktData.Any(s => s.TaxFlowId == Helper.iMSRPFlow && s.IsFormulaAvailable == false) && (!lstDbError.Any(s => s.CallStack == Helper.sPBPRETAX)))
                        {
                            lstDbError.Add(new CustomErrorMessage()
                            {
                                IsRootMessage = false,
                                CallStack = Helper.sPBPRETAX,
                                MessageId = 0,
                                MessageText = "Formula is not available for Tax :" + String.Join(",", lstMktData.Where(s => s.TaxFlowId == Helper.iMSRPFlow && s.IsFormulaAvailable == false).Select(s => s.TaxName)),
                                MessageTitle = x["pno34"],
                                PnoSerialNo = 0,
                                MessageType = Helper.strWarning
                            });
                        }
                        else if (CntPRETAXFlowMarketData == 0 && x["priceType"] == Helper.sPBMSRP && (!lstDbError.Any(s => s.CallStack == Helper.sPBMSRP)))
                        {
                            lstDbError.Add(new CustomErrorMessage()
                            {
                                IsRootMessage = false,
                                CallStack = Helper.sPBMSRP,
                                MessageId = 0,
                                MessageText = "Data is not available  for Market " + param.DicMarketData["CountryCode"] + " ,Date :" + param.DicMarketData["PriceDate"] + " , TaxTerritory : " + param.DicMarketData["TaxTerritory"] + " PriceBase : " + x["priceType"],
                                MessageTitle = x["pno34"],
                                PnoSerialNo = 0,
                                MessageType = Helper.strError
                            });
                        }
                        else if (CntMSRPFlowMarketData >= 0 && x["priceType"] == Helper.sPBMSRP && lstMktData.Any(s => s.TaxFlowId == Helper.iPRETAXFlow && s.IsFormulaAvailable == false) && (!lstDbError.Any(s => s.CallStack == Helper.sPBMSRP)))
                        {
                            lstDbError.Add(new CustomErrorMessage()
                            {
                                IsRootMessage = false,
                                CallStack = Helper.sPBMSRP,
                                MessageId = 0,
                                MessageText = "Formula is not available for Tax :" + String.Join(",", lstMktData.Where(s => s.TaxFlowId == Helper.iPRETAXFlow && s.IsFormulaAvailable == false).Select(s => s.TaxName)),
                                MessageTitle = x["pno34"],
                                PnoSerialNo = 0,
                                MessageType = Helper.strWarning
                            });
                        }
                    }
                }

                lstMkt.Add(new MarketWiseInputData()
                {
                    MarketCode = param.DicMarketData["CountryCode"],
                    PriceDate = param.DicMarketData["PriceDate"],
                    MarketData = lstMktData,
                    PnoParameterData = param.PnoParameterData
                });

            }

            return lstMkt;
        }

        private static void GetParameterList(PnoInput paramdata, Dictionary<string, string> DicParam, string locale)
        {
            DicParam.Add(Helper.strPno34, paramdata.Pno34Options);
            DicParam.Add(paramdata.PriceBase, paramdata.Price.Amount.ToDecimal(new CultureInfo(locale, false).NumberFormat).ToString());
            DicParam.Add(Helper.strpriceType, paramdata.PriceBase.ToUpper());
            DicParam.Add(Helper.strstructureWeek, paramdata.StructureWeek);
        }

        /// <summary>
        /// Create Response with combinations of inputdata and calculated Tax
        /// </summary>
        /// <param name="inputPno34Data"></param>
        /// <param name="result"></param>
        /// <returns>Return List of calculation data with input </returns>
        public static CalculateTaxCombinedResponseOutput CreateResponse(CalculateTaxCombined inputPno34Data, List<Dictionary<string, string>> lstDicCertifiedData, List<List<ResultVatDetails>> result ,List<MarketWiseInputData> lstMkt, List<int> pnonos = null, List<CustomErrorMessage> lstErrorMessage = null, List<CustomErrorMessage> lstDbError = null)
        {
            var lstErrorMessageNull = new CustomErrorMessage();
            var rootErrorMessage = new CustomErrorMessage();
            var calculateTaxCombinedResponse = new CalculateTaxCombinedResponseOutput();
            var response = new Pno34Response();
            var dataArea = new DataArea();
            var applicationArea = new ApplicationArea();
            var inputMsrParamlist = lstMkt[0].MarketData.Where(p => p.VariableTypeId == Helper.iInput && p.TaxFlowId == Helper.iPBMSRP).Select(p => p.VariableName).Distinct().ToList<string>();
            var inputPretaxParamlist = lstMkt[0].MarketData.Where(p => p.VariableTypeId == Helper.iInput && p.TaxFlowId == Helper.iPBPRETAX).Select(p => p.VariableName).Distinct().ToList<string>();

            var pno = new List<Pno>();
            int k = 0;
            var vatPositionsList = new List<VatPositions>();
            foreach (var val in inputPno34Data.CalculateTaxCombinedRequest.DataArea.PnoList)
            {
                if (pnonos != null && pnonos.Any(x => x == k))

                {
                    foreach (var item in lstErrorMessage.Where(x => x.PnoSerialNo == k && x.IsRootMessage == false))
                    {
                        item.MessageTitle = val.Pno34Options;
                    }
                    pno.Add(new Pno()
                    {
                        Pno34 = val.Pno34Options,
                        PriceBase = val.PriceBase,
                        Accessories = val.Accessories,
                        StructureWeek = val.StructureWeek,
                        ErrorMessage = lstErrorMessage.Where(x => x.PnoSerialNo == k && x.IsRootMessage == false).FirstOrDefault()
                    });
                }
                else if (lstDbError.Any(x => x.CallStack == val.PriceBase.ToUpper()))
                {
                    pno.Add(new Pno()
                    {
                        Pno34 = val.Pno34Options,
                        PriceBase = val.PriceBase,
                        Accessories = val.Accessories,
                        StructureWeek = val.StructureWeek,
                        ErrorMessage = lstDbError.Where(x => x.CallStack == val.PriceBase.ToUpper()).FirstOrDefault()
                    });
                }
                else if (lstDbError.Any(x => x.PnoSerialNo == k && (x.CallStack != Helper.sPBMSRP && x.CallStack != Helper.sPBPRETAX)))
                {
                    pno.Add(new Pno()
                    {
                        Pno34 = val.Pno34Options,
                        PriceBase = val.PriceBase,
                        Accessories = val.Accessories,
                        StructureWeek = val.StructureWeek,
                        ErrorMessage = lstDbError.Where(x => x.PnoSerialNo == k && (x.CallStack != Helper.sPBMSRP && x.CallStack != Helper.sPBPRETAX)).FirstOrDefault()
                    });
                }
                else
                {
                    decimal totalTax = 0;
                    decimal totaltaxVat = 0;
                    decimal totaltaxBrforeVat = 0;
                    decimal totaltaxAfterVat = 0;
                    List<Tax> taxlistBeforeVat = new List<Tax>();
                    List<Tax> taxlistVat = new List<Tax>();
                    List<Tax> taxlistAfterVat = new List<Tax>();

                    foreach (var TaxData in result[k].Where(x => x.SequenceId == k))
                    {
                        totalTax += Convert.ToDecimal(TaxData.Value);
                        if (TaxData.VatPositionId == Helper.iBeforeVat)
                        {
                            totaltaxBrforeVat += Convert.ToDecimal(TaxData.Value);
                            taxlistBeforeVat.Add(new Tax()
                            {
                                Name = TaxData.TaxName,
                                Amount = TaxData.Value.ToCultureDecimal(new CultureInfo(inputPno34Data.CalculateTaxCombinedRequest.Locale, false).NumberFormat),
                                // VatPosition = TaxData.vatPosition
                            });
                        }
                        else if (TaxData.VatPositionId == Helper.iVat)
                        {
                            totaltaxVat += Convert.ToDecimal(TaxData.Value);
                            taxlistVat.Add(new Tax()
                            {
                                Name = TaxData.TaxName,
                                Amount = TaxData.Value.ToCultureDecimal(new CultureInfo(inputPno34Data.CalculateTaxCombinedRequest.Locale, false).NumberFormat),
                                // VatPosition = TaxData.vatPosition
                            });
                        }
                        else if (TaxData.VatPositionId == Helper.iAfterVat)
                        {
                            totaltaxAfterVat += Convert.ToDecimal(TaxData.Value);
                            taxlistAfterVat.Add(new Tax()
                            {
                                Name = TaxData.TaxName,
                                Amount = TaxData.Value.ToCultureDecimal(new CultureInfo(inputPno34Data.CalculateTaxCombinedRequest.Locale, false).NumberFormat),
                                // VatPosition = TaxData.vatPosition
                            });
                        }

                    }

                    //
                    string pricedata = "0.00";
                    List<Parameter> parameters = new List<Parameter>();
                    List<string> lstInput = new List<string>();
                    if (val.PriceBase.ToUpper() == Helper.sPBMSRP)
                    {
                        lstInput = inputMsrParamlist;
                    }
                    else
                    {
                        lstInput = inputPretaxParamlist;

                    }
                    var CertifiedData = lstDicCertifiedData[k].ToDictionary(x=>x.Key,x=>x.Value);
                    if(val.Parameters !=null)
                    {
                    foreach (var param in val.Parameters)
                    {
                        //check if name is exist in input value then take
                        if (lstInput.Any(b => b == param.Name.ToUpperInvariant()))
                        {
                            if (CertifiedData.ContainsKey(param.Name.ToUpper()) && CertifiedData[param.Name.ToUpper()] != param.Value)
                            {
                                parameters.Add(new Parameter()
                                {
                                    Id = param.Id,
                                    Name = param.Name,
                                    Datatype = param.DataType,
                                    Status = Helper.strCertified,
                                    Unit = param.Unit,
                                    Value = CertifiedData[param.Name.ToUpperInvariant()]
                                });
                            }
                            else
                            {
                                parameters.Add(new Parameter()
                                {
                                    Id = param.Id,
                                    Name = param.Name,
                                    Datatype = param.DataType,
                                    Status = Helper.strNotCertified,
                                    Unit = param.Unit,
                                    Value = param.Value
                                });
                            }
                        }
                    }
                    }

                    pricedata = val.Price.Amount;
                    vatPositionsList.Add(new VatPositions()
                    {
                        VatPosition = Helper.sBeforeVat,
                        VatPositionTotalAmount = totaltaxBrforeVat.ToCultureDecimal(new CultureInfo(inputPno34Data.CalculateTaxCombinedRequest.Locale, false).NumberFormat),
                        TaxList = taxlistBeforeVat
                    });
                    vatPositionsList.Add(new VatPositions()
                    {
                        VatPosition = Helper.sVat,
                        VatPositionTotalAmount = totaltaxVat.ToCultureDecimal(new CultureInfo(inputPno34Data.CalculateTaxCombinedRequest.Locale, false).NumberFormat),
                        TaxList = taxlistVat
                    });
                    vatPositionsList.Add(new VatPositions()
                    {
                        VatPosition = Helper.sAfterVat,
                        VatPositionTotalAmount = totaltaxAfterVat.ToCultureDecimal(new CultureInfo(inputPno34Data.CalculateTaxCombinedRequest.Locale, false).NumberFormat),
                        TaxList = taxlistAfterVat
                    });

                    pno.Add(new Pno()
                    {
                        Pno34 = val.Pno34Options,
                        PriceBase = val.PriceBase,
                        Accessories = val.Accessories,
                        StructureWeek = val.StructureWeek,
                        Msrp = val.PriceBase.ToUpper() == Helper.sPBMSRP ? pricedata : (Convert.ToDecimal(pricedata.ToDecimal(new CultureInfo(inputPno34Data.CalculateTaxCombinedRequest.Locale, false).NumberFormat)) + totalTax).ToCultureDecimal(new CultureInfo(inputPno34Data.CalculateTaxCombinedRequest.Locale, false).NumberFormat),
                        Pretax = val.PriceBase.ToUpper() == Helper.sPBPRETAX ? pricedata : (Convert.ToDecimal(pricedata.ToDecimal(new CultureInfo(inputPno34Data.CalculateTaxCombinedRequest.Locale, false).NumberFormat)) - totalTax).ToCultureDecimal(new CultureInfo(inputPno34Data.CalculateTaxCombinedRequest.Locale, false).NumberFormat),
                        TotalTax = totalTax.ToCultureDecimal(new CultureInfo(inputPno34Data.CalculateTaxCombinedRequest.Locale, false).NumberFormat).ToString(),
                        //TaxList = taxlist,
                        VatPositions = vatPositionsList,
                        Parameters = parameters,
                        ErrorMessage = null
                    });

                }
                k++;
                vatPositionsList = new List<VatPositions>();
            }

            dataArea= new DataArea()
            {
                CountryCode = inputPno34Data.CalculateTaxCombinedRequest.DataArea.CountryCode,
                GccTaxPartnerGroup = inputPno34Data.CalculateTaxCombinedRequest.DataArea.GccTaxPartnerGroupCode,
                SpecificationMarket = inputPno34Data.CalculateTaxCombinedRequest.DataArea.SpecificationMarket,
                CountrySubdivisionCode = inputPno34Data.CalculateTaxCombinedRequest.DataArea.CountrySubdivisionCode,
                Partner = inputPno34Data.CalculateTaxCombinedRequest.DataArea.Partner,
                ModelYear = inputPno34Data.CalculateTaxCombinedRequest.DataArea.ModelYear,
                PriceDate = inputPno34Data.CalculateTaxCombinedRequest.DataArea.TaxationDate,
                TaxTerritory = inputPno34Data.CalculateTaxCombinedRequest.DataArea.TaxTerritory,
                CurrencyCode = inputPno34Data.CalculateTaxCombinedRequest.DataArea.CurrencyCode,
                Pno = pno
            };

            applicationArea.Sender = new Sender()
            {
                Application = inputPno34Data.CalculateTaxCombinedRequest.ApplicationArea.Sender.Application,
                RequestCreatedDateTime = inputPno34Data.CalculateTaxCombinedRequest.ApplicationArea.Sender.RequestCreatedDatetime,
                ResponseCreatedDateTime = DateTime.Now.ToString("yyyy-MM-ddThh:mm:ssZ"),
                SequenceId = inputPno34Data.CalculateTaxCombinedRequest.ApplicationArea.Sender.SequenceId
            };

            if ((lstDbError != null && lstDbError.Count > 0) || (lstErrorMessage != null && lstErrorMessage.Count > 0))
            {
                rootErrorMessage.CallStack = "";
                rootErrorMessage.IsRootMessage = true;
                rootErrorMessage.MessageId = 0;
                rootErrorMessage.MessageText = "Tax could not be calculated for one or more included configurations";
                rootErrorMessage.MessageType = Helper.strWarning;
                rootErrorMessage.PnoSerialNo = 0;
                rootErrorMessage.MessageTitle = Helper.sUraxApplicationServer;
            }
            else if (lstDbError == null || lstDbError.Count == 0)
            {
                rootErrorMessage.IsRootMessage = true;
                rootErrorMessage.MessageId = 0;
                rootErrorMessage.MessageText =null;
                rootErrorMessage.MessageType = null;
                rootErrorMessage.PnoSerialNo = 0;
                rootErrorMessage.MessageTitle =null;
            }

            response = new Pno34Response()
            {
                Locale = inputPno34Data.CalculateTaxCombinedRequest.Locale,
                Environment = Environment.GetEnvironmentVariable("Environment"),// System.Configuration.ConfigurationManager.AppSettings["environment"]
                Revision = inputPno34Data.CalculateTaxCombinedRequest.Revision,
                ApplicationArea = applicationArea,
                DataArea = dataArea,
                ErrorMessage = rootErrorMessage
            };
            calculateTaxCombinedResponse.CalculateTaxCombinedResponse = response;
            //check lstresponse root
            if (rootErrorMessage.MessageTitle != null )
            {
                new AppInsightsLogTracker().LogTaxNotCalculated(inputPno34Data, calculateTaxCombinedResponse);
            }
            return calculateTaxCombinedResponse;
        }
    }

    public struct PnoParameterData
    {
        public List<Dictionary<string, string>> LstInputParam { get; set; }
    }
    public struct MarketWiseParameterData
    {
        public List<PnoParameterData> PnoParameterData { get; set; }
        public Dictionary<string, string> DicMarketData { get; set; }
    }
}