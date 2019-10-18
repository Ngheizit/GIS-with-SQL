USE [master]
GO
/****** Object:  Database [NhztGDB]    Script Date: 2019/10/18 9:01:02 ******/
CREATE DATABASE [NhztGDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NhztGDB', FILENAME = N'D:\gitproj\gis2sql\gdb\NhztGDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'NhztGDB_log', FILENAME = N'D:\gitproj\gis2sql\gdb\NhztGDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [NhztGDB] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NhztGDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NhztGDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NhztGDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NhztGDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NhztGDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NhztGDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [NhztGDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NhztGDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NhztGDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NhztGDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NhztGDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NhztGDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NhztGDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NhztGDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NhztGDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NhztGDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [NhztGDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NhztGDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NhztGDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NhztGDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NhztGDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NhztGDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NhztGDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NhztGDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [NhztGDB] SET  MULTI_USER 
GO
ALTER DATABASE [NhztGDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NhztGDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NhztGDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NhztGDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [NhztGDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'NhztGDB', N'ON'
GO
ALTER DATABASE [NhztGDB] SET QUERY_STORE = OFF
GO
USE [NhztGDB]
GO
/****** Object:  Schema [S-T]    Script Date: 2019/10/18 9:01:02 ******/
CREATE SCHEMA [S-T]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 2019/10/18 9:01:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[Cno] [char](4) NOT NULL,
	[Cname] [char](40) NULL,
	[Cpno] [char](4) NULL,
	[Ccredit] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[Cno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SC]    Script Date: 2019/10/18 9:01:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SC](
	[Sno] [char](9) NOT NULL,
	[Cno] [char](4) NOT NULL,
	[Grade] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[Sno] ASC,
	[Cno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 2019/10/18 9:01:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[Sno] [char](9) NOT NULL,
	[Sname] [char](20) NULL,
	[Ssex] [char](2) NULL,
	[Sage] [smallint] NULL,
	[Sdept] [char](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Sno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Course] ([Cno], [Cname], [Cpno], [Ccredit]) VALUES (N'1   ', N'数据库                                  ', N'5   ', 4)
INSERT [dbo].[Course] ([Cno], [Cname], [Cpno], [Ccredit]) VALUES (N'2   ', N'数学                                    ', NULL, 2)
INSERT [dbo].[Course] ([Cno], [Cname], [Cpno], [Ccredit]) VALUES (N'3   ', N'信息系统                                ', N'1   ', 4)
INSERT [dbo].[Course] ([Cno], [Cname], [Cpno], [Ccredit]) VALUES (N'4   ', N'操作系统                                ', N'6   ', 3)
INSERT [dbo].[Course] ([Cno], [Cname], [Cpno], [Ccredit]) VALUES (N'5   ', N'数据结构                                ', N'7   ', 4)
INSERT [dbo].[Course] ([Cno], [Cname], [Cpno], [Ccredit]) VALUES (N'6   ', N'数据处理                                ', NULL, 2)
INSERT [dbo].[Course] ([Cno], [Cname], [Cpno], [Ccredit]) VALUES (N'7   ', N'PASCAL语言                              ', N'6   ', 4)
INSERT [dbo].[SC] ([Sno], [Cno], [Grade]) VALUES (N'201215121', N'1   ', 92)
INSERT [dbo].[SC] ([Sno], [Cno], [Grade]) VALUES (N'201215121', N'2   ', 85)
INSERT [dbo].[SC] ([Sno], [Cno], [Grade]) VALUES (N'201215121', N'3   ', 88)
INSERT [dbo].[SC] ([Sno], [Cno], [Grade]) VALUES (N'201215122', N'2   ', 90)
INSERT [dbo].[SC] ([Sno], [Cno], [Grade]) VALUES (N'201215122', N'3   ', 80)
INSERT [dbo].[Student] ([Sno], [Sname], [Ssex], [Sage], [Sdept]) VALUES (N'201215121', N'李勇                ', N'男', 21, N'CS                  ')
INSERT [dbo].[Student] ([Sno], [Sname], [Ssex], [Sage], [Sdept]) VALUES (N'201215122', N'刘晨                ', N'女', 20, N'CS                  ')
INSERT [dbo].[Student] ([Sno], [Sname], [Ssex], [Sage], [Sdept]) VALUES (N'201215123', N'王敏                ', N'女', 19, N'MA                  ')
INSERT [dbo].[Student] ([Sno], [Sname], [Ssex], [Sage], [Sdept]) VALUES (N'201215125', N'张立                ', N'男', 20, N'IS                  ')
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Student__52723D2703BD32D1]    Script Date: 2019/10/18 9:01:03 ******/
ALTER TABLE [dbo].[Student] ADD UNIQUE NONCLUSTERED 
(
	[Sname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD FOREIGN KEY([Cpno])
REFERENCES [dbo].[Course] ([Cno])
GO
ALTER TABLE [dbo].[SC]  WITH CHECK ADD FOREIGN KEY([Cno])
REFERENCES [dbo].[Course] ([Cno])
GO
ALTER TABLE [dbo].[SC]  WITH CHECK ADD FOREIGN KEY([Sno])
REFERENCES [dbo].[Student] ([Sno])
GO
USE [master]
GO
ALTER DATABASE [NhztGDB] SET  READ_WRITE 
GO
