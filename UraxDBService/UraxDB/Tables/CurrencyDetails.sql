CREATE TABLE [dbo].[CurrencyDetails]
(
CurrencyId INT CONSTRAINT PK_CurrencyDetails_CurrencyId PRIMARY KEY
,CurrencyCode varchar(10) NOT NULL 
, CurrencyName varchar(250)  NULL
,CountryName varchar(250)  NULL
,Descriptions varchar(50) NULL
,IsActive BIT NOT NULL CONSTRAINT  DF_CurrencyDetails_IsActive default(1)
,CreatedBy varchar(200) NOT NULL
,CreatedOn Datetime NOT NULL CONSTRAINT DF_CurrencyDetails_CreatedOn Default(GETUTCDATE()) 
,UpdatedBy varchar(200) NULL
,UpdatedOn dateTime CONSTRAINT DF_CurrencyDetails_UpdatedOn default(GETUTCDATE())
);
GO 
ALTER TABLE dbo.CurrencyDetails
ADD CONSTRAINT UQ_CurrencyDetails_CurrencyCode_CurrencyName UNIQUE(CountryName,CurrencyCode)
