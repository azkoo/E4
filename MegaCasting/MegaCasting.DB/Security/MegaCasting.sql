/*CREATE USER [MegaCasting] FOR LOGIN [MegaCasting];
*/
/*CREATE LOGIN [MegaCasting] WITH PASSWORD = '?-M_63-M_?'
GO
CREATE USER [MegaCasting] FOR LOGIN [MegaCasting]
    WITH DEFAULT_SCHEMA = [db_owner];


GO


CREATE LOGIN [MegaCasting] WITH PASSWORD=N'6?3_-_M*M', DEFAULT_DATABASE=[MegaCastingBD], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
ALTER SERVER ROLE [dbcreator] ADD MEMBER [MegaCasting]
GO
USE [MegaCastingBD]
GO
CREATE USER [MegaCasting]
    WITH DEFAULT_SCHEMA = [db_owner];


GO
USE [MegaCastingBD]
GO
ALTER USER [MegaCasting] WITH DEFAULT_SCHEMA=[db_owner]
GO
USE [MegaCastingBD]
GO

GO*/