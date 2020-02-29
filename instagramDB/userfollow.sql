CREATE TABLE [dbo].[userfollow] (
    [userId1] INT NOT NULL,
    [userId2] INT NOT NULL,
    CONSTRAINT [FK_userfollow_To_user] FOREIGN KEY ([userId1]) REFERENCES [dbo].[user] ([userId]),
    CONSTRAINT [FK_userfollow_To_user_following] FOREIGN KEY ([userId2]) REFERENCES [dbo].[user] ([userId])
);

