CREATE TABLE [dbo].[Activity]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NVARCHAR(200) NOT NULL, 
	[BriefIntroduction] NVARCHAR(500) NULL,
    [Content] NVARCHAR(MAX) NOT NULL, 
    [TypeId] INT NOT NULL, 
    [ChargeLevel] INT NOT NULL,
	[OrderBy] INT NOT NULL, 
	[Status] INT NOT NULL,
	[IsActive] bit Not NULL,
	[CreateDate] DATETIME NOT NULL, 
    [CreateIP] NVARCHAR(50) NOT NULL
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'会员活动',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Activity',
    @level2type = N'COLUMN',
    @level2name = N'Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'活动主题',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Activity',
    @level2type = N'COLUMN',
    @level2name = N'Title'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'活动内容',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Activity',
    @level2type = N'COLUMN',
    @level2name = N'Content'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'简介',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Activity',
    @level2type = N'COLUMN',
    @level2name = N'BriefIntroduction'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'活动类型',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Activity',
    @level2type = N'COLUMN',
    @level2name = N'TypeId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'收费级别（免费，会员免费..）',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Activity',
    @level2type = N'COLUMN',
    @level2name = N'ChargeLevel'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'排序',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Activity',
    @level2type = N'COLUMN',
    @level2name = N'OrderBy'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'创建时间',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Activity',
    @level2type = N'COLUMN',
    @level2name = N'CreateDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'创建IP',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Activity',
    @level2type = N'COLUMN',
    @level2name = N'CreateIP'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'会员活动',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Activity',
    @level2type = NULL,
    @level2name = NULL
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'是否发布',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Activity',
    @level2type = N'COLUMN',
    @level2name = N'IsActive'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'活动状态',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Activity',
    @level2type = N'COLUMN',
    @level2name = N'Status'