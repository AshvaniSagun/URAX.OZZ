CREATE TABLE [dbo].[LookUpDetails] (
    [LookUpId]       BIGINT        IDENTITY (1, 1) NOT NULL,
    [LookUpGroup]    INT           NOT NULL,
    [GroupDetailsId] BIGINT        NULL,
    [Value]          VARCHAR (200) NULL,
    [CreatedBy]      VARCHAR (200) NOT NULL,
    [CreatedOn]      DATETIME      CONSTRAINT [DF_LookUpDetails_CreatedOn] DEFAULT (GETUTCDATE()) NULL,
    [UpdatedBy]      VARCHAR (200) NOT NULL,
    [UpdatedOn]      DATETIME      CONSTRAINT [DF_LookUpDetails_UpdatedOn] DEFAULT (GETUTCDATE()) NULL,
    CONSTRAINT [PK_LookUpDetails_LookUpId] PRIMARY KEY CLUSTERED ([LookUpId] ASC),
    CONSTRAINT [FK_LookUpDetails_GroupDetailsId] FOREIGN KEY ([GroupDetailsId]) REFERENCES [dbo].[LookupGroupDetail] ([GroupDetailsId])
)

