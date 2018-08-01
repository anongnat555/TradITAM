
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/12/2018 17:15:28
-- Generated from EDMX file: C:\Users\patipon_wiangnak\Desktop\Tradition Asia\InternProject\TDInventory\TradITAM\TradITAM\tradasset_db.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TradAsset];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_asset_history_id_FK]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[asset_history] DROP CONSTRAINT [FK_asset_history_id_FK];
GO
IF OBJECT_ID(N'[dbo].[FK_asset_history_type_FK]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[asset_history] DROP CONSTRAINT [FK_asset_history_type_FK];
GO
IF OBJECT_ID(N'[dbo].[FK_asset_id_FK]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[asset_history] DROP CONSTRAINT [FK_asset_id_FK];
GO
IF OBJECT_ID(N'[dbo].[FK_asset_type_id_FK]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[asset] DROP CONSTRAINT [FK_asset_type_id_FK];
GO
IF OBJECT_ID(N'[dbo].[FK_historye_user_id_FK]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[history] DROP CONSTRAINT [FK_historye_user_id_FK];
GO
IF OBJECT_ID(N'[dbo].[FK_original_supplier_id_FK]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[asset] DROP CONSTRAINT [FK_original_supplier_id_FK];
GO
IF OBJECT_ID(N'[dbo].[FK_os_id_FK]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[asset] DROP CONSTRAINT [FK_os_id_FK];
GO
IF OBJECT_ID(N'[dbo].[FK_supplier_id_FK]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[asset] DROP CONSTRAINT [FK_supplier_id_FK];
GO
IF OBJECT_ID(N'[dbo].[FK_using_by_staff_id_FK]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[asset] DROP CONSTRAINT [FK_using_by_staff_id_FK];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[asset]', 'U') IS NOT NULL
    DROP TABLE [dbo].[asset];
GO
IF OBJECT_ID(N'[dbo].[asset_history]', 'U') IS NOT NULL
    DROP TABLE [dbo].[asset_history];
GO
IF OBJECT_ID(N'[dbo].[asset_history_type]', 'U') IS NOT NULL
    DROP TABLE [dbo].[asset_history_type];
GO
IF OBJECT_ID(N'[dbo].[asset_type]', 'U') IS NOT NULL
    DROP TABLE [dbo].[asset_type];
GO
IF OBJECT_ID(N'[dbo].[history]', 'U') IS NOT NULL
    DROP TABLE [dbo].[history];
GO
IF OBJECT_ID(N'[dbo].[os]', 'U') IS NOT NULL
    DROP TABLE [dbo].[os];
GO
IF OBJECT_ID(N'[dbo].[staff]', 'U') IS NOT NULL
    DROP TABLE [dbo].[staff];
GO
IF OBJECT_ID(N'[dbo].[supplier]', 'U') IS NOT NULL
    DROP TABLE [dbo].[supplier];
GO
IF OBJECT_ID(N'[dbo].[user_login]', 'U') IS NOT NULL
    DROP TABLE [dbo].[user_login];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'asset'
CREATE TABLE [dbo].[asset] (
    [asset_id] int  NOT NULL,
    [os_id] int  NULL,
    [asset_type_id] int  NULL,
    [original_supplier_id] int  NULL,
    [supplier_id] int  NULL,
    [using_by_staff_id] int  NULL,
    [asset_code] varchar(50)  NULL,
    [brand] varchar(100)  NULL,
    [price] decimal(10,2)  NULL,
    [cpu] varchar(100)  NULL,
    [ram] varchar(100)  NULL,
    [hdd] varchar(100)  NULL,
    [notes] varchar(max)  NULL,
    [start_date_warranty] datetime  NULL,
    [expiry_date_warranty] datetime  NULL,
    [is_active] bit  NULL,
    [create_date] datetime  NULL,
    [modified_date] datetime  NULL
);
GO

-- Creating table 'asset_history'
CREATE TABLE [dbo].[asset_history] (
    [asset_history_id] int  NOT NULL,
    [user_id] int  NULL,
    [asset_id] int  NULL,
    [asset_history_type] int  NULL,
    [remark] varchar(max)  NULL,
    [history_timestamp] datetime  NULL
);
GO

-- Creating table 'asset_history_type'
CREATE TABLE [dbo].[asset_history_type] (
    [asset_history_type_id] int  NOT NULL,
    [type_code] varchar(100)  NULL,
    [type_description] varchar(max)  NULL,
    [is_active] bit  NULL,
    [create_date] datetime  NULL,
    [modified_date] datetime  NULL
);
GO

-- Creating table 'asset_type'
CREATE TABLE [dbo].[asset_type] (
    [asset_type_id] int  NOT NULL,
    [asset_type_name] varchar(100)  NULL,
    [is_active] bit  NULL,
    [create_date] datetime  NULL,
    [modified_date] datetime  NULL
);
GO

-- Creating table 'history'
CREATE TABLE [dbo].[history] (
    [history_id] int  NOT NULL,
    [user_id] int  NULL,
    [references_id] int  NULL,
    [detail] varchar(max)  NULL,
    [history_timestamp] datetime  NULL,
    [history_type] int  NULL
);
GO

-- Creating table 'os'
CREATE TABLE [dbo].[os] (
    [os_id] int  NOT NULL,
    [os_name] varchar(100)  NULL,
    [is_active] bit  NULL,
    [create_date] datetime  NULL,
    [modified_date] datetime  NULL
);
GO

-- Creating table 'staff'
CREATE TABLE [dbo].[staff] (
    [staff_id] int  NOT NULL,
    [firstname] varchar(100)  NULL,
    [lastname] varchar(100)  NULL,
    [aka] varchar(50)  NULL,
    [start_date] datetime  NULL,
    [end_date] datetime  NULL,
    [is_active] bit  NULL,
    [create_date] datetime  NULL,
    [modified_date] datetime  NULL
);
GO

-- Creating table 'supplier'
CREATE TABLE [dbo].[supplier] (
    [supplier_id] int  NOT NULL,
    [company_name] varchar(200)  NULL,
    [contact_person] varchar(200)  NULL,
    [address] varchar(400)  NULL,
    [email] varchar(200)  NULL,
    [phone] varchar(20)  NULL,
    [is_active] bit  NULL,
    [create_date] datetime  NULL,
    [modified_date] datetime  NULL
);
GO

-- Creating table 'user_login'
CREATE TABLE [dbo].[user_login] (
    [user_id] int  NOT NULL,
    [username] varchar(50)  NULL,
    [password] varchar(128)  NULL,
    [user_role] int  NULL,
    [is_active] bit  NULL,
    [create_date] datetime  NULL,
    [modified_date] datetime  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [asset_id] in table 'asset'
ALTER TABLE [dbo].[asset]
ADD CONSTRAINT [PK_asset]
    PRIMARY KEY CLUSTERED ([asset_id] ASC);
GO

-- Creating primary key on [asset_history_id] in table 'asset_history'
ALTER TABLE [dbo].[asset_history]
ADD CONSTRAINT [PK_asset_history]
    PRIMARY KEY CLUSTERED ([asset_history_id] ASC);
GO

-- Creating primary key on [asset_history_type_id] in table 'asset_history_type'
ALTER TABLE [dbo].[asset_history_type]
ADD CONSTRAINT [PK_asset_history_type]
    PRIMARY KEY CLUSTERED ([asset_history_type_id] ASC);
GO

-- Creating primary key on [asset_type_id] in table 'asset_type'
ALTER TABLE [dbo].[asset_type]
ADD CONSTRAINT [PK_asset_type]
    PRIMARY KEY CLUSTERED ([asset_type_id] ASC);
GO

-- Creating primary key on [history_id] in table 'history'
ALTER TABLE [dbo].[history]
ADD CONSTRAINT [PK_history]
    PRIMARY KEY CLUSTERED ([history_id] ASC);
GO

-- Creating primary key on [os_id] in table 'os'
ALTER TABLE [dbo].[os]
ADD CONSTRAINT [PK_os]
    PRIMARY KEY CLUSTERED ([os_id] ASC);
GO

-- Creating primary key on [staff_id] in table 'staff'
ALTER TABLE [dbo].[staff]
ADD CONSTRAINT [PK_staff]
    PRIMARY KEY CLUSTERED ([staff_id] ASC);
GO

-- Creating primary key on [supplier_id] in table 'supplier'
ALTER TABLE [dbo].[supplier]
ADD CONSTRAINT [PK_supplier]
    PRIMARY KEY CLUSTERED ([supplier_id] ASC);
GO

-- Creating primary key on [user_id] in table 'user_login'
ALTER TABLE [dbo].[user_login]
ADD CONSTRAINT [PK_user_login]
    PRIMARY KEY CLUSTERED ([user_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [user_id] in table 'history'
ALTER TABLE [dbo].[history]
ADD CONSTRAINT [FK_historye_user_id_FK]
    FOREIGN KEY ([user_id])
    REFERENCES [dbo].[user_login]
        ([user_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_historye_user_id_FK'
CREATE INDEX [IX_FK_historye_user_id_FK]
ON [dbo].[history]
    ([user_id]);
GO

-- Creating foreign key on [asset_id] in table 'asset_history'
ALTER TABLE [dbo].[asset_history]
ADD CONSTRAINT [FK_asset_id_FK]
    FOREIGN KEY ([asset_id])
    REFERENCES [dbo].[asset]
        ([asset_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_asset_id_FK'
CREATE INDEX [IX_FK_asset_id_FK]
ON [dbo].[asset_history]
    ([asset_id]);
GO

-- Creating foreign key on [asset_type_id] in table 'asset'
ALTER TABLE [dbo].[asset]
ADD CONSTRAINT [FK_asset_type_id_FK]
    FOREIGN KEY ([asset_type_id])
    REFERENCES [dbo].[asset_type]
        ([asset_type_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_asset_type_id_FK'
CREATE INDEX [IX_FK_asset_type_id_FK]
ON [dbo].[asset]
    ([asset_type_id]);
GO

-- Creating foreign key on [original_supplier_id] in table 'asset'
ALTER TABLE [dbo].[asset]
ADD CONSTRAINT [FK_original_supplier_id_FK]
    FOREIGN KEY ([original_supplier_id])
    REFERENCES [dbo].[supplier]
        ([supplier_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_original_supplier_id_FK'
CREATE INDEX [IX_FK_original_supplier_id_FK]
ON [dbo].[asset]
    ([original_supplier_id]);
GO

-- Creating foreign key on [os_id] in table 'asset'
ALTER TABLE [dbo].[asset]
ADD CONSTRAINT [FK_os_id_FK]
    FOREIGN KEY ([os_id])
    REFERENCES [dbo].[os]
        ([os_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_os_id_FK'
CREATE INDEX [IX_FK_os_id_FK]
ON [dbo].[asset]
    ([os_id]);
GO

-- Creating foreign key on [supplier_id] in table 'asset'
ALTER TABLE [dbo].[asset]
ADD CONSTRAINT [FK_supplier_id_FK]
    FOREIGN KEY ([supplier_id])
    REFERENCES [dbo].[supplier]
        ([supplier_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_supplier_id_FK'
CREATE INDEX [IX_FK_supplier_id_FK]
ON [dbo].[asset]
    ([supplier_id]);
GO

-- Creating foreign key on [using_by_staff_id] in table 'asset'
ALTER TABLE [dbo].[asset]
ADD CONSTRAINT [FK_using_by_staff_id_FK]
    FOREIGN KEY ([using_by_staff_id])
    REFERENCES [dbo].[staff]
        ([staff_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_using_by_staff_id_FK'
CREATE INDEX [IX_FK_using_by_staff_id_FK]
ON [dbo].[asset]
    ([using_by_staff_id]);
GO

-- Creating foreign key on [user_id] in table 'asset_history'
ALTER TABLE [dbo].[asset_history]
ADD CONSTRAINT [FK_asset_history_id_FK]
    FOREIGN KEY ([user_id])
    REFERENCES [dbo].[user_login]
        ([user_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_asset_history_id_FK'
CREATE INDEX [IX_FK_asset_history_id_FK]
ON [dbo].[asset_history]
    ([user_id]);
GO

-- Creating foreign key on [asset_history_type] in table 'asset_history'
ALTER TABLE [dbo].[asset_history]
ADD CONSTRAINT [FK_asset_history_type_FK]
    FOREIGN KEY ([asset_history_type])
    REFERENCES [dbo].[asset_history_type]
        ([asset_history_type_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_asset_history_type_FK'
CREATE INDEX [IX_FK_asset_history_type_FK]
ON [dbo].[asset_history]
    ([asset_history_type]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------