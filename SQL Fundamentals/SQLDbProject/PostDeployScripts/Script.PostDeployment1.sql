/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
INSERT INTO dbo.Person (FirstName, LastName)
SELECT FirstName, LastName
FROM (VALUES 
    ('Solomon', 'Noskov'),
    ('Kliment', 'Kudryashov'),
    ('Apollinariy', 'Teterin'),
    ('Antonina', 'Krylova'),
    ('Aleksandra', 'Pestova'),
    ('Pelageya', 'Kozlova')
) AS source (FirstName, LastName)
WHERE NOT EXISTS (
    SELECT 1 
    FROM dbo.Person AS [target] 
    WHERE [target].FirstName = source.FirstName 
      AND [target].LastName = source.LastName
);

INSERT INTO dbo.[Address](Street, City, [State], ZipCode)
SELECT Street, City, [State], ZipCode
FROM (VALUES 
    ('Ulitsa Lenina, 14', 'Moscow', 'Moscow', '101000'),
    ('Prospekt Mira, 35', 'Saint Petersburg', 'Leningrad Oblast', '190000'),
    ('Prospekt Pobedy, 22', 'Novosibirsk', 'Novosibirsk Oblast', '630000'),
    ('Ulitsa Gagarina, 2', 'Yekaterinburg', 'Sverdlovsk Oblast', '620000'),
    ('Prospekt Nezavisimosti, 35', 'Minsk', '', '220005'),
    ('Prospekt Pobediteley, 22', 'Minsk', '', '220020')
) AS source (Street, City, [State], ZipCode)
WHERE NOT EXISTS (
    SELECT 1 
    FROM dbo.[Address] AS [target] 
    WHERE [target].Street = source.Street 
      AND [target].City = source.City
      AND [target].[State] = source.[State]
      AND [target].ZipCode = source.ZipCode
);

DECLARE @PersonId_Noskov INT, @PersonId_Kudryashov INT, @PersonId_Teterin INT,
@PersonId_Krylova INT, @PersonId_Pestova INT, @PersonId_Kozlova INT;

DECLARE @AddressId_UlitsaLenina INT, @AddressId_ProspektMira INT, @AddressId_ProspektPobedy INT,
@AddressId_UlitsaGagarina INT, @AddressId_ProspektNezavisimosti INT, @AddressId_ProspektPobediteley INT;

SELECT @PersonId_Noskov = Id FROM Person WHERE FirstName = 'Solomon' AND LastName = 'Noskov';
SELECT @PersonId_Kudryashov = Id FROM Person WHERE FirstName = 'Kliment' AND LastName = 'Kudryashov';
SELECT @PersonId_Teterin = Id FROM Person WHERE FirstName = 'Apollinariy' AND LastName = 'Teterin';
SELECT @PersonId_Krylova = Id FROM Person WHERE FirstName = 'Antonina' AND LastName = 'Krylova';
SELECT @PersonId_Pestova = Id FROM Person WHERE FirstName = 'Aleksandra' AND LastName = 'Pestova';
SELECT @PersonId_Kozlova = Id FROM Person WHERE FirstName = 'Pelageya' AND LastName = 'Kozlova';

SELECT @AddressId_UlitsaLenina = Id FROM Address WHERE Street = 'Ulitsa Lenina, 14' AND City = 'Moscow';
SELECT @AddressId_ProspektMira = Id FROM Address WHERE Street = 'Prospekt Mira, 35' AND City = 'Saint Petersburg';
SELECT @AddressId_ProspektPobedy = Id FROM Address WHERE Street = 'Prospekt Pobedy, 22' AND City = 'Novosibirsk';
SELECT @AddressId_UlitsaGagarina = Id FROM Address WHERE Street = 'Ulitsa Gagarina, 2' AND City = 'Yekaterinburg';
SELECT @AddressId_ProspektNezavisimosti = Id FROM Address WHERE Street = 'Prospekt Nezavisimosti, 35' AND City = 'Minsk';
SELECT @AddressId_ProspektPobediteley = Id FROM Address WHERE Street = 'Prospekt Pobediteley, 22' AND City = 'Minsk';

DECLARE @EPAMcompany nvarchar(20) = 'EPAM';

INSERT INTO dbo.Employee(AddressId, PersonId, CompanyName, Position, EmployeeName)
SELECT AddressId, PersonId, CompanyName, Position, EmployeeName
FROM (VALUES 
    (@AddressId_UlitsaLenina, @PersonId_Noskov, @EPAMcompany, 'Manager', 'Solomon Noskov'),
    (@AddressId_ProspektMira, @PersonId_Kudryashov, @EPAMcompany, 'Junior Developer', 'Kliment Kudryashov'),
    (@AddressId_ProspektPobedy, @PersonId_Teterin, @EPAMcompany, 'Tester', 'Apollinariy Teterin'),
    (@AddressId_UlitsaGagarina, @PersonId_Krylova, @EPAMcompany, 'Junior Developer', 'Antonina Krylova'),
    (@AddressId_ProspektNezavisimosti, @PersonId_Pestova, @EPAMcompany, 'Senior Developer', 'Aleksandra Pestova'),
    (@AddressId_ProspektPobediteley, @PersonId_Kozlova, @EPAMcompany, 'Tester', 'Pelageya Kozlova')
) AS source (AddressId, PersonId, CompanyName, Position, EmployeeName)
WHERE NOT EXISTS (
    SELECT 1 
    FROM dbo.Employee AS [target] 
    WHERE [target].AddressId = source.AddressId 
      AND [target].PersonId = source.PersonId
      AND [target].CompanyName = source.CompanyName
      AND [target].Position = source.Position
      AND [target].EmployeeName = source.EmployeeName
);

IF NOT EXISTS (SELECT * FROM dbo.[Address] WHERE Street = 'Academician Kuprevich Street, 1' AND City = 'Minsk' AND ZipCode = '220141')
BEGIN
    INSERT INTO dbo.[Address](Street, City, [State], ZipCode)
    VALUES ('Academician Kuprevich Street, 1', 'Minsk', '', '220141');

    DECLARE @newAddressId INT = SCOPE_IDENTITY();

    IF NOT EXISTS (SELECT * FROM dbo.Company WHERE [Name] = @EPAMcompany)
    BEGIN
    INSERT INTO dbo.Company (AddressId, [Name])
    VALUES (@newAddressId, @EPAMcompany)
    END
END