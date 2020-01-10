CREATE TABLE [dbo].[TodoDeletedHistory]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TodoItemBelongsTo] INT NOT NULL, 
    [TodoItemName] NVARCHAR(50) NOT NULL, 
    [TodoItemIsCompleted] BIT NOT NULL, 
    [DateDeleted] SMALLDATETIME NOT NULL, 
    CONSTRAINT [FK_TodoDeletedHistory_Person] FOREIGN KEY ([TodoItemBelongsTo]) REFERENCES [Person]([Id])
)
