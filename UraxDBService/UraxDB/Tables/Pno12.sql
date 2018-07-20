CREATE TABLE [dbo].[Pno12]
(
	[Pno12Id] [int]  IDENTITY(1,1) CONSTRAINT PK_Pno12_Pno12Id PRIMARY KEY  NOT NULL,
	[Pno12] [varchar](50) NULL,
	[ModelYear] [varchar](4) NULL,
	[CarLine] [varchar](100) NULL,
	[CreatedBy] [varchar](200) NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [varchar](200) NULL,
	[ModifiedOn] [datetime] NULL,
	[MarketId] [bigint] NOT NULL 
)
