USE [dsr_betalling]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 01-12-2016 10:33:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AccountHolderName] [nvarchar](100) NOT NULL,
	[Balance] [money] NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Activity]    Script Date: 01-12-2016 10:33:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Activity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Activity] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ActivityLog]    Script Date: 01-12-2016 10:33:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActivityLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FK_Activity] [int] NOT NULL,
	[FK_Account] [int] NOT NULL,
	[FK_User] [int] NOT NULL,
	[Amount] [money] NOT NULL,
	[Created] [datetime] NULL,
 CONSTRAINT [PK_ActivityLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Chip]    Script Date: 01-12-2016 10:33:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chip](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ChipId] [nvarchar](50) NOT NULL,
	[FK_Account] [int] NOT NULL,
 CONSTRAINT [PK_Chip] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 01-12-2016 10:33:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[ProductPrice] [money] NOT NULL,
	[Rebate] [money] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Purchase]    Script Date: 01-12-2016 10:33:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purchase](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FK_Account] [int] NOT NULL,
	[FK_User] [int] NOT NULL,
	[TotalPrice] [money] NOT NULL,
	[Created] [datetime] NULL,
 CONSTRAINT [PK_Purchase] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PurchaseItems]    Script Date: 01-12-2016 10:33:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FK_Purchase] [int] NOT NULL,
	[FK_Product] [int] NOT NULL,
	[Amount] [int] NOT NULL,
	[Price] [money] NOT NULL,
 CONSTRAINT [PK_PurchaseItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 01-12-2016 10:33:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Account] ON 

GO
INSERT [dbo].[Account] ([Id], [AccountHolderName], [Balance]) VALUES (1, N'Test', 1000.0000)
GO
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[Chip] ON 

GO
INSERT [dbo].[Chip] ([Id], [ChipId], [FK_Account]) VALUES (1, N'TEST000001', 1)
GO
SET IDENTITY_INSERT [dbo].[Chip] OFF
GO
ALTER TABLE [dbo].[ActivityLog]  WITH CHECK ADD  CONSTRAINT [FK_ActivityLog_Account] FOREIGN KEY([FK_Account])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[ActivityLog] CHECK CONSTRAINT [FK_ActivityLog_Account]
GO
ALTER TABLE [dbo].[ActivityLog]  WITH CHECK ADD  CONSTRAINT [FK_ActivityLog_Activity] FOREIGN KEY([FK_Activity])
REFERENCES [dbo].[Activity] ([Id])
GO
ALTER TABLE [dbo].[ActivityLog] CHECK CONSTRAINT [FK_ActivityLog_Activity]
GO
ALTER TABLE [dbo].[ActivityLog]  WITH CHECK ADD  CONSTRAINT [FK_ActivityLog_User] FOREIGN KEY([FK_User])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[ActivityLog] CHECK CONSTRAINT [FK_ActivityLog_User]
GO
ALTER TABLE [dbo].[Chip]  WITH CHECK ADD  CONSTRAINT [FK_Chip_Account] FOREIGN KEY([FK_Account])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[Chip] CHECK CONSTRAINT [FK_Chip_Account]
GO
ALTER TABLE [dbo].[Purchase]  WITH CHECK ADD  CONSTRAINT [FK_Purchase_Account] FOREIGN KEY([FK_Account])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[Purchase] CHECK CONSTRAINT [FK_Purchase_Account]
GO
ALTER TABLE [dbo].[Purchase]  WITH CHECK ADD  CONSTRAINT [FK_Purchase_User] FOREIGN KEY([FK_User])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Purchase] CHECK CONSTRAINT [FK_Purchase_User]
GO
ALTER TABLE [dbo].[PurchaseItems]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseItems_Product] FOREIGN KEY([FK_Product])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[PurchaseItems] CHECK CONSTRAINT [FK_PurchaseItems_Product]
GO
ALTER TABLE [dbo].[PurchaseItems]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseItems_Purchase] FOREIGN KEY([FK_Purchase])
REFERENCES [dbo].[Purchase] ([Id])
GO
ALTER TABLE [dbo].[PurchaseItems] CHECK CONSTRAINT [FK_PurchaseItems_Purchase]
GO
