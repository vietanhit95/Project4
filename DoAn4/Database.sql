USE [master]
GO
/****** Object:  Database [DoAn4]    Script Date: 5/14/2016 9:53:26 PM ******/
CREATE DATABASE [DoAn4]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DoAn4', FILENAME = N'D:\DoAn4\DoAn4.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DoAn4_log', FILENAME = N'D:\DoAn4\DoAn4_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DoAn4] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DoAn4].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DoAn4] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DoAn4] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DoAn4] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DoAn4] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DoAn4] SET ARITHABORT OFF 
GO
ALTER DATABASE [DoAn4] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DoAn4] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DoAn4] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DoAn4] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DoAn4] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DoAn4] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DoAn4] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DoAn4] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DoAn4] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DoAn4] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DoAn4] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DoAn4] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DoAn4] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DoAn4] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DoAn4] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DoAn4] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DoAn4] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DoAn4] SET RECOVERY FULL 
GO
ALTER DATABASE [DoAn4] SET  MULTI_USER 
GO
ALTER DATABASE [DoAn4] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DoAn4] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DoAn4] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DoAn4] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [DoAn4] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DoAn4', N'ON'
GO
USE [DoAn4]
GO
/****** Object:  Table [dbo].[BaiViet]    Script Date: 5/14/2016 9:53:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BaiViet](
	[MaBaiViet] [int] IDENTITY(1,1) NOT NULL,
	[MaChuyenMuc] [int] NOT NULL,
	[MaNhomSanPham] [int] NOT NULL,
	[MaKhachHang] [int] NULL,
	[MaVungMien] [int] NOT NULL,
	[TieuDe] [nvarchar](50) NULL,
	[NoiDung] [nvarchar](150) NULL,
	[NgayDang] [datetime] NULL,
	[NgayHetHan] [datetime] NULL,
	[NgayDuyet] [datetime] NULL,
	[TenNguoiLienHe] [nvarchar](50) NULL,
	[DiaChiLienHe] [nvarchar](50) NULL,
	[SDTLienHe] [varchar](20) NULL,
	[EmailLienHe] [varchar](50) NULL,
	[Image] [varchar](100) NULL,
	[GiaBan] [float] NULL,
	[TrangThai] [nvarchar](50) NULL,
 CONSTRAINT [PK_BaiViet] PRIMARY KEY CLUSTERED 
(
	[MaBaiViet] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ChuyenMuc]    Script Date: 5/14/2016 9:53:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChuyenMuc](
	[MaChuyenMuc] [int] IDENTITY(1,1) NOT NULL,
	[TenChuyenMuc] [nvarchar](50) NULL,
 CONSTRAINT [PK_ChuyenMuc] PRIMARY KEY CLUSTERED 
(
	[MaChuyenMuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HoaDonDangTin]    Script Date: 5/14/2016 9:53:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonDangTin](
	[MaHoaDon] [int] IDENTITY(1,1) NOT NULL,
	[MaKhachHang] [int] NOT NULL,
	[MoTa] [nvarchar](50) NULL,
	[NgayDang] [datetime] NULL,
	[MaBaiViet] [int] NOT NULL,
	[SoTien] [float] NULL,
 CONSTRAINT [PK_HoaDonDangTin] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HoaDonNapTien]    Script Date: 5/14/2016 9:53:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonNapTien](
	[MaHoaDon] [int] IDENTITY(1,1) NOT NULL,
	[MaKhachHang] [int] NOT NULL,
	[NgayNap] [datetime] NULL,
	[SoTienNap] [float] NULL,
 CONSTRAINT [PK_HoaDonNapTien] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 5/14/2016 9:53:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKhachHang] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[TenDangNhap] [varchar](50) NULL,
	[MatKhau] [varchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[SDT] [varchar](20) NULL,
	[Email] [varchar](50) NULL,
	[NgayDangKi] [datetime] NULL,
	[SoTienDaNap] [float] NULL,
	[GhiChu] [nvarchar](100) NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 5/14/2016 9:53:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNhanVien] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[TenDangNhap] [varchar](50) NULL,
	[MatKhau] [varchar](50) NULL,
	[SDT] [varchar](20) NULL,
	[Email] [varchar](50) NULL,
	[Image] [varchar](100) NULL,
	[TrangThai] [nvarchar](50) NULL,
	[QuyenHan] [nvarchar](50) NULL,
	[GhiChu] [nvarchar](100) NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NhomSanPham]    Script Date: 5/14/2016 9:53:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NhomSanPham](
	[MaNhomSanPham] [int] IDENTITY(1,1) NOT NULL,
	[TenNhomSanPham] [nvarchar](50) NULL,
	[Image] [varchar](100) NULL,
	[MoTa] [nvarchar](100) NULL,
 CONSTRAINT [PK_NhomSanPham] PRIMARY KEY CLUSTERED 
(
	[MaNhomSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VungMien]    Script Date: 5/14/2016 9:53:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VungMien](
	[MaVungMien] [int] IDENTITY(1,1) NOT NULL,
	[TenVungMien] [nvarchar](50) NULL,
 CONSTRAINT [PK_VungMien] PRIMARY KEY CLUSTERED 
(
	[MaVungMien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[BaiViet] ON 

INSERT [dbo].[BaiViet] ([MaBaiViet], [MaChuyenMuc], [MaNhomSanPham], [MaKhachHang], [MaVungMien], [TieuDe], [NoiDung], [NgayDang], [NgayHetHan], [NgayDuyet], [TenNguoiLienHe], [DiaChiLienHe], [SDTLienHe], [EmailLienHe], [Image], [GiaBan], [TrangThai]) VALUES (4, 2, 2, NULL, 1, N'xe máy', N'cần bán', CAST(N'2016-04-05 00:00:00.000' AS DateTime), NULL, NULL, N'hoàng anh', N'hà nội', N'0972471294', N'hoanganhcnpm@gmail.com', N'images (1).jpg', 6000000, N'chua')
INSERT [dbo].[BaiViet] ([MaBaiViet], [MaChuyenMuc], [MaNhomSanPham], [MaKhachHang], [MaVungMien], [TieuDe], [NoiDung], [NgayDang], [NgayHetHan], [NgayDuyet], [TenNguoiLienHe], [DiaChiLienHe], [SDTLienHe], [EmailLienHe], [Image], [GiaBan], [TrangThai]) VALUES (5, 1, 4, NULL, 1, N'mua nhà', N'cần mùa', CAST(N'2016-04-04 00:00:00.000' AS DateTime), NULL, NULL, N'việt anh', N'hưng yên', N'0976848282', N'vietanh@gmail.com', N'12512467_1561170800859958_1716790206990649182_n.jpg', 70000000, N'co')
INSERT [dbo].[BaiViet] ([MaBaiViet], [MaChuyenMuc], [MaNhomSanPham], [MaKhachHang], [MaVungMien], [TieuDe], [NoiDung], [NgayDang], [NgayHetHan], [NgayDuyet], [TenNguoiLienHe], [DiaChiLienHe], [SDTLienHe], [EmailLienHe], [Image], [GiaBan], [TrangThai]) VALUES (7, 1, 5, NULL, 3, N'Quạt', N'Cần mua', CAST(N'2016-04-18 00:00:00.000' AS DateTime), NULL, NULL, N'Hoàng anh', N'hưng yên', N'0972471294', N'hoanganhcnpm@gmail.com', N'sdaasd.jpg', 200000, N'chua')
INSERT [dbo].[BaiViet] ([MaBaiViet], [MaChuyenMuc], [MaNhomSanPham], [MaKhachHang], [MaVungMien], [TieuDe], [NoiDung], [NgayDang], [NgayHetHan], [NgayDuyet], [TenNguoiLienHe], [DiaChiLienHe], [SDTLienHe], [EmailLienHe], [Image], [GiaBan], [TrangThai]) VALUES (8, 1, 4, NULL, 2, N'Nhà', N'Cần mua', CAST(N'2016-04-18 00:00:00.000' AS DateTime), NULL, NULL, N'Hoàng anh', N'hưng yên', N'0972471294', N'hoanganhcnpm@gmail.com', N'imagesfsdfds.jpg', 300000000, N'ko')
INSERT [dbo].[BaiViet] ([MaBaiViet], [MaChuyenMuc], [MaNhomSanPham], [MaKhachHang], [MaVungMien], [TieuDe], [NoiDung], [NgayDang], [NgayHetHan], [NgayDuyet], [TenNguoiLienHe], [DiaChiLienHe], [SDTLienHe], [EmailLienHe], [Image], [GiaBan], [TrangThai]) VALUES (10, 2, 6, NULL, 4, N'Xoong', N'cần bán', CAST(N'2016-04-18 00:00:00.000' AS DateTime), NULL, NULL, N'Hoàng anh', N'Đàn nẵng', N'0972471294', N'hoanganhcnpm@gmail.com', N'images (3).jpg', 200000, N'co')
INSERT [dbo].[BaiViet] ([MaBaiViet], [MaChuyenMuc], [MaNhomSanPham], [MaKhachHang], [MaVungMien], [TieuDe], [NoiDung], [NgayDang], [NgayHetHan], [NgayDuyet], [TenNguoiLienHe], [DiaChiLienHe], [SDTLienHe], [EmailLienHe], [Image], [GiaBan], [TrangThai]) VALUES (11, 2, 6, NULL, 4, N'đèn', N'cần bán', CAST(N'2016-04-18 00:00:00.000' AS DateTime), NULL, NULL, N'Hoàng anh', N'Đàn nẵng', N'0972471294', N'hoanganhcnpm@gmail.com', N't?i xu?ng (4).jpg', 350000, N'chua')
INSERT [dbo].[BaiViet] ([MaBaiViet], [MaChuyenMuc], [MaNhomSanPham], [MaKhachHang], [MaVungMien], [TieuDe], [NoiDung], [NgayDang], [NgayHetHan], [NgayDuyet], [TenNguoiLienHe], [DiaChiLienHe], [SDTLienHe], [EmailLienHe], [Image], [GiaBan], [TrangThai]) VALUES (14, 1, 6, NULL, 1, N'Bàn ăn', N'Cần mua', CAST(N'2016-05-12 00:00:00.000' AS DateTime), CAST(N'2016-05-15 00:00:00.000' AS DateTime), CAST(N'2016-05-28 00:00:00.000' AS DateTime), N'Dương 3D 3G', N'Hưng Yên', N'1234567890', N'duong@gmail.com', N'skf.jpg', 30000000, N'Co')
INSERT [dbo].[BaiViet] ([MaBaiViet], [MaChuyenMuc], [MaNhomSanPham], [MaKhachHang], [MaVungMien], [TieuDe], [NoiDung], [NgayDang], [NgayHetHan], [NgayDuyet], [TenNguoiLienHe], [DiaChiLienHe], [SDTLienHe], [EmailLienHe], [Image], [GiaBan], [TrangThai]) VALUES (15, 1, 6, NULL, 5, N'Giá sách', N'Cần mua', CAST(N'2016-04-22 00:00:00.000' AS DateTime), NULL, NULL, N'Đồng', N'hà nội', N'3333333334', N'dong@gmail.com', N'giasach.jpg', 2000000, N'chua')
INSERT [dbo].[BaiViet] ([MaBaiViet], [MaChuyenMuc], [MaNhomSanPham], [MaKhachHang], [MaVungMien], [TieuDe], [NoiDung], [NgayDang], [NgayHetHan], [NgayDuyet], [TenNguoiLienHe], [DiaChiLienHe], [SDTLienHe], [EmailLienHe], [Image], [GiaBan], [TrangThai]) VALUES (16, 2, 3, NULL, 4, N'Nokia 6300 gold', N'cần bán', CAST(N'2016-04-25 00:00:00.000' AS DateTime), NULL, NULL, N'hoang anh', N'hưng yên', N'0972471294', N'hoanganhcnpm@gmail.com', N'6300.jpg', 600000, N'chua')
INSERT [dbo].[BaiViet] ([MaBaiViet], [MaChuyenMuc], [MaNhomSanPham], [MaKhachHang], [MaVungMien], [TieuDe], [NoiDung], [NgayDang], [NgayHetHan], [NgayDuyet], [TenNguoiLienHe], [DiaChiLienHe], [SDTLienHe], [EmailLienHe], [Image], [GiaBan], [TrangThai]) VALUES (17, 2, 8, NULL, 1, N'Chim chào mào', N'cần bán', NULL, NULL, NULL, N'Dương 3D 3G', N'Tây nguyên', N'0976848282', N'duong@gmail.com', N'hqdefault.jpg', 2000000, N'Chua')
INSERT [dbo].[BaiViet] ([MaBaiViet], [MaChuyenMuc], [MaNhomSanPham], [MaKhachHang], [MaVungMien], [TieuDe], [NoiDung], [NgayDang], [NgayHetHan], [NgayDuyet], [TenNguoiLienHe], [DiaChiLienHe], [SDTLienHe], [EmailLienHe], [Image], [GiaBan], [TrangThai]) VALUES (18, 2, 8, NULL, 1, N'Lồng chim', N'cần bán', CAST(N'2016-04-25 00:00:00.000' AS DateTime), NULL, NULL, N'Dương 3D 3G', N'hà nội', N'2133433433', N'duong@gmail.com', N'longchim.jpg', 300000, N'ko')
INSERT [dbo].[BaiViet] ([MaBaiViet], [MaChuyenMuc], [MaNhomSanPham], [MaKhachHang], [MaVungMien], [TieuDe], [NoiDung], [NgayDang], [NgayHetHan], [NgayDuyet], [TenNguoiLienHe], [DiaChiLienHe], [SDTLienHe], [EmailLienHe], [Image], [GiaBan], [TrangThai]) VALUES (19, 2, 8, NULL, 2, N'Lồng chim', N'cần bán', CAST(N'2016-04-25 00:00:00.000' AS DateTime), NULL, NULL, N'Dương 3D 3G', N'hưng yên', N'0976848282', N'duong@gmail.com', N'images (4).jpg', 300000, N'ko')
INSERT [dbo].[BaiViet] ([MaBaiViet], [MaChuyenMuc], [MaNhomSanPham], [MaKhachHang], [MaVungMien], [TieuDe], [NoiDung], [NgayDang], [NgayHetHan], [NgayDuyet], [TenNguoiLienHe], [DiaChiLienHe], [SDTLienHe], [EmailLienHe], [Image], [GiaBan], [TrangThai]) VALUES (21, 2, 8, NULL, 4, N'Giày nam', N'cần bán', CAST(N'2016-05-02 00:00:00.000' AS DateTime), CAST(N'2016-06-17 00:00:00.000' AS DateTime), CAST(N'2016-05-14 00:00:00.000' AS DateTime), N'Dương Thuận', N'hưng yên', N'0972471294', N'duong@gmail.com', N'1896893_370249719784295_17005246_n.jpg', 350000, N'Co')
INSERT [dbo].[BaiViet] ([MaBaiViet], [MaChuyenMuc], [MaNhomSanPham], [MaKhachHang], [MaVungMien], [TieuDe], [NoiDung], [NgayDang], [NgayHetHan], [NgayDuyet], [TenNguoiLienHe], [DiaChiLienHe], [SDTLienHe], [EmailLienHe], [Image], [GiaBan], [TrangThai]) VALUES (22, 1, 8, 2, 1, N'Giày nam', N'Cần mua', NULL, NULL, NULL, N'hoang anh', N'hà nội', N'3333333333', N'hoanganhcnpm@gmail.com', N'hhhhhh.jpg', 2000000, N'ko')
INSERT [dbo].[BaiViet] ([MaBaiViet], [MaChuyenMuc], [MaNhomSanPham], [MaKhachHang], [MaVungMien], [TieuDe], [NoiDung], [NgayDang], [NgayHetHan], [NgayDuyet], [TenNguoiLienHe], [DiaChiLienHe], [SDTLienHe], [EmailLienHe], [Image], [GiaBan], [TrangThai]) VALUES (23, 2, 8, 1, 1, N'Túi xách', N'cần bán', CAST(N'2016-04-25 00:00:00.000' AS DateTime), NULL, NULL, N'Dương 3D 3G', N'hưng yên', N'0972471294', N'hoanganhcnpm@gmail.com', N'tx.jpg', 800000, N'ko')
INSERT [dbo].[BaiViet] ([MaBaiViet], [MaChuyenMuc], [MaNhomSanPham], [MaKhachHang], [MaVungMien], [TieuDe], [NoiDung], [NgayDang], [NgayHetHan], [NgayDuyet], [TenNguoiLienHe], [DiaChiLienHe], [SDTLienHe], [EmailLienHe], [Image], [GiaBan], [TrangThai]) VALUES (24, 1, 8, 2, 1, N'Máy bơm', N'Cần mua', CAST(N'2016-04-25 00:00:00.000' AS DateTime), NULL, NULL, N'Chiến', N'hà nội', N'2133433433', N'chien@gmail.com', N'kkkk.jpg', 300000, N'co')
INSERT [dbo].[BaiViet] ([MaBaiViet], [MaChuyenMuc], [MaNhomSanPham], [MaKhachHang], [MaVungMien], [TieuDe], [NoiDung], [NgayDang], [NgayHetHan], [NgayDuyet], [TenNguoiLienHe], [DiaChiLienHe], [SDTLienHe], [EmailLienHe], [Image], [GiaBan], [TrangThai]) VALUES (25, 2, 8, 2, 3, N'Máy lọc nước', N'cần bán', CAST(N'2016-04-25 00:00:00.000' AS DateTime), NULL, NULL, N'Dương 3D 3G', N'hưng yên', N'0972471294', N'hoanganhcnpm@gmail.com', N'ln.jpg', 500000, N'co')
INSERT [dbo].[BaiViet] ([MaBaiViet], [MaChuyenMuc], [MaNhomSanPham], [MaKhachHang], [MaVungMien], [TieuDe], [NoiDung], [NgayDang], [NgayHetHan], [NgayDuyet], [TenNguoiLienHe], [DiaChiLienHe], [SDTLienHe], [EmailLienHe], [Image], [GiaBan], [TrangThai]) VALUES (30, 2, 8, 2, 4, N'Loa thùng', N'cần bán', CAST(N'2016-04-26 00:00:00.000' AS DateTime), NULL, NULL, N'Dương 3D 3G', N'hà nội', N'0972471294', N'duong@gmail.com', N'loa.jpg', 2000000, N'co')
INSERT [dbo].[BaiViet] ([MaBaiViet], [MaChuyenMuc], [MaNhomSanPham], [MaKhachHang], [MaVungMien], [TieuDe], [NoiDung], [NgayDang], [NgayHetHan], [NgayDuyet], [TenNguoiLienHe], [DiaChiLienHe], [SDTLienHe], [EmailLienHe], [Image], [GiaBan], [TrangThai]) VALUES (31, 2, 8, 2, 1, N'đồng hồ', N'cần bán', CAST(N'2016-04-26 00:00:00.000' AS DateTime), NULL, NULL, N'Dương 3D 3G', N'hưng yên', N'0972471294', N'hoanganhcnpm@gmail.com', N'dongho.jpg', 2000000, N'co')
INSERT [dbo].[BaiViet] ([MaBaiViet], [MaChuyenMuc], [MaNhomSanPham], [MaKhachHang], [MaVungMien], [TieuDe], [NoiDung], [NgayDang], [NgayHetHan], [NgayDuyet], [TenNguoiLienHe], [DiaChiLienHe], [SDTLienHe], [EmailLienHe], [Image], [GiaBan], [TrangThai]) VALUES (32, 2, 8, 1, 4, N'Cân', N'cần bán', CAST(N'2016-04-26 00:00:00.000' AS DateTime), NULL, NULL, N'việt anh', N'hưng yên', N'0972471294', N'hoanganhcnpm@gmail.com', N'images (5).jpg', 150000, N'co')
INSERT [dbo].[BaiViet] ([MaBaiViet], [MaChuyenMuc], [MaNhomSanPham], [MaKhachHang], [MaVungMien], [TieuDe], [NoiDung], [NgayDang], [NgayHetHan], [NgayDuyet], [TenNguoiLienHe], [DiaChiLienHe], [SDTLienHe], [EmailLienHe], [Image], [GiaBan], [TrangThai]) VALUES (34, 2, 8, 1, 4, N'thau', N'cần bán', CAST(N'2016-04-26 00:00:00.000' AS DateTime), NULL, NULL, N'Dương 3D 3G', N'hưng yên', N'0972471294', N'hoanganhcnpm@gmail.com', N'thau.jpg', NULL, N'co')
INSERT [dbo].[BaiViet] ([MaBaiViet], [MaChuyenMuc], [MaNhomSanPham], [MaKhachHang], [MaVungMien], [TieuDe], [NoiDung], [NgayDang], [NgayHetHan], [NgayDuyet], [TenNguoiLienHe], [DiaChiLienHe], [SDTLienHe], [EmailLienHe], [Image], [GiaBan], [TrangThai]) VALUES (35, 2, 8, 1, 4, N'phích nước', N'cần bán', CAST(N'2016-04-26 00:00:00.000' AS DateTime), NULL, NULL, N'Dương 3D 3G', N'hưng yên', N'0972471294', N'hoanganhcnpm@gmail.com', N'phich.jpg', 150000, N'co')
INSERT [dbo].[BaiViet] ([MaBaiViet], [MaChuyenMuc], [MaNhomSanPham], [MaKhachHang], [MaVungMien], [TieuDe], [NoiDung], [NgayDang], [NgayHetHan], [NgayDuyet], [TenNguoiLienHe], [DiaChiLienHe], [SDTLienHe], [EmailLienHe], [Image], [GiaBan], [TrangThai]) VALUES (36, 2, 5, 1, 4, N'trạn', N'cần bán', CAST(N'2016-04-26 00:00:00.000' AS DateTime), NULL, NULL, N'Chiến', N'hưng yên', N'0972471294', N'hoanganhcnpm@gmail.com', N'tran.jpg', 24000000, N'co')
INSERT [dbo].[BaiViet] ([MaBaiViet], [MaChuyenMuc], [MaNhomSanPham], [MaKhachHang], [MaVungMien], [TieuDe], [NoiDung], [NgayDang], [NgayHetHan], [NgayDuyet], [TenNguoiLienHe], [DiaChiLienHe], [SDTLienHe], [EmailLienHe], [Image], [GiaBan], [TrangThai]) VALUES (1064, 2, 3, NULL, 4, N'sdasd', N'đas', CAST(N'2016-05-14 00:00:00.000' AS DateTime), NULL, NULL, N'được', N'yên bái', N'0972471294', N'duoc@gmail.com', N'6300.jpg', 6666666666, NULL)
SET IDENTITY_INSERT [dbo].[BaiViet] OFF
SET IDENTITY_INSERT [dbo].[ChuyenMuc] ON 

INSERT [dbo].[ChuyenMuc] ([MaChuyenMuc], [TenChuyenMuc]) VALUES (1, N'Mua')
INSERT [dbo].[ChuyenMuc] ([MaChuyenMuc], [TenChuyenMuc]) VALUES (2, N'Ban')
SET IDENTITY_INSERT [dbo].[ChuyenMuc] OFF
SET IDENTITY_INSERT [dbo].[HoaDonDangTin] ON 

INSERT [dbo].[HoaDonDangTin] ([MaHoaDon], [MaKhachHang], [MoTa], [NgayDang], [MaBaiViet], [SoTien]) VALUES (22, 1, NULL, CAST(N'2016-04-19 23:43:01.777' AS DateTime), 0, NULL)
SET IDENTITY_INSERT [dbo].[HoaDonDangTin] OFF
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

INSERT [dbo].[KhachHang] ([MaKhachHang], [HoTen], [TenDangNhap], [MatKhau], [DiaChi], [SDT], [Email], [NgayDangKi], [SoTienDaNap], [GhiChu]) VALUES (1, N'Nguyễn Hoàng Anh', N'hoanganh', N'1', N'Hưng Yên', N'0972471294', N'hoanganhcnpm@gmail.com', CAST(N'2015-12-29 00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoTen], [TenDangNhap], [MatKhau], [DiaChi], [SDT], [Email], [NgayDangKi], [SoTienDaNap], [GhiChu]) VALUES (2, N'việt anh', N'vietanh', N'1', N'hưng yên', N'0972471294', N'anhduy210503@gmail.com', CAST(N'2016-04-20 00:00:00.000' AS DateTime), 43413134234, NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoTen], [TenDangNhap], [MatKhau], [DiaChi], [SDT], [Email], [NgayDangKi], [SoTienDaNap], [GhiChu]) VALUES (3, N'dương', N'duong', N'1', N'hưng yên', N'3132222223', N'anhduy210503@gmail.com', CAST(N'2016-04-20 00:00:00.000' AS DateTime), 43413134234, NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoTen], [TenDangNhap], [MatKhau], [DiaChi], [SDT], [Email], [NgayDangKi], [SoTienDaNap], [GhiChu]) VALUES (4, N'chiến', N'chien', N'1', N'hưng yên', N'1111111111', N'chien@gmail.com', CAST(N'2016-04-20 00:00:00.000' AS DateTime), 43413134234, NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoTen], [TenDangNhap], [MatKhau], [DiaChi], [SDT], [Email], [NgayDangKi], [SoTienDaNap], [GhiChu]) VALUES (5, N'đồng', N'dong', N'1', N'hưng yên', N'8374658734', N'adasd@gmail.com', CAST(N'2016-04-20 00:00:00.000' AS DateTime), 43413134234, NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoTen], [TenDangNhap], [MatKhau], [DiaChi], [SDT], [Email], [NgayDangKi], [SoTienDaNap], [GhiChu]) VALUES (6, N'abc', N'abc', N'1', N'Hưng Yên', N'2222222222', N'abc@gmail.com', CAST(N'2016-04-28 00:00:00.000' AS DateTime), 21321312323, NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoTen], [TenDangNhap], [MatKhau], [DiaChi], [SDT], [Email], [NgayDangKi], [SoTienDaNap], [GhiChu]) VALUES (7, N'hhh', N'123', N'a', N'w', N'4444444444', N'a@gmail.com', CAST(N'2016-05-07 00:00:00.000' AS DateTime), 1234324342, NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoTen], [TenDangNhap], [MatKhau], [DiaChi], [SDT], [Email], [NgayDangKi], [SoTienDaNap], [GhiChu]) VALUES (8, N'hhh', N'h', N'1', N'w', N'4444444444', N'a@gmail.com', CAST(N'2016-05-07 00:00:00.000' AS DateTime), 23424324234, NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [HoTen], [TenDangNhap], [MatKhau], [DiaChi], [SDT], [Email], [NgayDangKi], [SoTienDaNap], [GhiChu]) VALUES (9, N'Nguyễn Chí ĐƯợc', N'duoc', N'1', N'Yên Bái', N'5555555555', N'duoc@gmail.com', CAST(N'2016-05-13 00:00:00.000' AS DateTime), 23424242343, N'aa')
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
SET IDENTITY_INSERT [dbo].[NhanVien] ON 

INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [TenDangNhap], [MatKhau], [SDT], [Email], [Image], [TrangThai], [QuyenHan], [GhiChu]) VALUES (1, N'Nguyễn Việt Anh', N'vietanh', N'123456', N'0981995162', N'vietanhit95@gmail.com', NULL, N'VIP', N'Admin', N'VIP')
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [TenDangNhap], [MatKhau], [SDT], [Email], [Image], [TrangThai], [QuyenHan], [GhiChu]) VALUES (2, N'Nguyễn Chí Được', N'vietanh', N'123456', N'0914876283', N'chiduoc@gmail.com', N'1926979_436327899830701_1165496111_n.jpg', N'VIP', N'Nhan Vien', N'Đã Bổ Nhiệm')
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [TenDangNhap], [MatKhau], [SDT], [Email], [Image], [TrangThai], [QuyenHan], [GhiChu]) VALUES (3, N'Hoàng Nhật Nam', N'nhatnam123', N'123456', N'0981995162', N'nhatnam@gmail.com', N'1536473_370249959784271_703657364_n (1).jpg', N'Co', N'Admin', N'Đã Bổ Nhiệm')
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [TenDangNhap], [MatKhau], [SDT], [Email], [Image], [TrangThai], [QuyenHan], [GhiChu]) VALUES (4, N'Nguyễn Hoàng Anh', N'hoanganhcntt', N'123456', N'099999999', N'hoanganh@gmail.com', N'1896763_370249639784303_111600302_n.jpg', N'Co', N'Admin', N'Đã Bổ Nhiệm')
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [TenDangNhap], [MatKhau], [SDT], [Email], [Image], [TrangThai], [QuyenHan], [GhiChu]) VALUES (5, N'Nguyễn Cẩm Tú', N'camtu', N'123456', N'0988675432', N'camtu@gmail.com', N'1896763_370249639784303_111600302_n.jpg', N'Co', N'Admin', N'Đã Bổ Nhiệm')
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [TenDangNhap], [MatKhau], [SDT], [Email], [Image], [TrangThai], [QuyenHan], [GhiChu]) VALUES (6, N'Nguyễn Nam Cường', N'cuongnguyen', N'12345', N'0999999999', N'cuongnguyen@gmail.com', N'1655888_370249883117612_1795812555_n (1).jpg', N'Co', N'Nhan Vien', N'Đã Bổ Nhiệm')
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [TenDangNhap], [MatKhau], [SDT], [Email], [Image], [TrangThai], [QuyenHan], [GhiChu]) VALUES (7, N'Nguyễn Thị Hằng', N'hangthi', N'123456', N'0912786456', N'hangthi@gmail.com', N'1536473_370249959784271_703657364_n (1).jpg', N'Co', N'Admin', N'Đã Bổ Nhiệm')
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [TenDangNhap], [MatKhau], [SDT], [Email], [Image], [TrangThai], [QuyenHan], [GhiChu]) VALUES (8, N'Hoàng Minh Trí', N'minhtri', N'12345', N'0999999999', N'minhtri@gmail.com', N'1536473_370249959784271_703657364_n (1).jpg', N'Co', N'Admin', N'Đã Bổ Nhiệm')
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [TenDangNhap], [MatKhau], [SDT], [Email], [Image], [TrangThai], [QuyenHan], [GhiChu]) VALUES (9, N'Nguyễn Thùy Linh', N'thuylinh', N'12345', N'0969177225', N'thuylinh@gmail.com', N'1896763_370249639784303_111600302_n.jpg', N'Co', N'Admin', N'Đã Bổ Nhiệm')
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [TenDangNhap], [MatKhau], [SDT], [Email], [Image], [TrangThai], [QuyenHan], [GhiChu]) VALUES (10, N'Nguyễn Minh Nhật', N'minhnha', N'12345', N'0969177225', N'minhnhat@gmail.com', N'1911688_370244619784805_1245894383_n.jpg', N'Co', N'Admin', N'Đã Bổ Nhiệm')
SET IDENTITY_INSERT [dbo].[NhanVien] OFF
SET IDENTITY_INSERT [dbo].[NhomSanPham] ON 

INSERT [dbo].[NhomSanPham] ([MaNhomSanPham], [TenNhomSanPham], [Image], [MoTa]) VALUES (1, N'Ô tô', NULL, N'phương tiện di chuyển')
INSERT [dbo].[NhomSanPham] ([MaNhomSanPham], [TenNhomSanPham], [Image], [MoTa]) VALUES (2, N'Xe máy', NULL, N'phương tiện di chuyển')
INSERT [dbo].[NhomSanPham] ([MaNhomSanPham], [TenNhomSanPham], [Image], [MoTa]) VALUES (3, N'Điện thoại', NULL, N'Công nghệ')
INSERT [dbo].[NhomSanPham] ([MaNhomSanPham], [TenNhomSanPham], [Image], [MoTa]) VALUES (4, N'Nhà đất', NULL, N'bất động sản')
INSERT [dbo].[NhomSanPham] ([MaNhomSanPham], [TenNhomSanPham], [Image], [MoTa]) VALUES (5, N'Đồ gia dụng', NULL, N'đồ gia dụng')
INSERT [dbo].[NhomSanPham] ([MaNhomSanPham], [TenNhomSanPham], [Image], [MoTa]) VALUES (6, N'Đồ nội thất', NULL, N'đồ nội thất')
INSERT [dbo].[NhomSanPham] ([MaNhomSanPham], [TenNhomSanPham], [Image], [MoTa]) VALUES (7, N'Phụ kiện', NULL, N'phụ kiện')
INSERT [dbo].[NhomSanPham] ([MaNhomSanPham], [TenNhomSanPham], [Image], [MoTa]) VALUES (8, N'Linh tinh', NULL, N'gì cũng có')
SET IDENTITY_INSERT [dbo].[NhomSanPham] OFF
SET IDENTITY_INSERT [dbo].[VungMien] ON 

INSERT [dbo].[VungMien] ([MaVungMien], [TenVungMien]) VALUES (1, N'Hà Nội')
INSERT [dbo].[VungMien] ([MaVungMien], [TenVungMien]) VALUES (2, N'TP Hồ Chí Minh')
INSERT [dbo].[VungMien] ([MaVungMien], [TenVungMien]) VALUES (3, N'Hưng Yên')
INSERT [dbo].[VungMien] ([MaVungMien], [TenVungMien]) VALUES (4, N'Đà Nẵng')
INSERT [dbo].[VungMien] ([MaVungMien], [TenVungMien]) VALUES (5, N'Tây Nguyên')
INSERT [dbo].[VungMien] ([MaVungMien], [TenVungMien]) VALUES (6, N'Quảng Ninh')
INSERT [dbo].[VungMien] ([MaVungMien], [TenVungMien]) VALUES (7, N'Hải Dương')
INSERT [dbo].[VungMien] ([MaVungMien], [TenVungMien]) VALUES (8, N'Hà Nội')
INSERT [dbo].[VungMien] ([MaVungMien], [TenVungMien]) VALUES (9, N'Vũng Tàu')
INSERT [dbo].[VungMien] ([MaVungMien], [TenVungMien]) VALUES (10, N'Nha Trang ')
SET IDENTITY_INSERT [dbo].[VungMien] OFF
ALTER TABLE [dbo].[BaiViet]  WITH CHECK ADD  CONSTRAINT [FK_BaiViet_ChuyenMuc] FOREIGN KEY([MaChuyenMuc])
REFERENCES [dbo].[ChuyenMuc] ([MaChuyenMuc])
GO
ALTER TABLE [dbo].[BaiViet] CHECK CONSTRAINT [FK_BaiViet_ChuyenMuc]
GO
ALTER TABLE [dbo].[BaiViet]  WITH CHECK ADD  CONSTRAINT [FK_BaiViet_KhachHang] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([MaKhachHang])
GO
ALTER TABLE [dbo].[BaiViet] CHECK CONSTRAINT [FK_BaiViet_KhachHang]
GO
ALTER TABLE [dbo].[BaiViet]  WITH CHECK ADD  CONSTRAINT [FK_BaiViet_NhomSanPham] FOREIGN KEY([MaNhomSanPham])
REFERENCES [dbo].[NhomSanPham] ([MaNhomSanPham])
GO
ALTER TABLE [dbo].[BaiViet] CHECK CONSTRAINT [FK_BaiViet_NhomSanPham]
GO
ALTER TABLE [dbo].[BaiViet]  WITH CHECK ADD  CONSTRAINT [FK_BaiViet_VungMien] FOREIGN KEY([MaVungMien])
REFERENCES [dbo].[VungMien] ([MaVungMien])
GO
ALTER TABLE [dbo].[BaiViet] CHECK CONSTRAINT [FK_BaiViet_VungMien]
GO
ALTER TABLE [dbo].[HoaDonDangTin]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonDangTin_KhachHang] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([MaKhachHang])
GO
ALTER TABLE [dbo].[HoaDonDangTin] CHECK CONSTRAINT [FK_HoaDonDangTin_KhachHang]
GO
ALTER TABLE [dbo].[HoaDonNapTien]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonNapTien_KhachHang] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([MaKhachHang])
GO
ALTER TABLE [dbo].[HoaDonNapTien] CHECK CONSTRAINT [FK_HoaDonNapTien_KhachHang]
GO
USE [master]
GO
ALTER DATABASE [DoAn4] SET  READ_WRITE 
GO
