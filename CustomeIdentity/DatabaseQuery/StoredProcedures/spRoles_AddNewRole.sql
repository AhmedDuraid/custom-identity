CREATE PROCEDURE [dbo].[spRoles_AddNewRole] 
	
	@RoleID nvarchar(128),
	@RoleName nvarchar(256)
AS
BEGIN
	
	SET NOCOUNT ON;

	INSERT INTO Roles (Id,[Name]) VALUES (@RoleID,@RoleName);
END
