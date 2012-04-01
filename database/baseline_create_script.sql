USE [master]
GO

/****** Object:  Database [BooksDatabase]    Script Date: 04/01/2012 14:54:51 ******/
CREATE DATABASE [BooksDatabase] ON  PRIMARY 
( NAME = N'BooksDatabase', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\BooksDatabase.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BooksDatabase_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\BooksDatabase_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [BooksDatabase] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BooksDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [BooksDatabase] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [BooksDatabase] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [BooksDatabase] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [BooksDatabase] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [BooksDatabase] SET ARITHABORT OFF 
GO

ALTER DATABASE [BooksDatabase] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [BooksDatabase] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [BooksDatabase] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [BooksDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [BooksDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [BooksDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [BooksDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [BooksDatabase] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [BooksDatabase] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [BooksDatabase] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [BooksDatabase] SET  DISABLE_BROKER 
GO

ALTER DATABASE [BooksDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [BooksDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [BooksDatabase] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [BooksDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [BooksDatabase] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [BooksDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [BooksDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [BooksDatabase] SET  READ_WRITE 
GO

ALTER DATABASE [BooksDatabase] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [BooksDatabase] SET  MULTI_USER 
GO

ALTER DATABASE [BooksDatabase] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [BooksDatabase] SET DB_CHAINING OFF 
GO


USE [BooksDatabase]
GO
/****** Object:  Table [dbo].[Genres]    Script Date: 04/01/2012 14:55:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Genres](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK__genre__3213E83F145C0A3F] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Genres] ON
INSERT [dbo].[Genres] ([ID], [Name], [IsActive]) VALUES (1, N'Sci-Fi', NULL)
INSERT [dbo].[Genres] ([ID], [Name], [IsActive]) VALUES (2, N'Computers', NULL)
INSERT [dbo].[Genres] ([ID], [Name], [IsActive]) VALUES (3, N'Mystery', NULL)
INSERT [dbo].[Genres] ([ID], [Name], [IsActive]) VALUES (4, N'Historical', NULL)
INSERT [dbo].[Genres] ([ID], [Name], [IsActive]) VALUES (5, N'Fantasy', NULL)
INSERT [dbo].[Genres] ([ID], [Name], [IsActive]) VALUES (6, N'Technical', NULL)
INSERT [dbo].[Genres] ([ID], [Name], [IsActive]) VALUES (7, N'Sport', NULL)
SET IDENTITY_INSERT [dbo].[Genres] OFF
/****** Object:  Table [dbo].[Formats]    Script Date: 04/01/2012 14:55:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Formats](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
 CONSTRAINT [PK__format__3213E83F108B795B] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Formats] ON
INSERT [dbo].[Formats] ([ID], [Name]) VALUES (1, N'Paperback')
INSERT [dbo].[Formats] ([ID], [Name]) VALUES (2, N'Hardcover')
INSERT [dbo].[Formats] ([ID], [Name]) VALUES (3, N'Comic')
INSERT [dbo].[Formats] ([ID], [Name]) VALUES (4, N'Trade')
INSERT [dbo].[Formats] ([ID], [Name]) VALUES (5, N'Graphic Novel')
INSERT [dbo].[Formats] ([ID], [Name]) VALUES (6, N'E-book')
SET IDENTITY_INSERT [dbo].[Formats] OFF
/****** Object:  Table [dbo].[Countries]    Script Date: 04/01/2012 14:55:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Countries](
	[ISO] [char](2) NOT NULL,
	[Name] [varchar](80) NOT NULL,
	[PrintableName] [varchar](80) NOT NULL,
	[ISO3] [char](3) NULL,
	[NumCode] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[ISO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Countries] ([ISO], [Name], [PrintableName], [ISO3], [NumCode]) VALUES (N'AT', N'ATLANTIS', N'Atlantis', N'ATL', 904)
INSERT [dbo].[Countries] ([ISO], [Name], [PrintableName], [ISO3], [NumCode]) VALUES (N'AU', N'AUSTRALIA', N'Australia', N'AUS', 36)
INSERT [dbo].[Countries] ([ISO], [Name], [PrintableName], [ISO3], [NumCode]) VALUES (N'CZ', N'CZECH REPUBLIC', N'Czech Republic', N'CZE', 203)
INSERT [dbo].[Countries] ([ISO], [Name], [PrintableName], [ISO3], [NumCode]) VALUES (N'DE', N'GERMANY', N'Germany', N'DEU', 276)
INSERT [dbo].[Countries] ([ISO], [Name], [PrintableName], [ISO3], [NumCode]) VALUES (N'DK', N'DENMARK', N'Denmark', N'DNK', 208)
INSERT [dbo].[Countries] ([ISO], [Name], [PrintableName], [ISO3], [NumCode]) VALUES (N'FR', N'FRANCE', N'France', N'FRA', 250)
INSERT [dbo].[Countries] ([ISO], [Name], [PrintableName], [ISO3], [NumCode]) VALUES (N'GB', N'UNITED KINGDOM', N'United Kingdom', N'GBR', 826)
INSERT [dbo].[Countries] ([ISO], [Name], [PrintableName], [ISO3], [NumCode]) VALUES (N'GF', N'GRAND FENWICK', N'Grand Fenwick', N'GFK', 903)
INSERT [dbo].[Countries] ([ISO], [Name], [PrintableName], [ISO3], [NumCode]) VALUES (N'GK', N'GRAUSTARK', N'Graustark', N'GRA', 901)
INSERT [dbo].[Countries] ([ISO], [Name], [PrintableName], [ISO3], [NumCode]) VALUES (N'PL', N'POLAND', N'Poland', N'POL', 616)
INSERT [dbo].[Countries] ([ISO], [Name], [PrintableName], [ISO3], [NumCode]) VALUES (N'PT', N'PORTUGAL', N'Portugal', N'PRT', 620)
INSERT [dbo].[Countries] ([ISO], [Name], [PrintableName], [ISO3], [NumCode]) VALUES (N'RO', N'ROMANIA', N'Romania', N'ROM', 642)
INSERT [dbo].[Countries] ([ISO], [Name], [PrintableName], [ISO3], [NumCode]) VALUES (N'RU', N'RUSSIAN FEDERATION', N'Russian Federation', N'RUS', 643)
INSERT [dbo].[Countries] ([ISO], [Name], [PrintableName], [ISO3], [NumCode]) VALUES (N'US', N'UNITED STATES', N'United States', N'USA', 840)
INSERT [dbo].[Countries] ([ISO], [Name], [PrintableName], [ISO3], [NumCode]) VALUES (N'UT', N'UTOPIA', N'Utopia', N'UTO', 902)
INSERT [dbo].[Countries] ([ISO], [Name], [PrintableName], [ISO3], [NumCode]) VALUES (N'ZW', N'ZIMBABWE', N'Zimbabwe', N'ZWE', 716)
/****** Object:  Table [dbo].[Authors]    Script Date: 04/01/2012 14:55:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Authors](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](100) NOT NULL,
	[LastName] [varchar](100) NOT NULL,
	[CountryISO] [char](2) NULL,
	[BirthDate] [datetime] NULL,
 CONSTRAINT [PK_author] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Authors] ON
INSERT [dbo].[Authors] ([ID], [FirstName], [LastName], [CountryISO], [BirthDate]) VALUES (1, N'Fyodor', N'Dostoyevsky', N'RU', CAST(0xFFFF908400000000 AS DateTime))
INSERT [dbo].[Authors] ([ID], [FirstName], [LastName], [CountryISO], [BirthDate]) VALUES (2, N'J.K.', N'Rowling', N'GB', CAST(0x0000930300000000 AS DateTime))
INSERT [dbo].[Authors] ([ID], [FirstName], [LastName], [CountryISO], [BirthDate]) VALUES (3, N'Neil', N'Stephenson', N'US', CAST(0x0000555C00000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[Authors] OFF
/****** Object:  Table [dbo].[Users]    Script Date: 04/01/2012 14:55:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](100) NOT NULL,
	[FavouriteCategory] [varchar](100) NULL,
	[FavouriteBook] [varchar](250) NULL,
	[Occupation] [varchar](250) NULL,
	[CountryISO] [char](2) NULL,
	[BirthDate] [datetime] NULL,
	[LastActivity] [datetime] NULL,
	[Street] [varchar](150) NULL,
	[City] [varchar](100) NULL,
	[Phone] [varchar](100) NULL,
	[Email] [varchar](100) NULL,
 CONSTRAINT [PK__user__B9BE370F7F60ED59] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON
INSERT [dbo].[Users] ([ID], [UserName], [FavouriteCategory], [FavouriteBook], [Occupation], [CountryISO], [BirthDate], [LastActivity], [Street], [City], [Phone], [Email]) VALUES (1, N'jdoe', N'Sci-Fi', N'Necronomicon', N'management', N'US', CAST(0x0000644F015BB7A0 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Users] ([ID], [UserName], [FavouriteCategory], [FavouriteBook], [Occupation], [CountryISO], [BirthDate], [LastActivity], [Street], [City], [Phone], [Email]) VALUES (2, N'muffet', N'Fantasy', N'Cooking Fungi', N'none', N'GB', CAST(0x000077930170B128 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Users] ([ID], [UserName], [FavouriteCategory], [FavouriteBook], [Occupation], [CountryISO], [BirthDate], [LastActivity], [Street], [City], [Phone], [Email]) VALUES (3, N'sam', N'Technical', N'Higher Order Perl', N'programmer', N'US', CAST(0x000068B60170B128 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Users] ([ID], [UserName], [FavouriteCategory], [FavouriteBook], [Occupation], [CountryISO], [BirthDate], [LastActivity], [Street], [City], [Phone], [Email]) VALUES (4, N'jsw', N'Historical', N'History of the World', N'unemployed', N'RU', CAST(0x00005D0F0170B128 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Users] ([ID], [UserName], [FavouriteCategory], [FavouriteBook], [Occupation], [CountryISO], [BirthDate], [LastActivity], [Street], [City], [Phone], [Email]) VALUES (5, N'plax', N'Sci-Fi', N'Fungibility', N'editor', N'PL', CAST(0x00006F040170B128 AS DateTime), NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
/****** Object:  Table [dbo].[Books]    Script Date: 04/01/2012 14:55:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Books](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ISBN] [varchar](100) NOT NULL,
	[Title] [varchar](100) NOT NULL,
	[AuthorID] [int] NOT NULL,
	[Publisher] [varchar](100) NOT NULL,
	[Pages] [int] NULL,
	[Year] [int] NOT NULL,
	[FormatID] [int] NULL,
	[GenreID] [int] NULL,
	[BorrowedDate] [datetime] NULL,
	[BorrowerID] [int] NULL,
	[Extra] [varchar](100) NULL,
 CONSTRAINT [PK__book__3213E83F1DE57479] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Books] ON
INSERT [dbo].[Books] ([ID], [ISBN], [Title], [AuthorID], [Publisher], [Pages], [Year], [FormatID], [GenreID], [BorrowedDate], [BorrowerID], [Extra]) VALUES (1, N'0-7475-5100-6', N'.NET Best Practices', 1, N'Microsoft Press', 766, 2011, 1, 2, NULL, 2, N'')
INSERT [dbo].[Books] ([ID], [ISBN], [Title], [AuthorID], [Publisher], [Pages], [Year], [FormatID], [GenreID], [BorrowedDate], [BorrowerID], [Extra]) VALUES (2, N'9 788256006199', N'The Pragmatic Programmer', 1, N'Interbook', 442, 2005, 2, 2, NULL, 2, N'')
INSERT [dbo].[Books] ([ID], [ISBN], [Title], [AuthorID], [Publisher], [Pages], [Year], [FormatID], [GenreID], [BorrowedDate], [BorrowerID], [Extra]) VALUES (3, N'434012386', N'The Confusion', 2, N'Heinemann', 345, 2002, 2, 3, NULL, 1, N'')
INSERT [dbo].[Books] ([ID], [ISBN], [Title], [AuthorID], [Publisher], [Pages], [Year], [FormatID], [GenreID], [BorrowedDate], [BorrowerID], [Extra]) VALUES (4, N'782128254', N'The Complete Java 2 Certification Study Guide: Programmer''s and Developers Exams (With CD-ROM)', 2, N'Sybex Inc', NULL, 1999, 1, 2, NULL, 3, N'')
INSERT [dbo].[Books] ([ID], [ISBN], [Title], [AuthorID], [Publisher], [Pages], [Year], [FormatID], [GenreID], [BorrowedDate], [BorrowerID], [Extra]) VALUES (5, N'123-1234-0-123', N'Arnold''s Quest', 3, N'Houghton Mifflin', 345, 1935, 2, 5, NULL, 5, N'')
INSERT [dbo].[Books] ([ID], [ISBN], [Title], [AuthorID], [Publisher], [Pages], [Year], [FormatID], [GenreID], [BorrowedDate], [BorrowerID], [Extra]) VALUES (6, N'0-596-10092-2', N'Perl Testing: A Developer''s Notebook', 3, N'O''Reilly', 182, 2005, 3, 2, NULL, 3, N'')
INSERT [dbo].[Books] ([ID], [ISBN], [Title], [AuthorID], [Publisher], [Pages], [Year], [FormatID], [GenreID], [BorrowedDate], [BorrowerID], [Extra]) VALUES (7, N'0-2212-1900-1', N'Training to the Max', 1, N'Heinemann', 900, 2011, 1, 7, NULL, 2, NULL)
INSERT [dbo].[Books] ([ID], [ISBN], [Title], [AuthorID], [Publisher], [Pages], [Year], [FormatID], [GenreID], [BorrowedDate], [BorrowerID], [Extra]) VALUES (8, N'0-1111-2222-1', N'Training to the Max Second Edition', 1, N'Heinemann', 234, 2012, 1, 7, NULL, 3, NULL)
INSERT [dbo].[Books] ([ID], [ISBN], [Title], [AuthorID], [Publisher], [Pages], [Year], [FormatID], [GenreID], [BorrowedDate], [BorrowerID], [Extra]) VALUES (10, N'0-3444-5100-6', N'.NET Best Practices 2', 1, N'Microsoft Press', 766, 2011, 1, 2, NULL, 2, NULL)
INSERT [dbo].[Books] ([ID], [ISBN], [Title], [AuthorID], [Publisher], [Pages], [Year], [FormatID], [GenreID], [BorrowedDate], [BorrowerID], [Extra]) VALUES (11, N'0-3443-5122-1', N'.NET Best Practices 33', 1, N'Microsoft Press', 766, 2011, 1, 2, NULL, 2, NULL)
SET IDENTITY_INSERT [dbo].[Books] OFF
/****** Object:  Table [dbo].[BooksGenres]    Script Date: 04/01/2012 14:55:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BooksGenres](
	[BookID] [int] NOT NULL,
	[GenreID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BookID] ASC,
	[GenreID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[BooksGenres] ([BookID], [GenreID]) VALUES (1, 3)
INSERT [dbo].[BooksGenres] ([BookID], [GenreID]) VALUES (1, 5)
INSERT [dbo].[BooksGenres] ([BookID], [GenreID]) VALUES (3, 1)
INSERT [dbo].[BooksGenres] ([BookID], [GenreID]) VALUES (5, 5)
INSERT [dbo].[BooksGenres] ([BookID], [GenreID]) VALUES (6, 2)
INSERT [dbo].[BooksGenres] ([BookID], [GenreID]) VALUES (6, 3)
/****** Object:  ForeignKey [FK__book__format__1FCDBCEB]    Script Date: 04/01/2012 14:55:31 ******/
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK__book__format__1FCDBCEB] FOREIGN KEY([FormatID])
REFERENCES [dbo].[Formats] ([ID])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK__book__format__1FCDBCEB]
GO
/****** Object:  ForeignKey [FK__book__genre__20C1E124]    Script Date: 04/01/2012 14:55:31 ******/
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK__book__genre__20C1E124] FOREIGN KEY([GenreID])
REFERENCES [dbo].[Genres] ([ID])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK__book__genre__20C1E124]
GO
/****** Object:  ForeignKey [FK__book__owner__22AA2996]    Script Date: 04/01/2012 14:55:31 ******/
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK__book__owner__22AA2996] FOREIGN KEY([BorrowerID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK__book__owner__22AA2996]
GO
/****** Object:  ForeignKey [FK__books_gen__book___276EDEB3]    Script Date: 04/01/2012 14:55:31 ******/
ALTER TABLE [dbo].[BooksGenres]  WITH CHECK ADD  CONSTRAINT [FK__books_gen__book___276EDEB3] FOREIGN KEY([BookID])
REFERENCES [dbo].[Books] ([ID])
GO
ALTER TABLE [dbo].[BooksGenres] CHECK CONSTRAINT [FK__books_gen__book___276EDEB3]
GO
/****** Object:  ForeignKey [FK__books_gen__genre__286302EC]    Script Date: 04/01/2012 14:55:31 ******/
ALTER TABLE [dbo].[BooksGenres]  WITH CHECK ADD  CONSTRAINT [FK__books_gen__genre__286302EC] FOREIGN KEY([GenreID])
REFERENCES [dbo].[Genres] ([ID])
GO
ALTER TABLE [dbo].[BooksGenres] CHECK CONSTRAINT [FK__books_gen__genre__286302EC]
GO
/****** Object:  ForeignKey [FK_Users_Countries]    Script Date: 04/01/2012 14:55:31 ******/
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Countries] FOREIGN KEY([CountryISO])
REFERENCES [dbo].[Countries] ([ISO])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Countries]
GO
