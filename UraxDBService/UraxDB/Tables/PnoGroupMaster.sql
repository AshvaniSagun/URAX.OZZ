CREATE TABLE [dbo].[PnoGroupMaster]
(
PnoGroupId INT CONSTRAINT PK_PnoGroup_PnoGroupId PRIMARY KEY 
,PnoGroupName varchar(500) NOT NULL CONSTRAINT UQ_PnoGroupMaster_PnoGroupName UNIQUE 
,Isactive bit CONSTRAINT DF_PnoGroupMaster_Isactive default(1)
,CreatedBy varchar(200) NOT NULL
,CreatedOn Datetime NOT NULL CONSTRAINT DF_PNOGroup_CreatedOn Default(GETUTCDATE()) 
,UpdatedBy varchar(200) NOT NULL
,UpdatedOn dateTime  NOT NULL CONSTRAINT DF_PNOGroup_UpdatedOn  default(GETUTCDATE())
)
