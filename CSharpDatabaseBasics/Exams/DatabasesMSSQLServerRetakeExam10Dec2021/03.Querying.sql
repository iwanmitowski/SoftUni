SELECT Manufacturer,
	   Model,
	   FlightHours,
	   Condition
FROM Aircraft
ORDER BY FlightHours DESC

SELECT p.FirstName,
	   p.LastName,
	   a.Manufacturer,
	   a.Model,
	   a.FlightHours
FROM Pilots AS p
LEFT JOIN PilotsAircraft AS pa ON p.Id = pa.PilotId
LEFT JOIN Aircraft AS a ON a.Id = pa.AircraftId
WHERE a.FlightHours IS NOT NULL AND
	  a.FlightHours < 304
ORDER BY FlightHours DESC,
		 FirstName ASC

SELECT TOP(20)
	   fd.Id AS [DestinationId],
	   Start,
	   p.FullName,
	   AirportName,
	   TicketPrice
FROM FlightDestinations AS fd
JOIN Airports AS a ON fd.AirportId = a.Id
JOIN Passengers AS p ON fd.PassengerId = p.Id
WHERE DAY(Start) % 2 = 0
ORDER BY TicketPrice DESC,
		 AirportName ASC

SELECT a.Id AS AircraftId,
	   Manufacturer,
	   FlightHours,
	   COUNT(fd.Id) AS FlightDestinationsCount,
	   ROUND(AVG(TicketPrice), 2) AS AvgPrice
FROM Aircraft AS a
JOIN FlightDestinations AS fd ON fd.AircraftId = a.Id
GROUP BY a.Id, Manufacturer, FlightHours
HAVING COUNT(fd.Id) >= 2
ORDER BY COUNT(fd.Id) DESC,
		 a.Id

SELECT p.FullName,
	   COUNT(fd.AircraftId) AS CountOfAircraft,
	   SUM(fd.TicketPrice) AS TotalPayed
FROM Passengers AS p
JOIN FlightDestinations AS fd ON fd.PassengerId = p.Id
GROUP BY p.FullName
HAVING COUNT(fd.AircraftId) > 1 AND
	   p.FullName LIKE '_a%'
ORDER BY p.FullName

SELECT AirportName,
	   Start AS DayTime,
	   TicketPrice,
	   FullName,
	   Manufacturer,
	   Model
FROM FlightDestinations AS fd
JOIN Airports AS ap ON fd.AirportId = ap.Id
JOIN Aircraft AS ac ON fd.AircraftId = ac.Id
JOIN Passengers AS p ON fd.PassengerId = p.Id
WHERE DATEPART(HOUR, fd.Start) BETWEEN 6 AND 20 AND
	  TicketPrice > 2500
ORDER BY Model

