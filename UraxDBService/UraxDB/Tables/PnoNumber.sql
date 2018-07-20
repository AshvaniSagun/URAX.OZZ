CREATE TABLE [dbo].[PnoNumber]
(
PnoId bigint IDENTITY(1,1) CONSTRAINT PK_PnoNumber_PnoId PRIMARY KEY
,PnoGroupId INT NOT NULL CONSTRAINT FK_PnoNumber_ FOREIGN KEY REFERENCES PnoGroupMaster(PnoGroupId) 
,[Value] varchar(20) NOT NULL
,MarketId varchar(10),ModelYear varchar(4),CarLine varchar(200)
,Isactive bit NOT NULL CONSTRAINT DF_PnoNumber_Isactive default(1)
,CreatedBy varchar(200) NOT NULL
,CreatedOn Datetime NOT NULL CONSTRAINT DF_PnoNumber_CreatedOn Default(GETUTCDATE()) 
,UpdatedBy varchar(200) NOT NULL
,UpdatedOn dateTime NOT NULL CONSTRAINT DF_PnoNumber_UpdatedOn default(GETUTCDATE())
)
GO
ALTER TABLE PnoNumber
ADD CONSTRAINT UQ_PnoNumber_PnoGroupIdMIdMYCL UNIQUE([PnoGroupId], [MarketId],[ModelYear],[CarLine])
