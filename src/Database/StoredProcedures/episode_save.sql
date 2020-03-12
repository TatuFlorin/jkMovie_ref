CREATE PROCEDURE [dbo].[episode_save]
	@seasonNumber int,
	@tvId int,
	@videoSource nvarchar(MAX),
	@episodeNumber int,
	@overview nvarchar(MAX),
	@episodeName nvarchar(50),
	@stillPath nvarchar(MAX)
AS
BEGIN
	INSERT INTO [dbo].[Episodes] (tvId, seasonNumber, episodeNumber, name, videoSource, overview, image)
	VALUES (@tvId, @seasonNumber, @episodeNumber, @episodeName, @videoSource, @overview, @stillPath)
END
