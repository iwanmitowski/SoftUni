DECLARE @UserName VARCHAR(50) = 'Stamat'
DECLARE @GameName VARCHAR(50) = 'Safflower'
DECLARE @UserId INT = (SELECT Id FROM Users WHERE Username = @UserName)
DECLARE @GameId INT = (SELECT Id FROM Games WHERE Name = @GameName)
DECLARE @UserGameId int = (SELECT Id FROM UsersGames WHERE UserId = @UserID AND GameId = @GameID)
DECLARE @StamatsBudget MONEY = (SELECT Cash FROM UsersGames WHERE GameId = @GameId AND UserId = @UserId)

-- This can be USP
BEGIN TRANSACTION
	DECLARE @Price11to12 DECIMAL(18,4) = 
		(SELECT SUM(Price)
		 FROM Items
		 WHERE MinLevel IN (11, 12))

	IF(@StamatsBudget >= @Price11to12)
	BEGIN
		INSERT INTO UserGameItems
		SELECT Id, @UserGameId
		FROM Items
		WHERE Id IN (SELECT Id FROM Items WHERE MinLevel IN (11, 12))

		UPDATE UsersGames
		SET Cash -= @Price11to12
		WHERE GameId = @GameId AND
		UserId = @UserGameId

		SET @StamatsBudget -= @Price11to12
		COMMIT
	END
	ELSE
		ROLLBACK;

BEGIN TRANSACTION
	DECLARE @Price19to21 DECIMAL(18,4) = 
		(SELECT SUM(Price)
		 FROM Items
		 WHERE MinLevel BETWEEN 19 AND 21)

	IF(@StamatsBudget >= @Price19to21)
	BEGIN
		INSERT INTO UserGameItems
		SELECT Id, @UserGameId
		FROM Items
		WHERE Id IN (SELECT Id FROM Items WHERE MinLevel BETWEEN 19 AND 21)

		UPDATE UsersGames
		SET Cash -= @Price19to21
		WHERE GameId = @GameId AND
		UserId = @UserGameId
		COMMIT
	END
	ELSE
		ROLLBACK;

SELECT [Name] AS [Item Name]
FROM Items
WHERE Id IN (
	SELECT ItemId 
	FROM UserGameItems
	WHERE UserGameId = @UserGameID)
ORDER BY [Item Name]