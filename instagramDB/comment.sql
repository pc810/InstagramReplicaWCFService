CREATE TABLE [dbo].[comment]
(
	[commentId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [userId] INT NOT NULL, 
    [postId] INT NOT NULL, 
    [comment] NVARCHAR(MAX) NOT NULL, 
    [creation_date] DATETIME NULL, 
    CONSTRAINT [FK_comment_To_user] FOREIGN KEY ([userId]) REFERENCES [user]([userId]), 
    CONSTRAINT [FK_comment_To_post] FOREIGN KEY ([postId]) REFERENCES [post]([postId])
)
