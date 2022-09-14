/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Id]
      ,[Name]
      ,[PhoneNumber]
      ,[CreatedAt]
      ,[UpdatedAt]
      ,[Archived]
  FROM [restaurantdbTest].[dbo].[Restaurants]