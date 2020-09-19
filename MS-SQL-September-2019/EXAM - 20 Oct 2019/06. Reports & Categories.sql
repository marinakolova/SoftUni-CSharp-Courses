--Select all descriptions from reports, which have category. 
--Order them by description (ascending) then by category name (ascending).


  SELECT r.[Description], c.[Name] AS CategoryName
    FROM Reports AS r
    JOIN Categories AS c ON r.CategoryId = c.Id
ORDER BY r.[Description], CategoryName