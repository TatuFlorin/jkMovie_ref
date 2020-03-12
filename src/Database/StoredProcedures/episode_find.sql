CREATE PROCEDURE [dbo].[episode_find]
	@tvid int,
	@seasonNumber int,
	@episodeNumber int
AS
	BEGIN

	SET NOCOUNT ON;

	IF EXISTS ( SELECT * FROM dbo.Episodes WHERE tvId = @tvid AND episodeNumber = @episodeNumber AND seasonNumber = @seasonNumber)
		SELECT 1
	ELSE
		SELECT 0
	END
