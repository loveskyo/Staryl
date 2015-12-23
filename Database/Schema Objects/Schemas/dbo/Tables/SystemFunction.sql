CREATE TABLE [dbo].[SystemFunction]
(
    [Id]           INT          IDENTITY (1, 1) NOT NULL,
    [FunctionName] VARCHAR (50) NOT NULL,
    [FunctionCode] VARCHAR (50) NOT NULL,
    [IsBuiltin]    BIT          NOT NULL,
    CONSTRAINT [PK_SystemFunction] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'功能名称',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SystemFunction',
    @level2type = N'COLUMN',
    @level2name = N'FunctionName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'功能代码',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SystemFunction',
    @level2type = N'COLUMN',
    @level2name = N'FunctionCode'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'是否内置 内置不可删除',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SystemFunction',
    @level2type = N'COLUMN',
    @level2name = N'IsBuiltin'
GO

CREATE UNIQUE INDEX [IX_SystemFunction_FunctionCode] ON [dbo].[SystemFunction] ([FunctionCode])
