--Tenants Table
CREATE TABLE [dbo].[Tenants]
(
	[ID]               INT IDENTITY(1, 1)          NOT NULL,
	[FirstName]        NVARCHAR(20)                NOT NULL,
	[LastName]         NVARCHAR(25)                NOT NULL,
	[PhoneNumber]      NVARCHAR(10)                NOT NULL,
	[ApartmentName]    NVARCHAR(30)                NOT NULL,
	[ApartmentNumber]  INT                         NOT NULL,
	[Description]      NVARCHAR(500)               NOT NULL,
	[IsHome]           BIT              NOT NULL DEFAULT (0)
	CONSTRAINT [PK_dbo.Tenants] PRIMARY KEY CLUSTERED ([ID] ASC)
	);


INSERT INTO [dbo].[Tenants]
(
    [FirstName],
    [LastName],
    [PhoneNumber],
    [ApartmentName],
    [ApartmentNumber],
    [Description],
    [IsHome]
)
VALUES
(   N'Tom', -- FirstName - nvarchar(20)
    N'Arnold', -- LastName - nvarchar(25)
    N'5555555550', -- PhoneNumber - nvarchar(10)
    N'Summit View', -- ApartmentName - nvarchar(30)
    110,   -- ApartmentNumber - int
    N'Sink is clogged', -- Description - nvarchar(500)
    1 -- IsHome - bit
    ),
(	'Sally', 'Fields', '5555555551', 'Westside Apts', '222', 'Kitchen tile is broken', '0'),
(	'Clint', 'Eastwood', '5555555552', 'Eastside Apts', '23', 'Toilet is leaking', '1'),
(	'Julia', 'Roberts', '5555555553', 'Southside Apts', '87', 'Shower is working', '0')

GO