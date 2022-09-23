CREATE DATABASE [restaurantdb];
GO
USE [restaurantdb]
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

CREATE TABLE Orders(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RestaurantMenuId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL DEFAULT getutcdate(),
	[UpdatedAt] [datetime] NOT NULL DEFAULT getutcdate(),
	[Archived] [bit] NOT NULL DEFAULT (0),
	CONSTRAINT PK_Orders PRIMARY KEY ([Id]),
	CONSTRAINT FK_RestaurantMenu_RestaurantMenuCustomer FOREIGN KEY ([RestaurantMenuId]) REFERENCES [RestaurantMenus] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT FK_Customer_RestaurantMenuCustomer FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
);
GO
CREATE OR ALTER VIEW Details
AS
SELECT
        c.Id as Id,
        r.[Name] as RestaurantName,
        r.Id as RestaurantId,
        rm.MealName as MealName,
        Sum(rm.PriceInNis) as ProfitInNis,
        rm.Id as RestaurantMenuId,
        Sum(rm.PriceInUsd) as ProfitInUsd,
        count(Distinct c.Id) as NumberofOrderedCustomer,
        cc.CustomerName,
        cc.price 
    FROM
        Orders AS o     
    INNER JOIN
        Customers AS c     
            ON o.CustomerId = c.Id     
    INNER JOIN
        RestaurantMenus AS rm     
            ON rm.Id =o.RestaurantMenuId  
    INNER JOIN
        Restaurants AS r     
            ON r.Id =rm.RestaurantId   
    INNER join
        (
            select
                sub.occurance,
                sub.restaurantId,
                sub.price,
                sub.Id,
                sub.CustomerName   
            From
                (select
                    c.Id,
                    r.[Name] as raa,
                    r.Id as restaurantId,
                    CONCAT_WS(' ',
                    c.FirstName,
                    c.LastName) as CustomerName,
                    sum(rm.PriceInNis) as price,
                    count(o.CustomerId) as occurance    
                from
                    Customers c    
                INNER JOIN
                    Orders AS o    
                        ON c.Id = o.CustomerId    
                INNER JOIN
                    RestaurantMenus AS rm    
                        ON rm.Id =o.RestaurantMenuId    
                INNER JOIN
                    Restaurants AS r    
                        ON r.Id =rm.RestaurantId   
                GROUP BY
                    c.Id,
                    r.[Name] ,
                    restaurantId   
                order by
                    price desc   )sub  )as cc 
                    on cc.restaurantId=r.Id 
            GROUP BY
                r.Id;


--SELECT
--    r.[Name],
--    Count(DISTINCT c.Id),
--	Sum(rm.PriceInNis*o.Quantity/3.5),
--	Sum(rm.PriceInNis*o.Quantity),
--	rm.MealName
--FROM
--    Restaurants AS r
--    INNER JOIN
--        RestaurantMenus AS rm
--    ON rm.RestaurantId = r.Id
--    INNER JOIN
--        Orders AS o
--    ON o.RestaurantMenuId =rm.Id
--	INNER JOIN
--		Customers AS c
--    ON c.Id =o.CustomerId
--GROUP BY
--	r.[Name],o.RestaurantMenuId


--Select r.Name,Sum(o.Quantity)
--From
--	Orders o
--	INNER JOIN
--		RestaurantMenus rm
--	ON rm.Id=o.RestaurantMenuId
--	INNER JOIN
--		Restaurants r
--	ON r.Id=rm.RestaurantId
--Group By rm.Id,r.Name