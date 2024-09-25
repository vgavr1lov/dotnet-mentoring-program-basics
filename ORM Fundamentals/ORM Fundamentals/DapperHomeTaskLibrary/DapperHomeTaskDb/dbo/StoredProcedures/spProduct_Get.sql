CREATE PROCEDURE [dbo].[spProduct_Get]
	@Id int
AS
begin
	select [Id], [Description], [Weight], [Height], [Width], [Length]
	from dbo.Product
	where Id = @Id;
end
