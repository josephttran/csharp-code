CREATE TRIGGER [dbo].[TR_RecurringTodoItemIsCompletedHistory]
ON [dbo].[RecurringTodoItem]
AFTER UPDATE
AS 
BEGIN
    SET NOCOUNT ON;
    IF ((SELECT TOP 1 deleted.IsCompleted from deleted) = 0 
        AND (SELECT TOP 1 inserted.IsCompleted from inserted) = 1)
    BEGIN
        INSERT INTO RecurringTodoCompletedHistory VALUES ((SELECT TOP 1 inserted.id from inserted), GETDATE());

        IF ((SELECT TOP 1 inserted.FrequencyType from inserted) = 'day')
            UPDATE RecurringTodoItem
            SET IsCompleted = 0,
                StartDate = (SELECT TOP 1 inserted.NextCreateDate from inserted),
                NextCreateDate = DATEADD(DAY, FrequencyInterval, StartDate)
            WHERE Id = (SELECT TOP 1 inserted.id from inserted);

        IF ((SELECT TOP 1 inserted.FrequencyType from inserted) = 'week')
            UPDATE RecurringTodoItem
            SET IsCompleted = 0,
                StartDate = (SELECT TOP 1 inserted.NextCreateDate from inserted),
                NextCreateDate = DATEADD(WEEK, FrequencyInterval, StartDate)
            WHERE Id = (SELECT TOP 1 inserted.id from inserted);

         IF ((SELECT TOP 1 inserted.FrequencyType from inserted) = 'month')
            UPDATE RecurringTodoItem
            SET IsCompleted = 0,
                StartDate = (SELECT TOP 1 inserted.NextCreateDate from inserted),
                NextCreateDate = DATEADD(MONTH, FrequencyInterval, StartDate)
            WHERE Id = (SELECT TOP 1 inserted.id from inserted);
            
         IF ((SELECT TOP 1 inserted.FrequencyType from inserted) = 'year')
            UPDATE RecurringTodoItem
            SET IsCompleted = 0,
                StartDate = (SELECT TOP 1 inserted.NextCreateDate from inserted),
                NextCreateDate = DATEADD(YEAR, FrequencyInterval, StartDate)
            WHERE Id = (SELECT TOP 1 inserted.id from inserted);
    END 
END