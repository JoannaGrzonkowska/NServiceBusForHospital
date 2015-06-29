create database KSR_Director
go

USE KSR_Director
GO

	CREATE TABLE [dbo].[DirectorMessages](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY,
	[Comment] [nvarchar](200) NOT NULL,
	[When] [datetime] NOT NULL,
	[Type] [int] NOT NULL)