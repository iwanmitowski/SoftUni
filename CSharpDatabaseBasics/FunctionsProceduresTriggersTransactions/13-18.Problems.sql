CREATE TABLE Logs
(
	LogId INT PRIMARY KEY IDENTITY,
	AccountId INT NOT NULL,
	OldSum MONEY NOT NULL,
	NewSum MONEY NOT NULL
)

GO

CREATE TRIGGER tr_OldNewSum
ON Accounts
FOR UPDATE
AS
BEGIN
	INSERT INTO Logs(AccountId, OldSum, NewSum)
		SELECT i.Id, d.Balance, i.Balance
		FROM inserted AS i
		JOIN deleted AS d ON i.Id = d.Id
		WHERE i.Balance <> d.Balance
END

GO

CREATE TABLE NotificationEmails
(
	Id INT PRIMARY KEY IDENTITY,
	Recipient INT NOT NULL,
	Subject NVARCHAR(MAX) NOT NULL,
	Body NVARCHAR(MAX) NOT NULL,
)

GO

CREATE TRIGGER tr_NotificationEmails
ON Logs
FOR INSERT
AS
BEGIN
	DECLARE @recipient INT
	DECLARE @subject VARCHAR(MAX)
	DECLARE @oldBalance DECIMAL(15,2);
	DECLARE @newBalance DECIMAL(15,2);
	DECLARE @body VARCHAR(MAX)

	SET @recipient = (SELECT i.AccountId FROM inserted AS i)
	SET @subject = 'Balance change for account: ' + CAST(@recipient AS VARCHAR(MAX))
	SET @oldBalance = (SELECT i.OldSum FROM inserted AS i)
	SET @oldBalance = (SELECT i.NewSum FROM inserted AS i)
	SET @body = 'On ' + CAST(GETDATE() AS VARCHAR(MAX)) +
			    ' your balance was changed from ' + CAST(@oldBalance AS VARCHAR(MAX)) +
				' to ' + CAST(@newBalance AS VARCHAR(MAX))

	INSERT INTO NotificationEmails(Recipient, [Subject], Body) VALUES
	(@recipient, @subject, @body)
END

GO

CREATE PROC usp_DepositMoney (@AccountId INT, @MoneyAmount DECIMAL(18,4))
AS
BEGIN
	BEGIN TRANSACTION
		IF(@MoneyAmount < 0 OR @MoneyAmount IS NULL)
		BEGIN
			ROLLBACK;
			THROW 50001, 'Invalid amount of money', 1;
		END

		IF (NOT EXISTS
		(
			SELECT Id
			FROM Accounts
			WHERE Id = @AccountId
		) OR @AccountId IS NULL)
		BEGIN
			ROLLBACK;
			THROW 50002, 'Invalid account', 1;
		END

		UPDATE Accounts
		SET Balance += @MoneyAmount
		WHERE Id = @AccountId
	COMMIT
END

GO

CREATE PROC usp_WithdrawMoney (@AccountId INT, @MoneyAmount DECIMAL(18,4))
AS
BEGIN
	BEGIN TRANSACTION
		IF(@MoneyAmount < 0 OR @MoneyAmount IS NULL)
		BEGIN
			ROLLBACK;
			THROW 50001, 'Invalid amount of money', 1;
		END
	COMMIT

	IF(NOT EXISTS (
		SELECT Id
			FROM Accounts
			WHERE Id = @AccountId
	) OR @AccountId IS NULL)
	BEGIN
		ROLLBACK;
		THROW 50002, 'Invalid account', 1;
	END

	DECLARE @UserMoney DECIMAL(18,4) = (SELECT Balance from Accounts WHERE Id = @AccountId);

	IF(@MoneyAmount > @UserMoney)
	BEGIN
		ROLLBACK;
		THROW 50003, 'Not enough money', 1;
	END

	UPDATE Accounts
	SET Balance -= @MoneyAmount
	WHERE Id = @AccountId
END

GO

CREATE PROC usp_TransferMoney(@SenderId INT, @ReceiverId INT, @MoneyAmount DECIMAL(18,4))
AS
BEGIN
	BEGIN TRANSACTION
		EXEC usp_WithdrawMoney @SenderId, @MoneyAmount
		EXEC usp_DepositMoney @ReceiverId, @MoneyAmount
	COMMIT
END