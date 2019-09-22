CREATE VIEW PersonGiftBudget
AS 
SELECT FirstName, LastName, Budget AS InitialBudget, (Budget - ISNULL(SUM(Cost), 0)) AS BudgetLeft,
CASE WHEN SUM(Cost) IS NOT NULL THEN 'True' ELSE 'False' END AS HasGift
FROM dbo.FullPersonItem
GROUP BY PersonId, FirstName, LastName, Budget;
