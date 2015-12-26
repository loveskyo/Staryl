CREATE TABLE [dbo].[Album]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [AlbumName] NVARCHAR(50) NULL, 
    [UserId] INT NOT NULL, 
    [CreateDate] DATETIME NOT NULL, 
    [CreateIP] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_Album_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'相册名称',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Album',
    @level2type = N'COLUMN',
    @level2name = N'AlbumName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'会员Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Album',
    @level2type = N'COLUMN',
    @level2name = N'UserId'