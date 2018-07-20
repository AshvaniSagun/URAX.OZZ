using Newtonsoft.Json;
using Pno34ReqRespWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UraxBpcPno34Api.Models
{
    public class RedaRequest
    {
        #region Request Property

        public REDAIndividualValuesRequest REDAIndividualValuesRequest { get; set; }
        #endregion
        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmss");
        }
        //public static List<RedaRequest> CreateRedaRequest(IEnumerable<CalculateTaxCombined> inputPno34Data)
        //{
        //    string OccurenceCd = "99990";
        //    string OccurenceDesc = "URAX";
        //    string Pno34String = string.Empty;
        //    string[] Options = null;
        //    var header = new Header()
        //    {
        //        TimeStamp = GetTimestamp(DateTime.Now),
        //        SchemaVersion = "01.01.00"
        //    };
        //    var requestList = new List<RedaRequest>();
        //    string pno34 = string.Empty;
        //    foreach (var Pno34Data in inputPno34Data)
        //    {
        //        foreach (var dataparam in Pno34Data.CalculateTaxCombinedRequest)
        //            foreach (var param in dataparam.DataArea)
        //            {
        //                foreach (var pno in param.PnoList)
        //                {
        //                    Pno34String = pno.Pno34Options.Replace(" ","");
        //                    var lstOptions = new List<string>();
        //                    for (int i = 34; i < Pno34String.Length; i+=6)
        //                    {
        //                        lstOptions.Add(Pno34String.Substring(i,6));
        //                    }
        //                    Options = lstOptions.ToArray();
        //                    var request = new REDAIndividualValuesRequest
        //                    {
        //                        Header = header,
        //                        Order = new Order()
        //                        {
        //                            Occurence_Cd = OccurenceCd,
        //                            Occurence_Desc = OccurenceDesc,
        //                            StructureWeek = pno.StructureWeek,
        //                            PnO12 = Pno34String.Substring(0, 12),
        //                            ColourCode = Pno34String.Substring(12, 5),
        //                            UpholsteryCode = Pno34String.Substring(17, 6),
        //                            Options = Options,
        //                            SMsgCode = Pno34String.Substring(29, 5)
        //                        }
        //                    };
        //                    var requestReda = new RedaRequest() { REDAIndividualValuesRequest=request};
        //                    requestList.Add(requestReda);
        //                }
        //            }
        //    }
        //    return requestList;
        //}
        public static List<RedaRequest> CreateRedaRequest(CalculateTaxCombined inputPno34Data)
        {
            string OccurenceCd = "99990";
            string OccurenceDesc = "URAX";
            string Pno34String = string.Empty;
            string[] Options = null;
            var header = new Header()
            {
                TimeStamp = GetTimestamp(DateTime.Now),
                SchemaVersion = "01.01.00"
            };
            var requestList = new List<RedaRequest>();
            string pno34 = string.Empty;
            var CalculateTaxCombinedRequest = inputPno34Data.CalculateTaxCombinedRequest;
            var pnoList = inputPno34Data.CalculateTaxCombinedRequest.DataArea.PnoList;
            foreach (var pno in pnoList)
            {
                Pno34String = pno.Pno34Options;
                if (Pno34String.Length < 33) throw new ArgumentException("Min length is 34.");
                
                var lstOptions = new List<string>();
                for (int i = 34;6<=((Pno34String.Length- i)/6); i += 6)
                {
                    lstOptions.Add(Pno34String.Substring(i, 6));
                }
                Options = lstOptions.ToArray();
                var request = new REDAIndividualValuesRequest
                {
                    Header = header,
                    Order = new Order()
                    {
                        Occurence_Cd = OccurenceCd,
                        Occurence_Desc = OccurenceDesc,
                        StructureWeek = pno.StructureWeek,
                        PnO12 = Pno34String.Substring(0, 12),
                        ColourCode = Pno34String.Substring(12, 5),
                        UpholsteryCode = Pno34String.Substring(17, 6),
                        Options = Options,
                        SMsgCode = Pno34String.Substring(29, 5)
                    }
                };
                var requestReda = new RedaRequest() { REDAIndividualValuesRequest = request };
                requestList.Add(requestReda);
            }

            return requestList;
        }
    }

    public class REDAIndividualValuesRequest
    {
        public Header Header { get; set; }
        public Order Order { get; set; }
    }
    #region Header
    public class Header
    {
        #region Reda Header Property
        public string TimeStamp { get; set; }
        public string SchemaVersion { get; set; }
        #endregion
    }
    #endregion

    #region order

    public class Order
    {
        public string Occurence_Cd { get; set; }
        public string Occurence_Desc { get; set; }
        #region Reda Pno Property
        public string StructureWeek { get; set; }
        public string PnO12 { get; set; }
        public string ColourCode { get; set; }
        public string UpholsteryCode { get; set; }
        public string SMsgCode { get; set; }
        public string[] Options { get; set; }
        #endregion
    }
    #endregion
}
