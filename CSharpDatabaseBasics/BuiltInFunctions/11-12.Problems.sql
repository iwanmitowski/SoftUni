USE Geography

SELECT CountryName AS [Country Name],
	   IsoCode AS [ISO Code]
  FROM Countries
 WHERE LEN(CountryName) - LEN(REPLACE(UPPER(CountryName), 'A', '')) >= 3
ORDER BY [ISO Code]

SELECT PeakName, RiverName, LOWER(CONCAT(PeakName, SUBSTRING(RiverName,2, LEN(Rivername)))) AS Mix
  FROM Peaks, Rivers -- Cross join between tables
 WHERE LEFT(RiverName, 1) = RIGHT(PeakName, 1)
 ORDER BY Mix