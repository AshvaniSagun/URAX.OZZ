CREATE TABLE [dbo].[LookupGroupDetail] (
    [GroupDetailsId]    BIGINT        IDENTITY (1, 1) NOT NULL,
    [LookUpGroupId]     BIGINT        NOT NULL,
    [VariableId]        BIGINT        NOT NULL,
    [LookupRangeTypeId] INT           NULL,
    [IsActive]          BIT           CONSTRAINT [DF_LookupGroupDetail_IsActive] DEFAULT ((1)) NOT NULL,
    [CreatedBy]         VARCHAR (200) NOT NULL,
    [CreatedOn]         DATETIME      CONSTRAINT [DF_LookupGroupDetail_CreatedOn] DEFAULT (GETUTCDATE()) NOT NULL,
    [UpdatedBy]         VARCHAR (200) NOT NULL,
    [UpdatedOn]         DATETIME      CONSTRAINT [DF_LookupGroupDetail_UpdatedOn] DEFAULT (GETUTCDATE()) NOT NULL,
    CONSTRAINT [PK_LookupGroupDetail_GroupDetailsId] PRIMARY KEY CLUSTERED ([GroupDetailsId] ASC),
    CONSTRAINT [fk_LookupGroupDetail_LookUpGroupId] FOREIGN KEY ([LookUpGroupId]) REFERENCES [dbo].[LookUpGroup] ([LookUpGroupId]),
    CONSTRAINT [fk_LookupGroupDetail_LookupRangeTypeId] FOREIGN KEY ([LookupRangeTypeId]) REFERENCES [dbo].[ParameterDetails] ([ParameterId]),
    CONSTRAINT [FK_LookupGroupDetail_VariableId] FOREIGN KEY ([VariableId]) REFERENCES [dbo].[Variable] ([VariableId])
);
GO

