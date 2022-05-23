SELECT PeakName
  FROM Peaks
ORDER BY PeakName ASC

SELECT TOP(30) CountryName, Population
  FROM Countries
 WHERE ContinentCode = 'EU'
 ORDER BY Population DESC,
		  CountryName ASC

SELECT CountryName,
	   CountryCode,
	   CASE 
			WHEN CurrencyCode = 'EUR' THEN 'Euro'
			ELSE 'Not Euro'
		END AS Currency
  FROM Countries
 ORDER BY CountryName

 USE Diablo
 SELECT [Name] FROM Characters
    ORDER BY [Name]