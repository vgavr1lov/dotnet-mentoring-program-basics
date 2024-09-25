Create PROCEDURE [dbo].[spOrder_Insert]
	@Id int = null,
	@Status nvarchar(10),
	@CreateDate date,
	@UpdateDate date,
	@ProductId int
AS
begin
	insert into dbo.[Order] ([Status], CreateDate, UpdateDate, ProductId)
	values (@Status, @CreateDate, @UpdateDate, @ProductId);
	select SCOPE_IDENTITY();
end
