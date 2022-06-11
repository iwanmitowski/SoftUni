CREATE PROC usp_AssignProject(@emloyeeId INT, @projectID INT)
AS 
BEGIN TRANSACTION
	DECLARE @EmployeeProjectsCount INT = (SELECT COUNT(*) FROM EmployeesProjects WHERE EmployeeID = @emloyeeId)

	IF(@EmployeeProjectsCount >= 3)
	BEGIN
		ROLLBACK
		RAISERROR('The employee has too many projects!', 16, 1) 		
		RETURN	
	END

	INSERT INTO EmployeesProjects VALUES
	(@emloyeeId, @projectID)
COMMIT

GO

CREATE TRIGGER tr_OnDeletedEmployees
ON [Employees] FOR DELETE
AS
BEGIN
	INSERT INTO Deleted_Employees
	(
	 FirstName,
	 LastName,
	 MiddleName,
	 JobTitle,
	 DepartmentId,
	 Salary
	)
	 SELECT 
		FirstName,
		LastName,
		MiddleName,
		JobTitle,
		DepartmentId,
		Salary
	 FROM deleted
END