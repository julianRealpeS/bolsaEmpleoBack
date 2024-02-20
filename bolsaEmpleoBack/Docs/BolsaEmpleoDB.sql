USE [master]
GO
/****** Object:  Database [BolsaEmpleoDB]    Script Date: 20/02/2024 09:35:32 a. m. ******/
CREATE DATABASE [BolsaEmpleoDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BolsaEmpleoDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER01\MSSQL\DATA\BolsaEmpleoDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BolsaEmpleoDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER01\MSSQL\DATA\BolsaEmpleoDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [BolsaEmpleoDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BolsaEmpleoDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BolsaEmpleoDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BolsaEmpleoDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BolsaEmpleoDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BolsaEmpleoDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BolsaEmpleoDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [BolsaEmpleoDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BolsaEmpleoDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BolsaEmpleoDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BolsaEmpleoDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BolsaEmpleoDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BolsaEmpleoDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BolsaEmpleoDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BolsaEmpleoDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BolsaEmpleoDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BolsaEmpleoDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BolsaEmpleoDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BolsaEmpleoDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BolsaEmpleoDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BolsaEmpleoDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BolsaEmpleoDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BolsaEmpleoDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BolsaEmpleoDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BolsaEmpleoDB] SET RECOVERY FULL 
GO
ALTER DATABASE [BolsaEmpleoDB] SET  MULTI_USER 
GO
ALTER DATABASE [BolsaEmpleoDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BolsaEmpleoDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BolsaEmpleoDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BolsaEmpleoDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BolsaEmpleoDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BolsaEmpleoDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BolsaEmpleoDB', N'ON'
GO
ALTER DATABASE [BolsaEmpleoDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [BolsaEmpleoDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [BolsaEmpleoDB]
GO
/****** Object:  Table [dbo].[ciudadano]    Script Date: 20/02/2024 09:35:32 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ciudadano](
	[ciudadano_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[tipo_documento_id] [numeric](18, 0) NOT NULL,
	[cedula] [varchar](50) NOT NULL,
	[nombres] [varchar](50) NOT NULL,
	[apellidos] [varchar](50) NOT NULL,
	[fecha_nacimiento] [date] NOT NULL,
	[profesion] [varchar](50) NOT NULL,
	[aspiracion_salarial] [numeric](18, 0) NOT NULL,
	[correo_electronico] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ciudadano] PRIMARY KEY CLUSTERED 
(
	[ciudadano_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipo_documento]    Script Date: 20/02/2024 09:35:32 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipo_documento](
	[tipo_documento_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tipo_documento] PRIMARY KEY CLUSTERED 
(
	[tipo_documento_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vacante_ofertada]    Script Date: 20/02/2024 09:35:32 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vacante_ofertada](
	[vacante_ofertada_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[codigo] [varchar](50) NOT NULL,
	[cargo] [varchar](50) NOT NULL,
	[descripcion] [ntext] NOT NULL,
	[empresa] [varchar](50) NOT NULL,
	[salario] [numeric](18, 0) NOT NULL,
	[ciudadano_id] [numeric](18, 0) NULL,
 CONSTRAINT [PK_vacante_ofertada] PRIMARY KEY CLUSTERED 
(
	[vacante_ofertada_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[ciudadano]  WITH CHECK ADD  CONSTRAINT [FK_ciudadano_tipo_documento] FOREIGN KEY([tipo_documento_id])
REFERENCES [dbo].[tipo_documento] ([tipo_documento_id])
GO
ALTER TABLE [dbo].[ciudadano] CHECK CONSTRAINT [FK_ciudadano_tipo_documento]
GO
ALTER TABLE [dbo].[vacante_ofertada]  WITH CHECK ADD  CONSTRAINT [FK_vacante_ofertada_ciudadano] FOREIGN KEY([ciudadano_id])
REFERENCES [dbo].[ciudadano] ([ciudadano_id])
GO
ALTER TABLE [dbo].[vacante_ofertada] CHECK CONSTRAINT [FK_vacante_ofertada_ciudadano]
GO
USE [master]
GO
ALTER DATABASE [BolsaEmpleoDB] SET  READ_WRITE 
GO
