CREATE TABLE [dbo].[Questions]
(
	[Id] INT IDENTITY(1, 1) NOT NULL, 
	[Category] VARCHAR(50) NOT NULL, 
    [Type] VARCHAR(50) NOT NULL, 
    [Question] VARCHAR(1000) NOT NULL,

	CONSTRAINT [PK_Questions] PRIMARY KEY CLUSTERED ([Id]),
	
	CONSTRAINT [UK_Questions] UNIQUE NONCLUSTERED ([Category], [Type], [Question]) 
)
