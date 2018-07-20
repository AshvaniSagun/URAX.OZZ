using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UraxGCCService_API.Models;

namespace GCCService.Test
{
    class CalculateTaxProvideCo2Mock
    {
        private List<FeaturesInput> FeaturesMock()
        {
            var random = new Random();
            var list = new List<FeaturesInput>();
            var validStates = new List<string>() { "INCLUDED", "SELECTED", "AVAILABLE", "EXCLUDED","DEFAULT" };

            for (var i = 0; i < random.Next(0, 10); i++)
            {
                var item = new FeaturesInput
                {
                    FeatureType = random.Next(0, 9).ToString(),
                    FeatureCode = $"A{random.Next(0, 9).ToString()}",
                    State = validStates.ElementAt(random.Next(0, validStates.Count)),
                    Price = Math.Round((decimal)random.Next(100, 1000) / random.Next(3, 9), 2).ToString()
                };

                list.Add(item);
            }
            return list;
        }

        public CalculateTaxProvideCO2 CalculateTaxProvideCO2Mock()
        {

            var CalculateTaxProvideCO2 = new CalculateTaxProvideCO2
            {
                CalculateTaxProvideCO2Request = CO2RequestMock()
            };
            return CalculateTaxProvideCO2;
            }

        private CalculateTaxProvideCO2Request CO2RequestMock()
        {
            var locales = new List<string> { "sv-SE", "en-US", "en-GB" };
            var environments = new List<string> { "PROD", "DEV", "TEST", "QA" };
            var applications = new List<string> { "GCC" };
            var priceBases = new List<string> { Helper.sPBMSRP, Helper.sPBPRETAX };

            var random = new Random();

            var CalculateTaxProvideCO2Request = new CalculateTaxProvideCO2Request
            {
                Locale = "sv-SE",
                Environment = "DEV",
                Revision = "00.01",
                ApplicationArea = new ApplicationAreaInput
                {
                    Sender = new SenderInput
                    {
                        RequestDatetimeCreated = DateTime.UtcNow.ToString(),
                        SequenceId = Guid.NewGuid().ToString(),
                        Application = "GCC"
                    }
                },
                DataArea = new DataAreaInput
                {
                    SpecificationMarket = "123",
                    PnoList = new List<PnoListInput>() {
                        new PnoListInput
                        {
                            Pno12 = "123456789123",
                            Partner = "12345",
                            CountryCode = "SE",
                            CountrySubdivisionCode = "SE-SE",
                            TaxTerritory = "SE-SE",
                            ModelYear = DateTime.Now.Year.ToString(),
                            TaxationDate = DateTime.UtcNow.ToString(),
                            PriceBase = string.Empty,
                            Price = new  PriceInput
                            {
                                Amount = 100.ToString(),
                                CurrencyCode = "EUR"
                            },
                            Parameters = new List<ParametersInput>()
                            {
                                new ParametersInput
                                {
                                    Parameter = new List<Parameter>
                                    {
                                        new  Parameter
                                        {
                                            Name = $"{Guid.NewGuid()}",
                                            Status = "PRODUCTION",
                                            Value = "100.0",
                                            Unit = "Pa"
                                        }
                                    },
                                    ParameterGroup = "CO2",
                                    ParameterGroupLevel2 = "CO2"
                                }
                            },
                            Features = new List<FeaturesInput>
                            {
                                 new FeaturesInput
                                {
                                    FeatureType = random.Next(0, 9).ToString(),
                                    FeatureCode = $"A{random.Next(0, 9).ToString()}",
                                    State = "INCLUDED",
                                    Price = 100.ToString()
                                }
                            }
                        }
                    }
                }
            };

            return CalculateTaxProvideCO2Request ;
        }

    }
}
