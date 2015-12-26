CREATE TABLE [dbo].[User]
(
	Id int NOT NULL IDENTITY, 
	[Email] NVARCHAR(50) NOT NULL,
	Gender int NOT Null, 
    [Mobile] NVARCHAR(20) NOT NULL, 
    [UserType] INT NOT NULL, 
    [RecommendUser] NVARCHAR(50) NULL, 
    [RealName] NVARCHAR(50) NULL, 
    [Birthday] DATETIME NOT NULL, 
    [Avatar] NVARCHAR(50) NULL, 
    [CreateDate] DATETIME NOT NULL, 
    [CreateIP] NVARCHAR(50) NOT NULL, 
    [IsVIP] BIT NOT NULL DEFAULT 0, 
    [Password] NVARCHAR(50) NOT NULL, 
    [Status] INT NOT NULL DEFAULT 1, 
    [IsLogin] BIT NOT NULL DEFAULT 0
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'性别',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'User',
    @level2type = N'COLUMN',
    @level2name = N'Gender'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'用户名',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'User',
    @level2type = N'COLUMN',
    @level2name = 'Email'
GO

CREATE UNIQUE INDEX [IX_User_Email] ON [dbo].[User] ([Email])

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'手机号码',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'User',
    @level2type = N'COLUMN',
    @level2name = N'Mobile'
GO

CREATE UNIQUE INDEX [IX_User_Mobile] ON [dbo].[User] ([Mobile])

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'用户类型 1.个人用户 2.机构用户',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'User',
    @level2type = N'COLUMN',
    @level2name = N'UserType'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'推荐者',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'User',
    @level2type = N'COLUMN',
    @level2name = 'RecommendUser'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'真实性名',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'User',
    @level2type = N'COLUMN',
    @level2name = N'RealName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'出生年月',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'User',
    @level2type = N'COLUMN',
    @level2name = N'Birthday'
GO

GO

GO

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'头像',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'User',
    @level2type = N'COLUMN',
    @level2name = N'Avatar'
GO

GO

GO

GO

GO

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'是否VIP',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'User',
    @level2type = N'COLUMN',
    @level2name = N'IsVIP'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'密码',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'User',
    @level2type = N'COLUMN',
    @level2name = N'Password'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'账号状态 UserStatusEnum',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'User',
    @level2type = N'COLUMN',
    @level2name = N'Status'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'是否登录状态',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'User',
    @level2type = N'COLUMN',
    @level2name = N'IsLogin'