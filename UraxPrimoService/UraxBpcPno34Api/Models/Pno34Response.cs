using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Xml.Serialization;
using UraxBpcPno34Api.Models;

namespace Pno34ReqRespWebApi.Models
{
    public struct CalculateTaxCombinedResponseOutput
    {
        [JsonProperty(PropertyName = "calculateTaxCombinedResponse")]
        public Pno34Response CalculateTaxCombinedResponse { get; set; }

       
    }
    public struct Pno34Response
    {
        [JsonProperty(PropertyName = "locale")]
        public string Locale { get; set; }
        [XmlElement(IsNullable = true)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "environment")]
        public string Environment { get; set; }
        [XmlElement(IsNullable = true)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "revision")]
        public string Revision { get; set; }

        [JsonProperty(PropertyName = "applicationArea")]
        public ApplicationArea ApplicationArea { get; set; }
        [JsonProperty(PropertyName = "dataArea")]
        public DataArea DataArea { get; set; }
        [JsonProperty(PropertyName = "errorMessage")]
        public CustomErrorMessage ErrorMessage { get; set; }

    }
    public struct Sender
    {
        [JsonProperty(PropertyName = "application")]
        public string Application { get; set; }
        [JsonProperty(PropertyName = "requestCreatedDateTime")]
        public string RequestCreatedDateTime { get; set; }
        [JsonProperty(PropertyName = "responseCreatedDateTime")]
        public string ResponseCreatedDateTime { get; set; }
        [JsonProperty(PropertyName = "sequenceId")]
        public string SequenceId { get; set; }
    }
    public struct ApplicationArea
    {
        [JsonProperty(PropertyName = "sender")]

        public Sender Sender { get; set; }

    }
    public struct DataArea
    {
        [XmlElement(IsNullable = true)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "countryCode")]
        public string CountryCode { get; set; }
        [XmlElement(IsNullable = true)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "gccTaxPartnerGroup")]
        public string GccTaxPartnerGroup { get; set; }
        [XmlElement(IsNullable = true)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "specificationMarket")]
        public string SpecificationMarket { get; set; }
        [XmlElement(IsNullable = true)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "countrysubdivisionCode")]
        public string CountrySubdivisionCode { get; set; }
        [JsonProperty(PropertyName = "partner")]
        public string Partner { get; set; }
        [JsonProperty(PropertyName = "modelYear")]
        public string ModelYear { get; set; }
        [JsonProperty(PropertyName = "taxationDate")]

        public string PriceDate { get; set; }
        [JsonProperty(PropertyName = "taxTerritory")]

        public string TaxTerritory { get; set; }
        [JsonProperty(PropertyName = "currencyCode")]
        public string CurrencyCode { get; set; }
        [JsonProperty(PropertyName = "pnoList")]
        public List<Pno> Pno { get; set; }
    }
    public struct Pno
    {
        [JsonProperty(PropertyName = "pno34Options")]
        public string Pno34 { get; set; }
        [JsonProperty(PropertyName = "priceBase")]
        public string PriceBase { get; set; }
        [XmlElement(IsNullable = true)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "accessories")]
        public string Accessories { get; set; }
        [JsonProperty(PropertyName = "structureWeek")]
        public string StructureWeek { get; set; }
        [XmlElement(IsNullable = true)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "msrpAmount")]
        public string Msrp { get; set; }
        [XmlElement(IsNullable = true)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "pretaxAmount")]
        public string Pretax { get; set; }
        [XmlElement(IsNullable = true)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "totalTaxAmount")]
        public string TotalTax { get; set; }

        [JsonProperty(PropertyName = "vatPositions")]
        public List<VatPositions> VatPositions { get; set; }
        [XmlElement(IsNullable = true)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "parameters")]
        public List<Parameter> Parameters { get; set; }
        
        [XmlElement(IsNullable = true)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "errorMessage")]
        public CustomErrorMessage ErrorMessage { get; set; }
    }
    public struct Tax
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "amount")]
        public string Amount { get; set; }
        [XmlElement(IsNullable = true)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "vatRate")]
        public string VatRate { get; set; }

    }
    public struct Parameter
    {
        [JsonProperty(PropertyName = "id")]
        [MaxLength(50, ErrorMessage = "Max length is 50")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        [MaxLength(50, ErrorMessage = "Max length is 50")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "datatype")]
        public string Datatype { get; set; }
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
        [XmlElement(IsNullable = true)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "unit")]
        [MaxLength(30, ErrorMessage = "Max length is 30")]
        public string Unit { get; set; }
        [JsonProperty(PropertyName = "status")]
        [MaxLength(50, ErrorMessage = "Max length is 50")]
        public string Status { get; set; }
    }
    public struct FeatureResult
    {
        [JsonProperty(PropertyName = "featureType")]
        public string FeatureType { get; set; }
        [JsonProperty(PropertyName = "featureCode")]
        public string FeatureCode { get; set; }
        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }
        [JsonProperty(PropertyName = "vatName")]
        public string VatName { get; set; }
        [JsonProperty(PropertyName = "vatRate")]
        public string VatRate { get; set; }
        [XmlElement(IsNullable = true)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "vatExcludedAmount")]
        public decimal VatExcludedAmount { get; set; }
        [XmlElement(IsNullable = true)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "vatOnlyAmount")]
        public decimal VatOnlyAmount { get; set; }
        [XmlElement(IsNullable = true)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "vatIncludedAmount")]
        public decimal VatIncludedAmount { get; set; }
    }
    public struct VatPositions
    {
        [JsonProperty(PropertyName = "vatPosition")]
        public string VatPosition { get; set; }
        [JsonProperty(PropertyName = "vatPositionTotalAmount")]
        public string VatPositionTotalAmount { get; set; }
        [JsonProperty(PropertyName = "taxList")]

        public List<Tax> TaxList { get; set; }
    }
}