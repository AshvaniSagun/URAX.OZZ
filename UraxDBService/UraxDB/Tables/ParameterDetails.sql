CREATE TABLE [dbo].[ParameterDetails] (
    [ParameterId]      INT           NOT NULL,
    [ParameterGroupId] INT           NOT NULL,
    [Value]            VARCHAR (500) NOT NULL,
    [IsActive]         BIT           CONSTRAINT [DF_ParameterDetails_IsActive] DEFAULT ((1)) NOT NULL,
    [CreatedBy]        VARCHAR (200) NOT NULL,
    [CreatedOn]        DATETIME      CONSTRAINT [DF_ParameterDetails_CreatedOn] DEFAULT (GETUTCDATE()) NOT NULL,
    [UpdatedBy]        VARCHAR (200) NOT NULL,
    [UpdatedOn]        DATETIME      CONSTRAINT [DF_ParameterDetails_UpdatedOn] DEFAULT (GETUTCDATE()) NOT NULL,
	[ParameterCode] [varchar](1000) NULL,
    CONSTRAINT [PK_ParameterDetails_ParameterId] PRIMARY KEY CLUSTERED ([ParameterId] ASC),
    FOREIGN KEY ([ParameterGroupId]) REFERENCES [dbo].[ParameterGroupMaster] ([ParameterGroupId]),
    CONSTRAINT [UQ_ParameterDetails_ParameterGrouoIdValue] UNIQUE NONCLUSTERED ([ParameterGroupId] ASC, [Value] ASC)
);
GO

