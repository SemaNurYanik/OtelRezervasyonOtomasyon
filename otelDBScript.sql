USE [master]
GO
/****** Object:  Database [OtelDB]    Script Date: 4.11.2019 23:51:38 ******/
--CREATE DATABASE [OtelDB]
-- CONTAINMENT = NONE
-- ON  PRIMARY 
--( NAME = N'OtelDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\OtelDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
-- LOG ON 
--( NAME = N'OtelDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\OtelDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [OtelDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OtelDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OtelDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OtelDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OtelDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OtelDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OtelDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [OtelDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OtelDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OtelDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OtelDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OtelDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OtelDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OtelDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OtelDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OtelDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OtelDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [OtelDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OtelDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OtelDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OtelDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OtelDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OtelDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OtelDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OtelDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [OtelDB] SET  MULTI_USER 
GO
ALTER DATABASE [OtelDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OtelDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OtelDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OtelDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [OtelDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'OtelDB', N'ON'
GO
ALTER DATABASE [OtelDB] SET QUERY_STORE = OFF
GO
USE [OtelDB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [OtelDB]
GO
/****** Object:  Table [dbo].[Musteri]    Script Date: 4.11.2019 23:51:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Musteri](
	[MusteriID] [int] IDENTITY(1,1) NOT NULL,
	[RezervasyonID] [int] NOT NULL,
	[Ad] [nvarchar](max) NULL,
	[Soyad] [nvarchar](max) NULL,
	[TCKN] [nvarchar](max) NULL,
	[Telefon] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[OdaID] [int] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Musteri] PRIMARY KEY CLUSTERED 
(
	[MusteriID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MusteriRezervasyon]    Script Date: 4.11.2019 23:51:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MusteriRezervasyon](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RezervasyonID] [int] NULL,
	[MusteriID] [int] NULL,
	[OdaID] [int] NULL,
 CONSTRAINT [PK_MusteriRezervasyon] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Oda]    Script Date: 4.11.2019 23:51:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Oda](
	[OdaID] [int] IDENTITY(1,1) NOT NULL,
	[RezervasyonID] [int] NULL,
	[KisiSayisi] [int] NULL,
	[Fiyat] [money] NULL,
	[Durum] [bit] NULL,
	[HaftasonuSayisi] [int] NULL,
	[Haftasonu] [int] NULL,
	[MinKisi] [int] NULL,
	[MaxKisi] [int] NULL,
 CONSTRAINT [PK_Oda] PRIMARY KEY CLUSTERED 
(
	[OdaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rezervasyon]    Script Date: 4.11.2019 23:51:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rezervasyon](
	[RezervasyonID] [int] IDENTITY(1,1) NOT NULL,
	[UyeID] [int] NULL,
	[GirisTarihi] [datetime] NULL,
	[BitisTarihi] [datetime] NULL,
	[ToplamKisiSayisi] [int] NULL,
	[RezervasyonTipID] [int] NULL,
	[ToplamFiyat] [money] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Rezervasyon] PRIMARY KEY CLUSTERED 
(
	[RezervasyonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RezervasyonTip]    Script Date: 4.11.2019 23:51:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RezervasyonTip](
	[RezervasyonTipID] [int] IDENTITY(1,1) NOT NULL,
	[Ad] [nvarchar](max) NULL,
	[Aciklama] [nvarchar](max) NULL,
 CONSTRAINT [PK_RezervasyonTip] PRIMARY KEY CLUSTERED 
(
	[RezervasyonTipID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Uye]    Script Date: 4.11.2019 23:51:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Uye](
	[UyeID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NULL,
	[Sifre] [nvarchar](max) NULL,
	[IsAdmin] [bit] NULL,
 CONSTRAINT [PK_Uye] PRIMARY KEY CLUSTERED 
(
	[UyeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Musteri] ON 

INSERT [dbo].[Musteri] ([MusteriID], [RezervasyonID], [Ad], [Soyad], [TCKN], [Telefon], [Email], [OdaID], [IsActive]) VALUES (1, 1, N'Esra', N'Yavuz', N'12345678901', N'12345687', N'esryvz@yandex.com', 1, 1)
INSERT [dbo].[Musteri] ([MusteriID], [RezervasyonID], [Ad], [Soyad], [TCKN], [Telefon], [Email], [OdaID], [IsActive]) VALUES (2, 2, N'KişiBir', N'Test', N'12345678902', N'123', N'test1', 2, 1)
INSERT [dbo].[Musteri] ([MusteriID], [RezervasyonID], [Ad], [Soyad], [TCKN], [Telefon], [Email], [OdaID], [IsActive]) VALUES (3, 2, N'Kişiİki', N'Testİki', N'12345678903', N'1234', N'test2', 2, 1)
INSERT [dbo].[Musteri] ([MusteriID], [RezervasyonID], [Ad], [Soyad], [TCKN], [Telefon], [Email], [OdaID], [IsActive]) VALUES (4, 2, N'KişiÜç', N'TestÜç', N'12345678904', N'1234', N'test3', 2, 1)
INSERT [dbo].[Musteri] ([MusteriID], [RezervasyonID], [Ad], [Soyad], [TCKN], [Telefon], [Email], [OdaID], [IsActive]) VALUES (5, 2, N'KişiBir', N'Test', N'12345678902', N'123', N'test1', 3, 1)
INSERT [dbo].[Musteri] ([MusteriID], [RezervasyonID], [Ad], [Soyad], [TCKN], [Telefon], [Email], [OdaID], [IsActive]) VALUES (6, 3, N'esra', N'yavuz', N'12345678901', N'', N'asdds@hotmail.com', 4, 1)
INSERT [dbo].[Musteri] ([MusteriID], [RezervasyonID], [Ad], [Soyad], [TCKN], [Telefon], [Email], [OdaID], [IsActive]) VALUES (7, 4, N'Esra', N'Yavuz', N'12345678901', N'', N'abc@hotmail.com', 6, 1)
INSERT [dbo].[Musteri] ([MusteriID], [RezervasyonID], [Ad], [Soyad], [TCKN], [Telefon], [Email], [OdaID], [IsActive]) VALUES (8, 4, N'Kaan', N'Kılavuz', N'12345678902', N'', N'abc@hotmail.com', 6, 1)
SET IDENTITY_INSERT [dbo].[Musteri] OFF
SET IDENTITY_INSERT [dbo].[MusteriRezervasyon] ON 

INSERT [dbo].[MusteriRezervasyon] ([ID], [RezervasyonID], [MusteriID], [OdaID]) VALUES (1, 1, 1, 1)
INSERT [dbo].[MusteriRezervasyon] ([ID], [RezervasyonID], [MusteriID], [OdaID]) VALUES (2, 2, 2, 2)
INSERT [dbo].[MusteriRezervasyon] ([ID], [RezervasyonID], [MusteriID], [OdaID]) VALUES (3, 2, 3, 2)
INSERT [dbo].[MusteriRezervasyon] ([ID], [RezervasyonID], [MusteriID], [OdaID]) VALUES (4, 2, 4, 2)
INSERT [dbo].[MusteriRezervasyon] ([ID], [RezervasyonID], [MusteriID], [OdaID]) VALUES (5, 2, 5, 3)
INSERT [dbo].[MusteriRezervasyon] ([ID], [RezervasyonID], [MusteriID], [OdaID]) VALUES (6, 3, 6, 4)
INSERT [dbo].[MusteriRezervasyon] ([ID], [RezervasyonID], [MusteriID], [OdaID]) VALUES (7, 4, 7, 6)
INSERT [dbo].[MusteriRezervasyon] ([ID], [RezervasyonID], [MusteriID], [OdaID]) VALUES (8, 4, 8, 6)
SET IDENTITY_INSERT [dbo].[MusteriRezervasyon] OFF
SET IDENTITY_INSERT [dbo].[Oda] ON 

INSERT [dbo].[Oda] ([OdaID], [RezervasyonID], [KisiSayisi], [Fiyat], [Durum], [HaftasonuSayisi], [Haftasonu], [MinKisi], [MaxKisi]) VALUES (1, 1, 0, 120.0000, 0, 2, 40, 40, 30)
INSERT [dbo].[Oda] ([OdaID], [RezervasyonID], [KisiSayisi], [Fiyat], [Durum], [HaftasonuSayisi], [Haftasonu], [MinKisi], [MaxKisi]) VALUES (2, 2, 0, 120.0000, 0, 0, 40, 40, 30)
INSERT [dbo].[Oda] ([OdaID], [RezervasyonID], [KisiSayisi], [Fiyat], [Durum], [HaftasonuSayisi], [Haftasonu], [MinKisi], [MaxKisi]) VALUES (3, 2, 0, 120.0000, 0, 0, 40, 40, 30)
INSERT [dbo].[Oda] ([OdaID], [RezervasyonID], [KisiSayisi], [Fiyat], [Durum], [HaftasonuSayisi], [Haftasonu], [MinKisi], [MaxKisi]) VALUES (4, 3, 0, 120.0000, 0, 4, 40, 40, 30)
INSERT [dbo].[Oda] ([OdaID], [RezervasyonID], [KisiSayisi], [Fiyat], [Durum], [HaftasonuSayisi], [Haftasonu], [MinKisi], [MaxKisi]) VALUES (5, 3, 0, 120.0000, 0, 4, 40, 40, 30)
INSERT [dbo].[Oda] ([OdaID], [RezervasyonID], [KisiSayisi], [Fiyat], [Durum], [HaftasonuSayisi], [Haftasonu], [MinKisi], [MaxKisi]) VALUES (6, 4, 0, 120.0000, 0, 0, 40, 40, 30)
INSERT [dbo].[Oda] ([OdaID], [RezervasyonID], [KisiSayisi], [Fiyat], [Durum], [HaftasonuSayisi], [Haftasonu], [MinKisi], [MaxKisi]) VALUES (7, 0, 0, 120.0000, 1, 0, 40, 40, 30)
INSERT [dbo].[Oda] ([OdaID], [RezervasyonID], [KisiSayisi], [Fiyat], [Durum], [HaftasonuSayisi], [Haftasonu], [MinKisi], [MaxKisi]) VALUES (8, 0, 0, 120.0000, 1, 0, 40, 40, 30)
INSERT [dbo].[Oda] ([OdaID], [RezervasyonID], [KisiSayisi], [Fiyat], [Durum], [HaftasonuSayisi], [Haftasonu], [MinKisi], [MaxKisi]) VALUES (9, 0, 0, 120.0000, 1, 0, 40, 40, 30)
INSERT [dbo].[Oda] ([OdaID], [RezervasyonID], [KisiSayisi], [Fiyat], [Durum], [HaftasonuSayisi], [Haftasonu], [MinKisi], [MaxKisi]) VALUES (10, 0, 0, 120.0000, 1, 0, 40, 40, 30)
INSERT [dbo].[Oda] ([OdaID], [RezervasyonID], [KisiSayisi], [Fiyat], [Durum], [HaftasonuSayisi], [Haftasonu], [MinKisi], [MaxKisi]) VALUES (11, 0, 0, 120.0000, 1, 0, 40, 40, 30)
INSERT [dbo].[Oda] ([OdaID], [RezervasyonID], [KisiSayisi], [Fiyat], [Durum], [HaftasonuSayisi], [Haftasonu], [MinKisi], [MaxKisi]) VALUES (12, 0, 0, 120.0000, 1, 0, 40, 40, 30)
INSERT [dbo].[Oda] ([OdaID], [RezervasyonID], [KisiSayisi], [Fiyat], [Durum], [HaftasonuSayisi], [Haftasonu], [MinKisi], [MaxKisi]) VALUES (13, 0, 0, 120.0000, 1, 0, 40, 40, 30)
INSERT [dbo].[Oda] ([OdaID], [RezervasyonID], [KisiSayisi], [Fiyat], [Durum], [HaftasonuSayisi], [Haftasonu], [MinKisi], [MaxKisi]) VALUES (14, 0, 0, 120.0000, 1, 0, 40, 40, 30)
INSERT [dbo].[Oda] ([OdaID], [RezervasyonID], [KisiSayisi], [Fiyat], [Durum], [HaftasonuSayisi], [Haftasonu], [MinKisi], [MaxKisi]) VALUES (15, 0, 0, 120.0000, 1, 0, 40, 40, 30)
INSERT [dbo].[Oda] ([OdaID], [RezervasyonID], [KisiSayisi], [Fiyat], [Durum], [HaftasonuSayisi], [Haftasonu], [MinKisi], [MaxKisi]) VALUES (16, 0, 0, 120.0000, 1, 0, 40, 40, 30)
INSERT [dbo].[Oda] ([OdaID], [RezervasyonID], [KisiSayisi], [Fiyat], [Durum], [HaftasonuSayisi], [Haftasonu], [MinKisi], [MaxKisi]) VALUES (17, 0, 0, 120.0000, 1, 0, 40, 40, 30)
INSERT [dbo].[Oda] ([OdaID], [RezervasyonID], [KisiSayisi], [Fiyat], [Durum], [HaftasonuSayisi], [Haftasonu], [MinKisi], [MaxKisi]) VALUES (18, 0, 0, 120.0000, 1, 0, 40, 40, 30)
INSERT [dbo].[Oda] ([OdaID], [RezervasyonID], [KisiSayisi], [Fiyat], [Durum], [HaftasonuSayisi], [Haftasonu], [MinKisi], [MaxKisi]) VALUES (19, 0, 0, 120.0000, 1, 0, 40, 40, 30)
INSERT [dbo].[Oda] ([OdaID], [RezervasyonID], [KisiSayisi], [Fiyat], [Durum], [HaftasonuSayisi], [Haftasonu], [MinKisi], [MaxKisi]) VALUES (20, 0, 0, 120.0000, 1, 0, 40, 40, 30)
SET IDENTITY_INSERT [dbo].[Oda] OFF
SET IDENTITY_INSERT [dbo].[Rezervasyon] ON 

INSERT [dbo].[Rezervasyon] ([RezervasyonID], [UyeID], [GirisTarihi], [BitisTarihi], [ToplamKisiSayisi], [RezervasyonTipID], [ToplamFiyat], [IsActive]) VALUES (1, 1, CAST(N'2019-11-16T20:15:35.000' AS DateTime), CAST(N'2019-11-21T20:15:35.000' AS DateTime), 1, 1, 130.0000, 1)
INSERT [dbo].[Rezervasyon] ([RezervasyonID], [UyeID], [GirisTarihi], [BitisTarihi], [ToplamKisiSayisi], [RezervasyonTipID], [ToplamFiyat], [IsActive]) VALUES (2, 1, CAST(N'2019-10-30T21:08:28.523' AS DateTime), CAST(N'2019-10-31T21:08:28.523' AS DateTime), 4, 2, 190.0000, 1)
INSERT [dbo].[Rezervasyon] ([RezervasyonID], [UyeID], [GirisTarihi], [BitisTarihi], [ToplamKisiSayisi], [RezervasyonTipID], [ToplamFiyat], [IsActive]) VALUES (3, 5, CAST(N'2019-11-30T09:17:23.000' AS DateTime), CAST(N'2019-12-12T09:17:23.000' AS DateTime), 5, 3, 410.0000, 1)
INSERT [dbo].[Rezervasyon] ([RezervasyonID], [UyeID], [GirisTarihi], [BitisTarihi], [ToplamKisiSayisi], [RezervasyonTipID], [ToplamFiyat], [IsActive]) VALUES (4, 5, CAST(N'2019-11-20T09:21:50.000' AS DateTime), CAST(N'2019-11-22T09:21:50.000' AS DateTime), 2, 1, 100.0000, 1)
SET IDENTITY_INSERT [dbo].[Rezervasyon] OFF
SET IDENTITY_INSERT [dbo].[RezervasyonTip] ON 

INSERT [dbo].[RezervasyonTip] ([RezervasyonTipID], [Ad], [Aciklama]) VALUES (1, N'Standart', N'sadece oda ve kahvaltı dahildir.')
INSERT [dbo].[RezervasyonTip] ([RezervasyonTipID], [Ad], [Aciklama]) VALUES (2, N'Full', N'oda ve tüm öğünler dahildir.')
INSERT [dbo].[RezervasyonTip] ([RezervasyonTipID], [Ad], [Aciklama]) VALUES (3, N'Full + Full', N'oda yemek ve içki dahildir.')
SET IDENTITY_INSERT [dbo].[RezervasyonTip] OFF
SET IDENTITY_INSERT [dbo].[Uye] ON 

INSERT [dbo].[Uye] ([UyeID], [Email], [Sifre], [IsAdmin]) VALUES (1, N'esryvz@yandex.com', N'12345678', 1)
INSERT [dbo].[Uye] ([UyeID], [Email], [Sifre], [IsAdmin]) VALUES (2, N'ac@hotmail.com', N'12345', 0)
INSERT [dbo].[Uye] ([UyeID], [Email], [Sifre], [IsAdmin]) VALUES (3, N'kn@hotmail.com', N'12345', 0)
INSERT [dbo].[Uye] ([UyeID], [Email], [Sifre], [IsAdmin]) VALUES (4, N'abc@hotmail.com', N'12345678', 0)
INSERT [dbo].[Uye] ([UyeID], [Email], [Sifre], [IsAdmin]) VALUES (5, N'@hotmail.com', N'12345678', 0)
SET IDENTITY_INSERT [dbo].[Uye] OFF
ALTER TABLE [dbo].[Musteri]  WITH CHECK ADD  CONSTRAINT [FK_Musteri_Rezervasyon] FOREIGN KEY([RezervasyonID])
REFERENCES [dbo].[Rezervasyon] ([RezervasyonID])
GO
ALTER TABLE [dbo].[Musteri] CHECK CONSTRAINT [FK_Musteri_Rezervasyon]
GO
ALTER TABLE [dbo].[MusteriRezervasyon]  WITH CHECK ADD  CONSTRAINT [FK_MusteriRezervasyon_Musteri] FOREIGN KEY([MusteriID])
REFERENCES [dbo].[Musteri] ([MusteriID])
GO
ALTER TABLE [dbo].[MusteriRezervasyon] CHECK CONSTRAINT [FK_MusteriRezervasyon_Musteri]
GO
ALTER TABLE [dbo].[MusteriRezervasyon]  WITH CHECK ADD  CONSTRAINT [FK_MusteriRezervasyon_Oda] FOREIGN KEY([OdaID])
REFERENCES [dbo].[Oda] ([OdaID])
GO
ALTER TABLE [dbo].[MusteriRezervasyon] CHECK CONSTRAINT [FK_MusteriRezervasyon_Oda]
GO
ALTER TABLE [dbo].[MusteriRezervasyon]  WITH CHECK ADD  CONSTRAINT [FK_MusteriRezervasyon_Rezervasyon] FOREIGN KEY([RezervasyonID])
REFERENCES [dbo].[Rezervasyon] ([RezervasyonID])
GO
ALTER TABLE [dbo].[MusteriRezervasyon] CHECK CONSTRAINT [FK_MusteriRezervasyon_Rezervasyon]
GO
ALTER TABLE [dbo].[Rezervasyon]  WITH CHECK ADD  CONSTRAINT [FK_Rezervasyon_RezervasyonTip] FOREIGN KEY([RezervasyonTipID])
REFERENCES [dbo].[RezervasyonTip] ([RezervasyonTipID])
GO
ALTER TABLE [dbo].[Rezervasyon] CHECK CONSTRAINT [FK_Rezervasyon_RezervasyonTip]
GO
ALTER TABLE [dbo].[Rezervasyon]  WITH CHECK ADD  CONSTRAINT [FK_Rezervasyon_Uye] FOREIGN KEY([UyeID])
REFERENCES [dbo].[Uye] ([UyeID])
GO
ALTER TABLE [dbo].[Rezervasyon] CHECK CONSTRAINT [FK_Rezervasyon_Uye]
GO
USE [master]
GO
ALTER DATABASE [OtelDB] SET  READ_WRITE 
GO
