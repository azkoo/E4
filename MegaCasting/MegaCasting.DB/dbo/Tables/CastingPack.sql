CREATE TABLE [dbo].[CastingPack] (
    [Id]   BIGINT        NOT NULL,
    [Name] VARCHAR (500) NOT NULL,
    [Size] INT           NULL,
    CONSTRAINT [PK_CastingPack] PRIMARY KEY CLUSTERED ([Id] ASC)
);

