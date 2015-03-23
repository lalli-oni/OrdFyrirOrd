CREATE TABLE [dbo].[Words] (
    [WordId] INT           IDENTITY (1, 1) NOT NULL,
    [Word]   NVARCHAR (50) NOT NULL,
    [Token]  NCHAR (10)    NULL,
    PRIMARY KEY CLUSTERED ([WordId] ASC)
);

