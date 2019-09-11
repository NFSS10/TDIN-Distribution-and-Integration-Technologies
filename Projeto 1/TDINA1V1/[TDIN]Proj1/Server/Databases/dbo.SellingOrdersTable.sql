CREATE TABLE [dbo].[SellingOrders] (
    [Id]              INT IDENTITY (1, 1) NOT NULL,
    [UserID]          INT NOT NULL,
    [NumberDiginotes] INT NOT NULL,
    [Suspended]       BIT DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SellingOrders_ToUser] FOREIGN KEY ([UserID]) REFERENCES [dbo].[User] ([Id])
);

