CREATE TABLE [dbo].[Producer] (
    [Id]             BIGINT        NOT NULL,
    [Name]           VARCHAR (500) NOT NULL,
    [Password]       VARCHAR (50)  NOT NULL,
    [Website]        VARCHAR (500) NULL,
    [Phone]          VARCHAR (500) NULL,
    [Fax]            VARCHAR (500) NOT NULL,
    [City]           VARCHAR (500) NULL,
    [Address1]       VARCHAR (500) NULL,
    [Address2]       VARCHAR (500) NOT NULL,
    [Email]          VARCHAR (500) NULL,
    [CastingCounter] INT           NOT NULL,
    [IdCastingPack]  BIGINT        NOT NULL,
    CONSTRAINT [PK_Producer] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Producer_CastingPack] FOREIGN KEY ([IdCastingPack]) REFERENCES [dbo].[CastingPack] ([Id])
);







