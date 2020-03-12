CREATE PROCEDURE [dbo].[episode_getTvEpisodes]
	@Id int
AS
BEGIN
	SELECT * FROM [dbo].[Episodes] WHERE tvId = @Id
END
