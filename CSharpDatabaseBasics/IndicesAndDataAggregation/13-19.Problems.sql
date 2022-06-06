SELECT DepartmentID,
	   SUM(Salary) as TotalSalary
  FROM Employees
GROUP BY DepartmentID

SELECT DepartmentID, MIN(Salary) AS MinimumSalary
  FROM Employees 
 WHERE DepartmentID IN (2, 5, 7) AND HireDate > '01/01/2000'
GROUP BY DepartmentID

 SELECT *
   INTO #NewTable
   FROM Employees
  WHERE Salary > 30000

DELETE 
  FROM #NewTable 
 WHERE ManagerID = 42

UPDATE #NewTable 
   SET Salary+=5000
 WHERE DepartmentID = 1;  

SELECT DepartmentID,
	   AVG(Salary)
  FROM #NewTable
GROUP BY DepartmentID

SELECT DepartmentID, MAX(Salary) AS MaxSalary
  FROM Employees 
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

SELECT COUNT (*) AS Count
  FROM Employees
 WHERE ManagerID IS NULL
GROUP BY ManagerID

SELECT DepartmentId, Salary AS ThirdHighestSalary
  FROM (
SELECT DepartmentID,
	   Salary,
	   DENSE_RANK() OVER (PARTITION BY DepartmentId ORDER BY Salary DESC) AS Rank 
  FROM Employees
GROUP BY DepartmentID, Salary) AS r
WHERE Rank = 3

SELECT TOP(10) e.FirstName, e.LastName, e.DepartmentID
  FROM (
SELECT DepartmentID,
	   AVG(Salary) AS AvgSalary
  FROM Employees
GROUP BY DepartmentID) AS r
JOIN Employees AS e ON e.DepartmentID = r.DepartmentID
WHERE e.Salary > r.AvgSalary
ORDER BY DepartmentID