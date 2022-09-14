/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Id]
      ,[FirstName]
      ,[LastName]
      ,[CreatedAt]
      ,[UpdatedAt]
      ,[Archived]
  FROM [restaurantdbTest].[dbo].[Customers]