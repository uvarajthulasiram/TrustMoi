﻿CREATE TABLE [dbo].[Person]
(
	[Id] INT NOT NULL IDENTITY (1, 1),
	[UserId] NVARCHAR(128) NOT NULL,
	[DateOfBirth] DATETIME NOT NULL,
	[Gender] VARCHAR(10) NOT NULL,
	[AddressLine1] VARCHAR(250) NOT NULL,
	[AddressLine2] VARCHAR(250) NULL,
	[City] VARCHAR(100) NOT NULL

	CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_Person_AspNetUsers] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers]([Id]),
	CONSTRAINT [UK_Person_UserId] UNIQUE ([UserId])
)