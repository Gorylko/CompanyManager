CREATE PROCEDURE [dbo].[sp_select_areas_by_enterprise_id](
	@enterpriseId INT
	)
AS
BEGIN
	SELECT * 
	FROM [dbo].[WorkAreas]
	WHERE  [EnterpriseId] = @enterpriseId
END