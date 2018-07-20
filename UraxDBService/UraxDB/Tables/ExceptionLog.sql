CREATE TABLE [dbo].[ExceptionLog]
(  
    [Logid] [bigint] IDENTITY(1,1) NOT NULL,  
    [ExceptionMsg] [varchar](100) NULL,  
    [ExceptionType] [varchar](100) NULL,  
    [ExceptionSource] [nvarchar](max) NULL,  
    [ExceptionURL] [varchar](100) NULL,  
    [Logdate] [datetime]   NOT NULL CONSTRAINT  DF_ExceptionLog_datetime DEFAULT GETUTCDATE(),  
 CONSTRAINT [PK_ExceptionLog_Logid] PRIMARY KEY CLUSTERED   
(  
    [Logid] ASC  
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]  
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]  
  
GO  
