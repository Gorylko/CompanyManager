CREATE PROCEDURE [dbo].[sp_select_salt_by_user_login]
	@userLogin INT
AS
BEGIN
	SELECT [PasswordSalt]
	FROM [dbo].[Users]
	WHERE [dbo].[Users].[Login] = @userLogin
END