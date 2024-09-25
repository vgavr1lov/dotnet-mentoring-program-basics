CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Description] NVARCHAR(50) NOT NULL, 
    [Weight] NUMERIC(18, 2) NOT NULL, 
    [Height] NUMERIC(18, 2) NOT NULL, 
    [Width] NUMERIC(18, 2) NOT NULL, 
    [Length] NUMERIC(18, 2) NOT NULL
)
