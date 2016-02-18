CREATE TABLE [dbo].[Answers]
(
	[Id]			INT IDENTITY (1, 1) NOT NULL, 
    [QuestionId]	INT NOT NULL, 
    [Answer]		VARCHAR(1000) NOT NULL, 
    [Value]			INT NOT NULL,

	CONSTRAINT [PK_Answers] PRIMARY KEY CLUSTERED ([Id]),

	CONSTRAINT [FK_Answers_Questions] FOREIGN KEY ([QuestionId]) REFERENCES [dbo].[Questions] ([Id]),

	CONSTRAINT [UK_Answers] UNIQUE NONCLUSTERED ([QuestionId], [Answer])
)
