CREATE TABLE [dbo].[Schedule]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [LocationId] INT NOT NULL, 
    [MondayOpen] TIME NULL,
    [MondayClose] TIME NULL,
    [TuesdayOpen] TIME NULL,
    [TuesdayClose] TIME NULL,
    [WednesdayOpen] TIME NULL,
    [WednesdayClose] TIME NULL,
    [ThursdayOpen] TIME NULL,
    [ThursdayClose] TIME NULL,
    [FridayOpen] TIME NULL,
    [FridayClose] TIME NULL,
    [SaturdayOpen] TIME NULL,
    [SaturdayClose] TIME NULL,
    [SundayOpen] TIME NULL,
    [SundayClose] TIME NULL
);