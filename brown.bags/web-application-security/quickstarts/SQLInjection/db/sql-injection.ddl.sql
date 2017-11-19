CREATE DATABASE [SqlInjection];
GO

USE [SqlInjection];
GO

CREATE TABLE DataEntry (
	[Id] INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(55),
	[Created] DATETIME DEFAULT GETDATE()
);
GO

TRUNCATE TABLE [DataEntry];
INSERT INTO [DataEntry] ([Name])
VALUES 
	('Entry 1'),
	('Entry 2'),
	('Entry 3'),
	('Entry 4'),
	('Entry 5'),
	('Entry 6'),
	('Entry 7'),
	('Entry 8'),
	('Entry 9'),
	('Entry 10');