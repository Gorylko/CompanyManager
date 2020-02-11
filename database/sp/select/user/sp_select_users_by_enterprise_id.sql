CREATE PROCEDURE [dbo].[sp_select_users_by_enterprise_id](
	@enterpriseId INT
	)
AS
BEGIN
	SELECT
	[Users].[Id]
	,[Users].[Login]
	FROM [dbo].[Users]
	INNER JOIN [dbo].[UsersToEnterprises] ON [dbo].[UsersToEnterprises].[UserId] = [dbo].[Users].[Id]
	INNER JOIN [dbo].[Enterprises] ON [dbo].[Enterprises].[Id] = [dbo].[UsersToEnterprises].[EnterpriseId]
	WHERE [EnterpriseId] = @enterpriseId
END