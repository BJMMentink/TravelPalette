BEGIN
    INSERT INTO [dbo].[tblUser] (Id, Username, Password, Email, FirstName, LastName)
    VALUES
    (1, 'john_doe', 'password123', 'john.doe@example.com', 'John', 'Doe'),
    (2, 'jane_smith', 'letmein', 'jane.smith@example.com', 'Jane', 'Smith'),
    (3, 'bob_johnson', 'securepassword', 'bob.johnson@example.com', 'Bob', 'Johnson')
END