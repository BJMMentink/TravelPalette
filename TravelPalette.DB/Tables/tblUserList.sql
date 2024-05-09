CREATE TABLE [dbo].[tblUserList]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [UserId] INT NOT NULL,
    [ListId] INT,
    [ListName] VARCHAR(255) NOT NULL
)
