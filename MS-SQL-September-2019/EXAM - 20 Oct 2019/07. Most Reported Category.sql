--Select the top 5 most reported categories 
--and order them by the number of reports per category in descending order and then alphabetically by name.


  SELECT TOP(5) c.[Name],
         COUNT(r.Id) AS ReportsNumber
    FROM Categories AS c
    JOIN Reports AS r ON c.Id = r.CategoryId
GROUP BY c.[Name]
ORDER BY ReportsNumber DESC, c.[Name]