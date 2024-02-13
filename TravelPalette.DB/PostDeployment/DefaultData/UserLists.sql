BEGIN
    INSERT INTO tblUserList (Id, UserId, ListId, ListName)
    VALUES
    (1, 1, 1001, 'Favorites'),
    (2, 1, 1002, 'To-Do'),
    (3, 2, 1003, 'Shopping List');
END