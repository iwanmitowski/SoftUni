CREATE FUNCTION udf_FlightDestinationsByEmail(@email NVARCHAR(MAX))
RETURNS INT
AS
BEGIN
	RETURN (SELECT COUNT(p.Id)
	FROM Passengers AS p
	JOIN FlightDestinations AS fd ON fd.PassengerId = p.Id
	WHERE p.Email LIKE @email)
END

GO

CREATE PROC usp_SearchByAirportName @airportName VARCHAR(70)
AS
BEGIN
	SELECT AirportName,
		 p.FullName,
		 CASE 
			WHEN fd.TicketPrice <= 400 THEN 'Low'
			WHEN fd.TicketPrice BETWEEN 401 AND 1500 THEN 'Medium'
			ELSE 'High'
		 END AS LevelOfTickerPrice,
		 ac.Manufacturer,
		 ac.Condition,
		 at.TypeName
	FROM Airports AS a
	JOIN FlightDestinations AS fd ON fd.AirportId = a.Id AND a.AirportName = @airportName
	JOIN Passengers AS p ON fd.PassengerId = p.Id
	JOIN Aircraft AS ac ON fd.AircraftId = ac.Id
	JOIN AircraftTypes AS at ON ac.TypeId = at.Id
	ORDER BY ac.Manufacturer,
			 p.FullName
END