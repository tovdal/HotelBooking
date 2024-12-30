--Skapa MS-SQL syntaxer som kan utföra ’Select’, ’Where’, ’Order By’ uppgifter mot din databas

---- SELECT ----
USE HotelbookingDBTova;

SELECT
	*
FROM
Customers;

---- WHERE ----
USE HotelbookingDBTova;

SELECT 
    * 
FROM 
    Customers AS c
WHERE 
    c.FirstName LIKE 'C%';

---- ORDER BY ----
USE HotelbookingDBTova;

SELECT 
	*
FROM
	Rooms As r
ORDER BY
	r.PricePerNight DESC;
