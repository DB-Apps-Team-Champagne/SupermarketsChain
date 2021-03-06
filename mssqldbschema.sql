USE [master]
GO
/****** Object:  Database [SuperMarketChain]    Script Date: 26.7.2015 г. 20:48:38 ч. ******/
CREATE DATABASE [SuperMarketChain]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SuperMarketChain', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\SuperMarketChain.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SuperMarketChain_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\SuperMarketChain_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SuperMarketChain] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SuperMarketChain].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SuperMarketChain] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SuperMarketChain] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SuperMarketChain] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SuperMarketChain] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SuperMarketChain] SET ARITHABORT OFF 
GO
ALTER DATABASE [SuperMarketChain] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [SuperMarketChain] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SuperMarketChain] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SuperMarketChain] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SuperMarketChain] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SuperMarketChain] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SuperMarketChain] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SuperMarketChain] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SuperMarketChain] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SuperMarketChain] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SuperMarketChain] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SuperMarketChain] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SuperMarketChain] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SuperMarketChain] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SuperMarketChain] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SuperMarketChain] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [SuperMarketChain] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SuperMarketChain] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SuperMarketChain] SET  MULTI_USER 
GO
ALTER DATABASE [SuperMarketChain] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SuperMarketChain] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SuperMarketChain] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SuperMarketChain] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [SuperMarketChain] SET DELAYED_DURABILITY = DISABLED 
GO
USE [SuperMarketChain]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 26.7.2015 г. 20:48:38 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Measures]    Script Date: 26.7.2015 г. 20:48:38 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Measures](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MeasureName] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_dbo.Measures] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products]    Script Date: 26.7.2015 г. 20:48:38 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](50) NULL,
	[VendorId] [int] NOT NULL,
	[MeasureID] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_dbo.Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SaleReports]    Script Date: 26.7.2015 г. 20:48:38 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SaleReports](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [float] NOT NULL,
	[SaleTime] [datetime] NOT NULL,
	[VendorId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.SaleReports] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Vendors]    Script Date: 26.7.2015 г. 20:48:38 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vendors](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VendorName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_dbo.Vendors] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Index [IX_MeasureID]    Script Date: 26.7.2015 г. 20:48:38 ч. ******/
CREATE NONCLUSTERED INDEX [IX_MeasureID] ON [dbo].[Products]
(
	[MeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_VendorId]    Script Date: 26.7.2015 г. 20:48:38 ч. ******/
CREATE NONCLUSTERED INDEX [IX_VendorId] ON [dbo].[Products]
(
	[VendorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductId]    Script Date: 26.7.2015 г. 20:48:38 ч. ******/
CREATE NONCLUSTERED INDEX [IX_ProductId] ON [dbo].[SaleReports]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_VendorId]    Script Date: 26.7.2015 г. 20:48:38 ч. ******/
CREATE NONCLUSTERED INDEX [IX_VendorId] ON [dbo].[SaleReports]
(
	[VendorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Products_dbo.Measures_MeasureID] FOREIGN KEY([MeasureID])
REFERENCES [dbo].[Measures] ([ID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_dbo.Products_dbo.Measures_MeasureID]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Products_dbo.Vendors_VendorId] FOREIGN KEY([VendorId])
REFERENCES [dbo].[Vendors] ([ID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_dbo.Products_dbo.Vendors_VendorId]
GO
ALTER TABLE [dbo].[SaleReports]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SaleReports_dbo.Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[SaleReports] CHECK CONSTRAINT [FK_dbo.SaleReports_dbo.Products_ProductId]
GO
ALTER TABLE [dbo].[SaleReports]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SaleReports_dbo.Vendors_VendorId] FOREIGN KEY([VendorId])
REFERENCES [dbo].[Vendors] ([ID])
GO
ALTER TABLE [dbo].[SaleReports] CHECK CONSTRAINT [FK_dbo.SaleReports_dbo.Vendors_VendorId]
GO
USE [master]
GO
ALTER DATABASE [SuperMarketChain] SET  READ_WRITE 
GO
