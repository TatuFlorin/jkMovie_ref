CREATE PROCEDURE [dbo].[episode_remove]
	@Id int
AS
BEGIN
	DELETE FROM [dbo].[Episodes] WHERE Id = @Id
END
