CREATE FUNCTION [dbo].[ufn_ChkFormulaPriority]
(
	@VariableId as bigint
	,@Priority as int
)
RETURNS BIT 
AS
BEGIN

  DECLARE @chkValidPId BIT
    BEGIN
	Declare @TaxId int = (Select TOP 1 vre.TaxId from Variable vre where vre.VariableId =@VariableId)
      IF  EXISTS  ( Select 1 from Formula frm inner join Variable vre on frm.VariableId = vre.VariableId AND  vre.TaxId=@TaxId AND frm.VariableId !=@VariableId AND frm.[Priority] =@Priority)
        BEGIN
          SET @chkValidPId = 0
        END
    ELSE
      BEGIN
            SET @chkValidPId = 1 
      END
    END
  RETURN @chkValidPId
END
