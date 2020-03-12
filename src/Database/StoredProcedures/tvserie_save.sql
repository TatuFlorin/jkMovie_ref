CREATE PROCEDURE [dbo].[tvserie_save]
	@Id int,
	@title nvarchar(50),
	@poster nvarchar(MAX),
	@voteAverage real,
	@isPosted bit
AS
BEGIN
	INSERT INTO [dbo].[TvSeries] (Id, title, poster, voteAverage, isPosted)
	VALUES (@Id, @title, @poster, @voteAverage, @isPosted)
END
