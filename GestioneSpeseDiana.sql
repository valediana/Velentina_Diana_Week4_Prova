USE [master]
GO
/****** Object:  Database [GestioneSpese]    Script Date: 23/12/2021 14:50:36 ******/
CREATE DATABASE [GestioneSpese]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GestioneSpese', FILENAME = N'C:\Users\valentina.diana\GestioneSpese.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GestioneSpese_log', FILENAME = N'C:\Users\valentina.diana\GestioneSpese_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [GestioneSpese] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GestioneSpese].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GestioneSpese] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GestioneSpese] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GestioneSpese] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GestioneSpese] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GestioneSpese] SET ARITHABORT OFF 
GO
ALTER DATABASE [GestioneSpese] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [GestioneSpese] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GestioneSpese] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GestioneSpese] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GestioneSpese] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GestioneSpese] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GestioneSpese] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GestioneSpese] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GestioneSpese] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GestioneSpese] SET  ENABLE_BROKER 
GO
ALTER DATABASE [GestioneSpese] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GestioneSpese] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GestioneSpese] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GestioneSpese] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GestioneSpese] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GestioneSpese] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GestioneSpese] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GestioneSpese] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GestioneSpese] SET  MULTI_USER 
GO
ALTER DATABASE [GestioneSpese] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GestioneSpese] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GestioneSpese] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GestioneSpese] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GestioneSpese] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GestioneSpese] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [GestioneSpese] SET QUERY_STORE = OFF
GO
USE [GestioneSpese]
GO
/****** Object:  Table [dbo].[Categorie]    Script Date: 23/12/2021 14:50:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorie](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Categoria] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Spese]    Script Date: 23/12/2021 14:50:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Spese](
	[IdSpesa] [int] IDENTITY(1,1) NOT NULL,
	[Data] [datetime] NOT NULL,
	[Descrizione] [varchar](500) NOT NULL,
	[Utente] [varchar](100) NOT NULL,
	[Importo] [decimal](5, 2) NOT NULL,
	[Approvato] [bit] NOT NULL,
	[IdCategoria] [int] NOT NULL,
 CONSTRAINT [PK_Spese] PRIMARY KEY CLUSTERED 
(
	[IdSpesa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categorie] ON 

INSERT [dbo].[Categorie] ([Id], [Categoria]) VALUES (1, N'Viaggio')
INSERT [dbo].[Categorie] ([Id], [Categoria]) VALUES (2, N'Ristoranti')
INSERT [dbo].[Categorie] ([Id], [Categoria]) VALUES (3, N'Salute')
INSERT [dbo].[Categorie] ([Id], [Categoria]) VALUES (4, N'Sport')
INSERT [dbo].[Categorie] ([Id], [Categoria]) VALUES (5, N'Alimentazione')
INSERT [dbo].[Categorie] ([Id], [Categoria]) VALUES (6, N'Divertimento')
SET IDENTITY_INSERT [dbo].[Categorie] OFF
GO
SET IDENTITY_INSERT [dbo].[Spese] ON 

INSERT [dbo].[Spese] ([IdSpesa], [Data], [Descrizione], [Utente], [Importo], [Approvato], [IdCategoria]) VALUES (1, CAST(N'2021-12-20T00:00:00.000' AS DateTime), N'Hotel Eden', N'Valentina Diana', CAST(350.00 AS Decimal(5, 2)), 0, 1)
INSERT [dbo].[Spese] ([IdSpesa], [Data], [Descrizione], [Utente], [Importo], [Approvato], [IdCategoria]) VALUES (2, CAST(N'2021-12-23T00:00:00.000' AS DateTime), N'Ristorante Pizzeria', N'Anna Rossi', CAST(200.00 AS Decimal(5, 2)), 0, 2)
INSERT [dbo].[Spese] ([IdSpesa], [Data], [Descrizione], [Utente], [Importo], [Approvato], [IdCategoria]) VALUES (3, CAST(N'2021-12-22T00:00:00.000' AS DateTime), N'Taxi', N'Marco Verdi', CAST(40.00 AS Decimal(5, 2)), 1, 1)
INSERT [dbo].[Spese] ([IdSpesa], [Data], [Descrizione], [Utente], [Importo], [Approvato], [IdCategoria]) VALUES (4, CAST(N'2021-12-02T00:00:00.000' AS DateTime), N'Abbonamento Palestra ', N'Anna Rossi', CAST(60.00 AS Decimal(5, 2)), 1, 4)
INSERT [dbo].[Spese] ([IdSpesa], [Data], [Descrizione], [Utente], [Importo], [Approvato], [IdCategoria]) VALUES (7, CAST(N'2021-12-23T00:00:00.000' AS DateTime), N'Cena natalizia', N'Marco Verdi', CAST(100.00 AS Decimal(5, 2)), 1, 1)
INSERT [dbo].[Spese] ([IdSpesa], [Data], [Descrizione], [Utente], [Importo], [Approvato], [IdCategoria]) VALUES (8, CAST(N'2021-12-18T00:00:00.000' AS DateTime), N'Farmacia', N'Anna Rossi', CAST(30.00 AS Decimal(5, 2)), 1, 3)
INSERT [dbo].[Spese] ([IdSpesa], [Data], [Descrizione], [Utente], [Importo], [Approvato], [IdCategoria]) VALUES (14, CAST(N'2021-12-12T14:00:00.000' AS DateTime), N'ciocc', N'Valentina Diana', CAST(34.00 AS Decimal(5, 2)), 0, 4)
SET IDENTITY_INSERT [dbo].[Spese] OFF
GO
ALTER TABLE [dbo].[Spese]  WITH CHECK ADD  CONSTRAINT [FK_Categoria] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categorie] ([Id])
GO
ALTER TABLE [dbo].[Spese] CHECK CONSTRAINT [FK_Categoria]
GO
USE [master]
GO
ALTER DATABASE [GestioneSpese] SET  READ_WRITE 
GO
