
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/28/2017 13:46:21
-- Generated from EDMX file: C:\Users\jeroe\Source\Repos\DNET-herkansing\UrenregistratieApplicatie\UrenregistratieService\DBmodel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [UrenregistratieDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [UserId] int IDENTITY(1,1) NOT NULL,
    [Gebruikersnaam] nvarchar(max)  NOT NULL,
    [Wachtwoord] nvarchar(max)  NOT NULL,
    [ProjectProjectId] int  NOT NULL
);
GO

-- Creating table 'ProjectSet'
CREATE TABLE [dbo].[ProjectSet] (
    [ProjectId] int IDENTITY(1,1) NOT NULL,
    [Naam] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TaakSet'
CREATE TABLE [dbo].[TaakSet] (
    [TaakId] int IDENTITY(1,1) NOT NULL,
    [Type] nvarchar(max)  NOT NULL,
    [Uren] time  NOT NULL,
    [UserUserId] int  NOT NULL,
    [ProjectProjectId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [UserId] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [ProjectId] in table 'ProjectSet'
ALTER TABLE [dbo].[ProjectSet]
ADD CONSTRAINT [PK_ProjectSet]
    PRIMARY KEY CLUSTERED ([ProjectId] ASC);
GO

-- Creating primary key on [TaakId] in table 'TaakSet'
ALTER TABLE [dbo].[TaakSet]
ADD CONSTRAINT [PK_TaakSet]
    PRIMARY KEY CLUSTERED ([TaakId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ProjectProjectId] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [FK_ProjectUser]
    FOREIGN KEY ([ProjectProjectId])
    REFERENCES [dbo].[ProjectSet]
        ([ProjectId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectUser'
CREATE INDEX [IX_FK_ProjectUser]
ON [dbo].[UserSet]
    ([ProjectProjectId]);
GO

-- Creating foreign key on [UserUserId] in table 'TaakSet'
ALTER TABLE [dbo].[TaakSet]
ADD CONSTRAINT [FK_UserTaken]
    FOREIGN KEY ([UserUserId])
    REFERENCES [dbo].[UserSet]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserTaken'
CREATE INDEX [IX_FK_UserTaken]
ON [dbo].[TaakSet]
    ([UserUserId]);
GO

-- Creating foreign key on [ProjectProjectId] in table 'TaakSet'
ALTER TABLE [dbo].[TaakSet]
ADD CONSTRAINT [FK_ProjectTaak]
    FOREIGN KEY ([ProjectProjectId])
    REFERENCES [dbo].[ProjectSet]
        ([ProjectId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectTaak'
CREATE INDEX [IX_FK_ProjectTaak]
ON [dbo].[TaakSet]
    ([ProjectProjectId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------