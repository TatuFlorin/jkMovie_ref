CREATE PROCEDURE [dbo].[episode_save]
	@seasonNumber int,
	@tvId int,
	@videoSource nvarchar(MAX),
	@episodeNumber int
AS
BEGIN
	INSERT INTO [dbo].[Episodes] (tvId, seasonNumber, episodeNumber, videoSource)
	VALUES (@tvId, @seasonNumber, @episodeNumber, @videoSource)
END
