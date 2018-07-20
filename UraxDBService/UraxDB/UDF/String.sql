CREATE FUNCTION String(@Col2 VARCHAR(MAX))
RETURNS   @Result TABLE (value nvarchar(max))
AS
BEGIN
  DECLARE @startingposition INT
  DECLARE @InputString VARCHAR(max) = @Col2
  DECLARE @parts nvarchar(max)
  SELECT @startingposition = 1
WHILE @startingposition !=0
  BEGIN
    SELECT @startingposition = CHARINDEX(',',@InputString)
     IF @startingposition !=0
        SELECT @parts = LEFT(@InputString,@startingposition - 1)
     ELSE
        SELECT @parts = @InputString
        INSERT INTO @Result(value) VALUES(@parts)
        SELECT @InputString = RIGHT(@InputString,LEN(@InputString) - @startingposition)
  END
RETURN;
END
