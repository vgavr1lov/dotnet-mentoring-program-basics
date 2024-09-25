CREATE PROCEDURE [dbo].[spOrder_GetAll]
AS
begin
	select [Id], [Status], [CreateDate], [UpdateDate], [ProductId]
	from dbo.[Order];
end
