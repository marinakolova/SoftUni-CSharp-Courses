USE Airport

GO


  SELECT FlightId, SUM(Price) AS TotalPrice
    FROM Tickets
GROUP BY FlightId
ORDER BY TotalPrice DESC, FlightId