USE Diablo

GO


  SELECT TOP(50) 
         [Name], 
         FORMAT([Start], 'yyyy-MM-dd') AS [Start]
    FROM Games
   WHERE DATEPART(Year, [Start]) BETWEEN 2011 AND 2012
ORDER BY [Start], [Name]


  SELECT 
         Username, 
         SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email)) AS [Email Provider]
    FROM Users
ORDER BY [Email Provider], Username


  SELECT Username, IpAddress
    FROM Users
   WHERE IpAddress LIKE '___.1_%._%.___'
ORDER BY Username


  SELECT 
         [Name], 
        CASE
	     WHEN DATEPART(HOUR, [Start]) >= 0 AND  DATEPART(HOUR, [Start]) < 12 THEN 'Morning'
             WHEN DATEPART(HOUR, [Start]) >= 12 AND  DATEPART(HOUR, [Start]) < 18 THEN 'Afternoon'
             ELSE 'Evening'
         END AS [Part of the Day],
        CASE
             WHEN Duration <= 3 THEN 'Extra Short'
             WHEN Duration >= 4 AND Duration <= 6 THEN 'Short'
             WHEN Duration > 6 THEN 'Long'
             ELSE 'Extra Long'
         END AS [DurationName]
    FROM Games
ORDER BY [Name], [DurationName], [Part of the Day]
