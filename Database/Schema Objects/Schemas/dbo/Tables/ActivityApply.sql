CREATE TABLE [dbo].[ActivityApply]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ActivityId] INT NOT NULL, 
    [UserId] INT NOT NULL, 
	[StarId] INT NOT NULL,
	[Status] INT NOT NULL,
	[CreateDate] DATETIME NOT NULL, 
    [CreateIP] NVARCHAR(50) NOT NULL
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'活动报名表',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ActivityApply',
    @level2type = NULL,
    @level2name = NULL
GO

CREATE UNIQUE INDEX [IX_ActivityApply_ActivityId_StarId] ON [dbo].[ActivityApply] ([ActivityId], [StarId])

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'活动Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ActivityApply',
    @level2type = N'COLUMN',
    @level2name = N'ActivityId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'会员Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ActivityApply',
    @level2type = N'COLUMN',
    @level2name = N'UserId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'小朋友Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ActivityApply',
    @level2type = N'COLUMN',
    @level2name = N'StarId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'报名时间',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ActivityApply',
    @level2type = N'COLUMN',
    @level2name = N'CreateDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'状态（正常，取消，未参加，已参加）',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ActivityApply',
    @level2type = N'COLUMN',
    @level2name = N'Status'