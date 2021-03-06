USE [master]
GO
/****** Object:  Database [SharmilaTexDB]    Script Date: 08/02/2018 08:59:04 ******/
CREATE DATABASE [SharmilaTexDB] ON  PRIMARY 
( NAME = N'SharmilaTexDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\SharmilaTexDB.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SharmilaTexDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\SharmilaTexDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SharmilaTexDB] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SharmilaTexDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SharmilaTexDB] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [SharmilaTexDB] SET ANSI_NULLS OFF
GO
ALTER DATABASE [SharmilaTexDB] SET ANSI_PADDING OFF
GO
ALTER DATABASE [SharmilaTexDB] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [SharmilaTexDB] SET ARITHABORT OFF
GO
ALTER DATABASE [SharmilaTexDB] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [SharmilaTexDB] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [SharmilaTexDB] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [SharmilaTexDB] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [SharmilaTexDB] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [SharmilaTexDB] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [SharmilaTexDB] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [SharmilaTexDB] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [SharmilaTexDB] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [SharmilaTexDB] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [SharmilaTexDB] SET  DISABLE_BROKER
GO
ALTER DATABASE [SharmilaTexDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [SharmilaTexDB] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [SharmilaTexDB] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [SharmilaTexDB] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [SharmilaTexDB] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [SharmilaTexDB] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [SharmilaTexDB] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [SharmilaTexDB] SET  READ_WRITE
GO
ALTER DATABASE [SharmilaTexDB] SET RECOVERY FULL
GO
ALTER DATABASE [SharmilaTexDB] SET  MULTI_USER
GO
ALTER DATABASE [SharmilaTexDB] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [SharmilaTexDB] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'SharmilaTexDB', N'ON'
GO
USE [SharmilaTexDB]
GO
/****** Object:  Table [dbo].[User]    Script Date: 08/02/2018 08:59:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(100,1) NOT NULL,
	[Name] [nvarchar](25) NOT NULL,
	[Type] [nvarchar](7) NOT NULL,
	[Password] [nvarchar](12) NOT NULL,
	[Status] [nvarchar](8) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 08/02/2018 08:59:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](100) NULL,
	[Phone] [nchar](10) NULL,
	[AccountName] [nvarchar](70) NULL,
	[AccountNo] [nvarchar](30) NULL,
	[Bank] [nvarchar](30) NULL,
	[Branch] [nvarchar](30) NULL,
	[InitialBalance] [float] NOT NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 08/02/2018 08:59:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](40) NOT NULL,
	[Phone] [nchar](10) NULL,
	[NIC] [nvarchar](12) NULL,
	[Address] [nvarchar](100) NULL,
	[Status] [nvarchar](8) NOT NULL,
 CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Item]    Script Date: 08/02/2018 08:59:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Item](
	[Name] [nvarchar](30) NOT NULL,
	[Category] [nvarchar](7) NOT NULL,
	[Status] [nvarchar](8) NOT NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentBill]    Script Date: 08/02/2018 08:59:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentBill](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[SupplierId] [int] NULL,
	[SubTotal] [float] NOT NULL,
	[Discount] [float] NOT NULL,
	[ReturnAmount] [float] NOT NULL,
	[NetTotal] [float] NOT NULL,
	[BilledBy] [int] NOT NULL,
	[ShownBy] [int] NOT NULL,
 CONSTRAINT [PK_PaymentBill] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Purchase]    Script Date: 08/02/2018 08:59:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purchase](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SupplierId] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[Amount] [float] NOT NULL,
 CONSTRAINT [PK_Purchase] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Expense]    Script Date: 08/02/2018 08:59:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Expense](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[Amount] [float] NOT NULL,
	[AddedBy] [int] NOT NULL,
 CONSTRAINT [PK_Expense] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 08/02/2018 08:59:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(100,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](100) NULL,
	[Phone] [nchar](10) NULL,
	[NIC] [nvarchar](12) NULL,
	[InitialBalance] [float] NOT NULL,
	[AddedBy] [int] NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Normal]    Script Date: 08/02/2018 08:59:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Normal](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[CustomerId] [int] NULL,
	[SubTotal] [float] NOT NULL,
	[Discount] [float] NOT NULL,
	[ReturnAmount] [float] NOT NULL,
	[NetTotal] [float] NOT NULL,
	[CashAmount] [float] NOT NULL,
	[ChequeAmount] [float] NOT NULL,
	[PaidAmount] [float] NOT NULL,
	[Balance] [float] NOT NULL,
	[BilledBy] [int] NOT NULL,
	[ShownBy] [int] NOT NULL,
 CONSTRAINT [PK_Normal] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 08/02/2018 08:59:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[CustomerId] [int] NULL,
	[SubTotal] [float] NOT NULL,
	[Discount] [float] NOT NULL,
	[ReturnAmount] [float] NOT NULL,
	[NetTotal] [float] NOT NULL,
	[CashAmount] [float] NOT NULL,
	[ChequeAmount] [float] NOT NULL,
	[PaidAmount] [float] NOT NULL,
	[BilledBy] [int] NOT NULL,
	[ShownBy] [int] NOT NULL,
 CONSTRAINT [PK_BTT] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentBillReturnItem]    Script Date: 08/02/2018 08:59:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentBillReturnItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PaymentBillId] [int] NOT NULL,
	[QTY] [int] NOT NULL,
	[ItemName] [nvarchar](30) NOT NULL,
	[UnitPrice] [float] NOT NULL,
	[SubTotal] [float] NOT NULL,
	[Discount] [float] NOT NULL,
	[NetTotal] [float] NOT NULL,
 CONSTRAINT [PK_PaymentBillReturnItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentBillItem]    Script Date: 08/02/2018 08:59:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentBillItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PaymentBillId] [int] NOT NULL,
	[QTY] [int] NOT NULL,
	[ItemName] [nvarchar](30) NOT NULL,
	[UnitPrice] [float] NOT NULL,
	[SubTotal] [float] NOT NULL,
	[Discount] [float] NOT NULL,
	[NetTotal] [float] NOT NULL,
 CONSTRAINT [PK_PaymentBillItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReturnBill]    Script Date: 08/02/2018 08:59:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReturnBill](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Type] [nvarchar](10) NOT NULL,
	[CustomerId] [int] NULL,
	[SupplierId] [int] NULL,
	[SubTotal] [float] NOT NULL,
	[Discount] [float] NOT NULL,
	[NetTotal] [float] NULL,
	[BilledBy] [int] NOT NULL,
	[ShownBy] [int] NOT NULL,
 CONSTRAINT [PK_ReturnBill] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 08/02/2018 08:59:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SupplierId] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[Type] [nvarchar](12) NOT NULL,
	[Cash] [float] NOT NULL,
	[Cheque] [float] NOT NULL,
	[Total] [float] NOT NULL,
	[PaymentBillId] [int] NULL,
	[ReturnBillId] [int] NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NormalReturnItem]    Script Date: 08/02/2018 08:59:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NormalReturnItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BillId] [int] NOT NULL,
	[QTY] [int] NOT NULL,
	[ItemName] [nvarchar](30) NOT NULL,
	[UnitPrice] [float] NOT NULL,
	[SubTotal] [float] NOT NULL,
	[Discount] [float] NOT NULL,
	[NetTotal] [float] NOT NULL,
 CONSTRAINT [PK_NormalReturnItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NormalItem]    Script Date: 08/02/2018 08:59:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NormalItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BillId] [int] NOT NULL,
	[QTY] [int] NOT NULL,
	[ItemName] [nvarchar](30) NOT NULL,
	[UnitPrice] [float] NOT NULL,
	[SubTotal] [float] NOT NULL,
	[Discount] [float] NOT NULL,
	[NetTotal] [float] NOT NULL,
 CONSTRAINT [PK_NormalItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReturnBillItem]    Script Date: 08/02/2018 08:59:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReturnBillItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReturnBillId] [int] NOT NULL,
	[QTY] [int] NOT NULL,
	[ItemName] [nvarchar](30) NOT NULL,
	[UnitPrice] [float] NOT NULL,
	[SubTotal] [float] NOT NULL,
	[Discount] [float] NOT NULL,
	[NetTotal] [float] NOT NULL,
 CONSTRAINT [PK_ReturnBillItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BillReturnItem]    Script Date: 08/02/2018 08:59:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillReturnItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BillId] [int] NOT NULL,
	[QTY] [int] NOT NULL,
	[ItemName] [nvarchar](30) NOT NULL,
	[UnitPrice] [float] NOT NULL,
	[SubTotal] [float] NOT NULL,
	[Discount] [float] NOT NULL,
	[NetTotal] [float] NOT NULL,
 CONSTRAINT [PK_BTTReturnItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BillItem]    Script Date: 08/02/2018 08:59:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BillId] [int] NOT NULL,
	[QTY] [int] NOT NULL,
	[ItemName] [nvarchar](30) NOT NULL,
	[UnitPrice] [float] NOT NULL,
	[SubTotal] [float] NOT NULL,
	[Discount] [float] NOT NULL,
	[NetTotal] [float] NOT NULL,
 CONSTRAINT [PK_BTTItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Credit]    Script Date: 08/02/2018 08:59:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Credit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[BillId] [int] NOT NULL,
	[Amount] [float] NOT NULL,
 CONSTRAINT [PK_Credit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Collection]    Script Date: 08/02/2018 08:59:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Collection](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[Type] [nvarchar](12) NOT NULL,
	[Cash] [float] NOT NULL,
	[Cheque] [float] NOT NULL,
	[Total] [float] NOT NULL,
	[ReturnBillId] [int] NULL,
 CONSTRAINT [PK_Collection] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cheque]    Script Date: 08/02/2018 08:59:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cheque](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AddedDate] [date] NOT NULL,
	[Number] [nvarchar](15) NOT NULL,
	[Bank] [nvarchar](50) NOT NULL,
	[Branch] [nvarchar](50) NOT NULL,
	[Amount] [float] NOT NULL,
	[Date] [date] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[Description] [nvarchar](150) NULL,
	[PaymentId] [int] NULL,
	[Status] [nvarchar](8) NOT NULL,
 CONSTRAINT [PK_Cheque] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_PaymentBill_Staff]    Script Date: 08/02/2018 08:59:06 ******/
ALTER TABLE [dbo].[PaymentBill]  WITH CHECK ADD  CONSTRAINT [FK_PaymentBill_Staff] FOREIGN KEY([ShownBy])
REFERENCES [dbo].[Staff] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PaymentBill] CHECK CONSTRAINT [FK_PaymentBill_Staff]
GO
/****** Object:  ForeignKey [FK_PaymentBill_Supplier]    Script Date: 08/02/2018 08:59:06 ******/
ALTER TABLE [dbo].[PaymentBill]  WITH CHECK ADD  CONSTRAINT [FK_PaymentBill_Supplier] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Supplier] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PaymentBill] CHECK CONSTRAINT [FK_PaymentBill_Supplier]
GO
/****** Object:  ForeignKey [FK_PaymentBill_User]    Script Date: 08/02/2018 08:59:06 ******/
ALTER TABLE [dbo].[PaymentBill]  WITH CHECK ADD  CONSTRAINT [FK_PaymentBill_User] FOREIGN KEY([BilledBy])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PaymentBill] CHECK CONSTRAINT [FK_PaymentBill_User]
GO
/****** Object:  ForeignKey [FK_Purchase_Supplier]    Script Date: 08/02/2018 08:59:06 ******/
ALTER TABLE [dbo].[Purchase]  WITH CHECK ADD  CONSTRAINT [FK_Purchase_Supplier] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Supplier] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Purchase] CHECK CONSTRAINT [FK_Purchase_Supplier]
GO
/****** Object:  ForeignKey [FK_Expense_User]    Script Date: 08/02/2018 08:59:06 ******/
ALTER TABLE [dbo].[Expense]  WITH CHECK ADD  CONSTRAINT [FK_Expense_User] FOREIGN KEY([AddedBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Expense] CHECK CONSTRAINT [FK_Expense_User]
GO
/****** Object:  ForeignKey [FK_Customer_User]    Script Date: 08/02/2018 08:59:06 ******/
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_User] FOREIGN KEY([AddedBy])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_User]
GO
/****** Object:  ForeignKey [FK_Normal_Customer]    Script Date: 08/02/2018 08:59:06 ******/
ALTER TABLE [dbo].[Normal]  WITH CHECK ADD  CONSTRAINT [FK_Normal_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Normal] CHECK CONSTRAINT [FK_Normal_Customer]
GO
/****** Object:  ForeignKey [FK_Normal_Staff]    Script Date: 08/02/2018 08:59:06 ******/
ALTER TABLE [dbo].[Normal]  WITH CHECK ADD  CONSTRAINT [FK_Normal_Staff] FOREIGN KEY([ShownBy])
REFERENCES [dbo].[Staff] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Normal] CHECK CONSTRAINT [FK_Normal_Staff]
GO
/****** Object:  ForeignKey [FK_Normal_User]    Script Date: 08/02/2018 08:59:06 ******/
ALTER TABLE [dbo].[Normal]  WITH CHECK ADD  CONSTRAINT [FK_Normal_User] FOREIGN KEY([BilledBy])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Normal] CHECK CONSTRAINT [FK_Normal_User]
GO
/****** Object:  ForeignKey [FK_Bill_Customer]    Script Date: 08/02/2018 08:59:06 ******/
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_Bill_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_Bill_Customer]
GO
/****** Object:  ForeignKey [FK_Bill_Staff]    Script Date: 08/02/2018 08:59:06 ******/
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_Bill_Staff] FOREIGN KEY([ShownBy])
REFERENCES [dbo].[Staff] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_Bill_Staff]
GO
/****** Object:  ForeignKey [FK_Bill_User]    Script Date: 08/02/2018 08:59:06 ******/
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_Bill_User] FOREIGN KEY([BilledBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_Bill_User]
GO
/****** Object:  ForeignKey [FK_PaymentBillReturnItem_PaymentBill]    Script Date: 08/02/2018 08:59:06 ******/
ALTER TABLE [dbo].[PaymentBillReturnItem]  WITH CHECK ADD  CONSTRAINT [FK_PaymentBillReturnItem_PaymentBill] FOREIGN KEY([PaymentBillId])
REFERENCES [dbo].[PaymentBill] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PaymentBillReturnItem] CHECK CONSTRAINT [FK_PaymentBillReturnItem_PaymentBill]
GO
/****** Object:  ForeignKey [FK_PaymentBillItem_PaymentBill]    Script Date: 08/02/2018 08:59:06 ******/
ALTER TABLE [dbo].[PaymentBillItem]  WITH CHECK ADD  CONSTRAINT [FK_PaymentBillItem_PaymentBill] FOREIGN KEY([PaymentBillId])
REFERENCES [dbo].[PaymentBill] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PaymentBillItem] CHECK CONSTRAINT [FK_PaymentBillItem_PaymentBill]
GO
/****** Object:  ForeignKey [FK_ReturnBill_Customer]    Script Date: 08/02/2018 08:59:06 ******/
ALTER TABLE [dbo].[ReturnBill]  WITH CHECK ADD  CONSTRAINT [FK_ReturnBill_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ReturnBill] CHECK CONSTRAINT [FK_ReturnBill_Customer]
GO
/****** Object:  ForeignKey [FK_ReturnBill_Staff]    Script Date: 08/02/2018 08:59:06 ******/
ALTER TABLE [dbo].[ReturnBill]  WITH CHECK ADD  CONSTRAINT [FK_ReturnBill_Staff] FOREIGN KEY([ShownBy])
REFERENCES [dbo].[Staff] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ReturnBill] CHECK CONSTRAINT [FK_ReturnBill_Staff]
GO
/****** Object:  ForeignKey [FK_ReturnBill_Supplier]    Script Date: 08/02/2018 08:59:06 ******/
ALTER TABLE [dbo].[ReturnBill]  WITH CHECK ADD  CONSTRAINT [FK_ReturnBill_Supplier] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Supplier] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ReturnBill] CHECK CONSTRAINT [FK_ReturnBill_Supplier]
GO
/****** Object:  ForeignKey [FK_ReturnBill_User]    Script Date: 08/02/2018 08:59:06 ******/
ALTER TABLE [dbo].[ReturnBill]  WITH CHECK ADD  CONSTRAINT [FK_ReturnBill_User] FOREIGN KEY([BilledBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[ReturnBill] CHECK CONSTRAINT [FK_ReturnBill_User]
GO
/****** Object:  ForeignKey [FK_Payment_PaymentBill]    Script Date: 08/02/2018 08:59:06 ******/
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_PaymentBill] FOREIGN KEY([PaymentBillId])
REFERENCES [dbo].[PaymentBill] ([Id])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_PaymentBill]
GO
/****** Object:  ForeignKey [FK_Payment_ReturnBill]    Script Date: 08/02/2018 08:59:06 ******/
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_ReturnBill] FOREIGN KEY([ReturnBillId])
REFERENCES [dbo].[ReturnBill] ([Id])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_ReturnBill]
GO
/****** Object:  ForeignKey [FK_Payment_Supplier]    Script Date: 08/02/2018 08:59:06 ******/
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Supplier] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Supplier] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_Supplier]
GO
/****** Object:  ForeignKey [FK_NormalReturnItem_Normal]    Script Date: 08/02/2018 08:59:06 ******/
ALTER TABLE [dbo].[NormalReturnItem]  WITH CHECK ADD  CONSTRAINT [FK_NormalReturnItem_Normal] FOREIGN KEY([BillId])
REFERENCES [dbo].[Normal] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NormalReturnItem] CHECK CONSTRAINT [FK_NormalReturnItem_Normal]
GO
/****** Object:  ForeignKey [FK_NormalItem_Normal]    Script Date: 08/02/2018 08:59:06 ******/
ALTER TABLE [dbo].[NormalItem]  WITH CHECK ADD  CONSTRAINT [FK_NormalItem_Normal] FOREIGN KEY([BillId])
REFERENCES [dbo].[Normal] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NormalItem] CHECK CONSTRAINT [FK_NormalItem_Normal]
GO
/****** Object:  ForeignKey [FK_ReturnBillItem_ReturnBill]    Script Date: 08/02/2018 08:59:06 ******/
ALTER TABLE [dbo].[ReturnBillItem]  WITH CHECK ADD  CONSTRAINT [FK_ReturnBillItem_ReturnBill] FOREIGN KEY([ReturnBillId])
REFERENCES [dbo].[ReturnBill] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ReturnBillItem] CHECK CONSTRAINT [FK_ReturnBillItem_ReturnBill]
GO
/****** Object:  ForeignKey [FK_BillReturnItem_Bill]    Script Date: 08/02/2018 08:59:06 ******/
ALTER TABLE [dbo].[BillReturnItem]  WITH CHECK ADD  CONSTRAINT [FK_BillReturnItem_Bill] FOREIGN KEY([BillId])
REFERENCES [dbo].[Bill] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BillReturnItem] CHECK CONSTRAINT [FK_BillReturnItem_Bill]
GO
/****** Object:  ForeignKey [FK_BillItem_Bill]    Script Date: 08/02/2018 08:59:06 ******/
ALTER TABLE [dbo].[BillItem]  WITH CHECK ADD  CONSTRAINT [FK_BillItem_Bill] FOREIGN KEY([BillId])
REFERENCES [dbo].[Bill] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BillItem] CHECK CONSTRAINT [FK_BillItem_Bill]
GO
/****** Object:  ForeignKey [FK_Credit_Customer]    Script Date: 08/02/2018 08:59:06 ******/
ALTER TABLE [dbo].[Credit]  WITH CHECK ADD  CONSTRAINT [FK_Credit_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Credit] CHECK CONSTRAINT [FK_Credit_Customer]
GO
/****** Object:  ForeignKey [FK_Credit_Normal]    Script Date: 08/02/2018 08:59:06 ******/
ALTER TABLE [dbo].[Credit]  WITH CHECK ADD  CONSTRAINT [FK_Credit_Normal] FOREIGN KEY([BillId])
REFERENCES [dbo].[Normal] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Credit] CHECK CONSTRAINT [FK_Credit_Normal]
GO
/****** Object:  ForeignKey [FK_Collection_Customer]    Script Date: 08/02/2018 08:59:06 ******/
ALTER TABLE [dbo].[Collection]  WITH CHECK ADD  CONSTRAINT [FK_Collection_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Collection] CHECK CONSTRAINT [FK_Collection_Customer]
GO
/****** Object:  ForeignKey [FK_Collection_ReturnBill]    Script Date: 08/02/2018 08:59:06 ******/
ALTER TABLE [dbo].[Collection]  WITH CHECK ADD  CONSTRAINT [FK_Collection_ReturnBill] FOREIGN KEY([ReturnBillId])
REFERENCES [dbo].[ReturnBill] ([Id])
GO
ALTER TABLE [dbo].[Collection] CHECK CONSTRAINT [FK_Collection_ReturnBill]
GO
/****** Object:  ForeignKey [FK_Cheque_Customer]    Script Date: 08/02/2018 08:59:06 ******/
ALTER TABLE [dbo].[Cheque]  WITH CHECK ADD  CONSTRAINT [FK_Cheque_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cheque] CHECK CONSTRAINT [FK_Cheque_Customer]
GO
/****** Object:  ForeignKey [FK_Cheque_Payment]    Script Date: 08/02/2018 08:59:06 ******/
ALTER TABLE [dbo].[Cheque]  WITH CHECK ADD  CONSTRAINT [FK_Cheque_Payment] FOREIGN KEY([PaymentId])
REFERENCES [dbo].[Payment] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cheque] CHECK CONSTRAINT [FK_Cheque_Payment]
GO
