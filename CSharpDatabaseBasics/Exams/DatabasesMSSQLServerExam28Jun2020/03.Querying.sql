SELECT Id,
	   FORMAT(JourneyStart, 'dd/MM/yyyy') AS JourneyStart,
	   FORMAT(JourneyEnd, 'dd/MM/yyyy') AS JourneyEnd
FROM Journeys
WHERE Purpose = 'Military'
ORDER BY JourneyStart

SELECT c.Id,
	 CONCAT(c.FirstName, ' ', c.LastName) AS full_name
FROM Colonists AS c
JOIN TravelCards AS tc ON tc.ColonistId = c.Id
WHERE JobDuringJourney = 'Pilot'
ORDER BY Id

SELECT COUNT(*) AS count
FROM Colonists AS c
JOIN TravelCards AS tc ON tc.ColonistId = c.Id
JOIN Journeys AS j on tc.JourneyId = j.Id
WHERE j.Purpose = 'Technical'

SELECT s.Name, s.Manufacturer
FROM Spaceships AS s
JOIN Journeys AS j ON j.SpaceshipId = s.Id
JOIN TravelCards AS tc ON tc.JourneyId = j.Id
JOIN Colonists AS c ON tc.ColonistId = c.Id
WHERE tc.JobDuringJourney = 'Pilot' AND
	  DATEDIFF(YEAR, c.BirthDate, '01/01/2019') < 30
GROUP BY s.Name, s.Manufacturer
ORDER BY s.Name

select * from Planets

SELECT p.Name,
	 COUNT(j.Id) AS JourneysCount
FROM Planets AS p
JOIN Spaceports AS s ON s.PlanetId = p.Id
JOIN Journeys AS j ON j.DestinationSpaceportId = s.Id
GROUP BY p.Name 
ORDER BY JourneysCount DESC,
	     p.Name

SELECT *
FROM (
SELECT tc.JobDuringJourney,
	 CONCAT(c.FirstName, ' ', c.LastName) AS FullName,
	 DENSE_RANK() OVER (PARTITION BY tc.JobDuringJourney ORDER BY c.Birthdate) AS JobRank
FROM Colonists AS c
JOIN TravelCards AS tc ON tc.ColonistId = c.Id
JOIN Journeys AS j ON tc.JourneyId = j.Id
GROUP BY tc.JobDuringJourney, c.FirstName, c.LastName, c.BirthDate) AS r
WHERE JobRank = 2