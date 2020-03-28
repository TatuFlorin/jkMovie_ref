CREATE TABLE [dbo].[Episodes]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [tvId] INT NOT NULL, 
    [videoSource] NVARCHAR(MAX) NOT NULL, 
    [seasonNumber] INT NOT NULL, 
    [episodeNumber] INT NOT NULL 
)
