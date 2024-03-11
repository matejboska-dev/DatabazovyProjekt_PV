USE [master]
GO
/****** Object:  Database [boska]    Script Date: 11.03.2024 10:32:26 ******/
CREATE DATABASE [boska]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'boska', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS2019\MSSQL\DATA\boska.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'boska_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS2019\MSSQL\DATA\boska_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [boska] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [boska].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [boska] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [boska] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [boska] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [boska] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [boska] SET ARITHABORT OFF 
GO
ALTER DATABASE [boska] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [boska] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [boska] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [boska] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [boska] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [boska] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [boska] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [boska] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [boska] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [boska] SET  ENABLE_BROKER 
GO
ALTER DATABASE [boska] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [boska] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [boska] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [boska] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [boska] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [boska] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [boska] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [boska] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [boska] SET  MULTI_USER 
GO
ALTER DATABASE [boska] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [boska] SET DB_CHAINING OFF 
GO
ALTER DATABASE [boska] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [boska] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [boska] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [boska] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [boska] SET QUERY_STORE = OFF
GO
USE [boska]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 11.03.2024 10:32:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[customer_id] [int] NOT NULL,
	[first_name] [varchar](255) NULL,
	[last_name] [varchar](255) NULL,
	[email] [varchar](255) NULL,
	[phone_number] [varchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[customer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderItems]    Script Date: 11.03.2024 10:32:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItems](
	[order_item_id] [int] NOT NULL,
	[order_id] [int] NULL,
	[product_id] [int] NULL,
	[quantity] [int] NULL,
	[total_price] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[order_item_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 11.03.2024 10:32:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[order_id] [int] NOT NULL,
	[customer_id] [int] NULL,
	[order_date] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCategories]    Script Date: 11.03.2024 10:32:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategories](
	[category_id] [int] NOT NULL,
	[category_name] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[category_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 11.03.2024 10:32:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[product_id] [int] NOT NULL,
	[product_name] [varchar](255) NULL,
	[price] [float] NULL,
	[stock_quantity] [int] NULL,
	[category_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Customers] ([customer_id], [first_name], [last_name], [email], [phone_number]) VALUES (1, N'John', N'Doe', N'john.doe@example.com', N'+1234567890')
GO
INSERT [dbo].[Customers] ([customer_id], [first_name], [last_name], [email], [phone_number]) VALUES (2, N'Jane', N'Smith', N'jane.smith@example.com', N'+9876543210')
GO
INSERT [dbo].[OrderItems] ([order_item_id], [order_id], [product_id], [quantity], [total_price]) VALUES (1, 1, 1, 2, 1999.98)
GO
INSERT [dbo].[OrderItems] ([order_item_id], [order_id], [product_id], [quantity], [total_price]) VALUES (2, 2, 2, 5, 99.95)
GO
INSERT [dbo].[Orders] ([order_id], [customer_id], [order_date]) VALUES (1, 1, CAST(N'2024-03-09T18:22:02.537' AS DateTime))
GO
INSERT [dbo].[Orders] ([order_id], [customer_id], [order_date]) VALUES (2, 2, CAST(N'2024-03-09T18:22:02.537' AS DateTime))
GO
INSERT [dbo].[ProductCategories] ([category_id], [category_name]) VALUES (1, N'Electronics')
GO
INSERT [dbo].[ProductCategories] ([category_id], [category_name]) VALUES (2, N'Clothing')
GO
INSERT [dbo].[Products] ([product_id], [product_name], [price], [stock_quantity], [category_id]) VALUES (1, N'Laptop', 999.99, 10, 1)
GO
INSERT [dbo].[Products] ([product_id], [product_name], [price], [stock_quantity], [category_id]) VALUES (2, N'T-shirt', 19.99, 50, 2)
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD FOREIGN KEY([order_id])
REFERENCES [dbo].[Orders] ([order_id])
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD FOREIGN KEY([product_id])
REFERENCES [dbo].[Products] ([product_id])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([customer_id])
REFERENCES [dbo].[Customers] ([customer_id])
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD FOREIGN KEY([category_id])
REFERENCES [dbo].[ProductCategories] ([category_id])
GO
USE [master]
GO
ALTER DATABASE [boska] SET  READ_WRITE 
GO
