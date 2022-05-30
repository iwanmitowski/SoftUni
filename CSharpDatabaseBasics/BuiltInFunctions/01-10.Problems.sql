USE SoftUni

SELECT FirstName, LastName
  FROM Employees
 WHERE FirstName LIKE 'Sa%'

 SELECT FirstName, LastName
  FROM Employees
 WHERE LastName LIKE '%ei%'

 SELECT FirstName
   FROM Employees
  WHERE DepartmentID IN (3,10) AND
		YEAR(HireDate) BETWEEN 1995 AND 2005

SELECT FirstName, LastName
  FROM Employees
 WHERE LOWER(JobTitle) NOT LIKE '%engineer%'

 SELECT Name 
   FROM Towns
  WHERE LEN(Name) IN (5,6)
 ORDER BY Name

 SELECT TownId, Name
   FROM Towns
  WHERE LEFT(Name, 1) IN ('M', 'K', 'B', 'E')
 ORDER BY Name

 SELECT TownId, Name
   FROM Towns
  WHERE LEFT(Name, 1) NOT IN ('R', 'D', 'B')
 ORDER BY Name

GO

CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName
  FROM Employees
 WHERE YEAR(HireDate) > 2000

GO

SELECT FirstName, LastName
  FROM Employees
 WHERE LEN(LastName) = 5

SELECT * FROM (
SELECT EmployeeID,
	   FirstName,
	   LastName,
	   Salary,
	   DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeId) AS Rank
  FROM Employees
 WHERE Salary BETWEEN 10000 AND 50000

 ) as RES
 WHERE Rank = 2
  ORDER BY Salary DESC
