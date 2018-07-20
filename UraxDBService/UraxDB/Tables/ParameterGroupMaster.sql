CREATE TABLE [dbo].[ParameterGroupMaster]
(
ParameterGroupId int NOT NULL constraint PK_ParameterGroupMaster_ParameterGroupId primary key 
,ParameterGroupName varchar(500) NOT NULL CONSTRAINT UQ_ParameterGroupMaster_ParameterGroupName UNIQUE
,IsActive bit default(1)
,CreatedBy varchar(200) NOT NULL
,CreatedOn Datetime Default(GETUTCDATE()) 
,UpdatedBy varchar(200) NOT NULL
,UpdatedOn dateTime default(GETUTCDATE())
)
