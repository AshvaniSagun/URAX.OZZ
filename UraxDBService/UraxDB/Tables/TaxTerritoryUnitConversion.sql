CREATE TABLE [dbo].[TaxTerritoryUnitConversion](
	[CountryCodeId] [int] NOT NULL CONSTRAINT FK_Country_CountryCodeId FOREIGN KEY REFERENCES dbo.CountryCode(CountryCodeId),
	[UnitConversionId] [int] NOT NULL CONSTRAINT FK_UnitConversion_UnitConversionId FOREIGN KEY REFERENCES dbo.UnitConversion(UnitConversionId),
	[CreatedBy] [varchar](200) NULL,
	[CreatedOn] [datetime] CONSTRAINT [DF_TaxTerritoryUnitConversion_CreatedOn] DEFAULT (GETUTCDATE()) NOT NULL,
	[UpdatedBy] [varchar](200) NULL,
	[UpdatedOn] [datetime] CONSTRAINT [DF_TaxTerritoryUnitConversion_UpdatedOn] DEFAULT (GETUTCDATE()) NOT NULL,
 CONSTRAINT [pk_TaxTerUnitConv] PRIMARY KEY CLUSTERED 
(
	[CountryCodeId] ASC,
	[UnitConversionId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
