CREATE FUNCTION udf_CalculateTickets(@origin varchar(50), @destination varchar(50), @peopleCount int)
RETURNS VARCHAR(100)
AS
BEGIN
	
	IF (@peopleCount <= 0)
	BEGIN
		RETURN 'Invalid people count!'
	END
	
	DECLARE @tripId INT = (SELECT f.Id 
	                         FROM Flights AS f
	                         JOIN Tickets AS t	ON t.FlightId = f.Id 
	                        WHERE Destination = @destination AND Origin = @origin)
	
	IF (@tripId IS NULL)
	BEGIN
		RETURN 'Invalid flight!'
	END
	
	DECLARE @ticketPrice DECIMAL(15,2) = (SELECT t.Price FROM Flights AS f
	                                        JOIN Tickets AS t	ON t.FlightId = f.Id 
	                                       WHERE Destination = @destination AND Origin = @origin)
	
	DECLARE @totalPrice DECIMAL(15, 2) = @ticketPrice * @peoplecount
	
	RETURN 'Total price ' + CAST(@totalPrice as VARCHAR(30))

END