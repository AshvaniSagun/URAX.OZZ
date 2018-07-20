DECLARE @CountryCodeId int 
DECLARE @currencyId int 

SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'AE')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'AED')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='AE')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'AE', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'AL')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'ALL')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='AL')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'AL', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'AM')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'AMD')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='AM')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'AM', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'AN')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'SEK')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='AN')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'AN', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'AO')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'AOA')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='AO')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'AO', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'AR')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'ARS')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='AR')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'AR', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'AT')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'SEK')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='AT')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'AT', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'AU')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'AUD')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='AU')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'AU', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'AZ')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'AZN')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='AZ')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'AZ', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'BA')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'BAM')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='BA')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'BA', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'BD')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'BDT')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='BD')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'BD', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'BE-BRU')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'SEK')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='BE-BRU')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'BE-BRU', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'BE-WAL')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'SEK')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='BE-WAL')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'BE-WAL', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'BE-VLG')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'SEK')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='BE-VLG')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'BE-VLG', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'CA')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'CAD')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='CA')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'CA', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'CA-NL')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'CAD')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='CA-NL')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'CA-NL', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'CA-NS')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'CAD')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='CA-NS')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'CA-NS', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'BG')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'BGN')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='BG')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'BG', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'BH')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'BHD')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='BH')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'BH', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'BN')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'BOB')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='BN')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'BN', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'BO')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'BRL')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='BO')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'BO', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'BR')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'BND')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='BR')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'BR', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'BY')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'BYR')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='BY')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'BY', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'CA-ON')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'CAD')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='CA-ON')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'CA-ON', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'CA-NB')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'CAD')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='CA-NB')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'CA-NB', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'CA-QC')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'CAD')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='CA-QC')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'CA-QC', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'LU')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'SEK')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='LU')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'LU', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'CA-MB')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'CAD')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='CA-MB')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'CA-MB', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'CA-SK')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'CAD')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='CA-SK')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'CA-SK', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'CA-AB')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'CAD')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='CA-AB')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'CA-AB', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'CA-BC')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'CAD')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='CA-BC')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'CA-BC', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'BE')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'SEK')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='BE')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'BE', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'CH')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'CHF')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='CH')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'CH', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'CL')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'CLP')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='CL')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'CL', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'CN')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'CNY')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='CN')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'CN', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'CO')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'COU')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='CO')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'CO', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'CR')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'CRC')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='CR')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'CR', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'CS')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'SEK')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='CS')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'CS', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'CY')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'SEK')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='CY')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'CY', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'CZ')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'CZK')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='CZ')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'CZ', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'DE')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'EUR')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='DE')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'DE', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'DK')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'DKK')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='DK')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'DK', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'DO')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'DOP')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='DO')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'DO', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'DZ')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'DZD')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='DZ')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'DZ', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'EC')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'SEK')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='EC')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'EC', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'EE')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'SEK')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='EE')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'EE', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'EG')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'EGP')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='EG')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'EG', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'ES')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'EUR')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='ES')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'ES', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'FI')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'EUR')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='FI')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'FI', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'FJ')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'FJD')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='FJ')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'FJ', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'FR')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'SEK')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='FR')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'FR', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'GB')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'GBP')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='GB')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'GB', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'GE')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'GEL')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='GE')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'GE', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'GH')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'GHS')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='GH')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'GH', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'GR')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'SEK')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='GR')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'GR', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'GT')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'SEK')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='GT')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'GT', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'HK')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'HKD')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='HK')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'HK', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'HN')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'HNL')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='HN')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'HN', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'HR')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'HRK')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='HR')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'HR', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'HT')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'HTG')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='HT')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'HT', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'HU')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'HUF')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='HU')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'HU', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'ID')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'IDR')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='ID')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'ID', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'IE')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'EURO')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='IE')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'IE', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'IL')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'ILS')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='IL')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'IL', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'IN')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'INR')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='IN')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'IN', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'IS')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'ISK')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='IS')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'IS', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'IT')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'EUR')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='IT')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'IT', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'JM')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'JMD')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='JM')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'JM', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'JO')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'JOD')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='JO')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'JO', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'JP')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'JPY')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='JP')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'JP', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'KE')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'KES')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='KE')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'KE', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'KR')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'KRW')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='KR')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'KR', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'KW')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'KWD')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='KW')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'KW', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'KZ')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'KZT')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='KZ')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'KZ', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'LB')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'LBP')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='LB')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'LB', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'LK')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'LKR')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='LK')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'LK', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'LT')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'EUR')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='LT')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'LT', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'LV')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'EUR')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='LV')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'LV', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'LY')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'LYD')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='LY')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'LY', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'M2')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = '')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='M2')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'M2', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'M4')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = '')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='M4')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'M4', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'MA')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'MAD')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='MA')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'MA', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'MD')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'MDL')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='MD')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'MD', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'ME')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'EUR')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='ME')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'ME', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'MK')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'MKD')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='MK')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'MK', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'MM')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'SEK')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='MM')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'MM', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'MT')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'EURO')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='MT')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'MT', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'MX')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'MXN')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='MX')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'MX', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'MY')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'MYR')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='MY')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'MY', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'MZ')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'MZN')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='MZ')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'MZ', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'NA')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'NAD')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='NA')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'NA', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'NI')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'NIO')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='NI')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'NI', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'NL')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'EURO')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='NL')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'NL', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'NO')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'NOK')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='NO')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'NO', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'NZ')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'NZD')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='NZ')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'NZ', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'OM')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'OMR')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='OM')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'OM', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'PA')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'PAB')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='PA')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'PA', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'PE')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'PEN')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='PE')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'PE', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'PH')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'PHP')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='PH')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'PH', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'PL')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'PLN')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='PL')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'PL', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'PR')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'USD')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='PR')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'PR', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'PT')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'EUR')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='PT')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'PT', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'PY')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'PYG')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='PY')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'PY', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'QA')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'QAR')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='QA')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'QA', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'RO')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'RON')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='RO')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'RO', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'RS')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'RSD')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='RS')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'RS', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'RU')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'RUB')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='RU')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'RU', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'SA')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'SAR')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='SA')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'SA', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'SE')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'SEK')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='SE')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'SE', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'SG')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'SGD')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='SG')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'SG', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'SI')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'EUR')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='SI')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'SI', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'SK')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'EUR')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='SK')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'SK', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'SV')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'USD')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='SV')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'SV', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'SY')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'SYP')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='SY')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'SY', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'TH')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'THB')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='TH')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'TH', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'TN')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'TND')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='TN')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'TN', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'TR')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'TRY')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='TR')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'TR', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'TT')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'TTD')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='TT')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'TT', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'TW')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'TWD')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='TW')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'TW', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'UA')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'UAH')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='UA')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'UA', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'US')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'USD')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='US')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'US', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'UY')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'USD')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='UY')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'UY', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'VN')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'USD')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='VN')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'VN', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'YE')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'USD')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='YE')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'YE', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'YU')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'USD')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='YU')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'YU', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'ZA')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'USD')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='ZA')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'ZA', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'ZM')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'USD')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='ZM')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'ZM', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'ZW')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'USD')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='ZW')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'ZW', 0)
END
SET @CountryCodeId = (SELECT  cc.CountryCodeId  FROM dbo.CountryCode cc WHERE cc.CountryCode = 'ZZ')
SET @currencyId = (SELECT  cd.CurrencyId  FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode = 'USD')
IF(@CountryCodeId IS NOT NULL)
BEGIN
IF NOT EXISTS(SELECT 1 FROM Market m WHERE m.CountryCodeId=@CountryCodeId AND m.TaxTerritory='ZZ')
INSERT dbo.Market (CountryCodeId,TaxPartnerGroup,currencyId,IsActive,CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, SubdivisionCode,TaxTerritory, FeatureLevelTax)
VALUES (@CountryCodeId,NULL,@currencyId,  0,'ADMIN',GETUTCDATE(), 'ADMIN', GETUTCDATE(),NULL ,'ZZ', 0)
END
