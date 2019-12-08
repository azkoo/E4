CREATE TABLE [dbo].[Offer] (
    [Id]               BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]             VARCHAR (500)  NOT NULL,
    [Reference]        VARCHAR (500)  NULL,
    [Description]      VARCHAR (2000) NOT NULL,
    [Picture]          IMAGE          NULL,
    [PostNumber]       INT            NULL,
    [PublicationStart] DATETIME       NULL,
    [ContractStart]    DATETIME       NULL,
    [Period]           DATETIME       NULL,
    [Inspect]          BIT            NOT NULL,
    [IdProducer]       BIGINT         NOT NULL,
    [IdContractType]   BIGINT         NOT NULL,
    [IdJob]            BIGINT         NOT NULL,
    CONSTRAINT [PK_Offer] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Offer_ContractType] FOREIGN KEY ([IdContractType]) REFERENCES [dbo].[ContractType] ([Id]),
    CONSTRAINT [FK_Offer_Job] FOREIGN KEY ([IdJob]) REFERENCES [dbo].[Job] ([Id]),
    CONSTRAINT [FK_Offer_Producer] FOREIGN KEY ([IdProducer]) REFERENCES [dbo].[Producer] ([Id])
);





