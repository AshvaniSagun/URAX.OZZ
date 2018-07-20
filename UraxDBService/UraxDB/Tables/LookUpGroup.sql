CREATE TABLE [dbo].[LookUpGroup]
(
LookUpGroupId bigint IDENTITY(1,1) NOT NULL constraint PK_LookUpGroup_LookUpGroupId PRIMARY KEY--,GroupId bigint NOT NULL
,TaxId bigint NOT NULL CONSTRAINT fk_LookUpGroup_TaxId FOREIGN KEY REFERENCES Tax(TaxId)
,LookUpGroupName varchar(500) NOT NULL
,IsActive bit NOT NULL CONSTRAINT DF_LookUpGroup_IsActive default(1)
,CreatedBy varchar(200) NOT NULL
,CreatedOn Datetime NOT NULL CONSTRAINT DF_LookUpGroup_CreatedOn Default(GETUTCDATE()) 
,UpdatedBy varchar(200) NOT NULL
,UpdatedOn dateTime NOT NULL CONSTRAINT DF_LookUpGroup_UpdatedOn default(GETUTCDATE())
);
GO
ALTER TABLE LookUpGroup ADD CONSTRAINT UQ_LookUpGroup_TaxId_LookUpGroupName UNIQUE (TaxId, LookUpGroupName)
GO
