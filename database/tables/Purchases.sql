CREATE TABLE [dbo].[Purchases]
(
	[Id] INT IDENTITY(1,1) NOT NULL,
	[EnterpriseId] INT NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	[Cost] DECIMAL(10, 3) NULL,
	[RentPrice] DECIMAL(10, 3) NULL,
	[Income] DECIMAL(10, 3) NULL,

	FOREIGN KEY ([EnterpriseId]) REFERENCES [dbo].[Enterprises]([Id]),
	PRIMARY KEY CLUSTERED([Id]ASC)
);