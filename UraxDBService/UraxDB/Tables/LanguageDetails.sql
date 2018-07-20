CREATE TABLE [dbo].[LanguageDetails] (
    [LanguageDetailsId] INT           IDENTITY (1, 1) NOT NULL,
    [TaxMasterId]       BIGINT        NOT NULL,
    [LanguageId]        INT           NOT NULL,
    [TaxName]           NVARCHAR(200) NOT NULL,
	[IsDefault]			BIT           CONSTRAINT [DF_LanguageDetails_IsDefault] DEFAULT ((0)) NOT NULL,
    [IsActive]          BIT           CONSTRAINT [DF_LanguageDetails_IsActive] DEFAULT ((1)) NOT NULL,
    [CreatedBy]         VARCHAR (200) NOT NULL,
    [CreatedOn]         DATETIME      CONSTRAINT [DF_LanguageDetails_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [UpdatedBy]         VARCHAR (200) NOT NULL,
    [UpdatedOn]         DATETIME      CONSTRAINT [DF_LanguageDetails_UpdatedOn] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_LanguageDetails_LanguageId] PRIMARY KEY CLUSTERED ([LanguageDetailsId] ASC),
    CONSTRAINT [fk_LanguageDetails_LanguageId] FOREIGN KEY ([LanguageId]) REFERENCES [dbo].[Languages] ([LanguageId]),
    CONSTRAINT [fk_LanguageDetails_TaxMasterId] FOREIGN KEY ([TaxMasterId]) REFERENCES [dbo].[TaxMaster] ([TaxMasterId])
);
GO
	CREATE UNIQUE INDEX IX_LanguageDetails_TaxMasterId_IsDefault
    ON LanguageDetails(TaxMasterId)
    WHERE IsDefault = 1
GO
