CREATE PROCEDURE [dbo].[spUsers_GetUsers] 
	
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		Id
		,UserName
		,Email
		,EmailConfirmed
		,PasswordHash
		,NormalizedUserName
		,AuthenticationType
		,IsAuthenticated
		,[Name] 
	FROM Users
END
