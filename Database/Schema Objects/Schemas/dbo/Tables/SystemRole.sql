CREATE TABLE [dbo].[SystemRole](
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [RoleName]    VARCHAR (50) NOT NULL,
    [IsCanDelete] BIT           NOT NULL DEFAULT 1,
    [CreateIP]    VARCHAR (20) NOT NULL,
    [CreateDate]  DATETIME     NOT NULL,
    CONSTRAINT [PK_SystemRole] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'角色名称',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SystemRole',
    @level2type = N'COLUMN',
    @level2name = N'RoleName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'是否可以删除',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SystemRole',
    @level2type = N'COLUMN',
    @level2name = N'IsCanDelete'