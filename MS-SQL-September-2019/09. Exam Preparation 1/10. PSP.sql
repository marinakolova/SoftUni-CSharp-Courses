USE Airport

GO


--Select all planes with their name, seats count and passengers count. Order the results by passengers count (descending), plane name (ascending) and seats (ascending)

   SELECT p.[Name], 
          p.Seats, 
          COUNT(t.Id) AS PassengersCount
     FROM Planes AS p
LEFT JOIN Flights AS f	ON f.PlaneId = p.Id
LEFT JOIN Tickets AS t	ON t.FlightId = f.Id
 GROUP BY p.[Name], p.Seats
 ORDER BY PassengersCount DESC, p.Name, p.Seats