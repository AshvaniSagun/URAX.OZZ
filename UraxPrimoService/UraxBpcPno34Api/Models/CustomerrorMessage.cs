using Newtonsoft.Json;
using Pno34ReqRespWebApi.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;
using System.Xml.Serialization;
using UraxBpcPno34Api.Models;

namespace UraxBpcPno34Api.Models
{
    public class CustomErrorMessage
    {
        [JsonProperty(PropertyName = "messageId")]
        public int MessageId { get; set; }
        [JsonProperty(PropertyName = "messageType")]
        public string MessageType { get; set; }
        [JsonProperty(PropertyName = "messageTitle")]
        public string MessageTitle { get; set; }
        [JsonProperty(PropertyName = "messageText")]
        public string MessageText { get; set; }
        [XmlElement(IsNullable = true)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "callStack")]
        public string CallStack { get; set; }
        [JsonProperty(PropertyName = "pnoSerialNo")]
        public int PnoSerialNo { get; set; }
        [JsonProperty(PropertyName = "isRootMessage")]
        public bool IsRootMessage { get; set; }

        internal CalculateTaxCombinedResponseOutput GetCustomErrorDetails(CalculateTaxCombined inputPno34Data, string message)
        {
            List<CustomErrorMessage> lstErrorMessage = new List<CustomErrorMessage>();
            int i = 0;

            lstErrorMessage.Add(new CustomErrorMessage()
            {
                MessageType = Helper.strError,
                MessageText = message,
                MessageTitle = Helper.sUraxApplicationServer,
                MessageId = i,
                CallStack = ""
            });
            return CalculateTaxCombinedResponse(inputPno34Data, lstErrorMessage);
        }

