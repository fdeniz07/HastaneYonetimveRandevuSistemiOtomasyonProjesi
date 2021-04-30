USE [master]
GO

/****** Object:  Database [HastaneProje]    Script Date: 30.04.2021 18:23:45 ******/
CREATE DATABASE [HastaneProje]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HastaneProje', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\HastaneProje.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HastaneProje_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\HastaneProje_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HastaneProje].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [HastaneProje] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [HastaneProje] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [HastaneProje] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [HastaneProje] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [HastaneProje] SET ARITHABORT OFF 
GO

ALTER DATABASE [HastaneProje] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [HastaneProje] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [HastaneProje] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [HastaneProje] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [HastaneProje] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [HastaneProje] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [HastaneProje] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [HastaneProje] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [HastaneProje] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [HastaneProje] SET  DISABLE_BROKER 
GO

ALTER DATABASE [HastaneProje] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [HastaneProje] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [HastaneProje] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [HastaneProje] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [HastaneProje] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [HastaneProje] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [HastaneProje] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [HastaneProje] SET RECOVERY FULL 
GO

ALTER DATABASE [HastaneProje] SET  MULTI_USER 
GO

ALTER DATABASE [HastaneProje] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [HastaneProje] SET DB_CHAINING OFF 
GO

ALTER DATABASE [HastaneProje] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [HastaneProje] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [HastaneProje] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [HastaneProje] SET QUERY_STORE = OFF
GO

ALTER DATABASE [HastaneProje] SET  READ_WRITE 
GO

