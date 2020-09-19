USE Bitbucket

GO


  SELECT TOP(5) 
         r.Id,
         r.[Name],
         COUNT(c.Id) AS [Commits]
    FROM Repositories AS r
    JOIN RepositoriesContributors AS rc 
	  ON r.Id = rc.RepositoryId
    JOIN Users AS u 
	  ON rc.ContributorId = u.Id
    JOIN Commits AS c 
	  ON r.Id = c.RepositoryId
GROUP BY r.Id, r.[Name]
ORDER BY [Commits] DESC, r.Id, r.[Name]