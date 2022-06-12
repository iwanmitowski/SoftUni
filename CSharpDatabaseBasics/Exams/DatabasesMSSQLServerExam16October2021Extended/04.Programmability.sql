CREATE FUNCTION udf_ClientWithCigars(@name VARCHAR(MAX)) 
RETURNS INT
AS
BEGIN
	DECLARE @result INT;

	SET @result =
	(SELECT 
	COUNT(*) 
	FROM Clients cl
	JOIN ClientsCigars cc ON cc.ClientId = cl.Id
	JOIN Cigars c ON cc.CigarId = c.Id
	WHERE cl.FirstName LIKE @name)

	RETURN @result
END

GO

CREATE PROC usp_SearchByTaste(@taste VARCHAR(MAX))
AS
BEGIN
	SELECT 
		c.CigarName,
		CONCAT('$', c.PriceForSingleCigar) AS Price,
		t.TasteType,
		b.BrandName,
		CONCAT(s.Length, ' cm') AS CigarLength,
		CONCAT(s.RingRange, ' cm') AS CigarRingRange
	FROM Cigars c
	JOIN Tastes t ON c.TastId = t.Id
	JOIN Sizes s ON c.SizeId = s.Id
	JOIN Brands b ON c.BrandId = b.Id
	WHERE t.TasteType LIKE @taste
	ORDER BY s.[Length], s.RingRange DESC
END