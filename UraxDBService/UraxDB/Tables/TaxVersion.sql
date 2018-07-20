CREATE TABLE [dbo].[TaxVersion]
(
TaxVersionId bigint NOT NULL IDENTITY(1,1) CONSTRAINT PK_TaxMaster_TaxVersionId primary key
,TaxMasterId BIGINT NOT NULL CONSTRAINT fk_TaxVersion_TaxMasterId FOREIGN KEY REFERENCES [dbo].[TaxMaster](TaxMasterId)
,StartDate datetime NOT NULL,EndDate datetime NULL
,TaxVersionStatusId int CONSTRAINT [DF_TaxVersion_TaxVersionStatusId] DEFAULT (31) NOT NULL
,FeatureLevelTax BIT NOT NULL CONSTRAINT DF_TaxVersion_FeatureLevelTax DEFAULT(0)
,IsActive bit NOT NULL CONSTRAINT DF_TaxVersion_IsActive default(1) 
,CreatedBy varchar(200) NOT NULL,CreatedOn Datetime  NOT NULL CONSTRAINT DF_TaxVersion_CreatedOn Default(GETUTCDATE()) 
,UpdatedBy varchar(200) NOT NULL
,UpdatedOn dateTime NOT NULL CONSTRAINT DF_TaxVersion_UpdatedOn default(GETUTCDATE())
)
GO
ALTER TABLE TaxVersion
ADD   CONSTRAINT CHK_TaxVersion_Date CHECK (EndDate>=StartDate)
GO
ALTER TABLE TaxVersion
ADD CONSTRAINT CK_TaxVersion_DateFiff CHECK (dbo.ufn_checkOverlappingDateRange(TaxVersionId,TaxMasterId, StartDate,EndDate)  =(1))
GO
ALTER TABLE TaxVersion
ADD CONSTRAINT CK_TaxVersion_TaxVersionStatusId CHECK( [dbo].[ufn_ChkParamIdByGroupId](TaxVersionStatusId,10)= (1))