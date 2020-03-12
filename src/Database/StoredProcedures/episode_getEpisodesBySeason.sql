CREATE PROCEDURE [dbo].[episode_getEpisodesBySeason]
	@Id int,
	@seasonNumber int
AS
BEGIN
	SELECT * FROM [dbo].Episodes WHERE tvId = @Id AND seasonNumber = @seasonNumber
END
