CREATE FUNCTION [dbo].[ufn_checkOverlappingMaterialNewsDateRange]
(
@DateStart AS DATE
,@DateEnd AS DATE
)
RETURNS BIT 
AS
BEGIN
  DECLARE @retval BIT
  IF(@DateEnd IS NULL OR @DateEnd = '0001-01-01')
  BEGIN
  SET @DateEnd ='9999-12-31'
  END
  IF (DATEDIFF(day,@DateStart,@DateEnd) < 1)
    BEGIN
      SET @retval=0
    END
  ELSE
      BEGIN
            SET @retval=1
          END
  RETURN @retval
END