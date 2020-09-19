USE Minions

GO

CREATE TABLE People(
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[Name] VARCHAR(30) NOT NULL,
	[Picture] IMAGE,
	[Height] DECIMAL(10, 2),
	[Weight] DECIMAL(10, 2),
	[Gender] VARCHAR(1) NOT NULL CHECK([Gender] = 'f' OR [Gender] = 'm'),
	[Birthdate] DATE NOT NULL,
	[Biography] VARCHAR(MAX)
)

INSERT INTO People([Name], [Picture], [Height], [Weight], [Gender], [Birthdate], [Biography])
VALUES
('Pesho', NULL, NULL, NULL, 'm', '1992/09/21', NULL),
('Gosho', NULL, NULL, NULL, 'm', '1991/07/15', NULL),
('Ivan', NULL, NULL, NULL, 'm', '1988/03/08', NULL),
('Maria', NULL, NULL, NULL, 'f', '1997/06/03', NULL),
('Georgi', NULL, NULL, NULL, 'm', '2001/12/24', NULL)