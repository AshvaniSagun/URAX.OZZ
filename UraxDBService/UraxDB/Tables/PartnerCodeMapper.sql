CREATE TABLE [dbo].[PartnerCodeMapper]
(
	[PartnerCodeMapperId] INT  IDENTITY (1, 1) NOT NULL CONSTRAINT [PK_PartnerCodeMapper_PartnerCodeMapperId] PRIMARY KEY,
    [PartnerCode]  VARCHAR(500)  NOT NULL,
    [GCCTaxPartnerCode] VARCHAR(500)        NOT NULL,
	[MarketId]    BIGINT NOT NULL CONSTRAINT [fk_PartnerCodeMapper_MarketId] FOREIGN KEY ([MarketId]) REFERENCES [dbo].[Market] (MarketId),
    [IsActive]    BIT   CONSTRAINT [DF_PartnerCodeMapper_IsActive] DEFAULT ((1)) NOT NULL,
    [CreatedBy]   VARCHAR (200) NOT NULL,
    [CreatedOn]   DATETIME      CONSTRAINT [DF_PartnerCodeMapper_CreatedOn] DEFAULT (GETUTCDATE()) NOT NULL,
    [UpdatedBy]   VARCHAR (200) NOT NULL,
    [UpdatedOn]   DATETIME      CONSTRAINT [DF_PartnerCodeMapper_UpdatedOn] DEFAULT (GETUTCDATE()) NOT NULL
);
GO
CREATE INDEX CI_PartnerCodeMapper_MarketId_PartnerCode_GCCTaxPartnerCode ON PartnerCodeMapper (MarketId,PartnerCode, GCCTaxPartnerCode);
GO
