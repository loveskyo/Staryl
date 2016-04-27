CREATE TABLE [dbo].[PraiserRecord]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [StarId] INT NOT NULL, 
    [PraiserId] INT NULL, 
    [CreateDate] DATETIME NOT NULL, 
    [CreateIP] NVARCHAR(50) NOT NULL
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'被点赞者',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PraiserRecord',
    @level2type = N'COLUMN',
    @level2name = N'StarId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'点赞者(可能是游客)',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PraiserRecord',
    @level2type = N'COLUMN',
    @level2name = N'PraiserId'
GO


CREATE INDEX [IX_PraiserRecord_StarId_PraiserId_CreateDate] ON [dbo].[PraiserRecord] ([StarId], [PraiserId], [CreateDate] DESC)
