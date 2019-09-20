CREATE TABLE [dbo].[Address]
(
	[AddressId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CountryCode] NVARCHAR(3) NOT NULL, 
    [State] NVARCHAR(50) NULL, 
    [City] NVARCHAR(50) NULL, 
    [Zipcode] NVARCHAR(10) NULL 
)
