BEGIN
INSERT INTO [dbo].[tblAddress] (Id, StreetName, City, ZIP, State)
VALUES (1, '123 Main St', 'New York', '10001', 'NY'),
       (2, '456 Elm St', 'Los Angeles', '90001', 'CA'),
       (3, '789 Oak St', 'Chicago', '60601', 'IL');
END