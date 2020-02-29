CREATE TABLE [dbo].[user] (
    [userId]        INT           IDENTITY (1, 1) NOT NULL,
    [username]      NVARCHAR (50) NOT NULL,
    [email]         NVARCHAR (50) NOT NULL,
    [dob]           DATETIME      NOT NULL,
    [creation_date] DATETIME      NOT NULL,
    [password]      NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([userId] ASC)
);

