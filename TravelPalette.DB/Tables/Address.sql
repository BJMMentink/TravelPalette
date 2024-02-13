CREATE TABLE [dbo].[Address]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [StreetName] VARCHAR(255) NOT NULL,
    [City] VARCHAR(100) NOT NULL,
    [ZIP] VARCHAR(10) NOT NULL,
    [State] VARCHAR(2) NOT NULL
)
