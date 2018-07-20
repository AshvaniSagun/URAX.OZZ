CREATE TABLE [dbo].[PnoParameter]
(
PnoParameterId bigint IDENTITY(1,1) CONSTRAINT PK_PnoParameter_PnoId PRIMARY KEY 
,PnoId bigint NOT NULL CONSTRAINT FK_PnoParameter_PnoId FOREIGN KEY REFERENCES PnoNumber(PnoId)
,VariableMasterId INT NOT NULL CONSTRAINT FK_PnoParameter_VariableMasterId FOREIGN KEY REFERENCES PnoVariableMaster(VariableMasterId),Value VARCHAR(1000)
,Isactive bit NOT NULL CONSTRAINT DF_PNOParameter_Isactive default(1)
,CreatedBy varchar(200) NOT NULL
,CreatedOn Datetime NOT NULL CONSTRAINT DF_PnoParameter_CreatedOn Default(GETUTCDATE()) 
,UpdatedBy varchar(200) NOT NULL
,UpdatedOn dateTime NOT NULL CONSTRAINT DF_PnoParameter_UpdatedOn default(GETUTCDATE())
)
GO
ALTER TABLE PnoParameter
ADD CONSTRAINT UQ_PnoParameter_PnoIdVariableMasterId UNIQUE([PnoId], [VariableMasterId])