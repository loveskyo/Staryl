CREATE TABLE [dbo].[SystemPrivileges]
(
    [Id]            INT             IDENTITY (1, 1) NOT NULL,
    [RoleId]        INT             NOT NULL,
    [MenuId]        INT             NOT NULL,
    [FunctionCodes] NVARCHAR (2000) NOT NULL,
    CONSTRAINT [PK_SystemPrivileges] PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_SystemPrivileges_SystemRole] FOREIGN KEY (RoleId) REFERENCES [SystemRole]([Id])
);
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'角色Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SystemPrivileges',
    @level2type = N'COLUMN',
    @level2name = N'RoleId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'栏目Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SystemPrivileges',
    @level2type = N'COLUMN',
    @level2name = N'MenuId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'具有功能',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SystemPrivileges',
    @level2type = N'COLUMN',
    @level2name = N'FunctionCodes'