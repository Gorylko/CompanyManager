CREATE PROCEDURE [dbo].[sp_select_user_by_id]
	@userId INT
AS
BEGIN
	SELECT 
		[Id],
		[Login],
		[Password],
		[PasswordSalt]
	FROM [dbo].[Users]
	WHERE [dbo].[Users].[Id] = @userId
END