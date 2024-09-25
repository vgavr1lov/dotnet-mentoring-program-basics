CREATE PROCEDURE [dbo].[spInsertEmployeeInfo]
	@EmployeeName nvarchar(100) = null,
	@FirstName nvarchar(50) = null,
	@LastName nvarchar(50) = null,
	@CompanyName nvarchar(50),
	@Position nvarchar(50) = null,
	@Street nvarchar(50),
	@City nvarchar(20) = null,
	@State nvarchar(30) = null,
	@ZipCode nvarchar(50) = null
AS
begin
if not (len(isnull(trim(@FirstName), '')) = 0 and
		len(isnull(trim(@LastName), '')) = 0 and
		len(isnull(trim(@EmployeeName), '')) = 0)
begin
insert into dbo.[Address] (Street, City, [State], ZipCode)
values (@Street, @City, @State, @ZipCode);

declare @newAddressId int = scope_identity();

insert into dbo.Person (FirstName, LastName)
values (@FirstName, @LastName);

declare @newPersonId int = scope_identity();

if len(@CompanyName) > 20
begin
	set @CompanyName = left(@CompanyName, 20);
end

insert into dbo.Employee (AddressId, PersonId, CompanyName, Position, EmployeeName)
values (@newAddressId, @newPersonId, @CompanyName, @Position, @EmployeeName);

end
else
begin
	raiserror ('At least one field (either EmployeeName or FirstName or LastName) should be not null, empty string or contains only ‘space’ symbols', 16, 1)
end
end
