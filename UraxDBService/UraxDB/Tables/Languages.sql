CREATE TABLE [dbo].[Languages] (
    [LanguageId]          INT           NOT NULL,
    [CountryCode]         VARCHAR (10)  NULL,
    [Language]            VARCHAR (200) NOT NULL,
    [LanguageCountrycode] VARCHAR (200) NULL,
    [IsActive]            BIT           CONSTRAINT [DF_Languages_IsActive] DEFAULT ((1)) NOT NULL,
    [CreatedBy]           VARCHAR (200) NOT NULL,
    [CreatedOn]           DATETIME      CONSTRAINT [DF_Languages_CreatedOn] DEFAULT (GETUTCDATE()) NOT NULL,
    [UpdatedBy]           VARCHAR (200) NOT NULL,
    [UpdatedOn]           DATETIME      CONSTRAINT [DF_Languages_UpdatedOn] DEFAULT (GETUTCDATE()) NOT NULL,
    CONSTRAINT [PK_Languages_LanguageId] PRIMARY KEY CLUSTERED ([LanguageId] ASC)
);
GO

