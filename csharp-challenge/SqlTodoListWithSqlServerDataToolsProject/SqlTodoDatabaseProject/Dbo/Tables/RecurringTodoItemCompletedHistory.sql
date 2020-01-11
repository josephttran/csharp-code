CREATE TABLE [dbo].[RecurringTodoCompletedHistory]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [RecurringTodoItemId] INT NOT NULL, 
    [DateCompleted] DATETIME NOT NULL, 
    CONSTRAINT [FK_RecurringTodoCompletedHistory_RecurringTodoItem] FOREIGN KEY ([RecurringTodoItemId]) REFERENCES [RecurringTodoItem]([Id])
)
