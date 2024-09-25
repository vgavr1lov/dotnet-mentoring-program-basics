CREATE PROCEDURE [dbo].[spProduct_GetUnderCondition]
	@Id int = null,
	@Description nvarchar(50) = null,
	@Weight numeric(18, 2) = null,
	@Height numeric(18, 2) = null,
	@Width numeric(18, 2) = null,
	@Length numeric(18, 2) = null
AS
begin
	select [Id], [Description], [Weight], [Height], [Width], [Length]
	from dbo.Product
	where Id = @Id or
		  [Description] = @Description or
		  [Weight] = @Weight or
		  Height = @Height or
		  Width = @Width or
		  [Length] = @Length;
end
