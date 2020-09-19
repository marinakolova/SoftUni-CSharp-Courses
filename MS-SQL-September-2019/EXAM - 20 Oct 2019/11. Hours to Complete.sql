--Create a user defined function with the name udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME) 
--that receives a start date and end date 
--and must returns the total hours which has been taken for this task. 
--If start date is null or end is null return 0.


CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS
BEGIN
	IF (@StartDate IS NULL OR @EndDate IS NULL)
	BEGIN
		RETURN 0
	END
	
	DECLARE @totalHours INT = DATEDIFF(hour, @StartDate, @EndDate)
	
	RETURN @totalHours
END