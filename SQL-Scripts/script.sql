create table Users(
    id int primary key identity(1,1),
    username VARCHAR(255) not null unique,
    password text not null,
    phoneNumber bigint not null,
    phoneNumberExtention text not null,
    city text not null,
    zipCode int not null,
    aboutMe text,
    createdAt datetime default getdate()
);





create table UserGroups(
    groupName text primary key not null,
    permissions text,
    createdAt datetime default getdate()
);


create table AsignUserToGroup(
    userID int not null,
    groupID text not null,
    primary key (userID, groupID),
    foreign key (userID) references Users(id) on delete cascade,
    foreign key (groupID) references UserGroups(groupName)
);


create table Genre(
    id int primary key identity(1,1),
    genreName text not null,
);

create table Publisher(
    id int primary key identity(1,1),
    publisherName text not null,
);

create table Developer(
    id int primary key identity(1,1),
    developerName text not null,
);

create table GamePlatform(
    id int primary key identity(1,1),
    platformName text not null,
);

create table GameRequirements(
    id int primary key identity(1,1),
    os text not null,
    cpu text not null,
    ram int not null,
    gpu text not null,
    storage int not null,
    directX text not null,
);


create table Game(
    id int primary key identity(1,1),
    name text not null,
    description text not null,
    releaseDate datetime not null,
    numberOfPlayers int not null,
    ageRating decimal(10,2) not null,
    genre int not null,
    publisher int not null,
    developer int not null,
    minRequirementsID int not null,
    maxRequirementsID int not null,
    platform int not null,
    foreign key (genre) references Genre(id),
    foreign key (publisher) references Publisher(id),
    foreign key (developer) references Developer(id),
    foreign key (minRequirementsID) references GameRequirements(id),
    foreign key (maxRequirementsID) references GameRequirements(id),
    foreign key (platform) references GamePlatform(id)
);

create table GameListing(
    listingID int primary key identity(1,1),
    sellerID int not null,
    gameID int not null,
    price decimal(10,2) not null,
    title text not null,
    condition text not null,
    sold bit not null,
    createdAt datetime default getdate(),
    foreign key (sellerID) references Users(id) on delete cascade,
    foreign key (gameID) references Game(id),
);

create table Favorites(
    id int primary key identity(1,1),
    userID int not null,
    itemID int not null,
    FOREIGN KEY (userID) REFERENCES Users(id) ON DELETE CASCADE,
    FOREIGN KEY (itemID) REFERENCES GameListing(listingID)
);

create table Picture(
    id int primary key identity(1,1),
    userID int not null,
    listingsID int not null,
    pictureURL text not null,
    FOREIGN KEY (userID) REFERENCES Users(id) ON DELETE CASCADE,
    FOREIGN KEY (listingsID) REFERENCES GameListing(listingID)
);

create table Review(
    id int primary key identity(1,1),
    userID int not null,
    sellerID int not null,
    title text not null,
    rating text not null,
    description text not null,
    DateMade datetime default getdate(),
    ReviewId text not null,
    FOREIGN KEY (userID) REFERENCES Users(id) ON DELETE CASCADE,
    FOREIGN KEY (sellerID) REFERENCES Users(id) ON DELETE CASCADE
);

