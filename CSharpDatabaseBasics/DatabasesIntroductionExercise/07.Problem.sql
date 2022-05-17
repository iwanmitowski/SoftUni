CREATE TABLE People
(
	Id INT IDENTITY,
	Name NVARCHAR(200) NOT NULL,
	Picture VARBINARY(2048),
	Height FLOAT(2),
	Weight FLOAT(2),
	Gender CHAR CHECK (GENDER IN ('m','f')),
	Birthdate DATETIME NOT NULL,
	Biograpy NVARCHAR(MAX)
)

INSERT INTO People VALUES
('a', NULL, 78.4, 45.4, 'm', GETDATE(), 'asddasda'),
('b', NULL, 73.4, 44.4, 'f', GETDATE(), 'asddasda'),
('c', NULL, 74.4, 45.4, 'm', GETDATE(), 'asddasda'),
('d', NULL, 75.4, 46.4, 'f', GETDATE(), 'asddasda'),
('e', NULL, 76.4, 47.4, 'm', GETDATE(), 'asddasda')