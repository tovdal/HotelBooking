
--- SELECT ----------------------------
USE HotelbookingDBTova;

SELECT
	*
FROM
	Rooms

--- WHERE ------------------------------
USE HotelbookingDBTova;

SELECT 
	c.Id,
	c.FirstName,
	c.LastName
	
FROM
	Customers As c
WHERE
	c.FirstName LIKE 'B%'

--- ORDER BY----------------------------
USE HotelbookingDBTova;

SELECT
	r.RoomNumber,
	r.RoomSize,
	r.PricePerNight,
	r.TypeOfRoom
FROM
	Rooms AS r
ORDER BY
	r.PricePerNight DESC
-----------------------------------------

USE HotelbookingDBTova;

SELECT 
    c.FirstName,
	c.LastName,
    b.ID,
    b.CheckInDate,
    b.CheckOutDate

FROM 
    Customers AS c
INNER JOIN 
    Bookings AS b ON c.ID = b.CustomerID
WHERE 
    b.CustomerID = '1';
