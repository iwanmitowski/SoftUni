CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors
(
	Id INT PRIMARY KEY IDENTITY,
	DirectorName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Directors VALUES
('A', NULL),
('B', 'asd'),
('C', NULL),
('D', NULL),
('E', NULL)

CREATE TABLE Genres
(
	Id INT PRIMARY KEY IDENTITY,
	GenreName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)
INSERT INTO Genres VALUES
('A', NULL),
('B', 'asd'),
('C', NULL),
('D', NULL),
('E', NULL)

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)
INSERT INTO Categories VALUES
('A', NULL),
('B', 'asd'),
('C', NULL),
('D', NULL),
('E', NULL)

CREATE TABLE Movies
(
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(100) NOT NULL,
	DirectorId INT FOREIGN KEY (Id) REFERENCES Directors,
	CopyrightYear DATETIME2,
	Length TIME NOT NULL,
	GenreId INT FOREIGN KEY (Id) REFERENCES Genres,
	Categoryd INT FOREIGN KEY (Id) REFERENCES Categories,
	Rating INT,
	Notes NVARCHAR(MAX)
)
INSERT INTO Movies VALUES
('A', 1, GETDATE(), '23:59:59', 1, 1, 1, NULL),
('B', 2, GETDATE(), '23:59:59', 2, 2, 2, NULL),
('C', 3, GETDATE(), '23:59:59', 3, 3, 3, NULL),
('D', 4, GETDATE(), '23:59:59', 4, 4, 4, NULL),
('E', 5, GETDATE(), '23:59:59', 5, 5, 5, NULL)