create database KSR_Ward
go

USE KSR_Ward
GO
CREATE TABLE [dbo].[Patients](
	[Id] [int] PRIMARY KEY identity(1,1),
	[Age] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	ExtPatientId [int] NOT NULL
 )
CREATE TABLE [dbo].[PatientsDieseases](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY,
	[PatientId] [int] NOT NULL references [Patients],
	[Description] [nvarchar](200) NOT NULL,
	ExtPatientDieseaseId [int] NOT NULL
 )

 
CREATE TABLE [dbo].[Examinations](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY,
	[PatientDieseaseId] [int] NOT NULL references [PatientsDieseases],
	[ExaminationType] [int] NOT NULL,
	[LogType] [int] NOT NULL,
	[Comment] [nvarchar](200) NOT NULL,
	[WhenExamined] [datetime] NOT NULL)


	CREATE TABLE [dbo].[DirectorMessages](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY,
	[Comment] [nvarchar](200) NOT NULL,
	[When] [datetime] NOT NULL,
	ExtDirectorMessageId [int] NOT NULL)