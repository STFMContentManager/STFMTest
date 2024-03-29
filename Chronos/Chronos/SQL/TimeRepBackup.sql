-------------------------------------------------------------------------------
--	TimeRepBackup.sql
--	This SQL script backs up the TimeRep database to an external file.
--
--	Make sure to edit the path and file names before executing this script!
-------------------------------------------------------------------------------
BACKUP DATABASE [TimeRep]
	TO  DISK = N'G:\Backups\TimeRep.bak'
	WITH FORMAT, INIT,
	MEDIADESCRIPTION = N'TimeRep',
	MEDIANAME = N'TimeRep',
	NAME = N'TimeRep-Full Database Backup',
	SKIP, NOREWIND, NOUNLOAD,  STATS = 10, CHECKSUM
GO

DECLARE @backupSetId AS INTEGER
SELECT @backupSetId = position
	FROM msdb..backupset
	WHERE database_name=N'TimeRep' and
		backup_set_id=(SELECT max(backup_set_id) FROM msdb..backupset
			WHERE database_name=N'TimeRep' )

if @backupSetId is null
begin
	raiserror(N'Verify failed. Backup information for database ''TimeRep'' not found.', 16, 1)
end

RESTORE VERIFYONLY
	FROM DISK = N'G:\Backups\TimeRep.bak'
	WITH FILE = @backupSetId,
	NOUNLOAD, NOREWIND
GO
