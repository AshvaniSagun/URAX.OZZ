CREATE TABLE [dbo].[CountryCode]
(
CountryCodeId int CONSTRAINT PK_CountryCode_CountryCodeId PRIMARY KEY
,CountryCode varchar(3) NOT NULL CONSTRAINT UQ_CountryCode_CountryCode UNIQUE
,CountryName nvarchar(200) NOT NULL CONSTRAINT UQ_CountryCode_CountryName UNIQUE
,CultureInfoDetails varchar(20) NULL
,Descriptions varchar(200) NULL
,IsActive bit NOT NULL CONSTRAINT DF_CountryCode_IsActive  default(1)
,CreatedBy varchar(200) NOT NULL
,CreatedOn Datetime NOT NULL CONSTRAINT DF_CountryCode_CreatedOn Default(GETUTCDATE()) 
,UpdatedBy varchar(200) NOT NULL
,UpdatedOn dateTime  NOT NULL CONSTRAINT DF_CountryCode_UpdatedOn  default(GETUTCDATE())
)
