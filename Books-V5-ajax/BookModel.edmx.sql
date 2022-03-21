
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/09/2022 18:08:03
-- Generated from EDMX file: C:\Users\mario\Downloads\Books-SQL\Books-SQL\Books-V5-ajaxASPAPI\Books-V5-ajax\BookModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BookDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Books]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Books];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Books'
CREATE TABLE [dbo].[Books] (
    [BookId] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Genre] nvarchar(max)  NOT NULL,
    [Year] int  NOT NULL,
    [Author] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [BookId] in table 'Books'
ALTER TABLE [dbo].[Books]
ADD CONSTRAINT [PK_Books]
    PRIMARY KEY CLUSTERED ([BookId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------