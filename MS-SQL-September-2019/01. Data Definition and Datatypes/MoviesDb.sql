CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors(
	Id INT PRIMARY KEY IDENTITY,
	DirectorName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Genres(
	Id INT PRIMARY KEY IDENTITY,
	GenreName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Movies(
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(100) NOT NULL,
	DirectorId INT,
	CopyrightYear INT NOT NULL,
	[Length] INT,
	GenreId INT,
	CategoryId INT,
	Rating INT,
	Notes NVARCHAR(MAX)
)

INSERT INTO Directors (DirectorName, Notes)
VALUES
('Steven Spielberg', NULL),
('Quentin Tarantino', NULL),
('John Steinbeck', NULL),
('Ivan Petrov', NULL),
('George Lucas', NULL)

INSERT INTO Genres (GenreName, Notes)
VALUES
('Comedy', NULL),
('Drama', NULL),
('Action', NULL),
('Romance', NULL),
('Horror', NULL)

INSERT INTO Categories (CategoryName, Notes)
VALUES
('AdultsOnly', NULL),
('Series', NULL),
('Children', NULL),
('Foreign', NULL),
('Bulgarian', NULL)

ALTER TABLE Movies
ADD CONSTRAINT FK_DirectorId
FOREIGN KEY (DirectorId) REFERENCES Directors(Id)

ALTER TABLE Movies
ADD CONSTRAINT FK_GenreId
FOREIGN KEY (GenreId) REFERENCES Genres(Id)

ALTER TABLE Movies
ADD CONSTRAINT FK_CategoryId
FOREIGN KEY (CategoryId) REFERENCES Categories(Id)

INSERT INTO Movies 
(Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating, Notes)
VALUES
('From Dusk Till Down', 1, 1999, NULL, 2, 3, NULL, NULL),
('Indiana Jones', 4, 2001, NULL, 5, 1, NULL, NULL),
('Batman', 2, 1985, NULL, 3, 4, NULL, NULL),
('American Pie', 5, 2008, NULL, 1, 2, NULL, NULL),
('True Blood', 3, 2011, NULL, 4, 5, NULL, NULL)