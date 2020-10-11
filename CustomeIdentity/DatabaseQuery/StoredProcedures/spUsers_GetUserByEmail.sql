CREATE PROCEDURE [dbo].[spUsers_GetUserByEmail]
	@UserEmail nvarchar (256)
AS
BEGIN

	SET NOCOUNT ON;

	SELECT * FROM Users WHERE Email = @UserEmail
END
