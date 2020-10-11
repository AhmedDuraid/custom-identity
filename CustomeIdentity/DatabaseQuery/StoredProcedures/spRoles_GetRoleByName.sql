CREATE PROCEDURE [dbo].[spRoles_GetRoleByName]
	@RoleName nvarchar(256)
AS
BEGIN

	SET NOCOUNT ON;

	SELECT Id,[Name] 
	FROM Roles
	WHERE [Name]=@RoleName
END
