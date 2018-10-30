CREATE TABLE [dbo].[Tenants]
(
	[ID]                  INT IDENTITY(1,1)        NOT NULL,
	[FirstName]           NVARCHAR(20)             NOT NULL,
	[LastName]            NVARCHAR(25)             NOT NULL,
	[PhoneNumber]         NVARCHAR(10)             NOT NULL,
	[ApartmentName]       NVARCHAR(30)             NOT NULL,
	[ApartmentNumber]     INT                      NOT NULL,
	[FixDescription]      NVARCHAR(500)            NOT NULL,
	[IsHome]              BIT                     DEFAULT(0)
	CONSTRAINT [PK_dbo.Tenants] PRIMARY KEY CLUSTERED ([ID] ASC)
); 

INSERT INTO [dbo].[Tenants] (FirstName,LastName,PhoneNumber,ApartmentName,ApartmentNumber,FixDescription,IsHome) VALUES
	('Sally', 'Fields', '5555555550', 'Westside Park Apts', 123, 'Kitchen sink is clogged', 'True'),
	('Walter', 'Matheau', '5555555551', 'River Lane Apts', 75, 'Carpet is frayed', 'False'),
	('Cindy', 'Lauper', '5555555552', 'Eastside Manor', 222, 'Toilet is leaking', 'False'),
	('Lee', 'Majors', '5555555553', 'Park Place Estates', 87, 'Window in bedroom 2 cracked', 'True')
GO