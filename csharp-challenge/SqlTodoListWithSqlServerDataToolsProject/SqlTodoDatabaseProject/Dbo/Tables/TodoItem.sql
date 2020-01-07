CREATE TABLE [dbo].[TodoItem]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [BelongsTo] INT NOT NULL,
    [Name] NVARCHAR(50) NOT NULL, 
    [IsCompleted] BIT NULL, 
    CONSTRAINT [FK_Todo_Person] FOREIGN KEY ([BelongsTo]) REFERENCES [Person]([Id])
)
