USE SoftUni

GO



  SELECT 
         DepartmentID, 
         SUM(Salary) AS [TotalSalary]
    FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID



  SELECT 
         DepartmentID, 
         MIN(Salary) AS [MinimumSalary]
    FROM Employees
   WHERE DepartmentID IN(2, 5, 7) AND HireDate > '01/01/2000'
GROUP BY DepartmentID



SELECT * INTO NewEmployeesTable
  FROM Employees
 WHERE Salary > 30000

DELETE FROM NewEmployeesTable
 WHERE ManagerID = 42

UPDATE NewEmployeesTable
   SET Salary += 5000
 WHERE DepartmentID = 1

  SELECT 
         DepartmentID, 
         AVG(Salary) AS AverageSalary
    FROM NewEmployeesTable
GROUP BY DepartmentID



  SELECT 
         DepartmentID, 
         MAX(Salary) AS MaxSalary
    FROM Employees
GROUP BY DepartmentID
  HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000


  
SELECT COUNT(*) AS [Count]
  FROM Employees
 WHERE ManagerID IS NULL



SELECT 
       [RankedTable].DepartmentID, 
       [RankedTable].Salary AS [ThirdHighestSalary]
  FROM (
             SELECT 
                    DepartmentID, 
                    Salary, 
                    DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS [Rank]
               FROM Employees
           GROUP BY DepartmentID, Salary
        ) AS [RankedTable]
 WHERE [Rank] = 3



SELECT TOP(10) 
       FirstName, 
       LastName, 
       DepartmentID
  FROM Employees AS e
WHERE Salary > (SELECT AVG(Salary) 
                  FROM Employees AS em 
                 WHERE em.DepartmentID = e.DepartmentID)
ORDER BY DepartmentID
