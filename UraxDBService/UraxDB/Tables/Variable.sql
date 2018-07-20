CREATE TABLE [dbo].[Variable]
(
VariableId bigint IDENTITY(1,1) NOT NULL constraint PK_Variable_VariableId primary key 
,TaxId BIGINT NOT NULL CONSTRAINT fk_Variable_TaxId FOREIGN KEY REFERENCES Tax(TaxId)
,VariableName varchar(500) NOT NULL
,[Value] decimal(18,2),UnitTypeId int 
,VariableTypeId int NOT NULL,
IslookUp bit CONSTRAINT DF_Variable_IslookUp default(0)
,TestValue varchar(500) NULL
,IsActive bit NOT NULL CONSTRAINT DF_Variable_IsActive default(1)
,CreatedBy varchar(200) NOT NULL
,CreatedOn Datetime NOT NULL CONSTRAINT DF_Variable_CreatedOn Default(GETUTCDATE()) 
,UpdatedBy varchar(200) NOT NULL
,UpdatedOn dateTime NOT NULL CONSTRAINT DF_Variable_UpdatedOn default(GETUTCDATE())
)
GO
ALTER TABLE Variable 
ADD CONSTRAINT CK_Variable_VariableName_CharactersNumebrs CHECK ([Value] NOT LIKE '%[^A-Za-z0-9. ]%' )
GO
ALTER TABLE Variable
ADD CONSTRAINT UQ_Variable_TaxIdVariableName UNIQUE([TaxId],[VariableName])
GO
ALTER TABLE Variable
ADD CONSTRAINT CK_Variable_VariableTypeId CHECK( [dbo].[ufn_ChkParamIdByGroupId](VariableTypeId,3)= (1))
GO
ALTER TABLE Variable
ADD CONSTRAINT CK_Variable_UnitTypeId CHECK( [dbo].[ufn_ChkParamIdByGroupId](UnitTypeId,5)= (1))
