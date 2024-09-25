CREATE TABLE [dbo].[Company]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [Name] nvarchar(20) not null,
    [AddressId] int not null, 
    CONSTRAINT [FK_Company_Address] FOREIGN KEY ([AddressId]) REFERENCES [Address]([Id])



)
