CREATE DATABASE ConsultorioMedico 

CREATE TABLE [dbo].[Rol](
[RolId] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
[Name] [varchar] (50) NOT NULL,
[Status] [TinyInt] NOT NUll 
)
GO
CREATE TABLE [dbo].[Patient](
[PatientId] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
[Name] [varchar] (50) NOT NULL,
[LastName] [varchar] (50) NOT NULL,
[Telefono] [varchar] (50) NOT NULL,
[DUI] [varchar] (50) NOT NULL,
)
GO
CREATE TABLE [dbo].[Schedules](
[SchedulesId] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
[DayName] [varchar] (50) NOT NULL,
[StartOfShift] [decimal] (10,2) NOT NUll,
[EndOfShift] [decimal] (10,2) NOT NULL
)
GO
CREATE TABLE [dbo].[WorkPlaces](
[WorkPlacesId] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
[WorkPlaces] [varchar] (50) NOT NULL 
)
GO

CREATE TABLE [dbo].[Specialties](
[SpecialtiesId] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
[Specialty] [varchar] (50) NOT NULL 
)
GO

CREATE TABLE [dbo].[Users] (
	[UserId] [int] Primary key Identity(1,1) NOT NULL,
	[RolId] [int] NOT NULL,
	[WorkplaceId] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[PhoneNumber] [varchar](10) NOT NULL,
	[Dui] [varchar](25) NOT NULL,
	[Email] [varchar](25) NOT NULL,
	[Login] [varchar](25) NOT NULL,
	[Password] [char](100) NOT NULL,
	[Status] [TinyInt] NOT NULL,
	[FechaRegistro] [DateTime] NOT NULL
	CONSTRAINT FK1_Rol_Usuario FOREIGN KEY (RolId) REFERENCES Rol (RolId),
	CONSTRAINT FK2_WorkPLace_Usuario FOREIGN KEY (WorkplaceId) REFERENCES WorkPlaces (WorkPlacesId)
)
GO


CREATE TABLE [dbo].[UserSchedules](
[UserSchedulesId] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
[UserId] [int] NOT NULL,
[SpecialtieId] [int] NOT NULL,
[SchedulesId] [int] NOT NULL,
[NumberHoursFree] DECIMAL(10, 2) NOT NULL,
[NumberHoursUsed] DECIMAL(10, 2) NOT NULL,
[NumberOfHours] int NOT NULL,
CONSTRAINT FK1_UserSchedules_Usuario FOREIGN KEY (UserId) REFERENCES Users (UserId),
CONSTRAINT FK2_UserSchedules_Schedules FOREIGN KEY (SchedulesId) REFERENCES Schedules (SchedulesId),
CONSTRAINT FK3_UserSchedules_Specialtie FOREIGN KEY (SpecialtieId) REFERENCES Specialties (SpecialtiesId)
)
GO


CREATE TABLE [dbo].[DoctorSpecialties] (
[DoctorSpecialtiesId] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
[UserId] [int] NOT NULL,
[SpecialtieId] [int] NOT NULL
CONSTRAINT FK1_DocSpecialtie_Usuario FOREIGN KEY (UserId) REFERENCES Users (UserId),
CONSTRAINT FK2_DocSpecialtie_Specialtie FOREIGN KEY (SpecialtieId) REFERENCES Specialties (SpecialtiesId)
)
GO

CREATE TABLE [dbo].[Clinics] (
	[ClinicsId] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[OfficeName] [varchar] (50) NOT NULL,
	[OfficeAddres] [varchar] (50) NOT NULL,
	[OfficeEmail] [varchar] (50) NOT NULL,
	[OfficePhone] [varchar] (15) NOT NULL
	CONSTRAINT FK1_Clinics_Usuario FOREIGN KEY (UserId) REFERENCES Users (UserId)
)
GO

CREATE TABLE [dbo].[Appointment] (
	[AppointmentId] [int] primary key identity(1000, 2) NOT NULL,
	[UserSchedulesId] [int] NOT NULL,
	[PatientId] [int] NOT NULL,
	[Reason] [varchar](200) NOT NULL,
	[Appointment_date] datetime NOT NULL,
	[EndOfAppoinmet] datetime NOT NULL,
	[Status] [tinyint] NOT NULL
	CONSTRAINT FK1_Appointment_Usuario FOREIGN KEY (UserSchedulesId) REFERENCES UserSchedules (UserSchedulesId),
	CONSTRAINT FK2_Appointment_Patient FOREIGN KEY (PatientId) REFERENCES Patient (PatientId)
)
GO