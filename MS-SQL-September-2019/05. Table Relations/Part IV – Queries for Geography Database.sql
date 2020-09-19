USE Geography

GO


SELECT *
  FROM (
         SELECT MountainRange, p.PeakName, p.Elevation
           FROM Mountains AS m
           JOIN Peaks AS p 
                  ON p.MountainId = m.Id
       ) AS g
   WHERE MountainRange = 'Rila'
ORDER BY g.Elevation DESC
