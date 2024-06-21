CREATE DATABASE Campeonato;

USE [Campeonato]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 15/6/2024 23:06:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[idCategoria] [int] IDENTITY(1,1) NOT NULL,
	[idJugador] [int] NOT NULL,
	[nombre] [nchar](100) NOT NULL,
 CONSTRAINT [PK_Categorias] PRIMARY KEY CLUSTERED 
(
	[idCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Director_Tecnico]    Script Date: 15/6/2024 23:06:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Director_Tecnico](
	[id_Director] [int] IDENTITY(1,1) NOT NULL,
	[id_Categoria] [int] NULL,
	[nombre] [nchar](100) NULL,
	[apellido] [nchar](100) NULL,
	[nacionalidad] [nchar](100) NULL,
	[titulosGanados] [int] NULL,
	[victorias] [int] NULL,
	[derrotas] [int] NULL,
	[empates] [int] NULL,
	[foto_url] [nvarchar](MAX) NULL,
 CONSTRAINT [PK_Director_Tecnico] PRIMARY KEY CLUSTERED 
(
	[id_Director] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estadistica]    Script Date: 15/6/2024 23:06:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estadistica](
	[idEstadistica] [int] IDENTITY(1,1) NOT NULL,
	[idJugador] [int] NOT NULL,
	[idTemporada] [int] NOT NULL,
	[partidosJugados] [int] NOT NULL,
	[goles] [int] NOT NULL,
	[asistencias] [int] NOT NULL,
	[tarjetasAmarillas] [int] NOT NULL,
	[tarjetasRojas] [int] NOT NULL,
 CONSTRAINT [PK_Estadistica] PRIMARY KEY CLUSTERED 
(
	[idEstadistica] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Info_Equipo]    Script Date: 15/6/2024 23:06:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Info_Equipo](
	[idEquipo] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nchar](100) NOT NULL,
	[direccionEstadio] [nchar](100) NOT NULL,
	[entrenador] [nchar](100) NOT NULL,
	[añoFundacion] [int] NOT NULL,
	[capitan] [nchar](100) NOT NULL,
	[titulosGanados] [int] NOT NULL,
 CONSTRAINT [PK_Info_Equipo] PRIMARY KEY CLUSTERED 
(
	[idEquipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Jugadores]    Script Date: 15/6/2024 23:06:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jugadores](
	[idJugador] [int] IDENTITY(1,1) NOT NULL,
	[idEstadistica] [int] NULL,
	[nombre] [nchar](100) NULL,
	[apellido] [nchar](100) NULL,
	[edad] [int] NULL,
	[numero_camiseta] [int] NULL,
	[posicion] [nchar](100) NULL,
	[foto_url] [nvarchar](MAX) NULL,
 CONSTRAINT [PK_Jugadores] PRIMARY KEY CLUSTERED 
(
	[idJugador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Temporada]    Script Date: 15/6/2024 23:06:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Temporada](
	[idTemporada] [int] NOT NULL,
	[idEstadistica] [int] NOT NULL,
	[nombre] [nchar](100) NOT NULL,
 CONSTRAINT [PK_Temporada] PRIMARY KEY CLUSTERED 
(
	[idTemporada] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Categorias]  WITH CHECK ADD  CONSTRAINT [FK_Categorias_Jugadores] FOREIGN KEY([idJugador])
REFERENCES [dbo].[Jugadores] ([idJugador])
GO
ALTER TABLE [dbo].[Categorias] CHECK CONSTRAINT [FK_Categorias_Jugadores]
GO
ALTER TABLE [dbo].[Director_Tecnico]  WITH CHECK ADD  CONSTRAINT [FK_Director_Tecnico_Categorias] FOREIGN KEY([id_Categoria])
REFERENCES [dbo].[Categorias] ([idCategoria])
GO
ALTER TABLE [dbo].[Director_Tecnico] CHECK CONSTRAINT [FK_Director_Tecnico_Categorias]
GO
ALTER TABLE [dbo].[Estadistica]  WITH CHECK ADD  CONSTRAINT [FK_Estadistica_Temporada] FOREIGN KEY([idTemporada])
REFERENCES [dbo].[Temporada] ([idTemporada])
GO
ALTER TABLE [dbo].[Estadistica] CHECK CONSTRAINT [FK_Estadistica_Temporada]
GO
ALTER TABLE [dbo].[Jugadores]  WITH CHECK ADD  CONSTRAINT [FK_Jugadores_Estadistica] FOREIGN KEY([idEstadistica])
REFERENCES [dbo].[Estadistica] ([idEstadistica])
GO
ALTER TABLE [dbo].[Jugadores] CHECK CONSTRAINT [FK_Jugadores_Estadistica]
GO
