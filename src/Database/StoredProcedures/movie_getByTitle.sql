CREATE PROCEDURE [dbo].[movie_getByTitle]
	@title nvarchar(128)
AS
BEGIN
	SELECT * FROM dbo.Movies WHERE title = @title
END
