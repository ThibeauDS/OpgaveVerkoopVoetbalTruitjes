CREATE TABLE [dbo].[Club] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Competitie] NVARCHAR (50)  NOT NULL,
    [Ploeg]      NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO
CREATE TABLE [dbo].[ClubSet] (
    [Id]     INT IDENTITY (1, 1) NOT NULL,
    [Versie] INT NOT NULL,
    [Thuis]  BIT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO
CREATE TABLE [dbo].[Klant] (
    [Id]    INT            IDENTITY (1, 1) NOT NULL,
    [Naam]  NVARCHAR (250) NOT NULL,
    [Adres] NVARCHAR (250) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO
CREATE TABLE [dbo].[Truitje] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Maat]       NVARCHAR (10)  NOT NULL,
    [Seizoen]    NVARCHAR (20)  NOT NULL,
    [Prijs]      FLOAT (53)     NOT NULL,
    [Versie]     INT            NOT NULL,
    [Thuis]      BIT            NOT NULL,
    [Competitie] NVARCHAR (50)  NOT NULL,
    [Ploeg]      NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO
CREATE TABLE [dbo].[Bestellingen] (
    [Id]           INT        IDENTITY (1, 1) NOT NULL,
    [Datum]        DATETIME   NOT NULL,
    [Verkoopprijs] FLOAT (53) NOT NULL,
    [Betaald]      BIT        NOT NULL,
    [KlantID]      INT        NOT NULL,
    [TruitjeID]    INT        NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Klant_Bestelling] FOREIGN KEY ([KlantID]) REFERENCES [dbo].[Klant] ([Id]),
	CONSTRAINT [FK_Truitje_Bestelling] FOREIGN KEY ([TruitjeID]) REFERENCES [dbo].[Truitje] ([Id])
);
GO
CREATE TABLE [dbo].[BestellingTruitje] (
    [BestellingID] INT NOT NULL,
    [TruitjeID]    INT NOT NULL,
    [Aantal]       INT NOT NULL,
	CONSTRAINT [FK_Bestelling_BestellingTruitje] FOREIGN KEY ([BestellingID]) REFERENCES [dbo].[Bestellingen] ([Id]),
	CONSTRAINT [FK_Truitje_BestellingTruitje] FOREIGN KEY ([TruitjeID]) REFERENCES [dbo].[Truitje] ([Id])
);
GO