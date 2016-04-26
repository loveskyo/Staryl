CREATE TABLE [dbo].[StarUser]
(
	Id int NOT NULL IDENTITY, 
	Gender int NOT Null, 
    [RealName] NVARCHAR(50) NOT NULL, 
    [Birthday] DATETIME NOT NULL, 
    [City] INT NOT NULL, 
    [Province] INT NOT NULL, 
    [Area] INT NOT NULL, 
    [Avatar] NVARCHAR(50) NOT NULL, 
    [Height] INT NULL, 
    [Weight] INT NULL, 
    [Hobby] NVARCHAR(1000) NULL, 
    [Greeting] NVARCHAR(500) NULL, 
    [CreateDate] DATETIME NOT NULL, 
    [CreateIP] NVARCHAR(50) NOT NULL, 
    [NickName] NVARCHAR(50) NULL, 
    [ParentId] INT NOT NULL, 
    [IsRecommend] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_StarUser_User] FOREIGN KEY ([ParentId]) REFERENCES [User]([Id]), 
    CONSTRAINT [PK_StarUser] PRIMARY KEY ([Id])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'性别 1男 2女',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'StarUser',
    @level2type = N'COLUMN',
    @level2name = N'Gender'


GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'真实性名',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'StarUser',
    @level2type = N'COLUMN',
    @level2name = N'RealName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'出生年月',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'StarUser',
    @level2type = N'COLUMN',
    @level2name = N'Birthday'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'省',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'StarUser',
    @level2type = N'COLUMN',
    @level2name = N'Province'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'市',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'StarUser',
    @level2type = N'COLUMN',
    @level2name = N'City'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'区县',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'StarUser',
    @level2type = N'COLUMN',
    @level2name = N'Area'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'头像',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'StarUser',
    @level2type = N'COLUMN',
    @level2name = N'Avatar'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'身高 cm',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'StarUser',
    @level2type = N'COLUMN',
    @level2name = N'Height'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'体重 kg',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'StarUser',
    @level2type = N'COLUMN',
    @level2name = N'Weight'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'兴趣爱好',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'StarUser',
    @level2type = N'COLUMN',
    @level2name = N'Hobby'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'个性签名',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'StarUser',
    @level2type = N'COLUMN',
    @level2name = N'Greeting'

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'昵称',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'StarUser',
    @level2type = N'COLUMN',
    @level2name = N'NickName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'父账号Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'StarUser',
    @level2type = N'COLUMN',
    @level2name = N'ParentId'
GO

CREATE INDEX [IX_StarUser_ParentId] ON [dbo].[StarUser] (ParentId)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'是否推荐',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'StarUser',
    @level2type = N'COLUMN',
    @level2name = N'IsRecommend'