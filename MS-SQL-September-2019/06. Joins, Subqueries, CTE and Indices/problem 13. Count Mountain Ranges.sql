USE [Geography]

GO


  SELECT CountryCode, COUNT(MountainId) AS MountainRange
    FROM MountainsCountries
GROUP BY CountryCode
  HAVING CountryCode IN ('US', 'RU', 'BG')