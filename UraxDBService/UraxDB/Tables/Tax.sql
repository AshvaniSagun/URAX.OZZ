CREATE TABLE [dbo].[Tax]
(
TaxId BIGINT NOT NULL IDENTITY(1,1) CONSTRAINT PK_Tax_TaxId PRIMARY KEY
,TaxVersionId bigint NOT NULL CONSTRAINT fk_Tax_TaxVersionId FOREIGN KEY REFERENCES TaxVersion(TaxVersionId),TaxFlowId INT NOT NULL
,IsActive BIT NOT NULL CONSTRAINT DF_Tax_IsActive DEFAULT(1)
,CreatedBy varchar(200) NOT NULL
,CreatedOn Datetime NOT NULL CONSTRAINT DF_Tax_CreatedOn Default(GETUTCDATE()) 
,UpdatedBy varchar(200) NOT NULL
,UpdatedOn dateTime NOT NULL CONSTRAINT DF_Tax_UpdatedOn default(GETUTCDATE())
)
GO
ALTER TABLE Tax
ADD CONSTRAINT UQ_Tax_TaxVersionIdTaxFlowId UNIQUE([TaxVersionId], [TaxFlowId])
GO
ALTER TABLE Tax
ADD CONSTRAINT CK_Tax_TaxFlowId CHECK( [dbo].[ufn_ChkParamIdByGroupId](TaxFlowId,1)= (1))
