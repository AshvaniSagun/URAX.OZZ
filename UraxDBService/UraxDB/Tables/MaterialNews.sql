CREATE TABLE [dbo].[MaterialNews] (
    [MNId]             INT             IDENTITY (1, 1) NOT NULL,
    [ContentTypeId]    BIGINT          NULL,
    [ContentHeading]   VARCHAR (1000)  NOT NULL,
    [ContentText]      VARCHAR (MAX)   NOT NULL,
    [PublishStartDate] DATE            NULL,
    [PublishEndDate]   DATE            NULL,
    [ImageUrl]         VARCHAR (1000)  NULL,
    [ImageName]        VARCHAR (500)   NULL,
    [IsActive]         BIT             CONSTRAINT [DF_MaterialNews_IsActive] DEFAULT ((1)) NOT NULL,
    [CreatedBy]        VARCHAR (200)   NOT NULL,
    [CreatedOn]        DATETIME        CONSTRAINT [DF_MaterialNews_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [UpdatedBy]        VARCHAR (200)   NULL,
    [UpdatedOn]        DATETIME        CONSTRAINT [DF_MaterialNews_UpdatedOn] DEFAULT (getdate()) NULL,
    [ImageData]        VARBINARY (MAX) NULL,
    CONSTRAINT [PK_MaterialNews_MNId] PRIMARY KEY CLUSTERED ([MNId] ASC),
    CONSTRAINT [CK_MaterialNews_ContentTypeId] CHECK ([dbo].[ufn_ChkParamIdByGroupId]([ContentTypeId],(7))=(1))
);
GO
--ALTER TABLE [dbo].[MaterialNews]  WITH CHECK ADD  CONSTRAINT [CK_MaterialNews_OverlappingDateRange] 
--CHECK  ([dbo].[ufn_checkOverlappingMaterialNewsDateRange]([PublishStartDate],[PublishEndDate])<>(0))
--GO

