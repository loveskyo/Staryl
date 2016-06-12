CREATE TABLE [dbo].[Ticket]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [TicketNo] NVARCHAR(100) NOT NULL, 
    [UserId] INT NOT NULL, 
    [StarDate] DATETIME NOT NULL, 
    [EndDate] DATETIME NOT NULL, 
    [CreateDate] DATETIME NOT NULL, 
    [CreateIP] NVARCHAR(50) NOT NULL, 
    [Creator] INT NOT NULL, 
    [TicketValue] INT NOT NULL, 
    [TicketType] INT NOT NULL, 
    [Status] INT NOT NULL
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'券号',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Ticket',
    @level2type = N'COLUMN',
    @level2name = N'TicketNo'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'所属用户Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Ticket',
    @level2type = N'COLUMN',
    @level2name = N'UserId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'券开始时间（以0点为准，例：开始时间为23号，则23号可用）',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Ticket',
    @level2type = N'COLUMN',
    @level2name = N'StarDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'券结束时间(到午夜12点为准，例：结束日期为24号，则24号当天可用)',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Ticket',
    @level2type = N'COLUMN',
    @level2name = N'EndDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'券创建者',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Ticket',
    @level2type = N'COLUMN',
    @level2name = N'Creator'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'券价值',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Ticket',
    @level2type = N'COLUMN',
    @level2name = N'TicketValue'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'券类型（现金券，一次券）',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Ticket',
    @level2type = N'COLUMN',
    @level2name = N'TicketType'
GO

CREATE UNIQUE INDEX [IX_Ticket_TicketNo] ON [dbo].[Ticket] ([TicketNo])

GO

CREATE INDEX [IX_Ticket_UserId] ON [dbo].[Ticket] ([UserId])

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'状态，1未使用，2已使用，0已过期，-1无效',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Ticket',
    @level2type = N'COLUMN',
    @level2name = N'Status'