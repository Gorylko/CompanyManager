CREATE PROCEDURE [dbo].[sp_select_employees_by_enterprise_id](
	@enterpriseId INT
	)
AS
BEGIN
	SELECT * 
	FROM [dbo].[Employees]
	WHERE  [EnterpriseId] = @enterpriseId
END