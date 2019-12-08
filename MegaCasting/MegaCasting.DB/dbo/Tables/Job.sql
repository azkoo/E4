CREATE TABLE [dbo].[Job] (
    [Id]        BIGINT        IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (500) NOT NULL,
    [IdJobType] BIGINT        NOT NULL,
    CONSTRAINT [PK_Job] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Job_JobType] FOREIGN KEY ([IdJobType]) REFERENCES [dbo].[JobType] ([Id])
);



