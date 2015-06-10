USE [master]
GO
/****** Object:  Database [HospitalKSR]    Script Date: 2015-06-09 11:01:39 ******/
CREATE DATABASE [HospitalKSR]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HospitalKSR', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\HospitalKSR.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'HospitalKSR_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\HospitalKSR_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [HospitalKSR] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HospitalKSR].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HospitalKSR] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HospitalKSR] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HospitalKSR] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HospitalKSR] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HospitalKSR] SET ARITHABORT OFF 
GO
ALTER DATABASE [HospitalKSR] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HospitalKSR] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [HospitalKSR] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HospitalKSR] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HospitalKSR] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HospitalKSR] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HospitalKSR] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HospitalKSR] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HospitalKSR] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HospitalKSR] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HospitalKSR] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HospitalKSR] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HospitalKSR] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HospitalKSR] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HospitalKSR] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HospitalKSR] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HospitalKSR] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HospitalKSR] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HospitalKSR] SET RECOVERY FULL 
GO
ALTER DATABASE [HospitalKSR] SET  MULTI_USER 
GO
ALTER DATABASE [HospitalKSR] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HospitalKSR] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HospitalKSR] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HospitalKSR] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'HospitalKSR', N'ON'
GO
USE [HospitalKSR]
GO
/****** Object:  Table [dbo].[Alergy]    Script Date: 2015-06-09 11:01:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alergies](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Alergy] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Patient]    Script Date: 2015-06-09 11:01:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patient](
	[Id] [int] NOT NULL,
	[Age] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](200) NOT NULL,
	[PasswordSalt] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Patient] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PatientAlergies]    Script Date: 2015-06-09 11:01:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PatientAlergies](
	[PatientId] [int] NOT NULL,
	[AlergyId] [int] NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[WhenDiagnosed] [datetime] NOT NULL,
	FOREIGN KEY ([PatientId]) REFERENCES Patient(Id),
	FOREIGN KEY ([AlergyId]) REFERENCES Alergies(Id),
	primary key ([PatientId], [AlergyId])
) ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [HospitalKSR] SET  READ_WRITE 
GO
