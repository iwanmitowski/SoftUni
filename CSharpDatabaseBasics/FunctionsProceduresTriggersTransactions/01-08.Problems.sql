CREATE PROC usp_GetEmployeesSalaryAbove35000
AS
BEGIN
	SELECT FirstName, LastName
	FROM Employees
	WHERE Salary > 35000
END

GO

CREATE PROC usp_GetEmployeesSalaryAboveNumber
@Number DECIMAL(18,4)
AS
BEGIN
	SELECT FirstName, LastName
	FROM Employees
	WHERE Salary >= @Number
END

GO

CREATE PROC usp_GetTownsStartingWith
@StartWith NVARCHAR(MAX)
AS
BEGIN
	SELECT [Name]
    FROM Towns
    WHERE LEFT([Name], LEN(@StartWith)) LIKE @StartWith
END

EXEC usp_GetTownsStartingWith 'bo'

GO

CREATE PROC usp_GetEmployeesFromTown
@Town NVARCHAR(MAX)
AS
BEGIN
	SELECT e.FirstName, e.LastName
	FROM Employees AS e
	JOIN Addresses AS a ON e.AddressID = a.AddressID
	JOIN Towns AS t  ON t.TownID = a.TownID
	WHERE t.Name = @Town
END

GO

CREATE FUNCTION ufn_GetSalaryLevel(@Salary DECIMAL(18,4))
RETURNS NVARCHAR(10)
AS
BEGIN
	IF (@Salary < 30000)
	BEGIN
		RETURN 'Low'
	END
	ELSE IF (@Salary BETWEEN 30000 AND 50000)
	BEGIN
		RETURN 'Average'
	END

	RETURN 'High'
END

GO

CREATE PROC usp_EmployeesBySalaryLevel
@Level NVARCHAR(MAX)
AS
BEGIN
	SELECT FirstName, LastName
	FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @Level
END

GO

CREATE FUNCTION ufn_IsWordComprised(@SetOfLetters NVARCHAR(MAX), @Word NVARCHAR(MAX))
RETURNS BIT
AS
BEGIN
	DECLARE @i INT = 0;
	DECLARE @MatchingCharacters INT = 0;

	WHILE(@i <= LEN(@Word))
	BEGIN
		DECLARE @Letter NVARCHAR(1) = SUBSTRING(@Word, @i, 1);
		DECLARE @IsIncluded BIT = CHARINDEX(@Letter, @SetOfLetters);

		IF(@IsIncluded <> 0)
		BEGIN
			 SET @MatchingCharacters = @MatchingCharacters + 1;
		END

		SET @i = @i + 1;
	END

	IF(@MatchingCharacters = LEN(@Word))
	BEGIN
		RETURN 1;
	END

	RETURN 0;
END

GO

CREATE PROCEDURE usp_DeleteEmployeesFromDepartment(@DepartmentId INT)
AS
BEGIN
	ALTER TABLE Departments
	ALTER COLUMN ManagerId INT NULL

	DELETE
	FROM EmployeesProjects
	WHERE EmployeeID IN (
		SELECT EmployeeID
		FROM Employees
		WHERE DepartmentID = @DepartmentId)

	UPDATE Employees
	SET ManagerID = NULL
	WHERE ManagerID IN (
		SELECT EmployeeID
		FROM Employees
		WHERE DepartmentID = @DepartmentId)

	UPDATE Departments
	SET ManagerID = NULL
	WHERE DepartmentID = @DepartmentId

	DELETE
	FROM Employees
	WHERE DepartmentID = @DepartmentId;

	DELETE
	FROM Departments
	WHERE DepartmentID = @DepartmentId

	SELECT COUNT(*)
	FROM Employees
	WHERE DepartmentID = @DepartmentId
END