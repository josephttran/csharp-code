CREATE VIEW dbo.PersonBudget
AS 
SELECT FirstName, LastName, Budget FROM dbo.Person
WHERE PersonId NOT IN (
	SELECT PersonId
	FROM dbo.PersonItem
);
