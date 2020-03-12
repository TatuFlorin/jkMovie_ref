CREATE PROCEDURE [dbo].[tvserie_getById]
	@Id int
AS
BEGIN
	SELECT * FROM [dbo].[TvSeries] WHERE Id = @Id
END
