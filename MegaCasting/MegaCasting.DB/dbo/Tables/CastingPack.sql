CREATE TABLE [dbo].[CastingPack] (
    [Id]   BIGINT        IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (500) NOT NULL,
    [Size] INT           NULL,
    CONSTRAINT [PK_CastingPack] PRIMARY KEY CLUSTERED ([Id] ASC)
);



