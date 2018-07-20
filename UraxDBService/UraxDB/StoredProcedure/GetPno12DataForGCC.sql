CREATE PROCEDURE [dbo].[GetPno12DataForGCC]
@PriceDate varchar(max),
@GCCPartnerCode varchar(max),
@ModelYear varchar(max),
@specificationMarket int
AS
BEGIN
		--DECLARE @PriceDate varchar(max)='2017-11-01',@GCCPartnerCode varchar(max)='6AT2026',@ModelYear varchar(max)='2018',@specificationMarket int=250

		DECLARE @TEMP TABLE ( ID INT, PartnerCode VARCHAR(MAX),PriceDate Date,ModelYear varchar(4))
		INSERT INTO @TEMP
		SELECT T.Id, T.Value,T1.Value,T2.[value] FROM
		(SELECT  ROW_NUMBER() OVER(ORDER BY value ASC) AS ID,value   FROM  [dbo].string(@GCCPartnerCode))  T 
		INNER JOIN (
		SELECT ROW_NUMBER() OVER(ORDER BY value ASC) AS ID,CAST(value AS DATE) AS value   FROM  [dbo].string(@PriceDate)) T1 ON T.ID = T1.ID
		INNER JOIN (
		SELECT ROW_NUMBER() OVER(ORDER BY value ASC) AS ID,CAST(value AS DATE) AS value   FROM  [dbo].string(@ModelYear)) T2 ON T.ID = T2.ID
		--SELECT * FROM @TEMP
		DECLARE @CountryCode varchar(100) , @TaxTerritory varchar(100);
		DECLARE @TEMP1 TABLE (  CountryCode VARCHAR(MAX),MarketId bigInt ,TaxTerritory varchar(100),PriceDate Date,PartnerCode VARCHAR(MAX),ModelYear varchar(4))
		INSERT INTO @TEMP1
		SELECT  cc.CountryCode, m.MarketId,m.TaxTerritory, t.PriceDate,t.PartnerCode,t.ModelYear FROM   PartnerCodeMapper pcm
		INNER JOIN dbo.Market m ON pcm.MarketId = m.MarketId
		INNER JOIN dbo.CountryCode cc ON m.CountryCodeId = cc.CountryCodeId
		INNER JOIN @TEMP t ON t.PartnerCode = pcm.PartnerCode
	
		SELECT DISTINCT p.Pno12,p.ModelYear,UPPER(pfp.ParameterValue) AS [Value],UPPER(ppd.DefinitionName) AS Name,UPPER(ppd.ShortName) AS Id,p.CarLine AS CarLine
		--,t.PartnerCode, t.PriceDate, t.TaxTerritory
		,CAST(p.MarketId as INT) as MarketCode 
		FROM dbo.Pno12 p
		INNER JOIN dbo.Pno12FixedParameters pfp ON p.Pno12Id = pfp.Pno12Id --AND p.MarketId = ISNULL(@specificationMarket,0)
		--INNER JOIN @TEMP1 t ON  p.ModelYear = t.ModelYear
		INNER JOIN dbo.Pno12ParameterDefinition ppd ON pfp.Pno12PdId = ppd.Pno12PdId 
		INNER JOIN dbo.Pno12ParameterType ppt ON ppd.Pno12PtId = ppt.Pno12PtId
		INNER JOIN dbo.Pno12UnitOfMeasurement puom ON ppd.Pno12UomId = puom.Pno12UomId  
		
END
