USE [ShopBridgeInventoryDB]
GO
/****** Object:  Table [dbo].[ShopBridge]    Script Date: 03/29/2021 23:20:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShopBridge](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[Description] [nvarchar](500) NULL,
	[Price] [float] NULL,
	[Qty] [int] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_ShopBridge] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ShopBridge] ON
INSERT [dbo].[ShopBridge] ([Id], [Name], [Description], [Price], [Qty], [Status]) VALUES (1, N'Tube Lights', N'This is a good brand surya.', 25000, 1500, 1)
INSERT [dbo].[ShopBridge] ([Id], [Name], [Description], [Price], [Qty], [Status]) VALUES (2, N'Bulb', N'This is good Brand Phillips.', 10000, 1580, 0)
SET IDENTITY_INSERT [dbo].[ShopBridge] OFF
