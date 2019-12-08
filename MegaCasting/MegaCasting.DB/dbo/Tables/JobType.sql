CREATE TABLE [dbo].[JobType] (
    [Id]   BIGINT        IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (500) NOT NULL,
    CONSTRAINT [PK_JobType] PRIMARY KEY CLUSTERED ([Id] ASC)
);



