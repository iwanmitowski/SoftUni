SELECT CigarName, PriceForSingleCigar, ImageURL
FROM Cigars
ORDER BY PriceForSingleCigar,
	     CigarName DESC

SELECT 
	c.Id,
	c.CigarName,
	c.PriceForSingleCigar,
	t.TasteType,
	t.TasteStrength
FROM Cigars AS c
JOIN Tastes AS t ON c.TastId = t.Id
WHERE TasteType IN ('Earthy' ,'Woody')
ORDER BY PriceForSingleCigar DESC

SELECT c.Id,
	   c.FirstName + ' ' + c.LastName AS ClientName,
	   c.Email
FROM Clients AS c
LEFT JOIN ClientsCigars AS cc ON c.Id = cc.ClientId
WHERE cc.CigarId IS NULL
ORDER BY ClientName

SELECT TOP(5)
	CigarName,
	PriceForSingleCigar,
	ImageURL
FROM Cigars AS c
JOIN Sizes AS s ON c.SizeId = s.Id
WHERE 
	  (c.CigarName LIKE '%ci%' OR
	  c.PriceForSingleCigar > 50) AND
	  s.RingRange > 2.55 AND
	  s.Length >= 12
ORDER BY CigarName,
		 PriceForSingleCigar DESC

SELECT 
	CONCAT(c.FirstName, ' ', c.LastName) AS FullName,
	a.Country,
	a.ZIP,
	CONCAT('$', MAX(ci.PriceForSingleCigar)) AS CigarPrice
FROM Clients AS c
JOIN Addresses AS a ON c.AddressId = a.Id
JOIN ClientsCigars AS cc ON cc.ClientId = c.Id
JOIN Cigars AS ci ON ci.Id = cc.CigarId
WHERE a.ZIP NOT LIKE '%[^0-9]%'
GROUP BY FirstName, LastName, Country, ZIP

SELECT 
	c.LastName,
	CEILING(AVG(s.Length)) AS CiagrLength,
	CEILING(AVG(s.RingRange)) AS CiagrRingRange
FROM Clients AS c
JOIN ClientsCigars AS cc ON cc.ClientId = c.Id
JOIN Cigars AS ci ON ci.Id = cc.CigarId
JOIN Sizes AS s ON s.Id = ci.SizeId
GROUP BY c.LastName
ORDER BY CEILING(AVG(s.Length)) DESC