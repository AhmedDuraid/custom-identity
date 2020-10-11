CREATE PROCEDURE [dbo].[spRoles_GetRoleByID] 
	@RoleID nvarchar(128)
AS
BEGIN

	SET NOCOUNT ON;

	SELECT Id,[Name] 
	FROM Roles
	WHERE Id = @RoleID
	
END
