CREATE PROCEDURE [dbo].[spOrder_Update]
	@Id int,
	@Status nvarchar(10),
	@CreateDate date,
	@UpdateDate date,
	@ProductId int
AS
begin
	update dbo.[Order]
	set [Status] = @Status, 
	CreateDate = @CreateDate, 
	UpdateDate = @UpdateDate, 
	ProductId = @ProductId
	where Id = @Id;
end
