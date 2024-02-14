BEGIN
    INSERT INTO [dbo].[tblLocation] (Id, AddressId, Description, BusinessName, Coordinates, PhoneNumber)
        VALUES 
        (100, 1, 'Downtown', 'Central Coffee', '40.7128° N, 74.0060° W', '+1 (212) 555-1234'),
        (200, 2, 'Beachfront', 'Sunset Grill', '34.0522° N, 118.2437° W', '+1 (310) 555-5678'),
        (300, 3, 'Suburban', 'Green Gardens', '41.8781° N, 87.6298° W', '+1 (312) 555-9876');

END