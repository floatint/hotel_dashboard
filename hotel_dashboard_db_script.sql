USE [master]
GO
/****** Object:  Database [hotel_dashboard_db]    Script Date: 21.07.2020 16:54:21 ******/
CREATE DATABASE [hotel_dashboard_db]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'hotel_dashboard_db', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\hotel_dashboard_db.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'hotel_dashboard_db_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\hotel_dashboard_db_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [hotel_dashboard_db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [hotel_dashboard_db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [hotel_dashboard_db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [hotel_dashboard_db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [hotel_dashboard_db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [hotel_dashboard_db] SET ARITHABORT OFF 
GO
ALTER DATABASE [hotel_dashboard_db] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [hotel_dashboard_db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [hotel_dashboard_db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [hotel_dashboard_db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [hotel_dashboard_db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [hotel_dashboard_db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [hotel_dashboard_db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [hotel_dashboard_db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [hotel_dashboard_db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [hotel_dashboard_db] SET  DISABLE_BROKER 
GO
ALTER DATABASE [hotel_dashboard_db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [hotel_dashboard_db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [hotel_dashboard_db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [hotel_dashboard_db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [hotel_dashboard_db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [hotel_dashboard_db] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [hotel_dashboard_db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [hotel_dashboard_db] SET RECOVERY FULL 
GO
ALTER DATABASE [hotel_dashboard_db] SET  MULTI_USER 
GO
ALTER DATABASE [hotel_dashboard_db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [hotel_dashboard_db] SET DB_CHAINING OFF 
GO
ALTER DATABASE [hotel_dashboard_db] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [hotel_dashboard_db] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [hotel_dashboard_db] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'hotel_dashboard_db', N'ON'
GO
USE [hotel_dashboard_db]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 21.07.2020 16:54:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 21.07.2020 16:54:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[SecondName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Birthday] [datetime2](7) NOT NULL,
	[Gender] [tinyint] NOT NULL,
	[RegistrationAddress] [nvarchar](max) NULL,
	[RoomStatusId] [int] NOT NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Corps]    Script Date: 21.07.2020 16:54:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Corps](
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Corps] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Floors]    Script Date: 21.07.2020 16:54:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Floors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CorpsId] [int] NOT NULL,
 CONSTRAINT [PK_Floors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 21.07.2020 16:54:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [tinyint] NOT NULL,
	[FloorId] [int] NOT NULL,
 CONSTRAINT [PK_Rooms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomStatuses]    Script Date: 21.07.2020 16:54:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomStatuses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReserveStart] [datetime2](7) NOT NULL,
	[ReserveEnd] [datetime2](7) NOT NULL,
	[RoomId] [int] NOT NULL,
 CONSTRAINT [PK_RoomStatuses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200711150246_Init DB', N'3.1.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200711200658_Update DB struct', N'3.1.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200711211928_RoomStatus changed', N'3.1.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200711221608_Client changed', N'3.1.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200713202425_Preset DB data', N'3.1.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200713215027_Relationships changed', N'3.1.5')
SET IDENTITY_INSERT [dbo].[Clients] ON 

INSERT [dbo].[Clients] ([Id], [FirstName], [SecondName], [LastName], [Birthday], [Gender], [RegistrationAddress], [RoomStatusId]) VALUES (2, N'Иван', N'Иванов', N'Иванович', CAST(N'2020-07-20T00:00:00.0000000' AS DateTime2), 0, N'Москва', 18)
INSERT [dbo].[Clients] ([Id], [FirstName], [SecondName], [LastName], [Birthday], [Gender], [RegistrationAddress], [RoomStatusId]) VALUES (3, N'Антон', N'Сидоров', N'Павлович', CAST(N'2020-07-20T00:00:00.0000000' AS DateTime2), 0, N'Воронеж', 19)
INSERT [dbo].[Clients] ([Id], [FirstName], [SecondName], [LastName], [Birthday], [Gender], [RegistrationAddress], [RoomStatusId]) VALUES (4, N'Анна', N'Моторина', N'Олеговна', CAST(N'1998-06-24T00:00:00.0000000' AS DateTime2), 1, N'Воронеж', 19)
SET IDENTITY_INSERT [dbo].[Clients] OFF
SET IDENTITY_INSERT [dbo].[Corps] ON 

INSERT [dbo].[Corps] ([Id]) VALUES (1)
INSERT [dbo].[Corps] ([Id]) VALUES (2)
INSERT [dbo].[Corps] ([Id]) VALUES (3)
INSERT [dbo].[Corps] ([Id]) VALUES (4)
SET IDENTITY_INSERT [dbo].[Corps] OFF
SET IDENTITY_INSERT [dbo].[Floors] ON 

INSERT [dbo].[Floors] ([Id], [CorpsId]) VALUES (1, 1)
INSERT [dbo].[Floors] ([Id], [CorpsId]) VALUES (2, 1)
INSERT [dbo].[Floors] ([Id], [CorpsId]) VALUES (3, 1)
INSERT [dbo].[Floors] ([Id], [CorpsId]) VALUES (4, 1)
INSERT [dbo].[Floors] ([Id], [CorpsId]) VALUES (5, 1)
INSERT [dbo].[Floors] ([Id], [CorpsId]) VALUES (6, 1)
INSERT [dbo].[Floors] ([Id], [CorpsId]) VALUES (7, 1)
INSERT [dbo].[Floors] ([Id], [CorpsId]) VALUES (8, 1)
INSERT [dbo].[Floors] ([Id], [CorpsId]) VALUES (9, 2)
INSERT [dbo].[Floors] ([Id], [CorpsId]) VALUES (10, 2)
INSERT [dbo].[Floors] ([Id], [CorpsId]) VALUES (11, 2)
INSERT [dbo].[Floors] ([Id], [CorpsId]) VALUES (12, 2)
INSERT [dbo].[Floors] ([Id], [CorpsId]) VALUES (13, 2)
INSERT [dbo].[Floors] ([Id], [CorpsId]) VALUES (14, 2)
INSERT [dbo].[Floors] ([Id], [CorpsId]) VALUES (15, 2)
INSERT [dbo].[Floors] ([Id], [CorpsId]) VALUES (16, 2)
INSERT [dbo].[Floors] ([Id], [CorpsId]) VALUES (17, 3)
INSERT [dbo].[Floors] ([Id], [CorpsId]) VALUES (18, 3)
INSERT [dbo].[Floors] ([Id], [CorpsId]) VALUES (19, 3)
INSERT [dbo].[Floors] ([Id], [CorpsId]) VALUES (20, 3)
INSERT [dbo].[Floors] ([Id], [CorpsId]) VALUES (21, 3)
INSERT [dbo].[Floors] ([Id], [CorpsId]) VALUES (22, 3)
INSERT [dbo].[Floors] ([Id], [CorpsId]) VALUES (23, 3)
INSERT [dbo].[Floors] ([Id], [CorpsId]) VALUES (24, 3)
INSERT [dbo].[Floors] ([Id], [CorpsId]) VALUES (25, 4)
INSERT [dbo].[Floors] ([Id], [CorpsId]) VALUES (26, 4)
INSERT [dbo].[Floors] ([Id], [CorpsId]) VALUES (27, 4)
INSERT [dbo].[Floors] ([Id], [CorpsId]) VALUES (28, 4)
INSERT [dbo].[Floors] ([Id], [CorpsId]) VALUES (29, 4)
INSERT [dbo].[Floors] ([Id], [CorpsId]) VALUES (30, 4)
INSERT [dbo].[Floors] ([Id], [CorpsId]) VALUES (31, 4)
INSERT [dbo].[Floors] ([Id], [CorpsId]) VALUES (32, 4)
SET IDENTITY_INSERT [dbo].[Floors] OFF
SET IDENTITY_INSERT [dbo].[Rooms] ON 

INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (1, 1, 1)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (2, 1, 1)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (3, 1, 1)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (4, 1, 1)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (5, 2, 1)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (6, 2, 1)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (7, 2, 1)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (8, 2, 1)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (9, 4, 1)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (10, 4, 1)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (11, 1, 2)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (12, 1, 2)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (13, 1, 2)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (14, 1, 2)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (15, 2, 2)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (16, 2, 2)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (17, 2, 2)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (18, 2, 2)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (19, 4, 2)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (20, 4, 2)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (21, 1, 3)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (22, 1, 3)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (23, 1, 3)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (24, 1, 3)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (25, 2, 3)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (26, 2, 3)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (27, 2, 3)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (28, 2, 3)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (29, 4, 3)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (30, 4, 3)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (31, 1, 4)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (32, 1, 4)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (33, 1, 4)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (34, 1, 4)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (35, 2, 4)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (36, 2, 4)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (37, 2, 4)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (38, 2, 4)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (39, 4, 4)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (40, 4, 4)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (41, 1, 5)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (42, 1, 5)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (43, 1, 5)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (44, 1, 5)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (45, 2, 5)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (46, 2, 5)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (47, 2, 5)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (48, 2, 5)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (49, 4, 5)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (50, 4, 5)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (51, 1, 6)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (52, 1, 6)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (53, 1, 6)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (54, 1, 6)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (55, 2, 6)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (56, 2, 6)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (57, 2, 6)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (58, 2, 6)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (59, 4, 6)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (60, 4, 6)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (61, 1, 7)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (62, 1, 7)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (63, 1, 7)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (64, 1, 7)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (65, 2, 7)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (66, 2, 7)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (67, 2, 7)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (68, 2, 7)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (69, 4, 7)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (70, 4, 7)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (71, 1, 8)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (72, 1, 8)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (73, 1, 8)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (74, 1, 8)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (75, 2, 8)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (76, 2, 8)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (77, 2, 8)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (78, 2, 8)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (79, 4, 8)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (80, 4, 8)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (81, 1, 9)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (82, 1, 9)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (83, 1, 9)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (84, 1, 9)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (85, 2, 9)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (86, 2, 9)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (87, 2, 9)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (88, 2, 9)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (89, 4, 9)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (90, 4, 9)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (91, 1, 10)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (92, 1, 10)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (93, 1, 10)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (94, 1, 10)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (95, 2, 10)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (96, 2, 10)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (97, 2, 10)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (98, 2, 10)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (99, 4, 10)
GO
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (100, 4, 10)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (101, 1, 11)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (102, 1, 11)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (103, 1, 11)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (104, 1, 11)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (105, 2, 11)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (106, 2, 11)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (107, 2, 11)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (108, 2, 11)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (109, 4, 11)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (110, 4, 11)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (111, 1, 12)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (112, 1, 12)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (113, 1, 12)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (114, 1, 12)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (115, 2, 12)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (116, 2, 12)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (117, 2, 12)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (118, 2, 12)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (119, 4, 12)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (120, 4, 12)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (121, 1, 13)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (122, 1, 13)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (123, 1, 13)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (124, 1, 13)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (125, 2, 13)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (126, 2, 13)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (127, 2, 13)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (128, 2, 13)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (129, 4, 13)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (130, 4, 13)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (131, 1, 14)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (132, 1, 14)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (133, 1, 14)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (134, 1, 14)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (135, 2, 14)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (136, 2, 14)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (137, 2, 14)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (138, 2, 14)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (139, 4, 14)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (140, 4, 14)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (141, 1, 15)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (142, 1, 15)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (143, 1, 15)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (144, 1, 15)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (145, 2, 15)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (146, 2, 15)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (147, 2, 15)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (148, 2, 15)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (149, 4, 15)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (150, 4, 15)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (151, 1, 16)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (152, 1, 16)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (153, 1, 16)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (154, 1, 16)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (155, 2, 16)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (156, 2, 16)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (157, 2, 16)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (158, 2, 16)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (159, 4, 16)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (160, 4, 16)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (161, 1, 17)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (162, 1, 17)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (163, 1, 17)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (164, 1, 17)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (165, 2, 17)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (166, 2, 17)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (167, 2, 17)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (168, 2, 17)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (169, 4, 17)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (170, 4, 17)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (171, 1, 18)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (172, 1, 18)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (173, 1, 18)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (174, 1, 18)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (175, 2, 18)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (176, 2, 18)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (177, 2, 18)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (178, 2, 18)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (179, 4, 18)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (180, 4, 18)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (181, 1, 19)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (182, 1, 19)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (183, 1, 19)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (184, 1, 19)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (185, 2, 19)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (186, 2, 19)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (187, 2, 19)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (188, 2, 19)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (189, 4, 19)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (190, 4, 19)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (191, 1, 20)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (192, 1, 20)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (193, 1, 20)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (194, 1, 20)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (195, 2, 20)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (196, 2, 20)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (197, 2, 20)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (198, 2, 20)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (199, 4, 20)
GO
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (200, 4, 20)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (201, 1, 21)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (202, 1, 21)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (203, 1, 21)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (204, 1, 21)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (205, 2, 21)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (206, 2, 21)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (207, 2, 21)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (208, 2, 21)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (209, 4, 21)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (210, 4, 21)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (211, 1, 22)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (212, 1, 22)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (213, 1, 22)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (214, 1, 22)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (215, 2, 22)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (216, 2, 22)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (217, 2, 22)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (218, 2, 22)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (219, 4, 22)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (220, 4, 22)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (221, 1, 23)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (222, 1, 23)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (223, 1, 23)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (224, 1, 23)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (225, 2, 23)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (226, 2, 23)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (227, 2, 23)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (228, 2, 23)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (229, 4, 23)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (230, 4, 23)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (231, 1, 24)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (232, 1, 24)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (233, 1, 24)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (234, 1, 24)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (235, 2, 24)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (236, 2, 24)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (237, 2, 24)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (238, 2, 24)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (239, 4, 24)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (240, 4, 24)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (241, 1, 25)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (242, 1, 25)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (243, 1, 25)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (244, 1, 25)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (245, 2, 25)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (246, 2, 25)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (247, 2, 25)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (248, 2, 25)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (249, 4, 25)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (250, 4, 25)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (251, 1, 26)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (252, 1, 26)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (253, 1, 26)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (254, 1, 26)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (255, 2, 26)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (256, 2, 26)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (257, 2, 26)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (258, 2, 26)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (259, 4, 26)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (260, 4, 26)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (261, 1, 27)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (262, 1, 27)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (263, 1, 27)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (264, 1, 27)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (265, 2, 27)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (266, 2, 27)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (267, 2, 27)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (268, 2, 27)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (269, 4, 27)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (270, 4, 27)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (271, 1, 28)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (272, 1, 28)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (273, 1, 28)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (274, 1, 28)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (275, 2, 28)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (276, 2, 28)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (277, 2, 28)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (278, 2, 28)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (279, 4, 28)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (280, 4, 28)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (281, 1, 29)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (282, 1, 29)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (283, 1, 29)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (284, 1, 29)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (285, 2, 29)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (286, 2, 29)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (287, 2, 29)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (288, 2, 29)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (289, 4, 29)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (290, 4, 29)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (291, 1, 30)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (292, 1, 30)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (293, 1, 30)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (294, 1, 30)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (295, 2, 30)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (296, 2, 30)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (297, 2, 30)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (298, 2, 30)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (299, 4, 30)
GO
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (300, 4, 30)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (301, 1, 31)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (302, 1, 31)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (303, 1, 31)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (304, 1, 31)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (305, 2, 31)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (306, 2, 31)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (307, 2, 31)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (308, 2, 31)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (309, 4, 31)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (310, 4, 31)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (311, 1, 32)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (312, 1, 32)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (313, 1, 32)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (314, 1, 32)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (315, 2, 32)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (316, 2, 32)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (317, 2, 32)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (318, 2, 32)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (319, 4, 32)
INSERT [dbo].[Rooms] ([Id], [Type], [FloorId]) VALUES (320, 4, 32)
SET IDENTITY_INSERT [dbo].[Rooms] OFF
SET IDENTITY_INSERT [dbo].[RoomStatuses] ON 

INSERT [dbo].[RoomStatuses] ([Id], [ReserveStart], [ReserveEnd], [RoomId]) VALUES (12, CAST(N'2020-07-19T00:00:00.0000000' AS DateTime2), CAST(N'2020-07-19T00:00:00.0000000' AS DateTime2), 257)
INSERT [dbo].[RoomStatuses] ([Id], [ReserveStart], [ReserveEnd], [RoomId]) VALUES (13, CAST(N'2020-07-19T00:00:00.0000000' AS DateTime2), CAST(N'2020-07-24T00:00:00.0000000' AS DateTime2), 251)
INSERT [dbo].[RoomStatuses] ([Id], [ReserveStart], [ReserveEnd], [RoomId]) VALUES (14, CAST(N'2020-07-19T00:00:00.0000000' AS DateTime2), CAST(N'2020-08-07T00:00:00.0000000' AS DateTime2), 10)
INSERT [dbo].[RoomStatuses] ([Id], [ReserveStart], [ReserveEnd], [RoomId]) VALUES (15, CAST(N'2020-07-20T00:00:00.0000000' AS DateTime2), CAST(N'2020-07-31T00:00:00.0000000' AS DateTime2), 95)
INSERT [dbo].[RoomStatuses] ([Id], [ReserveStart], [ReserveEnd], [RoomId]) VALUES (16, CAST(N'2020-07-20T00:00:00.0000000' AS DateTime2), CAST(N'2020-07-20T00:00:00.0000000' AS DateTime2), 184)
INSERT [dbo].[RoomStatuses] ([Id], [ReserveStart], [ReserveEnd], [RoomId]) VALUES (18, CAST(N'2020-07-20T00:00:00.0000000' AS DateTime2), CAST(N'2020-07-23T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[RoomStatuses] ([Id], [ReserveStart], [ReserveEnd], [RoomId]) VALUES (19, CAST(N'2020-07-20T00:00:00.0000000' AS DateTime2), CAST(N'2020-07-25T00:00:00.0000000' AS DateTime2), 6)
SET IDENTITY_INSERT [dbo].[RoomStatuses] OFF
/****** Object:  Index [IX_Clients_RoomStatusId]    Script Date: 21.07.2020 16:54:22 ******/
CREATE NONCLUSTERED INDEX [IX_Clients_RoomStatusId] ON [dbo].[Clients]
(
	[RoomStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Floors_CorpsId]    Script Date: 21.07.2020 16:54:22 ******/
CREATE NONCLUSTERED INDEX [IX_Floors_CorpsId] ON [dbo].[Floors]
(
	[CorpsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Rooms_FloorId]    Script Date: 21.07.2020 16:54:22 ******/
CREATE NONCLUSTERED INDEX [IX_Rooms_FloorId] ON [dbo].[Rooms]
(
	[FloorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RoomStatuses_RoomId]    Script Date: 21.07.2020 16:54:22 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_RoomStatuses_RoomId] ON [dbo].[RoomStatuses]
(
	[RoomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[RoomStatuses] ADD  DEFAULT ((0)) FOR [RoomId]
GO
ALTER TABLE [dbo].[Clients]  WITH CHECK ADD  CONSTRAINT [FK_Clients_RoomStatuses_RoomStatusId] FOREIGN KEY([RoomStatusId])
REFERENCES [dbo].[RoomStatuses] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Clients] CHECK CONSTRAINT [FK_Clients_RoomStatuses_RoomStatusId]
GO
ALTER TABLE [dbo].[Floors]  WITH CHECK ADD  CONSTRAINT [FK_Floors_Corps_CorpsId] FOREIGN KEY([CorpsId])
REFERENCES [dbo].[Corps] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Floors] CHECK CONSTRAINT [FK_Floors_Corps_CorpsId]
GO
ALTER TABLE [dbo].[Rooms]  WITH CHECK ADD  CONSTRAINT [FK_Rooms_Floors_FloorId] FOREIGN KEY([FloorId])
REFERENCES [dbo].[Floors] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Rooms] CHECK CONSTRAINT [FK_Rooms_Floors_FloorId]
GO
ALTER TABLE [dbo].[RoomStatuses]  WITH CHECK ADD  CONSTRAINT [FK_RoomStatuses_Rooms_RoomId] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Rooms] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoomStatuses] CHECK CONSTRAINT [FK_RoomStatuses_Rooms_RoomId]
GO
USE [master]
GO
ALTER DATABASE [hotel_dashboard_db] SET  READ_WRITE 
GO