        internal CalculateTaxCombinedResponseOutput GetErrorDetails(CalculateTaxCombined inputPno34Data, ModelStateDictionary modelState)
        {
            List<CustomErrorMessage> lstErrorMessage = new List<CustomErrorMessage>();
            int i = 0;
            Dictionary<string, string> dicRootData = Helper.Getpno34DataDatakey();
            Dictionary<string, string> dicPnoData = Helper.GetpnoDataDatakey();
            List<int> pnonos = new List<int>();
            foreach (var data in modelState)
            {
                string strstack = data.Key.Replace("pno34Data.", "");
                int SerialNo = 0;
                bool RootMessage = false;
                if (dicRootData.ContainsValue(strstack))
                {
                    SerialNo = 0;
                    RootMessage = true;
                }
                else
                {
                    int lastindex = strstack.LastIndexOf('.') + 1;
                    int lastindex1 = 0;
                    int lastindex2 = 1;
                    string substring = strstack.Substring(lastindex);
                    if (dicPnoData.ContainsValue(substring))
                    {
                        lastindex1 = strstack.LastIndexOf('[') + 1;
                        lastindex2 = strstack.LastIndexOf(']');
                    }
                    else if ("Amount" == substring)
                    {
                        lastindex1 = strstack.IndexOf(".PnoList[") + 9;
                        lastindex2 = strstack.IndexOf("].Price.Amount") ;
                    }
                    else
                    {
                        lastindex1 = strstack.IndexOf(".PnoList[") == -1 ? strstack.IndexOf(".pnoList[") + 9 : strstack.IndexOf(".PnoList[") + 9;
                        lastindex2 = strstack.IndexOf("].Parameters") == -1 ? strstack.IndexOf("].parameters") : strstack.IndexOf("].Parameters");
                    }
                    SerialNo = Convert.ToInt32(strstack.Substring(lastindex1, lastindex2 - lastindex1));

                }
                if (lstErrorMessage.Any(x => x.PnoSerialNo == SerialNo && x.IsRootMessage == RootMessage))
                {
                    //Update Data
                    foreach (var item in lstErrorMessage.Where(x => x.PnoSerialNo == SerialNo && x.IsRootMessage == RootMessage))
                    {
                        item.CallStack = item.CallStack + "," + data.Key.Replace("pno34Data[0].", "");
                        string msg = data.Value.Errors[0].ErrorMessage == "" ? data.Value.Errors[1].ErrorMessage : data.Value.Errors[0].ErrorMessage;
                        item.MessageText = item.MessageText.Contains(msg) ? item.MessageText : item.MessageText + "," + msg;
                    }
                }
                else
                {
                    lstErrorMessage.Add(new CustomErrorMessage()
                    {
                        MessageType = Helper.strError,
                        MessageText = data.Value.Errors[0].ErrorMessage == "" ? data.Value.Errors[1].ErrorMessage : data.Value.Errors[0].ErrorMessage,
                        MessageTitle = "",
                        MessageId = i,
                        CallStack = data.Key.Replace("pno34Data[0].", ""),
                        PnoSerialNo = SerialNo,
                        IsRootMessage = RootMessage
                    });
                    i++;
                    pnonos.Add(SerialNo);
                }


            }
            //Check if root level error is not avialable 
            if (!lstErrorMessage.Any(x => x.IsRootMessage == true))
            {

                if (inputPno34Data.CalculateTaxCombinedRequest.DataArea.PnoList.Count > lstErrorMessage.Where(x => x.IsRootMessage == false).ToList().Count)
                {
                    return new Pno34().Pno34ResponseData(inputPno34Data, pnonos, lstErrorMessage);

                }
            }
            return CalculateTaxCombinedResponse(inputPno34Data, lstErrorMessage);
        }
        private static ObservableCollection<T> DeepCopy<T>(IEnumerable<T> list)
     where T : ICloneable
        {
            return new ObservableCollection<T>(list.Select(x => x.Clone()).Cast<T>());
        }
        internal CalculateTaxCombinedResponseOutput CalculateTaxCombinedResponse(CalculateTaxCombined inputPno34Data, List<CustomErrorMessage> lstErrorMessage)
        {
            try
            {
                var response = new CalculateTaxCombinedResponseOutput();
                var pno34Response = new Pno34Response();
                var dataArea = new DataArea();
                var applicationArea = new ApplicationArea();
                var sender = new Sender();
                var lstPno = new List<Pno>();
                int pnoindex = 0;
                foreach (var datapno in inputPno34Data.CalculateTaxCombinedRequest.DataArea.PnoList)
                {
                    foreach (var item in lstErrorMessage.Where(x => x.PnoSerialNo == pnoindex && x.IsRootMessage == false))
                    {
                        item.MessageTitle = datapno.Pno34Options;
                    }
                    lstPno.Add(new Pno()
                    {
                        ErrorMessage = lstErrorMessage.Where(x => x.PnoSerialNo == pnoindex && x.IsRootMessage == false).FirstOrDefault(),
                        Pno34 = datapno.Pno34Options
                    });
                    pnoindex++;
                }
                dataArea = new DataArea()
                {
                    CountryCode = inputPno34Data.CalculateTaxCombinedRequest.DataArea.CountryCode,
                    CountrySubdivisionCode = inputPno34Data.CalculateTaxCombinedRequest.DataArea.CountrySubdivisionCode,
                    CurrencyCode = inputPno34Data.CalculateTaxCombinedRequest.DataArea.CurrencyCode,
                    GccTaxPartnerGroup = inputPno34Data.CalculateTaxCombinedRequest.DataArea.GccTaxPartnerGroupCode,
                    ModelYear = inputPno34Data.CalculateTaxCombinedRequest.DataArea.ModelYear,
                    Partner = inputPno34Data.CalculateTaxCombinedRequest.DataArea.Partner,
                    PriceDate = inputPno34Data.CalculateTaxCombinedRequest.DataArea.TaxationDate,
                    SpecificationMarket = inputPno34Data.CalculateTaxCombinedRequest.DataArea.SpecificationMarket,
                    TaxTerritory = inputPno34Data.CalculateTaxCombinedRequest.DataArea.TaxTerritory,
                    Pno = lstPno,

                };
                sender = new Sender()
                {
                    Application = inputPno34Data.CalculateTaxCombinedRequest.ApplicationArea.Sender.Application,
                    RequestCreatedDateTime = inputPno34Data.CalculateTaxCombinedRequest.ApplicationArea.Sender.RequestCreatedDatetime,
                    SequenceId = inputPno34Data.CalculateTaxCombinedRequest.ApplicationArea.Sender.SequenceId,
                    ResponseCreatedDateTime = DateTime.Now.ToString("yyyy-MM-ddThh:mm:ssZ")
                };

                applicationArea.Sender = sender;

                var RootErrorMessage = new CustomErrorMessage();
                if ((lstErrorMessage.Where(x => x.PnoSerialNo == 0 && x.IsRootMessage == true).ToList().Count == 0) && (lstErrorMessage != null && lstErrorMessage.Count > 0))
                {
                    RootErrorMessage.CallStack = "";
                    RootErrorMessage.IsRootMessage = true;
                    RootErrorMessage.MessageId = 0;
                    RootErrorMessage.MessageText = "Tax could not be calculated for one or more included configurations";
                    RootErrorMessage.MessageType = Helper.strWarning;
                    RootErrorMessage.PnoSerialNo = 0;
                    RootErrorMessage.MessageTitle = Helper.sUraxApplicationServer;
                }
                else if (lstErrorMessage.Where(x => x.IsRootMessage == true).ToList().Count > 0)
                {
                    var ltsError = lstErrorMessage.Where(x => x.IsRootMessage == true).FirstOrDefault();
                    RootErrorMessage.CallStack = ltsError.CallStack;
                    RootErrorMessage.IsRootMessage = true;
                    RootErrorMessage.MessageId = ltsError.MessageId;
                    RootErrorMessage.MessageText = ltsError.MessageText;
                    RootErrorMessage.MessageType = Helper.strError;
                    RootErrorMessage.PnoSerialNo = ltsError.PnoSerialNo;
                    RootErrorMessage.MessageTitle = ltsError.MessageTitle;
                }
                else
                {
                    lstErrorMessage.Where(x => x.PnoSerialNo == 0 && x.IsRootMessage == true).ToList();
                }
                pno34Response = new Pno34Response()
                {
                    ApplicationArea = applicationArea,
                    DataArea = dataArea,
                    Environment = inputPno34Data.CalculateTaxCombinedRequest.Environment,
                    Locale = inputPno34Data.CalculateTaxCombinedRequest.Locale,
                    Revision = inputPno34Data.CalculateTaxCombinedRequest.Revision,
                    ErrorMessage = RootErrorMessage

                };
                response.CalculateTaxCombinedResponse = pno34Response;
                //check lstresponse root
                if (RootErrorMessage.MessageTitle != null)
                {
                    new AppInsightsLogTracker().LogTaxNotCalculated(inputPno34Data, response);
                }
                return response;

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}