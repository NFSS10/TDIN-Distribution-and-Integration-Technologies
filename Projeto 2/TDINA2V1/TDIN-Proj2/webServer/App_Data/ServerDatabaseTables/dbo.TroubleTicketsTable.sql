CREATE TABLE [dbo].[TroubleTickets]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Title] NVARCHAR(50) NOT NULL,
    [Description] NVARCHAR(1000) NOT NULL,
    [CreationDate] DATETIME NOT NULL,
    [State] INT NOT NULL DEFAULT 1,
    [Answer] NVARCHAR(1000) NOT NULL,
	[Worker_Id] INT NOT NULL DEFAULT -1,
    [Solver_Id] INT NOT NULL DEFAULT -1,
    CONSTRAINT [FK_TroubleTickets_ToSolver] FOREIGN KEY ([Solver_Id]) REFERENCES [dbo].[Solvers]([Id]),
	CONSTRAINT [FK_TroubleTickets_ToWorker] FOREIGN KEY ([Worker_Id]) REFERENCES [dbo].[Workers]([Id])
)
