GO

CREATE PROC GetPersonPhone
	@FName nvarchar(50),
	@PPhone varchar(15)

AS
SELECT 
	PP.FirstName, 
	PPH.PhoneNumber
FROM Person.Person AS PP 
	INNER JOIN Person.EmailAddress AS PE ON PP.BusinessEntityID = PE.BusinessEntityID
	INNER JOIN Person.PersonPhone AS PPH ON PP.BusinessEntityID = PPH.BusinessEntityID
WHERE PP.FirstName LIKE @FName
	AND PPH.PhoneNumber LIKE @PPhone
GO

GetPersonPhone 
	'E%',
	'%5%'