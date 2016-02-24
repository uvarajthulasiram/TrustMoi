﻿CREATE TABLE [dbo].[UserPerson]
(
	[UserId] NVARCHAR(128) NOT NULL,
	[DateOfBirth] DATETIME NOT NULL,
	[Gender] VARCHAR(10) NOT NULL,
	[AddressLine1] VARCHAR(250) NOT NULL,
	[AddressLine2] VARCHAR(250) NULL,
	[City] VARCHAR(100) NOT NULL,
	[IsBlocked] BIT NOT NULL DEFAULT 0,

	CONSTRAINT [PK_UserPerson] PRIMARY KEY CLUSTERED ([UserId]),
	CONSTRAINT [FK_UserPerson_AspNetUsers] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers]([Id])
)
