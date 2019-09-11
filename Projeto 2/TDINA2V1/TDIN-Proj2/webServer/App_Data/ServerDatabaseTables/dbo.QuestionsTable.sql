CREATE TABLE [dbo].[Questions]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Title] NVARCHAR(50) NOT NULL,
    [Description] NVARCHAR(1000) NOT NULL,
    [Answer] NVARCHAR(1000) NOT NULL,
    [IsAnswered] BIT NOT NULL DEFAULT 0,
    [Department_Id] INT NOT NULL DEFAULT -1,
    [Ticket_Id] INT NOT NULL DEFAULT -1,
    CONSTRAINT [FK_QuestionsToDepartment_Ticket] FOREIGN KEY ([Ticket_Id]) REFERENCES [dbo].[TroubleTickets]([Id])
)
