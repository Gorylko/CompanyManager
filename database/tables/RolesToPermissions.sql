CREATE TABLE [dbo].[RolesToPermissions]
(
	[Id] INT IDENTITY(1, 1) NOT NULL,
	[RoleId] INT NOT NULL,
	[PermissionId] INT NOT NULL,

	FOREIGN KEY([RoleId]) REFERENCES [dbo].[Roles]([Id]),
	FOREIGN KEY([PermissionId]) REFERENCES [dbo].[Permissions]([Id]),

	PRIMARY KEY CLUSTERED([Id]ASC)
);