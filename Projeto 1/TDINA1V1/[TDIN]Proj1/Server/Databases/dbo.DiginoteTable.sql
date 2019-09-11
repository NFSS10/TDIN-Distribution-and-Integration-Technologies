CREATE TABLE [dbo].[Diginote] (
    [Id]        INT NOT NULL IDENTITY,
    [OwnerUser] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Diginote_ToUser] FOREIGN KEY ([OwnerUser]) REFERENCES [dbo].[User] ([Id])
);

