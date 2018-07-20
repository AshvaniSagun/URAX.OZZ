CREATE  FUNCTION [dbo].[ufn_ChkParamIdByGroupId]
(
	@ParameterId as int
	,@ParameterGroupId as int
)
RETURNS BIT 
AS
BEGIN

  DECLARE @chkValidId BIT
    BEGIN
      IF NOT EXISTS  ( SELECT 1 FROM [dbo].[ParameterDetails] pd   WHERE pd.ParameterId =@ParameterId and pd.ParameterGroupId =@ParameterGroupId)
        BEGIN
          SET @chkValidId = 0
        END
    ELSE
      BEGIN
            SET @chkValidId = 1 
      END
    END
  RETURN @chkValidId
END
GO

