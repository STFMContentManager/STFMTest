-------------------------------------------------------------------------------
--	C-CreateDatabaseUser.sql
--	This SQL script is responsible for creating the database user required for
--	TimeRep operation.
-------------------------------------------------------------------------------
USE [master]
GO
CREATE LOGIN [TimeRep]
	WITH PASSWORD=N'TimeRep',
	DEFAULT_DATABASE=[TimeRep],
	CHECK_EXPIRATION=OFF,
	CHECK_POLICY=OFF
GO
USE [TimeRep]
GO
CREATE USER [TimeRep] FOR LOGIN [TimeRep]
GO
USE [TimeRep]
GO
EXEC sp_addrolemember N'db_owner', N'TimeRep'
GO
