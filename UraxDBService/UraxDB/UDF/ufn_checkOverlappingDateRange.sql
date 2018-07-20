CREATE FUNCTION [dbo].[ufn_checkOverlappingDateRange]
(
	@TaxVersionId as bigint
	,@TaxMasterId as int
    ,@StartDate AS DATETIME
    ,@EndDate AS DATETIME
)
RETURNS BIT 
AS
BEGIN

  DECLARE @chkduplicate BIT
    BEGIN
      IF EXISTS  ( SELECT 1 FROM [dbo].[TaxVersion]    WHERE TaxVersionId <> @TaxVersionId and TaxMasterId = @TaxMasterId    AND @EndDate >= StartDate	 AND EndDate >= @StartDate  )
        BEGIN
          SET @chkduplicate=0
        END
    ELSE
      BEGIN
            SET @chkduplicate=1
      END
    END
  RETURN @chkduplicate
END
