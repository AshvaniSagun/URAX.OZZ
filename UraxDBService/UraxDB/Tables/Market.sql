CREATE TABLE [dbo].[Market] (
    [MarketId]      BIGINT        IDENTITY (1, 1) NOT NULL,
    [CountryCodeId] INT           NOT NULL,
    [TaxPartnerGroup] VARCHAR (20)   NULL,
    [currencyId]    INT           NOT NULL,
	[SubdivisionCode] [varchar](50) NULL,
	[TaxTerritory] [varchar](50) NOT NULL,
	[FeatureLevelTax] [bit] NOT NULL CONSTRAINT [DF_Market_FeatureLevelTax]  DEFAULT ((0)),
    [IsActive]      BIT           CONSTRAINT [DF_Market_IsActive] DEFAULT ((1)) NOT NULL,
    [CreatedBy]     VARCHAR (200) NOT NULL,
    [CreatedOn]     DATETIME      CONSTRAINT [DF_Market_CreatedOn] DEFAULT (GETUTCDATE()) NOT NULL,
    [UpdatedBy]     VARCHAR (200) NOT NULL,
    [UpdatedOn]     DATETIME      CONSTRAINT [DF_Market_UpdatedOn] DEFAULT (GETUTCDATE()) NOT NULL,
    CONSTRAINT [PK_Market_MarketId] PRIMARY KEY CLUSTERED ([MarketId] ASC),
    CONSTRAINT [FK_Market_CountryCodeId] FOREIGN KEY ([CountryCodeId]) REFERENCES [dbo].[CountryCode] ([CountryCodeId]),
    CONSTRAINT [FK_Market_currencyId] FOREIGN KEY ([currencyId]) REFERENCES [dbo].[CurrencyDetails] ([CurrencyId])
   
);
GO
ALTER TABLE dbo.Market
ADD CONSTRAINT UQ_Market_CountryCodeId_TaxTerritory UNIQUE(CountryCodeId,TaxTerritory)
GO