--Skyrim V
insert into Genre(genreName) VALUES ("RPG"), ("Action"), ("Adventure"), ("Fantasy"), ("Open World"), ("Singleplayer"), ("First-Person"), ("Third-Person"), ("Dragons"), ("Magic"), ("Moddable"), ("Character Customization"), ("Atmospheric"), ("Story Rich"), ("Exploration"), ("Sandbox"), ("Great Soundtrack"), ("Masterpiece"), ("Multiple Endings"), ("Choices Matter"), ("Action RPG"), ("Medieval"), ("Nudity"), ("Sexual Content"), ("Mature"), ("Violent"), ("Gore"), ("Dark Fantasy"), ("Difficult"), ("Crafting"), ("Lore-Rich"), ("Replay Value"), ("Classic"), ("Third Person Shooter"), ("FPS"), ("Shooter"), ("Co-op"), ("Multiplayer"), ("Online Co-Op"), ("PvP"), ("Competitive"), ("First-Person Shooter"), ("Sci-fi"), ("Post-apocalyptic"), ("Zombies"), ("Survival"), ("Horror"), ("Tactical"), ("Stealth"), ("Realistic"), ("War"), ("Military"), ("Strategy"), ("RTS"), ("Turn-Based"), ("Tanks"), ("Simulation"), ("Building"), ("Management"), ("City Builder"), ("Sandbox"), ("Casual"), ("2D"), ("Puzzle"), ("Platformer"), ("Retro"), ("Pixel Graphics"), ("Indie"), ("Racing"), ("Sports"), ("Arcade"), ("VR"), ("VR Only"), ("Massively Multiplayer"), ("MMORPG"), ("RPG"), ("Open World"), ("Multiplayer"), ("Co-op"), ("Action"), ("Adventure"), ("Fantasy"), ("Third Person"), ("Singleplayer"), ("Story Rich"), ("Atmospheric"), ("Great Soundtrack"), ("Character Customization"), ("Moddable"), ("First-Person"), ("Shooter"), ("Sci-fi"), ("Space"), ("Simulation"), ("Strategy"), ("RTS"), ("Tactical"), ("War"), ("Military"), ("Realistic"), ("Massively Multiplayer"), ("MMO"), ("RPG"), ("Open World"), ("Multiplayer"), ("Co-op"), ("Action"), ("Adventure"), ("Fantasy"), ("Third Person"), ("Singleplayer"), ("Story Rich"), ("Atmospheric"), ("Great Soundtrack"), ("Character Customization"), ("Moddable"), ("First-Person"), ("Shooter"), ("Sci-fi"), ("Space"), ("Simulation"), ("Strategy"), ("RTS"), ("Tactical"), ("War"), ("Military"), ("Realistic"), ("Massively Multiplayer"), ("MMO"), ("RPG"), ("Open World");
insert into Publisher(publisherName) VALUES ("Bethesda Softworks");
insert into Developer(developerName) VALUES ("Bethesda Game Studios");
insert into GamePlatform(platformName) VALUES ("PC"), ("Xbox 360"), ("Xbox One"), ("PlayStation 3"), ("PlayStation 4"), ("Nintendo Switch"), ("PlayStation VR"), ("Oculus Rift"), ("HTC Vive"), ("Windows Mixed Reality");
insert into GameRequirements(os, cpu, ram, gpu, storage, directX) VALUES ("Windows 7/Vista/XP PC (32 or 64 bit Version)", "Dual Core 2.00GHz or equivalent processor", 2, "Direct X 9.0c compliant video card with 512 MB of RAM", 6, "Version 9.0c");
insert into GameRequirements(os, cpu, ram, gpu, storage, directX) VALUES ("Windows 7/Vista/XP PC (32 or 64 bit Version)", "Quad-core Intel or AMD CPU ", 4, "DirectX 9.0c compatible NVIDIA or AMD ATI video card with 1GB of RAM (Nvidia GeForce GTX 260 or higher; ATI Radeon 4890 or higher)", 6, "Version 9.0c");
insert into Game(name, description, releaseDate, numberOfPlayers, ageRating, genre, publisher, developer, minRequirementsID, maxRequirementsID, platform) 
VALUES ("The Elder Scrolls V: Skyrim", "Immerse yourself in the epic world of Skyrim with this brand new, sealed copy. Unopened and ready for adventure, this edition guarantees a pristine gaming experience.", DATETIMEFROMPARTS(2011, 11, 11, 0, 0, 0, 0), 1, 18, 1, 1, 1, 1, 2, 1);

-- Skyrim V Special Edition
insert into GameRequirements(os, cpu, ram, gpu, storage, directX) VALUES ("Windows 7/8.1/10 (64-bit Version)", "Intel i5-750/AMD Phenom II X4-945", 8, "NVIDIA GTX 470 1GB /AMD HD 7870 2GB", 12, "Version 9.0c");
insert into GameRequirements(os, cpu, ram, gpu, storage, directX) VALUES ("Windows 7/8.1/10 (64-bit Version)", "Intel i5-2400/AMD FX-8320", 8, "NVIDIA GTX 780 3GB /AMD R9 290 4GB", 12, "Version 9.0c");
insert into Game(name, description, releaseDate, numberOfPlayers, ageRating, genre, publisher, developer, minRequirementsID, maxRequirementsID, platform) VALUES ("The Elder Scrolls V: Skyrim Special Edition", "Winner of more than 200 Game of the Year Awards, Skyrim Special Edition brings the epic fantasy to life in stunning detail. The Special Edition includes the critically acclaimed game and add-ons with all-new features like remastered art and effects, volumetric god rays, dynamic depth of field, screen-space reflections, and more. Skyrim Special Edition also brings the full power of mods to the PC and Xbox One. New quests, environments, characters, dialogue, armor, weapons and more – with Mods, there are no limits to what you can experience.", DATETIMEFROMPARTS(2016, 10, 28, 0, 0, 0, 0), 1, 18, 1, 1, 1, 3, 4, 1);

