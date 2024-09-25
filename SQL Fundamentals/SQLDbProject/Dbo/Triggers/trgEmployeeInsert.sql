CREATE TRIGGER trgEmployeeInsert
	ON dbo.Employee
	after INSERT
	AS
	BEGIN
		SET NOCOUNT ON
		declare @InsertedAddressId int;
		declare @InsertedCompanyName nvarchar(50);

		select @InsertedAddressId = AddressId,
			   @InsertedCompanyName = CompanyName 				
		from inserted;

		if not exists (select * from dbo.Company where [Name] = @InsertedCompanyName)
		and exists (select * from dbo.[Address] where id = @InsertedAddressId)
		begin		
			declare @InsertedStreet nvarchar(50);
			declare @InsertedCity nvarchar(20);
			declare @InsertedState nvarchar(50);
			declare @InsertedZipCode nvarchar(50);

			select @InsertedStreet = Street, @InsertedCity = City, 
			@InsertedState = [State], @InsertedZipCode = ZipCode
			from dbo.[Address]
			where id = @InsertedAddressId;

			insert into dbo.[Address] (Street, City, [State], ZipCode)
			values (@InsertedStreet, @InsertedCity, @InsertedState, @InsertedZipCode);

			declare @NewAddressId int = scope_identity();

			insert into dbo.Company ([Name], AddressId)
			values (@InsertedCompanyName, @NewAddressId);
		end
	END

