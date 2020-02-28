CREATE TABLE [dbo].[userfollow]
(
	[userid1] INT NOT NULL, 
    [userid2] INT NOT NULL, 
    CONSTRAINT [FK_userfollow_To_user] FOREIGN KEY ([userid1]) REFERENCES [user]([userid]), 
    CONSTRAINT [FK_userfollow_To_user_following] FOREIGN KEY ([userid2]) REFERENCES [user]([userid])
)
