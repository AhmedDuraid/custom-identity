CREATE PROCEDURE [dbo].[spUsers_GetUserByName] 
	
	@NormalizedUserName nvarchar(256)
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
	where NormalizedUserName = @NormalizedUserName
END
