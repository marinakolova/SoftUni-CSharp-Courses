USE [Geography]

GO


   SELECT TOP(5) k.CountryName,
          ISNULL(k.PeakName, '(no highest peak)'),
          ISNULL(k.[Highest Peak Elevation], 0),
          ISNULL(k.MountainRange, '(no mountain)')
     FROM (
   SELECT c.CountryName,
          p.PeakName,
          MAX(p.Elevation) AS [Highest Peak Elevation],
          m.MountainRange,
          DENSE_RANK() OVER(PARTITION BY c.CountryName ORDER BY MAX(p.Elevation) DESC) AS [Rank]
     FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
LEFT JOIN Peaks AS p ON mc.MountainId = p.MountainId
 GROUP BY c.CountryName, p.PeakName, m.MountainRange) AS k
    WHERE k.[Rank] = 1
 ORDER BY k.CountryName, k.PeakName