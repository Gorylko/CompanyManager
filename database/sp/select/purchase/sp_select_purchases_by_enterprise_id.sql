CREATE PROCEDURE [dbo].[sp_select_purchases_by_enterprise_id](
	@enterpriseId INT
	)
AS
BEGIN
	SELECT * 
	FROM [dbo].[Purchases]
	WHERE  [EnterpriseId] = @enterpriseId
END