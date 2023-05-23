IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Employees] (
    [Id] int NOT NULL IDENTITY,
    [Address] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [EmployeeIdentityId] int NOT NULL,
    [EmployeeStatusId] int NOT NULL,
    [EndDate] datetime2 NOT NULL,
    [FirstName] nvarchar(max) NOT NULL,
    [HireDate] datetime2 NOT NULL,
    [LastName] nvarchar(max) NOT NULL,
    [MiddleName] nvarchar(max) NOT NULL,
    [SSN] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [EmployeeStatusLookUps] (
    [Id] int NOT NULL IDENTITY,
    [EmployeeStatusCode] nvarchar(max) NOT NULL,
    [EmployeeStatusDescription] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_EmployeeStatusLookUps] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230518041646_InitialMigration', N'8.0.0-preview.4.23259.3');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[EmployeeStatusLookUps]') AND [c].[name] = N'EmployeeStatusDescription');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [EmployeeStatusLookUps] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [EmployeeStatusLookUps] ALTER COLUMN [EmployeeStatusDescription] nvarchar(1024) NOT NULL;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[EmployeeStatusLookUps]') AND [c].[name] = N'EmployeeStatusCode');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [EmployeeStatusLookUps] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [EmployeeStatusLookUps] ALTER COLUMN [EmployeeStatusCode] nvarchar(64) NOT NULL;
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Employees]') AND [c].[name] = N'SSN');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Employees] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Employees] ALTER COLUMN [SSN] nvarchar(2048) NOT NULL;
GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Employees]') AND [c].[name] = N'MiddleName');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Employees] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Employees] ALTER COLUMN [MiddleName] nvarchar(50) NULL;
GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Employees]') AND [c].[name] = N'LastName');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Employees] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Employees] ALTER COLUMN [LastName] nvarchar(50) NOT NULL;
GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Employees]') AND [c].[name] = N'HireDate');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Employees] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [Employees] ALTER COLUMN [HireDate] datetime2 NULL;
GO

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Employees]') AND [c].[name] = N'FirstName');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Employees] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [Employees] ALTER COLUMN [FirstName] nvarchar(50) NOT NULL;
GO

DECLARE @var7 sysname;
SELECT @var7 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Employees]') AND [c].[name] = N'EndDate');
IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [Employees] DROP CONSTRAINT [' + @var7 + '];');
ALTER TABLE [Employees] ALTER COLUMN [EndDate] datetime2 NULL;
GO

DECLARE @var8 sysname;
SELECT @var8 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Employees]') AND [c].[name] = N'Email');
IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [Employees] DROP CONSTRAINT [' + @var8 + '];');
ALTER TABLE [Employees] ALTER COLUMN [Email] nvarchar(2048) NOT NULL;
GO

DECLARE @var9 sysname;
SELECT @var9 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Employees]') AND [c].[name] = N'Address');
IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [Employees] DROP CONSTRAINT [' + @var9 + '];');
ALTER TABLE [Employees] ALTER COLUMN [Address] nvarchar(max) NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230518043602_UpdateOnboardingDb', N'8.0.0-preview.4.23259.3');
GO

COMMIT;
GO

