/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Id]
      ,[MealName]
      ,[PriceInNis]
      ,[PriceInUsd]
      ,[Quantity]
      ,[CreatedAt]
      ,[UpdatedAt]
      ,[Archived]
      ,[RestaurantId]
  FROM [restaurantdbTest].[dbo].[RestaurantMenus]