CREATE TABLE [dbo].[Tenants]
(
	[ID] INT IDENTITY(1,1) NOT NULL,
	[FirstName] NVARCHAR(20) NOT NULL,
	[LastName] NVARCHAR(25) NOT NULL,
	[PhoneNumber] NVARCHAR(10) NOT NULL,
	[ApartmentName] NVARCHAR(30) NOT NULL,
	[ApartmentNumber] INT NOT NULL,
	[FixDescription] NVARCHAR(500) NOT NULL,
	CONSTRAINT [PK_dbo.Tenants] PRIMARY KEY CLUSTERED ([ID] ASC)
);

INSERT INTO [dbo].[Tenants] (FirstName, LastName, PhoneNumber, ApartmentName, ApartmentNumber, FixDescription) VALUES
	('Sally', 'Fields', '5555555550', 'Westside Park Apts', 123, 'Kitchen sink is clogged'),
	('Frank', 'Stallone', '5555555551', 'Eagle Crest Manor', 222, 'Heater broken'),
	('Cindy', 'Lauper', '5555555552', 'Southside Manor', 95, 'Carpet frayed'),
	('Michael', 'Landon', '5555555553', 'Eastside Apts', 45, 'Toilet is clogged')
GO

