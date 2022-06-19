INSERT INTO Volunteers (Name, PhoneNumber, Address, AnimalId, DepartmentId) VALUES
('Anita Kostova',	'0896365412',	'Sofia, 5 Rosa str.',	15,	1),
('Dimitur Stoev',	'0877564223',	null,	42,	4),
('Kalina Evtimova',	'0896321112',	'Silistra, 21 Breza str.',	9,	7),
('Stoyan Tomov',	'0898564100',	'Montana, 1 Bor str.',	18,	8),
('Boryana Mileva',	'0888112233',	null,	31,	5)

INSERT INTO Animals (Name, BirthDate, OwnerId, AnimalTypeId) VALUES
('Giraffe',	'2018-09-21',	21,	1),
('Harpy Eagle',	'2015-04-17',	15,	3),
('Hamadryas Baboon',	'2017-11-02',	null,	1),
('Tuatara',	'2021-06-30',	2,	4)

SELECT * FROM Owners
UPDATE Animals
SET OwnerId = 4
WHERE OwnerId IS NULL

DELETE
FROM Volunteers
WHERE DepartmentId = (
	SELECT Id 
	FROM VolunteersDepartments
	WHERE DepartmentName = 'Education program assistant')

DELETE
FROM VolunteersDepartments
WHERE DepartmentName = 'Education program assistant'

