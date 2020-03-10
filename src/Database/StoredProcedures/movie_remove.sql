CREATE PROCEDURE [dbo].[movie_remove]
	@Id int
AS
BEGIN
	DELETE FROM [dbo].[Movies] WHERE Id = @Id
END
