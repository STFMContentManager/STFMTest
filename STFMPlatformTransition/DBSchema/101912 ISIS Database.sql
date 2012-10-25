USE [ISIS]
GO
/****** Object:  User [ISISTest]    Script Date: 10/19/2012 10:05:34 ******/
/*CREATE USER [ISISTest] FOR LOGIN [ISISTest] WITH DEFAULT_SCHEMA=[db_datareader]
GO*/
/****** Object:  Table [dbo].[PersonsCompany]    Script Date: 10/19/2012 10:05:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonsCompany](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PersonsID] [int] NULL,
	[CompaniesID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssociationType]    Script Date: 10/19/2012 10:05:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AssociationType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AssocDescShort] [varchar](20) NULL,
	[AssocDescFull] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FMIssue]    Script Date: 10/19/2012 10:05:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FMIssue](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PublishDate] [datetime] NOT NULL,
	[Vol] [int] NOT NULL,
	[Num] [int] NOT NULL,
	[LiveWebDate] [datetime] NULL,
	[PDFPath] [varchar](15) NULL,
	[Published] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AddressMailingType]    Script Date: 10/19/2012 10:05:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AddressMailingType](
	[ID] [tinyint] IDENTITY(1,1) NOT NULL,
	[AddressType] [varchar](25) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AddressLocationType]    Script Date: 10/19/2012 10:05:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AddressLocationType](
	[ID] [tinyint] IDENTITY(1,1) NOT NULL,
	[LocationType] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CredentialType]    Script Date: 10/19/2012 10:05:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CredentialType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CredentialTitle] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 10/19/2012 10:05:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Countries](
	[ID] [int] NOT NULL,
	[CountryName] [varchar](255) NULL,
 CONSTRAINT [CountryID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CompanyAddressesConvert]    Script Date: 10/19/2012 10:05:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CompanyAddressesConvert](
	[AddressID] [int] IDENTITY(1000,1) NOT NULL,
	[AddressLine1] [varchar](200) NULL,
	[AddressLine2] [varchar](65) NULL,
	[AddressLine3] [varchar](65) NULL,
	[City] [varchar](50) NULL,
	[States] [varchar](2) NULL,
	[StateValue] [tinyint] NULL,
	[Zip] [varchar](10) NULL,
	[CountryID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[AddressID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CompanyAddresses]    Script Date: 10/19/2012 10:05:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CompanyAddresses](
	[ID] [int] IDENTITY(1000,1) NOT NULL,
	[AddressLine1] [varchar](200) NULL,
	[AddressLine2] [varchar](65) NULL,
	[AddressLine3] [varchar](65) NULL,
	[City] [varchar](50) NULL,
	[State] [tinyint] NULL,
	[Zip] [varchar](10) NULL,
	[CountryID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FMAuthor]    Script Date: 10/19/2012 10:05:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FMAuthor](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ArticleID] [int] NOT NULL,
	[FName] [varchar](50) NOT NULL,
	[MName] [varchar](50) NULL,
	[LName] [varchar](50) NOT NULL,
	[Organization] [varchar](100) NULL,
	[PublishOrder] [int] NULL,
	[Credential] [varchar](25) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FMArticle]    Script Date: 10/19/2012 10:05:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FMArticle](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IssueID] [int] NOT NULL,
	[Title] [varchar](300) NOT NULL,
	[Subject] [varchar](50) NULL,
	[StartPage] [int] NOT NULL,
	[EndPage] [int] NOT NULL,
	[Abstract] [varchar](3500) NOT NULL,
	[FilePDF] [varchar](25) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 10/19/2012 10:05:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Transactions](
	[ID] [int] IDENTITY(10000,1) NOT NULL,
	[PersonID] [int] NULL,
	[ProductType] [int] NULL,
	[ProductDesc] [varchar](100) NULL,
	[TransDate] [datetime] NULL,
	[TotalDue] [int] NULL,
	[TotalPaid] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TestInsert]    Script Date: 10/19/2012 10:05:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TestInsert](
	[Test] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[STFMAVTypes]    Script Date: 10/19/2012 10:05:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[STFMAVTypes](
	[TypeID] [int] IDENTITY(1,1) NOT NULL,
	[GeneralDesc] [varchar](50) NULL,
	[Brand] [varchar](25) NULL,
	[ModelNum] [varchar](50) NULL,
	[CommonDesc] [varchar](140) NULL,
PRIMARY KEY CLUSTERED 
(
	[TypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[STFMAVTrack]    Script Date: 10/19/2012 10:05:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[STFMAVTrack](
	[EquipID] [int] IDENTITY(100001,1) NOT NULL,
	[EquipType] [int] NULL,
	[EquipStatus] [int] NULL,
	[SerialNumber] [varchar](25) NULL,
	[PurchaseDate] [datetime] NULL,
	[WarrantyEnd] [datetime] NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[UseLocation] [varchar](100) NULL,
	[CurrentLocation] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[EquipID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[STFMAVCondition]    Script Date: 10/19/2012 10:05:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[STFMAVCondition](
	[StatusID] [int] IDENTITY(1,1) NOT NULL,
	[StatusText] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[StatusID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StatesList]    Script Date: 10/19/2012 10:05:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StatesList](
	[ID] [tinyint] IDENTITY(1,1) NOT NULL,
	[name] [varchar](40) NOT NULL,
	[abbrev] [varchar](2) NOT NULL,
 CONSTRAINT [stateid] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PhoneNumberType]    Script Date: 10/19/2012 10:05:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PhoneNumberType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NumberType] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MemProducts]    Script Date: 10/19/2012 10:05:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MemProducts](
	[ID] [int] IDENTITY(1000,1) NOT NULL,
	[MemTypeID] [int] NOT NULL,
	[AssociationID] [int] NOT NULL,
	[ValidFrom] [datetime] NOT NULL,
	[ValidTo] [datetime] NOT NULL,
	[Price] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MembershipType]    Script Date: 10/19/2012 10:05:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MembershipType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MembershipTypeDesc] [varchar](50) NULL,
 CONSTRAINT [PK_MemTypeID_MemType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Membership]    Script Date: 10/19/2012 10:05:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Membership](
	[ID] [int] IDENTITY(1000,1) NOT NULL,
	[AssociationID] [int] NULL,
	[MembershipTypeID] [int] NULL,
 CONSTRAINT [PK__Membersh__0CF04B382E1BDC42] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FoundationProducts]    Script Date: 10/19/2012 10:05:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FoundationProducts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductDesc] [varchar](100) NULL,
	[Price] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[InsertCompany]    Script Date: 10/19/2012 10:05:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[InsertCompany](
	@PersonID int,
	@CompanyID int) AS
	
Insert INTO PersonsCompany (PersonsID, CompaniesID) VALUES (@PersonID, @CompanyID)
GO
/****** Object:  StoredProcedure [dbo].[FMPublishIssue]    Script Date: 10/19/2012 10:05:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[FMPublishIssue] (@ID int) as Update FMIssue Set Published = 1 Where ID = @ID
GO
/****** Object:  StoredProcedure [dbo].[FMAddIssue]    Script Date: 10/19/2012 10:05:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[FMAddIssue] (@PubDate datetime, @Vol int, @Num int, @PDF varchar(15)) As

Insert into FMIssue(PublishDate, Vol, Num, PDFPath, Published) Values (@PubDate, @Vol, @Num, @PDF, 0)

SELECT SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[FMAddAuthor]    Script Date: 10/19/2012 10:05:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[FMAddAuthor] (@ArticleID int, @Fname varchar(50), 
@MName varchar(50), @Lname varchar(50), @Org varchar(100)) AS

Declare @PubOrder int
Select ArticleID FROM FMAuthor WHERE ArticleID = @ArticleID
Set @PubOrder = @@ROWCOUNT+1

IF @PubOrder = null BEGIN Set @PubOrder = 1 END

Insert Into FMAuthor(ArticleID, FName, MName, LName, Organization, PublishOrder) Values
	(@ArticleID, @Fname, @MName, @Lname, @Org, @PubOrder)
GO
/****** Object:  StoredProcedure [dbo].[FMAddArticle]    Script Date: 10/19/2012 10:05:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[FMAddArticle] (
	@IssueID int,
	@Title varchar(300),
	@Subject varchar(50),
	@Start int,
	@End int,
	@Abstract varchar(3500),
	@PDFDirectory varchar(25)) AS
	
Insert into FMArticle (IssueID, Title, Subject, StartPage, EndPage, Abstract, FilePDF) Values (
	@IssueID, @Title, @Subject, @Start, @End, @Abstract, @PDFDirectory)
	
Select SCOPE_IDENTITY()
GO
/****** Object:  Table [dbo].[Companies]    Script Date: 10/19/2012 10:05:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Companies](
	[ID] [int] IDENTITY(100,1) NOT NULL,
	[CompanyName] [varchar](100) NULL,
	[CompanyAddressID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[FMDeleteIssue]    Script Date: 10/19/2012 10:05:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[FMDeleteIssue] (@IssueID int) as
       
Delete from FMAuthor Where ArticleID IN (Select ID FROM FMArticle WHERE IssueID = @IssueID)

Delete from FMArticle WHERE IssueID = @IssueID

Delete from FMIssue WHERE ID = @IssueID
GO
/****** Object:  Table [dbo].[Persons]    Script Date: 10/19/2012 10:05:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Persons](
	[PersonID] [int] IDENTITY(100000,1) NOT NULL,
	[Prefix] [varchar](10) NULL,
	[FirstName] [varchar](50) NULL,
	[MiddleName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Suffix] [varchar](10) NULL,
	[CompanyID] [int] NULL,
	[Birthdate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PersonCredentials]    Script Date: 10/19/2012 10:05:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonCredentials](
	[ID] [int] IDENTITY(1000,1) NOT NULL,
	[PersonID] [int] NULL,
	[CredentialTypeID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[NameTest]    Script Date: 10/19/2012 10:05:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[NameTest] (

@SQLPrefix varchar(10) = NULL, 
@SQLFname Varchar(50) = NULL,
@SQLMname varchar(50) = NULL,
@SQLLname varchar(50) = Null,
@SQLsuffix varchar(10) = Null,
@SQLBday datetime = null

) AS

INSERT INTO Persons (Prefix, FirstName, MiddleName, LastName, Suffix, Birthdate)

VALUES(@SQLPrefix,@SQLFname, @SQLMname, @SQLLname, @SQLsuffix, @SQLBday)

Select SCOPE_IDENTITY()
GO
/****** Object:  Table [dbo].[Email]    Script Date: 10/19/2012 10:05:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Email](
	[ID] [int] IDENTITY(1000,1) NOT NULL,
	[PersonID] [int] NOT NULL,
	[EmailAddress] [varchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Association]    Script Date: 10/19/2012 10:05:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Association](
	[ID] [int] IDENTITY(1000,1) NOT NULL,
	[PersonID] [int] NULL,
	[AssociationTypeID] [int] NULL,
	[DateCreated] [datetime] NULL,
	[CreatedBy] [varchar](25) NULL,
 CONSTRAINT [PK__Associat__B51A19CD25869641] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 10/19/2012 10:05:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Addresses](
	[ID] [int] IDENTITY(1000,1) NOT NULL,
	[PersonID] [int] NOT NULL,
	[AddressLine1] [varchar](65) NOT NULL,
	[AddressLine2] [varchar](65) NULL,
	[AddressLine3] [varchar](65) NULL,
	[City] [varchar](50) NOT NULL,
	[States] [tinyint] NULL,
	[Zip] [varchar](10) NULL,
	[CountryID] [int] NOT NULL,
	[MailingTypeCode] [tinyint] NULL,
	[LocationTypeCode] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Phone]    Script Date: 10/19/2012 10:05:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Phone](
	[ID] [int] IDENTITY(1000,1) NOT NULL,
	[PersonID] [int] NOT NULL,
	[PhoneNumber] [varchar](20) NOT NULL,
	[CountryCode] [tinyint] NULL,
	[PhoneTypeCode] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[InsertPhone]    Script Date: 10/19/2012 10:05:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[InsertPhone](
	@PersonID int,
	@PhoneNum varchar(20),
	@CountryCode tinyint,
	@PhoneTypeCode int) as
	
 Insert into Phone (PersonID, PhoneNumber, CountryCode, PhoneTypeCode)
	Values
		(@PersonID, @PhoneNum, @CountryCode, @PhoneTypeCode)
GO
/****** Object:  StoredProcedure [dbo].[EmailInsert]    Script Date: 10/19/2012 10:05:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[EmailInsert](
  
  @PersonID int,
  @EmailAddress varchar(200)) AS
  
  Insert into Email(PersonID, EmailAddress)
	
	Values (@PersonID, @EmailAddress)
GO
/****** Object:  StoredProcedure [dbo].[AddressInsert]    Script Date: 10/19/2012 10:05:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[AddressInsert](
  
  @PersonID int,
  @AddressLine1 varchar(65),
  @AddressLine2 varchar(65),
  @AddressLine3 varchar(65),
  @City varchar(50),
  @States tinyint,
  @Zip varchar(10),
  @CountryID int,
  @MailingTypeCode tinyint,
  @LocationTypeCode tinyint)  AS
  
  Insert into Addresses(PersonID, AddressLine1, AddressLine2, AddressLine3,
	City,States,Zip,CountryID,MailingTypeCode,LocationTypeCode)
	
	Values (@PersonID, @AddressLine1, @AddressLine2, @AddressLine3, @City,
		@States, @Zip, @CountryID, @MailingTypeCode, @LocationTypeCode)
GO
/****** Object:  ForeignKey [FK_Addresses_ PID]    Script Date: 10/19/2012 10:05:34 ******/
ALTER TABLE [dbo].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK_Addresses_ PID] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Persons] ([PersonID])
GO
ALTER TABLE [dbo].[Addresses] CHECK CONSTRAINT [FK_Addresses_ PID]
GO
/****** Object:  ForeignKey [FK_PersonID_Association]    Script Date: 10/19/2012 10:05:34 ******/
ALTER TABLE [dbo].[Association]  WITH CHECK ADD  CONSTRAINT [FK_PersonID_Association] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Persons] ([PersonID])
GO
ALTER TABLE [dbo].[Association] CHECK CONSTRAINT [FK_PersonID_Association]
GO
/****** Object:  ForeignKey [FK_CompanyAddress_Companies]    Script Date: 10/19/2012 10:05:34 ******/
ALTER TABLE [dbo].[Companies]  WITH CHECK ADD  CONSTRAINT [FK_CompanyAddress_Companies] FOREIGN KEY([CompanyAddressID])
REFERENCES [dbo].[CompanyAddresses] ([ID])
GO
ALTER TABLE [dbo].[Companies] CHECK CONSTRAINT [FK_CompanyAddress_Companies]
GO
/****** Object:  ForeignKey [FK_PersonID_Email]    Script Date: 10/19/2012 10:05:34 ******/
ALTER TABLE [dbo].[Email]  WITH CHECK ADD  CONSTRAINT [FK_PersonID_Email] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Persons] ([PersonID])
GO
ALTER TABLE [dbo].[Email] CHECK CONSTRAINT [FK_PersonID_Email]
GO
/****** Object:  ForeignKey [FK_PersonID_PersonCredentials]    Script Date: 10/19/2012 10:05:34 ******/
ALTER TABLE [dbo].[PersonCredentials]  WITH CHECK ADD  CONSTRAINT [FK_PersonID_PersonCredentials] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Persons] ([PersonID])
GO
ALTER TABLE [dbo].[PersonCredentials] CHECK CONSTRAINT [FK_PersonID_PersonCredentials]
GO
/****** Object:  ForeignKey [FK_CompanyID_Persons]    Script Date: 10/19/2012 10:05:34 ******/
ALTER TABLE [dbo].[Persons]  WITH CHECK ADD  CONSTRAINT [FK_CompanyID_Persons] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Companies] ([ID])
GO
ALTER TABLE [dbo].[Persons] CHECK CONSTRAINT [FK_CompanyID_Persons]
GO
/****** Object:  ForeignKey [FK_PersonID_Phone]    Script Date: 10/19/2012 10:05:34 ******/
ALTER TABLE [dbo].[Phone]  WITH CHECK ADD  CONSTRAINT [FK_PersonID_Phone] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Persons] ([PersonID])
GO
ALTER TABLE [dbo].[Phone] CHECK CONSTRAINT [FK_PersonID_Phone]
GO
