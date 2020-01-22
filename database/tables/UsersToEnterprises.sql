CREATE TABLE [dbo].[UsersToEnterprises]
(
	[Id] INT IDENTITY(1, 1) NOT NULL,
	[UserId] INT NOT NULL,
	[EnterpriseId] INT NOT NULL,

	FOREIGN KEY([UserId]) REFERENCES [dbo].[Users]([Id]),
	FOREIGN KEY([EnterpriseId]) REFERENCES [dbo].[Enterprises]([Id]),

	PRIMARY KEY CLUSTERED([Id]ASC)
);