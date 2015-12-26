CREATE TABLE [dbo].[SystemMenu]
(
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [MenuName]  VARCHAR (50)   NOT NULL,
    [MenuAddr]  VARCHAR (50)   NOT NULL,
    [ParentId]  INT            NOT NULL,
    [IsLeft]    BIT            NOT NULL,
    [IsTop]     BIT            NOT NULL,
    [Functions] VARCHAR (1000) NOT NULL,
    [IsMenu]    BIT            NOT NULL,
    [MenuLevel] INT            NOT NULL,
    CONSTRAINT [PK_SystemMenu] PRIMARY KEY CLUSTERED ([Id] ASC)
);



GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'栏目名称',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SystemMenu',
    @level2type = N'COLUMN',
    @level2name = N'MenuName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'栏目地址',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SystemMenu',
    @level2type = N'COLUMN',
    @level2name = N'MenuAddr'
GO

CREATE UNIQUE INDEX [IX_SystemMenu_MenuAddr] ON [dbo].[SystemMenu] ([MenuAddr])

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'父级栏目Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SystemMenu',
    @level2type = N'COLUMN',
    @level2name = N'ParentId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'是否左侧',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SystemMenu',
    @level2type = N'COLUMN',
    @level2name = N'IsLeft'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'是否顶部',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SystemMenu',
    @level2type = N'COLUMN',
    @level2name = N'IsTop'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'栏目具有的功能',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SystemMenu',
    @level2type = N'COLUMN',
    @level2name = N'Functions'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'是否显示',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SystemMenu',
    @level2type = N'COLUMN',
    @level2name = N'IsMenu'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'栏目等级',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SystemMenu',
    @level2type = N'COLUMN',
    @level2name = N'MenuLevel'