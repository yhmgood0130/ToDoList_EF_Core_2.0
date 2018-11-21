IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Schedules] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [StartDate] datetime2 NOT NULL,
    [EndDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Schedules] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [ToDoLists] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [ScheduleId] int NOT NULL,
    CONSTRAINT [PK_ToDoLists] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ToDoLists_Schedules_ScheduleId] FOREIGN KEY ([ScheduleId]) REFERENCES [Schedules] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Tasks] (
    [Id] int NOT NULL IDENTITY,
    [Text] nvarchar(max) NULL,
    [ToDoListId] int NOT NULL,
    CONSTRAINT [PK_Tasks] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Tasks_ToDoLists_ToDoListId] FOREIGN KEY ([ToDoListId]) REFERENCES [ToDoLists] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Tasks_ToDoListId] ON [Tasks] ([ToDoListId]);

GO

CREATE INDEX [IX_ToDoLists_ScheduleId] ON [ToDoLists] ([ScheduleId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20181119202602_initial', N'2.1.4-rtm-31024');

GO

