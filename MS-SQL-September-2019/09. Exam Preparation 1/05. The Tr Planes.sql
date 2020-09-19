USE Airport

GO


  SELECT Id, [Name], Seats, [Range] 
    FROM Planes
   WHERE [Name] LIKE '%tr%'
ORDER BY Id, [Name], Seats, [Range]