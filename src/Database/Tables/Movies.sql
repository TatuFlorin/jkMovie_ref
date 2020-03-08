CREATE TABLE [dbo].[Movies]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [title] NVARCHAR(100) NOT NULL, 
    [poster] NVARCHAR(MAX) NOT NULL, 
    [voteAverage] REAL NOT NULL, 
    [videoSource] NVARCHAR(MAX) NOT NULL, 
    [isPosted] BIT NOT NULL
)
