CREATE TABLE [dbo].[comment] (
    [commentId]     INT            IDENTITY (1, 1) NOT NULL,
    [userId]        INT            NOT NULL,
    [postId]        INT            NOT NULL,
    [comment]       NVARCHAR (MAX) NOT NULL,
    [creation_date] DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([commentId] ASC),
    CONSTRAINT [FK_comment_To_user] FOREIGN KEY ([userId]) REFERENCES [dbo].[user] ([userId]) ON DELETE CASCADE,
    CONSTRAINT [FK_comment_To_post] FOREIGN KEY ([postId]) REFERENCES [dbo].[post] ([postId]) ON DELETE CASCADE
);

