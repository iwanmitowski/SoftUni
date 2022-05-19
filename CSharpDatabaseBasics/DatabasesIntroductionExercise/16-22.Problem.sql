CREATE DATABASE SUNI
USE SUNI

CREATE TABLE Towns
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(30) NOT NULL
)

CREATE TABLE Addresses
(
	Id INT PRIMARY KEY IDENTITY,
	AddressText NVARCHAR(30) NOT NULL,
	TownId INT FOREIGN KEY (Id) REFERENCES Towns
)

CREATE TABLE Departments
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(30) NOT NULL
)

CREATE TABLE Employees
(
    Id INT PRIMARY KEY IDENTITY,
    FirstName VARCHAR(30) NOT NULL,
    MiddleName VARCHAR(30) NOT NULL,
    LastName VARCHAR(30) NOT NULL,
    JobTitle VARCHAR(30) NOT NULL,
    DepartmentId INT FOREIGN KEY REFERENCES Departments(Id),
    HireDate DATE NOT NULL,
    Salary DECIMAL(15,2) NOT NULL,
    AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)

DROP DATABASE SoftUni

INSERT INTO Towns VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

INSERT INTO Departments VALUES
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance')


INSERT INTO Employees VALUES
('Ivan','Ivanov','Ivanov','.NET Developer',4,'02/01/2013',3500.00,NULL),
('Petar','Petrov','Petrov','Senior Engineer',1,'03/02/2004',4000.00,NULL),
('Maria','Petrova','Ivanova','Intern',5,'08/28/2016',525.25,NULL),
('Georgi','Terziev','Ivanov','CEO',2,'12/09/2007',3000.00,NULL),
('Peter','Pan','Pan','Intern',3,'08/28/2016',599.88,NULL)

SELECT *
  FROM Towns

SELECT *
  FROM Departments

SELECT *
  FROM Employees
 ORDER BY Name

SELECT *
  FROM Towns
 ORDER BY Name

SELECT *
  FROM Departments
 ORDER BY Name

SELECT *
  FROM Employees
ORDER BY Salary	DESC

SELECT Name
  FROM Towns

SELECT Name
  FROM Departments

SELECT FirstName, LastName, JobTitle, Salary
  FROM Employees

UPDATE Employees
   SET Salary *= 1.1