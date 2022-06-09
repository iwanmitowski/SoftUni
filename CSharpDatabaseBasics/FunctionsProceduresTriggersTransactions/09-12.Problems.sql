CREATE PROCEDURE usp_GetHoldersFullName
AS
BEGIN
	SELECT FirstName + ' ' + LastName AS [Full Name]
	FROM AccountHolders
END

GO

CREATE PROC usp_GetHoldersWithBalanceHigherThan(@Balance MONEY)
AS
BEGIN
	SELECT ah.FirstName, ah.LastName
	FROM AccountHolders AS ah
	JOIN Accounts AS a ON ah.Id = a.AccountHolderId
	GROUP BY ah.FirstName, ah.LastName, ah.Id
	HAVING SUM(Balance) > @Balance
	ORDER BY ah.FirstName, ah.LastName
END

GO

CREATE FUNCTION ufn_CalculateFutureValue(@I DECIMAL(14,4), @R FLOAT, @T INT)
RETURNS DECIMAL(14,4)
AS
BEGIN
	RETURN ROUND(@I * (POWER((1 + @R),@T)), 4);
END

GO

CREATE OR ALTER PROC usp_CalculateFutureValueForAccount
@AccountId INT,
@R FLOAT
AS
BEGIN
	SELECT 
		ah.Id AS [Account Id],
		ah.FirstName,
		ah.LastName,
		a.Balance AS [Current Balance],
		dbo.ufn_CalculateFutureValue(a.Balance, @R, 5) AS [Balance in 5 year]
	FROM AccountHolders AS ah
	JOIN Accounts AS a ON ah.Id = a.AccountHolderId AND a.Id = @AccountId
END

EXEC dbo.usp_CalculateFutureValueForAccount 1, 0.1