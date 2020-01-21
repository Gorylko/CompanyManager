CREATE TABLE [dbo].[Employees]
(
	[Id] INT IDENTITY (1,1) NOT NULL,
	[EnterpriseId] INT NOT NULL,
	[FirstName] NVARCHAR(100) NOT NULL,
   	[LastName] NVARCHAR(100) NOT NULL,
	[Position] NVARCHAR(100) NOT NULL,
	[Salary] DECIMAL(10, 3) NOT NULL,

	FOREIGN KEY ([EnterpriseId]) REFERENCES [dbo].[Enterprises]([Id]),
 	PRIMARY KEY CLUSTERED([Id] ASC)
);