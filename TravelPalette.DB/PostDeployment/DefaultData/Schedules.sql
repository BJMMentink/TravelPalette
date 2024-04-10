BEGIN
    INSERT INTO [dbo].[tblSchedule] (Id, LocationId, MondayOpen, MondayClose, TuesdayOpen, TuesdayClose, WednesdayOpen, WednesdayClose, ThursdayOpen, ThursdayClose, FridayOpen, FridayClose, SaturdayOpen, SaturdayClose, SundayOpen, SundayClose)
    VALUES (1, 1001, '18:00:00', '08:00:00', '18:00:00', '08:00:00', '18:00:00', '08:00:00', '18:00:00', '08:00:00', '18:00:00', '08:00:00', '10:00:00', '16:00:00', NULL, NULL),
           (4, 400, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
END


