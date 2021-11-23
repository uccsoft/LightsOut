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

CREATE TABLE [GameSettings] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [BoardSize] int NOT NULL,
    CONSTRAINT [PK_GameSettings] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211120132219_Create-GameSettings-Table', N'5.0.12');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'BoardSize', N'Name') AND [object_id] = OBJECT_ID(N'[GameSettings]'))
    SET IDENTITY_INSERT [GameSettings] ON;
INSERT INTO [GameSettings] ([Id], [BoardSize], [Name])
VALUES (1, 5, N'5 x 5');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'BoardSize', N'Name') AND [object_id] = OBJECT_ID(N'[GameSettings]'))
    SET IDENTITY_INSERT [GameSettings] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'BoardSize', N'Name') AND [object_id] = OBJECT_ID(N'[GameSettings]'))
    SET IDENTITY_INSERT [GameSettings] ON;
INSERT INTO [GameSettings] ([Id], [BoardSize], [Name])
VALUES (2, 8, N'8 x 8');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'BoardSize', N'Name') AND [object_id] = OBJECT_ID(N'[GameSettings]'))
    SET IDENTITY_INSERT [GameSettings] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'BoardSize', N'Name') AND [object_id] = OBJECT_ID(N'[GameSettings]'))
    SET IDENTITY_INSERT [GameSettings] ON;
INSERT INTO [GameSettings] ([Id], [BoardSize], [Name])
VALUES (3, 10, N'10 x 10');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'BoardSize', N'Name') AND [object_id] = OBJECT_ID(N'[GameSettings]'))
    SET IDENTITY_INSERT [GameSettings] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211120134409_Seed-GameSettings-Table', N'5.0.12');
GO

COMMIT;
GO

