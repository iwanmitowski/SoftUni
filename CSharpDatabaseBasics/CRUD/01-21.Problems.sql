SELECT *
  FROM Departments

SELECT [Name]
  FROM Departments

SELECT FirstName, LastName, Salary
  FROM Employees

SELECT FirstName, MiddleName, LastName
  FROM Employees

SELECT FirstName + '.' + LastName + '@softuni.bg' AS [Full Email Address]
  FROM Employees

 SELECT DISTINCT Salary
   FROM Employees

SELECT * 
  FROM Employees
 WHERE JobTitle = 'Sales Representative'

SELECT FirstName, LastName, JobTitle
  FROM Employees
 WHERE Salary BETWEEN 20000. AND 30000

 SELECT FirstName + ' ' + MiddleName + ' ' + LastName AS [Full Name]
   FROM Employees
  WHERE Salary IN (25000, 14000, 12500, 23600)

SELECT FirstName, LastName
  FROM Employees
 WHERE ManagerID IS NULL

SELECT FirstName, LastName, Salary
  FROM Employees
 WHERE Salary > 50000
 ORDER BY Salary DESC

SELECT TOP 5 FirstName, LastName
 FROM Employees
ORDER BY Salary DESC

SELECT FirstName, LastName
  FROM Employees
 WHERE DepartmentID NOT IN (4)

SELECT * 
  FROM Employees
ORDER BY Salary DESC,
		 FirstName ASC,
		 LastName DESC,
		 MiddleName

CREATE VIEW V_EmployeesSalaries AS
SELECT FirstName, LastName, Salary
  FROM Employees

CREATE VIEW V_EmployeeNameJobTitle AS
SELECT
	  CASE 
		   WHEN MiddleName IS NULL
		   THEN FirstName + ' ' + LastName 
		   ELSE FirstName + ' ' + MiddleName + ' ' + LastName
	   END AS [Full Name],
	   JobTitle
  FROM Employees

SELECT DISTINCT JobTitle
  FROM Employees

SELECT TOP(10) *
  FROM Projects
ORDER BY StartDate ASC,
		 Name ASC
 
SELECT TOP(7) FirstName, LastName, HireDate
  FROM Employees
ORDER BY HireDate DESC

UPDATE Employees
   SET Employees.Salary *= 1.12
  FROM Employees AS e
  JOIN Departments AS d ON d.DepartmentId = e.DepartmentId
 WHERE d.Name IN ('Information Services', 'Marketing', 'Tool Design', 'Engineering')


SELECT Salary
  FROM Employees