CREATE FUNCTION dbo.udf_GetColonistsCount(@PlanetName VARCHAR (30))
RETURNS INT
AS
BEGIN
	DECLARE @COUNT INT = (SELECT COUNT(p.Id) 
	FROM Colonists AS c
	JOIN TravelCards AS tc ON tc.ColonistId = c.Id
	JOIN Journeys AS j ON tc.JourneyId = j.Id
	JOIN Spaceports AS s on j.DestinationSpaceportId = s.Id
	JOIN Planets AS p ON s.PlanetId = p.Id
	WHERE p.Name = @PlanetName
	GROUP BY p.Name)

	RETURN @COUNT
END

GO

CREATE PROCEDURE usp_ChangeJourneyPurpose @JourneyId INT, @NewPurpose VARCHAR(11)
AS
BEGIN
	DECLARE @ExistingJourney INT = (SELECT Id
	FROM Journeys
	WHERE Id =  @JourneyId)

	IF(@ExistingJourney IS NULL)
	BEGIN
		THROW 50001,'The journey does not exist!', 1
	END

	DECLARE @Purpose VARCHAR(11) = (SELECT Purpose FROM Journeys WHERE Id = 4);

	IF(@Purpose = @NewPurpose)
	BEGIN
		THROW 50002,'You cannot change the purpose!', 1
	END

	UPDATE Journeys
	SET Purpose = @NewPurpose
	WHERE Id = @JourneyId
END

GO