USE Gringotts

GO



SELECT COUNT(*) AS [Count]
  FROM WizzardDeposits



SELECT MAX(MagicWandSize) AS LongestMagicWand
  FROM WizzardDeposits



  SELECT 
         DepositGroup, 
         MAX(MagicWandSize)
    FROM WizzardDeposits
GROUP BY DepositGroup



  SELECT TOP(2) 
         DepositGroup
    FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)



  SELECT 
         DepositGroup, 
         SUM(DepositAmount)
    FROM WizzardDeposits
GROUP BY DepositGroup



  SELECT 
         DepositGroup, 
         SUM(DepositAmount) AS [TotalSum]
    FROM WizzardDeposits
   WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup



  SELECT 
         DepositGroup, 
         SUM(DepositAmount) AS [TotalSum]
    FROM WizzardDeposits
   WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
  HAVING SUM(DepositAmount) < 150000
ORDER BY [TotalSum] DESC



  SELECT 
         DepositGroup, 
         MagicWandCreator, 
         MIN(DepositCharge) AS [MinDepositCharge]
    FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup



SELECT 
       [Ages].AgeGroup, 
       COUNT(Ages.AgeGroup) AS [WizardCount]
FROM (
       SELECT 
              CASE
                   WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
                   WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
                   WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
                   WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
                   WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
                   WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
                   ELSE '[61+]'
               END AS [AgeGroup]
          FROM WizzardDeposits
      ) AS [Ages]
GROUP BY Ages.AgeGroup



  SELECT LEFT(FirstName, 1) AS FirstLetter
    FROM WizzardDeposits
   WHERE DepositGroup =  'Troll Chest'
GROUP BY LEFT(FirstName, 1)
ORDER BY FirstLetter



  SELECT 
         DepositGroup, 
         IsDepositExpired, 
         AVG(DepositInterest) AS AverageInterest
    FROM WizzardDeposits
   WHERE DepositStartDate > '01/01/1985'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired



SELECT SUM(k.Diff) AS SumDifference
  FROM (
         SELECT wd.DepositAmount - (SELECT w.DepositAmount 
                                      FROM WizzardDeposits 
                                        AS w 
                                     WHERE w.Id = wd.Id + 1) AS Diff
           FROM WizzardDeposits AS wd
       ) AS k
