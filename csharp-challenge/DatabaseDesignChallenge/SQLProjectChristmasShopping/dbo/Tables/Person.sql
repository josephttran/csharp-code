CREATE TABLE [dbo].[Person]
(
	[PersonId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [Age] TINYINT NULL, 
    [AddressId] INT NULL, 
    CONSTRAINT [FK_Person_Address] FOREIGN KEY ([AddressId]) REFERENCES [Address]([AddressId]) ON DELETE SET NULL
)
