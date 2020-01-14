CREATE PROCEDURE [dbo].[spHistory]
AS
BEGIN
	SELECT C.ItemDescription, C.[Total Not Completed], D.[Total Completed], (C.[Total Not Completed] + D.[Total Completed]) AS 'Total Assigned'
	FROM
		(
			SELECT RecurringTodoItem.ItemDescription, COUNT (*) AS 'Total Not Completed'
			FROM  RecurringTodoItem
			GROUP BY RecurringTodoItem.ItemDescription
		) C
		LEFT JOIN
		(
			SELECT A.ItemDescription, (CASE WHEN TimeCompleted IS NULL THEN 0 ELSE TimeCompleted END) AS 'Total Completed'
			FROM
			(
				SELECT RecurringTodoItem.ItemDescription
				FROM RecurringTodoItem INNER JOIN RecurringTodoCompletedHistory
				ON RecurringTodoItemId != RecurringTodoItem.Id
				GROUP BY RecurringTodoItem.ItemDescription
			) A
			LEFT JOIN
			(SELECT RecurringTodoItem.ItemDescription, COUNT (*) AS TimeCompleted
			FROM RecurringTodoItem INNER JOIN RecurringTodoCompletedHistory
			ON RecurringTodoItemId = RecurringTodoItem.Id
			GROUP BY RecurringTodoItem.ItemDescription
			) B
		ON a.ItemDescription = b.ItemDescription
		) D
	ON C.ItemDescription = D.ItemDescription
END
