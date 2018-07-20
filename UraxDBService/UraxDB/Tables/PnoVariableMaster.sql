CREATE TABLE [dbo].[PnoVariableMaster](
	[VariableMasterId] [int] IDENTITY(1,1) NOT NULL,
	[PnoGroupId] [int] NOT NULL,
	[VariableName] [varchar](500) NOT NULL,
	[VariableCode] [varchar](100) NULL,
	[Datatype] [varchar](100) NULL,
	[Isactive] [bit] NOT NULL,
	[CreatedBy] [varchar](200) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [varchar](200) NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
	[GuiName] [varchar](500) NULL,
	GroupTypeId int CONSTRAINT [DF_PnoVariableMaster_GroupTypeId] DEFAULT (35) NOT NULL,
 CONSTRAINT [PK_PnoVariableMaster_VariableId] PRIMARY KEY CLUSTERED 
(
	[VariableMasterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON),
 CONSTRAINT [UQ_PnoVariableMaster_PnoGroupIdVariableCode] UNIQUE NONCLUSTERED 
(
	[PnoGroupId] ASC,
	[VariableCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON),
 CONSTRAINT [UQ_PnoVariableMaster_PnoGroupIdVariableName] UNIQUE NONCLUSTERED 
(
	[PnoGroupId] ASC,
	[VariableName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
ALTER TABLE [dbo].[PnoVariableMaster]  WITH CHECK ADD  CONSTRAINT [FK_PnoVariableMaster_PnoGroupId] FOREIGN KEY([PnoGroupId])
REFERENCES [dbo].[PnoGroupMaster] ([PnoGroupId])
GO

ALTER TABLE [dbo].[PnoVariableMaster] CHECK CONSTRAINT [FK_PnoVariableMaster_PnoGroupId]
GO
