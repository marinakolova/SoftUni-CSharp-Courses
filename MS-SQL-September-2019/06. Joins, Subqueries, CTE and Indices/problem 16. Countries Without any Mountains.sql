USE [Geography]

GO


   SELECT COUNT(*) AS [CountryCode]
     FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
    WHERE mc.MountainId IS NULL