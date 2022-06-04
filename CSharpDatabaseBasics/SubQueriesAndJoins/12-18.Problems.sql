USE Geography

SELECT mc.CountryCode, m.MountainRange, p.PeakName, p.Elevation
  FROM Mountains AS m
  JOIN MountainsCountries AS mc ON m.Id = mc.MountainId
  JOIN Peaks AS p ON p.MountainId = m.Id
 WHERE mc.CountryCode = 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC

SELECT mc.CountryCode, COUNT(*) AS [MountainRanges]
  FROM Mountains AS m
  JOIN MountainsCountries AS mc ON m.Id = mc.MountainId
GROUP BY mc.CountryCode
 HAVING mc.CountryCode IN ('BG', 'RU', 'US')

 SELECT * FROM Rivers WHERE RiverName = 'Niger'

SELECT TOP(5) c.CountryName, r.RiverName
  FROM Countries AS c
  LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
  LEFT JOIN Rivers AS r ON r.Id = cr.RiverId
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName 

SELECT ContinentCode, CurrencyCode, CurrencyUsage
  FROM (
SELECT ContinentCode,
	   CurrencyCode,
	   COUNT(CurrencyCode) AS CurrencyUsage,
	   DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY COUNT(CurrencyCode) DESC) AS Ranking
  FROM Countries
GROUP BY ContinentCode, CurrencyCode) AS res
WHERE Ranking = 1 AND CurrencyUsage > 1

SELECT COUNT(*) AS [Count]
  FROM Countries AS c
  LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
  LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
 WHERE MountainId IS NULL

SELECT TOP(5) c.CountryName, MAX(p.Elevation) AS [HighestPeakElevation], MAX(r.Length) AS [LongestRiverLength]
  FROM Countries AS c
  JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
  JOIN Mountains AS m ON mc.MountainId = m.Id
  JOIN Peaks AS p ON P.MountainId = m.Id
  JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode 
  JOIN Rivers AS r ON cr.RiverId = r.Id
GROUP BY c.CountryName
ORDER BY MAX(p.Elevation) DESC,
		 MAX(r.Length) DESC,
		 c.CountryName

SELECT TOP(5)
	   [Country],
	   ISNULL([Highest Peak Name], '(no highest peak)') AS [Highest Peak Name],
	   ISNULL([Highest Peak Elevation], 0)  AS [Highest Peak Elevation],
	   ISNULL(res.MountainRange, '(no mountain)') AS [Mountain]
FROM (
SELECT
	   c.CountryName AS Country,
	   p.PeakName AS [Highest Peak Name],
	   MAX(p.Elevation) AS [Highest Peak Elevation],
	   m.MountainRange,
	   DENSE_RANK() OVER (PARTITION BY c.CountryName ORDER BY Max(p.Elevation) DESC) AS Ranking
  FROM Countries AS c
  LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
  LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
  LEFT JOIN Peaks AS p ON P.MountainId = m.Id
GROUP BY c.CountryName, p.PeakName, m.MountainRange) AS res
WHERE Ranking = 1
ORDER BY  [Country], [Highest Peak Name]