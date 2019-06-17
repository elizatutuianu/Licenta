CREATE TABLE [dbo].[Students] (
    [Email]                 NVARCHAR (MAX) NULL,
    [Password]              NVARCHAR (MAX) NULL,
    [ConfirmPassword]       NVARCHAR (MAX) NULL,
    [IsAdmin]               BIT            NULL,
    [Id]                    INT            IDENTITY (1, 1) NOT NULL,
    [Cnp]                   NVARCHAR (13)  NOT NULL,
    [FirstName]             NVARCHAR (MAX) NOT NULL,
    [LastName]              NVARCHAR (MAX) NOT NULL,
    [Initial]               NVARCHAR (MAX) NOT NULL,
    [FacultyId]             INT            NOT NULL,
    [SpecializationId]      INT            NOT NULL,
    [StudyProgram]          NVARCHAR (MAX) NOT NULL,
    [Year]                  NVARCHAR (MAX) NOT NULL,
    [IsSocialCase]          BIT            NOT NULL,
    [IsMedicalCase]         BIT            NOT NULL,
    [Media]                 REAL           NOT NULL,
    [Sex]                   NVARCHAR (MAX) NOT NULL,
    [Taxa_buget]            NVARCHAR (MAX) NOT NULL,
    [Group]                 INT            NOT NULL,
    [Credits]               INT            NOT NULL,
    [PhoneNo]               NVARCHAR (MAX) NOT NULL,
    [AccomodationRequestId] INT            NULL,
    [IdCardStudent1Id]      INT            NOT NULL,
    [LanguageOfStudy1]      NVARCHAR (MAX) NOT NULL,
    [RoomId]                INT            NULL,
    CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Students_AccomodationRequest_AccomodationRequestId] FOREIGN KEY ([AccomodationRequestId]) REFERENCES [dbo].[AccomodationRequest] ([Id]),
    CONSTRAINT [FK_Students_Faculty_FacultyId] FOREIGN KEY ([FacultyId]) REFERENCES [dbo].[Faculty] ([Id]),
    CONSTRAINT [FK_Students_IdCardStudent_IdCardStudent1Id] FOREIGN KEY ([IdCardStudent1Id]) REFERENCES [dbo].[IdCardStudent] ([Id]),
    CONSTRAINT [FK_Students_Room_RoomId] FOREIGN KEY ([RoomId]) REFERENCES [dbo].[Room] ([Id]),
    CONSTRAINT [FK_Students_Specialization_SpecializationId] FOREIGN KEY ([SpecializationId]) REFERENCES [dbo].[Specialization] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Students_AccomodationRequestId]
    ON [dbo].[Students]([AccomodationRequestId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Students_FacultyId]
    ON [dbo].[Students]([FacultyId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Students_IdCardStudent1Id]
    ON [dbo].[Students]([IdCardStudent1Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Students_RoomId]
    ON [dbo].[Students]([RoomId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Students_SpecializationId]
    ON [dbo].[Students]([SpecializationId] ASC);

