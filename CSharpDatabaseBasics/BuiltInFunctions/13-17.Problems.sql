USE Diablo

SELECT TOP(50)
	   Name, FORMAT(Start, 'yyyy-MM-dd') AS Start
  FROM Games
 WHERE YEAR(Start) BETWEEN 2011 AND 2012
 ORDER BY Start, Name

SELECT Username, SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email) - CHARINDEX('@', Email)) AS [Email Provider]
  FROM Users
ORDER BY [Email Provider], Username

SELECT Username, IpAddress AS [IP Address]
  FROM Users
 WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username

SELECT Name AS Game,
	   CASE
		   WHEN DATEPART(HOUR, Start) BETWEEN 0 AND 11 THEN 'Morning'
		   WHEN DATEPART(HOUR, Start) BETWEEN 12 AND 17 THEN 'Afternoon'
		   ELSE 'Evening'
		END AS [Part of the Day],
		CASE
		   WHEN Duration <= 3 THEN 'Extra Short'
		   WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
		   WHEN Duration > 6 THEN 'Long'
		   WHEN Duration IS NULL THEN 'Extra Long'
		END AS Duration
  FROM Games
ORDER BY Game, Duration, [Part of the Day] 
