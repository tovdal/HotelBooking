-- Skapa MS-SQL syntaxer som kan utföra ’Joins’, ’Group By’ och minst en ’Subquery’

---- JOIN ----
USE HotelbookingDBTova;

SELECT
	c.FirstName,
	a.Street
FROM
	Customers AS c
INNER JOIN
	[Address] AS a ON a.Id = c.AddressId;

---- GROUP BY ----
USE HotelbookingDBTova;

SELECT
    r.RoomSize,
    COUNT(*) AS RoomSizeCount
FROM
    Rooms AS r
GROUP BY
    r.RoomSize;

---- SUBQUERY ----
USE HotelbookingDBTova;

SELECT
    r.RoomNumber,
    r.PricePerNight,
    (SELECT AVG(PricePerNight) FROM Rooms) AS AveragePricePerNight
FROM	
    Rooms AS r;