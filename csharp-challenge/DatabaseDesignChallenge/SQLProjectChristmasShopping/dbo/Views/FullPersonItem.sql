CREATE VIEW FullPersonItem
AS
SELECT personItem.PersonId, FirstName, LastName, Budget, Name, Cost
FROM dbo.Person AS person 
	LEFT JOIN dbo.PersonItem AS personItem ON person.PersonId = personItem.PersonId
	LEFT JOIN dbo.Item AS item ON personItem.ItemId = item.ItemId
