DELETE FROM [dbo].[Club];
DBCC CHECKIDENT ('Club', RESEED, 0);
GO
DELETE FROM [dbo].[ClubSet];
DBCC CHECKIDENT ('ClubSet', RESEED, 0);
GO
DELETE FROM [dbo].[Klant];
DBCC CHECKIDENT ('Klant', RESEED, 0);
GO
DELETE FROM [dbo].[Truitje];
DBCC CHECKIDENT ('Truitje', RESEED, 0);
GO
DELETE FROM [dbo].[Bestellingen];
DBCC CHECKIDENT ('Bestellingen', RESEED, 0);
GO
DELETE FROM [dbo].[BestellingTruitje];
GO