USE SoftUni

SELECT TOP(5) e.EmployeeID, e.JobTitle, e.AddressID, a.AddressText
  FROM Employees AS e
  JOIN Addresses AS a ON e.AddressID = a.AddressID
ORDER BY e.AddressID

SELECT TOP(50) e.FirstName, e.LastName, t.Name as [Town], a.AddressText
  FROM Employees AS e
  JOIN Addresses AS a ON e.AddressID = a.AddressID
  JOIN Towns AS t ON a.TownID = t.TownID
ORDER BY e.FirstName, e.LastName

SELECT e.EmployeeID, e.FirstName, e.LastName, d.Name as [DepartmentName]
  FROM Employees AS e
  JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
 WHERE d.Name = 'Sales'
ORDER BY e.EmployeeID

SELECT TOP(5) e.EmployeeID, e.FirstName, e.Salary, d.Name as [DepartmentName]
  FROM Employees AS e
  JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
 WHERE e.Salary > 15000
ORDER BY d.DepartmentID

SELECT TOP(3) e.EmployeeID, e.FirstName
  FROM Employees AS e
  LEFT JOIN EmployeesProjects AS ep ON  e.EmployeeID = ep.EmployeeID
  LEFT JOIN Projects AS p ON ep.ProjectID = p.ProjectID
  WHERE ep.ProjectID IS NULL
ORDER BY e.EmployeeID 

SELECT e.FirstName, e.LastName, e.HireDate, d.Name as [DeptName]
  FROM Employees AS e
  JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
 WHERE e.HireDate > '01-01-1999' 
   AND d.Name IN ('Sales', 'Finance')
ORDER BY e.HireDate

SELECT TOP(5) e.EmployeeID, e.FirstName, p.Name AS [ProjectName]
  FROM Employees AS e
  LEFT JOIN EmployeesProjects AS ep ON  e.EmployeeID = ep.EmployeeID
  LEFT JOIN Projects AS p ON ep.ProjectID = p.ProjectID
 WHERE p.StartDate > '08-13-2002' AND p.EndDate IS NULL
ORDER BY e.EmployeeID

SELECT TOP(5) e.EmployeeID, e.FirstName, 
  CASE WHEN YEAR(p.StartDate) >= 2005 THEN NULL
	   ELSE p.Name 
   END AS [ProjectName]
  FROM Employees AS e
  LEFT JOIN EmployeesProjects AS ep ON  e.EmployeeID = ep.EmployeeID
  LEFT JOIN Projects AS p ON ep.ProjectID = p.ProjectID
 WHERE e.EmployeeID = 24

SELECT e.EmployeeID, e.FirstName, m.EmployeeID AS [ManagerID] , m.FirstName AS [ManagerName]
  FROM Employees AS e 
  JOIN Employees AS m ON e.ManagerID = m.EmployeeID
 WHERE m.EmployeeID IN (3,7)
 ORDER BY e.EmployeeID

SELECT TOP(50)
	   e.EmployeeID,
	   e.FirstName + ' ' + e.LastName AS [EmployeeName],
	   m.FirstName + ' ' + m.LastName AS [ManagerName],
	   d.Name AS [DepartmentName]
  FROM Employees AS e 
  JOIN Employees AS m ON e.ManagerID = m.EmployeeID
  JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID

SELECT MIN(r.AvgSalary) AS [MinAverageSalary]
FROM (
SELECT AVG(e.Salary) AS AvgSalary
  FROM Employees AS e
  JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
GROUP BY d.DepartmentID) AS r