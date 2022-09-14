/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [RestaurantMenuId]
      ,[CustomerId]
      ,[Quantity]
  FROM [restaurantdbTest].[dbo].[RestaurantMenus_Customers]