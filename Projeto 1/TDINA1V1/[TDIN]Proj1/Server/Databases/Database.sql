CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Username] NCHAR(32) NOT NULL, 
    [Password] NCHAR(32) NOT NULL 
)
