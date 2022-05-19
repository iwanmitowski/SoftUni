CREATE DATABASE Hotel
USE Hotel

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Title NVARCHAR(30) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Employees VALUES
('A','A','A', NULL),
('A','A','A', NULL),
('A','A','A', NULL)

CREATE TABLE Customers 
(
	AccountNumber INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	PhoneNumber NCHAR(10) NOT NULL,
	EmergencyName NVARCHAR(30) NOT NULL,
	EmergencyNumber NCHAR(10) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Customers VALUES
('A', 'A', '0123456789', 'B', 'B', '0123456789'),
('A', 'A', '0123456789', 'B', 'B', '0123456789'),
('A', 'A', '0123456789', 'B', 'B', '0123456789')

CREATE TABLE RoomStatus
(
	RoomStatus NVARCHAR(10) PRIMARY KEY,
	Notes NVARCHAR(MAX)
)

INSERT INTO RoomStatus VALUES
('Taken', NULL),
('Reserved', NULL),
('Free', NULL)

CREATE TABLE RoomTypes
(
	RoomType NVARCHAR(10) PRIMARY KEY,
	Notes NVARCHAR(MAX)
)

INSERT INTO RoomTypes VALUES
('Apartment', NULL),
('Single', NULL),
('Double', NULL)


CREATE TABLE BedTypes
(
	BedType NVARCHAR(10) PRIMARY KEY,
	Notes NVARCHAR(MAX)
)

INSERT INTO BedTypes VALUES
('Single', NULL),
('Double', NULL),
('Tripple', NULL)


CREATE TABLE Rooms
(
	RoomNumber INT PRIMARY KEY IDENTITY,
	RoomType NVARCHAR(10) FOREIGN KEY  (RoomType) REFERENCES RoomTypes,
	BedType NVARCHAR(10) FOREIGN KEY  (BedType) REFERENCES BedTypes,
	Rate REAL,
	RoomTypes NVARCHAR(10) FOREIGN KEY  (RoomType) REFERENCES RoomTypes,
	Notes NVARCHAR(MAX)
)
INSERT INTO Rooms VALUES
('Single', 'Single', 4.20, 'Single', NULL),
('Single', 'Single', 420, 'Single', NULL),
('Single', 'Single', 440, 'Single', NULL)

CREATE TABLE Payments
(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY (Id) REFERENCES Employees,
	PaymentDate DATETIME2 NOT NULL,
	AccountNumber INT FOREIGN KEY (AccountNumber) REFERENCES Customers,
	FirstDateOccupied DATETIME2 NOT NULL,
	LastDateOccupied DATETIME2 NOT NULL,
	TotalDays AS DATEDIFF(DAY, LastDateOccupied, FirstDateOccupied),
	AmountCharged REAL NOT NULL,
	TaxRate REAL NOT NULL,
	TaxAmount REAL NOT NULL,
	PaymentTotal REAL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Payments VALUES
(1, GETDATE(), 1, GETDATE(), GETDATE(), 2.4, 2.4, 2.4, NULL, NULL),
(2, GETDATE(), 2, GETDATE(), GETDATE(), 2.4, 2.4, 2.4, NULL, NULL),
(3, GETDATE(), 3, GETDATE(), GETDATE(), 2.4, 2.4, 2.4, NULL, NULL)

CREATE TABLE Occupancies
(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY (Id) REFERENCES Employees,
	DateOccupied DATETIME2 NOT NULL,
	AccountNumber INT FOREIGN KEY (AccountNumber) REFERENCES Customers,
	RoomNumber INT FOREIGN KEY (RoomNumber) REFERENCES Rooms,
	RateApplied REAL,
	PhoneCharge REAL,
	Notes NVARCHAR(MAX)
)
INSERT INTO Occupancies VALUES
(1, GETDATE(), 1, 1, NULL, NULL, NULL),
(2, GETDATE(), 2, 2, NULL, NULL, NULL),
(3, GETDATE(), 3, 3, NULL, NULL, NULL)
