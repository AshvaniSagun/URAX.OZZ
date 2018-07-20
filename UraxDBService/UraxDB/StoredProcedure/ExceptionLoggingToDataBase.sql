CREATE PROCEDURE [dbo].[ExceptionLoggingToDataBase]
	(  
@ExceptionMsg varchar(100)=null,  
@ExceptionType varchar(100)=null,  
@ExceptionSource nvarchar(max)=null,  
@ExceptionURL varchar(100)=null  
)  
AS  
BEGIN  
Insert into ExceptionLog  
(  
ExceptionMsg ,  
ExceptionType,   
ExceptionSource,  
ExceptionURL,  
Logdate  
)  
SELECT  
@ExceptionMsg,  
@ExceptionType,  
@ExceptionSource,  
@ExceptionURL,  
GETUTCDATE()  

SELECT 'Success'
END  
