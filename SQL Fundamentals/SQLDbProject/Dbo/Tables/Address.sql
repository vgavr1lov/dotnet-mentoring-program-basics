CREATE TABLE [dbo].[Address]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [Street] nvarchar(50) NOT NULL,
    [City] nvarchar(50) NULL,
    [State] nvarchar(50) NULL,
    [ZipCode] nvarchar(50) NULL

)
