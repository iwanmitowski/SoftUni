SELECT TOP(1) * FROM Pilots
SELECT TOP(1) * FROM Passengers


INSERT INTO Passengers
SELECT FirstName + ' ' + LastName,
	   FirstName + LastName + '@gmail.com'
FROM Pilots
WHERE Id BETWEEN 5 AND 15

UPDATE Aircraft
SET Condition = 'A'
WHERE Condition IN ('C', 'B') AND
	  (FlightHours IS NULL OR FlightHours <= 100) AND
	  YEAR >= 2013

DELETE 
FROM Passengers
WHERE LEN(FullName) <= 10
