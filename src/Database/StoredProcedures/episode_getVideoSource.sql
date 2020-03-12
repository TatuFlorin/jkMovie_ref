CREATE PROCEDURE [dbo].[episode_getVideoSource]
	@id int,
	@episodeNumber int,
	@seasonNumber int
AS
BEGIN
SELECT videoSource FROM [dbo].Episodes WHERE episodeNumber = @episodeNumber AND seasonNumber = @seasonNumber
END
