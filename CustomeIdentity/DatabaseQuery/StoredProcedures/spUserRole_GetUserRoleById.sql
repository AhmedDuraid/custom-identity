CREATE PROCEDURE [dbo].[spUserRole_GetUserRoleById]
	@UserId nvarchar(128)
AS
BEGIN

	SET NOCOUNT ON;

    SELECT 
		UserRole.RoleId,
		UserRole.UserId,
		Roles.Name
	FROM UserRole
	JOIN Roles ON Roles.Id = UserRole.RoleId 
	WHERE UserRole.UserId = @UserId;	
END
