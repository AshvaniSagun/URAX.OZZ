CREATE TABLE [dbo].[Pno12ParameterDefinition]
(
	[Pno12PdId] [int] IDENTITY(1,1) CONSTRAINT PK_Pno12ParameterDefinition_Pno12PdId PRIMARY KEY NOT NULL ,
	[DefinitionName] [varchar](200) NULL,
	[ShortName] [varchar](200) NULL,
	[DataType] [varchar](200) NULL,
	[Pno12PtId] [int] NOT NULL Constraint fk_Pno12ParameterDefinition_Pno12PtId foreign key references [dbo].[Pno12ParameterType] ([Pno12PtId]),
	[Pno12UomId] [int] NOT  NULL Constraint fk_Pno12ParameterDefinition_Pno12UomId foreign key references [dbo].[Pno12UnitOfMeasurement] ([Pno12UomId]),
	[Description] [varchar](200) NULL,
	[CreatedBy] [varchar](200) NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [varchar](200) NULL,
	[ModifiedOn] [datetime] NULL
)
