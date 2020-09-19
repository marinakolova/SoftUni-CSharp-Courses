--Select the user's username and category name in all reports in which users have submitted a report on their birthday. 
--Order them by username (ascending) and then by category name (ascending).


  SELECT u.Username, c.[Name] AS CategoryName
    FROM Reports AS r
    JOIN Users AS u ON r.UserId = u.Id
    JOIN Categories AS c ON r.CategoryId = c.Id
   WHERE DAY(r.OpenDate) = DAY(u.Birthdate)
ORDER BY u.Username, CategoryName