-- Skyrim Legendary Edition
insert into Game(name, description, releaseDate, numberOfPlayers, ageRating, genre, publisher, developer, minRequirementsID, maxRequirementsID, platform) VALUES ("The Elder Scrolls V: Skyrim Legendary Edition", "Winner of more than 200 Game of the Year awards, experience the complete Skyrim collection with The Elder Scrolls V: Skyrim Legendary Edition, including the original critically-acclaimed game, official add-ons – Dawnguard, Hearthfire, and Dragonborn – and added features like combat cameras, mounted combat, Legendary difficulty mode for hardcore players, and Legendary skills – enabling you to master every perk and level up your skills infinitely.", DATETIMEFROMPARTS(2013, 6, 4, 0, 0, 0, 0), 1, 18, 1, 1, 1, 3, 4, 1);

-- Skyrim VR
insert into GameRequirements(os, cpu, ram, gpu, storage, directX) VALUES ("Windows 7/8.1/10 (64-bit Version)", "Intel Core i5-6600K/AMD Ryzen 5 1400 or better", 8, "NVIDIA GTX 970 / AMD RX 480 8GB or better", 15, "Version 9.0c");
insert into GameRequirements(os, cpu, ram, gpu, storage, directX) VALUES ("Windows 7/8.1/10 (64-bit Version)", "Intel Core i7-4790/AMD Ryzen 5 1500X or better", 8, "NVIDIA GTX 1070 8GB / AMD RX Vega 56 8GB", 15, "Version 9.0c");
insert into Game(name, description, releaseDate, numberOfPlayers, ageRating, genre, publisher, developer, minRequirementsID, maxRequirementsID, platform) VALUES ("The Elder Scrolls V: Skyrim VR", "A true, full-length open-world game for VR has arrived from award-winning developers, Bethesda Game Studios. Skyrim VR reimagines the complete epic fantasy masterpiece with an unparalleled sense of scale, depth, and immersion. From battling ancient dragons to exploring rugged mountains and more, Skyrim VR brings to life a complete open world for you to experience any way you choose. Skyrim VR includes the critically-acclaimed core game and official add-ons – Dawnguard, Hearthfire, and Dragonborn.", DATETIMEFROMPARTS(2018, 4, 3, 0, 0, 0, 0), 1, 18, 1, 1, 1, 5, 6, 1);


-- The Elder Scrolls V: Skyrim - Collector's Edition



insert into Review(userID, SellerID, title, rating, description, DateMade, ReviewId) 
values
("User(1)", "seller(1)", "Hurtig levering og kvalitetsprodukt", "5 stjerner", "Fantastisk oplevelse! Produktet blev leveret hurtigt og levede op til mine forventninger med hensyn til kvalitet. Jeg er virkelig glad for købet.",DATETIME,"Review(1)");

insert into Review(userID, SellerID, title, rating, description, DateMade, ReviewId) 
values ("User(2)", "seller(2)", "Fremragende emballering og produkt som beskrevet", "5 stjerner", "Fem stjerner til denne sælger! Produktet var nøjagtigt som beskrevet, og emballagen var så omhyggelig, at alt ankom i perfekt stand. Tak!", DateTime, "reviewId");

insert into Review(userID, SellerID, title, rating, description, DateMade, ReviewId)
values ("User(3)", "seller(3)", "Pålidelig sælger og problemfri handel", "5 stjerner", "Jeg kunne ikke være mere tilfreds! Sælgeren var pålidelig, og hele handelsprocessen var let og problemfri. Jeg kan varmt anbefale denne sælger.",DateTime,"review(3)");

insert into Review
    (userID, SellerID, title, rating, description, DateMade, ReviewId)
values
    ("User(4)", "seller(4)", "Pålidelig sælger og problemfri handel", "5 stjerner", "Jeg kunne ikke være mere tilfreds! Sælgeren var pålidelig, og hele handelsprocessen var let og problemfri. Jeg kan varmt anbefale denne sælger.", DateTime, "review(4)");


insert into Review
    (userID, SellerID, title, rating, description, DateMade, ReviewId)
values
    ("User(5)", "seller(5)", "Pålidelig sælger og problemfri handel", "5 stjerner", "Jeg kunne ikke være mere tilfreds! Sælgeren var pålidelig, og hele handelsprocessen var let og problemfri. Jeg kan varmt anbefale denne sælger.", DateTime, "review(5)");
