# GameSync
![ReadMeHamePage](https://user-images.githubusercontent.com/84350426/152440397-37ffdf4a-4e2b-48c5-ba8f-29f4fcab2ba8.PNG)

GameSync is a full stack application that allows users to add, share, and cross refference their favorite games with thier friend's games. 


# Install Instructions

  - Clone this repo to the location of your choice
  - cd GameSync
  - run start GameSync.sln
  - cd client
  - run npm install
  - in the same directory run npm start
  - in Visual Studio create a New Query
  - copy and run the Create Tables SQL script in the new query
  - navigate to the database it creates and add it to a new query 
  - copy the Seed Data SQL file and run the sript in the new database
  - start the program in Visual studio

# SQL

USE [GameSync]
GO


DROP TABLE IF EXISTS [UserFriend];
DROP TABLE IF EXISTS [UserProfile];
DROP TABLE IF EXISTS [UserGame];
DROP TABLE IF EXISTS [Game];
DROP TABLE IF EXISTS [Comment];
DROP TABLE IF EXISTS [Genre];
GO

CREATE TABLE [UserProfile] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [UserName] nvarchar(255),
  [Name] nvarchar(255),
  [Email] nvarchar(255),
  [CreateDateTime] datetime,
  [FirebaseUserId] nvarchar(255)

  CONSTRAINT UQ_FirebaseUserId UNIQUE(FirebaseUserId)
)
GO

CREATE TABLE [UserFriend] (
  [Id] int PRIMARY KEY IDENTITY(1,1),
  [UserProfile_id] int NOT NULL,
  [Friend_id] int NOT NULL

  CONSTRAINT [FK_UserFriend_UserProfile_FriendId] FOREIGN KEY ([Friend_id]) REFERENCES [UserProfile] ([Id]),
  CONSTRAINT [FK_UserFriend_UserProfile_UserProfileId] FOREIGN KEY ([UserProfile_Id]) REFERENCES [UserProfile] ([Id])
)
GO

CREATE TABLE [Genre] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Genre] nvarchar(255)
)
GO

CREATE TABLE [Game] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Title] nvarchar(255),
  [NumPlayers] nvarchar(255),
  [ImageLocation] nvarchar(255),
  [Genre_id] int

  CONSTRAINT [FK_Game_Genre] FOREIGN KEY ([Genre_id]) REFERENCES [Genre] ([Id])
)
GO
CREATE TABLE [UserGame] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [UserProfile_id] int NOT NULL,
  [Game_id] int NOT NULL

  CONSTRAINT [FK_UserGame_Game] FOREIGN KEY ([Game_id]) REFERENCES [Game] ([Id]),
  CONSTRAINT [FK_UserGame_UserProfile] FOREIGN KEY ([UserProfile_Id]) REFERENCES [UserProfile] ([Id])
)
GO
CREATE TABLE [Comment] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [UserGame_id] int NOT NULL,
  [UserProfile_id] int NOT NULL,
  [Content] text NOT NULL

  CONSTRAINT [FK_Comment_Game] FOREIGN KEY ([UserGame_id]) REFERENCES [UserGame] ([Id]),
  CONSTRAINT [FK_Comment_UserProfile] FOREIGN KEY ([UserProfile_Id]) REFERENCES [UserProfile] ([Id])
)
GO


# ERD
![ERD for backend Capstone](https://user-images.githubusercontent.com/84350426/149177103-fa731056-d83b-4c34-9a0d-31676089589f.png)

# WireFrame

![Wire Frame Backend Capstone](https://user-images.githubusercontent.com/84350426/149177550-7f64e48b-9b25-481d-9bf7-a6d75f5e70cd.PNG)

# MVP For this Project
A user interface where users have full CRUD functionality over their own games from their own library as well as adding and removing friend from their friends list. 
# Streach goals
Filtering through games they have in common with their friends.



# Tech Stack

  - C#
  - .NET
  - React 
  - Bootstrap
  - SQL
  - Firebase
