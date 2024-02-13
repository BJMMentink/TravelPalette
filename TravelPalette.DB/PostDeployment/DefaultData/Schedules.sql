BEGIN
    INSERT INTO tblSchedule (Id, LocationId, MondayOpen, MondayClose, TuesdayOpen, TuesdayClose, WednesdayOpen, WednesdayClose, ThursdayOpen, ThursdayClose, FridayOpen, FridayClose, SaturdayOpen, SaturdayClose, SundayOpen, SundayClose)
    VALUES
    (1, 100, '08:00', '17:00', '08:00', '17:00', '08:00', '17:00', '08:00', '17:00', '08:00', '17:00', '08:00', '12:00', '08:00', '17:00', '08:00', '17:00'),
    (2, 200, '09:00', '18:00', '09:00', '18:00', '09:00', '18:00', '09:00', '18:00', '09:00', '18:00', '09:00', '18:00', '09:00', '18:00', '09:00', '18:00'),
    (3, 300, '07:30', '16:30', '07:30', '16:30', '07:30', '16:30', '07:30', '16:30', '07:30', '16:30', '07:30', '16:30', NULL, NULL, NULL, NULL);
END