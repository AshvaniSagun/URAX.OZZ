CREATE TABLE [dbo].[UnitConversion](
	[UnitConversionId] [int] IDENTITY(1,1) NOT NULL,
	[FromUnitOfMeasurementId] [int] NULL CONSTRAINT FK_From_Pno12UnitOfMeasurement_Pno12UomId FOREIGN KEY REFERENCES dbo.Pno12UnitOfMeasurement(Pno12UomId),
	[ToUnitOfMeasurementId] [int] NULL CONSTRAINT FK_To_Pno12UnitOfMeasurement_Pno12UomId FOREIGN KEY REFERENCES dbo.Pno12UnitOfMeasurement(Pno12UomId),
	[ConversionRate] [decimal](18,12) NULL,
	[CreatedBy] [varchar](200) NULL,
	[CreatedOn] [datetime] CONSTRAINT [DF_UnitConversion_CreatedOn] DEFAULT (GETUTCDATE()) NOT NULL,
	[ModifiedBy] [varchar](200) NULL,
	[ModifiedOn] [datetime] CONSTRAINT [DF_UnitConversion_ModifiedOn] DEFAULT (GETUTCDATE()) NOT NULL,
 CONSTRAINT [PK_UnitConversion_UnitConversionId] PRIMARY KEY CLUSTERED 
(
	[UnitConversionId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

