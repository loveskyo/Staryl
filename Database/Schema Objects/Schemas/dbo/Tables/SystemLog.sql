CREATE TABLE [dbo].[SystemLog]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [MethodName] VARCHAR(50) NULL, 
    [MethodSignature] VARCHAR(50) NULL, 
    [TypeName] VARCHAR(50) NULL, 
    [CallContext] VARCHAR(2000) NULL, 
    [SystemName] VARCHAR(50) NOT NULL, 
    [UseTime] INT NOT NULL, 
    [Args] VARCHAR(1000) NULL, 
    [CreateDate] DATETIME NOT NULL, 
    [CreateIP] VARCHAR(50) NULL, 
    [ReturnValue] TEXT NULL, 
    [LogType] INT NOT NULL
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'方法名称',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SystemLog',
    @level2type = N'COLUMN',
    @level2name = N'MethodName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'方法签名',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SystemLog',
    @level2type = N'COLUMN',
    @level2name = N'MethodSignature'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'类型名称',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SystemLog',
    @level2type = N'COLUMN',
    @level2name = N'TypeName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'执行上下文',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SystemLog',
    @level2type = N'COLUMN',
    @level2name = N'CallContext'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'系统名称',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SystemLog',
    @level2type = N'COLUMN',
    @level2name = N'SystemName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'执行时长',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SystemLog',
    @level2type = N'COLUMN',
    @level2name = N'UseTime'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'参数',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SystemLog',
    @level2type = N'COLUMN',
    @level2name = N'Args'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'开始时间',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SystemLog',
    @level2type = N'COLUMN',
    @level2name = N'CreateDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'IP',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SystemLog',
    @level2type = N'COLUMN',
    @level2name = N'CreateIP'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'返回值',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SystemLog',
    @level2type = N'COLUMN',
    @level2name = N'ReturnValue'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'日志类型',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SystemLog',
    @level2type = N'COLUMN',
    @level2name = N'LogType'