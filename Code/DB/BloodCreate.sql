create database KSR_Blood
go

USE KSR_Blood
GO


CREATE TABLE [dbo].[Examinations](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY,
	[ExtPatientDieseaseId] [int] NOT NULL ,
	[LogType] [int] NOT NULL,
	[Comment] [nvarchar](200) NOT NULL,
	[WhenExamined] [datetime] NOT NULL)
