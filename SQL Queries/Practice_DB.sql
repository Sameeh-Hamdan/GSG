CREATE DATABASE [Practice_DB];
GO
USE [Practice_DB]
GO

CREATE TABLE [dbo].[Categories](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CreatedAt] [datetime] NOT NULL DEFAULT getutcdate(),
	[UpdatedAt] [datetime] NOT NULL DEFAULT getutcdate(),
	[Archived] [bit] NOT NULL DEFAULT (0),
	CONSTRAINT [PK_Categories] PRIMARY KEY (ID)
);
GO

GO

CREATE TABLE [dbo].[SubCategories](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CreatedAt] [datetime] NOT NULL DEFAULT getutcdate(),
	[UpdatedAt] [datetime] NOT NULL DEFAULT getutcdate(),
	[Archived] [bit] NOT NULL DEFAULT (0),
	[CategoryID] [int] NOT NULL,
	CONSTRAINT [PK_SubCategories] PRIMARY KEY (ID),
	CONSTRAINT [FK_SubCategories_Categories] FOREIGN KEY([CategoryID]) REFERENCES [dbo].[Categories] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
);
GO

GO

CREATE TABLE [dbo].[Items](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CreatedAt] [datetime] NOT NULL DEFAULT getutcdate(),
	[UpdatedAt] [datetime] NOT NULL DEFAULT getutcdate(),
	[Archived] [bit] NOT NULL DEFAULT (0),
	[SubCategoryID] [int] NOT NULL,
	CONSTRAINT [PK_Items] PRIMARY KEY([ID]),
	CONSTRAINT [FK_Items_SubCategories] FOREIGN KEY([SubCategoryID]) REFERENCES [dbo].[SubCategories] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
);

GO

CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[ConfirmPassword] [nvarchar](max) NOT NULL,
	[ImageUrl] [nvarchar](max) NOT NULL,
	Email nvarchar(256) not null,
	[CreatedAt] [datetime] NOT NULL DEFAULT getutcdate(),
	[UpdatedAt] [datetime] NOT NULL DEFAULT getutcdate(),
	[Archived] [bit] NOT NULL DEFAULT (0),
	CONSTRAINT unique_email UNIQUE(Email),
	CONSTRAINT [PK_Users] PRIMARY KEY([ID])
);

--Delete from SubCategories
GO

CREATE OR ALTER VIEW DetailsOfItems (
    [Item Id],
    [Item Name],
    [SubCategory Id],
    [SubCategory Name],
    [Category Id],
    [Category Name]
)
AS
SELECT
    it.Id,
    it.[Name],
    it.SubCategoryID,
    sub_ctg.[Name],
    ctg.Id,
    ctg.[Name]
FROM
    Items AS it
    INNER JOIN
        SubCategories AS sub_ctg
    ON sub_ctg.Id = it.SubCategoryID
    INNER JOIN
        Categories AS ctg
    ON ctg.Id =sub_ctg.CategoryID;