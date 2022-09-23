CREATE DATABASE Practice02DB;
GO
USE Practice02DB
GO
CREATE TABLE Users(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](255) NOT NULL,
	[LastName] [nvarchar](255) NOT NULL,

	[Password] [nvarchar](max) NOT NULL,
	[ConfirmPassword] [nvarchar](max) NOT NULL,
	[ImageUrl] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](256) NOT NULL,

	[CreatedAt] [datetime] NOT NULL DEFAULT getutcdate(),
	[UpdatedAt] [datetime] NOT NULL DEFAULT getutcdate(),
	[Archived] [bit] NOT NULL DEFAULT (0),

	CONSTRAINT [PK_Users] PRIMARY KEY([Id]),
	CONSTRAINT [UQ_Email] UNIQUE(Email)
);