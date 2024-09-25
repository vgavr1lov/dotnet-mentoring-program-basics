CREATE PROCEDURE [dbo].[spProduct_GetAll]
AS
begin
	select [Id], [Description], [Weight], [Height], [Width], [Length]
	from dbo.Product;
end

