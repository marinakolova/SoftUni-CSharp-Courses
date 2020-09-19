USE Bitbucket

GO


UPDATE Issues
   SET IssueStatus = 'closed'
 WHERE AssigneeId = 6