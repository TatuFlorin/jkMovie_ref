CREATE PROCEDURE [dbo].[movie_getById]
	@Id int
AS
BEGIN
	SELECT * FROM [dbo].[Movies] WHERE Id = @Id
END
