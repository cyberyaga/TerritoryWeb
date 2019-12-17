--Create Username
CREATE LOGIN TerritoryWebDbUser WITH PASSWORD = 'TerritoryWebDbPWD123'
GO

EXEC master..sp_addsrvrolemember @loginame = N'TerritoryWebDbUser', @rolename = N'dbcreator'
GO
--Create Username END


--Use this is permissions are bad.
Use TerritoryWebDB;
GO

IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'TerritoryWebDbUser')
BEGIN
    CREATE USER [TerritoryWebDbUser] FOR LOGIN [TerritoryWebDbUser]
    EXEC sp_addrolemember N'db_owner', N'TerritoryWebDbUser'
END;
GO