CREATE TABLE [dbo].[Others]
(
	[OtherId] INT NOT NULL PRIMARY KEY, 
    [Other] NCHAR(10) NULL, 
    [Token] NCHAR(10) NULL, 
    [OthersToWords] INT NULL, 
    CONSTRAINT [FK_Others_Words] FOREIGN KEY ([OthersToWords]) REFERENCES [Words]([WordId])
)
