SELECT FirstName, LastName, FORMAT(BirthDate, 'MM-dd-yyyy'), c.Name AS Hometown, Email 
FROM Accounts AS a
JOIN Cities  AS c ON a.CityId = c.Id
WHERE Email LIKE 'e%'
ORDER BY c.Name

SELECT c.Name, COUNT(h.Id) AS Hotels
FROM Cities AS c
JOIN Hotels AS h ON c.Id = h.CityId
GROUP BY c.Name
ORDER BY COUNT(h.Id) DESC,
		 c.Name

SELECT a.Id,
	   CONCAT(a.FirstName, ' ', a.LastName) AS FullName,
	   MAX(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS LongestTrip,
	   MIN(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS ShortestTrip
FROM Accounts AS a
JOIN AccountsTrips AS at ON a.Id = at.AccountId
JOIN Trips AS t ON t.Id = at.TripId
WHERE t.CancelDate IS NULL AND
	  a.MiddleName IS NULL
GROUP BY a.Id, CONCAT(a.FirstName, ' ', a.LastName)
ORDER BY LongestTrip DESC,
		 ShortestTrip

SELECT TOP(10) c.Id, c.Name, c.CountryCode AS Country, Count(a.Id) AS Accounts
FROM Accounts AS a
JOIN Cities AS c ON a.CityId = c.Id 
GROUP BY c.Id, c.Name, c.CountryCode
ORDER BY Accounts DESC

SELECT a.Id,
	   a.Email,
	   c.[Name] AS City,
	   COUNT(at.TripId) AS Trips
FROM Accounts AS a
JOIN AccountsTrips AS at ON a.Id = at.AccountId
JOIN Trips AS t ON at.TripId = t.Id
JOIN Rooms AS r ON r.Id = t.RoomId
JOIN Hotels AS h ON h.Id = r.HotelId
JOIN Cities AS c ON a.CityId = c.Id
WHERE a.CityId = h.CityId
GROUP BY a.Id,
         a.Email,
         C.Name
ORDER BY Trips DESC,
         a.Id

SELECT t.Id, CONCAT(a.FirstName, ' ', a.MiddleName,' ' a.LastName) AS FullName, c1.Name AS [From], c2.name AS [To]
FROM Trips AS t
JOIN Rooms AS r ON t.RoomId = r.Id
JOIN Hotels AS h  ON h.Id = r.HotelId
JOIN Cities AS c2 ON h.CityId = c2.Id
JOIN AccountsTrips AS at ON t.Id = at.AccountId
JOIN Accounts AS a ON a.Id = at.AccountId
JOIN Cities AS c1 ON a.Id = c1.Id
ORDER BY FullName,
		 t.Id

SELECT t.Id,
	 CONCAT(a.FirstName, ' ', ISNULL(a.MiddleName,''), ' ', a.LastName) AS [Full Name],
	 ca.Name as [From],
	 ch.Name as [To],
	 CASE 
		  WHEN t.CancelDate IS NOT NULL THEN 'Canceled'
		  ELSE CONCAT(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate), ' days')
	 END AS Duration
FROM Trips AS t
JOIN AccountsTrips AS at ON t.Id = at.TripId
JOIN Accounts AS a ON a.Id = at.AccountId
JOIN Cities AS ca ON a.CityId = ca.Id
JOIN Rooms AS r ON r.Id = t.RoomId
JOIN Hotels AS h ON h.Id = r.HotelId
JOIN Cities AS ch ON h.CityId = ch.Id
ORDER BY [Full Name],
		 t.Id
		