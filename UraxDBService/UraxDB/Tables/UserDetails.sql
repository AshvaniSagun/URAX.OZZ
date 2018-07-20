CREATE TABLE [dbo].[UserDetails] (
    [UDetailsId]     BIGINT        IDENTITY (1, 1) NOT NULL,
    [CDSID]          VARCHAR (100) NULL,
    [FirstName]      VARCHAR (500) NOT NULL,
    [MiddeName]      VARCHAR (500) NULL,
    [LastName]       VARCHAR (200) NULL,
    [PhoneNo]        VARCHAR (25)  NULL,
    [OfficialEmail]  VARCHAR (500) NULL,
    [PersionalEMail] VARCHAR (500) NULL,
    [StatusID]       INT           NULL,
    [UserTypeId]     INT           NULL,
    [IsActive]       BIT           CONSTRAINT [DF_UserDetails_IsActive] DEFAULT ((1)) NULL,
    [LoginDateUTC]   DATETIME      CONSTRAINT [DF_UserDetails_LoginDateUTC] DEFAULT (GETUTCDATE()) NULL,
    [CreatedBy]      VARCHAR (500) NULL,
    [CreatedOn]      DATETIME      CONSTRAINT [DF_UserDetails_CreatedOn] DEFAULT (GETUTCDATE()) NULL,
    [UpdatedBy]      VARCHAR (500) NULL,
    [UpdatedOn]      DATETIME      CONSTRAINT [DF_UserDetails_UpdatedOn] DEFAULT (GETUTCDATE()) NULL,
    CONSTRAINT [PK_UserDetails_UDetailsId] PRIMARY KEY CLUSTERED ([UDetailsId] ASC),
    CONSTRAINT [UQ_UserDetails_CDSID] UNIQUE NONCLUSTERED ([CDSID] ASC)
);
GO

