CREATE PROCEDURE [dbo].[spProduct_Insert]
	@Id int = null,
	@Description nvarchar(50),
	@Weight numeric(18, 2),
	@Height numeric(18, 2),
	@Width numeric(18, 2),
	@Length numeric(18, 2)
AS
begin
	insert into dbo.[Product] ([Description], [Weight], Height, Width, [Length])
	values (@Description, @Weight, @Height, @Width, @Length);
	select SCOPE_IDENTITY();
end
