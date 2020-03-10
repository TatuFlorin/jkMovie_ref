CREATE PROCEDURE [dbo].[movie_save]
	@Id int,
	@videoSource nvarchar(MAX),
	@title nvarchar(50),
	@poster nvarchar(MAX),
	@voteAverage real,
	@isPosted bit
AS
BEGIN
	INSERT INTO [dbo].Movies (Id, videoSource, title, poster, voteAverage, isPosted)
	VALUES (@Id, @videoSource, @title, @poster, @voteAverage, @isPosted)
END
