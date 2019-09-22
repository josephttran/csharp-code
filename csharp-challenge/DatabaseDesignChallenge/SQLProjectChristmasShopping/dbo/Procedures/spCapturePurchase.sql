CREATE PROCEDURE [dbo].[spCapturePurchase]
	@ItemId		int = NULL,
	@GiftName	nvarchar(50),
	@Cost		Decimal(8, 2),
	@PersonId	int,
	@FirstName	nvarchar(50),
	@LastName	nvarchar(50),
	@Budget		Decimal(8, 2)
AS
BEGIN
	SET NOCOUNT ON	

	BEGIN TRY
		BEGIN TRANSACTION
			-- If the item does not already exist, insert a row into the Item table 
			IF NOT EXISTS (SELECT 1 FROM dbo.Item WHERE (GiftName = @GiftName AND Cost = @Cost) OR (ItemId = @ItemId))
			BEGIN
				SET IDENTITY_INSERT dbo.Item ON

				IF @ItemId IS NULL
				BEGIN
					INSERT INTO dbo.Item (GiftName, Cost) 
					VALUES (@GiftName, @Cost)
					SET @ItemId = (SELECT ItemId FROM dbo.Item WHERE GiftName = @GiftName AND Cost = @Cost)
				END
				ELSE
				BEGIN
					INSERT INTO dbo.Item (ItemId, GiftName, Cost) 
					VALUES (@ItemId, @GiftName, @Cost)
				END

				SET IDENTITY_INSERT dbo.Item OFF
			END

			-- If a person is not already in the Person table then insert a new row
			IF NOT EXISTS (SELECT 1 FROM dbo.Person WHERE PersonId = @PersonId)
			BEGIN
				SET IDENTITY_INSERT dbo.Person ON

				INSERT INTO dbo.Person (PersonId, FirstName, LastName, Budget) 
				VALUES (@PersonId, @FirstName, @LastName, @Budget)

				SET IDENTITY_INSERT dbo.Person OFF
			END

			-- Relation between Person and Item
			IF NOT EXISTS (SELECT 1 FROM dbo.PersonItem WHERE ItemId = @ItemId)
			AND NOT EXISTS (SELECT 1 FROM dbo.PersonItem WHERE PersonId = @PersonId)
			BEGIN
				INSERT INTO dbo.PersonItem (PersonId, ItemId)
				VALUES (@PersonId, @ItemId)
			END	
			ELSE
			BEGIN
				PRINT 'Already bought this Gift for this person'
			END
		COMMIT TRANSACTION

		SELECT FirstName, LastName, Budget, GiftName, Cost 
		FROM dbo.FullPersonItem
		WHERE PersonId = @PersonId;
	END TRY
	BEGIN CATCH
		SELECT 
			ERROR_NUMBER() AS ErrorNumber  
			,ERROR_SEVERITY() AS ErrorSeverity  
			,ERROR_STATE() AS ErrorState  
			,ERROR_PROCEDURE() AS ErrorProcedure  
			,ERROR_LINE() AS ErrorLine  
			,ERROR_MESSAGE() AS ErrorMessage; 

		IF @@TRANCOUNT > 0
		BEGIN
			ROLLBACK
		END
	END CATCH
END																	    
