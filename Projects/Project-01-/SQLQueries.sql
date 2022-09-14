CREATE DATABASE [restaurantdbTest];
GO
USE [restaurantdbTest]
GO

CREATE TABLE [dbo].[Restaurants](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[PhoneNumber] [nvarchar](255) NOT NULL,
	[CreatedAt] [datetime] NOT NULL DEFAULT getutcdate(),
	[UpdatedAt] [datetime] NOT NULL DEFAULT getutcdate(),
	[Archived] [bit] NOT NULL DEFAULT (0),
	CONSTRAINT [PK_Restaurants] PRIMARY KEY (Id)
);
GO

GO

CREATE TABLE [dbo].[RestaurantMenus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MealName] [nvarchar](255) NOT NULL,
	[PriceInNis] [Decimal](10,2)NOT NULL,
	[PriceInUsd] AS [PriceInNis]/3.5,
	[Quantity] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL DEFAULT getutcdate(),
	[UpdatedAt] [datetime] NOT NULL DEFAULT getutcdate(),
	[Archived] [bit] NOT NULL DEFAULT (0),
	[RestaurantId] [int] NOT NULL,
	CONSTRAINT [PK_RestaurantMenus] PRIMARY KEY (Id),
	CONSTRAINT [FK_RestaurantMenus_Restaurants] FOREIGN KEY([RestaurantId]) REFERENCES [dbo].[Restaurants] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
);
GO

GO

CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](255) NOT NULL,
	[LastName] [nvarchar](255) NOT NULL,
	[CreatedAt] [datetime] NOT NULL DEFAULT getutcdate(),
	[UpdatedAt] [datetime] NOT NULL DEFAULT getutcdate(),
	[Archived] [bit] NOT NULL DEFAULT (0),
	CONSTRAINT [PK_Customers] PRIMARY KEY([Id]),
);
GO

CREATE TABLE RestaurantMenus_Customers(
	[RestaurantMenuId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	CONSTRAINT PK_RestaurantMenu_Customer PRIMARY KEY ([RestaurantMenuId],[CustomerId]),
	CONSTRAINT FK_RestaurantMenu_RestaurantMenuCustomer FOREIGN KEY ([RestaurantMenuId]) REFERENCES [RestaurantMenus] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT FK_Customer_RestaurantMenuCustomer FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
);
GO

CREATE OR ALTER VIEW Details (
    [RestaurantName],
    [NumberOfOrderedCustomer],
    [ProfitInUsd],
    [ProfitInNis],
    [TheBestSellingMeal],
    [MostPurchasedCustomer]
)
AS
SELECT
    r.[Name] [RestaurantName],
    Count(c.Id)[NumberOfOrderedCustomer],
	Sum(rm.PriceInNis*rmc.Quantity)[ProfitInUsd]
FROM
    Restaurants AS r
    INNER JOIN
        RestaurantMenus AS rm
    ON rm.RestaurantId = r.Id
    INNER JOIN
        RestaurantMenus_Customers AS rmc
    ON rmc.RestaurantMenuId =rm.Id
	INNER JOIN
        Customers AS c
    ON c.Id =rmc.CustomerId
    GROUP BY
		r.[Name]