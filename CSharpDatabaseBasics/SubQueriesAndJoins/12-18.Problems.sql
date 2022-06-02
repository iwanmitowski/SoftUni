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


-- 15

SELECT COUNT(*) AS [Count]
  FROM Countries AS c
  LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
  LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
 WHERE MountainId IS NULL
