CREATE TABLE [dbo].[Undergo]
(
	[Id] INT NOT NULL  IDENTITY,
	StarUserId int not null, 
    [Photos] NVARCHAR(500) NULL, 
    [Content] NVARCHAR(1000) NULL, 
    [CreateDate] DATETIME NOT NULL, 
    [CreateIP] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_Undergo_StarUser] FOREIGN KEY ([StarUserId]) REFERENCES [StarUser]([Id]), 
    CONSTRAINT [PK_Undergo] PRIMARY KEY ([Id]),
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'童星Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Undergo',
    @level2type = N'COLUMN',
    @level2name = N'StarUserId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'照片 最多9张',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Undergo',
    @level2type = N'COLUMN',
    @level2name = N'Photos'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'说明',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Undergo',
    @level2type = N'COLUMN',
    @level2name = N'Content'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'创建时间',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Undergo',
    @level2type = N'COLUMN',
    @level2name = N'CreateDate'
GO

CREATE INDEX [IX_Undergo_StarUserId] ON [dbo].[Undergo] ([StarUserId])
