--Select all info for reports along with 
--employee first name and last name (concataned with space), department name, category name, report description, open date, status label and name of the user. 

--Order them by first name (descending), last name (descending), department (ascending), 
--category (ascending), description (ascending), open date (ascending), status (ascending) and user (ascending).

--Date should be in format - dd.MM.yyyy

--If there are empty records, replace them with 'None'.

--Employee	Department	Category	Description	OpenDate	Status	User

   SELECT ISNULL(e.FirstName + ' ' + e.LastName, 'None') AS Employee,
          ISNULL(d.[Name], 'None') AS Department,
          ISNULL(c.[Name], 'None') AS Category,
          ISNULL(r.[Description], 'None') AS [Description],
          ISNULL(FORMAT( r.OpenDate, 'dd.MM.yyyy', 'en-US' ), 'None') AS OpenDate,
          ISNULL(s.Label, 'None') AS [Status],
          ISNULL(u.[Name], 'None') AS [User]
     FROM Reports AS r
LEFT JOIN Employees AS e ON r.EmployeeId = e.Id
LEFT JOIN Departments AS d ON e.DepartmentId = d.Id
LEFT JOIN Categories AS c ON r.CategoryId = c.Id
LEFT JOIN [Status] AS s ON r.StatusId = s.Id
LEFT JOIN Users AS u ON r.UserId = u.Id
 ORDER BY e.FirstName DESC, e.LastName DESC, Department, Category, r.[Description], FORMAT( r.OpenDate, 'yyyy-MM-dd', 'en-US' ), [Status], [User]