CREATE TABLE [dbo].[RecurringTodoItem]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [BelongsTo] INT NOT NULL, 
    [ItemDescription] NVARCHAR(50) NOT NULL, 
    [StartDate] DATETIME NOT NULL, 
    [EndDate] DATETIME NULL, 
    [FrequencyType] NVARCHAR(5) NOT NULL, 
    [FrequencyInterval] INT NOT NULL, 
    [IsActive] BIT NOT NULL,
    [IsCompleted] BIT NOT NULL DEFAULT 0,
    [NextCreateDate] datetime DEFAULT null,
    CONSTRAINT [FK_RecurringTodoItem_Person] FOREIGN KEY ([BelongsTo]) REFERENCES [Person]([Id]),
    CONSTRAINT [CK_RecurringTodoItem_Frequency] CHECK ([FrequencyType] IN ('day', 'week', 'month', 'year')),
    CONSTRAINT [CK_RecurringTodoItem_FrequencyInterval] CHECK (FrequencyInterval > 0)
)

GO

CREATE TRIGGER [dbo].[TR_RecurringTodoItem]
ON [dbo].[RecurringTodoItem]
FOR INSERT
AS
BEGIN
    SET NoCount ON
    IF ((SELECT TOP 1 inserted.FrequencyType from inserted) = 'day')
    UPDATE RecurringTodoItem
    SET NextCreateDate = DATEADD(DAY, FrequencyInterval, StartDate)
    WHERE Id = (SELECT TOP 1 inserted.id from inserted);

    IF ((SELECT TOP 1 inserted.FrequencyType from inserted) = 'week')
    UPDATE RecurringTodoItem
    SET NextCreateDate = DATEADD(WEEK, FrequencyInterval, StartDate)
    WHERE Id = (SELECT TOP 1 inserted.id from inserted);

    IF ((SELECT TOP 1 inserted.FrequencyType from inserted) = 'month')
    UPDATE RecurringTodoItem
    SET NextCreateDate = DATEADD(MONTH, FrequencyInterval, StartDate)
    WHERE Id = (SELECT TOP 1 inserted.id from inserted);
            
    IF ((SELECT TOP 1 inserted.FrequencyType from inserted) = 'year')
    UPDATE RecurringTodoItem
    SET NextCreateDate = DATEADD(YEAR, FrequencyInterval, StartDate)
    WHERE Id = (SELECT TOP 1 inserted.id from inserted);
END