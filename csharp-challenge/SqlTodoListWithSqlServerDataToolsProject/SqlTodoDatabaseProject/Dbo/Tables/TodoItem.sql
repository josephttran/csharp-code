CREATE TABLE [dbo].[TodoItem]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [BelongsTo] INT NOT NULL,
    [ItemName] NVARCHAR(50) NOT NULL, 
    [IsCompleted] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_Todo_Person] FOREIGN KEY ([BelongsTo]) REFERENCES [Person]([Id])
)
