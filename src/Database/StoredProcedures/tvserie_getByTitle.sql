CREATE PROCEDURE [dbo].[tvserie_getByTitle]
	@title nvarchar(128)
AS
BEGIN
	SELECT * FROM dbo.TvSeries WHERE title = @title
END
