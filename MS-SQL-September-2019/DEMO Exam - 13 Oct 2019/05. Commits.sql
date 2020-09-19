USE Bitbucket

GO


  SELECT Id, [Message], RepositoryId, ContributorId 
    FROM Commits AS c
ORDER BY c.Id, c.[Message], c.RepositoryId, c.ContributorId