CREATE TRIGGER [dbo].[TodoItemDeletedTrigger]
ON [dbo].[TodoItem]
AFTER DELETE
AS
BEGIN
	SET NOCOUNT ON
	INSERT INTO TodoDeletedHistory VALUES (
		(SELECT TOP 1 deleted.BelongsTo from deleted),
		(SELECT TOP 1 deleted.ItemName from deleted),
		(SELECT TOP 1 deleted.IsCompleted from deleted),
		GETDATE()
	);
END
