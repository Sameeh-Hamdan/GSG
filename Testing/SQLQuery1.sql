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
    it.SubId,
    sub_ctg.[Name],
    ctg.Id,
    ctg.[Name]
FROM
    Items AS it
    INNER JOIN
        Sub_Categories AS sub_ctg
    ON sub_ctg.Id = it.SubId
    INNER JOIN
        Categories AS ctg
    ON ctg.Id =sub_ctg.CatId;

go

CREATE PROC sp_GetDetailsForItem(
    @item_id int
) AS 
BEGIN
	Select *
	from DetailsOfItems  as DI
	where DI.[Item Id]=@item_id
END;

EXEC sp_GetDetailsForItem @item_id= 5;

GO

CREATE FUNCTION udfGetDetailsForItem (
    @item_id INT
)
RETURNS TABLE
AS
RETURN
    Select *
	from DetailsOfItems  as DI
	where DI.[Item Id]=@item_id