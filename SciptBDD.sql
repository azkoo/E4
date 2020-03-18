USE [master]
GO
<<<<<<< HEAD
/****** Object:  Database [MegaCastingBD]    Script Date: 08/12/2019 17:09:52 ******/
=======
/****** Object:  Database [MegaCastingBD]    Script Date: 07/12/2019 18:05:41 ******/
>>>>>>> parent of 6949421... Merge branch 'Matheo'
CREATE DATABASE [MegaCastingBD]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MegaCastingBD', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\MegaCastingBD.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MegaCastingBD_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\MegaCastingBD_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [MegaCastingBD] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MegaCastingBD].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MegaCastingBD] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MegaCastingBD] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MegaCastingBD] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MegaCastingBD] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MegaCastingBD] SET ARITHABORT OFF 
GO
ALTER DATABASE [MegaCastingBD] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MegaCastingBD] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MegaCastingBD] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MegaCastingBD] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MegaCastingBD] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MegaCastingBD] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MegaCastingBD] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MegaCastingBD] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MegaCastingBD] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MegaCastingBD] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MegaCastingBD] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MegaCastingBD] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MegaCastingBD] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MegaCastingBD] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MegaCastingBD] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MegaCastingBD] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MegaCastingBD] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MegaCastingBD] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MegaCastingBD] SET  MULTI_USER 
GO
ALTER DATABASE [MegaCastingBD] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MegaCastingBD] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MegaCastingBD] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MegaCastingBD] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MegaCastingBD] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MegaCastingBD] SET QUERY_STORE = OFF
GO
USE [MegaCastingBD]
GO
<<<<<<< HEAD
/****** Object:  Table [dbo].[CastingPack]    Script Date: 08/12/2019 17:09:52 ******/
=======
/****** Object:  User [MegaCasting]    Script Date: 07/12/2019 18:05:41 ******/
CREATE USER [MegaCasting] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[db_owner]
GO
ALTER ROLE [db_owner] ADD MEMBER [MegaCasting]
GO
/****** Object:  Table [dbo].[CastingPack]    Script Date: 07/12/2019 18:05:41 ******/
>>>>>>> parent of 6949421... Merge branch 'Matheo'
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CastingPack](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](500) NOT NULL,
	[Size] [int] NULL,
 CONSTRAINT [PK_CastingPack] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
<<<<<<< HEAD
/****** Object:  Table [dbo].[ContractType]    Script Date: 08/12/2019 17:09:52 ******/
=======
/****** Object:  Table [dbo].[ContractType]    Script Date: 07/12/2019 18:05:41 ******/
>>>>>>> parent of 6949421... Merge branch 'Matheo'
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContractType](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](500) NOT NULL,
 CONSTRAINT [PK_ContractType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
<<<<<<< HEAD
/****** Object:  Table [dbo].[Job]    Script Date: 08/12/2019 17:09:52 ******/
=======
/****** Object:  Table [dbo].[Job]    Script Date: 07/12/2019 18:05:41 ******/
>>>>>>> parent of 6949421... Merge branch 'Matheo'
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Job](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](500) NOT NULL,
	[IdJobType] [bigint] NOT NULL,
 CONSTRAINT [PK_Job] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
<<<<<<< HEAD
/****** Object:  Table [dbo].[JobType]    Script Date: 08/12/2019 17:09:52 ******/
=======
/****** Object:  Table [dbo].[JobType]    Script Date: 07/12/2019 18:05:41 ******/
>>>>>>> parent of 6949421... Merge branch 'Matheo'
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobType](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](500) NOT NULL,
 CONSTRAINT [PK_JobType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
<<<<<<< HEAD
/****** Object:  Table [dbo].[Offer]    Script Date: 08/12/2019 17:09:52 ******/
=======
/****** Object:  Table [dbo].[Offer]    Script Date: 07/12/2019 18:05:41 ******/
>>>>>>> parent of 6949421... Merge branch 'Matheo'
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Offer](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](500) NOT NULL,
	[Reference] [varchar](500) NOT NULL,
	[Description] [varchar](2000) NOT NULL,
	[Picture] [image] NULL,
	[PostNumber] [int] NULL,
	[PublicationStart] [datetime] NOT NULL,
	[ContractStart] [datetime] NULL,
	[Period] [varchar](500) NULL,
	[Inspect] [bit] NOT NULL,
	[IdProducer] [bigint] NOT NULL,
	[IdContractType] [bigint] NOT NULL,
	[IdJob] [bigint] NOT NULL,
 CONSTRAINT [PK_Offer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
<<<<<<< HEAD
/****** Object:  Table [dbo].[Producer]    Script Date: 08/12/2019 17:09:52 ******/
=======
/****** Object:  Table [dbo].[Producer]    Script Date: 07/12/2019 18:05:41 ******/
>>>>>>> parent of 6949421... Merge branch 'Matheo'
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producer](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](500) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Website] [varchar](500) NULL,
	[Phone] [varchar](500) NULL,
	[Fax] [varchar](500) NOT NULL,
	[City] [varchar](500) NULL,
	[Address1] [varchar](500) NULL,
<<<<<<< HEAD
	[Address2] [varchar](500) NULL,
	[Email] [varchar](500) NOT NULL,
	[CastingCounter] [int] NULL,
=======
	[Address2] [varchar](500) NOT NULL,
	[Email] [varchar](500) NULL,
	[CastingCounter] [int] NOT NULL,
>>>>>>> parent of 6949421... Merge branch 'Matheo'
	[IdCastingPack] [bigint] NOT NULL,
 CONSTRAINT [PK_Producer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Job]  WITH CHECK ADD  CONSTRAINT [FK_Job_JobType] FOREIGN KEY([IdJobType])
REFERENCES [dbo].[JobType] ([Id])
GO
ALTER TABLE [dbo].[Job] CHECK CONSTRAINT [FK_Job_JobType]
GO
ALTER TABLE [dbo].[Offer]  WITH CHECK ADD  CONSTRAINT [FK_Offer_ContractType] FOREIGN KEY([IdContractType])
REFERENCES [dbo].[ContractType] ([Id])
GO
ALTER TABLE [dbo].[Offer] CHECK CONSTRAINT [FK_Offer_ContractType]
GO
ALTER TABLE [dbo].[Offer]  WITH CHECK ADD  CONSTRAINT [FK_Offer_Job] FOREIGN KEY([IdJob])
REFERENCES [dbo].[Job] ([Id])
GO
ALTER TABLE [dbo].[Offer] CHECK CONSTRAINT [FK_Offer_Job]
GO
ALTER TABLE [dbo].[Offer]  WITH CHECK ADD  CONSTRAINT [FK_Offer_Producer] FOREIGN KEY([IdProducer])
REFERENCES [dbo].[Producer] ([Id])
GO
ALTER TABLE [dbo].[Offer] CHECK CONSTRAINT [FK_Offer_Producer]
GO
ALTER TABLE [dbo].[Producer]  WITH CHECK ADD  CONSTRAINT [FK_Producer_CastingPack] FOREIGN KEY([IdCastingPack])
REFERENCES [dbo].[CastingPack] ([Id])
GO
ALTER TABLE [dbo].[Producer] CHECK CONSTRAINT [FK_Producer_CastingPack]
GO
USE [master]
GO
ALTER DATABASE [MegaCastingBD] SET  READ_WRITE 
GO
