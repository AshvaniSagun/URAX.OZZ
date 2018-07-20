CREATE TABLE [dbo].[UserRoles] (
    [UserRoleId]    BIGINT        IDENTITY (1, 1) NOT NULL,
    [UDetailsId]    BIGINT        NULL,
    [CountryCodeID] BIGINT        NULL,
    [AccessLevelId] INT           NULL,
    [Authorization] VARCHAR (500) NULL,
    [IsActive]      BIT           CONSTRAINT [DF_UserRoles_IsActive] DEFAULT ((1)) NULL,
    [CreatedBy]     VARCHAR (500) NULL,
    [CreatedOn]     DATETIME      CONSTRAINT [DF_UserRoles_CreatedOn] DEFAULT (GETUTCDATE()) NULL,
    [UpdatedBy]     VARCHAR (500) NULL,
    [UpdatedOn]     DATETIME      CONSTRAINT [DF_UserRoles_UpdatedOn] DEFAULT (GETUTCDATE()) NULL,
    CONSTRAINT [PK_UserRoles_UserRoleId] PRIMARY KEY CLUSTERED ([UserRoleId] ASC),
    CONSTRAINT [FK_UserRoles_UDetailsId] FOREIGN KEY ([UDetailsId]) REFERENCES [dbo].[UserDetails] ([UDetailsId])
);
GO

