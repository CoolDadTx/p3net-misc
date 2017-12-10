/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
SET IDENTITY_INSERT Roles ON;

IF NOT EXISTS (SELECT * FROM Roles WHERE Id = 1) INSERT INTO Roles (Id, Name) VALUES (1, 'Administrators')
IF NOT EXISTS (SELECT * FROM Roles WHERE Id = 2) INSERT INTO Roles (Id, Name) VALUES (2, 'Users')

SET IDENTITY_INSERT Roles OFF;

SET IDENTITY_INSERT Users ON;

IF NOT EXISTS (SELECT * FROM Users WHERE Id = 1) INSERT INTO Users (Id, Name) VALUES (1, 'Bob')
IF NOT EXISTS (SELECT * FROM Users WHERE Id = 2) INSERT INTO Users (Id, Name) VALUES (2, 'Sue')
IF NOT EXISTS (SELECT * FROM Users WHERE Id = 3) INSERT INTO Users (Id, Name) VALUES (3, 'Jan')
IF NOT EXISTS (SELECT * FROM Users WHERE Id = 4) INSERT INTO Users (Id, Name) VALUES (4, 'Mark')

SET IDENTITY_INSERT Users OFF;

IF NOT EXISTS (SELECT * FROM UserRoles WHERE UserId = 1 AND RoleId = 1) INSERT INTO UserRoles (UserId, RoleId) VALUES (1, 1)
IF NOT EXISTS (SELECT * FROM UserRoles WHERE UserId = 1 AND RoleId = 2) INSERT INTO UserRoles (UserId, RoleId) VALUES (1, 2)

IF NOT EXISTS (SELECT * FROM UserRoles WHERE UserId = 2 AND RoleId = 1) INSERT INTO UserRoles (UserId, RoleId) VALUES (2, 1)
IF NOT EXISTS (SELECT * FROM UserRoles WHERE UserId = 2 AND RoleId = 2) INSERT INTO UserRoles (UserId, RoleId) VALUES (2, 2)

IF NOT EXISTS (SELECT * FROM UserRoles WHERE UserId = 3 AND RoleId = 2) INSERT INTO UserRoles (UserId, RoleId) VALUES (3, 2)

IF NOT EXISTS (SELECT * FROM UserRoles WHERE UserId = 4 AND RoleId = 2) INSERT INTO UserRoles (UserId, RoleId) VALUES (4, 2)



