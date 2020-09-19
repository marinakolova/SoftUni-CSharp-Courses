--Select all employees and show how many unique users each of them has served to.
--Order by users count  (descending) and then by full name (ascending).

--FullName	UsersCount


    SELECT e.FirstName + ' ' + e.LastName AS FullName,
           ISNULL(k.UsersCount, 0) AS UsersCount
      FROM
   (SELECT r.EmployeeId,
           COUNT(r.UserId) AS UsersCount
      FROM Reports AS r
  GROUP BY r.EmployeeId
    HAVING r.EmployeeId IS NOT NULL) AS k
RIGHT JOIN Employees AS e ON k.EmployeeId = e.Id
  ORDER BY k.UsersCount DESC, FullName