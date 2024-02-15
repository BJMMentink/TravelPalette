BEGIN
    INSERT INTO [dbo].[tblUserList] (Id, UserId, ListId, ListName)
    VALUES (1, 1, 1, 'Favorites'),
           (2, 1, 2, 'To-Do'),
           (3, 2, 3, 'Shopping List')
END

