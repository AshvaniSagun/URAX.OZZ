
DECLARE	 @CountryCodeId INT
DECLARE	 @Admin  VARCHAR(50)
SET @Admin='Admin'
SET @CountryCodeId=(SELECT cc.CountryCodeId FROM dbo.CountryCode cc WHERE cc.CountryCode='DK')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS (SELECT 1 FROM dbo.TaxTerritoryUnitConversion ttuc  WHERE ttuc.CountryCodeId=@CountryCodeId)
INSERT dbo.TaxTerritoryUnitConversion(CountryCodeId,UnitConversionId,CreatedBy, CreatedOn, UpdatedBy,UpdatedOn)
VALUES(@CountryCodeId,2,@Admin,getutcdate(),@Admin,getutcdate())
END
SET @CountryCodeId=(SELECT cc.CountryCodeId FROM dbo.CountryCode cc WHERE cc.CountryCode='IE')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS (SELECT 1 FROM dbo.TaxTerritoryUnitConversion ttuc  WHERE ttuc.CountryCodeId=@CountryCodeId)
INSERT dbo.TaxTerritoryUnitConversion(CountryCodeId,UnitConversionId,CreatedBy, CreatedOn, UpdatedBy,UpdatedOn)
VALUES(@CountryCodeId,3,@Admin,getutcdate(),@Admin,getutcdate())
END
SET @CountryCodeId=(SELECT cc.CountryCodeId FROM dbo.CountryCode cc WHERE cc.CountryCode='US')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS (SELECT 1 FROM dbo.TaxTerritoryUnitConversion ttuc  WHERE ttuc.CountryCodeId=@CountryCodeId)
INSERT dbo.TaxTerritoryUnitConversion(CountryCodeId,UnitConversionId,CreatedBy, CreatedOn, UpdatedBy,UpdatedOn)
VALUES(@CountryCodeId,5,@Admin,getutcdate(),@Admin,getutcdate())
END