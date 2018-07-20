using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Pno34ReqRespWebApi.Models
{
    public struct CalculateTaxCombined
    {
        [JsonProperty(PropertyName = "calculateTaxCombinedRequest")]
        [Required(ErrorMessage = "calculateTaxCombinedRequest is required")]
        public CalculateTaxCombinedRequest CalculateTaxCombinedRequest { get; set; }
    }
    public struct CalculateTaxCombinedRequest
    {
        [JsonProperty(PropertyName = "locale")]
        [Required(ErrorMessage = "locale is required")]
        [RegularExpression("^[a-z]{2}[-]{1}[A-Z]{2}$", ErrorMessage = "locale format should be match (ex- en-US, sv-SE)")]
        [StringLength(5, ErrorMessage = "Fixed length should be 5")]
        public string Locale { get; set; }

        [XmlElement(IsNullable = true)]
        [JsonProperty(PropertyName = "environment")]
        [MaxLength(10, ErrorMessage = "Max length is 10")]
        public string Environment { get; set; }

        [XmlElement(IsNullable = true)]
        [JsonProperty(PropertyName = "revision")]
        [MaxLength(5, ErrorMessage = "Max length is 5")]
        public string Revision { get; set; }

        [JsonProperty(PropertyName = "applicationArea")]
        [Required(ErrorMessage = "applicationArea is required")]
        public ApplicationAreaInput ApplicationArea { get; set; }

        [JsonProperty(PropertyName = "dataArea")]
        [Required(ErrorMessage = "dataArea is required")]
        public DataAreaInput DataArea { get; set; }
    }

    public struct SenderInput
    {
        [JsonProperty(PropertyName = "application")]
        [Required(ErrorMessage = "application is required")]
        [MaxLength(20, ErrorMessage = "Max length is 20")]
        public string Application { get; set; }

        [JsonProperty(PropertyName = "requestCreatedDatetime")]
        [Required(ErrorMessage = "requestCreatedDatetime is required")]
        [MaxLength(24, ErrorMessage = "Max length is 24")]
        [RegularExpression("^[0-9]{4}[-]{1}[0-9]{2}[-]{1}[0-9]{2}[T]{1}[0-9]{2}[:]{1}[0-9]{2}[:]{1}[0-9]{2}[Z]{1}|[0-9]{4}[-]{1}[0-9]{2}[-]{1}[0-9]{2}[T]{1}[0-9]{2}[:]{1}[0-9]{2}[:]{1}[0-9]{2}[+]{1}[0-9]{4}$"
            , ErrorMessage = "dateTimeCreated format should be match ex:(2017-10-13T08:00:47Z)")]
        public string RequestCreatedDatetime { get; set; }

        [JsonProperty(PropertyName = "sequenceId")]
        [Required(ErrorMessage = "sequenceId is required")]
        [StringLength(36, ErrorMessage = "Fixed length should be 36")]
        public string SequenceId { get; set; }
    }

    public struct ApplicationAreaInput
    {
        [JsonProperty(PropertyName = "sender")]
        [Required(ErrorMessage = "sender is required")]
        public SenderInput Sender { get; set; }
    }

    public struct Price
    {
        
        [JsonProperty(PropertyName = "amount")]
        [MaxLength(28, ErrorMessage = "Maximum length is 28")]
        //[RegularExpression(@"((\d+)(\.\d{2}))$"
        //    , ErrorMessage = "Amount format should be match (ex- 9999.99)")]
        [Required(ErrorMessage = "Price amount value is required")]
        public string Amount { get; set; }
    }

    public struct ParameterInput
    {
        [JsonProperty(PropertyName = "id")]
        [Required(ErrorMessage = "id is required")]
        [MaxLength(50, ErrorMessage = "Max length is 50")]
        public string Id { get; set; }

        [XmlElement(IsNullable = true)]
        [JsonProperty(PropertyName = "name")]
        [MaxLength(50, ErrorMessage = "Max length is 50")]
        public string Name { get; set; }

        [XmlElement(IsNullable = true)]
        [JsonProperty(PropertyName = "datatype")]
        [MaxLength(30, ErrorMessage = "Max length is 30")]
        public string DataType { get; set; }

        [Required(ErrorMessage = "Commercial data values are required")]
        [JsonProperty(PropertyName = "value")]
        [MaxLength(100, ErrorMessage = "Max length is 100")]
        public string Value { get; set; }

        [XmlElement(IsNullable = true)]
        [JsonProperty(PropertyName = "unit")]
        [MaxLength(30, ErrorMessage = "Max length is 30")]
        public string Unit { get; set; }


    }
    public class PnoInput
    {
        [JsonProperty(PropertyName = "pno34options")]
        [Required(ErrorMessage = "pno34options is required")]
        [MinLength(34, ErrorMessage = "Min length is 34")]
        [MaxLength(634, ErrorMessage = "Max length is 634")]
        public string Pno34Options { get; set; }

        [JsonProperty(PropertyName = "priceBase")]
        [Required(ErrorMessage = "priceBase is required")]
        [MaxLength(20, ErrorMessage = "Maximum length is 20")]
        [RegularExpression("^([Mm][Ss][Rr][Pp]|[Pp][Rr][Ee][Tt][Aa][Xx])$", ErrorMessage = "priceBase format should be match (ex- MSRP or PRETAX)")]
        public string PriceBase { get; set; }

        [XmlElement(IsNullable = true)]
        [JsonProperty(PropertyName = "accessories")]
        public string Accessories { get; set; }

        [JsonProperty(PropertyName = "structureWeek")]
        [Required(ErrorMessage = "structureWeek is required")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Value should be in numeric format (ex- 201817)")]
        [MinLength(6, ErrorMessage = "Fixed length should be 6")]
        [StringLength(6, ErrorMessage = "Fixed length should be 6")]
        public string StructureWeek { get; set; }

        [JsonProperty(PropertyName = "price")]
        [Required(ErrorMessage = "price is required")]
        public Price Price { get; set; }

        [XmlElement(IsNullable = true)]
        [JsonProperty(PropertyName = "parameters")]
        public List<ParameterInput> Parameters { get; set; }


    }

    public struct Feature
    {
        [JsonProperty(PropertyName = "featureType")]
        [MaxLength(3, ErrorMessage = "Maximum length is 3")]
        [Required(ErrorMessage = "featureType is required")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Value should be in numeric format (ex- 4)")]
        public string FeatureType { get; set; }

        [JsonProperty(PropertyName = "featureCode")]
        [MaxLength(10, ErrorMessage = "Maximum length is 10")]
        [Required(ErrorMessage = "featureCode is required")]
        public string FeatureCode { get; set; }

        [JsonProperty(PropertyName = "state")]
        [Required(ErrorMessage = "state is required")]
        [MaxLength(20, ErrorMessage = "Maximum length is 20")]
        public string State { get; set; }

        [XmlElement(IsNullable = true)]
        [JsonProperty(PropertyName = "price")]
        [MaxLength(28, ErrorMessage = "Maximum length is 28")]
        public string Price { get; set; }
    }
    public struct DataAreaInput

    {
        [JsonProperty(PropertyName = "CountryCode")]
        [Required(ErrorMessage = "Country Code is required")]
        [RegularExpression("^[A-Z]{2}$", ErrorMessage = "Country Code format should be match (ex- “IT” for Italy,“FI” for Finland)")]
        [StringLength(2, ErrorMessage = "Fixed length should be 2")]
        public string CountryCode { get; set; }

        [XmlElement(IsNullable = true)]
        [JsonProperty(PropertyName = "gccTaxPartnerGroupCode")]
        [MaxLength(20, ErrorMessage = "Max length is 20")]
        public string GccTaxPartnerGroupCode { get; set; }

        [JsonProperty(PropertyName = "taxTerritory")]
        [Required(ErrorMessage = "Tax Territory is required")]
        [MaxLength(20, ErrorMessage = "Max length is 20")]
        public string TaxTerritory { get; set; }

        [JsonProperty(PropertyName = "specificationMarket")]
        [Required(ErrorMessage = "specificationMarket is required")]
        [MaxLength(3, ErrorMessage = "Max length is 3")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "specificationMarket should be numeric(Ex-110)")]
        public string SpecificationMarket { get; set; }

        [XmlElement(IsNullable = true)]
        [JsonProperty(PropertyName = "CountrySubdivisionCode")]
        [StringLength(5, ErrorMessage = "Fixed length should be 5")]
        [RegularExpression("^[A-Z]{2}[-]{1}[A-Z]{2}$", ErrorMessage = "CountrySubdivisionCode format should be match (ex-“IT-AO” for Italy, Aosta)")]
        public string CountrySubdivisionCode { get; set; }

        [XmlElement(IsNullable = true)]
        [JsonProperty(PropertyName = "partner")]
        [MaxLength(10, ErrorMessage = "Max length is 10")]
        public string Partner { get; set; }

        [JsonProperty(PropertyName = "modelYear")]
        [Required(ErrorMessage = "Model Year is required")]
        [RegularExpression("^[0-9]{4}$", ErrorMessage = "Model Year format should be match (ex-2018)")]
        [StringLength(4, ErrorMessage = "Fixed length should be 4")]
        public string ModelYear { get; set; }

        [Required(ErrorMessage = "Taxation Date is required")]
        [RegularExpression("^[0-9]{4}[-]{1}[0-9]{2}[-]{1}[0-9]{2}$", ErrorMessage = "Taxation Date format should be match (ex- 2017-12-31)")]
        [StringLength(10, ErrorMessage = "Fixed length should be 10")]
        [JsonProperty(PropertyName = "taxationDate")]
        public string TaxationDate { get; set; }

        [Required(ErrorMessage = "currencyCode is required")]
        [JsonProperty(PropertyName = "currencyCode")]
        [StringLength(3, ErrorMessage = "Fixed length should be 3")]
        [RegularExpression("^[A-Za-z]{3}$", ErrorMessage = "Currency Code format should be match (ex- EUR)")]
        public string CurrencyCode { get; set; }

        [XmlElement(IsNullable = true)]
        [JsonProperty(PropertyName = "fleet")]
        [RegularExpression("^([Tt][Rr][Uu][Ee]|[Ff][Aa][Ll][Ss][Ee])$", ErrorMessage = "fleet format should be match (ex- True or False)")]
        public string Fleet { get; set; }

        [JsonProperty(PropertyName = "pnoList")]
        [Required(ErrorMessage = "pnoList is required")]
        public List<PnoInput> PnoList { get; set; }
    }
}