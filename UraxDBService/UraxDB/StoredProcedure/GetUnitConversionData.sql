CREATE PROCEDURE [dbo].[GetUnitConversionData]
@CountryCode varchar(50)
AS
BEGIN
SELECT m.TaxTerritory AS TaxTerritory,uc.FromUnitOfMeasurementId AS FromUnitOfMeasurementId,uc.ToUnitOfMeasurementId AS ToUnitOfMeasurementId,
uc.ConversionRate AS ConversionRate,UPPER(ppd.ShortName) AS DefinitionName
FROM dbo.CountryCode cc	
JOIN dbo.TaxTerritoryUnitConversion ttuc ON cc.CountryCodeId = ttuc.CountryCodeId
JOIN dbo.Market m ON cc.CountryCodeId = m.CountryCodeId	 
JOIN dbo.UnitConversion uc ON ttuc.UnitConversionId = uc.UnitConversionId 
JOIN dbo.Pno12ParameterDefinition ppd ON uc.FromUnitOfMeasurementId =ppd.Pno12UomId 
WHERE  cc.CountryCode=@CountryCode
END
