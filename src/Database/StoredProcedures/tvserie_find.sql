CREATE PROCEDURE [dbo].[tvserie_find]
	@Id int
AS
BEGIN

	SET NOCOUNT ON;

	IF EXISTS (SELECT * FROM [dbo].[TvSeries] WHERE Id = @Id)
		SELECT 1
		ELSE
		SELECT 0
END
