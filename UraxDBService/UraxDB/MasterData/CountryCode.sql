IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='AE')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(1,'AE','United Arab Emirates','ar-AE',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='United Arab Emirates' FROM dbo.CountryCode cc WHERE cc.CountryCode='AE'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='AF')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(2,'AF','Afghanistan','ps-AF',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Afghanistan' FROM dbo.CountryCode cc WHERE cc.CountryCode='AF'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='AL')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(3,'AL','Albania','sq-AL',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Albania' FROM dbo.CountryCode cc WHERE cc.CountryCode='AL'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='AM')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(4,'AM','Armenia','hy-AM',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Armenia' FROM dbo.CountryCode cc WHERE cc.CountryCode='AM'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='AR')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(5,'AR','Argentina','es-AR',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Argentina' FROM dbo.CountryCode cc WHERE cc.CountryCode='AR'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='AT')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(6,'AT','Austria','de-AT',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Austria' FROM dbo.CountryCode cc WHERE cc.CountryCode='AT'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='AU')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(7,'AU','Australia','en-AU',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Australia' FROM dbo.CountryCode cc WHERE cc.CountryCode='AU'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='AZ')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(8,'AZ','Azerbaijan','az-Cyrl-AZ',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Azerbaijan' FROM dbo.CountryCode cc WHERE cc.CountryCode='AZ'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='BA')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(9,'BA','Bosnia and Herzegovina','sr-Cyrl-BA',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Bosnia and Herzegovina' FROM dbo.CountryCode cc WHERE cc.CountryCode='BA'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='BD')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(10,'BD','Bangladesh','bn-BD',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Bangladesh' FROM dbo.CountryCode cc WHERE cc.CountryCode='BD'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='BE')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(11,'BE','Belgium','fr-BE',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Belgium' FROM dbo.CountryCode cc WHERE cc.CountryCode='BE'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='BG')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(12,'BG','Bulgaria','bg-BG',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Bulgaria' FROM dbo.CountryCode cc WHERE cc.CountryCode='BG'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='BH')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(13,'BH','Bahrain','ar-BH',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Bahrain' FROM dbo.CountryCode cc WHERE cc.CountryCode='BH'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='BN')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(14,'BN','Brunei Darussalam','ms-BN',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Brunei Darussalam' FROM dbo.CountryCode cc WHERE cc.CountryCode='BN'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='BO')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(15,'BO','Bolivia (Plurinational State of)','quz-BO',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Bolivia (Plurinational State of)' FROM dbo.CountryCode cc WHERE cc.CountryCode='BO'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='BR')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(16,'BR','Brazil','pt-BR',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Brazil' FROM dbo.CountryCode cc WHERE cc.CountryCode='BR'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='BY')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(17,'BY','Belarus','be-BY',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Belarus' FROM dbo.CountryCode cc WHERE cc.CountryCode='BY'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='BZ')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(18,'BZ','Belize','en-BZ',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Belize' FROM dbo.CountryCode cc WHERE cc.CountryCode='BZ'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='CA')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(19,'CA','Canada','fr-CA',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Canada' FROM dbo.CountryCode cc WHERE cc.CountryCode='CA'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='CH')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(20,'CH','Switzerland','rm-CH',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Switzerland' FROM dbo.CountryCode cc WHERE cc.CountryCode='CH'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='CL')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(21,'CL','Chile','arn-CL',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Chile' FROM dbo.CountryCode cc WHERE cc.CountryCode='CL'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='CN')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(22,'CN','China','bo-CN',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='China' FROM dbo.CountryCode cc WHERE cc.CountryCode='CN'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='CO')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(24,'CO','Colombia','es-CO',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Colombia' FROM dbo.CountryCode cc WHERE cc.CountryCode='CO'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='CR')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(25,'CR','Costa Rica','es-CR',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Costa Rica' FROM dbo.CountryCode cc WHERE cc.CountryCode='CR'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='CZ')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(27,'CZ','Czechia','cs-CZ',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Czechia' FROM dbo.CountryCode cc WHERE cc.CountryCode='CZ'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='DE')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(28,'DE','Germany','de-DE',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Germany' FROM dbo.CountryCode cc WHERE cc.CountryCode='DE'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='DK')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(29,'DK','Denmark','da-DK',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Denmark' FROM dbo.CountryCode cc WHERE cc.CountryCode='DK'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='DO')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(30,'DO','Dominican Republic','es-DO',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Dominican Republic' FROM dbo.CountryCode cc WHERE cc.CountryCode='DO'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='DZ')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(31,'DZ','Algeria','ar-DZ',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Algeria' FROM dbo.CountryCode cc WHERE cc.CountryCode='DZ'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='EC')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(32,'EC','Ecuador','quz-EC',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Ecuador' FROM dbo.CountryCode cc WHERE cc.CountryCode='EC'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='EE')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(33,'EE','Estonia','et-EE',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Estonia' FROM dbo.CountryCode cc WHERE cc.CountryCode='EE'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='EG')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(34,'EG','Egypt','ar-EG',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Egypt' FROM dbo.CountryCode cc WHERE cc.CountryCode='EG'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='ES')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(35,'ES','Spain','eu-ES',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Spain' FROM dbo.CountryCode cc WHERE cc.CountryCode='ES'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='ET')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(37,'ET','Ethiopia','am-ET',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Ethiopia' FROM dbo.CountryCode cc WHERE cc.CountryCode='ET'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='FI')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(38,'FI','Finland','fi-FI',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Finland' FROM dbo.CountryCode cc WHERE cc.CountryCode='FI'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='FO')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(39,'FO','Faroe Islands','fo-FO',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Faroe Islands' FROM dbo.CountryCode cc WHERE cc.CountryCode='FO'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='FR')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(40,'FR','France','fr-FR',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='France' FROM dbo.CountryCode cc WHERE cc.CountryCode='FR'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='GB')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(41,'GB','United Kingdom of Great Britain and Northern Ireland','en-GB',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='United Kingdom of Great Britain and Northern Ireland' FROM dbo.CountryCode cc WHERE cc.CountryCode='GB'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='GE')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(42,'GE','Georgia','ka-GE',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Georgia' FROM dbo.CountryCode cc WHERE cc.CountryCode='GE'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='GL')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(43,'GL','Greenland','kl-GL',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Greenland' FROM dbo.CountryCode cc WHERE cc.CountryCode='GL'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='GR')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(44,'GR','Greece','el-GR',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Greece' FROM dbo.CountryCode cc WHERE cc.CountryCode='GR'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='GT')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(45,'GT','Guatemala','es-GT',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Guatemala' FROM dbo.CountryCode cc WHERE cc.CountryCode='GT'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='HK')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(46,'HK','Hong Kong','zh-HK',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Hong Kong' FROM dbo.CountryCode cc WHERE cc.CountryCode='HK'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='HN')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(47,'HN','Honduras','es-HN',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Honduras' FROM dbo.CountryCode cc WHERE cc.CountryCode='HN'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='HR')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(48,'HR','Croatia','hr-HR',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Croatia' FROM dbo.CountryCode cc WHERE cc.CountryCode='HR'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='HU')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(49,'HU','Hungary','hu-HU',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Hungary' FROM dbo.CountryCode cc WHERE cc.CountryCode='HU'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='ID')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(50,'ID','Indonesia','id-ID',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Indonesia' FROM dbo.CountryCode cc WHERE cc.CountryCode='ID'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='IE')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(51,'IE','Ireland','en-IE',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Ireland' FROM dbo.CountryCode cc WHERE cc.CountryCode='IE'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='IL')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(52,'IL','Israel','he-IL',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Israel' FROM dbo.CountryCode cc WHERE cc.CountryCode='IL'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='IN')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(53,'IN','India','en-IN',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='India' FROM dbo.CountryCode cc WHERE cc.CountryCode='IN'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='IQ')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(54,'IQ','Iraq','ar-IQ',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Iraq' FROM dbo.CountryCode cc WHERE cc.CountryCode='IQ'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='IR')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(55,'IR','Iran (Islamic Republic of)','fa-IR',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Iran (Islamic Republic of)' FROM dbo.CountryCode cc WHERE cc.CountryCode='IR'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='IS')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(56,'IS','Iceland','is-IS',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Iceland' FROM dbo.CountryCode cc WHERE cc.CountryCode='IS'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='IT')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(57,'IT','Italy','it-IT',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Italy' FROM dbo.CountryCode cc WHERE cc.CountryCode='IT'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='JM')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(58,'JM','Jamaica','en-JM',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Jamaica' FROM dbo.CountryCode cc WHERE cc.CountryCode='JM'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='JO')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(59,'JO','Jordan','ar-JO',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Jordan' FROM dbo.CountryCode cc WHERE cc.CountryCode='JO'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='JP')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(60,'JP','Japan','ja-JP',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Japan' FROM dbo.CountryCode cc WHERE cc.CountryCode='JP'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='KE')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(61,'KE','Kenya','sw-KE',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Kenya' FROM dbo.CountryCode cc WHERE cc.CountryCode='KE'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='KG')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(62,'KG','Kyrgyzstan','ky-KG',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Kyrgyzstan' FROM dbo.CountryCode cc WHERE cc.CountryCode='KG'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='KH')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(63,'KH','Cambodia','km-KH',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Cambodia' FROM dbo.CountryCode cc WHERE cc.CountryCode='KH'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='KR')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(64,'KR','Korea (Republic of)','ko-KR',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Korea (Republic of)' FROM dbo.CountryCode cc WHERE cc.CountryCode='KR'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='KW')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(65,'KW','Kuwait','ar-KW',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Kuwait' FROM dbo.CountryCode cc WHERE cc.CountryCode='KW'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='KZ')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(66,'KZ','Kazakhstan','kk-KZ',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Kazakhstan' FROM dbo.CountryCode cc WHERE cc.CountryCode='KZ'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='LA')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(67,'LA','Lao Peoples Democratic Republic','lo-LA',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Lao Peoples Democratic Republic' FROM dbo.CountryCode cc WHERE cc.CountryCode='LA'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='LB')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(68,'LB','Lebanon','ar-LB',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Lebanon' FROM dbo.CountryCode cc WHERE cc.CountryCode='LB'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='LI')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(69,'LI','Liechtenstein','de-LI',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Liechtenstein' FROM dbo.CountryCode cc WHERE cc.CountryCode='LI'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='LK')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(70,'LK','Sri Lanka','si-LK',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Sri Lanka' FROM dbo.CountryCode cc WHERE cc.CountryCode='LK'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='LT')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(71,'LT','Lithuania','lt-LT',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Lithuania' FROM dbo.CountryCode cc WHERE cc.CountryCode='LT'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='LU')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(72,'LU','Luxembourg','lb-LU',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Luxembourg' FROM dbo.CountryCode cc WHERE cc.CountryCode='LU'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='LV')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(73,'LV','Latvia','lv-LV',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Latvia' FROM dbo.CountryCode cc WHERE cc.CountryCode='LV'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='LY')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(74,'LY','Libya','ar-LY',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Libya' FROM dbo.CountryCode cc WHERE cc.CountryCode='LY'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='MA')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(75,'MA','Morocco','ar-MA',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Morocco' FROM dbo.CountryCode cc WHERE cc.CountryCode='MA'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='MC')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(76,'MC','Monaco','fr-MC',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Monaco' FROM dbo.CountryCode cc WHERE cc.CountryCode='MC'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='ME')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(77,'ME','Montenegro','sr-Cyrl-ME',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Montenegro' FROM dbo.CountryCode cc WHERE cc.CountryCode='ME'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='MK')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(78,'MK','Macedonia (the former Yugoslav Republic of)','mk-MK',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Macedonia (the former Yugoslav Republic of)' FROM dbo.CountryCode cc WHERE cc.CountryCode='MK'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='MN')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(79,'MN','Mongolia','mn-MN',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Mongolia' FROM dbo.CountryCode cc WHERE cc.CountryCode='MN'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='MO')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(80,'MO','Macao','zh-MO',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Macao' FROM dbo.CountryCode cc WHERE cc.CountryCode='MO'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='MT')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(81,'MT','Malta','mt-MT',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Malta' FROM dbo.CountryCode cc WHERE cc.CountryCode='MT'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='MV')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(82,'MV','Maldives','dv-MV',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Maldives' FROM dbo.CountryCode cc WHERE cc.CountryCode='MV'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='MX')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(83,'MX','Mexico','es-MX',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Mexico' FROM dbo.CountryCode cc WHERE cc.CountryCode='MX'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='MY')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(84,'MY','Malaysia','ms-MY',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Malaysia' FROM dbo.CountryCode cc WHERE cc.CountryCode='MY'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='NG')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(86,'NG','Nigeria','ha-Latn-NG',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Nigeria' FROM dbo.CountryCode cc WHERE cc.CountryCode='NG'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='NI')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(89,'NI','Nicaragua','es-NI',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Nicaragua' FROM dbo.CountryCode cc WHERE cc.CountryCode='NI'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='NL')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(90,'NL','Netherlands','nl-NL',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Netherlands' FROM dbo.CountryCode cc WHERE cc.CountryCode='NL'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='NO')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(91,'NO','Norway','nb-NO',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Norway' FROM dbo.CountryCode cc WHERE cc.CountryCode='NO'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='NP')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(92,'NP','Nepal','ne-NP',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Nepal' FROM dbo.CountryCode cc WHERE cc.CountryCode='NP'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='NZ')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(93,'NZ','New Zealand','en-NZ',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='New Zealand' FROM dbo.CountryCode cc WHERE cc.CountryCode='NZ'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='OM')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(94,'OM','Oman','ar-OM',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Oman' FROM dbo.CountryCode cc WHERE cc.CountryCode='OM'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='PA')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(95,'PA','Panama','es-PA',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Panama' FROM dbo.CountryCode cc WHERE cc.CountryCode='PA'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='PE')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(96,'PE','Peru','es-PE',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Peru' FROM dbo.CountryCode cc WHERE cc.CountryCode='PE'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='PH')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(97,'PH','Philippines','fil-PH',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Philippines' FROM dbo.CountryCode cc WHERE cc.CountryCode='PH'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='PK')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(99,'PK','Pakistan','ur-PK',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Pakistan' FROM dbo.CountryCode cc WHERE cc.CountryCode='PK'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='PL')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(100,'PL','Poland','pl-PL',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Poland' FROM dbo.CountryCode cc WHERE cc.CountryCode='PL'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='PR')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(101,'PR','Puerto Rico','es-PR',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Puerto Rico' FROM dbo.CountryCode cc WHERE cc.CountryCode='PR'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='PT')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(102,'PT','Portugal','pt-PT',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Portugal' FROM dbo.CountryCode cc WHERE cc.CountryCode='PT'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='PY')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(103,'PY','Paraguay','es-PY',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Paraguay' FROM dbo.CountryCode cc WHERE cc.CountryCode='PY'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='QA')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(104,'QA','Qatar','ar-QA',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Qatar' FROM dbo.CountryCode cc WHERE cc.CountryCode='QA'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='RO')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(105,'RO','Romania','ro-RO',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Romania' FROM dbo.CountryCode cc WHERE cc.CountryCode='RO'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='RS')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(106,'RS','Serbia','sr-Cyrl-RS',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Serbia' FROM dbo.CountryCode cc WHERE cc.CountryCode='RS'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='RU')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(107,'RU','Russian Federation','ru-RU',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Russian Federation' FROM dbo.CountryCode cc WHERE cc.CountryCode='RU'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='RW')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(108,'RW','Rwanda','rw-RW',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Rwanda' FROM dbo.CountryCode cc WHERE cc.CountryCode='RW'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='SA')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(109,'SA','Saudi Arabia','ar-SA',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Saudi Arabia' FROM dbo.CountryCode cc WHERE cc.CountryCode='SA'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='SE')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(110,'SE','Sweden','sv-SE',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Sweden' FROM dbo.CountryCode cc WHERE cc.CountryCode='SE'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='SG')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(111,'SG','Singapore','en-SG',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Singapore' FROM dbo.CountryCode cc WHERE cc.CountryCode='SG'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='SI')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(112,'SI','Slovenia','sl-SI',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Slovenia' FROM dbo.CountryCode cc WHERE cc.CountryCode='SI'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='SK')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(113,'SK','Slovakia','sk-SK',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Slovakia' FROM dbo.CountryCode cc WHERE cc.CountryCode='SK'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='SN')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(114,'SN','Senegal','wo-SN',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Senegal' FROM dbo.CountryCode cc WHERE cc.CountryCode='SN'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='SV')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(115,'SV','El Salvador','es-SV',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='El Salvador' FROM dbo.CountryCode cc WHERE cc.CountryCode='SV'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='SY')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(116,'SY','Syrian Arab Republic','syr-SY',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Syrian Arab Republic' FROM dbo.CountryCode cc WHERE cc.CountryCode='SY'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='TH')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(118,'TH','Thailand','th-TH',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Thailand' FROM dbo.CountryCode cc WHERE cc.CountryCode='TH'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='TJ')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(119,'TJ','Tajikistan','tg-Cyrl-TJ',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Tajikistan' FROM dbo.CountryCode cc WHERE cc.CountryCode='TJ'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='TM')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(120,'TM','Turkmenistan','tk-TM',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Turkmenistan' FROM dbo.CountryCode cc WHERE cc.CountryCode='TM'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='TN')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(121,'TN','Tunisia','ar-TN',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Tunisia' FROM dbo.CountryCode cc WHERE cc.CountryCode='TN'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='TR')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(122,'TR','Turkey','tr-TR',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Turkey' FROM dbo.CountryCode cc WHERE cc.CountryCode='TR'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='TT')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(123,'TT','Trinidad and Tobago','en-TT',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Trinidad and Tobago' FROM dbo.CountryCode cc WHERE cc.CountryCode='TT'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='TW')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(124,'TW','Taiwan, Province of China[a]','zh-TW',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Taiwan, Province of China[a]' FROM dbo.CountryCode cc WHERE cc.CountryCode='TW'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='UA')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(125,'UA','Ukraine','uk-UA',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Ukraine' FROM dbo.CountryCode cc WHERE cc.CountryCode='UA'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='US')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(126,'US','United States of America','en-US',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='United States of America' FROM dbo.CountryCode cc WHERE cc.CountryCode='US'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='UY')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(127,'UY','Uruguay','es-UY',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Uruguay' FROM dbo.CountryCode cc WHERE cc.CountryCode='UY'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='UZ')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(129,'UZ','Uzbekistan','uz-Latn-UZ',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Uzbekistan' FROM dbo.CountryCode cc WHERE cc.CountryCode='UZ'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='VE')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(130,'VE','Venezuela (Bolivarian Republic of)','es-VE',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Venezuela (Bolivarian Republic of)' FROM dbo.CountryCode cc WHERE cc.CountryCode='VE'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='VN')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(131,'VN','Viet Nam','vi-VN',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Viet Nam' FROM dbo.CountryCode cc WHERE cc.CountryCode='VN'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='YE')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(132,'YE','Yemen','ar-YE',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Yemen' FROM dbo.CountryCode cc WHERE cc.CountryCode='YE'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='ZA')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(133,'ZA','South Africa','en-ZA',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='South Africa' FROM dbo.CountryCode cc WHERE cc.CountryCode='ZA'
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='ZW')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(134,'ZW','Zimbabwe','en-ZW',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Zimbabwe' FROM dbo.CountryCode cc WHERE cc.CountryCode='ZW'

-------------------------
IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='AN')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(135,'AN','NETHERLANDS ANTILLES','en-US',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='NETHERLANDS ANTILLES' FROM dbo.CountryCode cc WHERE cc.CountryCode='AN'

IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='AO')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(136,'AO','Angola','en-US',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Angola' FROM dbo.CountryCode cc WHERE cc.CountryCode='AO'

IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='CY')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(137,'CY','Cyprus','en-US',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Cyprus' FROM dbo.CountryCode cc WHERE cc.CountryCode='CY'

IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='FJ')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(138,'FJ','Fiji','en-US',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Fiji' FROM dbo.CountryCode cc WHERE cc.CountryCode='FJ'

IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='GH')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(139,'GH','Ghana','en-US',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Ghana' FROM dbo.CountryCode cc WHERE cc.CountryCode='GH'

IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='HT')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(140,'HT','HAITI','en-US',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='HAITI' FROM dbo.CountryCode cc WHERE cc.CountryCode='HT'

IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='ZZ')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(141,'ZZ','unspecified country','en-US',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='unspecified country' FROM dbo.CountryCode cc WHERE cc.CountryCode='ZZ'

IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='ZM')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(142,'ZM','Zambia','en-US',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Zambia' FROM dbo.CountryCode cc WHERE cc.CountryCode='ZM'

IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='NA')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(143,'NA','Namibia','en-US',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Namibia' FROM dbo.CountryCode cc WHERE cc.CountryCode='NA'

IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='MZ')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(144,'MZ','Mozambique','en-US',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Mozambique' FROM dbo.CountryCode cc WHERE cc.CountryCode='MZ'

IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='MM')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(145,'MM','Myanmar','en-US',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Myanmar' FROM dbo.CountryCode cc WHERE cc.CountryCode='MM'

IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='MD')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(146,'MD','Moldova','en-US',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Moldova' FROM dbo.CountryCode cc WHERE cc.CountryCode='MD'

IF NOT EXISTS(SELECT 1 FROM CountryCode c WHERE c.CountryCode='YU')
INSERT INTO CountryCode (CountryCodeId,CountryCode,CountryName,CultureInfoDetails,Descriptions,CreatedBy,UpdatedBy)
VALUES(147,'YU','Yugoslavia','en-US',NULL,'ADMIN','ADMIN')
ELSE
UPDATE cc SET cc.CountryName='Yugoslavia' FROM dbo.CountryCode cc WHERE cc.CountryCode='YU'






