CREATE TABLE [dbo].[ContractType] (
    [Id]   BIGINT        IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (500) NOT NULL,
    CONSTRAINT [PK_ContractType] PRIMARY KEY CLUSTERED ([Id] ASC)
);



