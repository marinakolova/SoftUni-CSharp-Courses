--Create a stored procedure with the name usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT) 
--that receives an employee's Id and a report's Id 
--and assigns the employee to the report only if the department of the employee and the department of the report's category are the same. 
--Otherwise throw an exception with message: "Employee doesn't belong to the appropriate department!".


CREATE PROCEDURE usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
BEGIN
	
	DECLARE @employeeDepartmentId INT = (SELECT e.DepartmentId
	                                       FROM Employees AS e
							              WHERE e.Id = @EmployeeId)

	DECLARE @reportCategoryId INT = (SELECT r.CategoryId
	                                   FROM Reports AS r
							          WHERE r.Id = @ReportId)

	DECLARE @reportDepartmentId INT = (SELECT c.DepartmentId
	                                   FROM Categories AS c
							          WHERE c.Id = @reportCategoryId)


	IF (@employeeDepartmentId != @reportDepartmentId)
	BEGIN
		RAISERROR('Employee doesn''t belong to the appropriate department!', 16, 1)
		RETURN
	END

	UPDATE Reports
	SET EmployeeId = @EmployeeId
	WHERE Id = @ReportId
	
END