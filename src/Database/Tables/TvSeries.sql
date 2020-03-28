CREATE TABLE [dbo].[TvSeries]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [title] NVARCHAR(50) NOT NULL, 
    [poster] NVARCHAR(MAX) NOT NULL, 
    [voteAverage] REAL NOT NULL, 
    [isPosted] BIT NOT NULL, 
    [numberOfSeasons] INT NOT NULL
)
