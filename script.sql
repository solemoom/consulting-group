USE [master]
GO
/****** Object:  Database [BIBLIOTECA]    Script Date: 9/6/2019 8:39:13 PM ******/
CREATE DATABASE [BIBLIOTECA]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BIBLIOTECA', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\BIBLIOTECA.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BIBLIOTECA_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\BIBLIOTECA_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BIBLIOTECA] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BIBLIOTECA].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BIBLIOTECA] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BIBLIOTECA] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BIBLIOTECA] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BIBLIOTECA] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BIBLIOTECA] SET ARITHABORT OFF 
GO
ALTER DATABASE [BIBLIOTECA] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BIBLIOTECA] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [BIBLIOTECA] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BIBLIOTECA] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BIBLIOTECA] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BIBLIOTECA] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BIBLIOTECA] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BIBLIOTECA] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BIBLIOTECA] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BIBLIOTECA] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BIBLIOTECA] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BIBLIOTECA] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BIBLIOTECA] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BIBLIOTECA] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BIBLIOTECA] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BIBLIOTECA] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BIBLIOTECA] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BIBLIOTECA] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BIBLIOTECA] SET RECOVERY FULL 
GO
ALTER DATABASE [BIBLIOTECA] SET  MULTI_USER 
GO
ALTER DATABASE [BIBLIOTECA] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BIBLIOTECA] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BIBLIOTECA] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BIBLIOTECA] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BIBLIOTECA', N'ON'
GO
USE [BIBLIOTECA]
GO
/****** Object:  StoredProcedure [dbo].[InsertEstudiante]    Script Date: 9/6/2019 8:39:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertEstudiante]

	@CI nvarchar(10),
	@Nombre nvarchar(50),
	@Direccion nvarchar(255),
	@Carrera nvarchar(50),
	@Edad int

AS

Insert into Estudiante(CI,Nombre,Direccion,Carrera,Edad)
  VALUES (@CI,@Nombre,@direccion,@Carrera,@Edad)


GO
/****** Object:  StoredProcedure [dbo].[SelectLibrobyAutor]    Script Date: 9/6/2019 8:39:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectLibrobyAutor] 

	@Autor nvarchar(255)
AS
	select Libro.Titulo from LibAut 
		join Libro on Libro.IdLibro = LibAut.IdLibro 
		Join Autor on Autor.IdAutor = LibAut.IdAutor 
	Where Autor.Nombre = @Autor


GO
/****** Object:  StoredProcedure [dbo].[UpdateLibrobyIdLibro]    Script Date: 9/6/2019 8:39:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateLibrobyIdLibro]
	@IdLibro int,
	@Titulo nvarchar(255),
	@Editorial nvarchar(255),
	@Area nvarchar(50)
AS
update Libro Set Titulo = @Titulo, Editorial = @Editorial, Area = @Area where IdLibro = @IdLibro

GO
/****** Object:  Table [dbo].[Autor]    Script Date: 9/6/2019 8:39:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Autor](
	[IdAutor] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Nacionalidad] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Autor] PRIMARY KEY CLUSTERED 
(
	[IdAutor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Estudiante]    Script Date: 9/6/2019 8:39:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estudiante](
	[IdLector] [int] IDENTITY(1,1) NOT NULL,
	[CI] [nvarchar](10) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Direccion] [nvarchar](max) NOT NULL,
	[Carrera] [nvarchar](50) NOT NULL,
	[Edad] [int] NOT NULL,
 CONSTRAINT [PK_Estudiante] PRIMARY KEY CLUSTERED 
(
	[IdLector] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LibAut]    Script Date: 9/6/2019 8:39:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LibAut](
	[IdAutor] [int] NULL,
	[IdLibro] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Libro]    Script Date: 9/6/2019 8:39:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Libro](
	[IdLibro] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [nvarchar](max) NOT NULL,
	[Editorial] [nvarchar](max) NOT NULL,
	[Area] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Libro] PRIMARY KEY CLUSTERED 
(
	[IdLibro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Prestamo]    Script Date: 9/6/2019 8:39:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prestamo](
	[IdLector] [int] NULL,
	[IdLibro] [int] NULL,
	[FechaPrestamo] [date] NOT NULL,
	[FechaDevolucion] [date] NOT NULL,
	[Devuelto] [bit] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  UserDefinedFunction [dbo].[ListarPrestamo]    Script Date: 9/6/2019 8:39:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Function [dbo].[ListarPrestamo](@Estudiante nvarchar(50))
Returns Table
AS
       Return (select Libro.Titulo from Prestamo
	Join Libro on Libro.IdLibro = Prestamo.IdLibro
	join Estudiante on Estudiante.IdLector = Prestamo.IdLector	
Where Estudiante.Nombre = @Estudiante
)
GO
SET IDENTITY_INSERT [dbo].[Autor] ON 

INSERT [dbo].[Autor] ([IdAutor], [Nombre], [Nacionalidad]) VALUES (1, N'Mario Benedetti', N'Francia')
INSERT [dbo].[Autor] ([IdAutor], [Nombre], [Nacionalidad]) VALUES (2, N'Julio', N'USA')
INSERT [dbo].[Autor] ([IdAutor], [Nombre], [Nacionalidad]) VALUES (3, N'Maria Suarez', N'España')
INSERT [dbo].[Autor] ([IdAutor], [Nombre], [Nacionalidad]) VALUES (4, N'Leonardo', N'Italia')
INSERT [dbo].[Autor] ([IdAutor], [Nombre], [Nacionalidad]) VALUES (5, N'Julieta', N'USA')
SET IDENTITY_INSERT [dbo].[Autor] OFF
SET IDENTITY_INSERT [dbo].[Estudiante] ON 

INSERT [dbo].[Estudiante] ([IdLector], [CI], [Nombre], [Direccion], [Carrera], [Edad]) VALUES (1, N'C00001', N'Alfredo', N'Plaza España', N'Informatica', 23)
INSERT [dbo].[Estudiante] ([IdLector], [CI], [Nombre], [Direccion], [Carrera], [Edad]) VALUES (2, N'C00002', N'Andrea Garmendia', N'Merida', N'Literatura', 22)
INSERT [dbo].[Estudiante] ([IdLector], [CI], [Nombre], [Direccion], [Carrera], [Edad]) VALUES (3, N'C00003', N'Ramiro Flores', N'Bilbao', N'Informatica', 26)
INSERT [dbo].[Estudiante] ([IdLector], [CI], [Nombre], [Direccion], [Carrera], [Edad]) VALUES (4, N'C00004', N'Felipe Loayza Beramendi', N'Cartago', N'Ciencias', 21)
INSERT [dbo].[Estudiante] ([IdLector], [CI], [Nombre], [Direccion], [Carrera], [Edad]) VALUES (5, N'C00005', N'Emelina Perez Acevedo', N'Colon', N'Literatura', 21)
INSERT [dbo].[Estudiante] ([IdLector], [CI], [Nombre], [Direccion], [Carrera], [Edad]) VALUES (6, N'C000006', N'Federico Lopez', N'Villa Fontana', N'Actuariales', 25)
INSERT [dbo].[Estudiante] ([IdLector], [CI], [Nombre], [Direccion], [Carrera], [Edad]) VALUES (7, N'C00007', N'Patricia', N'Sevilla', N'Artes', 20)
SET IDENTITY_INSERT [dbo].[Estudiante] OFF
INSERT [dbo].[LibAut] ([IdAutor], [IdLibro]) VALUES (1, 1)
INSERT [dbo].[LibAut] ([IdAutor], [IdLibro]) VALUES (2, 2)
INSERT [dbo].[LibAut] ([IdAutor], [IdLibro]) VALUES (3, 3)
INSERT [dbo].[LibAut] ([IdAutor], [IdLibro]) VALUES (4, 4)
INSERT [dbo].[LibAut] ([IdAutor], [IdLibro]) VALUES (5, 5)
INSERT [dbo].[LibAut] ([IdAutor], [IdLibro]) VALUES (1, 6)
INSERT [dbo].[LibAut] ([IdAutor], [IdLibro]) VALUES (2, 7)
INSERT [dbo].[LibAut] ([IdAutor], [IdLibro]) VALUES (3, 8)
SET IDENTITY_INSERT [dbo].[Libro] ON 

INSERT [dbo].[Libro] ([IdLibro], [Titulo], [Editorial], [Area]) VALUES (1, N'Base de Datos', N'Alfa', N'Internet')
INSERT [dbo].[Libro] ([IdLibro], [Titulo], [Editorial], [Area]) VALUES (2, N'Titulo 2', N'Omega', N'Literatura')
INSERT [dbo].[Libro] ([IdLibro], [Titulo], [Editorial], [Area]) VALUES (3, N'Visual Studio Net', N'Editorial', N'Internet')
INSERT [dbo].[Libro] ([IdLibro], [Titulo], [Editorial], [Area]) VALUES (4, N'Titulo 4', N'Alfa', N'Literatura')
INSERT [dbo].[Libro] ([IdLibro], [Titulo], [Editorial], [Area]) VALUES (5, N'Ciencias', N'Alfa', N'Ciencias')
INSERT [dbo].[Libro] ([IdLibro], [Titulo], [Editorial], [Area]) VALUES (6, N'Titulo 5', N'Omega', N'Ciencias')
INSERT [dbo].[Libro] ([IdLibro], [Titulo], [Editorial], [Area]) VALUES (7, N'Titulo 6', N'Editorial', N'Ciencias')
INSERT [dbo].[Libro] ([IdLibro], [Titulo], [Editorial], [Area]) VALUES (8, N'Base de Datos', N'Omega', N'Internet')
INSERT [dbo].[Libro] ([IdLibro], [Titulo], [Editorial], [Area]) VALUES (9, N'Titulo 8 ', N'Editorial', N'Literatura')
SET IDENTITY_INSERT [dbo].[Libro] OFF
INSERT [dbo].[Prestamo] ([IdLector], [IdLibro], [FechaPrestamo], [FechaDevolucion], [Devuelto]) VALUES (1, 1, CAST(0x1D400B00 AS Date), CAST(0x24400B00 AS Date), 0)
INSERT [dbo].[Prestamo] ([IdLector], [IdLibro], [FechaPrestamo], [FechaDevolucion], [Devuelto]) VALUES (2, 2, CAST(0x3B400B00 AS Date), CAST(0x25400B00 AS Date), 0)
INSERT [dbo].[Prestamo] ([IdLector], [IdLibro], [FechaPrestamo], [FechaDevolucion], [Devuelto]) VALUES (3, 3, CAST(0xDE3F0B00 AS Date), CAST(0x11400B00 AS Date), 1)
INSERT [dbo].[Prestamo] ([IdLector], [IdLibro], [FechaPrestamo], [FechaDevolucion], [Devuelto]) VALUES (4, 4, CAST(0xC83F0B00 AS Date), CAST(0xCD3F0B00 AS Date), 1)
INSERT [dbo].[Prestamo] ([IdLector], [IdLibro], [FechaPrestamo], [FechaDevolucion], [Devuelto]) VALUES (5, 5, CAST(0xFD2E0B00 AS Date), CAST(0x182F0B00 AS Date), 0)
INSERT [dbo].[Prestamo] ([IdLector], [IdLibro], [FechaPrestamo], [FechaDevolucion], [Devuelto]) VALUES (1, 6, CAST(0x1F400B00 AS Date), CAST(0x29400B00 AS Date), 0)
INSERT [dbo].[Prestamo] ([IdLector], [IdLibro], [FechaPrestamo], [FechaDevolucion], [Devuelto]) VALUES (2, 7, CAST(0x05400B00 AS Date), CAST(0x1F400B00 AS Date), 0)
INSERT [dbo].[Prestamo] ([IdLector], [IdLibro], [FechaPrestamo], [FechaDevolucion], [Devuelto]) VALUES (3, 8, CAST(0x9B2E0B00 AS Date), CAST(0x182F0B00 AS Date), 1)
ALTER TABLE [dbo].[LibAut]  WITH CHECK ADD FOREIGN KEY([IdAutor])
REFERENCES [dbo].[Autor] ([IdAutor])
GO
ALTER TABLE [dbo].[LibAut]  WITH CHECK ADD FOREIGN KEY([IdLibro])
REFERENCES [dbo].[Libro] ([IdLibro])
GO
ALTER TABLE [dbo].[Prestamo]  WITH CHECK ADD  CONSTRAINT [FK__Prestamo__IdLect__15502E78] FOREIGN KEY([IdLector])
REFERENCES [dbo].[Estudiante] ([IdLector])
GO
ALTER TABLE [dbo].[Prestamo] CHECK CONSTRAINT [FK__Prestamo__IdLect__15502E78]
GO
ALTER TABLE [dbo].[Prestamo]  WITH CHECK ADD FOREIGN KEY([IdLibro])
REFERENCES [dbo].[Libro] ([IdLibro])
GO
/****** Object:  Trigger [dbo].[SelectEstudiantes]    Script Date: 9/6/2019 8:39:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[SelectEstudiantes]
      ON [dbo].[Estudiante]
      AFTER INSERT
      AS
        BEGIN
         SELECT * FROM Estudiante
        END
GO
USE [master]
GO
ALTER DATABASE [BIBLIOTECA] SET  READ_WRITE 
GO
