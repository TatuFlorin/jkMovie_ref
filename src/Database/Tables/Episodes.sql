CREATE TABLE [dbo].[Episodes]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [tvId] INT NOT NULL, 
    [videoSource] NVARCHAR(MAX) NOT NULL, 
    [seasonNumber] INT NOT NULL, 
    [episodeNumber] INT NOT NULL, 
    [name] NVARCHAR(50) NULL, 
    [overview] NVARCHAR(MAX) NULL, 
    [image] NVARCHAR(MAX) NULL
)
