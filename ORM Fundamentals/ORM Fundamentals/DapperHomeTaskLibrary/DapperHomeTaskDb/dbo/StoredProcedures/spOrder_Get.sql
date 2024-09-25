CREATE PROCEDURE [dbo].[spOrder_Get]
	@Id int
AS
begin
	select [Id], [Status], [CreateDate], [UpdateDate], [ProductId]
	from dbo.[Order]
	where Id = @Id;
end
