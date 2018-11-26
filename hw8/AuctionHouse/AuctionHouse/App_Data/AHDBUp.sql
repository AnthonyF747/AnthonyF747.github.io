CREATE TABLE Seller
(
	SellerID             INT             IDENTITY(1,1)    NOT NULL,
	SellerFullName       NVARCHAR(35)                     NOT NULL,
	SellerPhoneNumber    NVARCHAR(12)                     NOT NULL,
	SellerEmailAddress   NVARCHAR(20)                     NOT NULL,
	PRIMARY KEY (SellerID)
);

CREATE TABLE Buyer
(
	BuyerID              INT             IDENTITY(1,1)    NOT NULL,
	BuyerFullName        NVARCHAR(35)                     NOT NULL,
	BuyerPhoneNumber     NVARCHAR(12)                     NOT NULL,
	BuyerEmailAddress    NVARCHAR(20)                     NOT NULL,
	PRIMARY KEY (BuyerID)
);

CREATE TABLE Item
(
	ItemID               INT             IDENTITY(1,1)    NOT NULL,
	ItemName             NVARCHAR(20)                     NOT NULL,
	ItemDescription      NVARCHAR(250)                    NOT NULL,
	PRIMARY KEY (ItemID),
	SellerID INT FOREIGN KEY REFERENCES Seller(SellerID)
);

CREATE TABLE Bid
(
	BidID                INT             IDENTITY(1,1)    NOT NULL,
	BidAmount            DECIMAL                          NOT NULL,
	BidTimeStamp         DATETIME                         NOT NULL,
	PRIMARY KEY (BidID),
	ItemID INT FOREIGN KEY REFERENCES Item (ItemID),
	BuyerID INT FOREIGN KEY REFERENCES Buyer (BuyerID)
);

INSERT INTO Buyer (BuyerFullName, BuyerPhoneNumber, BuyerEmailAddress)
VALUES ('Sara Silverman', '5555555551', 'silvermans@email.com'),
('Tom Arnold', '5555555552', 'arnoldt@email.com'),
('Lindsay Wagner', '5555555553', 'wagnerl@email.com'),
('Lee Majors', '5555555554', 'majorsl@email.com');

INSERT INTO Seller (SellerFullName, SellerPhoneNumber, SellerEmailAddress)
VALUES ('Wesley Snipes', '5555555555', 'snipesw@email.com'),
('Jessica Lange', '5555555556', 'langej@email.com'),
('Reggie Jackson', '5555555557', 'jacksonr@email.com'),
('Angie Dickenson', '5555555558', 'dickensona@email.com');

INSERT INTO Item (ItemName, ItemDescription, SellerID)
VALUES ('Silver Spoon', 'A spoon made of pure silver', 2),
('Gold Earring', 'A earring made of gold', 3),
('Metal Ring', 'A ring made of an unknown metal', 1),
('Golf Clubs', 'Golf clubs that have seen better days', 4);