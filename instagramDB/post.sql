CREATE TABLE [dbo].[post]
(
	[postId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [userId] INT NOT NULL, 
    [photopath] NVARCHAR(MAX) NOT NULL, 
    [location] NVARCHAR(50) NULL, 
    [creation_date] DATETIME NULL, 
    CONSTRAINT [FK_post_To_user] FOREIGN KEY ([userId]) REFERENCES [user]([userId])
)
