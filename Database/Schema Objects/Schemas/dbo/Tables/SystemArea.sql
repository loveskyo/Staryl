CREATE TABLE [dbo].[SystemArea]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Display] NVARCHAR(50) NOT NULL, 
    [ParentId] INT NOT NULL
)

GO

CREATE INDEX [IX_SystemArea_ParentId] ON [dbo].[SystemArea] (ParentId)
