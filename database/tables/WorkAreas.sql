CREATE TABLE [dbo].[WorkAreas]
(
	[Id] INT IDENTITY(1,1) NOT NULL,
	[EnterpriseId] INT NOT NULL,
	[Name] NVARCHAR(100) NOT NULL,
	[Location]NVARCHAR(100) NULL,
	[Cost] DECIMAL(10, 3) NULL,
	[RentRrice] DECIMAL(10, 3) NULL,

	FOREIGN KEY ([EnterpriseId]) REFERENCES [dbo].[Enterprises]([Id]),
	PRIMARY KEY CLUSTERED([Id]ASC)
);