CREATE PROCEDURE [dbo].[spLookup]
	@id int
AS
BEGIN
	SELECT Person.Id, FirstName, LastName, RecurringTodoItem.ItemDescription, RecurringTodoItem.StartDate, IsActive, IsCompleted
	FROM Person INNER JOIN RecurringTodoItem
	ON Person.Id = RecurringTodoItem.BelongsTo
	WHERE Person.Id = @id
	AND IsActive = 1
	AND IsCompleted = 0;
END
