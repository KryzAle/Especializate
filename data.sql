USE [master]
GO
/****** Object:  Database [DB_A44489_asistencia]    Script Date: 17/01/2019 12:38:25 ******/
CREATE DATABASE [DB_A44489_asistencia]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB_A44489_asistencia', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\DB_A44489_asistencia.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DB_A44489_asistencia_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\DB_A44489_asistencia_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DB_A44489_asistencia] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_A44489_asistencia].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_A44489_asistencia] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB_A44489_asistencia] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB_A44489_asistencia] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB_A44489_asistencia] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB_A44489_asistencia] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB_A44489_asistencia] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DB_A44489_asistencia] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB_A44489_asistencia] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB_A44489_asistencia] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB_A44489_asistencia] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB_A44489_asistencia] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB_A44489_asistencia] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB_A44489_asistencia] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB_A44489_asistencia] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB_A44489_asistencia] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DB_A44489_asistencia] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB_A44489_asistencia] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB_A44489_asistencia] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB_A44489_asistencia] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB_A44489_asistencia] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB_A44489_asistencia] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DB_A44489_asistencia] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB_A44489_asistencia] SET RECOVERY FULL 
GO
ALTER DATABASE [DB_A44489_asistencia] SET  MULTI_USER 
GO
ALTER DATABASE [DB_A44489_asistencia] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB_A44489_asistencia] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DB_A44489_asistencia] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DB_A44489_asistencia] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [DB_A44489_asistencia] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DB_A44489_asistencia', N'ON'
GO
USE [DB_A44489_asistencia]
GO
/****** Object:  User [kakarotto]    Script Date: 17/01/2019 12:38:25 ******/
CREATE USER [kakarotto] FOR LOGIN [kakarotto] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 17/01/2019 12:38:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Asistencia]    Script Date: 17/01/2019 12:38:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Asistencia](
	[asi_id] [int] IDENTITY(1,1) NOT NULL,
	[asi_fecha] [date] NOT NULL,
	[asi_hora_inicio] [time](7) NOT NULL,
	[asi_hora_fin] [time](7) NULL,
	[asi_tiempo] [int] NOT NULL,
	[asi_contenido] [varchar](10) NULL,
	[asi_est_id] [int] NOT NULL,
	[asi_tema_id] [int] NOT NULL,
 CONSTRAINT [pk8] PRIMARY KEY CLUSTERED 
(
	[asi_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 17/01/2019 12:38:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 17/01/2019 12:38:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 17/01/2019 12:38:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 17/01/2019 12:38:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 17/01/2019 12:38:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Estudiante]    Script Date: 17/01/2019 12:38:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Estudiante](
	[est_id] [int] IDENTITY(1,1) NOT NULL,
	[est_nombre] [varchar](50) NOT NULL,
	[est_apellido] [varchar](30) NOT NULL,
	[est_telefono] [varchar](15) NULL,
	[est_direccion] [varchar](100) NOT NULL,
	[est_correo] [varchar](50) NOT NULL,
	[est_cedula] [varchar](50) NOT NULL,
	[est_cole_univ] [varchar](50) NULL,
 CONSTRAINT [pk1] PRIMARY KEY CLUSTERED 
(
	[est_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Horario_Profesor]    Script Date: 17/01/2019 12:38:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Horario_Profesor](
	[hor_pro_id] [int] IDENTITY(1,1) NOT NULL,
	[hor_pro_dia] [nvarchar](50) NOT NULL,
	[hor_pro_hora_inicio] [time](7) NOT NULL,
	[hor_pro_hora_fin] [time](7) NOT NULL,
	[hor_pro_pro_id] [nvarchar](128) NOT NULL,
 CONSTRAINT [pk5] PRIMARY KEY CLUSTERED 
(
	[hor_pro_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Inscripcion]    Script Date: 17/01/2019 12:38:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inscripcion](
	[ins_id] [int] IDENTITY(1,1) NOT NULL,
	[ins_fecha] [date] NOT NULL,
	[ins_valor] [float] NOT NULL,
	[ins_total_horas] [int] NOT NULL,
	[ins_saldo] [int] NULL,
	[ins_est_id] [int] NOT NULL,
 CONSTRAINT [pk2] PRIMARY KEY CLUSTERED 
(
	[ins_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Materia]    Script Date: 17/01/2019 12:38:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Materia](
	[mat_id] [int] IDENTITY(1,1) NOT NULL,
	[mat_nombre] [varchar](50) NOT NULL,
 CONSTRAINT [pk3] PRIMARY KEY CLUSTERED 
(
	[mat_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Profesor]    Script Date: 17/01/2019 12:38:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Profesor](
	[pro_id] [nvarchar](128) NOT NULL,
	[pro_nombre] [varchar](50) NULL,
	[pro_apellido] [varchar](30) NULL,
	[pro_telefono] [varchar](15) NULL,
	[pro_direccion] [varchar](100) NULL,
	[pro_correo] [varchar](50) NOT NULL,
	[pro_cedula] [varchar](50) NULL,
	[pro_profesion] [varchar](50) NULL,
 CONSTRAINT [pk4] PRIMARY KEY CLUSTERED 
(
	[pro_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Profesor_Materia]    Script Date: 17/01/2019 12:38:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profesor_Materia](
	[pro_mat_id] [int] IDENTITY(1,1) NOT NULL,
	[pro_mat_pro_id] [nvarchar](128) NOT NULL,
	[pro_mat_mat_id] [int] NOT NULL,
 CONSTRAINT [pk6] PRIMARY KEY CLUSTERED 
(
	[pro_mat_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tema]    Script Date: 17/01/2019 12:38:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tema](
	[tema_id] [int] IDENTITY(1,1) NOT NULL,
	[tema_nombre] [varchar](50) NOT NULL,
	[tema_pro_mat_id] [int] NOT NULL,
 CONSTRAINT [pk7] PRIMARY KEY CLUSTERED 
(
	[tema_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201901141722580_InitialCreate', N'Organizate.Models.ApplicationDbContext', 0x1F8B0800000000000400DD5CDB6EDC36107D2FD07F10F4D416CECA9726488DDD04CEDA6E8DC617649DA06F0157E2AE8548942A51AEDDA25FD6877E527FA14389BAF1A2CBAEBCBB0E02042B727866381C92C3E1D0FFFDF3EFF8ED83EF19F7388ADD804CCC83D1BE696062078E4B961333A18B17AFCDB76FBEFD667CE6F80FC6A79CEE88D1414B124FCC3B4AC363CB8AED3BECA378E4BB7614C4C1828EECC0B790135887FBFB3F59070716060813B00C63FC2121D4F571FA019FD380D838A409F22E03077B312F879A598A6A5C211FC721B2F1C4BC8E9688B87F228A4719B1699C782E024166D85B98062224A0888298C71F633CA3514096B3100A9077FB1862A05B202FC65CFCE392BC6B4FF60F594FACB2610E6527310DFC9E8007475C3596D87C25059B85EA407967A064FAC87A9D2A70625E38382DFA1078A00091E1F1D48B18F1C4BC2C589CC4E115A6A3BCE128833C8F00EE8F20FA32AA22EE199DDBED15A67438DA67FFF68C69E2D124C21382131A216FCFB849E69E6BFF8A1F6F832F984C8E0EE68BA3D72F5F21E7E8D58FF8E865B5A7D057A0AB1540D14D14843802D9F0A2E8BF6958F57696D8B06856699369056C096685695CA287F7982CE91DCC97C3D7A671EE3E60272FE1C6F591B83089A0118D12F8BC4A3C0FCD3D5CD45B8D3CD9FF0D5C0F5FBE1A84EB15BA7797E9D00BFC61E24430AF3E602FAD8DEFDC309B5EB5F1FECCC9CEA3C067DF75FBCA6A3FCF8224B25967022DC92D8A9698D6A51B5BA5F17632690635BC59E7A8BB6FDA4C52D9BC95A4AC43ABCC849CC5A667432EEFD3F2ED6C7127610883979A16D34893C1497BD54868BC679424A5E11C74351C021DFA9AD7C1331FB9DE000B61072EE0822CDCC8C7452FDF05607688F496F906C531AC03CE2F28BE6B101D7E0E20FA0CDB4904E639A3C80F9F9CDBCD5D40F055E2CF99D56F8ED7604373FB47708E6C1A446784B55A1BEF7D607F09127A469C5398BF1FA99D03B2CF5BD7EF0E30883827B68DE3F81C8C193BD3003CEC1CF082D0A3C3DE706C7DDAB62332F590EBAB3D116125FD9C9396DE889A42F24834642AAFA449D4F7C1D225DD44CD49F5A26614ADA272B2BEA232B06E92724ABDA02941AB9C19D5607E5E3A42C33B7A29ECEE7B7AEB6DDEBAB5A0A2C619AC90F8674C7004CB98738328C5112947A0CBBAB10D67211D3EC6F4C9F7A694D327E42543B35A6936A48BC0F0B32185DDFDD9908A09C5F7AEC3BC920EC79F9C18E03BD1AB4F56ED734E906CD3D3A1D6CD4D33DFCC1AA09B2E27711CD86E3A0B14812F1EB6A8CB0F3E9CD11EC3C87A23C641A06360E82EDBF2A004FA668A46754D4EB18729364EEC2C303845B18D1C598DD021A78760F98EAA10AC8C87D485FB41E209968E23D608B143500C33D525549E162EB1DD1079AD5A125A76DCC258DF0B1E62CD290E31610C5B35D185B93AFCC10428F80883D2A6A1B155B1B86643D478ADBA316F7361CB7197A2121BB1C916DF596397DC7F7B12C36CD6D8068CB359255D04D086F2B661A0FCACD2D500C483CBAE19A87062D2182877A93662A0758D6DC140EB2A7976069A1D51BB8EBF705EDD35F3AC1F9437BFAD37AA6B0BB659D3C78E9966E67B421B0A2D70249BE7E99C55E207AA389C819CFC7C167357573411063EC3B41EB229FD5DA51F6A35838846D404581A5A0B28BF049480A409D543B83C96D7281DF7227AC0E671B74658BEF60BB0151B90B1AB97A11542FD95A9689C9D4E1F45CF0A6B908CBCD361A182A3300871F1AA77BC835274715959315D7CE13EDE70A5637C301A14D4E2B96A94947766702DE5A6D9AE259543D6C7255B4B4B82FBA4D152DE99C1B5C46DB45D490AA7A0875BB0968AEA5BF840932D8F7414BB4D5137B6B214295E30B634B954E34B14862E595672AB788931CB12ABA62F66FD538EFC0CC3B26345E651216DC18906115A62A1165883A4E76E14D35344D11CB138CFD4F12532E5DEAA59FE7396D5ED531EC47C1FC8A9D9EFAC857C755FDB6A655F84439C43077DE6D0A45174C5F0AB9B1B2CD50D79285204EEA78197F844EF5FE95B67D777D5F659898C30B604F925FF495296E4E5D635DF695CE43931CC1815DECBEAE3A487D0693BF73DABFAD6F9A37A943C3C5545D185ACB6366E3A37A6CF58890E62FFA16A45789A59C5B352AA00BCA8274625B14102ABD47547ADE79E5431EB35DD118504932AA450D543CA6A1A494DC86AC54A781A8DAA29BA73901347AAE8726D7764450A49155A51BD02B64266B1AE3BAA22CBA40AACA8EE8E5DA69C886BE80EEF5BDA63CBAA1B5776B05D6FE7D2603CCD8238CCC657B9BFAF02558A7B62F11B7A098C97EFA431694F77AB1A5316CE58CF983418FA75A776F15D5F761A6FEBF598B5DBECDAD2DE749BAFC7EB67B24F6A18D2D94E2429B817673CE12C37E6E7AAF6C733D2412B23318D5C8DB0AD3FC614FB2346309AFDEE4D3D17B3453C27B8045B5BE09866191CE6E1FEC1A1F00067771EC35871EC788A73A9EE454C7DCC36908C45EE5164DFA1484E8D58E3C148092A459D2F88831F26E65F69ABE33480C17EA5C57BC645FC91B8BF2750711B25D8F85B4EF51C2681BEC3938D42D0BF9FC55B88EE2ABFF8ED73D69465FEC3743A36F60545AF32FCF51712BDA4C99AAE21CDCAEF269EEF6CAB3D4B50A20AB365F5570873970EF2022197F23B1F3D7CDF5734E52B83B510152F0986C21B4485BA9702AB60695F0938F049D35702FD3AAB7E35B08A68DA17032EE90F26BE17E8BE0CE52DB7B80F29CE4B9B5892523DB7E65BAF957CB9EDBD494ACB5E6BA2CBA9D73DE0064DAF5ECF45796669CB836D9D8AACE4C1B0B769F74F9E8ABC2BD9C7A5D3BEDDA4E34DE61937DC267D55E9C53B9010A748F0D97E12F1A66D4D1700DEF14CCC7EA9C23B666C7C9BDF7E42F0A68D4D1720DE7163EB95F6BB63B6B6ADFD73CB96D6790BDD7A12AF9C8FA4B9C8514591DB9274B3903B1CFFE7011841E651666F2BD559614D19AD2D0C4B123D537D3A9AC8589A38125F89A2996DBFBEF20DBFB1B39CA699AD2689B389375FFF1B79739A66DE9AD4C86DA4172B93135529DF2DEB5853EED4734A27AEF5A4257BBDCD676DBC957F4ED9C38328A5367B34B7CBCF27597810950C39757A2407CB17C5B07756FE1623ECDFB1BB2C21D85F6624D8AEED9A05CD055904F9E62D48949308119A4B4C91035BEA4944DD05B22954B30074FA383C0DEAB16B9039762EC87542C3844297B13FF76A012FE60434F14F33A0EB328FAF43F6150FD10510D36581FB6BF22E713DA790FB5C1113D24030EF82877BD9585216F65D3E16485701E908C4D5573845B7D80F3D008BAFC90CDDE3556403F37B8F97C87E2C23803A90F681A8AB7D7CEAA26584FC986394EDE1136CD8F11FDEFC0F7AF4119992540000, N'6.2.0-61023')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1', N'Administrador')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2', N'Secretaria')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3', N'Profesor')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9d3483b5-aac9-4952-9db4-b89cdfd7f53b', N'2')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'cb7becd9-c867-4dfb-a393-26a39e5d8bb8', N'1')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'184275ef-3360-44b7-8329-d8a7d8c5c681', N'sad@asd.com', 0, N'AD7TiMaOPEAXYmaQoTIOXxNYPQTcsQirBvFG1h1VocYzEzcOTF437ubtLsuuwEfgkA==', N'94cf0e9c-65a3-4423-a340-b520e0a2286b', NULL, 0, 0, NULL, 1, 0, N'sad@asd.com')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1c9e42bf-47f2-4f89-8216-bbed84763ecc', N'jean@profesor.com', 0, N'AGKwVp6/TdZuS17gB7aD0ojA1gYZ2KR8K65057d7oINDREBgXGFD5UrI5cBjUNvTQw==', N'83746eb1-d0b5-4399-a9b7-fa633f71faf9', NULL, 0, 0, NULL, 1, 0, N'jean@profesor.com')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5e9c718d-5d53-48f1-a5ed-3089ab96f76a', N'alex@profesor.com', 0, N'ABjkU36R/quV/tNAx97kJC7gZwuBq/j3+a7Oq1lWSFioNo0qws/xbv1iElco9T+7gQ==', N'7a0d68de-686f-4818-bf87-5d4327cbfc0d', NULL, 0, 0, NULL, 1, 0, N'alex@profesor.com')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9d3483b5-aac9-4952-9db4-b89cdfd7f53b', N'secretaria@secretaria.com', 0, N'AFR/bkvgxTlPCENGi3Ph383SMjY+acXjFmQWFm7pton2uA4e6wkXgDzAZxk75f+5og==', N'e3a0749e-7dc8-4565-97ef-e6bb7ed062c3', NULL, 0, 0, NULL, 1, 0, N'secretaria@secretaria.com')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'cb7becd9-c867-4dfb-a393-26a39e5d8bb8', N'administrador@administrador.com', 0, N'AAV2Vy/sY3exCFGN6AkQlZb/iCwtQyEegwkKvbXYj3jPYOTg7Xaj8CRf8D9rAKYjhA==', N'7f411bab-5ee9-4a8d-969f-d16960760d34', NULL, 0, 0, NULL, 1, 0, N'administrador@administrador.com')
SET IDENTITY_INSERT [dbo].[Estudiante] ON 

INSERT [dbo].[Estudiante] ([est_id], [est_nombre], [est_apellido], [est_telefono], [est_direccion], [est_correo], [est_cedula], [est_cole_univ]) VALUES (1, N'Kakarotto', N'son', N'1563456', N'asdasasd', N'asd@asd.com', N'0603928854', N'espe')
SET IDENTITY_INSERT [dbo].[Estudiante] OFF
SET IDENTITY_INSERT [dbo].[Horario_Profesor] ON 

INSERT [dbo].[Horario_Profesor] ([hor_pro_id], [hor_pro_dia], [hor_pro_hora_inicio], [hor_pro_hora_fin], [hor_pro_pro_id]) VALUES (1, N'Lunes', CAST(N'09:00:00' AS Time), CAST(N'13:00:00' AS Time), N'5e9c718d-5d53-48f1-a5ed-3089ab96f76a')
INSERT [dbo].[Horario_Profesor] ([hor_pro_id], [hor_pro_dia], [hor_pro_hora_inicio], [hor_pro_hora_fin], [hor_pro_pro_id]) VALUES (2, N'Lunes', CAST(N'09:15:00' AS Time), CAST(N'15:00:00' AS Time), N'184275ef-3360-44b7-8329-d8a7d8c5c681')
INSERT [dbo].[Horario_Profesor] ([hor_pro_id], [hor_pro_dia], [hor_pro_hora_inicio], [hor_pro_hora_fin], [hor_pro_pro_id]) VALUES (3, N'Martes', CAST(N'09:00:00' AS Time), CAST(N'10:00:00' AS Time), N'184275ef-3360-44b7-8329-d8a7d8c5c681')
INSERT [dbo].[Horario_Profesor] ([hor_pro_id], [hor_pro_dia], [hor_pro_hora_inicio], [hor_pro_hora_fin], [hor_pro_pro_id]) VALUES (4, N'Miercoles', CAST(N'10:25:00' AS Time), CAST(N'16:00:00' AS Time), N'184275ef-3360-44b7-8329-d8a7d8c5c681')
SET IDENTITY_INSERT [dbo].[Horario_Profesor] OFF
SET IDENTITY_INSERT [dbo].[Inscripcion] ON 

INSERT [dbo].[Inscripcion] ([ins_id], [ins_fecha], [ins_valor], [ins_total_horas], [ins_saldo], [ins_est_id]) VALUES (1, CAST(N'2015-12-05' AS Date), 0, 8, NULL, 1)
INSERT [dbo].[Inscripcion] ([ins_id], [ins_fecha], [ins_valor], [ins_total_horas], [ins_saldo], [ins_est_id]) VALUES (2, CAST(N'2019-01-16' AS Date), 0, 3, NULL, 1)
INSERT [dbo].[Inscripcion] ([ins_id], [ins_fecha], [ins_valor], [ins_total_horas], [ins_saldo], [ins_est_id]) VALUES (3, CAST(N'2019-01-01' AS Date), 0, 2, NULL, 1)
INSERT [dbo].[Inscripcion] ([ins_id], [ins_fecha], [ins_valor], [ins_total_horas], [ins_saldo], [ins_est_id]) VALUES (4, CAST(N'2019-02-02' AS Date), 0, 2, NULL, 1)
INSERT [dbo].[Inscripcion] ([ins_id], [ins_fecha], [ins_valor], [ins_total_horas], [ins_saldo], [ins_est_id]) VALUES (5, CAST(N'2019-06-04' AS Date), 0, 23, NULL, 1)
INSERT [dbo].[Inscripcion] ([ins_id], [ins_fecha], [ins_valor], [ins_total_horas], [ins_saldo], [ins_est_id]) VALUES (6, CAST(N'2019-07-02' AS Date), 0, 23, NULL, 1)
INSERT [dbo].[Inscripcion] ([ins_id], [ins_fecha], [ins_valor], [ins_total_horas], [ins_saldo], [ins_est_id]) VALUES (7, CAST(N'2019-09-03' AS Date), 0, 2, NULL, 1)
INSERT [dbo].[Inscripcion] ([ins_id], [ins_fecha], [ins_valor], [ins_total_horas], [ins_saldo], [ins_est_id]) VALUES (8, CAST(N'2019-01-02' AS Date), 0, 3, NULL, 1)
INSERT [dbo].[Inscripcion] ([ins_id], [ins_fecha], [ins_valor], [ins_total_horas], [ins_saldo], [ins_est_id]) VALUES (9, CAST(N'2019-10-01' AS Date), 0, 33, NULL, 1)
INSERT [dbo].[Inscripcion] ([ins_id], [ins_fecha], [ins_valor], [ins_total_horas], [ins_saldo], [ins_est_id]) VALUES (10, CAST(N'2019-11-05' AS Date), 0, 2, NULL, 1)
INSERT [dbo].[Inscripcion] ([ins_id], [ins_fecha], [ins_valor], [ins_total_horas], [ins_saldo], [ins_est_id]) VALUES (11, CAST(N'2019-07-19' AS Date), 0, 34, NULL, 1)
INSERT [dbo].[Inscripcion] ([ins_id], [ins_fecha], [ins_valor], [ins_total_horas], [ins_saldo], [ins_est_id]) VALUES (12, CAST(N'2018-12-04' AS Date), 0, 56, NULL, 1)
INSERT [dbo].[Inscripcion] ([ins_id], [ins_fecha], [ins_valor], [ins_total_horas], [ins_saldo], [ins_est_id]) VALUES (13, CAST(N'2019-01-17' AS Date), 0, 55, NULL, 1)
INSERT [dbo].[Inscripcion] ([ins_id], [ins_fecha], [ins_valor], [ins_total_horas], [ins_saldo], [ins_est_id]) VALUES (14, CAST(N'2019-01-17' AS Date), 50, 5, NULL, 1)
SET IDENTITY_INSERT [dbo].[Inscripcion] OFF
SET IDENTITY_INSERT [dbo].[Materia] ON 

INSERT [dbo].[Materia] ([mat_id], [mat_nombre]) VALUES (1, N'Fisica')
SET IDENTITY_INSERT [dbo].[Materia] OFF
INSERT [dbo].[Profesor] ([pro_id], [pro_nombre], [pro_apellido], [pro_telefono], [pro_direccion], [pro_correo], [pro_cedula], [pro_profesion]) VALUES (N'184275ef-3360-44b7-8329-d8a7d8c5c681', N'Jean', N'Pineda', N'asdasdasd', N'dsadsa', N'sad@asd.com', N'sadasdadss', N'sadsa')
INSERT [dbo].[Profesor] ([pro_id], [pro_nombre], [pro_apellido], [pro_telefono], [pro_direccion], [pro_correo], [pro_cedula], [pro_profesion]) VALUES (N'5e9c718d-5d53-48f1-a5ed-3089ab96f76a', N'Alexander', N'Arcos', N'0987670512', N'Ambato', N'alex@profesor.com', N'1805150354', N'VAgo SA')
SET IDENTITY_INSERT [dbo].[Profesor_Materia] ON 

INSERT [dbo].[Profesor_Materia] ([pro_mat_id], [pro_mat_pro_id], [pro_mat_mat_id]) VALUES (1, N'5e9c718d-5d53-48f1-a5ed-3089ab96f76a', 1)
INSERT [dbo].[Profesor_Materia] ([pro_mat_id], [pro_mat_pro_id], [pro_mat_mat_id]) VALUES (2, N'184275ef-3360-44b7-8329-d8a7d8c5c681', 1)
SET IDENTITY_INSERT [dbo].[Profesor_Materia] OFF
SET IDENTITY_INSERT [dbo].[Tema] ON 

INSERT [dbo].[Tema] ([tema_id], [tema_nombre], [tema_pro_mat_id]) VALUES (1, N'Mru', 1)
INSERT [dbo].[Tema] ([tema_id], [tema_nombre], [tema_pro_mat_id]) VALUES (2, N'MRUV', 1)
INSERT [dbo].[Tema] ([tema_id], [tema_nombre], [tema_pro_mat_id]) VALUES (3, N'Sad', 1)
INSERT [dbo].[Tema] ([tema_id], [tema_nombre], [tema_pro_mat_id]) VALUES (4, N'MRU', 2)
SET IDENTITY_INSERT [dbo].[Tema] OFF
ALTER TABLE [dbo].[Asistencia]  WITH CHECK ADD  CONSTRAINT [fk6] FOREIGN KEY([asi_est_id])
REFERENCES [dbo].[Estudiante] ([est_id])
GO
ALTER TABLE [dbo].[Asistencia] CHECK CONSTRAINT [fk6]
GO
ALTER TABLE [dbo].[Asistencia]  WITH CHECK ADD  CONSTRAINT [fk7] FOREIGN KEY([asi_tema_id])
REFERENCES [dbo].[Tema] ([tema_id])
GO
ALTER TABLE [dbo].[Asistencia] CHECK CONSTRAINT [fk7]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Horario_Profesor]  WITH CHECK ADD  CONSTRAINT [fk2] FOREIGN KEY([hor_pro_pro_id])
REFERENCES [dbo].[Profesor] ([pro_id])
GO
ALTER TABLE [dbo].[Horario_Profesor] CHECK CONSTRAINT [fk2]
GO
ALTER TABLE [dbo].[Inscripcion]  WITH CHECK ADD  CONSTRAINT [fk1] FOREIGN KEY([ins_est_id])
REFERENCES [dbo].[Estudiante] ([est_id])
GO
ALTER TABLE [dbo].[Inscripcion] CHECK CONSTRAINT [fk1]
GO
ALTER TABLE [dbo].[Profesor_Materia]  WITH CHECK ADD  CONSTRAINT [fk3] FOREIGN KEY([pro_mat_pro_id])
REFERENCES [dbo].[Profesor] ([pro_id])
GO
ALTER TABLE [dbo].[Profesor_Materia] CHECK CONSTRAINT [fk3]
GO
ALTER TABLE [dbo].[Profesor_Materia]  WITH CHECK ADD  CONSTRAINT [fk4] FOREIGN KEY([pro_mat_mat_id])
REFERENCES [dbo].[Materia] ([mat_id])
GO
ALTER TABLE [dbo].[Profesor_Materia] CHECK CONSTRAINT [fk4]
GO
ALTER TABLE [dbo].[Tema]  WITH CHECK ADD  CONSTRAINT [fk5] FOREIGN KEY([tema_pro_mat_id])
REFERENCES [dbo].[Profesor_Materia] ([pro_mat_id])
GO
ALTER TABLE [dbo].[Tema] CHECK CONSTRAINT [fk5]
GO
USE [master]
GO
ALTER DATABASE [DB_A44489_asistencia] SET  READ_WRITE 
GO
