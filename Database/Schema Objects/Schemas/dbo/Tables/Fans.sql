CREATE TABLE [dbo].[Fans]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [StarId] INT NOT NULL, 
    [FansId] INT NOT NULL, 
    [CreateDate] DATETIME NOT NULL, 
    [CreateIP] NVARCHAR(50) NOT NULL
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'被关注者Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Fans',
    @level2type = N'COLUMN',
    @level2name = N'StarId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'关注者Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Fans',
    @level2type = N'COLUMN',
    @level2name = N'FansId'
GO

CREATE INDEX [IX_Fans_StarId] ON [dbo].[Fans] (StarId)

GO

CREATE INDEX [IX_Fans_FansId] ON [dbo].[Fans] (FansId)

GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_Fans_StarId_FansId] ON [dbo].[Fans] ([FansId], [StarId])
