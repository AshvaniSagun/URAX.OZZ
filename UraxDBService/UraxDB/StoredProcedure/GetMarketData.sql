CREATE PROCEDURE [dbo].[GetMarketData](
@CountryCode varchar(10),
@PriceDate Date,
@TaxTerritory varchar(50)

)
AS
BEGIN
	--DECLARE @CountryCode varchar(10)='ZZ',@PriceDate Date='2018-01-01',@TaxTerritory varchar(50)='URAX'
	--set @MarketCode ='FI'
	--set @PriceDate ='2017-01-01'
	SELECT * FROM
	(
	--DECLARE @CountryCode varchar(10)='ZZ',@PriceDate Date='2018-01-01',@TaxTerritory varchar(50)='URAX'

	SELECT   cc.CountryName as MarketName,cc.CountryCode ,CASE WHEN ld.TaxName IS NULL THEN tm.TaxName ELSE ld.TaxName END AS TaxName , tm.TaxPositionId
	, CASE WHEN tm.TaxPositionId= 1 THEN 'Before VAT' WHEN tm.TaxPositionId=2 THEN 'VAT' ELSE 'After VAT' END AS VatPosition
	,tm.[Priority] AS TaxPriority,tv.StartDate, tv.EndDate,pd2.[Value] AS TaxFlow ,t.TaxFlowId,UPPER(v.VariableName) AS VariableName
	,v.IslookUp,ISnull(f.[Priority],0) AS FormulaPriority
	,pd.[Value] AS [VariableType],v.VariableTypeId
	,pd3.[Value] as [UnitType], v.UnitTypeId
	,f.FormulaDefination,f.MinValue, f.MaxValue
	,NULL as [LookUpRange],Isnull(NULL,0) AS [LookupRangeTypeId],NULL AS LookUpGroupName,Isnull(NULL,0) AS LookUpGroup,IsnUll(NULL,0) AS GroupDetailsId
	--,CAST(v.[Value]  AS varchar(500)) AS [Value]
	,CAST( CASE WHEN  v.[Value] LIKE '%-%' THEN   substring(CAST(v.[Value]  AS varchar(200)), 1, CHARINDEX('-',v.[Value])-1)  ELSE UPPER(v.[Value])
	 END AS varchar(500)) AS [Value]
	,CAST(  CASE  WHEN  v.[Value] LIKE '%-%' THEN    substring(CAST(v.[Value] AS varchar(200)), CHARINDEX('-',v.[Value])+1, LEN(v.[Value])) ELSE UPPER(v.[Value])
	 END AS varchar(500))   as [ValueRange]
	 ,CAST(1 AS bit) AS IsFormulaAvailable
	 ,CAST(tm.TaxMasterId AS INT)  AS TaxMasterId
	 ,UPPER(CAST(v.TestValue AS varchar)) AS DefaultValue
	 FROM dbo.Variable v
	LEFT JOIN  dbo.Formula f ON f.VariableId = v.VariableId
	LEFT JOIN dbo.ParameterDetails pd ON pd.ParameterId = v.VariableTypeId  AND pd.ParameterGroupId=3
	LEFT JOIN dbo.ParameterDetails pd3 ON pd3.parameterId = v.UnitTypeId AND pd3.ParameterGroupId =5
	INNER JOIN dbo.Tax t ON v.TaxId = t.TaxId
	LEFT JOIN [dbo].ParameterDetails pd2 ON pd2.ParameterId = t.TaxFlowId AND pd2.ParameterGroupId=1
	INNER JOIN dbo.TaxVersion tv ON t.TaxVersionId = tv.TaxVersionId
	INNER JOIN dbo.TaxMaster tm ON tv.TaxMasterId = tm.TaxMasterId
	LEFT JOIN  dbo.LanguageDetails ld ON tm.TaxMasterId = ld.TaxMasterId AND ld.IsActive=1
	INNER JOIN dbo.Market m ON tm.MarketId = m.MarketId
	INNER JOIN dbo.CountryCode cc ON m.CountryCodeId = cc.CountryCodeId
	INNER JOIN dbo.CurrencyDetails cd ON m.currencyId = cd.CurrencyId
	WHERE cc.CountryCode = @CountryCode AND m.TaxTerritory= @TaxTerritory AND @PriceDate BETWEEN tv.StartDate AND tv.EndDate
	--ORDER BY tm.[Priority] ASC ,f.[Priority] ASC
	UNION ALL
	-------LookUp Details
	SELECT   cc.CountryName as MarketName,cc.CountryCode ,CASE WHEN ld.TaxName IS NULL THEN tm.TaxName ELSE ld.TaxName END AS TaxName , tm.TaxPositionId
	, CASE WHEN tm.TaxPositionId= 1 THEN 'Before VAT' WHEN tm.TaxPositionId=2 THEN 'VAT' ELSE 'After VAT' END AS VatPosition
	,tm.[Priority] AS TaxPriority,tv.StartDate, tv.EndDate,pd4.[Value] AS TaxFlow ,t.TaxFlowId
	,UPPER(v.VariableName) AS VariableName,v.IslookUp,0 AS [FormulaPriority] --,lgd.VariableId
	,pd.[Value] as [VariableType],v.VariableTypeId
	,pd2.[Value] as [VariableUnit], v.UnitTypeId, NULL AS [FormulaDefination],NULL as MinValue, NULL as MaxValue
	,pd3.[Value] AS [LookUpRange],lgd.LookupRangeTypeId
	,lug.LookUpGroupName AS [LookUpGroupName]  ,lud.LookUpGroup,lud.GroupDetailsId
	--,lud.[Value], lud.[Value] AS ValueRange FROM dbo.LookUpDetails lud
	,CAST( CASE WHEN  lud.[Value] LIKE '%-%' THEN   substring(CAST(lud.[Value]  AS varchar(200)), 1, CHARINDEX('-',lud.[Value])-1)  ELSE UPPER(lud.[Value])
	 END   AS varchar(500)) AS [Value]
	, CAST( CASE  WHEN  lud.[Value] LIKE '%-%' THEN    substring(CAST(lud.[Value] AS varchar(200)), CHARINDEX('-',lud.[Value])+1, LEN(lud.[Value])) ELSE UPPER(lud.[Value])
	 END  AS varchar(500))  as [ValueRange]
	 ,CAST(1 AS bit) AS IsFormulaAvailable
	 ,CAST(tm.TaxMasterId AS INT)  AS TaxMasterId
	 ,UPPER(CAST(v.TestValue AS varchar)) AS DefaultValue
	FROM dbo.LookUpDetails lud
	INNER JOIN dbo.LookupGroupDetail lgd ON lud.GroupDetailsId = lgd.GroupDetailsId
	INNER JOIN dbo.Variable v ON lgd.VariableId = v.VariableId
	INNER JOIN dbo.ParameterDetails pd ON v.VariableTypeId = pd.ParameterId
	INNER JOIN dbo.ParameterDetails pd3 ON pd3.ParameterId = lgd.LookupRangeTypeId
	LEFT JOIN [dbo].ParameterDetails pd2 ON pd2.ParameterId = v.UnitTypeId AND pd2.ParameterGroupId=5
	INNER JOIN dbo.LookUpGroup lug ON lgd.LookUpGroupId = lug.LookUpGroupId
	INNER JOIN dbo.Tax t ON v.TaxId = t.TaxId
	LEFT JOIN dbo.ParameterDetails pd4 ON pd4.ParameterId = t.TaxFlowId AND pd4.ParameterGroupId=1
	INNER JOIN dbo.TaxVersion tv ON t.TaxVersionId = tv.TaxVersionId
	INNER JOIN dbo.TaxMaster tm ON tv.TaxMasterId = tm.TaxMasterId
	LEFT JOIN  dbo.LanguageDetails ld ON tm.TaxMasterId = ld.TaxMasterId AND ld.IsActive=1
	INNER JOIN dbo.Market m ON tm.MarketId = m.MarketId
	INNER JOIN dbo.CountryCode cc ON m.CountryCodeId = cc.CountryCodeId
	INNER JOIN dbo.CurrencyDetails cd ON m.currencyId = cd.CurrencyId
	WHERE cc.CountryCode = @CountryCode AND m.TaxTerritory= @TaxTerritory AND @PriceDate BETWEEN tv.StartDate AND tv.EndDate

	UNION ALL
	---Formula not avl with Tax Name
	SELECT DISTINCT
	'' as MarketName,'' as CountryCode , tm.TaxName ,0 AS TaxPositionId
	, '' AS VatPosition
	,0 TaxPriority,tv.StartDate, tv.EndDate,pd4.[Value] AS TaxFlow ,t.TaxFlowId
	,'' AS VariableName
	,CAST(0 AS BIT) AS IslookUp,0 AS FormulaPriority
	,'' AS [VariableType],0 AS VariableTypeId
	,'' as [UnitType], 0 AS  UnitTypeId
	,NULL FormulaDefination,NULL MinValue, NULL MaxValue
	,NULL as [LookUpRange],0 AS [LookupRangeTypeId],NULL AS LookUpGroupName,0 AS LookUpGroup,0 AS GroupDetailsId
	--,CAST(v.[Value]  AS varchar(500)) AS [Value]
	,'' AS [Value]
	,''   as [ValueRange]
	 ,CAST(0 AS bit) AS IsFormulaAvailable
	,CAST(tm.TaxMasterId AS INT)  AS TaxMasterId
	,UPPER(CAST(v.TestValue AS varchar)) AS DefaultValue
	FROM dbo.TaxMaster tm
	INNER JOIN dbo.Market m ON tm.MarketId = m.MarketId
	INNER JOIN dbo.CountryCode cc ON m.CountryCodeId = cc.CountryCodeId
	INNER JOIN dbo.TaxVersion tv ON tm.TaxMasterId = tv.TaxMasterId
	INNER JOIN dbo.Tax t ON tv.TaxVersionId = t.TaxVersionId
	LEFT JOIN dbo.ParameterDetails pd4 ON pd4.ParameterId = t.TaxFlowId AND pd4.ParameterGroupId=1
	LEFT JOIN dbo.Variable v ON t.TaxId = v.TaxId
	WHERE cc.CountryCode = @CountryCode AND m.TaxTerritory= @TaxTerritory AND @PriceDate BETWEEN tv.StartDate AND tv.EndDate  AND v.VariableId IS NULL
	UNION ALL
	---Formula not avl with Tax Name
	SELECT '' as MarketName,'' as CountryCode , tm.TaxName ,0 AS TaxPositionId
	, '' AS VatPosition
	,0 TaxPriority,tv.StartDate, tv.EndDate,pd4.[Value] AS TaxFlow ,t.TaxFlowId
	,'' AS VariableName
	,CAST(0 AS BIT) AS IslookUp,0 AS FormulaPriority
	,'' AS [VariableType],0 AS VariableTypeId
	,'' as [UnitType], 0 AS  UnitTypeId
	,NULL FormulaDefination,NULL MinValue, NULL MaxValue
	,NULL as [LookUpRange],0 AS [LookupRangeTypeId],NULL AS LookUpGroupName,0 AS LookUpGroup,0 AS GroupDetailsId
	--,CAST(v.[Value]  AS varchar(500)) AS [Value]
	,'' AS [Value]
	,''   as [ValueRange]
	 ,CAST(0 AS bit) AS IsFormulaAvailable
	 ,0 as TaxMasterId
	 ,NULL AS DefaultValue
	FROM dbo.TaxMaster tm
	INNER JOIN dbo.Market m ON tm.MarketId = m.MarketId
	INNER JOIN dbo.CountryCode cc ON m.CountryCodeId = cc.CountryCodeId
	INNER JOIN dbo.TaxVersion tv ON tm.TaxMasterId = tv.TaxMasterId
	INNER JOIN dbo.Tax t ON tv.TaxVersionId = t.TaxVersionId
	LEFT JOIN dbo.ParameterDetails pd4 ON pd4.ParameterId = t.TaxFlowId AND pd4.ParameterGroupId=1
	INNER JOIN dbo.Variable v ON t.TaxId = v.TaxId  AND v.VariableTypeId IN(8,9)
	LEFT JOIN dbo.Formula f ON v.VariableId = f.VariableId
	WHERE cc.CountryCode = @CountryCode AND m.TaxTerritory= @TaxTerritory AND @PriceDate BETWEEN tv.StartDate AND tv.EndDate  AND f.FormulaDefination IS  NULL

	AND tm.TaxName NOT IN(
	 SELECT tm.TaxName
	FROM dbo.TaxMaster tm
	INNER JOIN dbo.Market m ON tm.MarketId = m.MarketId
	INNER JOIN dbo.CountryCode cc ON m.CountryCodeId = cc.CountryCodeId
	INNER JOIN dbo.TaxVersion tv ON tm.TaxMasterId = tv.TaxMasterId
	INNER JOIN dbo.Tax t ON tv.TaxVersionId = t.TaxVersionId
	LEFT JOIN dbo.ParameterDetails pd4 ON pd4.ParameterId = t.TaxFlowId AND pd4.ParameterGroupId=1
	INNER JOIN dbo.Variable v ON t.TaxId = v.TaxId  AND v.VariableTypeId IN(8,9)
	LEFT JOIN dbo.Formula f ON v.VariableId = f.VariableId
	WHERE cc.CountryCode = @CountryCode AND m.TaxTerritory= @TaxTerritory AND @PriceDate BETWEEN tv.StartDate AND tv.EndDate  AND f.FormulaDefination IS NOT NULL)
	GROUP BY tm.TaxName,tv.StartDate, tv.EndDate,pd4.[Value]  ,t.TaxFlowId
	) CTE

	ORDER BY  CTE.TaxPriority ASC,CTE.LookUpGroup ASC , CTE.FormulaPriority ASC

END
