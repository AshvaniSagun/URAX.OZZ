CREATE TABLE [dbo].[Formula]
(
FormulaId bigint IDENTITY(1,1) CONSTRAINT PK_Formula_FormulaId primary key
,VariableId BIGINT NOT NULL CONSTRAINT FK_Formula_VariableId FOREIGN KEY REFERENCES Variable(VariableId)
,FormulaDefination varchar(max)
,MinValue decimal(18, 2) ,MaxValue decimal(18, 2)
,[Priority] int NOT NULL 
--,RoundId int  NULL
,IsActive bit NOT NULL CONSTRAINT DF_Formula_IsActive default(1)
,CreatedBy varchar(200) NOT NULL
,CreatedOn Datetime CONSTRAINT DF_Formula_CreatedOn Default(GETUTCDATE()) 
,UpdatedBy varchar(200) NOT NULL
,UpdatedOn dateTime CONSTRAINT DF_Formula_UpdatedOn default(GETUTCDATE())
)
GO
ALTER TABLE Formula
ADD CONSTRAINT UQ_Formula_VariableId UNIQUE([VariableId])
--GO
--ALTER TABLE Formula
--ADD CONSTRAINT CK_Formula_RoundId CHECK( [dbo].[ufn_ChkParamIdByGroupId](RoundId,6)= (1))
GO
ALTER TABLE Formula
ADD CONSTRAINT CK_Formula_Priority CHECK( [dbo].[ufn_ChkFormulaPriority](VariableId,[Priority])= (1))