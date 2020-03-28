CREATE PROCEDURE [dbo].[episode_getLastEpisode]
	@Id int
AS
BEGIN
	SELECT * FROM [dbo].[Episodes] WHERE tvId = @Id
	ORDER BY seasonNumber, episodeNumber
END
