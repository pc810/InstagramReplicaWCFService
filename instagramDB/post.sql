CREATE TABLE [dbo].[post] (
    [postId]        INT            IDENTITY (1, 1) NOT NULL,
    [userId]        INT            NOT NULL,
    [photopath]     NVARCHAR (MAX) NOT NULL,
    [location]      NVARCHAR (50)  NULL,
    [creation_date] DATETIME       NULL,
    [post_text] NVARCHAR(MAX) NULL, 
    [likes] INT NULL, 
    PRIMARY KEY CLUSTERED ([postId] ASC),
    CONSTRAINT [FK_post_To_user] FOREIGN KEY ([userId]) REFERENCES [dbo].[user] ([userId])
);

