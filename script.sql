USE [master]
GO
/****** Object:  Database [Dictionary_Development_System]  ******/
CREATE DATABASE [Dictionary_Development_System]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Dictionary_Development_System', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MURATPC\MSSQL\DATA\Dictionary_Development_System.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Dictionary_Development_System_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MURATPC\MSSQL\DATA\Dictionary_Development_System_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Dictionary_Development_System] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Dictionary_Development_System].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Dictionary_Development_System] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Dictionary_Development_System] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Dictionary_Development_System] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Dictionary_Development_System] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Dictionary_Development_System] SET ARITHABORT OFF 
GO
ALTER DATABASE [Dictionary_Development_System] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Dictionary_Development_System] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Dictionary_Development_System] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Dictionary_Development_System] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Dictionary_Development_System] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Dictionary_Development_System] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Dictionary_Development_System] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Dictionary_Development_System] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Dictionary_Development_System] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Dictionary_Development_System] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Dictionary_Development_System] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Dictionary_Development_System] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Dictionary_Development_System] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Dictionary_Development_System] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Dictionary_Development_System] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Dictionary_Development_System] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Dictionary_Development_System] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Dictionary_Development_System] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Dictionary_Development_System] SET  MULTI_USER 
GO
ALTER DATABASE [Dictionary_Development_System] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Dictionary_Development_System] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Dictionary_Development_System] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Dictionary_Development_System] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Dictionary_Development_System] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Dictionary_Development_System]
GO
/****** Object:  Table [dbo].[Dictionary]   ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dictionary](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Word] [nvarchar](50) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[DeveloperId] [int] NOT NULL,
	[InterestId] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[UserID] [int] NOT NULL,
 CONSTRAINT [PK_Dictionary] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Interest]  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Interest](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Interest] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TempUser]  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TempUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_TempUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TempWord]  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TempWord](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Word] [nvarchar](50) NOT NULL,
	[Status] [int] NOT NULL,
	[InterestId] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[AcceptanceVote] [int] NOT NULL,
	[RejectionVote] [int] NOT NULL,
	[DeveloperId] [int] NULL,
	[Content] [varchar](max) NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_TempWord] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Role] [int] NOT NULL,
	[InterestId] [int] NOT NULL,
	[CreatedDaate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Votes]   ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Votes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DeveloperId] [int] NOT NULL,
	[WordId] [int] NOT NULL,
	[Value] [bit] NOT NULL,
 CONSTRAINT [PK_InVoting] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Dictionary]  WITH CHECK ADD  CONSTRAINT [FK_Dictionary_Interest] FOREIGN KEY([InterestId])
REFERENCES [dbo].[Interest] ([Id])
GO
ALTER TABLE [dbo].[Dictionary] CHECK CONSTRAINT [FK_Dictionary_Interest]
GO
ALTER TABLE [dbo].[Dictionary]  WITH CHECK ADD  CONSTRAINT [FK_Dictionary_User] FOREIGN KEY([DeveloperId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Dictionary] CHECK CONSTRAINT [FK_Dictionary_User]
GO
ALTER TABLE [dbo].[TempWord]  WITH CHECK ADD  CONSTRAINT [FK_TempWord_Interest] FOREIGN KEY([InterestId])
REFERENCES [dbo].[Interest] ([Id])
GO
ALTER TABLE [dbo].[TempWord] CHECK CONSTRAINT [FK_TempWord_Interest]
GO
ALTER TABLE [dbo].[TempWord]  WITH CHECK ADD  CONSTRAINT [FK_TempWord_User] FOREIGN KEY([DeveloperId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[TempWord] CHECK CONSTRAINT [FK_TempWord_User]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Interest] FOREIGN KEY([InterestId])
REFERENCES [dbo].[Interest] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Interest]
GO
USE [master]
GO
ALTER DATABASE [Dictionary_Development_System] SET  READ_WRITE 
GO
