CREATE PROCEDURE [dbo].[GetAllPno12DataForGCC]
AS
BEGIN
		SELECT DISTINCT p.Pno12,p.ModelYear,UPPER(pfp.ParameterValue) AS [Value],UPPER(ppd.DefinitionName) AS Name,UPPER(ppd.ShortName) AS Id,p.CarLine AS CarLine
		--,t.PartnerCode, t.PriceDate, t.TaxTerritory
		,CAST(p.MarketId as INT) as MarketCode 
		FROM dbo.Pno12 p
		INNER JOIN dbo.Pno12FixedParameters pfp ON p.Pno12Id = pfp.Pno12Id 
		INNER JOIN dbo.Pno12ParameterDefinition ppd ON pfp.Pno12PdId = ppd.Pno12PdId 
		INNER JOIN dbo.Pno12ParameterType ppt ON ppd.Pno12PtId = ppt.Pno12PtId
		INNER JOIN dbo.Pno12UnitOfMeasurement puom ON ppd.Pno12UomId = puom.Pno12UomId  
END