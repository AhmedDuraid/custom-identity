CREATE TABLE [dbo].[Users](
	[Id] [nvarchar](128) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[NormalizedUserName] [nvarchar](max) NULL,
	[AuthenticationType] [nvarchar](256) NULL,
	[IsAuthenticated] [bit] NULL,
	[Name] [nvarchar](256) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


/****** Null objects can be changed to NotNull. some of them are Null for testing  ******/