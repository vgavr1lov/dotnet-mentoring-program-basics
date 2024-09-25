CREATE TABLE [dbo].[Employee]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [AddressId] int not null,
    [PersonId] int not null,
    [CompanyName] nvarchar(20) not null,
    [Position] nvarchar(30) null,
    [EmployeeName] nvarchar(100) null, 
    CONSTRAINT [FK_Employee_Address] FOREIGN KEY ([AddressId]) REFERENCES [Address]([Id]), 
    CONSTRAINT [FK_Employee_Person] FOREIGN KEY ([PersonId]) REFERENCES [Person]([Id])

)
