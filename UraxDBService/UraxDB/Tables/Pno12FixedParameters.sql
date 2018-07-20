CREATE TABLE [dbo].[Pno12FixedParameters]
(
	[Pno12Id] [int] NOT NULL,
	[Pno12PdId] [int] NOT NULL,
	[ParameterValue] [varchar](200) NULL,
	[CreatedBy] [varchar](200) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [varchar](200) NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [pk_FixedParam] PRIMARY KEY CLUSTERED 
(
	[Pno12Id] ASC,
	[Pno12PdId] ASC
)
)


GO

ALTER TABLE [dbo].[Pno12FixedParameters]  WITH CHECK ADD FOREIGN KEY([Pno12PdId])
REFERENCES [dbo].[Pno12ParameterDefinition] ([Pno12PdId])
GO

ALTER TABLE [dbo].[Pno12FixedParameters]  WITH CHECK ADD FOREIGN KEY([Pno12Id])
REFERENCES [dbo].[Pno12] ([Pno12Id])
GO
