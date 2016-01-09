CREATE VIEW [dbo].[UserStarUserView]
		AS SELECT a.*,r.IsVIP FROM StarUser a inner join [User] r on a.ParentId=r.Id
