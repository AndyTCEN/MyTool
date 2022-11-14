SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER FUNCTION [dbo].[splitstring] ( @splitChar VARCHAR(MAX),@stringToSplit VARCHAR(MAX) )
RETURNS
 @returnList TABLE ([Name] [nvarchar] (500),[RowNum] [int])
AS
BEGIN

 DECLARE @name NVARCHAR(255)
 DECLARE @pos INT
 DECLARE @ronnum INT=1

 WHILE CHARINDEX(@splitChar, @stringToSplit) > 0
 BEGIN
  SELECT @pos  = CHARINDEX(@splitChar, @stringToSplit)  
  SELECT @name = SUBSTRING(@stringToSplit, 1, @pos-1)

  INSERT INTO @returnList 
  SELECT @name,@ronnum

  SELECT @stringToSplit = SUBSTRING(@stringToSplit, @pos+1, LEN(@stringToSplit)-@pos)
  SET @ronnum+=1
 END

 INSERT INTO @returnList
 SELECT @stringToSplit,@ronnum

 RETURN
END