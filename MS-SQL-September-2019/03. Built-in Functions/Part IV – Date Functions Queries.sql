USE Orders

GO


SELECT 
       ProductName, 
       OrderDate, 
       DATEADD(DAY, 3, OrderDate) AS [Pay Due],
       DATEADD(MONTH, 1, OrderDate) AS [Deliver Due] 
  FROM Orders



CREATE TABLE People(
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[Name] VARCHAR(30) NOT NULL,
	[Birthdate] DATETIME NOT NULL,
)

INSERT INTO People([Name], [Birthdate])
     VALUES
            ('Victor', '2000-12-07 00:00:00.000'),
            ('Steven', '1992-09-10 00:00:00.000'),
            ('Stephen', '1910-09-19 00:00:00.000'),
            ('John', '2010-01-06 00:00:00.000')

SELECT * FROM People

SELECT
       [Name],
       DATEDIFF(year, [Birthdate], GETDATE()) AS [Age in Years],
       DATEDIFF(month, [Birthdate], GETDATE()) AS [Age in Months],
       DATEDIFF(day, [Birthdate], GETDATE()) AS [Age in Days],
       DATEDIFF(minute, [Birthdate], GETDATE()) AS [Age in Minutes]
  FROM People
