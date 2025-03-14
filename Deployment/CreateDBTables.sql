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
CREATE TABLE [Breeds] (
    [Id] nvarchar(450) NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [Temperament] nvarchar(max) NOT NULL,
    [Origin] nvarchar(max) NOT NULL,
    [Country_codes] nvarchar(max) NOT NULL,
    [Country_code] nvarchar(max) NOT NULL,
    [Life_span] nvarchar(max) NOT NULL,
    [Wikipedia_url] nvarchar(max) NOT NULL,
    [Vetstreet_url] nvarchar(max) NOT NULL,
    [Vcahospitals_url] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [Alt_names] nvarchar(max) NOT NULL,
    [Indoor] int NULL,
    [Adaptability] int NULL,
    [Affection_level] int NULL,
    [Child_friendly] int NULL,
    [Dog_friendly] int NULL,
    [Energy_level] int NULL,
    [Grooming] int NULL,
    [Health_issues] int NULL,
    [Intelligence] int NULL,
    [Shedding_level] int NULL,
    [Social_needs] int NULL,
    [Stranger_friendly] int NULL,
    [Experimental] int NULL,
    [Hairless] int NULL,
    [Natural] int NULL,
    [Rare] int NULL,
    [Rex] int NULL,
    [Suppressed_tail] int NULL,
    [Short_legs] int NULL,
    [Hypoallergenic] int NULL,
    [Reference_image_id] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Breeds] PRIMARY KEY ([Id])
);

CREATE TABLE [Cats] (
    [Id] int NOT NULL IDENTITY,
    [CatId] nvarchar(max) NOT NULL,
    [Width] int NULL,
    [Height] int NULL,
    [Created] datetime2 NOT NULL DEFAULT (getdate()),
    CONSTRAINT [PK_Cats] PRIMARY KEY ([Id])
);

CREATE TABLE [Tags] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Created] datetime2 NOT NULL DEFAULT (getdate()),
    CONSTRAINT [PK_Tags] PRIMARY KEY ([Id])
);

CREATE TABLE [Weight] (
    [Id] int NOT NULL IDENTITY,
    [Imperial] nvarchar(max) NOT NULL,
    [Metric] nvarchar(max) NOT NULL,
    [BreedId] nvarchar(450) NULL,
    CONSTRAINT [PK_Weight] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Weight_Breeds_BreedId] FOREIGN KEY ([BreedId]) REFERENCES [Breeds] ([Id])
);

CREATE TABLE [Images] (
    [Id] nvarchar(450) NOT NULL,
    [Url] nvarchar(max) NOT NULL,
    [Width] int NULL,
    [Height] int NULL,
    [CatId] int NOT NULL,
    CONSTRAINT [PK_Images] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Images_Cats_CatId] FOREIGN KEY ([CatId]) REFERENCES [Cats] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [CatTag] (
    [CatsId] int NOT NULL,
    [TagsId] int NOT NULL,
    CONSTRAINT [PK_CatTag] PRIMARY KEY ([CatsId], [TagsId]),
    CONSTRAINT [FK_CatTag_Cats_CatsId] FOREIGN KEY ([CatsId]) REFERENCES [Cats] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_CatTag_Tags_TagsId] FOREIGN KEY ([TagsId]) REFERENCES [Tags] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [BreedImage] (
    [BreedsId] nvarchar(450) NOT NULL,
    [ImagesId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_BreedImage] PRIMARY KEY ([BreedsId], [ImagesId]),
    CONSTRAINT [FK_BreedImage_Breeds_BreedsId] FOREIGN KEY ([BreedsId]) REFERENCES [Breeds] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_BreedImage_Images_ImagesId] FOREIGN KEY ([ImagesId]) REFERENCES [Images] ([Id]) ON DELETE CASCADE
);

CREATE INDEX [IX_BreedImage_ImagesId] ON [BreedImage] ([ImagesId]);

CREATE INDEX [IX_CatTag_TagsId] ON [CatTag] ([TagsId]);

CREATE UNIQUE INDEX [IX_Images_CatId] ON [Images] ([CatId]);

CREATE UNIQUE INDEX [IX_Weight_BreedId] ON [Weight] ([BreedId]) WHERE [BreedId] IS NOT NULL;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250127092558_InitialCreate', N'9.0.1');

COMMIT;
GO