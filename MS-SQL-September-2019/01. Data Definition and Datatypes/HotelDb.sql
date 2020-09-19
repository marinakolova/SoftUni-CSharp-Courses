CREATE DATABASE Hotel

USE Hotel

CREATE TABLE Employees (
	Id INT PRIMARY KEY IDENTITY, 
	FirstName NVARCHAR(30) NOT NULL, 
	LastName NVARCHAR(30) NOT NULL, 
	Title NVARCHAR(30), 
	Notes NVARCHAR(MAX)
)

CREATE TABLE Customers (
	AccountNumber INT PRIMARY KEY IDENTITY, 
	FirstName NVARCHAR(30) NOT NULL, 
	LastName NVARCHAR(30) NOT NULL, 
	PhoneNumber NVARCHAR(30), 
	EmergencyName NVARCHAR(30), 
	EmergencyNumber NVARCHAR(30), 
	Notes NVARCHAR(MAX)
)

CREATE TABLE RoomStatus (
	RoomStatus INT UNIQUE NOT NULL, 
	Notes NVARCHAR(MAX)
)

CREATE TABLE RoomTypes (
	RoomType INT UNIQUE NOT NULL, 
	Notes NVARCHAR(MAX)
)

CREATE TABLE BedTypes (
	BedType INT UNIQUE NOT NULL, 
	Notes NVARCHAR(MAX)
)

CREATE TABLE Rooms (
	RoomNumber INT UNIQUE NOT NULL, 
	RoomType INT FOREIGN KEY REFERENCES RoomTypes(RoomType), 
	BedType INT FOREIGN KEY REFERENCES BedTypes(BedType), 
	Rate INT, 
	RoomStatus INT FOREIGN KEY REFERENCES RoomStatus(RoomStatus), 
	Notes NVARCHAR(MAX)
)

CREATE TABLE Payments (
	Id INT PRIMARY KEY IDENTITY, 
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id), 
	PaymentDate DATETIME2, 
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber), 
	FirstDateOccupied DATETIME2, 
	LastDateOccupied DATETIME2, 
	TotalDays INT, 
	AmountCharged DECIMAL(15, 2), 
	TaxRate DECIMAL(15, 2), 
	TaxAmount DECIMAL(15, 2), 
	PaymentTotal DECIMAL(15, 2), 
	Notes NVARCHAR(MAX)
)

CREATE TABLE Occupancies (
	Id INT PRIMARY KEY IDENTITY, 
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id), 
	DateOccupied DATETIME2, 
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber), 
	RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber), 
	RateApplied INT, 
	PhoneCharge INT, 
	Notes NVARCHAR(MAX)
)

INSERT INTO Employees 
(FirstName, LastName, Title, Notes)
VALUES
('Ivan', 'Petrov', NULL, NULL),
('Pesho', 'Ivanov', NULL, NULL),
('Gosho', 'Mitov', NULL, NULL)

INSERT INTO Customers 
(FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
VALUES
('John', 'Smith', NULL, NULL, NULL, NULL),
('Bob', 'Miller', NULL, NULL, NULL, NULL),
('Tom', 'Hanks', NULL, NULL, NULL, NULL)

INSERT INTO RoomStatus 
(RoomStatus, Notes)
VALUES
(10, 'Available'),
(11, 'Occupied'),
(12, 'Needs Cleaning')

INSERT INTO RoomTypes 
(RoomType, Notes)
VALUES
(20, 'Normal'),
(21, 'Luxorious'),
(22, 'Secret')

INSERT INTO BedTypes 
(BedType, Notes)
VALUES
(30, 'OnePerson'),
(31, 'TwoPeople'),
(32, 'KingSize')

INSERT INTO Rooms 
(RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes)
VALUES
(123, 20, 31, NULL, 10, NULL),
(223, 21, 30, NULL, 12, NULL),
(323, 22, 32, NULL, 11, NULL)

INSERT INTO Payments 
(EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)
VALUES
(1, NULL, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(3, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(2, NULL, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)

INSERT INTO Occupancies 
(EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)
VALUES
(1, NULL, 2, 123, NULL, NULL, NULL),
(3, NULL, 1, 323, NULL, NULL, NULL),
(2, NULL, 3, 223, NULL, NULL, NULL)