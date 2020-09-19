USE SoftUni

GO


  SELECT TOP(50) e.EmployeeID,
         e.FirstName + ' ' + e.LastName AS EmployeeName,
		 m.FirstName + ' ' + m.LastName AS ManagerName,
		 d.[Name] AS DepartmentName
    FROM Employees AS e
    JOIN Employees AS m ON e.ManagerID = m.EmployeeID
    JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID