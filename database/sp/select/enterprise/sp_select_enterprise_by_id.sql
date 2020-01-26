CREATE PROCEDURE [dbo].[sp_select_enterprise_by_id](
	@id INT
	)
AS
BEGIN
	SELECT TOP 1 * 
	FROM [dbo].[Enterprises]
	WHERE  [Id] = @id

	--EXEC [dbo].[sp_select_areas_by_enterprise_id] @id
	--EXEC [dbo].[sp_select_employees_by_enterprise_id] @id
	--EXEC [dbo].[sp_select_purchases_by_enterprise_id] @id
END