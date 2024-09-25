CREATE PROCEDURE [dbo].[spOrder_GetUnderCondition]
	@Status nvarchar(10) = null,
	@CreateDateMonth int = null,
	@CreateDateYear int = null,
	@ProductId int = null
AS
begin
	select [Id], [Status], [CreateDate], [UpdateDate], [ProductId] 
	from dbo.[Order]
	where [Status] = @Status or
		  MONTH(CreateDate) = @CreateDateMonth or
		  YEAR(CreateDate) = @CreateDateYear or
		  ProductId = @ProductId;
end
