IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='AED' AND cd.CountryName=N'AED-UAE Dirham')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(1,'AED','UAE Dirham' , 'AED-UAE Dirham',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='UAE Dirham'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='AFN' AND cd.CountryName=N'AFN-Afghani')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(2,'AFN','Afghani' , 'AFN-Afghani',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Afghani'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='ALL' AND cd.CountryName=N'ALL-Lek')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(3,'ALL','Lek' , 'ALL-Lek',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Lek'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='AMD' AND cd.CountryName=N'AMD-Armenian Dram')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(4,'AMD','Armenian Dram' , 'AMD-Armenian Dram',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Armenian Dram'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='ANG' AND cd.CountryName=N'ANG-Netherlands Antillean Guilder')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(5,'ANG','Netherlands Antillean Guilder' , 'ANG-Netherlands Antillean Guilder',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Netherlands Antillean Guilder'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='ANG' AND cd.CountryName=N'ANG-Netherlands Antillean Guilder')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(6,'ANG','Netherlands Antillean Guilder' , 'ANG-Netherlands Antillean Guilder',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Netherlands Antillean Guilder'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='AOA' AND cd.CountryName=N'AOA-Kwanza')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(7,'AOA','Kwanza' , 'AOA-Kwanza',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Kwanza'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='ARS' AND cd.CountryName=N'ARS-Argentine Peso')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(8,'ARS','Argentine Peso' , 'ARS-Argentine Peso',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Argentine Peso'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='AUD' AND cd.CountryName=N'AUD-Australian Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(9,'AUD','Australian Dollar' , 'AUD-Australian Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Australian Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='AUD' AND cd.CountryName=N'AUD-Australian Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(10,'AUD','Australian Dollar' , 'AUD-Australian Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Australian Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='AUD' AND cd.CountryName=N'AUD-Australian Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(11,'AUD','Australian Dollar' , 'AUD-Australian Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Australian Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='AUD' AND cd.CountryName=N'AUD-Australian Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(12,'AUD','Australian Dollar' , 'AUD-Australian Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Australian Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='AUD' AND cd.CountryName=N'AUD-Australian Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(13,'AUD','Australian Dollar' , 'AUD-Australian Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Australian Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='AUD' AND cd.CountryName=N'AUD-Australian Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(14,'AUD','Australian Dollar' , 'AUD-Australian Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Australian Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='AUD' AND cd.CountryName=N'AUD-Australian Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(15,'AUD','Australian Dollar' , 'AUD-Australian Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Australian Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='AUD' AND cd.CountryName=N'AUD-Australian Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(16,'AUD','Australian Dollar' , 'AUD-Australian Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Australian Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='AWG' AND cd.CountryName=N'AWG-Aruban Florin')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(17,'AWG','Aruban Florin' , 'AWG-Aruban Florin',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Aruban Florin'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='AZN' AND cd.CountryName=N'AZN-Azerbaijanian Manat')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(18,'AZN','Azerbaijanian Manat' , 'AZN-Azerbaijanian Manat',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Azerbaijanian Manat'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='BAM' AND cd.CountryName=N'BAM-Convertible Mark')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(19,'BAM','Convertible Mark' , 'BAM-Convertible Mark',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Convertible Mark'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='BBD' AND cd.CountryName=N'BBD-Barbados Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(20,'BBD','Barbados Dollar' , 'BBD-Barbados Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Barbados Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='BDT' AND cd.CountryName=N'BDT-Taka')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(21,'BDT','Taka' , 'BDT-Taka',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Taka'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='BGN' AND cd.CountryName=N'BGN-Bulgarian Lev')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(22,'BGN','Bulgarian Lev' , 'BGN-Bulgarian Lev',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Bulgarian Lev'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='BHD' AND cd.CountryName=N'BHD-Bahraini Dinar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(23,'BHD','Bahraini Dinar' , 'BHD-Bahraini Dinar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Bahraini Dinar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='BIF' AND cd.CountryName=N'BIF-Burundi Franc')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(24,'BIF','Burundi Franc' , 'BIF-Burundi Franc',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Burundi Franc'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='BMD' AND cd.CountryName=N'BMD-Bermudian Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(25,'BMD','Bermudian Dollar' , 'BMD-Bermudian Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Bermudian Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='BND' AND cd.CountryName=N'BND-Brunei Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(26,'BND','Brunei Dollar' , 'BND-Brunei Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Brunei Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='BOB' AND cd.CountryName=N'BOB-Boliviano')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(27,'BOB','Boliviano' , 'BOB-Boliviano',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Boliviano'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='BOV' AND cd.CountryName=N'BOV-Mvdol')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(28,'BOV','Mvdol' , 'BOV-Mvdol',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Mvdol'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='BRL' AND cd.CountryName=N'BRL-Brazilian Real')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(29,'BRL','Brazilian Real' , 'BRL-Brazilian Real',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Brazilian Real'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='BSD' AND cd.CountryName=N'BSD-Bahamian Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(30,'BSD','Bahamian Dollar' , 'BSD-Bahamian Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Bahamian Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='BTN' AND cd.CountryName=N'BTN-Ngultrum')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(31,'BTN','Ngultrum' , 'BTN-Ngultrum',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Ngultrum'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='BWP' AND cd.CountryName=N'BWP-Pula')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(32,'BWP','Pula' , 'BWP-Pula',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Pula'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='BYR' AND cd.CountryName=N'BYR-Belarussian Ruble')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(33,'BYR','Belarussian Ruble' , 'BYR-Belarussian Ruble',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Belarussian Ruble'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='BZD' AND cd.CountryName=N'BZD-Belize Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(34,'BZD','Belize Dollar' , 'BZD-Belize Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Belize Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='CAD' AND cd.CountryName=N'CAD-Canadian Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(35,'CAD','Canadian Dollar' , 'CAD-Canadian Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Canadian Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='CDF' AND cd.CountryName=N'CDF-Congolese Franc')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(36,'CDF','Congolese Franc' , 'CDF-Congolese Franc',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Congolese Franc'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='CHE' AND cd.CountryName=N'CHE-WIR Euro')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(37,'CHE','WIR Euro' , 'CHE-WIR Euro',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='WIR Euro'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='CHF' AND cd.CountryName=N'CHF-Swiss Franc')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(38,'CHF','Swiss Franc' , 'CHF-Swiss Franc',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Swiss Franc'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='CHF' AND cd.CountryName=N'CHF-Swiss Franc')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(39,'CHF','Swiss Franc' , 'CHF-Swiss Franc',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Swiss Franc'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='CHW' AND cd.CountryName=N'CHW-WIR Franc')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(40,'CHW','WIR Franc' , 'CHW-WIR Franc',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='WIR Franc'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='CLF' AND cd.CountryName=N'CLF-Unidad de Fomento')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(41,'CLF','Unidad de Fomento' , 'CLF-Unidad de Fomento',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Unidad de Fomento'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='CLP' AND cd.CountryName=N'CLP-Chilean Peso')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(42,'CLP','Chilean Peso' , 'CLP-Chilean Peso',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Chilean Peso'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='CNY' AND cd.CountryName=N'CNY-Yuan Renminbi')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(43,'CNY','Yuan Renminbi' , 'CNY-Yuan Renminbi',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Yuan Renminbi'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='COP' AND cd.CountryName=N'COP-Colombian Peso')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(44,'COP','Colombian Peso' , 'COP-Colombian Peso',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Colombian Peso'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='COU' AND cd.CountryName=N'COU-Unidad de Valor Real')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(45,'COU','Unidad de Valor Real' , 'COU-Unidad de Valor Real',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Unidad de Valor Real'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='CRC' AND cd.CountryName=N'CRC-Costa Rican Colon')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(46,'CRC','Costa Rican Colon' , 'CRC-Costa Rican Colon',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Costa Rican Colon'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='CUC' AND cd.CountryName=N'CUC-Peso Convertible')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(47,'CUC','Peso Convertible' , 'CUC-Peso Convertible',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Peso Convertible'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='CUP' AND cd.CountryName=N'CUP-Cuban Peso')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(48,'CUP','Cuban Peso' , 'CUP-Cuban Peso',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Cuban Peso'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='CVE' AND cd.CountryName=N'CVE-Cabo Verde Escudo')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(49,'CVE','Cabo Verde Escudo' , 'CVE-Cabo Verde Escudo',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Cabo Verde Escudo'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='CZK' AND cd.CountryName=N'CZK-Czech Koruna')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(50,'CZK','Czech Koruna' , 'CZK-Czech Koruna',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Czech Koruna'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='DJF' AND cd.CountryName=N'DJF-Djibouti Franc')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(51,'DJF','Djibouti Franc' , 'DJF-Djibouti Franc',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Djibouti Franc'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='DKK' AND cd.CountryName=N'DKK-Danish Krone')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(52,'DKK','Danish Krone' , 'DKK-Danish Krone',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Danish Krone'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='DKK' AND cd.CountryName=N'DKK-Danish Krone')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(53,'DKK','Danish Krone' , 'DKK-Danish Krone',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Danish Krone'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='DKK' AND cd.CountryName=N'DKK-Danish Krone')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(54,'DKK','Danish Krone' , 'DKK-Danish Krone',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Danish Krone'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='DOP' AND cd.CountryName=N'DOP-Dominican Peso')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(55,'DOP','Dominican Peso' , 'DOP-Dominican Peso',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Dominican Peso'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='DZD' AND cd.CountryName=N'DZD-Algerian Dinar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(56,'DZD','Algerian Dinar' , 'DZD-Algerian Dinar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Algerian Dinar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='EGP' AND cd.CountryName=N'EGP-Egyptian Pound')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(57,'EGP','Egyptian Pound' , 'EGP-Egyptian Pound',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Egyptian Pound'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='ERN' AND cd.CountryName=N'ERN-Nakfa')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(58,'ERN','Nakfa' , 'ERN-Nakfa',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Nakfa'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='ETB' AND cd.CountryName=N'ETB-Ethiopian Birr')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(59,'ETB','Ethiopian Birr' , 'ETB-Ethiopian Birr',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Ethiopian Birr'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='EUR' AND cd.CountryName=N'EUR-Euro')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(60,'EUR','Euro' , 'EUR-Euro',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Euro'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='EUR' AND cd.CountryName=N'EUR-Euro')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(61,'EUR','Euro' , 'EUR-Euro',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Euro'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='EUR' AND cd.CountryName=N'EUR-Euro')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(62,'EUR','Euro' , 'EUR-Euro',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Euro'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='EUR' AND cd.CountryName=N'EUR-Euro')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(63,'EUR','Euro' , 'EUR-Euro',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Euro'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='EUR' AND cd.CountryName=N'EUR-Euro')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(64,'EUR','Euro' , 'EUR-Euro',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Euro'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='EUR' AND cd.CountryName=N'EUR-Euro')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(65,'EUR','Euro' , 'EUR-Euro',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Euro'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='EUR' AND cd.CountryName=N'EUR-Euro')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(66,'EUR','Euro' , 'EUR-Euro',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Euro'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='EUR' AND cd.CountryName=N'EUR-Euro')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(67,'EUR','Euro' , 'EUR-Euro',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Euro'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='EUR' AND cd.CountryName=N'EUR-Euro')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(68,'EUR','Euro' , 'EUR-Euro',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Euro'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='EUR' AND cd.CountryName=N'EUR-Euro')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(69,'EUR','Euro' , 'EUR-Euro',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Euro'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='EUR' AND cd.CountryName=N'EUR-Euro')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(70,'EUR','Euro' , 'EUR-Euro',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Euro'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='EUR' AND cd.CountryName=N'EUR-Euro')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(71,'EUR','Euro' , 'EUR-Euro',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Euro'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='EUR' AND cd.CountryName=N'EUR-Euro')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(72,'EUR','Euro' , 'EUR-Euro',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Euro'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='EUR' AND cd.CountryName=N'EUR-Euro')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(73,'EUR','Euro' , 'EUR-Euro',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Euro'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='EUR' AND cd.CountryName=N'EUR-Euro')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(74,'EUR','Euro' , 'EUR-Euro',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Euro'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='EUR' AND cd.CountryName=N'EUR-Euro')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(75,'EUR','Euro' , 'EUR-Euro',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Euro'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='EUR' AND cd.CountryName=N'EUR-Euro')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(76,'EUR','Euro' , 'EUR-Euro',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Euro'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='EUR' AND cd.CountryName=N'EUR-Euro')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(77,'EUR','Euro' , 'EUR-Euro',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Euro'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='EUR' AND cd.CountryName=N'EUR-Euro')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(78,'EUR','Euro' , 'EUR-Euro',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Euro'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='EUR' AND cd.CountryName=N'EUR-Euro')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(79,'EUR','Euro' , 'EUR-Euro',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Euro'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='EUR' AND cd.CountryName=N'EUR-Euro')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(80,'EUR','Euro' , 'EUR-Euro',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Euro'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='EUR' AND cd.CountryName=N'EUR-Euro')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(81,'EUR','Euro' , 'EUR-Euro',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Euro'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='EUR' AND cd.CountryName=N'EUR-Euro')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(82,'EUR','Euro' , 'EUR-Euro',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Euro'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='EUR' AND cd.CountryName=N'EUR-Euro')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(83,'EUR','Euro' , 'EUR-Euro',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Euro'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='EUR' AND cd.CountryName=N'EUR-Euro')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(84,'EUR','Euro' , 'EUR-Euro',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Euro'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='EUR' AND cd.CountryName=N'EUR-Euro')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(85,'EUR','Euro' , 'EUR-Euro',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Euro'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='EUR' AND cd.CountryName=N'EUR-Euro')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(86,'EUR','Euro' , 'EUR-Euro',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Euro'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='EUR' AND cd.CountryName=N'EUR-Euro')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(87,'EUR','Euro' , 'EUR-Euro',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Euro'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='EUR' AND cd.CountryName=N'EUR-Euro')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(88,'EUR','Euro' , 'EUR-Euro',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Euro'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='EUR' AND cd.CountryName=N'EUR-Euro')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(89,'EUR','Euro' , 'EUR-Euro',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Euro'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='EUR' AND cd.CountryName=N'EUR-Euro')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(90,'EUR','Euro' , 'EUR-Euro',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Euro'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='EUR' AND cd.CountryName=N'EUR-Euro')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(91,'EUR','Euro' , 'EUR-Euro',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Euro'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='EUR' AND cd.CountryName=N'EUR-Euro')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(92,'EUR','Euro' , 'EUR-Euro',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Euro'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='EUR' AND cd.CountryName=N'EUR-Euro')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(93,'EUR','Euro' , 'EUR-Euro',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Euro'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='FJD' AND cd.CountryName=N'FJD-Fiji Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(94,'FJD','Fiji Dollar' , 'FJD-Fiji Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Fiji Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='FKP' AND cd.CountryName=N'FKP-Falkland Islands Pound')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(95,'FKP','Falkland Islands Pound' , 'FKP-Falkland Islands Pound',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Falkland Islands Pound'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='GBP' AND cd.CountryName=N'GBP-Pound Sterling')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(96,'GBP','Pound Sterling' , 'GBP-Pound Sterling',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Pound Sterling'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='GBP' AND cd.CountryName=N'GBP-Pound Sterling')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(97,'GBP','Pound Sterling' , 'GBP-Pound Sterling',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Pound Sterling'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='GBP' AND cd.CountryName=N'GBP-Pound Sterling')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(98,'GBP','Pound Sterling' , 'GBP-Pound Sterling',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Pound Sterling'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='GBP' AND cd.CountryName=N'GBP-Pound Sterling')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(99,'GBP','Pound Sterling' , 'GBP-Pound Sterling',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Pound Sterling'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='GEL' AND cd.CountryName=N'GEL-Lari')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(100,'GEL','Lari' , 'GEL-Lari',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Lari'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='GHS' AND cd.CountryName=N'GHS-Ghana Cedi')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(101,'GHS','Ghana Cedi' , 'GHS-Ghana Cedi',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Ghana Cedi'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='GIP' AND cd.CountryName=N'GIP-Gibraltar Pound')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(102,'GIP','Gibraltar Pound' , 'GIP-Gibraltar Pound',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Gibraltar Pound'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='GMD' AND cd.CountryName=N'GMD-Dalasi')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(103,'GMD','Dalasi' , 'GMD-Dalasi',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Dalasi'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='GNF' AND cd.CountryName=N'GNF-Guinea Franc')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(104,'GNF','Guinea Franc' , 'GNF-Guinea Franc',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Guinea Franc'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='GTQ' AND cd.CountryName=N'GTQ-Quetzal')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(105,'GTQ','Quetzal' , 'GTQ-Quetzal',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Quetzal'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='GYD' AND cd.CountryName=N'GYD-Guyana Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(106,'GYD','Guyana Dollar' , 'GYD-Guyana Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Guyana Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='HKD' AND cd.CountryName=N'HKD-Hong Kong Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(107,'HKD','Hong Kong Dollar' , 'HKD-Hong Kong Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Hong Kong Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='HNL' AND cd.CountryName=N'HNL-Lempira')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(108,'HNL','Lempira' , 'HNL-Lempira',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Lempira'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='HRK' AND cd.CountryName=N'HRK-Kuna')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(109,'HRK','Kuna' , 'HRK-Kuna',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Kuna'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='HTG' AND cd.CountryName=N'HTG-Gourde')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(110,'HTG','Gourde' , 'HTG-Gourde',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Gourde'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='HUF' AND cd.CountryName=N'HUF-Forint')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(111,'HUF','Forint' , 'HUF-Forint',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Forint'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='IDR' AND cd.CountryName=N'IDR-Rupiah')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(112,'IDR','Rupiah' , 'IDR-Rupiah',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Rupiah'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='ILS' AND cd.CountryName=N'ILS-New Israeli Sheqel')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(113,'ILS','New Israeli Sheqel' , 'ILS-New Israeli Sheqel',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='New Israeli Sheqel'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='INR' AND cd.CountryName=N'INR-Indian Rupee')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(114,'INR','Indian Rupee' , 'INR-Indian Rupee',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Indian Rupee'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='INR' AND cd.CountryName=N'INR-Indian Rupee')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(115,'INR','Indian Rupee' , 'INR-Indian Rupee',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Indian Rupee'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='IQD' AND cd.CountryName=N'IQD-Iraqi Dinar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(116,'IQD','Iraqi Dinar' , 'IQD-Iraqi Dinar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Iraqi Dinar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='IRR' AND cd.CountryName=N'IRR-Iranian Rial')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(117,'IRR','Iranian Rial' , 'IRR-Iranian Rial',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Iranian Rial'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='ISK' AND cd.CountryName=N'ISK-Iceland Krona')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(118,'ISK','Iceland Krona' , 'ISK-Iceland Krona',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Iceland Krona'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='JMD' AND cd.CountryName=N'JMD-Jamaican Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(119,'JMD','Jamaican Dollar' , 'JMD-Jamaican Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Jamaican Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='JOD' AND cd.CountryName=N'JOD-Jordanian Dinar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(120,'JOD','Jordanian Dinar' , 'JOD-Jordanian Dinar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Jordanian Dinar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='JPY' AND cd.CountryName=N'JPY-Yen')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(121,'JPY','Yen' , 'JPY-Yen',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Yen'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='KES' AND cd.CountryName=N'KES-Kenyan Shilling')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(122,'KES','Kenyan Shilling' , 'KES-Kenyan Shilling',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Kenyan Shilling'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='KGS' AND cd.CountryName=N'KGS-Som')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(123,'KGS','Som' , 'KGS-Som',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Som'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='KHR' AND cd.CountryName=N'KHR-Riel')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(124,'KHR','Riel' , 'KHR-Riel',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Riel'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='KMF' AND cd.CountryName=N'KMF-Comoro Franc')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(125,'KMF','Comoro Franc' , 'KMF-Comoro Franc',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Comoro Franc'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='KPW' AND cd.CountryName=N'KPW-North Korean Won')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(126,'KPW','North Korean Won' , 'KPW-North Korean Won',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='North Korean Won'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='KRW' AND cd.CountryName=N'KRW-Won')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(127,'KRW','Won' , 'KRW-Won',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Won'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='KWD' AND cd.CountryName=N'KWD-Kuwaiti Dinar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(128,'KWD','Kuwaiti Dinar' , 'KWD-Kuwaiti Dinar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Kuwaiti Dinar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='KYD' AND cd.CountryName=N'KYD-Cayman Islands Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(129,'KYD','Cayman Islands Dollar' , 'KYD-Cayman Islands Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Cayman Islands Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='KZT' AND cd.CountryName=N'KZT-Tenge')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(130,'KZT','Tenge' , 'KZT-Tenge',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Tenge'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='LAK' AND cd.CountryName=N'LAK-Kip')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(131,'LAK','Kip' , 'LAK-Kip',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Kip'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='LBP' AND cd.CountryName=N'LBP-Lebanese Pound')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(132,'LBP','Lebanese Pound' , 'LBP-Lebanese Pound',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Lebanese Pound'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='LKR' AND cd.CountryName=N'LKR-Sri Lanka Rupee')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(133,'LKR','Sri Lanka Rupee' , 'LKR-Sri Lanka Rupee',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Sri Lanka Rupee'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='LRD' AND cd.CountryName=N'LRD-Liberian Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(134,'LRD','Liberian Dollar' , 'LRD-Liberian Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Liberian Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='LSL' AND cd.CountryName=N'LSL-Loti')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(135,'LSL','Loti' , 'LSL-Loti',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Loti'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='LYD' AND cd.CountryName=N'LYD-Libyan Dinar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(136,'LYD','Libyan Dinar' , 'LYD-Libyan Dinar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Libyan Dinar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='MAD' AND cd.CountryName=N'MAD-Moroccan Dirham')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(137,'MAD','Moroccan Dirham' , 'MAD-Moroccan Dirham',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Moroccan Dirham'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='MAD' AND cd.CountryName=N'MAD-Moroccan Dirham')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(138,'MAD','Moroccan Dirham' , 'MAD-Moroccan Dirham',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Moroccan Dirham'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='MDL' AND cd.CountryName=N'MDL-Moldovan Leu')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(139,'MDL','Moldovan Leu' , 'MDL-Moldovan Leu',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Moldovan Leu'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='MGA' AND cd.CountryName=N'MGA-Malagasy Ariary')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(140,'MGA','Malagasy Ariary' , 'MGA-Malagasy Ariary',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Malagasy Ariary'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='MKD' AND cd.CountryName=N'MKD-Denar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(141,'MKD','Denar' , 'MKD-Denar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Denar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='MMK' AND cd.CountryName=N'MMK-Kyat')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(142,'MMK','Kyat' , 'MMK-Kyat',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Kyat'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='MNT' AND cd.CountryName=N'MNT-Tugrik')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(143,'MNT','Tugrik' , 'MNT-Tugrik',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Tugrik'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='MOP' AND cd.CountryName=N'MOP-Pataca')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(144,'MOP','Pataca' , 'MOP-Pataca',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Pataca'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='MRO' AND cd.CountryName=N'MRO-Ouguiya')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(145,'MRO','Ouguiya' , 'MRO-Ouguiya',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Ouguiya'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='MUR' AND cd.CountryName=N'MUR-Mauritius Rupee')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(146,'MUR','Mauritius Rupee' , 'MUR-Mauritius Rupee',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Mauritius Rupee'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='MVR' AND cd.CountryName=N'MVR-Rufiyaa')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(147,'MVR','Rufiyaa' , 'MVR-Rufiyaa',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Rufiyaa'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='MWK' AND cd.CountryName=N'MWK-Kwacha')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(148,'MWK','Kwacha' , 'MWK-Kwacha',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Kwacha'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='MXN' AND cd.CountryName=N'MXN-Mexican Peso')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(149,'MXN','Mexican Peso' , 'MXN-Mexican Peso',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Mexican Peso'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='MXV' AND cd.CountryName=N'MXV-Mexican Unidad de Inversion (UDI)')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(150,'MXV','Mexican Unidad de Inversion (UDI)' , 'MXV-Mexican Unidad de Inversion (UDI)',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Mexican Unidad de Inversion (UDI)'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='MYR' AND cd.CountryName=N'MYR-Malaysian Ringgit')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(151,'MYR','Malaysian Ringgit' , 'MYR-Malaysian Ringgit',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Malaysian Ringgit'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='MZN' AND cd.CountryName=N'MZN-Mozambique Metical')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(152,'MZN','Mozambique Metical' , 'MZN-Mozambique Metical',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Mozambique Metical'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='NAD' AND cd.CountryName=N'NAD-Namibia Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(153,'NAD','Namibia Dollar' , 'NAD-Namibia Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Namibia Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='NGN' AND cd.CountryName=N'NGN-Naira')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(154,'NGN','Naira' , 'NGN-Naira',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Naira'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='NIO' AND cd.CountryName=N'NIO-Cordoba Oro')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(155,'NIO','Cordoba Oro' , 'NIO-Cordoba Oro',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Cordoba Oro'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='NOK' AND cd.CountryName=N'NOK-Norwegian Krone')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(156,'NOK','Norwegian Krone' , 'NOK-Norwegian Krone',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Norwegian Krone'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='NOK' AND cd.CountryName=N'NOK-Norwegian Krone')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(157,'NOK','Norwegian Krone' , 'NOK-Norwegian Krone',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Norwegian Krone'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='NOK' AND cd.CountryName=N'NOK-Norwegian Krone')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(158,'NOK','Norwegian Krone' , 'NOK-Norwegian Krone',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Norwegian Krone'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='NPR' AND cd.CountryName=N'NPR-Nepalese Rupee')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(159,'NPR','Nepalese Rupee' , 'NPR-Nepalese Rupee',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Nepalese Rupee'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='NZD' AND cd.CountryName=N'NZD-New Zealand Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(160,'NZD','New Zealand Dollar' , 'NZD-New Zealand Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='New Zealand Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='NZD' AND cd.CountryName=N'NZD-New Zealand Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(161,'NZD','New Zealand Dollar' , 'NZD-New Zealand Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='New Zealand Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='NZD' AND cd.CountryName=N'NZD-New Zealand Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(162,'NZD','New Zealand Dollar' , 'NZD-New Zealand Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='New Zealand Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='NZD' AND cd.CountryName=N'NZD-New Zealand Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(163,'NZD','New Zealand Dollar' , 'NZD-New Zealand Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='New Zealand Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='NZD' AND cd.CountryName=N'NZD-New Zealand Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(164,'NZD','New Zealand Dollar' , 'NZD-New Zealand Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='New Zealand Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='OMR' AND cd.CountryName=N'OMR-Rial Omani')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(165,'OMR','Rial Omani' , 'OMR-Rial Omani',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Rial Omani'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='PAB' AND cd.CountryName=N'PAB-Balboa')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(166,'PAB','Balboa' , 'PAB-Balboa',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Balboa'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='PEN' AND cd.CountryName=N'PEN-Nuevo Sol')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(167,'PEN','Nuevo Sol' , 'PEN-Nuevo Sol',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Nuevo Sol'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='PGK' AND cd.CountryName=N'PGK-Kina')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(168,'PGK','Kina' , 'PGK-Kina',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Kina'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='PHP' AND cd.CountryName=N'PHP-Philippine Peso')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(169,'PHP','Philippine Peso' , 'PHP-Philippine Peso',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Philippine Peso'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='PKR' AND cd.CountryName=N'PKR-Pakistan Rupee')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(170,'PKR','Pakistan Rupee' , 'PKR-Pakistan Rupee',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Pakistan Rupee'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='PLN' AND cd.CountryName=N'PLN-Zloty')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(171,'PLN','Zloty' , 'PLN-Zloty',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Zloty'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='PYG' AND cd.CountryName=N'PYG-Guarani')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(172,'PYG','Guarani' , 'PYG-Guarani',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Guarani'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='QAR' AND cd.CountryName=N'QAR-Qatari Rial')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(173,'QAR','Qatari Rial' , 'QAR-Qatari Rial',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Qatari Rial'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='RON' AND cd.CountryName=N'RON-Romanian Leu')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(174,'RON','Romanian Leu' , 'RON-Romanian Leu',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Romanian Leu'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='RSD' AND cd.CountryName=N'RSD-Serbian Dinar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(175,'RSD','Serbian Dinar' , 'RSD-Serbian Dinar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Serbian Dinar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='RUB' AND cd.CountryName=N'RUB-Russian Ruble')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(176,'RUB','Russian Ruble' , 'RUB-Russian Ruble',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Russian Ruble'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='RWF' AND cd.CountryName=N'RWF-Rwanda Franc')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(177,'RWF','Rwanda Franc' , 'RWF-Rwanda Franc',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Rwanda Franc'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='SAR' AND cd.CountryName=N'SAR-Saudi Riyal')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(178,'SAR','Saudi Riyal' , 'SAR-Saudi Riyal',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Saudi Riyal'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='SBD' AND cd.CountryName=N'SBD-Solomon Islands Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(179,'SBD','Solomon Islands Dollar' , 'SBD-Solomon Islands Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Solomon Islands Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='SCR' AND cd.CountryName=N'SCR-Seychelles Rupee')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(180,'SCR','Seychelles Rupee' , 'SCR-Seychelles Rupee',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Seychelles Rupee'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='SDG' AND cd.CountryName=N'SDG-Sudanese Pound')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(181,'SDG','Sudanese Pound' , 'SDG-Sudanese Pound',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Sudanese Pound'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='SEK' AND cd.CountryName=N'SEK-Swedish Krona')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(182,'SEK','Swedish Krona' , 'SEK-Swedish Krona',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Swedish Krona'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='SGD' AND cd.CountryName=N'SGD-Singapore Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(183,'SGD','Singapore Dollar' , 'SGD-Singapore Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Singapore Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='SHP' AND cd.CountryName=N'SHP-Saint Helena Pound')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(184,'SHP','Saint Helena Pound' , 'SHP-Saint Helena Pound',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Saint Helena Pound'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='SLL' AND cd.CountryName=N'SLL-Leone')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(185,'SLL','Leone' , 'SLL-Leone',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Leone'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='SOS' AND cd.CountryName=N'SOS-Somali Shilling')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(186,'SOS','Somali Shilling' , 'SOS-Somali Shilling',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Somali Shilling'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='SRD' AND cd.CountryName=N'SRD-Surinam Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(187,'SRD','Surinam Dollar' , 'SRD-Surinam Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Surinam Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='SSP' AND cd.CountryName=N'SSP-South Sudanese Pound')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(188,'SSP','South Sudanese Pound' , 'SSP-South Sudanese Pound',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='South Sudanese Pound'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='STD' AND cd.CountryName=N'STD-Dobra')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(189,'STD','Dobra' , 'STD-Dobra',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Dobra'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='SVC' AND cd.CountryName=N'SVC-El Salvador Colon')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(190,'SVC','El Salvador Colon' , 'SVC-El Salvador Colon',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='El Salvador Colon'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='SYP' AND cd.CountryName=N'SYP-Syrian Pound')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(191,'SYP','Syrian Pound' , 'SYP-Syrian Pound',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Syrian Pound'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='SZL' AND cd.CountryName=N'SZL-Lilangeni')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(192,'SZL','Lilangeni' , 'SZL-Lilangeni',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Lilangeni'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='THB' AND cd.CountryName=N'THB-Baht')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(193,'THB','Baht' , 'THB-Baht',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Baht'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='TJS' AND cd.CountryName=N'TJS-Somoni')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(194,'TJS','Somoni' , 'TJS-Somoni',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Somoni'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='TMT' AND cd.CountryName=N'TMT-Turkmenistan New Manat')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(195,'TMT','Turkmenistan New Manat' , 'TMT-Turkmenistan New Manat',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Turkmenistan New Manat'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='TND' AND cd.CountryName=N'TND-Tunisian Dinar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(196,'TND','Tunisian Dinar' , 'TND-Tunisian Dinar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Tunisian Dinar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='TOP' AND cd.CountryName=N'TOP-Pa’anga')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(197,'TOP','Pa’anga' , 'TOP-Pa’anga',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Pa’anga'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='TRY' AND cd.CountryName=N'TRY-Turkish Lira')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(198,'TRY','Turkish Lira' , 'TRY-Turkish Lira',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Turkish Lira'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='TTD' AND cd.CountryName=N'TTD-Trinidad and Tobago Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(199,'TTD','Trinidad and Tobago Dollar' , 'TTD-Trinidad and Tobago Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Trinidad and Tobago Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='TWD' AND cd.CountryName=N'TWD-New Taiwan Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(200,'TWD','New Taiwan Dollar' , 'TWD-New Taiwan Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='New Taiwan Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='TZS' AND cd.CountryName=N'TZS-Tanzanian Shilling')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(201,'TZS','Tanzanian Shilling' , 'TZS-Tanzanian Shilling',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Tanzanian Shilling'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='UAH' AND cd.CountryName=N'UAH-Hryvnia')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(202,'UAH','Hryvnia' , 'UAH-Hryvnia',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Hryvnia'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='UGX' AND cd.CountryName=N'UGX-Uganda Shilling')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(203,'UGX','Uganda Shilling' , 'UGX-Uganda Shilling',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Uganda Shilling'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='USD' AND cd.CountryName=N'USD-US Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(204,'USD','US Dollar' , 'USD-US Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='US Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='USD' AND cd.CountryName=N'USD-US Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(205,'USD','US Dollar' , 'USD-US Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='US Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='USD' AND cd.CountryName=N'USD-US Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(206,'USD','US Dollar' , 'USD-US Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='US Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='USD' AND cd.CountryName=N'USD-US Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(207,'USD','US Dollar' , 'USD-US Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='US Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='USD' AND cd.CountryName=N'USD-US Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(208,'USD','US Dollar' , 'USD-US Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='US Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='USD' AND cd.CountryName=N'USD-US Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(209,'USD','US Dollar' , 'USD-US Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='US Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='USD' AND cd.CountryName=N'USD-US Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(210,'USD','US Dollar' , 'USD-US Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='US Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='USD' AND cd.CountryName=N'USD-US Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(211,'USD','US Dollar' , 'USD-US Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='US Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='USD' AND cd.CountryName=N'USD-US Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(212,'USD','US Dollar' , 'USD-US Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='US Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='USD' AND cd.CountryName=N'USD-US Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(213,'USD','US Dollar' , 'USD-US Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='US Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='USD' AND cd.CountryName=N'USD-US Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(214,'USD','US Dollar' , 'USD-US Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='US Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='USD' AND cd.CountryName=N'USD-US Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(215,'USD','US Dollar' , 'USD-US Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='US Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='USD' AND cd.CountryName=N'USD-US Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(216,'USD','US Dollar' , 'USD-US Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='US Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='USD' AND cd.CountryName=N'USD-US Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(217,'USD','US Dollar' , 'USD-US Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='US Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='USD' AND cd.CountryName=N'USD-US Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(218,'USD','US Dollar' , 'USD-US Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='US Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='USD' AND cd.CountryName=N'USD-US Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(219,'USD','US Dollar' , 'USD-US Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='US Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='USD' AND cd.CountryName=N'USD-US Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(220,'USD','US Dollar' , 'USD-US Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='US Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='USD' AND cd.CountryName=N'USD-US Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(221,'USD','US Dollar' , 'USD-US Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='US Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='USD' AND cd.CountryName=N'USD-US Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(222,'USD','US Dollar' , 'USD-US Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='US Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='USN' AND cd.CountryName=N'USN-US Dollar (Next day)')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(223,'USN','US Dollar (Next day)' , 'USN-US Dollar (Next day)',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='US Dollar (Next day)'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='UYI' AND cd.CountryName=N'UYI-Uruguay Peso en Unidades Indexadas (URUIURUI)')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(224,'UYI','Uruguay Peso en Unidades Indexadas (URUIURUI)' , 'UYI-Uruguay Peso en Unidades Indexadas (URUIURUI)',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Uruguay Peso en Unidades Indexadas (URUIURUI)'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='UYU' AND cd.CountryName=N'UYU-Peso Uruguayo')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(225,'UYU','Peso Uruguayo' , 'UYU-Peso Uruguayo',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Peso Uruguayo'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='UZS' AND cd.CountryName=N'UZS-Uzbekistan Sum')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(226,'UZS','Uzbekistan Sum' , 'UZS-Uzbekistan Sum',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Uzbekistan Sum'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='VEF' AND cd.CountryName=N'VEF-Bolivar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(227,'VEF','Bolivar' , 'VEF-Bolivar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Bolivar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='VND' AND cd.CountryName=N'VND-Dong')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(228,'VND','Dong' , 'VND-Dong',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Dong'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='VUV' AND cd.CountryName=N'VUV-Vatu')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(229,'VUV','Vatu' , 'VUV-Vatu',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Vatu'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='WST' AND cd.CountryName=N'WST-Tala')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(230,'WST','Tala' , 'WST-Tala',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Tala'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='XAF' AND cd.CountryName=N'XAF-CFA Franc BEAC')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(231,'XAF','CFA Franc BEAC' , 'XAF-CFA Franc BEAC',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='CFA Franc BEAC'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='XAF' AND cd.CountryName=N'XAF-CFA Franc BEAC')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(232,'XAF','CFA Franc BEAC' , 'XAF-CFA Franc BEAC',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='CFA Franc BEAC'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='XAF' AND cd.CountryName=N'XAF-CFA Franc BEAC')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(233,'XAF','CFA Franc BEAC' , 'XAF-CFA Franc BEAC',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='CFA Franc BEAC'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='XAF' AND cd.CountryName=N'XAF-CFA Franc BEAC')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(234,'XAF','CFA Franc BEAC' , 'XAF-CFA Franc BEAC',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='CFA Franc BEAC'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='XAF' AND cd.CountryName=N'XAF-CFA Franc BEAC')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(235,'XAF','CFA Franc BEAC' , 'XAF-CFA Franc BEAC',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='CFA Franc BEAC'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='XAF' AND cd.CountryName=N'XAF-CFA Franc BEAC')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(236,'XAF','CFA Franc BEAC' , 'XAF-CFA Franc BEAC',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='CFA Franc BEAC'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='XCD' AND cd.CountryName=N'XCD-East Caribbean Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(237,'XCD','East Caribbean Dollar' , 'XCD-East Caribbean Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='East Caribbean Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='XCD' AND cd.CountryName=N'XCD-East Caribbean Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(238,'XCD','East Caribbean Dollar' , 'XCD-East Caribbean Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='East Caribbean Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='XCD' AND cd.CountryName=N'XCD-East Caribbean Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(239,'XCD','East Caribbean Dollar' , 'XCD-East Caribbean Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='East Caribbean Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='XCD' AND cd.CountryName=N'XCD-East Caribbean Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(240,'XCD','East Caribbean Dollar' , 'XCD-East Caribbean Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='East Caribbean Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='XCD' AND cd.CountryName=N'XCD-East Caribbean Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(241,'XCD','East Caribbean Dollar' , 'XCD-East Caribbean Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='East Caribbean Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='XCD' AND cd.CountryName=N'XCD-East Caribbean Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(242,'XCD','East Caribbean Dollar' , 'XCD-East Caribbean Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='East Caribbean Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='XCD' AND cd.CountryName=N'XCD-East Caribbean Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(243,'XCD','East Caribbean Dollar' , 'XCD-East Caribbean Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='East Caribbean Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='XCD' AND cd.CountryName=N'XCD-East Caribbean Dollar')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(244,'XCD','East Caribbean Dollar' , 'XCD-East Caribbean Dollar',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='East Caribbean Dollar'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='XDR' AND cd.CountryName=N'XDR-SDR (Special Drawing Right)')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(245,'XDR','SDR (Special Drawing Right)' , 'XDR-SDR (Special Drawing Right)',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='SDR (Special Drawing Right)'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='XOF' AND cd.CountryName=N'XOF-CFA Franc BCEAO')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(246,'XOF','CFA Franc BCEAO' , 'XOF-CFA Franc BCEAO',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='CFA Franc BCEAO'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='XOF' AND cd.CountryName=N'XOF-CFA Franc BCEAO')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(247,'XOF','CFA Franc BCEAO' , 'XOF-CFA Franc BCEAO',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='CFA Franc BCEAO'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='XOF' AND cd.CountryName=N'XOF-CFA Franc BCEAO')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(248,'XOF','CFA Franc BCEAO' , 'XOF-CFA Franc BCEAO',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='CFA Franc BCEAO'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='XOF' AND cd.CountryName=N'XOF-CFA Franc BCEAO')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(249,'XOF','CFA Franc BCEAO' , 'XOF-CFA Franc BCEAO',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='CFA Franc BCEAO'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='XOF' AND cd.CountryName=N'XOF-CFA Franc BCEAO')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(250,'XOF','CFA Franc BCEAO' , 'XOF-CFA Franc BCEAO',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='CFA Franc BCEAO'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='XOF' AND cd.CountryName=N'XOF-CFA Franc BCEAO')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(251,'XOF','CFA Franc BCEAO' , 'XOF-CFA Franc BCEAO',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='CFA Franc BCEAO'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='XOF' AND cd.CountryName=N'XOF-CFA Franc BCEAO')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(252,'XOF','CFA Franc BCEAO' , 'XOF-CFA Franc BCEAO',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='CFA Franc BCEAO'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='XOF' AND cd.CountryName=N'XOF-CFA Franc BCEAO')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(253,'XOF','CFA Franc BCEAO' , 'XOF-CFA Franc BCEAO',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='CFA Franc BCEAO'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='XPF' AND cd.CountryName=N'XPF-CFP Franc')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(254,'XPF','CFP Franc' , 'XPF-CFP Franc',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='CFP Franc'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='XPF' AND cd.CountryName=N'XPF-CFP Franc')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(255,'XPF','CFP Franc' , 'XPF-CFP Franc',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='CFP Franc'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='XPF' AND cd.CountryName=N'XPF-CFP Franc')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(256,'XPF','CFP Franc' , 'XPF-CFP Franc',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='CFP Franc'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='XSU' AND cd.CountryName=N'XSU-Sucre')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(257,'XSU','Sucre' , 'XSU-Sucre',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Sucre'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='XUA' AND cd.CountryName=N'XUA-ADB Unit of Account')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(258,'XUA','ADB Unit of Account' , 'XUA-ADB Unit of Account',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='ADB Unit of Account'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='YER' AND cd.CountryName=N'YER-Yemeni Rial')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(259,'YER','Yemeni Rial' , 'YER-Yemeni Rial',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Yemeni Rial'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='ZAR' AND cd.CountryName=N'ZAR-Rand')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(260,'ZAR','Rand' , 'ZAR-Rand',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Rand'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='ZAR' AND cd.CountryName=N'ZAR-Rand')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(261,'ZAR','Rand' , 'ZAR-Rand',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Rand'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'
IF NOT EXISTS(SELECT 1 FROM dbo.CurrencyDetails cd WHERE  cd.CurrencyCode='ZAR' AND cd.CountryName=N'ZAR-Rand')
INSERT INTO  CurrencyDetails(CurrencyId,CurrencyCode,CurrencyName,CountryName ,Descriptions,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
VALUES(262,'ZAR','Rand' , 'ZAR-Rand',NULL,1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE cd SET cd.CurrencyName='Rand'  from dbo.CurrencyDetails cd WHERE cd.CurrencyCode='AED' AND CountryName='KAZAKHSTAN'

