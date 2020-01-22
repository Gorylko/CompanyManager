CREATE TABLE [dbo].[Enterprises]
(
	[Id] INT IDENTITY (1,1) NOT NULL,
	[Name] NVARCHAR(30) NOT NULL,
	[Description] NVARCHAR(200) NULL,
   	[CreatedBy] INT NOT NULL,
	FOREIGN KEY ([CreatedBy]) REFERENCES [dbo].[Users]([Id]),

 	PRIMARY KEY CLUSTERED([Id] ASC)
);