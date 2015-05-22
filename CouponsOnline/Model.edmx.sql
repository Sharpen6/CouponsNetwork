
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/22/2015 13:39:05
-- Generated from EDMX file: C:\Users\DorinS\Documents\GitHub\CouponsNetwork\CouponsOnline\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [basic];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_BusinessCoupon]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Coupons] DROP CONSTRAINT [FK_BusinessCoupon];
GO
IF OBJECT_ID(N'[dbo].[FK_BusinessLocation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Businesses] DROP CONSTRAINT [FK_BusinessLocation];
GO
IF OBJECT_ID(N'[dbo].[FK_CouponOrderedCoupon]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderedCoupons] DROP CONSTRAINT [FK_CouponOrderedCoupon];
GO
IF OBJECT_ID(N'[dbo].[FK_LocationVisit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Visits] DROP CONSTRAINT [FK_LocationVisit];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomerOrderedCoupon]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderedCoupons] DROP CONSTRAINT [FK_CustomerOrderedCoupon];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomerRecommendation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Recommendations] DROP CONSTRAINT [FK_CustomerRecommendation];
GO
IF OBJECT_ID(N'[dbo].[FK_Admin_inherits_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users_Admin] DROP CONSTRAINT [FK_Admin_inherits_User];
GO
IF OBJECT_ID(N'[dbo].[FK_Customer_inherits_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users_Customer] DROP CONSTRAINT [FK_Customer_inherits_User];
GO
IF OBJECT_ID(N'[dbo].[FK_Owner_inherits_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users_Owner] DROP CONSTRAINT [FK_Owner_inherits_User];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomerVisit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Visits] DROP CONSTRAINT [FK_CustomerVisit];
GO
IF OBJECT_ID(N'[dbo].[FK_Users_AdminBusiness]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Businesses] DROP CONSTRAINT [FK_Users_AdminBusiness];
GO
IF OBJECT_ID(N'[dbo].[FK_BusinessUsers_Owner]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Businesses] DROP CONSTRAINT [FK_BusinessUsers_Owner];
GO
IF OBJECT_ID(N'[dbo].[FK_BusinessCategoriesInterest]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Interests] DROP CONSTRAINT [FK_BusinessCategoriesInterest];
GO
IF OBJECT_ID(N'[dbo].[FK_BusinessBusinessCategories]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Businesses] DROP CONSTRAINT [FK_BusinessBusinessCategories];
GO
IF OBJECT_ID(N'[dbo].[FK_InterestCoupon_Interest]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InterestCoupon] DROP CONSTRAINT [FK_InterestCoupon_Interest];
GO
IF OBJECT_ID(N'[dbo].[FK_InterestCoupon_Coupon]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InterestCoupon] DROP CONSTRAINT [FK_InterestCoupon_Coupon];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Businesses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Businesses];
GO
IF OBJECT_ID(N'[dbo].[Coupons]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Coupons];
GO
IF OBJECT_ID(N'[dbo].[Locations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Locations];
GO
IF OBJECT_ID(N'[dbo].[OrderedCoupons]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderedCoupons];
GO
IF OBJECT_ID(N'[dbo].[Recommendations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Recommendations];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Users_Admin]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users_Admin];
GO
IF OBJECT_ID(N'[dbo].[Users_Customer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users_Customer];
GO
IF OBJECT_ID(N'[dbo].[Users_Owner]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users_Owner];
GO
IF OBJECT_ID(N'[dbo].[Visits]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Visits];
GO
IF OBJECT_ID(N'[dbo].[BusinessCategories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BusinessCategories];
GO
IF OBJECT_ID(N'[dbo].[Interests]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Interests];
GO
IF OBJECT_ID(N'[dbo].[InterestCoupon]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InterestCoupon];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Businesses'
CREATE TABLE [dbo].[Businesses] (
    [BusinessID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [Location_Id] int  NULL,
    [BusinessCategoriesId] int  NOT NULL,
    [Users_Admin_UserName] varchar(500)  NOT NULL,
    [Users_Owner_UserName] varchar(500)  NOT NULL
);
GO

-- Creating table 'Coupons'
CREATE TABLE [dbo].[Coupons] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [OriginalPrice] nvarchar(max)  NOT NULL,
    [DiscountPrice] nvarchar(max)  NOT NULL,
    [ExperationDate] nvarchar(max)  NOT NULL,
    [AvarageRanking] nvarchar(max)  NULL,
    [MaxNum] int  NOT NULL,
    [Business_BusinessID] int  NOT NULL
);
GO

-- Creating table 'Locations'
CREATE TABLE [dbo].[Locations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Coordinates] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'OrderedCoupons'
CREATE TABLE [dbo].[OrderedCoupons] (
    [SerialNum] int IDENTITY(1,1) NOT NULL,
    [Status] int  NOT NULL,
    [PurchaseDate] nvarchar(max)  NOT NULL,
    [UseDate] nvarchar(max)  NOT NULL,
    [Opinion] nvarchar(max)  NULL,
    [Rank] nvarchar(max)  NULL,
    [Coupon_Id] int  NOT NULL,
    [Customer_UserName] varchar(500)  NOT NULL
);
GO

-- Creating table 'Recommendations'
CREATE TABLE [dbo].[Recommendations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Source] int  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Link] nvarchar(max)  NOT NULL,
    [Customer_UserName] varchar(500)  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserName] varchar(500)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NULL,
    [Name] nvarchar(max)  NOT NULL,
    [PhoneKidomet] int  NULL,
    [PhoneNum] int  NULL
);
GO

-- Creating table 'Users_Admin'
CREATE TABLE [dbo].[Users_Admin] (
    [UserName] varchar(500)  NOT NULL
);
GO

-- Creating table 'Users_Customer'
CREATE TABLE [dbo].[Users_Customer] (
    [UserName] varchar(500)  NOT NULL
);
GO

-- Creating table 'Users_Owner'
CREATE TABLE [dbo].[Users_Owner] (
    [UserName] varchar(500)  NOT NULL
);
GO

-- Creating table 'Visits'
CREATE TABLE [dbo].[Visits] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date] nvarchar(max)  NOT NULL,
    [Location_Id] int  NOT NULL,
    [CustomerVisit_Visit_UserName] varchar(500)  NOT NULL
);
GO

-- Creating table 'BusinessCategories'
CREATE TABLE [dbo].[BusinessCategories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Interests'
CREATE TABLE [dbo].[Interests] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [BusinessCategoriesId] int  NOT NULL
);
GO

-- Creating table 'InterestCoupon'
CREATE TABLE [dbo].[InterestCoupon] (
    [Interests_Id] int  NOT NULL,
    [Coupons_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [BusinessID] in table 'Businesses'
ALTER TABLE [dbo].[Businesses]
ADD CONSTRAINT [PK_Businesses]
    PRIMARY KEY CLUSTERED ([BusinessID] ASC);
GO

-- Creating primary key on [Id] in table 'Coupons'
ALTER TABLE [dbo].[Coupons]
ADD CONSTRAINT [PK_Coupons]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Locations'
ALTER TABLE [dbo].[Locations]
ADD CONSTRAINT [PK_Locations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [SerialNum] in table 'OrderedCoupons'
ALTER TABLE [dbo].[OrderedCoupons]
ADD CONSTRAINT [PK_OrderedCoupons]
    PRIMARY KEY CLUSTERED ([SerialNum] ASC);
GO

-- Creating primary key on [Id] in table 'Recommendations'
ALTER TABLE [dbo].[Recommendations]
ADD CONSTRAINT [PK_Recommendations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [UserName] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserName] ASC);
GO

-- Creating primary key on [UserName] in table 'Users_Admin'
ALTER TABLE [dbo].[Users_Admin]
ADD CONSTRAINT [PK_Users_Admin]
    PRIMARY KEY CLUSTERED ([UserName] ASC);
GO

-- Creating primary key on [UserName] in table 'Users_Customer'
ALTER TABLE [dbo].[Users_Customer]
ADD CONSTRAINT [PK_Users_Customer]
    PRIMARY KEY CLUSTERED ([UserName] ASC);
GO

-- Creating primary key on [UserName] in table 'Users_Owner'
ALTER TABLE [dbo].[Users_Owner]
ADD CONSTRAINT [PK_Users_Owner]
    PRIMARY KEY CLUSTERED ([UserName] ASC);
GO

-- Creating primary key on [Id] in table 'Visits'
ALTER TABLE [dbo].[Visits]
ADD CONSTRAINT [PK_Visits]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BusinessCategories'
ALTER TABLE [dbo].[BusinessCategories]
ADD CONSTRAINT [PK_BusinessCategories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Interests'
ALTER TABLE [dbo].[Interests]
ADD CONSTRAINT [PK_Interests]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Interests_Id], [Coupons_Id] in table 'InterestCoupon'
ALTER TABLE [dbo].[InterestCoupon]
ADD CONSTRAINT [PK_InterestCoupon]
    PRIMARY KEY CLUSTERED ([Interests_Id], [Coupons_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Business_BusinessID] in table 'Coupons'
ALTER TABLE [dbo].[Coupons]
ADD CONSTRAINT [FK_BusinessCoupon]
    FOREIGN KEY ([Business_BusinessID])
    REFERENCES [dbo].[Businesses]
        ([BusinessID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BusinessCoupon'
CREATE INDEX [IX_FK_BusinessCoupon]
ON [dbo].[Coupons]
    ([Business_BusinessID]);
GO

-- Creating foreign key on [Location_Id] in table 'Businesses'
ALTER TABLE [dbo].[Businesses]
ADD CONSTRAINT [FK_BusinessLocation]
    FOREIGN KEY ([Location_Id])
    REFERENCES [dbo].[Locations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BusinessLocation'
CREATE INDEX [IX_FK_BusinessLocation]
ON [dbo].[Businesses]
    ([Location_Id]);
GO

-- Creating foreign key on [Coupon_Id] in table 'OrderedCoupons'
ALTER TABLE [dbo].[OrderedCoupons]
ADD CONSTRAINT [FK_CouponOrderedCoupon]
    FOREIGN KEY ([Coupon_Id])
    REFERENCES [dbo].[Coupons]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CouponOrderedCoupon'
CREATE INDEX [IX_FK_CouponOrderedCoupon]
ON [dbo].[OrderedCoupons]
    ([Coupon_Id]);
GO

-- Creating foreign key on [Location_Id] in table 'Visits'
ALTER TABLE [dbo].[Visits]
ADD CONSTRAINT [FK_LocationVisit]
    FOREIGN KEY ([Location_Id])
    REFERENCES [dbo].[Locations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_LocationVisit'
CREATE INDEX [IX_FK_LocationVisit]
ON [dbo].[Visits]
    ([Location_Id]);
GO

-- Creating foreign key on [Customer_UserName] in table 'OrderedCoupons'
ALTER TABLE [dbo].[OrderedCoupons]
ADD CONSTRAINT [FK_CustomerOrderedCoupon]
    FOREIGN KEY ([Customer_UserName])
    REFERENCES [dbo].[Users_Customer]
        ([UserName])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerOrderedCoupon'
CREATE INDEX [IX_FK_CustomerOrderedCoupon]
ON [dbo].[OrderedCoupons]
    ([Customer_UserName]);
GO

-- Creating foreign key on [Customer_UserName] in table 'Recommendations'
ALTER TABLE [dbo].[Recommendations]
ADD CONSTRAINT [FK_CustomerRecommendation]
    FOREIGN KEY ([Customer_UserName])
    REFERENCES [dbo].[Users_Customer]
        ([UserName])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerRecommendation'
CREATE INDEX [IX_FK_CustomerRecommendation]
ON [dbo].[Recommendations]
    ([Customer_UserName]);
GO

-- Creating foreign key on [UserName] in table 'Users_Admin'
ALTER TABLE [dbo].[Users_Admin]
ADD CONSTRAINT [FK_Admin_inherits_User]
    FOREIGN KEY ([UserName])
    REFERENCES [dbo].[Users]
        ([UserName])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [UserName] in table 'Users_Customer'
ALTER TABLE [dbo].[Users_Customer]
ADD CONSTRAINT [FK_Customer_inherits_User]
    FOREIGN KEY ([UserName])
    REFERENCES [dbo].[Users]
        ([UserName])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [UserName] in table 'Users_Owner'
ALTER TABLE [dbo].[Users_Owner]
ADD CONSTRAINT [FK_Owner_inherits_User]
    FOREIGN KEY ([UserName])
    REFERENCES [dbo].[Users]
        ([UserName])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [CustomerVisit_Visit_UserName] in table 'Visits'
ALTER TABLE [dbo].[Visits]
ADD CONSTRAINT [FK_CustomerVisit]
    FOREIGN KEY ([CustomerVisit_Visit_UserName])
    REFERENCES [dbo].[Users_Customer]
        ([UserName])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerVisit'
CREATE INDEX [IX_FK_CustomerVisit]
ON [dbo].[Visits]
    ([CustomerVisit_Visit_UserName]);
GO

-- Creating foreign key on [Users_Admin_UserName] in table 'Businesses'
ALTER TABLE [dbo].[Businesses]
ADD CONSTRAINT [FK_Users_AdminBusiness]
    FOREIGN KEY ([Users_Admin_UserName])
    REFERENCES [dbo].[Users_Admin]
        ([UserName])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Users_AdminBusiness'
CREATE INDEX [IX_FK_Users_AdminBusiness]
ON [dbo].[Businesses]
    ([Users_Admin_UserName]);
GO

-- Creating foreign key on [Users_Owner_UserName] in table 'Businesses'
ALTER TABLE [dbo].[Businesses]
ADD CONSTRAINT [FK_BusinessUsers_Owner]
    FOREIGN KEY ([Users_Owner_UserName])
    REFERENCES [dbo].[Users_Owner]
        ([UserName])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BusinessUsers_Owner'
CREATE INDEX [IX_FK_BusinessUsers_Owner]
ON [dbo].[Businesses]
    ([Users_Owner_UserName]);
GO

-- Creating foreign key on [BusinessCategoriesId] in table 'Interests'
ALTER TABLE [dbo].[Interests]
ADD CONSTRAINT [FK_BusinessCategoriesInterest]
    FOREIGN KEY ([BusinessCategoriesId])
    REFERENCES [dbo].[BusinessCategories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BusinessCategoriesInterest'
CREATE INDEX [IX_FK_BusinessCategoriesInterest]
ON [dbo].[Interests]
    ([BusinessCategoriesId]);
GO

-- Creating foreign key on [BusinessCategoriesId] in table 'Businesses'
ALTER TABLE [dbo].[Businesses]
ADD CONSTRAINT [FK_BusinessBusinessCategories]
    FOREIGN KEY ([BusinessCategoriesId])
    REFERENCES [dbo].[BusinessCategories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BusinessBusinessCategories'
CREATE INDEX [IX_FK_BusinessBusinessCategories]
ON [dbo].[Businesses]
    ([BusinessCategoriesId]);
GO

-- Creating foreign key on [Interests_Id] in table 'InterestCoupon'
ALTER TABLE [dbo].[InterestCoupon]
ADD CONSTRAINT [FK_InterestCoupon_Interest]
    FOREIGN KEY ([Interests_Id])
    REFERENCES [dbo].[Interests]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Coupons_Id] in table 'InterestCoupon'
ALTER TABLE [dbo].[InterestCoupon]
ADD CONSTRAINT [FK_InterestCoupon_Coupon]
    FOREIGN KEY ([Coupons_Id])
    REFERENCES [dbo].[Coupons]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InterestCoupon_Coupon'
CREATE INDEX [IX_FK_InterestCoupon_Coupon]
ON [dbo].[InterestCoupon]
    ([Coupons_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------