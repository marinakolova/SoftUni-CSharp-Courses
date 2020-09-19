USE [Geography]

GO


  SELECT k.ContinentCode, k.CurrencyCode, k.CurrencyUsage
    FROM (
  SELECT c.ContinentCode,
         c.CurrencyCode,
         COUNT(c.CurrencyCode) AS [CurrencyUsage],
         DENSE_RANK() OVER(PARTITION BY c.ContinentCode ORDER BY COUNT(c.CurrencyCode) DESC) AS [Rank]
    FROM Countries AS c
    JOIN Currencies AS cc ON cc.CurrencyCode = c.CurrencyCode
GROUP BY c.ContinentCode, c.CurrencyCode
  HAVING COUNT(c.CurrencyCode) != 1) AS k
   WHERE k.[Rank] = 1
ORDER BY k.ContinentCode