CREATE PROCEDURE [dbo].[spUsers_AddUser] 
	@UserId nvarchar(128)
	,@UserName nvarchar(256)
	,@Email nvarchar (256)
	,@Password nvarchar(MAX)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO Users(
		Id
		,UserName
		,Email
		,PasswordHash
		,NormalizedUserName
		)
		VALUES (
		@UserId
		,@UserName
		,@Email
		,@Password
		,@UserName)
END
