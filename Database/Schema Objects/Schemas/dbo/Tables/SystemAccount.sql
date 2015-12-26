CREATE TABLE [dbo].[SystemAccount]
(
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [Account]     VARCHAR (50)    NOT NULL,
    [Password]    VARCHAR (50)    NOT NULL,
    [UserName]    VARCHAR (50)    NULL,
    [NickName]    VARCHAR (50)    NULL,
    [RoleId]      INT             NOT NULL,
    [Department]  INT             NOT NULL,
    [IsEnable]    BIT             NOT NULL,
    [IsCanDelete] BIT              NOT NULL DEFAULT 1,
    [CreateIP]    VARCHAR (20)    NOT NULL,
    [CreateDate]  DATETIME        NOT NULL,
    [Remarks]     NVARCHAR (2000) NULL,
    CONSTRAINT [PK_BS_Account] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'登录账号',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SystemAccount',
    @level2type = N'COLUMN',
    @level2name = N'Account'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'登录密码',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SystemAccount',
    @level2type = N'COLUMN',
    @level2name = N'Password'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'用户姓名',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SystemAccount',
    @level2type = N'COLUMN',
    @level2name = N'UserName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'用户昵称',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SystemAccount',
    @level2type = N'COLUMN',
    @level2name = N'NickName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'角色Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SystemAccount',
    @level2type = N'COLUMN',
    @level2name = N'RoleId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'部门',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SystemAccount',
    @level2type = N'COLUMN',
    @level2name = N'Department'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'是否可用',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SystemAccount',
    @level2type = N'COLUMN',
    @level2name = N'IsEnable'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'是否可以删除',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SystemAccount',
    @level2type = N'COLUMN',
    @level2name = N'IsCanDelete'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'备注说明',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SystemAccount',
    @level2type = N'COLUMN',
    @level2name = N'Remarks'