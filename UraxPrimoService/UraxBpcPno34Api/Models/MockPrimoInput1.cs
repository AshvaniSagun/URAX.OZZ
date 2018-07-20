using Pno34ReqRespWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UraxBPCPNO34Api.Models;

namespace UraxBpcPno34Api.Models
{
    public class MockPrimoInput1
    {
        
            public static CalculateTaxCombined CreateMockPrimoInputWithInvalidLocale()
            {
                var pnoData = new CalculateTaxCombined
                {
                    CalculateTaxCombinedRequest = new CalculateTaxCombinedRequest()
                    {
                        Locale = "",
                        Environment = "DEV",
                        Revision = "1.7",
                        ApplicationArea = new ApplicationAreaInput()
                        {
                            Sender = new SenderInput()
                            {
                                Application = "Primo",
                                RequestCreatedDatetime = "2017-10-13T08:00:47Z",
                                SequenceId = "123129132"
                            }
                        },
                        DataArea = new DataAreaInput()
                        {
                            CountryCode = "SE",
                            CountrySubdivisionCode = "",
                            GccTaxPartnerGroupCode = "",
                            SpecificationMarket = "112",
                            TaxTerritory = "SE",
                            Partner = "",
                            ModelYear = "2018",
                            TaxationDate = "2017-01-02",
                            CurrencyCode = "EUR",
                            Fleet = "",
                            PnoList = new List<PnoInput>()
                        {
                            new PnoInput()
                            {
                                Pno34Options="246A8MA0411071700RA0000000000EU001000117000139000169000255000273000399000489000603000645000752000870999719",
                                PriceBase="PRETAX",
                                Accessories="",
                                StructureWeek="201746",
                                Price= new Price()
                                {
                                    Amount="10000"
                                },
                                Parameters= new List<ParameterInput>()
                                {
                                    new ParameterInput()
                                    {
                                        Id="C",
                                        Name ="NEDC CO2 COMBINED",
                                        DataType ="NUMERIC",
                                        Value ="200",
                                        Unit =""
                                    }
                                }
                            }
                        }
                        }


                    }
                };

                return pnoData;
            }
            public static CalculateTaxCombined CreateMockValidPrimoInput()
            {
                var pnoData = new CalculateTaxCombined
                {
                    CalculateTaxCombinedRequest = new CalculateTaxCombinedRequest()
                    {
                        Locale = "en-US",
                        Environment = "TEST",
                        Revision = "1.7",
                        ApplicationArea = new ApplicationAreaInput()
                        {
                            Sender = new SenderInput()
                            {
                                Application = "Primo",
                                RequestCreatedDatetime = "2017-10-13T08:00:47Z",
                                SequenceId = "123129132"
                            }
                        },
                        DataArea = new DataAreaInput()
                        {
                            CountryCode = "YE",
                            CountrySubdivisionCode = "YE-AB",
                            GccTaxPartnerGroupCode = "",
                            SpecificationMarket = "112",
                            TaxTerritory = "YM",
                            Partner = "",
                            ModelYear = "2018",
                            TaxationDate = "2018-01-02",
                            CurrencyCode = "YER",
                            Fleet = "",
                            PnoList = new List<PnoInput>()
                        {
                            new PnoInput()
                            {
                                Pno34Options="246A8MA0411071700RA0000000000EU001000117000139000169000255000273000399000489000603000645000752000870999719",
                                PriceBase="PRETAX",
                                Accessories="",
                                StructureWeek="201746",
                                Price= new Price()
                                {
                                    Amount="10000"
                                },
                                Parameters= new List<ParameterInput>()
                                {
                                    new ParameterInput()
                                    {
                                        Id="CC",
                                        Name ="CYLINDER CAPACITY",
                                        DataType ="Numeric",
                                        Value ="100",
                                        Unit =""
                                    },new ParameterInput()
                                    {
                                        Id="HP",
                                        Name ="HP",
                                        DataType ="Decimal",
                                        Value ="6",
                                        Unit =""
                                    },new ParameterInput()
                                    {
                                        Id="KW",
                                        Name ="kW",
                                        DataType ="Decimal",
                                        Value ="4.4742",
                                        Unit =""
                                    }
                                }
                            }
                        }
                        }


                    }
                };

                return pnoData;
            }

