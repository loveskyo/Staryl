CREATE TABLE [dbo].[Photo]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PhotoImage] NVARCHAR(50) NOT NULL, 
    [AlbumId] INT NOT NULL, 
    [UserId] INT NOT NULL, 
    [CreateDate] DATETIME NOT NULL, 
    [CreateIP] NVARCHAR(50) NOT NULL, 
    [IsDefault] BIT NOT NULL,
	
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'是否默认图',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Photo',
    @level2type = N'COLUMN',
    @level2name = N'IsDefault'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'图片地址 不含路径',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Photo',
    @level2type = N'COLUMN',
    @level2name = N'PhotoImage'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'相册Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Photo',
    @level2type = N'COLUMN',
    @level2name = N'AlbumId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'用户Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Photo',
    @level2type = N'COLUMN',
    @level2name = N'UserId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'创建时间',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Photo',
    @level2type = N'COLUMN',
    @level2name = N'CreateDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'创建IP',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Photo',
    @level2type = N'COLUMN',
    @level2name = N'CreateIP'