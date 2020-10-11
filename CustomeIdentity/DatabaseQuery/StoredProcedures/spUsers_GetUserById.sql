CREATE PROCEDURE [dbo].[spUsers_GetUserById] 
	@UserId nvarchar(128)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
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
	where Id = @UserId
END