            public static Tuple<CalculateTaxCombined, List<Dictionary<string, string>>, List<List<ResultVatDetails>>, List<MarketWiseInputData>> CreateMockInput()
            {
                var inputPno34Data = CreateMockValidPrimoInput(); ;
                var lstdicPnoCertifiedData = CreateMocklstdicPnoCertifiedData();
                var result = CreateMockInputResult();
                var lstMkt = CreateMocklstMkt();
                var tuple = new Tuple<CalculateTaxCombined, List<Dictionary<string, string>>, List<List<ResultVatDetails>>, List<MarketWiseInputData>>(inputPno34Data, lstdicPnoCertifiedData, result, lstMkt);
                return tuple;
            }
            public static List<Dictionary<string, string>> CreateMocklstdicPnoCertifiedData()
            {
                var lstdicPnoCertifiedData = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    { "FUEL TYPE", "PETROL" },
                    { "NEDC CO2 COMBINED", "200" },
                    { "WLTP CO2 TOTAL", "100" }
                }

            };
                return lstdicPnoCertifiedData;
            }
            public static List<List<ResultVatDetails>> CreateMockInputResult()
            {
                var result = new List<List<ResultVatDetails>>()
            {
                new List<ResultVatDetails>()
                {
                    new ResultVatDetails()
                    {
                        Pno34="246A8MA0411071700RA0000000000EU001000117000139000169000255000273000399000489000603000645000752000870999719",
                        SequenceId=0,
                        TaxName="Yemen_BeforeVAT",
                        Value=12,
                        VatPosition="Before VAT",
                        VatPositionId=1
                    },
                    new ResultVatDetails()
                    {
                        Pno34="246A8MA0411071700RA0000000000EU001000117000139000169000255000273000399000489000603000645000752000870999719",
                        SequenceId=0,
                        TaxName="Yemen_VAT",
                        Value=1000000,
                        VatPosition="VAT",
                        VatPositionId=2
                    },
                    new ResultVatDetails()
                    {
                        Pno34="246A8MA0411071700RA0000000000EU001000117000139000169000255000273000399000489000603000645000752000870999719",
                        SequenceId=0,
                        TaxName="Yemen_AFTERVAT",
                        Value=12,
                        VatPosition="After VAT",
                        VatPositionId=3
                    }
                }
            };
                return result;
            }
            public static List<MarketWiseInputData> CreateMocklstMkt()
            {
                var lstMkt = new List<MarketWiseInputData>()
            {
                new MarketWiseInputData()
                {
                    MarketCode="YE",
                    MarketData= new List<MarketData>()
                    {
                        new MarketData()
                        {
                            MarketName= "Yemen",
                            CountryCode= "YE",
                            TaxName= "Yemen_Before_VAT",
                            TaxPriority= 1,
                            StartDate= Convert.ToDateTime("2018-01-01T00:00:00"),
                            EndDate= Convert.ToDateTime("9999-12-31T00:00:00"),
                            TaxFlow= "PRETAX",
                            TaxFlowId= 5,
                            VariableName= "HP",
                            IslookUp= false,
                            FormulaPriority= 0,
                            VariableType= "Input",
                            VariableTypeId= 6,
                            UnitType= "",
                            UnitTypeId= 14,
                            FormulaDefination= null,
                            LookUpRange= null,
                            LookupRangeTypeId= 0,
                            LookUpGroupName= null,
                            LookUpGroup= 0,
                            GroupDetails= null,
                            Value= null,
                            ValueRange= null,
                            TaxPositionId= 1,
                            VatPosition= "Before VAT",
                            MinValue= null,
                            MaxValue= null,
                            IsFormulaAvailable= true

                        },
                         new MarketData()
                        {
                            MarketName= "Yemen",
                            CountryCode= "YE",
                            TaxName= "Yemen_Before_VAT",
                            TaxPriority= 1,
                            StartDate= Convert.ToDateTime("2018-01-01T00:00:00"),
                            EndDate= Convert.ToDateTime("9999-12-31T00:00:00"),
                            TaxFlow= "PRETAX",
                            TaxFlowId= 5,
                            VariableName= "BEFOREVAT_OUTPUT",
                            IslookUp= false,
                            FormulaPriority= 1,
                            VariableType= "Output",
                            VariableTypeId= 8,
                            UnitType= "",
                            UnitTypeId= 14,
                            FormulaDefination= "HP*2",
                            LookUpRange= null,
                            LookupRangeTypeId= 0,
                            LookUpGroupName= null,
                            LookUpGroup= 0,
                            GroupDetails= null,
                            Value= null,
                            ValueRange= null,
                            TaxPositionId= 1,
                            VatPosition= "Before VAT",
                            MinValue= null,
                            MaxValue= null,
                            IsFormulaAvailable= true

                        },
                         new MarketData()
                        {
                            MarketName= "Yemen",
                            CountryCode= "YE",
                            TaxName= "Yemen_VAT",
                            TaxPriority= 2,
                            StartDate= Convert.ToDateTime("2018-01-01T00:00:00"),
                            EndDate= Convert.ToDateTime("9999-12-31T00:00:00"),
                            TaxFlow= "PRETAX",
                            TaxFlowId= 5,
                            VariableName= "CYLINDER CAPACITY",
                            IslookUp= false,
                            FormulaPriority= 0,
                            VariableType= "Input",
                            VariableTypeId= 6,
                            UnitType= "",
                            UnitTypeId= 14,
                            FormulaDefination= null,
                            LookUpRange= null,
                            LookupRangeTypeId= 0,
                            LookUpGroupName= null,
                            LookUpGroup= 0,
                            GroupDetails= null,
                            Value= null,
                            ValueRange= null,
                            TaxPositionId= 2,
                            VatPosition= "VAT",
                            MinValue= null,
                            MaxValue= null,
                            IsFormulaAvailable= true

                        },
                         new MarketData()
                        {
                            MarketName= "Yemen",
                            CountryCode= "YE",
                            TaxName= "Yemen_VAT",
                            TaxPriority= 2,
                            StartDate= Convert.ToDateTime("2018-01-01T00:00:00"),
                            EndDate= Convert.ToDateTime("9999-12-31T00:00:00"),
                            TaxFlow= "PRETAX",
                            TaxFlowId= 5,
                            VariableName= "PRETAX",
                            IslookUp= false,
                            FormulaPriority= 0,
                            VariableType= "Input",
                            VariableTypeId= 6,
                            UnitType= "",
                            UnitTypeId= 14,
                            FormulaDefination= null,
                            LookUpRange= null,
                            LookupRangeTypeId= 0,
                            LookUpGroupName= null,
                            LookUpGroup= 0,
                            GroupDetails= null,
                            Value= null,
                            ValueRange= null,
                            TaxPositionId= 2,
                            VatPosition= "VAT",
                            MinValue= null,
                            MaxValue= null,
                            IsFormulaAvailable= true

                        },
                         new MarketData()
                        {
                            MarketName= "Yemen",
                            CountryCode= "YE",
                            TaxName= "Yemen_VAT",
                            TaxPriority= 2,
                            StartDate= Convert.ToDateTime("2018-01-01T00:00:00"),
                            EndDate= Convert.ToDateTime("9999-12-31T00:00:00"),
                            TaxFlow= "PRETAX",
                            TaxFlowId= 5,
                            VariableName= "VAT_OUTPUT",
                            IslookUp= false,
                            FormulaPriority= 1,
                            VariableType= "Output",
                            VariableTypeId= 8,
                            UnitType= "",
                            UnitTypeId= 14,
                            FormulaDefination= "CYLINDER CAPACITY*PRETAX",
                            LookUpRange= null,
                            LookupRangeTypeId= 0,
                            LookUpGroupName= null,
                            LookUpGroup= 0,
                            GroupDetails= null,
                            Value= null,
                            ValueRange= null,
                            TaxPositionId= 2,
                            VatPosition= "VAT",
                            MinValue= null,
                            MaxValue= null,
                            IsFormulaAvailable= true

                        },
                         new MarketData()
                        {
                            MarketName= "Yemen",
                            CountryCode= "YE",
                            TaxName= "Yemen_AFTER_VAT",
                            TaxPriority= 3,
                            StartDate= Convert.ToDateTime("2018-01-01T00:00:00"),
                            EndDate= Convert.ToDateTime("9999-12-31T00:00:00"),
                            TaxFlow= "PRETAX",
                            TaxFlowId= 5,
                            VariableName= "KW",
                            IslookUp= false,
                            FormulaPriority= 0,
                            VariableType= "Input",
                            VariableTypeId= 6,
                            UnitType= "",
                            UnitTypeId= 14,
                            FormulaDefination= null,
                            LookUpRange= null,
                            LookupRangeTypeId= 0,
                            LookUpGroupName= null,
                            LookUpGroup= 0,
                            GroupDetails= null,
                            Value= null,
                            ValueRange= null,
                            TaxPositionId= 3,
                            VatPosition= "After VAT",
                            MinValue= null,
                            MaxValue= null,
                            IsFormulaAvailable= true

                        },
                         new MarketData()
                        {
                            MarketName= "Yemen",
                            CountryCode= "YE",
                            TaxName= "Yemen_AFTER_VAT",
                            TaxPriority= 3,
                            StartDate= Convert.ToDateTime("2018-01-01T00:00:00"),
                            EndDate= Convert.ToDateTime("9999-12-31T00:00:00"),
                            TaxFlow= "PRETAX",
                            TaxFlowId= 5,
                            VariableName= "AFTER_VAT_OUTPUT",
                            IslookUp= false,
                            FormulaPriority= 0,
                            VariableType= "Input",
                            VariableTypeId= 8,
                            UnitType= "",
                            UnitTypeId= 14,
                            FormulaDefination= "KW*2",
                            LookUpRange= null,
                            LookupRangeTypeId= 0,
                            LookUpGroupName= null,
                            LookUpGroup= 0,
                            GroupDetails= null,
                            Value= null,
                            ValueRange= null,
                            TaxPositionId= 3,
                            VatPosition= "After VAT",
                            MinValue= null,
                            MaxValue= null,
                            IsFormulaAvailable= true

                        }
                    },
                    PriceDate= "2018-01-02",
                    PnoParameterData= new List<PnoParameterData>()
                    {
                        new PnoParameterData()
                        {
                            LstInputParam= new List<Dictionary<string, string>>()
                            {
                                new Dictionary<string, string>()
                                {
                                    {"CYLINDER CAPACITY","100" },
                                    {"HP","6" },
                                    {"KW","4.4742" },
                                    {"FUEL TYPE","PETROL" },
                                    {"NEDC CO2 COMBINED","139" },
                                    {"WLTP CO2 TOTAL","166" },
                                    {"MASS IN RUNNING ORDER TOTAL","1815" },
                                    {"HOMOLOGATION CURB WEIGHT TOTAL","1740" },
                                    {"TP MAX LADEN MASS","2420" },
                                    {"NEDC_CO2_UDC","165" },
                                    {"NEDC_CO2_EUDC","124" },
                                    {"WLTP_CO2_LOW","197" },
                                    {"WLTP_CO2_MEDIUM","166" },
                                    {"WLTP_CO2_HIGH","144" },
                                    {"WLTP_CO2_EXTRA_HIGH","173" },
                                    {"NEDC FUEL CONSUMPTION COMBINED","5.3" },
                                    {"NEDC_FC_UDC","6.3" },
                                    {"NEDC_FC_EUDC","4.7" },
                                    {"WLTP FUEL CONSUMPTION TOTAL","6.4" },
                                    {"WLTP_FC_LOW","7.5" },
                                    {"WLTP_FC_MEDIUM","6.4" },
                                    {"WLTP_FC_HIGH","5.5" },
                                    {"WLTP_FC_EXTRA_HIGH","6.6" },
                                    {"pno34","246A8MA0411071700RA0000000000EU001000117000139000169000255000273000399000489000603000645000752000870999719" },
                                    {"PRETAX","10000" },
                                    {"priceType","PRETAX" },
                                    {"structureWeek","201746" },
                                    {"PnoSrlNo","0" }
                                }
                            }
                        }
                    }
                }
            };
                return lstMkt;
            }
        
    }

}
