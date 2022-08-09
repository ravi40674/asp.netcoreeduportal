CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET utf8mb4;

START TRANSACTION;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20220209090233_createdata') THEN

    ALTER DATABASE CHARACTER SET utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20220209090233_createdata') THEN

    CREATE TABLE `tblRole` (
        `RoleId` int NOT NULL AUTO_INCREMENT,
        `Role` longtext CHARACTER SET utf8mb4 NULL,
        `Description` longtext CHARACTER SET utf8mb4 NULL,
        `IsActive` tinyint(1) NOT NULL,
        `IsAdminRole` tinyint(1) NOT NULL,
        CONSTRAINT `PK_tblRole` PRIMARY KEY (`RoleId`)
    ) CHARACTER SET utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20220209090233_createdata') THEN

    CREATE TABLE `tblRolePrivileges` (
        `PrivilegeID` int NOT NULL AUTO_INCREMENT,
        `MenuItemID` int NOT NULL,
        `MenuItem` longtext CHARACTER SET utf8mb4 NULL,
        `MenuItemController` longtext CHARACTER SET utf8mb4 NULL,
        `MenuItemView` longtext CHARACTER SET utf8mb4 NULL,
        `View` tinyint(1) NOT NULL,
        `Add` tinyint(1) NOT NULL,
        `Edit` tinyint(1) NOT NULL,
        `Delete` tinyint(1) NOT NULL,
        `Detail` tinyint(1) NOT NULL,
        `ParentID` int NOT NULL,
        `SortOrder` int NOT NULL,
        `IsActive` tinyint(1) NOT NULL,
        `DesignationID` int NOT NULL,
        `EmployeeID` int NULL,
        CONSTRAINT `PK_tblRolePrivileges` PRIMARY KEY (`PrivilegeID`)
    ) CHARACTER SET utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20220209090233_createdata') THEN

    CREATE TABLE `tblUser` (
        `UserID` int NOT NULL AUTO_INCREMENT,
        `FirstName` longtext CHARACTER SET utf8mb4 NULL,
        `LastName` longtext CHARACTER SET utf8mb4 NULL,
        `MobileNumber` longtext CHARACTER SET utf8mb4 NULL,
        `Email` longtext CHARACTER SET utf8mb4 NULL,
        `Password` longtext CHARACTER SET utf8mb4 NULL,
        `Address` longtext CHARACTER SET utf8mb4 NULL,
        `RoleID` int NOT NULL,
        CONSTRAINT `PK_tblUser` PRIMARY KEY (`UserID`)
    ) CHARACTER SET utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20220209090233_createdata') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20220209090233_createdata', '5.0.14');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

COMMIT;

