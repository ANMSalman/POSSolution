USE [SharmilaTexDatabase]
GO
/****** Object:  Table [dbo].[User]    Script Date: 08/02/2018 08:56:42 ******/
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
/****** Object:  Table [dbo].[Staff]    Script Date: 08/02/2018 08:56:42 ******/
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
/****** Object:  Table [dbo].[Item]    Script Date: 08/02/2018 08:56:42 ******/
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
/****** Object:  Table [dbo].[Expense]    Script Date: 08/02/2018 08:56:42 ******/
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
/****** Object:  Table [dbo].[Customer]    Script Date: 08/02/2018 08:56:42 ******/
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
/****** Object:  Table [dbo].[Bill]    Script Date: 08/02/2018 08:56:42 ******/
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
/****** Object:  Table [dbo].[BillReturnItem]    Script Date: 08/02/2018 08:56:42 ******/
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
/****** Object:  Table [dbo].[BillItem]    Script Date: 08/02/2018 08:56:42 ******/
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
/****** Object:  ForeignKey [FK_Bill_Customer]    Script Date: 08/02/2018 08:56:42 ******/
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_Bill_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_Bill_Customer]
GO
/****** Object:  ForeignKey [FK_Bill_Staff]    Script Date: 08/02/2018 08:56:42 ******/
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_Bill_Staff] FOREIGN KEY([ShownBy])
REFERENCES [dbo].[Staff] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_Bill_Staff]
GO
/****** Object:  ForeignKey [FK_Bill_User]    Script Date: 08/02/2018 08:56:42 ******/
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_Bill_User] FOREIGN KEY([BilledBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_Bill_User]
GO
/****** Object:  ForeignKey [FK_BillItem_Bill]    Script Date: 08/02/2018 08:56:42 ******/
ALTER TABLE [dbo].[BillItem]  WITH CHECK ADD  CONSTRAINT [FK_BillItem_Bill] FOREIGN KEY([BillId])
REFERENCES [dbo].[Bill] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BillItem] CHECK CONSTRAINT [FK_BillItem_Bill]
GO
/****** Object:  ForeignKey [FK_BillReturnItem_Bill]    Script Date: 08/02/2018 08:56:42 ******/
ALTER TABLE [dbo].[BillReturnItem]  WITH CHECK ADD  CONSTRAINT [FK_BillReturnItem_Bill] FOREIGN KEY([BillId])
REFERENCES [dbo].[Bill] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BillReturnItem] CHECK CONSTRAINT [FK_BillReturnItem_Bill]
GO
/****** Object:  ForeignKey [FK_Customer_User]    Script Date: 08/02/2018 08:56:42 ******/
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_User] FOREIGN KEY([AddedBy])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_User]
GO
/****** Object:  ForeignKey [FK_Expense_User]    Script Date: 08/02/2018 08:56:42 ******/
ALTER TABLE [dbo].[Expense]  WITH CHECK ADD  CONSTRAINT [FK_Expense_User] FOREIGN KEY([AddedBy])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Expense] CHECK CONSTRAINT [FK_Expense_User]
GO
