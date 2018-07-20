CREATE TABLE [dbo].[SubdivisionCode]
(
	SubdivisionCodeId int CONSTRAINT PK_SubdivisionCode_SubdivisionCodeId PRIMARY KEY 
,CountryCodeId int NOT NULL CONSTRAINT FK_SubdivisionCode_CountryCodeId FOREIGN KEY REFERENCES dbo.CountryCode(CountryCodeId)
,SubdivisionCode varchar(6) NOT NULL 
,SubdivisionName nvarchar(200)  NULL
,LocalName nvarchar(200)  NULL
,Descriptions varchar(200) NULL
,IsActive bit NOT NULL CONSTRAINT DF_SubdivisionCode_IsActive  default(1)
,CreatedBy varchar(200) NOT NULL
,CreatedOn Datetime NOT NULL CONSTRAINT DF_SubdivisionCode_CreatedOn Default(GETUTCDATE()) 
,UpdatedBy varchar(200) NOT NULL
,UpdatedOn dateTime  NOT NULL CONSTRAINT DF_SubdivisionCode_UpdatedOn  default(GETUTCDATE())
)
