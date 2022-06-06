SELECT COUNT(*) AS Count
  FROM WizzardDeposits

SELECT MAX(MagicWandSize) AS LongestMagicWand
  FROM WizzardDeposits

SELECT DepositGroup,
	   MAX(MagicWandSize) AS LongestMagicWand
  FROM WizzardDeposits
 GROUP BY DepositGroup

SELECT TOP(2)
	  DepositGroup
  FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize) ASC

SELECT DepositGroup,
	   SUM(DepositAmount) AS TotalSum
  FROM WizzardDeposits
 GROUP BY DepositGroup

 SELECT DepositGroup,
	   SUM(DepositAmount) AS TotalSum
  FROM WizzardDeposits
 WHERE MagicWandCreator = 'Ollivander family'
 GROUP BY DepositGroup
 
SELECT DepositGroup,
	   SUM(DepositAmount) AS TotalSum
  FROM WizzardDeposits
 WHERE MagicWandCreator = 'Ollivander family'
 GROUP BY DepositGroup
 HAVING SUM(DepositAmount) < 150000
 ORDER BY SUM(DepositAmount) DESC

SELECT DepositGroup,
	   MagicWandCreator,
	   MIN(DepositCharge) AS MinDepositCharge
  FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator


SELECT AgeGroups, COUNT(*) AS WizardCount
  FROM (
SELECT
	  CASE
		   WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
		   WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
		   WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
		   WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
		   WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
		   WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
		   ELSE '[61+]'
	   END AS AgeGroups
  FROM WizzardDeposits) AS r
GROUP BY AgeGroups

SELECT LEFT(FirstName, 1) AS FirstLetter
  FROM WizzardDeposits
 WHERE DepositGroup = 'Troll Chest'
GROUP BY LEFT(FirstName, 1)
ORDER BY LEFT(FirstName, 1)

SELECT * FROM WizzardDeposits

SELECT DepositGroup,
	   IsDepositExpired,
	   AVG(DepositInterest) AS AverageInterest
  FROM WizzardDeposits
 WHERE DepositStartDate > '01/01/1985'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC,
		 IsDepositExpired
--Вариант 1
 SELECT SUM(Host.DepositAmount - Guest.DepositAmount) AS Difference
   FROM WizzardDeposits AS Host
   JOIN WizzardDeposits AS Guest ON Host.Id + 1 = Guest.Id

--Вариант 2
  SELECT SUM(Result.[Difference])
    FROM (
  SELECT Host.DepositAmount - LEAD(Host.DepositAmount) OVER(ORDER BY Id) AS [Difference]
    FROM WizzardDeposits AS Host) AS Result