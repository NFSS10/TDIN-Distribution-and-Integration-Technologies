CREATE TABLE [dbo].[Quota] (
    [Id]    INT   NOT NULL,
    [Value] MONEY DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

