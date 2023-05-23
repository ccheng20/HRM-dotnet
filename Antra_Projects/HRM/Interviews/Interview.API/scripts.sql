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

CREATE TABLE [Interviewers] (
    [Id] int NOT NULL IDENTITY,
    [Email] nvarchar(1000) NOT NULL,
    [EmployeeIdentityId] int NOT NULL,
    [FirstName] nvarchar(50) NOT NULL,
    [LastName] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Interviewers] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Interviews] (
    [Id] int NOT NULL IDENTITY,
    [BeginTime] datetime2 NOT NULL,
    [CandidateEmail] nvarchar(max) NOT NULL,
    [CandidateFirstName] nvarchar(50) NOT NULL,
    [CandidateId] int NOT NULL,
    [CandidateLastName] nvarchar(50) NOT NULL,
    [EndTime] datetime2 NOT NULL,
    [Feedback] nvarchar(max) NULL,
    [InterviewerId] int NOT NULL,
    [InterviewTypeId] int NOT NULL,
    [Passed] bit NULL,
    [Rating] int NULL,
    [SubmissionId] int NOT NULL,
    CONSTRAINT [PK_Interviews] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [InterviewTypeLookUps] (
    [Id] int NOT NULL IDENTITY,
    [InterviewTypeCode] nvarchar(50) NOT NULL,
    [InterviewTypeDescription] nvarchar(256) NOT NULL,
    CONSTRAINT [PK_InterviewTypeLookUps] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230517050354_InitialMigration', N'8.0.0-preview.4.23259.3');
GO

COMMIT;
GO

