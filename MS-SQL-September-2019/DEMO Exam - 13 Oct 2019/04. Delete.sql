USE Bitbucket

GO


DELETE
  FROM RepositoriesContributors
 WHERE RepositoriesContributors.RepositoryId IN (SELECT r.Id
                                                   FROM Repositories AS r
                                                  WHERE r.[Name] = 'Softuni-Teamwork')
												  
DELETE
  FROM Issues
 WHERE Issues.RepositoryId IN (SELECT r.Id
                                 FROM Repositories AS r
                                WHERE r.[Name] = 'Softuni-Teamwork')
										  
