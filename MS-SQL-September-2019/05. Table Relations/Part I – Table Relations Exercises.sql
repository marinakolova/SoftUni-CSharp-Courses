CREATE DATABASE TableRelationsExercise

GO

USE TableRelationsExercise

GO


CREATE TABLE Passports(
	PassportID INT NOT NULL PRIMARY KEY IDENTITY(101, 1),
	PassportNumber NVARCHAR(50) NOT NULL
)

CREATE TABLE Persons(
	PersonID INT PRIMARY KEY IDENTITY(1, 1),
	FirstName NVARCHAR(50) NOT NULL,
	Salary DECIMAL(18, 2),
	PassportID INT FOREIGN KEY REFERENCES Passports(PassportID)
)

INSERT INTO Passports(PassportNumber)
VALUES
	('N34FG21B'),
	('K65LO4R7'),
	('ZE657QP2')

INSERT INTO Persons(FirstName, Salary, PassportID)
VALUES
	('Roberto', 43300.00, 102),
	('Tom', 56100.00, 103),
	('Yana', 60200.00, 101)




CREATE TABLE Manufacturers(
	ManufacturerID INT PRIMARY KEY IDENTITY(1, 1),
	[Name] NVARCHAR(50) NOT NULL,
	EstablishedOn DATE
)

CREATE TABLE Models(
	ModelID INT PRIMARY KEY IDENTITY(101, 1),
	[Name] NVARCHAR(50) NOT NULL,
	ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID) NOT NULL
)

INSERT INTO Manufacturers([Name], EstablishedOn)
VALUES
	('BMW', '07/03/1916'),
	('Tesla', '01/01/2003'),
	('Lada', '01/05/1966')

INSERT INTO Models([Name], ManufacturerID)
VALUES
	('X1', 1),
	('i6', 1),
	('Model S', 2),
	('Model X', 2),
	('Model 3', 2),
	('Nova', 3)




CREATE TABLE Students(
	StudentID INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE Exams(
	ExamID INT PRIMARY KEY NOT NULL,
	[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE StudentsExams(
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID) NOT NULL,
	ExamID INT FOREIGN KEY REFERENCES Exams(ExamID) NOT NULL,
	CONSTRAINT PK_StudentsExams PRIMARY KEY (StudentID, ExamID)
)

INSERT INTO Students([Name]) 
VALUES
	('Mila'),
	('Toni'),
	('Ron')

INSERT INTO Exams([ExamID], [Name]) 
VALUES
	(101, 'SpringMVC'),
	(102, 'Neo4j'),
	(103, 'Oracle 11g')

INSERT INTO StudentsExams([StudentID], [ExamID]) 
VALUES
	(1, 101),
	(1, 102),
	(2, 101),
	(3, 103),
	(2, 102),
	(2, 103)




CREATE TABLE Teachers(
	TeacherID INT PRIMARY KEY IDENTITY(101, 1) NOT NULL,
	[Name] VARCHAR(30) NOT NULL,
	ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers([Name], ManagerID) 
VALUES
	('John', NULL),
	('Maya', 106),
	('Silvia', 106),
	('Ted', 105),
	('Mark', 101),
	('Greta', 101)