CREATE TABLE [dbo].[PersonItem]
(
	[PersonId] INT NOT NULL, 
    [ItemId] INT NOT NULL, 
	PRIMARY KEY (PersonId, ItemId), 
    CONSTRAINT [FK_PersonItem_Person] FOREIGN KEY ([PersonId]) REFERENCES [Person]([PersonId]) ON DELETE CASCADE, 
    CONSTRAINT [FK_PersonItem_Item] FOREIGN KEY ([ItemId]) REFERENCES [Item]([ItemId]) ON DELETE CASCADE
)
