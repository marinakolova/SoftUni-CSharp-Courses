CREATE DATABASE CarRental

USE CarRental

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(50) NOT NULL,
	DailyRate INT,
	WeeklyRate INT,
	MonthlyRate INT,
	WeekendRate INT
)

CREATE TABLE Cars(
	Id INT PRIMARY KEY IDENTITY,
	PlateNumber NVARCHAR(10) NOT NULL,
	Manufacturer NVARCHAR(30) NOT NULL,
	Model NVARCHAR(30) NOT NULL,
	CarYear INT NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	Doors INT,
	Picture VARBINARY(MAX),
	Condition NVARCHAR(50),
	Available BIT
)

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Title NVARCHAR(50),
	Notes NVARCHAR(MAX)
)

CREATE TABLE Customers (
	Id INT PRIMARY KEY IDENTITY, 
	DriverLicenceNumber INT NOT NULL, 
	FullName NVARCHAR(50) NOT NULL, 
	[Address] NVARCHAR(100), 
	City NVARCHAR(50), 
	ZIPCode INT, 
	Notes NVARCHAR(MAX)
)

CREATE TABLE RentalOrders (
	Id INT PRIMARY KEY IDENTITY, 
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id), 
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id), 
	CarId INT FOREIGN KEY REFERENCES Cars(Id), 
	TankLevel INT, 
	KilometrageStart INT, 
	KilometrageEnd INT, 
	TotalKilometrage INT, 
	StartDate DATETIME2, 
	EndDate DATETIME2, 
	TotalDays INT, 
	RateApplied INT, 
	TaxRate INT, 
	OrderStatus NVARCHAR(20), 
	Notes NVARCHAR(MAX)
)

INSERT INTO Categories 
(CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
VALUES
('Cheap', NULL, NULL, NULL, NULL),
('Medium', NULL, NULL, NULL, NULL),
('Extra', NULL, NULL, NULL, NULL)

INSERT INTO Cars 
(PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
VALUES
('CB1234BK', 'Audi', 'A4', 2005, 3, 4, NULL, NULL, 1),
('CB5678CA', 'Renault', 'Clio', 2002, 2, 2, NULL, NULL, 0),
('CB9012MK', 'Peugeot', '306', 1997, 1, 4, NULL, NULL, 0)

INSERT INTO Employees 
(FirstName, LastName, Title, Notes)
VALUES
('Ivan', 'Petrov', NULL, NULL),
('Pesho', 'Ivanov', NULL, NULL),
('Maria', 'Georgieva', NULL, NULL)


INSERT INTO Customers 
(DriverLicenceNumber, FullName, [Address], City, ZIPCode, Notes)
VALUES
('45698525', 'Pesho Petrov', NULL, NULL, NULL, NULL),
('52698454', 'Georgi Marinov', NULL, NULL, NULL, NULL),
('75632492', 'Lora Kirova', NULL, NULL, NULL, NULL)


INSERT INTO RentalOrders 
(EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
VALUES
(1, 2, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(2, 3, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(3, 1, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)