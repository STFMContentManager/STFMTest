-------------------------------------------------------------------------------
--	TimeRepRestore.sql
--	This SQL script restores a database backup.
--
--	Make sure to change the path and file names before executing this script!
-------------------------------------------------------------------------------
RESTORE DATABASE [TimeRep]
	FROM DISK = N'G:\Backups\TimeRep.bak'
	WITH  FILE = 1,
	NOUNLOAD, REPLACE, STATS = 10
GO
