CREATE PROCEDURE [dbo].[sp_select_enterprises_by_user_id](
	@userId INT
	)
AS
BEGIN
	SELECT
	[Enterprises].[Id]
	,[Enterprises].[Name]
	,[Enterprises].[Description]
	FROM [dbo].[Enterprises]
	INNER JOIN [dbo].[UsersToEnterprises] ON [dbo].[UsersToEnterprises].[EnterpriseId] = [dbo].[Enterprises].[Id]
	INNER JOIN [dbo].[Users] ON [dbo].[Users].[Id] = [dbo].[UsersToEnterprises].[UserId]
	WHERE [dbo].[Users].[Id] = @userId
END