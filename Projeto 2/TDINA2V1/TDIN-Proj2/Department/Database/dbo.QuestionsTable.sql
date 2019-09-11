CREATE TABLE [dbo].[Questions]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NVARCHAR(50) NULL, 
    [Question] NVARCHAR(1000) NULL, 
    [ServerQuestion_Id] INT NULL, 
    [Ticket_Id] INT NULL
)
