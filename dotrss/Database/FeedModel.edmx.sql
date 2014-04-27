
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/27/2014 11:38:16
-- Generated from EDMX file: f:\dokumente\visual studio 2013\Projects\dotrss\dotrss\Database\FeedModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [dotrss];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_FeedFeedItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FeedItems] DROP CONSTRAINT [FK_FeedFeedItem];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Feeds]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Feeds];
GO
IF OBJECT_ID(N'[dbo].[FeedItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FeedItems];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Feeds'
CREATE TABLE [dbo].[Feeds] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Uri] nvarchar(max)  NOT NULL,
    [LastUpdated] datetime  NOT NULL,
    [FeedType] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'FeedItems'
CREATE TABLE [dbo].[FeedItems] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Body] nvarchar(max)  NOT NULL,
    [Uri] nvarchar(max)  NOT NULL,
    [UId] nvarchar(max)  NOT NULL,
    [PubDate] datetime  NOT NULL,
    [Feed_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Feeds'
ALTER TABLE [dbo].[Feeds]
ADD CONSTRAINT [PK_Feeds]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FeedItems'
ALTER TABLE [dbo].[FeedItems]
ADD CONSTRAINT [PK_FeedItems]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Feed_Id] in table 'FeedItems'
ALTER TABLE [dbo].[FeedItems]
ADD CONSTRAINT [FK_FeedFeedItem]
    FOREIGN KEY ([Feed_Id])
    REFERENCES [dbo].[Feeds]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FeedFeedItem'
CREATE INDEX [IX_FK_FeedFeedItem]
ON [dbo].[FeedItems]
    ([Feed_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------