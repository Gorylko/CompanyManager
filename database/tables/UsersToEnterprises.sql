CREATE TABLE [dbo].[UsersToEnterprises]
(
	[Id] INT IDENTITY(1, 1) NOT NULL,
	[UserId] INT NOT NULL,
	[EnterpriseId] INT NOT NULL,
	[RoleId] INT NULL,

	FOREIGN KEY([UserId]) REFERENCES [dbo].[Users]([Id]),
	FOREIGN KEY([EnterpriseId]) REFERENCES [dbo].[Enterprises]([Id]),
	FOREIGN KEY([RoleId]) REFERENCES [dbo].[Roles]([Id]),

	PRIMARY KEY CLUSTERED([Id]ASC)
);