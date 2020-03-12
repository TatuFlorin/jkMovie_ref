CREATE PROCEDURE [dbo].[tvserie_remove]
	@Id int
AS
BEGIN
	DELETE FROM [dbo].TvSeries WHERE Id = @Id
END
