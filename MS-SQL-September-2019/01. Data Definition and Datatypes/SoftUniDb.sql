CREATE DATABASE SoftUni

USE SoftUni

CREATE TABLE Towns (
	Id INT PRIMARY KEY IDENTITY, 
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Addresses (
	Id INT PRIMARY KEY IDENTITY, 
	AddressText NVARCHAR(200), 
	TownId INT FOREIGN KEY REFERENCES Towns(Id)
)

CREATE TABLE Departments (
	Id INT PRIMARY KEY IDENTITY, 
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Employees (
	Id INT PRIMARY KEY IDENTITY, 
	FirstName NVARCHAR(50) NOT NULL, 
	MiddleName NVARCHAR(50) NOT NULL, 
	LastName NVARCHAR(50) NOT NULL, 
	JobTitle NVARCHAR(50), 
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id), 
	HireDate NVARCHAR(50), 
	Salary DECIMAL(15, 2), 
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)

--TODO: BACKUP, DELETE AND RESTORE DATABASE

INSERT INTO Towns ([Name])
VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

INSERT INTO Departments ([Name])
VALUES
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance')

INSERT INTO Employees 
(FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary)
VALUES
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '01/02/2013', 3500.00),
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '02/03/2004', 4000.00),
('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '28/08/2016', 525.25),
('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '09/12/2007', 3000.00),
('Peter', 'Pan', 'Pan', 'Intern', 3, '28/08/2016', 599.88)


SELECT * FROM Towns

SELECT * FROM Departments

SELECT * FROM Employees


SELECT * FROM Towns
ORDER BY [Name]

SELECT * FROM Departments
ORDER BY [Name]

SELECT * FROM Employees
ORDER BY Salary DESC


SELECT [Name] FROM Towns
ORDER BY [Name]

SELECT [Name] FROM Departments
ORDER BY [Name]

SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY Salary DESC


UPDATE Employees
SET [Salary] = [Salary] + [Salary] * 0.10
SELECT [Salary] FROM Employees