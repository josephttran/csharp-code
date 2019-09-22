/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

IF NOT EXISTS (SELECT 1 FROM dbo.Address)
BEGIN
  INSERT INTO dbo.Address (CountryCode, State)
  VALUES ('US', 'CA'), 
  ('US', 'OR'), 
  ('US', 'WA');
END


IF NOT EXISTS (SELECT 1 FROM dbo.Person)
BEGIN
  INSERT INTO dbo.Person (FirstName, LastName, Age, AddressID, Budget)
  VALUES ('J', 'T', 22, 1, 100),
  ('Alice', 'Wonder', 14, 1, 50),
  ('Bob', 'Key', 14, 1, 50),
  ('Eve', 'Shadow', 10, 3, 50),
  ('Midnight', 'Sun', 22, 2, 100),
  ('Fast', 'Light', 22, 2, 100);
END

IF NOT EXISTS (SELECT 1 FROM dbo.Item)
BEGIN
  INSERT INTO dbo.Item ([GiftName], Cost)
  VALUES ('Healing Stone Mug', 24.95), 
  ('Green Herbal Tea Kit', 40.00), 
  ('Bubble Tea Kit', 35.00), 
  ('Wishing Ball', 32.00), 
  ('Decision Star', 18.75), 
  ('Double Sided Puzzle', 16.85), 
  ('Magnetic Sand Hourglass', 18.00), 
  ('Gardener Basket', 39.95), 
  ('Water Bottle', 15.00), 
  ('Art Drawing Set', 29.25);
END

IF NOT EXISTS (SELECT 1 FROM dbo.PersonItem)
BEGIN
  INSERT INTO dbo.PersonItem (PersonId, ItemId)
  VALUES (1, 10),
  (1, 2),
  (2, 5),
  (2, 7),
  (3, 4),
  (3, 1),
  (4, 6),
  (4, 9),
  (5, 2),
  (5, 3);
END