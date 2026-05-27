Create Database Attendance;

USE [Attendance]

CREATE TABLE [dbo].[Course](
	[CID] [int] IDENTITY(1,1) NOT NULL,
	[CourseName] [varchar](50) NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[CID] ASC
))

CREATE TABLE [dbo].[Student](
	[STID] [int] IDENTITY(1,1) NOT NULL,
	[SName] [varchar](50) NULL,
	[Roll] [int] NULL,
	[Course] [varchar](50) NULL,
	[Year] [varchar](50) NULL,
	[Phone] [bigint] NULL,
	[Email] [varchar](50) NULL,
	[Sem] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[STID] ASC
))

CREATE TABLE [dbo].[StudentAttendance](
	[AID] [int] IDENTITY(1,1) NOT NULL,
	[STID] [int] NULL,
	[StudentName] [varchar](50) NULL,
	[Course] [varchar](50) NULL,
	[Year] [varchar](50) NULL,
	[Subject] [varchar](50) NULL,
	[Roll] [int] NULL,
	[Status] [int] NULL,
	[Date] [date] NULL,
	[Lecture] [int] NULL,
	[Sem] [varchar](50) NULL,
 CONSTRAINT [PK_StudentAttendance] PRIMARY KEY CLUSTERED 
(
	[AID] ASC
))

CREATE TABLE [dbo].[Subject](
	[SID] [int] IDENTITY(1,1) NOT NULL,
	[CID] [int] NULL,
	[CourseName] [varchar](50) NULL,
	[Year] [varchar](50) NULL,
	[SubjectName] [varchar](50) NULL,
	[Sem] [varchar](50) NULL,
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[SID] ASC
))

CREATE TABLE [dbo].[T_Lectures](
	[TID] [int] NULL,
	[TName] [varchar](50) NULL,
	[Date] [date] NULL,
	[LTaken] [int] NULL,
	[Course] [varchar](50) NULL,
	[Year] [varchar](50) NULL,
	[Subject] [varchar](50) NULL,
	[Sem] [varchar](50) NULL
)

CREATE TABLE [dbo].[Teacher](
	[TID] [int] IDENTITY(1,1) NOT NULL,
	[TName] [varchar](50) NULL,
	[TUserID] [varchar](50) NULL,
	[TPassword] [varchar](50) NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[TID] ASC
))

CREATE TABLE [dbo].[TeacherSubject](
	[TSID] [int] IDENTITY(1,1) NOT NULL,
	[Teacher] [varchar](50) NULL,
	[Course] [varchar](50) NULL,
	[Year] [varchar](50) NULL,
	[Sem] [varchar](50) NULL,
	[Subject] [varchar](50) NULL,
 CONSTRAINT [PK_TeacherSubject] PRIMARY KEY CLUSTERED 
(
	[TSID] ASC
))

