CREATE TABLE [dbo].[Order]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Status] NVARCHAR(10) NOT NULL, 
    [CreateDate] DATE NOT NULL, 
    [UpdateDate] DATE NOT NULL, 
    [ProductId] INT NOT NULL, 
    CONSTRAINT [FK_Order_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id])
)
