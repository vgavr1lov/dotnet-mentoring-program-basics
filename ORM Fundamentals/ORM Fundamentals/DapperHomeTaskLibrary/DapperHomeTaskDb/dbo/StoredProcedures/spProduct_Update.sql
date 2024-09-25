CREATE PROCEDURE [dbo].[spProduct_Update]
	@Id int,
	@Description nvarchar(50),
	@Weight numeric(18, 2),
	@Height numeric(18, 2),
	@Width numeric(18, 2),
	@Length numeric(18, 2)
AS
begin
	update dbo.[Product]
	set [Description] = @Description,
	[Weight] = @Weight,
	Height = @Height,
	Width = @Width,
	[Length] = @Length
	where Id = @Id;
end
