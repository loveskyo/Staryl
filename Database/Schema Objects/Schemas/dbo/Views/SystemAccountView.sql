CREATE VIEW [dbo].[SystemAccountView]
	AS SELECT a.*,r.RoleName FROM SystemAccount a inner join SystemRole r on a.RoleId=r.Id
