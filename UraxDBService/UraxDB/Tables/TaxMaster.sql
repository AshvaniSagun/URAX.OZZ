CREATE TABLE [dbo].[TaxMaster]
(
TaxMasterId bigint NOT NULL IDENTITY(1,1) CONSTRAINT PK_TaxMaster_TaxMasterId primary key 
,MarketId bigint NOT NULL Constraint fk_TaxMaster_MarketId foreign key references dbo.Market(MarketId)
,TaxName varchar(500) NOT NULL,TaxPositionId int,[Priority] int NOT NULL
,IsActive bit NOT NULL CONSTRAINT DF_TaxMaster_IsActive Default(1)
,CreatedBy varchar(200) NOT NULL
,CreatedOn Datetime NOT NULL CONSTRAINT DF_TaxMaster_CreatedOn Default(GETUTCDATE()) 
,UpdatedBy varchar(200) NOT NULL
,UpdatedOn dateTime NOT NULL CONSTRAINT DF_TaxMaster_UpdatedOn default(GETUTCDATE())
)
GO
ALTER TABLE TaxMaster
ADD CONSTRAINT UQ_TaxMaster_MarketIdPriority UNIQUE(MarketId, [Priority])
GO
ALTER TABLE TaxMaster
ADD CONSTRAINT UQ_TaxMaster_MarketIdTaxName UNIQUE(MarketId, [TaxName])
GO
ALTER TABLE TaxMaster
ADD CONSTRAINT CK_TaxMaster_TaxPositionId CHECK( [dbo].[ufn_ChkParamIdByGroupId](TaxPositionId,2)= (1))
