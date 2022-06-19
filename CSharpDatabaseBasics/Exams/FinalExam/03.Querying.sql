SELECT 
	Name,
	PhoneNumber,
	Address,
	AnimalId,
	DepartmentId
FROM Volunteers
ORDER BY 
	Name,
	AnimalId,
	DepartmentId

SELECT 
	Name,
	AnimalType,
	FORMAT(BirthDate, 'dd.MM.yyyy') AS BirthDate
FROM Animals AS a
JOIN AnimalTypes AS at ON at.Id = a.AnimalTypeId
ORDER BY Name

SELECT TOP(5)
	o.Name AS Owner,
	COUNT(*) AS CountOfAnimals
FROM Owners AS o
JOIN Animals AS a ON a.OwnerId = o.Id
GROUP BY o.Name
ORDER BY CountOfAnimals DESC,
	     o.Name

SELECT
	CONCAT(o.Name,'-', a.Name) AS OwnersAnimals,
	 o.PhoneNumber,
	 c.Id
FROM Owners AS o
JOIN Animals AS a ON a.OwnerId = o.Id
JOIN AnimalTypes AS at ON at.Id = a.AnimalTypeId
JOIN AnimalsCages AS ac ON ac.AnimalId = a.Id
JOIN Cages AS c ON ac.CageId = c.Id
WHERE AnimalType = 'Mammals'
ORDER BY o.Name,
		 a.Name DESC

SELECT 
	 v.Name,
	 v.PhoneNumber,
	 TRIM(SUBSTRING(V.Address,  CHARINDEX(',', v.Address)+2, LEN(v.Address))) AS Address
FROM Volunteers AS v
JOIN VolunteersDepartments AS vd ON vd.Id = v.DepartmentId
WHERE vd.DepartmentName = 'Education program assistant' AND
	  v.Address LIKE '%Sofia%'
ORDER BY v.Name

SELECT 
	a.Name,
	YEAR(a.Birthdate) AS BirthYear,
	at.AnimalType
FROM Animals AS a
JOIN AnimalTypes AS at ON at.Id = a.AnimalTypeId
WHERE OwnerId IS NULL AND
	  DATEDIFF(YEAR, a.BirthDate, '01/01/2022') < 5 AND
	  at.AnimalType NOT LIKE 'Birds'
ORDER BY a.Name