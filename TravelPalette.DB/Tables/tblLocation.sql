CREATE TABLE [dbo].[tblLocation]
(
	[Id] INT NOT NULL PRIMARY KEY,
    [AddressId] VARCHAR(255) NOT NULL,
    [Description] VARCHAR(255) NOT NULL,
    [BusinessName] VARCHAR(255) NOT NULL,
    [Coordinates] VARCHAR(50) NOT NULL,
    [PhoneNumber] VARCHAR(15) NOT NULL
)
