USE [master]
GO
/****** Object:  Database [bank]    Script Date: 2021/6/15 21:27:55 ******/
CREATE DATABASE [bank]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'bank', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\bank.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'bank_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\bank_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [bank] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [bank].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [bank] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [bank] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [bank] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [bank] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [bank] SET ARITHABORT OFF 
GO
ALTER DATABASE [bank] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [bank] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [bank] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [bank] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [bank] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [bank] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [bank] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [bank] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [bank] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [bank] SET  DISABLE_BROKER 
GO
ALTER DATABASE [bank] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [bank] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [bank] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [bank] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [bank] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [bank] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [bank] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [bank] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [bank] SET  MULTI_USER 
GO
ALTER DATABASE [bank] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [bank] SET DB_CHAINING OFF 
GO
ALTER DATABASE [bank] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [bank] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [bank] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [bank] SET QUERY_STORE = OFF
GO
USE [bank]
GO
/****** Object:  Table [dbo].[admin]    Script Date: 2021/6/15 21:27:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[admin](
	[id] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[sex] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[history]    Script Date: 2021/6/15 21:27:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[history](
	[id] [int] NOT NULL,
	[flow] [varchar](50) NOT NULL,
	[date] [datetime] NOT NULL,
	[way] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 2021/6/15 21:27:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[sex] [varchar](50) NULL,
	[tel] [varchar](11) NOT NULL,
	[money] [decimal](18, 2) NULL,
	[idcard] [varchar](50) NOT NULL,
	[date] [datetime] NOT NULL,
	[situation] [varchar](4) NOT NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[admin] ([id], [password], [name], [sex]) VALUES (N'1', N'123', N'Geoge', N'female')
INSERT [dbo].[history] ([id], [flow], [date], [way]) VALUES (1, N'+123', CAST(N'2021-06-09T15:47:29.000' AS DateTime), N'存款')
INSERT [dbo].[history] ([id], [flow], [date], [way]) VALUES (1, N'-123', CAST(N'2021-06-09T15:48:12.000' AS DateTime), N'取款')
INSERT [dbo].[history] ([id], [flow], [date], [way]) VALUES (1, N'-5', CAST(N'2021-06-09T16:16:57.000' AS DateTime), N'转账给ID:2')
INSERT [dbo].[history] ([id], [flow], [date], [way]) VALUES (2, N'+5', CAST(N'2021-06-09T16:16:57.000' AS DateTime), N'来自ID：1的转账')
INSERT [dbo].[history] ([id], [flow], [date], [way]) VALUES (1, N'-100', CAST(N'2021-06-09T16:17:19.000' AS DateTime), N'转账给ID:2')
INSERT [dbo].[history] ([id], [flow], [date], [way]) VALUES (2, N'+100', CAST(N'2021-06-09T16:17:19.000' AS DateTime), N'来自ID：1的转账')
INSERT [dbo].[history] ([id], [flow], [date], [way]) VALUES (1, N'-100', CAST(N'2021-06-09T16:20:25.000' AS DateTime), N'转账给ID:2')
INSERT [dbo].[history] ([id], [flow], [date], [way]) VALUES (1, N'-99', CAST(N'2021-06-09T16:21:54.000' AS DateTime), N'转账给ID:2')
INSERT [dbo].[history] ([id], [flow], [date], [way]) VALUES (2, N'+99', CAST(N'2021-06-09T16:21:54.000' AS DateTime), N'来自ID：1的转账')
INSERT [dbo].[history] ([id], [flow], [date], [way]) VALUES (1, N'+1', CAST(N'2021-06-09T16:38:28.000' AS DateTime), N'存款')
INSERT [dbo].[history] ([id], [flow], [date], [way]) VALUES (1, N'-99', CAST(N'2021-06-09T17:17:18.000' AS DateTime), N'转账给ID:3')
INSERT [dbo].[history] ([id], [flow], [date], [way]) VALUES (3, N'+99', CAST(N'2021-06-09T17:17:18.000' AS DateTime), N'来自ID：1的转账')
INSERT [dbo].[history] ([id], [flow], [date], [way]) VALUES (22, N'+100', CAST(N'2021-06-15T20:02:47.000' AS DateTime), N'存款')
INSERT [dbo].[history] ([id], [flow], [date], [way]) VALUES (22, N'-5', CAST(N'2021-06-15T20:04:54.000' AS DateTime), N'取款')
INSERT [dbo].[history] ([id], [flow], [date], [way]) VALUES (1, N'-100', CAST(N'2021-06-09T16:41:19.000' AS DateTime), N'取款')
INSERT [dbo].[history] ([id], [flow], [date], [way]) VALUES (1, N'-3', CAST(N'2021-06-09T16:45:20.000' AS DateTime), N'转账给ID:2')
INSERT [dbo].[history] ([id], [flow], [date], [way]) VALUES (2, N'+3', CAST(N'2021-06-09T16:45:20.000' AS DateTime), N'来自ID：1的转账')
INSERT [dbo].[history] ([id], [flow], [date], [way]) VALUES (22, N'-5', CAST(N'2021-06-15T20:08:01.000' AS DateTime), N'转账给ID:21')
INSERT [dbo].[history] ([id], [flow], [date], [way]) VALUES (21, N'+5', CAST(N'2021-06-15T20:08:01.000' AS DateTime), N'来自ID：22的转账')
SET IDENTITY_INSERT [dbo].[users] ON 

INSERT [dbo].[users] ([id], [password], [name], [sex], [tel], [money], [idcard], [date], [situation]) VALUES (1, N'123', N'Mike      ', N'男', N'13684588321', CAST(1800.00 AS Decimal(18, 2)), N'332502180002216540', CAST(N'2021-06-15T20:11:56.000' AS DateTime), N'正常')
INSERT [dbo].[users] ([id], [password], [name], [sex], [tel], [money], [idcard], [date], [situation]) VALUES (2, N'123', N'John      ', N'男', N'16876524154', CAST(302.64 AS Decimal(18, 2)), N'332502156421454565', CAST(N'2021-06-08T23:29:35.000' AS DateTime), N'冻结')
INSERT [dbo].[users] ([id], [password], [name], [sex], [tel], [money], [idcard], [date], [situation]) VALUES (3, N'qwe', N'Johnson', N'男', N'15687341484', CAST(212.00 AS Decimal(18, 2)), N'321563423132213421', CAST(N'2021-06-09T13:17:28.000' AS DateTime), N'正常')
INSERT [dbo].[users] ([id], [password], [name], [sex], [tel], [money], [idcard], [date], [situation]) VALUES (4, N'asd', N'Judy      ', N'女', N'16354864354', CAST(0.00 AS Decimal(18, 2)), N'321343243453452133', CAST(N'2021-06-08T23:47:00.000' AS DateTime), N'正常')
INSERT [dbo].[users] ([id], [password], [name], [sex], [tel], [money], [idcard], [date], [situation]) VALUES (5, N'zxc', N'Sara      ', N'女', N'15678641315', CAST(0.00 AS Decimal(18, 2)), N'321434534532443544', CAST(N'2021-06-08T23:47:00.000' AS DateTime), N'正常')
INSERT [dbo].[users] ([id], [password], [name], [sex], [tel], [money], [idcard], [date], [situation]) VALUES (6, N'123qwe', N'Max       ', N'女', N'11324234213', CAST(0.00 AS Decimal(18, 2)), N'213324354353453213', CAST(N'2021-06-08T23:48:00.000' AS DateTime), N'正常')
INSERT [dbo].[users] ([id], [password], [name], [sex], [tel], [money], [idcard], [date], [situation]) VALUES (7, N'321', N'Jiso      ', N'女', N'12323423423', CAST(851646348.17 AS Decimal(18, 2)), N'213214323434565466', CAST(N'2021-06-08T23:49:00.000' AS DateTime), N'正常')
INSERT [dbo].[users] ([id], [password], [name], [sex], [tel], [money], [idcard], [date], [situation]) VALUES (8, N'ewq', N'张潇文', N'男', N'18678945455', CAST(1000000000000000.00 AS Decimal(18, 2)), N'468764643113213213', CAST(N'2021-06-08T23:50:00.000' AS DateTime), N'正常')
INSERT [dbo].[users] ([id], [password], [name], [sex], [tel], [money], [idcard], [date], [situation]) VALUES (9, N'dsa', N'邱坐齐', N'男', N'12345446548', CAST(181.35 AS Decimal(18, 2)), N'123468756496876445', CAST(N'2021-06-08T23:51:00.000' AS DateTime), N'正常')
INSERT [dbo].[users] ([id], [password], [name], [sex], [tel], [money], [idcard], [date], [situation]) VALUES (11, N'cxz', N'Andy      ', N'女', N'32132134324', CAST(3213.00 AS Decimal(18, 2)), N'324545657658776876', CAST(N'2021-06-08T23:53:00.000' AS DateTime), N'正常')
INSERT [dbo].[users] ([id], [password], [name], [sex], [tel], [money], [idcard], [date], [situation]) VALUES (12, N'123', N'Jessi', N'女', N'12332432432', CAST(0.00 AS Decimal(18, 2)), N'123123212343254354', CAST(N'2021-06-09T13:14:40.000' AS DateTime), N'正常')
INSERT [dbo].[users] ([id], [password], [name], [sex], [tel], [money], [idcard], [date], [situation]) VALUES (13, N'123', N'李四', N'男', N'12354354645', CAST(0.00 AS Decimal(18, 2)), N'321323435345646546', CAST(N'2021-06-09T13:16:57.000' AS DateTime), N'正常')
INSERT [dbo].[users] ([id], [password], [name], [sex], [tel], [money], [idcard], [date], [situation]) VALUES (15, N'123', N'朱迪', N'女', N'12132132132', CAST(0.00 AS Decimal(18, 2)), N'321234324345435345', CAST(N'2021-06-09T13:30:02.000' AS DateTime), N'正常')
INSERT [dbo].[users] ([id], [password], [name], [sex], [tel], [money], [idcard], [date], [situation]) VALUES (16, N'123', N'张三', N'男', N'12132132133', CAST(0.00 AS Decimal(18, 2)), N'332132143425443546', CAST(N'2021-06-09T13:31:18.000' AS DateTime), N'正常')
INSERT [dbo].[users] ([id], [password], [name], [sex], [tel], [money], [idcard], [date], [situation]) VALUES (17, N'123', N'王五', N'男', N'12323432423', CAST(0.00 AS Decimal(18, 2)), N'323546879783213233', CAST(N'2021-06-09T13:32:30.000' AS DateTime), N'正常')
INSERT [dbo].[users] ([id], [password], [name], [sex], [tel], [money], [idcard], [date], [situation]) VALUES (18, N'123', N'甲', N'男', N'13587896455', CAST(0.00 AS Decimal(18, 2)), N'332043985490645860', CAST(N'2021-06-09T13:38:13.000' AS DateTime), N'正常')
INSERT [dbo].[users] ([id], [password], [name], [sex], [tel], [money], [idcard], [date], [situation]) VALUES (19, N'123', N'乙', N'女', N'13467905645', CAST(0.00 AS Decimal(18, 2)), N'332132354365475678', CAST(N'2021-06-09T13:38:35.000' AS DateTime), N'正常')
INSERT [dbo].[users] ([id], [password], [name], [sex], [tel], [money], [idcard], [date], [situation]) VALUES (20, N'123', N'Mike', N'女', N'11345343431', CAST(0.00 AS Decimal(18, 2)), N'321354343453213213', CAST(N'2021-06-09T17:01:21.697' AS DateTime), N'正常')
INSERT [dbo].[users] ([id], [password], [name], [sex], [tel], [money], [idcard], [date], [situation]) VALUES (21, N'123', N'Asa', N'女', N'18913215643', CAST(5.00 AS Decimal(18, 2)), N'321321653412653421', CAST(N'2021-06-15T19:09:43.000' AS DateTime), N'正常')
INSERT [dbo].[users] ([id], [password], [name], [sex], [tel], [money], [idcard], [date], [situation]) VALUES (22, N'321', N'cat', N'男', N'11312311123', CAST(90.00 AS Decimal(18, 2)), N'321321321321321312', CAST(N'2021-06-15T20:36:17.000' AS DateTime), N'冻结')
SET IDENTITY_INSERT [dbo].[users] OFF
ALTER TABLE [dbo].[users] ADD  CONSTRAINT [DF_users_money]  DEFAULT ((0)) FOR [money]
GO
ALTER TABLE [dbo].[users] ADD  CONSTRAINT [DF_users_date]  DEFAULT (getdate()) FOR [date]
GO
ALTER TABLE [dbo].[users] ADD  CONSTRAINT [DF_users_situation]  DEFAULT ('正常') FOR [situation]
GO
ALTER TABLE [dbo].[history]  WITH CHECK ADD  CONSTRAINT [FK_history_users] FOREIGN KEY([id])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[history] CHECK CONSTRAINT [FK_history_users]
GO
USE [master]
GO
ALTER DATABASE [bank] SET  READ_WRITE 
GO
