USE SoftUni

GO


  SELECT TOP(1) AVG(e.Salary) AS MinAverageSalary
    FROM Employees AS e
GROUP BY e.DepartmentID
ORDER BY MinAverageSalary