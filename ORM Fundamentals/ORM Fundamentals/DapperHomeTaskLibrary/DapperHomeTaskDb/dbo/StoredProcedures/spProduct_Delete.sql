CREATE PROCEDURE [dbo].[spProduct_Delete]
	@Id int
AS
begin
	delete
	from dbo.Product
	where Id = @Id;
end
