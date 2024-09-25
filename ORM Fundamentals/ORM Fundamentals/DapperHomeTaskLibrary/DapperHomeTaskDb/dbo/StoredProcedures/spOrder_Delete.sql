CREATE PROCEDURE [dbo].[spOrder_Delete]
	@Id int
AS
begin
	delete
	from dbo.[Order]
	where Id = @Id;
end
