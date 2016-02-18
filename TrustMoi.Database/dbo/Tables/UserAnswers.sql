CREATE TABLE [dbo].[UserAnswers]
(
	[Id]		INT IDENTITY(1, 1) NOT NULL,
	[UserId]	NVARCHAR (128) NOT NULL,
	[AnswerId]	INT NOT NULL,

	CONSTRAINT [PK_UserAnswers] PRIMARY KEY ([Id]),
	
	CONSTRAINT [FK_UserAnswers_AspNetUsers] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
	CONSTRAINT [FK_UserAnswers_Answers] FOREIGN KEY ([AnswerId]) REFERENCES [dbo].[Answers] ([Id]),

	CONSTRAINT [UK_UserAnswers] UNIQUE NONCLUSTERED ([UserId], [AnswerId])
)
