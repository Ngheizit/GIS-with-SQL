USE [master]
GO
/****** Object:  Database [ArcGISOnlineDatas]    Script Date: 2019/10/18 21:56:29 ******/
CREATE DATABASE [ArcGISOnlineDatas]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ArcGISOnlineDatas', FILENAME = N'D:\gitproj\gis2sql\gdb\ArcGISOnlineDatas.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ArcGISOnlineDatas_log', FILENAME = N'D:\gitproj\gis2sql\gdb\ArcGISOnlineDatas_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ArcGISOnlineDatas] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ArcGISOnlineDatas].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ArcGISOnlineDatas] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ArcGISOnlineDatas] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ArcGISOnlineDatas] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ArcGISOnlineDatas] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ArcGISOnlineDatas] SET ARITHABORT OFF 
GO
ALTER DATABASE [ArcGISOnlineDatas] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ArcGISOnlineDatas] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ArcGISOnlineDatas] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ArcGISOnlineDatas] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ArcGISOnlineDatas] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ArcGISOnlineDatas] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ArcGISOnlineDatas] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ArcGISOnlineDatas] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ArcGISOnlineDatas] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ArcGISOnlineDatas] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ArcGISOnlineDatas] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ArcGISOnlineDatas] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ArcGISOnlineDatas] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ArcGISOnlineDatas] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ArcGISOnlineDatas] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ArcGISOnlineDatas] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ArcGISOnlineDatas] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ArcGISOnlineDatas] SET RECOVERY FULL 
GO
ALTER DATABASE [ArcGISOnlineDatas] SET  MULTI_USER 
GO
ALTER DATABASE [ArcGISOnlineDatas] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ArcGISOnlineDatas] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ArcGISOnlineDatas] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ArcGISOnlineDatas] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ArcGISOnlineDatas] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ArcGISOnlineDatas', N'ON'
GO
ALTER DATABASE [ArcGISOnlineDatas] SET QUERY_STORE = OFF
GO
USE [ArcGISOnlineDatas]
GO
/****** Object:  Table [dbo].[Content]    Script Date: 2019/10/18 21:56:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Content](
	[Object-ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [text] NOT NULL,
	[Tags] [text] NULL,
	[Id] [char](32) NOT NULL,
	[Url] [text] NULL,
	[Type] [varchar](50) NOT NULL,
	[Time] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Folder]    Script Date: 2019/10/18 21:56:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Folder](
	[Name] [ntext] NULL,
	[Url] [ntext] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Content] ON 

INSERT [dbo].[Content] ([Object-ID], [Title], [Tags], [Id], [Url], [Type], [Time]) VALUES (1, N'中国主要河流', N'中国,河流,三级,线状要素', N'e79cc00732734d8bbbdd53c87087a858', N'https://services9.arcgis.com/8vu5jgpRPi7NCKmE/arcgis/rest/services/RIVER_3J/FeatureServer/0', N'Feature Layer', CAST(N'2019-10-11T18:29:07.000' AS DateTime))
INSERT [dbo].[Content] ([Object-ID], [Title], [Tags], [Id], [Url], [Type], [Time]) VALUES (2, N'中国主要湖泊和水库', N'中国,湖泊,水库,面状要素', N'a89b1f5462fa4efbba030e1ef182b2bb', N'https://services9.arcgis.com/8vu5jgpRPi7NCKmE/arcgis/rest/services/LAKE_L1R/FeatureServer/0', N'Feature Layer', CAST(N'2019-10-11T18:27:59.000' AS DateTime))
INSERT [dbo].[Content] ([Object-ID], [Title], [Tags], [Id], [Url], [Type], [Time]) VALUES (3, N'中国主要铁路', N'中国,铁路,线状要素', N'71c922e8f1fa47c0ac32536544e2eb9a', N'https://services9.arcgis.com/8vu5jgpRPi7NCKmE/arcgis/rest/services/TRAIN/FeatureServer/0', N'Feature Layer', CAST(N'2019-10-11T18:30:00.000' AS DateTime))
INSERT [dbo].[Content] ([Object-ID], [Title], [Tags], [Id], [Url], [Type], [Time]) VALUES (4, N'中国省级行政单元', N'中国,省级,面状要素,行政单元', N'bfd082765c7c4fc4a752649c915a4b16', N'https://services9.arcgis.com/8vu5jgpRPi7NCKmE/arcgis/rest/services/BOUA_PJ/FeatureServer/0', N'Feature Layer', CAST(N'2019-10-11T17:55:17.000' AS DateTime))
INSERT [dbo].[Content] ([Object-ID], [Title], [Tags], [Id], [Url], [Type], [Time]) VALUES (5, N'中国省级行政界线', N'中国,行政界线,省级,线状要素', N'b4966bbc506543baa8a8e0919ac62485', N'https://services9.arcgis.com/8vu5jgpRPi7NCKmE/arcgis/rest/services/BOUL_PJ/FeatureServer/0', N'Feature Layer', CAST(N'2019-10-11T18:10:07.000' AS DateTime))
INSERT [dbo].[Content] ([Object-ID], [Title], [Tags], [Id], [Url], [Type], [Time]) VALUES (8, N'中国省级行政中心', N'中国,行政中心,省级,点状要素', N'f393f6802a244c78b8abb5e112e0a07a', N'https://services9.arcgis.com/8vu5jgpRPi7NCKmE/arcgis/rest/services/BOUP_PJ/FeatureServer/0', N'Feature Layer', CAST(N'2019-10-11T18:21:35.000' AS DateTime))
INSERT [dbo].[Content] ([Object-ID], [Title], [Tags], [Id], [Url], [Type], [Time]) VALUES (9, N'中国主要湖泊和水库', N'中国,湖泊,水库,面状要素', N'89491aecee0344cc89d30e2ffb06c526', NULL, N'Shapefile', CAST(N'2019-10-11T18:27:54.000' AS DateTime))
INSERT [dbo].[Content] ([Object-ID], [Title], [Tags], [Id], [Url], [Type], [Time]) VALUES (10, N'中国省级行政单元', N'中国,省级,行政单元,面状要素', N'9122a291ccd94203b2d35cc958f503a8', NULL, N'Shapefile', CAST(N'2019-10-11T17:55:11.000' AS DateTime))
INSERT [dbo].[Content] ([Object-ID], [Title], [Tags], [Id], [Url], [Type], [Time]) VALUES (11, N'中国主要河流', N'中国,河流,三级,线状要素', N'5730dab051a54f709f1bf6d73119917e', NULL, N'Shapefile', CAST(N'2019-10-11T18:29:03.000' AS DateTime))
INSERT [dbo].[Content] ([Object-ID], [Title], [Tags], [Id], [Url], [Type], [Time]) VALUES (12, N'中国省级行政界线', N'中国,行政界线,省级,线状要素', N'a5449f4eb0604acd9d77686205280648', NULL, N'Shapefile', CAST(N'2019-10-11T18:10:01.000' AS DateTime))
INSERT [dbo].[Content] ([Object-ID], [Title], [Tags], [Id], [Url], [Type], [Time]) VALUES (13, N'中国主要铁路', N'中国,铁路,线状要素', N'5ed391596a5d4454bbe27f4485d2ebe1', NULL, N'Shapefile', CAST(N'2019-10-11T18:29:55.000' AS DateTime))
INSERT [dbo].[Content] ([Object-ID], [Title], [Tags], [Id], [Url], [Type], [Time]) VALUES (14, N'中国省级行政中心', N'中国,行政中心,省级,点状要素', N'af89a3e736f6467f838953486d74de08', NULL, N'Shapefile', CAST(N'2019-10-11T18:21:29.000' AS DateTime))
INSERT [dbo].[Content] ([Object-ID], [Title], [Tags], [Id], [Url], [Type], [Time]) VALUES (15, N'讲咩嘢啊', N'留言点,倾偈,点状要素', N'802059dbab224e6eac801b69404bfa31', NULL, N'Service Definition', CAST(N'2019-10-12T18:54:34.000' AS DateTime))
INSERT [dbo].[Content] ([Object-ID], [Title], [Tags], [Id], [Url], [Type], [Time]) VALUES (18, N'讲咩嘢啊', N'留言点,倾偈,点状要素', N'3b1cdf189a8e4353a11b75f85d6fd274', N'https://services9.arcgis.com/8vu5jgpRPi7NCKmE/arcgis/rest/services/倾偈_WFL1/FeatureServer/0', N'Feature Layer', CAST(N'2019-10-12T18:54:37.000' AS DateTime))
INSERT [dbo].[Content] ([Object-ID], [Title], [Tags], [Id], [Url], [Type], [Time]) VALUES (19, N'倾偈', N'倾偈,留言,地图', N'a09189d13e77459dbbe57383e250e375', NULL, N'Web Map', CAST(N'2019-10-12T18:55:03.000' AS DateTime))
INSERT [dbo].[Content] ([Object-ID], [Title], [Tags], [Id], [Url], [Type], [Time]) VALUES (20, N'纬线与东西半球分界线', N'球面,行星环,线状要素', N'39bdaa0217e948b1bacc971db277afe3', NULL, N'Service Definition', CAST(N'2019-10-17T21:32:31.000' AS DateTime))
INSERT [dbo].[Content] ([Object-ID], [Title], [Tags], [Id], [Url], [Type], [Time]) VALUES (23, N'纬线与东西半球分界线', N'球面,行星环,线状要素', N'37d394774cec439ca7b0e12eac31a806', N'https://services9.arcgis.com/8vu5jgpRPi7NCKmE/arcgis/rest/services/地球环_WFL1/FeatureServer/0', N'Feature Layer', CAST(N'2019-10-17T21:32:35.000' AS DateTime))
INSERT [dbo].[Content] ([Object-ID], [Title], [Tags], [Id], [Url], [Type], [Time]) VALUES (24, N'地球环', N'球面,行星环', N'81d1016c04ca4513b09995304a2731c4', NULL, N'Web Scene', CAST(N'2019-10-17T21:33:11.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Content] OFF
INSERT [dbo].[Folder] ([Name], [Url]) VALUES (N'ChinaBaseData', N'e79cc00732734d8bbbdd53c87087a858')
INSERT [dbo].[Folder] ([Name], [Url]) VALUES (N'ChinaBaseData', N'a89b1f5462fa4efbba030e1ef182b2bb')
INSERT [dbo].[Folder] ([Name], [Url]) VALUES (N'ChinaBaseData', N'71c922e8f1fa47c0ac32536544e2eb9a')
INSERT [dbo].[Folder] ([Name], [Url]) VALUES (N'ChinaBaseData', N'bfd082765c7c4fc4a752649c915a4b16')
INSERT [dbo].[Folder] ([Name], [Url]) VALUES (N'ChinaBaseData', N'b4966bbc506543baa8a8e0919ac62485')
INSERT [dbo].[Folder] ([Name], [Url]) VALUES (N'ChinaBaseData', N'f393f6802a244c78b8abb5e112e0a07a')
INSERT [dbo].[Folder] ([Name], [Url]) VALUES (N'ChinaBaseData', N'89491aecee0344cc89d30e2ffb06c526')
INSERT [dbo].[Folder] ([Name], [Url]) VALUES (N'ChinaBaseData', N'9122a291ccd94203b2d35cc958f503a8')
INSERT [dbo].[Folder] ([Name], [Url]) VALUES (N'ChinaBaseData', N'5730dab051a54f709f1bf6d73119917e')
INSERT [dbo].[Folder] ([Name], [Url]) VALUES (N'ChinaBaseData', N'a5449f4eb0604acd9d77686205280648')
INSERT [dbo].[Folder] ([Name], [Url]) VALUES (N'ChinaBaseData', N'5ed391596a5d4454bbe27f4485d2ebe1')
INSERT [dbo].[Folder] ([Name], [Url]) VALUES (N'ChinaBaseData', N'af89a3e736f6467f838953486d74de08')
INSERT [dbo].[Folder] ([Name], [Url]) VALUES (N'WebView', N'802059dbab224e6eac801b69404bfa31')
INSERT [dbo].[Folder] ([Name], [Url]) VALUES (N'WebView', N'3b1cdf189a8e4353a11b75f85d6fd274')
INSERT [dbo].[Folder] ([Name], [Url]) VALUES (N'WebView', N'a09189d13e77459dbbe57383e250e375')
INSERT [dbo].[Folder] ([Name], [Url]) VALUES (N'WebView', N'39bdaa0217e948b1bacc971db277afe3')
INSERT [dbo].[Folder] ([Name], [Url]) VALUES (N'WebView', N'37d394774cec439ca7b0e12eac31a806')
INSERT [dbo].[Folder] ([Name], [Url]) VALUES (N'WebView', N'81d1016c04ca4513b09995304a2731c4')
USE [master]
GO
ALTER DATABASE [ArcGISOnlineDatas] SET  READ_WRITE 
GO
