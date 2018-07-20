CREATE  PROCEDURE [dbo].[GetPno12CommercialData]
@TaxTerritory varchar(50),
@ModelYear varchar(4),
@specificationMarket varchar(50)
AS
BEGIN

	--DECLARE @TaxTerritory varchar(4)='AT',@ModelYear varchar(4)='2018',@specificationMarket varchar(50)='210'
	DECLARE @MarketId varchar(4)=(SELECT m.MarketId FROM dbo.Market m WHERE m.TaxTerritory=@TaxTerritory)
	SELECT p.Pno12,p.ModelYear,UPPER(pfp.ParameterValue) AS [Value],UPPER(ppd.DefinitionName) AS Name,ppd.ShortName AS Id,p.CarLine AS CarLine
	FROM dbo.Pno12 p
	INNER JOIN dbo.Pno12FixedParameters pfp ON p.Pno12Id = pfp.Pno12Id  AND p.ModelYear = @ModelYear AND p.MarketId =CAST( ISNULL(@specificationMarket,0) as INT)
	INNER JOIN dbo.Pno12ParameterDefinition ppd ON pfp.Pno12PdId = ppd.Pno12PdId 
	INNER JOIN dbo.Pno12ParameterType ppt ON ppd.Pno12PtId = ppt.Pno12PtId
	INNER JOIN dbo.Pno12UnitOfMeasurement puom ON ppd.Pno12UomId = puom.Pno12UomId  
END