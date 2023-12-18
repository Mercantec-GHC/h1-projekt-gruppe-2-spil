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
    userGroupID int PRIMARY key identity(1,1),
    groupName text not null,
    permissions text,
    createdAt datetime default getdate()
);


create table AsignUserToGroup(
    userID int not null,
    groupID int not null,
    primary key (userID, groupID),
    foreign key (userID) references Users(id) on delete cascade,
    foreign key (groupID) references UserGroups(userGroupID)
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
    gpu varchar(max) not null,
    storage int not null,
    directX text not null,
);


create table Game(
    id int primary key identity(1,1),
    name text not null,
    description text not null,
    releaseDate datetime not null,
    numberOfPlayers int not null,
    ageRating int not null,
    publisher int not null,
    minRequirementsID int,
    maxRequirementsID int,
    foreign key (publisher) references Publisher(id),
    foreign key (minRequirementsID) references GameRequirements(id),
    foreign key (maxRequirementsID) references GameRequirements(id),
);

create table assignPlatformToGame(
  gameID int not null,
  platformID int not null,
  primary key (gameID, platformID),
  foreign key (gameID) references Game(id) on delete cascade,
  foreign key (platformID) references GamePlatform(id)
);

create table assignGenreToGame(
  gameID int not null,
  genreID int not null,
  primary key (gameID, genreID),
  foreign key (gameID) references Game(id) on delete cascade,
  foreign key (genreID) references Genre(id)
);

create table assignDeveloperToGame(
  gameID int not null,
  developerID int not null,
  primary key (gameID, developerID),
  foreign key (gameID) references Game(id) on delete cascade,
  foreign key (developerID) references Developer(id)
);


create table GameListing(
    listingID int primary key identity(1,1),
    sellerID int not null,
    gameID int not null,
    price decimal(10,2) not null,
    title text not null,
    condition text not null,
    description text,
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
    userID int,
    listingsID int,
    pictureURL text not null,
    FOREIGN KEY (userID) REFERENCES Users(id),
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
    FOREIGN KEY (sellerID) REFERENCES Users(id) ON DELETE CASCADE,
    FOREIGN KEY (userID) REFERENCES Users(id)
    
);


-- instansiate genre, publisher, developer, platform
insert into Genre(genreName) VALUES ('RPG'), ('Action'), ('Adventure'), ('Fantasy'), ('Open World'), ('Singleplayer'), 
('First-Person'), ('Third-Person'), ('Dragons'), ('Magic'), ('Moddable'), 
('Character Customization'), ('Atmospheric'), ('Story Rich'), ('Exploration'), 
('Sandbox'), ('Great Soundtrack'), ('Masterpiece'), ('Multiple Endings'), 
('Choices Matter'), ('Medieval'), ('Nudity'), ('Sexual Content'), 
('Mature'), ('Violent'), ('Gore'), ('Dark Fantasy'), ('Difficult'), ('Crafting'), 
('Lore-Rich'), ('Replay Value'), ('Classic'), ('Third Person Shooter'), ('FPS'), 
('Shooter'), ('Co-op'), ('Multiplayer'), ('Online Co-Op'), ('PvP'), ('Competitive'), 
('First-Person Shooter'), ('Sci-fi'), ('Post-apocalyptic'), ('Zombies'), ('Survival'), 
('Horror'), ('Tactical'), ('Stealth'), ('Realistic'), ('War'), ('Military'), 
('Strategy'), ('RTS'), ('Turn-Based'), ('Tanks'), ('Simulation'), ('Building'), 
('Management'), ('City Builder'), ('Casual'), ('2D'), ('Puzzle'), ('Platformer'), 
('Retro'), ('Pixel Graphics'), ('Indie'), ('Racing'), ('Sports'), ('Arcade'), ('VR'), 
('VR Only'), ('Massively Multiplayer'), ('MMORPG'), 
('Space');
insert into Publisher(publisherName) VALUES ('Bethesda Softworks'), ('Rockstar Ganes'), ('Playstation PC LLC'), ('Bandai Namco Entertainment'), ('Ubisoft'), ('Electronic Arts'), ('Square Enix'), ('Activision'), ('Microsoft Studios'), ('Warner Bros. Interactive Entertainment'), ('2K Games'), ('Sony Interactive Entertainment'), ('Capcom'), ('Sega'), ('Paradox Interactive'), ('Deep Silver'), ('THQ Nordic'), ('Focus Home Interactive'), ('Codemasters'), ('Koei Tecmo Games'), ('505 Games'), ('Kalypso Media Digital'), ('NIS America, Inc.'), ('BANDAI NAMCO Entertainment America Inc.'), ('SEGA'), ('SEGA of America, Inc.'), ('Warner Bros. Interactive Entertainment'), ('Warner Bros. Interactive'), ('Warner Bros. Interactiv'), ('Larian Studios'), ('CD Project Red');
insert into Developer(developerName) VALUES ('Bethesda Game Studios'), ('Rockstar North'), ('Santa Monica Studio'), ('Tarsier Studios'), ('Larian Studios'), ('CD Project Red');
insert into GamePlatform(platformName) VALUES ('PC'), ('Xbox 360'), ('Xbox One'), ('PlayStation 3'), ('PlayStation 4'), ('Nintendo Switch'), ('PlayStation VR'), ('Oculus Rift'), ('HTC Vive'), ('Windows Mixed Reality'), ('PlayStation 5'), ('PlayStation 2'), ('PlayStation 1'), ('Nintendo Wii'), ('Nintendo Wii U'), ('Game Cube');


-- instansiate usersGroups
insert into UserGroups(groupName, permissions) VALUES ('Admin', 'all'), ('User', 'read, write, update, delete'), ('Seller', 'read, write, update, delete'), ('Guest', 'read');

-- instansiate users
INSERT INTO Users (username, password, phoneNumber, phoneNumberExtention, city, zipCode, aboutMe, createdAt)
VALUES
('anders_jensen', 'Velkommen123', 4512345678, '+45', 'Copenhagen', 1000, 'Elsker at udforske kultur og mad.', GETDATE()),
('mette_nielsen', 'Havfrue@123', 4523456789, '+45', 'Aarhus', 8000, 'Kunst og natur er min passion.', GETDATE()),
('lars_pedersen', 'Cykel1234', 4534567890, '+45', 'Odense', 5000, 'Cykling er mit liv!', GETDATE()),
('sanne_andersen', 'Hjemlandet!23', 4545678901, '+45', 'Aalborg', 9000, 'Stolt af mit hjemland.', GETDATE()),
('morten_sorensen', 'Strand123', 4556789012, '+45', 'Esbjerg', 6700, 'Elsker at slappe af på stranden.', GETDATE()),
('lotte_poulsen', 'Haven@1', 4567890123, '+45', 'Randers', 8900, 'Haveentusiast og blomsterelsker.', GETDATE()),
('nikolaj_jacobsen', 'FodboldFan!23', 4578901234, '+45', 'Vejle', 7100, 'Fodbold er min store passion.', GETDATE()),
('signe_christensen', 'Musik123', 4589012345, '+45', 'Horsens', 8700, 'Musik er min sjæl.', GETDATE()),
('henrik_larsen', 'Vandretur123', 4590123456, '+45', 'Silkeborg', 8600, 'Vandreture i naturen er fantastisk.', GETDATE()),
('ida_kristensen', 'Eventyr123', 4511234567, '+45', 'Holstebro', 7500, 'Elsker eventyr og nye oplevelser.', GETDATE()),
('christian_nielsen', 'KaffeElsker', 4512109876, '+45', 'Kolding', 6000, 'Ingen dag uden en god kop kaffe.', GETDATE()),
('camilla_larsen', 'Havet123', 4513210987, '+45', 'Roskilde', 4000, 'Fascineret af havet og dets skønhed.', GETDATE()),
('poul_sorensen', 'Globetrotter', 4514321098, '+45', 'Helsingør', 3000, 'Rejser verden rundt og elsker det.', GETDATE()),
('louise_andersen', 'KunstnerSjæl', 4515432109, '+45', 'Egedal', 2765, 'Udtrykker mig gennem kunst og kreativitet.', GETDATE()),
('martin_bak', 'TechEntusiast', 4516543210, '+45', 'Herning', 7400, 'Passioneret omkring teknologi og innovation.', GETDATE()),
('helene_madsen', 'YogaLivet@23', 4517654321, '+45', 'Fredericia', 7000, 'Balancerer livet med yoga og mindfulness.', GETDATE()),
('simon_petersen', 'MadEventyr', 4518765432, '+45', 'Nyborg', 5800, 'Oplever verden gennem maden.', GETDATE()),
('vibeke_jensen', 'BogOrme123', 4519876543, '+45', 'Svendborg', 5700, 'Fordybet i bøgernes verden.', GETDATE()),
('jens_christiansen', 'KodeNinja!23', 4511987654, '+45', 'Holbæk', 4300, 'Løser udfordringer gennem kodning.', GETDATE()),
('marie_larsen', 'NaturElsker', 4511098765, '+45', 'Vordingborg', 4760, 'Eventyr i den danske natur.', GETDATE()),
('anne_poulsen', 'SolenSkaerner', 4523456790, '+45', 'Aalborg', 9000, 'Elsker solnedgange ved vandet.', GETDATE()),
('kasper_andersen', 'Lystfisker@123', 4534567891, '+45', 'Aarhus', 8000, 'Fiskeri er min store hobby.', GETDATE()),
('sofie_jensen', 'Bogorm123', 4545678902, '+45', 'Odense', 5000, 'Læser alt, jeg kan komme i nærheden af.', GETDATE()),
('thomas_mortensen', 'FilmFan!23', 4556789013, '+45', 'Esbjerg', 6700, 'Ingen film er for mange!', GETDATE()),
('laura_christiansen', 'KunstElsker', 4567890124, '+45', 'Randers', 8900, 'Maleri og skulptur er min passion.', GETDATE()),
('jesper_pedersen', 'NaturenKalder', 4578901235, '+45', 'Vejle', 7100, 'Udflugter og vandreture i naturen.', GETDATE()),
('mia_nielsen', 'Hjemmekok@1', 4589012346, '+45', 'Horsens', 8700, 'Elsker at eksperimentere i køkkenet.', GETDATE()),
('henrik_petersen', 'Gamer123', 4590123457, '+45', 'Silkeborg', 8600, 'Gaming er min guilty pleasure.', GETDATE()),
('maria_sorensen', 'ModeEntusiast', 4511234568, '+45', 'Holstebro', 7500, 'Følger altid de nyeste modetrends.', GETDATE()),
('ole_larsen', 'KaffeKender', 4512109879, '+45', 'Kolding', 6000, 'Barista in the making.', GETDATE()),
('lærke_jacobsen', 'Danseløve@23', 4513210980, '+45', 'Roskilde', 4000, 'Dans er min form for udtryk.', GETDATE()),
('karl_sorensen', 'RejseEventyr', 4514321091, '+45', 'Helsingør', 3000, 'Verden er min legeplads.', GETDATE()),
('emilie_larsen', 'MusikFreak!23', 4515432102, '+45', 'Egedal', 2765, 'Koncertgænger og musikelsker.', GETDATE()),
('anders_poulsen', 'TechWizard', 4516543213, '+45', 'Herning', 7400, 'Alt omkring teknologi fascinerer mig.', GETDATE()),
('sara_madsen', 'YogaMaster@23', 4517654324, '+45', 'Fredericia', 7000, 'Yoga er min daglige rutine.', GETDATE()),
('jonas_andersen', 'MadGourmet', 4518765435, '+45', 'Nyborg', 5800, 'Udforsker gourmetverdenen.', GETDATE()),
('emil_christensen', 'LitteraturFan', 4519876546, '+45', 'Svendborg', 5700, 'Bøger er min bedste ven.', GETDATE()),
('lise_jensen', 'KodeGuru!23', 4511987657, '+45', 'Holbæk', 4300, 'Elsker at løse komplekse problemer med kode.', GETDATE()),
('mads_larsen', 'Vandhund123', 4511098768, '+45', 'Vordingborg', 4760, 'Livet er bedre ved vandet.', GETDATE()),
('stine_petersen', 'Eventyr123', 4522109879, '+45', 'Sønderborg', 6400, 'Altid på udkig efter nye eventyr.', GETDATE()),
('viktor_jensen', 'HavetsMysterium', 4523456790, '+45', 'Aalborg', 9000, 'Fascineret af livet under havets overflade.', GETDATE()),
('nina_poulsen', 'KreativSjæl@123', 4534567891, '+45', 'Aarhus', 8000, 'Skaber kunst og håndværk med sjæl.', GETDATE()),
('simon_larsen', 'Løber1234', 4545678902, '+45', 'Odense', 5000, 'Løber maraton for sjov og sundhed.', GETDATE()),
('emilia_nielsen', 'FilmNørd123', 4556789013, '+45', 'Esbjerg', 6700, 'Sætter pris på god filmkunst.', GETDATE()),
('johan_andersen', 'HistorieElsker', 4567890124, '+45', 'Randers', 8900, 'Fascineret af verdenshistorien.', GETDATE()),
('amalie_jacobsen', 'Naturoplevelser', 4578901235, '+45', 'Vejle', 7100, 'Udforsker Danmarks smukke natur.', GETDATE()),
('frederik_pedersen', 'MadElsker@1', 4589012346, '+45', 'Horsens', 8700, 'Kulinariske eventyr er min passion.', GETDATE()),
('lærke_mortensen', 'GamerGirl!23', 4590123457, '+45', 'Silkeborg', 8600, 'Gaming og streaming på fritiden.', GETDATE()),
('jonathan_sorensen', 'ModeBevidst', 4511234568, '+45', 'Holstebro', 7500, 'Opdateret på de nyeste modetrends.', GETDATE()),
('ida_larsen', 'KaffeConnaisseur', 4512109879, '+45', 'Kolding', 6000, 'Elsker at udforske kaffevarianter.', GETDATE()),
('alexandra_christensen', 'Danseliv123', 4513210980, '+45', 'Roskilde', 4000, 'Passioneret danser og koreograf.', GETDATE()),
('martin_poulsen', 'Globetrotter123', 4514321091, '+45', 'Helsingør', 3000, 'Rejser verden rundt for at opleve forskellige kulturer.', GETDATE()),
('emilie_sorensen', 'KunstneriskSjæl', 4515432102, '+45', 'Egedal', 2765, 'Skaber kunst med sjæl og dybde.', GETDATE()),
('mathias_jensen', 'TechEnthusiast', 4516543213, '+45', 'Herning', 7400, 'Interesseret i den seneste teknologi og innovation.', GETDATE()),
('emma_madsen', 'YogaLife@23', 4517654324, '+45', 'Fredericia', 7000, 'Fokuserer på indre ro og balance gennem yoga.', GETDATE()),
('peter_andersen', 'Madkunstner', 4518765435, '+45', 'Nyborg', 5800, 'Elsker at eksperimentere i køkkenet.', GETDATE()),
('louise_christensen', 'Bibliofil', 4519876546, '+45', 'Svendborg', 5700, 'Elsker at fordybe mig i bøgernes verden.', GETDATE()),
('nicolai_jensen', 'CodeMaster!23', 4511987657, '+45', 'Holbæk', 4300, 'Løser komplekse problemer med kodekunst.', GETDATE()),
('sara_larsen', 'Svømmer123', 4511098768, '+45', 'Vordingborg', 4760, 'Svømning er min motionsform og passion.', GETDATE());



-- instansiate assignUserToGroup
insert into AsignUserToGroup(userID, groupID) VALUES (1, 1), (1, 2), (1, 3), (2, 2), (3, 2), (4, 2), (4, 3), (5, 2), (5, 1), 
(6, 2), (7, 2), (8, 2), (9, 2), (9, 3), (10, 2), (10, 1), (11, 2), (11, 3), (12, 2), (13, 2), (14, 2), (14, 1),
(15, 2), (15, 1), (16, 2), (16, 3), (17, 2), (17, 3), (18, 2), (19, 2), (20, 2), (20, 3), (21, 2), (21, 3), (22, 2), 
(23, 2), (24, 2), (25, 2), (25, 3), (26, 2), (27, 2), (27, 3), (28, 2), (29, 2), (30, 2), (31, 2), (31, 3), (32, 2), (32, 3), 
(33, 2), (34, 2), (35, 2), (35, 3), (36, 2), (37, 2), (37, 3), (38, 2), (38, 3), (39, 2), (40, 2), (41, 2), (41, 3), (42, 2), 
(42, 3), (43, 2), (44, 2), (45, 2), (45, 3), (46, 2), (47, 2), (47, 3), (48, 2), (49, 2), (50, 2), (51, 2), (51, 3), (52, 2), 
(53, 2), (53, 3), (54, 2), (55, 2), (56, 2), (57, 2), (57, 3), (58, 2), (58, 3), (59, 2);




--Skyrim V

insert into GameRequirements(os, cpu, ram, gpu, storage, directX) VALUES ('Windows 7/Vista/XP PC (32 or 64 bit Version)', 'Dual Core 2.00GHz or equivalent processor', 2, 'Direct X 9.0c compliant video card with 512 MB of RAM', 6, 'Version 9.0c');
insert into GameRequirements(os, cpu, ram, gpu, storage, directX) VALUES ('Windows 7/Vista/XP PC (32 or 64 bit Version)', 'Quad-core Intel or AMD CPU ', 4, 'DirectX 9.0c compatible NVIDIA or AMD ATI video card with 1GB of RAM (Nvidia GeForce GTX 260 or higher; ATI Radeon 4890 or higher)', 6, 'Version 9.0c');
insert into Game(name, description, releaseDate, numberOfPlayers, ageRating, publisher, minRequirementsID, maxRequirementsID) 
VALUES ('The Elder Scrolls V: Skyrim - PC', 'Immerse yourself in the epic world of Skyrim with this brand new, sealed copy. Unopened and ready for adventure, this edition guarantees a pristine gaming experience.', DATETIMEFROMPARTS(2011, 11, 11, 0, 0, 0, 0), 1, 18, 1, 1, 2);

-- Skyrim V Special Edition
insert into GameRequirements(os, cpu, ram, gpu, storage, directX) VALUES ('Windows 7/8.1/10 (64-bit Version)', 'Intel i5-750/AMD Phenom II X4-945', 8, 'NVIDIA GTX 470 1GB /AMD HD 7870 2GB', 12, 'Version 9.0c');
insert into GameRequirements(os, cpu, ram, gpu, storage, directX) VALUES ('Windows 7/8.1/10 (64-bit Version)', 'Intel i5-2400/AMD FX-8320', 8, 'NVIDIA GTX 780 3GB /AMD R9 290 4GB', 12, 'Version 9.0c');
insert into Game(name, description, releaseDate, numberOfPlayers, ageRating, publisher, minRequirementsID, maxRequirementsID) VALUES ('The Elder Scrolls V: Skyrim Special Edition - PC', 'Winner of more than 200 Game of the Year Awards, Skyrim Special Edition brings the epic fantasy to life in stunning detail. The Special Edition includes the critically acclaimed game and add-ons with all-new features like remastered art and effects, volumetric god rays, dynamic depth of field, screen-space reflections, and more. Skyrim Special Edition also brings the full power of mods to the PC and Xbox One. New quests, environments, characters, dialogue, armor, weapons and more – with Mods, there are no limits to what you can experience.', DATETIMEFROMPARTS(2016, 10, 28, 0, 0, 0, 0), 1, 18, 1, 3, 4);

-- Skyrim Legendary Edition
insert into Game(name, description, releaseDate, numberOfPlayers, ageRating, publisher, minRequirementsID, maxRequirementsID) VALUES ('The Elder Scrolls V: Skyrim Legendary Edition - PC', 'Winner of more than 200 Game of the Year awards, experience the complete Skyrim collection with The Elder Scrolls V: Skyrim Legendary Edition, including the original critically-acclaimed game, official add-ons – Dawnguard, Hearthfire, and Dragonborn – and added features like combat cameras, mounted combat, Legendary difficulty mode for hardcore players, and Legendary skills – enabling you to master every perk and level up your skills infinitely.', DATETIMEFROMPARTS(2013, 6, 4, 0, 0, 0, 0), 1, 18, 1, 3, 4);

-- Skyrim VR
insert into GameRequirements(os, cpu, ram, gpu, storage, directX) VALUES ('Windows 7/8.1/10 (64-bit Version)', 'Intel Core i5-6600K/AMD Ryzen 5 1400 or better', 8, 'NVIDIA GTX 970 / AMD RX 480 8GB or better', 15, 'Version 9.0c');
insert into GameRequirements(os, cpu, ram, gpu, storage, directX) VALUES ('Windows 7/8.1/10 (64-bit Version)', 'Intel Core i7-4790/AMD Ryzen 5 1500X or better', 8, 'NVIDIA GTX 1070 8GB / AMD RX Vega 56 8GB', 15, 'Version 9.0c');
insert into Game(name, description, releaseDate, numberOfPlayers, ageRating, publisher, minRequirementsID, maxRequirementsID) VALUES ('The Elder Scrolls V: Skyrim VR - PC', 'A true, full-length open-world game for VR has arrived from award-winning developers, Bethesda Game Studios. Skyrim VR reimagines the complete epic fantasy masterpiece with an unparalleled sense of scale, depth, and immersion. From battling ancient dragons to exploring rugged mountains and more, Skyrim VR brings to life a complete open world for you to experience any way you choose. Skyrim VR includes the critically-acclaimed core game and official add-ons – Dawnguard, Hearthfire, and Dragonborn.', DATETIMEFROMPARTS(2017, 11, 17, 0, 0, 0, 0), 1, 18, 1, 5, 6);


-- The Elder Scrolls V: Skyrim - Collector's Edition
insert into Game(name, description, releaseDate, numberOfPlayers, ageRating, publisher, minRequirementsID, maxRequirementsID) VALUES ('The Elder Scrolls V: Skyrim - Collectors Edition - PC', 'The Elder Scrolls V: Skyrim is an open-world action role-playing game developed by Bethesda Game Studios. The games main story revolves around the player characters quest to defeat Alduin the World-Eater, a dragon who is prophesied to destroy the world. The game is set 200 years after the events of Oblivion and takes place in Skyrim, the northernmost province of Tamriel. Over the course of the game, the player completes quests and develops the character by improving skills. The game continues the open-world tradition of its predecessors by allowing the player to travel anywhere in the game world at any time, and to ignore or postpone the main storyline indefinitely.', DATETIMEFROMPARTS(2011, 11, 11, 0, 0, 0, 0), 1, 18, 1, 1, 2);

-- Skyrim: Digital Deluxe Edition with DLC
insert into Game(name, description, releaseDate, numberOfPlayers, ageRating, publisher, minRequirementsID, maxRequirementsID) VALUES ('The Elder Scrolls V: Skyrim - Digital Deluxe Edition with DLC - PC', 'The Elder Scrolls V: Skyrim is an open-world action role-playing game developed by Bethesda Game Studios. The games main story revolves around the player characters quest to defeat Alduin the World-Eater, a dragon who is prophesied to destroy the world. The game is set 200 years after the events of Oblivion and takes place in Skyrim, the northernmost province of Tamriel. Over the course of the game, the player completes quests and develops the character by improving skills. The game continues the open-world tradition of its predecessors by allowing the player to travel anywhere in the game world at any time, and to ignore or postpone the main storyline indefinitely.', DATETIMEFROMPARTS(2011, 11, 11, 0, 0, 0, 0), 1, 18, 1, 1, 2);


-- Skyrim - Steelbook Edition
insert into Game(name, description, releaseDate, numberOfPlayers, ageRating, publisher, minRequirementsID, maxRequirementsID) VALUES ('The Elder Scrolls V: Skyrim - Steelbook Edition - PC', 'The Elder Scrolls V: Skyrim is an open-world action role-playing game developed by Bethesda Game Studios. The games main story revolves around the player characters quest to defeat Alduin the World-Eater, a dragon who is prophesied to destroy the world. The game is set 200 years after the events of Oblivion and takes place in Skyrim, the northernmost province of Tamriel. Over the course of the game, the player completes quests and develops the character by improving skills. The game continues the open-world tradition of its predecessors by allowing the player to travel anywhere in the game world at any time, and to ignore or postpone the main storyline indefinitely.', DATETIMEFROMPARTS(2011, 11, 11, 0, 0, 0, 0), 1, 18, 1, 1, 2);


-- Skyrim: Special Edition - Collector's Box Set
insert into Game(name, description, releaseDate, numberOfPlayers, ageRating, publisher, minRequirementsID, maxRequirementsID) VALUES ('The Elder Scrolls V: Skyrim - Special Edition - Collectors Box Set - PC', 'The Elder Scrolls V: Skyrim is an open-world action role-playing game developed by Bethesda Game Studios. The games main story revolves around the player characters quest to defeat Alduin the World-Eater, a dragon who is prophesied to destroy the world. The game is set 200 years after the events of Oblivion and takes place in Skyrim, the northernmost province of Tamriel. Over the course of the game, the player completes quests and develops the character by improving skills. The game continues the open-world tradition of its predecessors by allowing the player to travel anywhere in the game world at any time, and to ignore or postpone the main storyline indefinitely.', DATETIMEFROMPARTS(2016, 10, 28, 0, 0, 0, 0), 1, 18, 1, 3, 4);


-- GTA V
insert into GameRequirements(os, cpu, ram, gpu, storage, directX) VALUES ('Windows 8.1 64 Bit, Windows 8 64 Bit, Windows 7 64 Bit Service Pack 1', 'Intel Core 2 Quad CPU Q6600 @ 2.40GHz (4 CPUs) / AMD Phenom 9850 Quad-Core Processor (4 CPUs) @ 2.5GHz', 4, 'NVIDIA 9800 GT 1GB / AMD HD 4870 1GB (DX 10, 10.1, 11)', 72, 'Version 10');
insert into GameRequirements(os, cpu, ram, gpu, storage, directX) VALUES ('Windows 8.1 64 Bit, Windows 8 64 Bit, Windows 7 64 Bit Service Pack 1', 'Intel Core i5 3470 @ 3.2GHz (4 CPUs) / AMD X8 FX-8350 @ 4GHz (8 CPUs)', 8, 'NVIDIA GTX 660 2GB / AMD HD 7870 2GB', 72, 'Version 10');
insert into Game(name, description, releaseDate, numberOfPlayers, ageRating, publisher, minRequirementsID, maxRequirementsID) VALUES ('Grand Theft Auto V PC', 'Grand Theft Auto V for PC offers players the option to explore the award-winning world of Los Santos and Blaine County in resolutions of up to 4k and beyond, as well as the chance to experience the game running at 60 frames per second.', DATETIMEFROMPARTS(2015, 4, 14, 0, 0, 0, 0), 1, 18, 2, 7, 8);

-- GTA V Premium Edition
insert into Game(name, description, releaseDate, numberOfPlayers, ageRating, publisher, minRequirementsID, maxRequirementsID) VALUES ('Grand Theft Auto V: Premium Edition', 'Grand Theft Auto V for PC offers players the option to explore the award-winning world of Los Santos and Blaine County in resolutions of up to 4k and beyond, as well as the chance to experience the game running at 60 frames per second.', DATETIMEFROMPARTS(2017, 4, 14, 0, 0, 0, 0), 1, 18, 2, 7, 8);

-- God of War (2018)
insert into GameRequirements(os, cpu, ram, gpu, storage, directX) VALUES ('Windows 7/8.1/10 (64-bit versions)', 'Intel Core i5-2400/AMD FX-8320 or better', 8, 'NVIDIA GTX 660 2GB/AMD Radeon HD 7970 3GB or better', 72, 'Version 10');
insert into GameRequirements(os, cpu, ram, gpu, storage, directX) VALUES ('Windows 7/8.1/10 (64-bit versions)', 'Intel Core i7-4770/AMD Ryzen 5 1600X or better', 8, 'NVIDIA GTX 1060 6GB/AMD Radeon RX 480 8GB or better', 72, 'Version 10');
insert into Game(name, description, releaseDate, numberOfPlayers, ageRating, publisher, minRequirementsID, maxRequirementsID) values ('God of War', 'God of War for PC was teased for months, from about halfway through 2021 until the developers finally put players out of their misery and confirmed the PC release in January 2022! It is the PC-friendly version of the 2018 Gods of War, which was initially only available on PlayStation. The game allows PC gamers to enjoy the intense Norse God action-adventure game.

The game is the eighth in the whole cross-platform series and takes place against a background that while not really being open world and more a series of linked locations, is still wide and explorable within those locations. You seldom feel constrained despite the linear game progression.', DATETIMEFROMPARTS(2018, 4, 20, 0, 0, 0, 0), 1, 18, 2, 9, 10);


-- Little Nightmares I
insert into GameRequirements(os, cpu, ram, gpu, storage, directX) VALUES ('Windows 7, 64-bit', 'Intel CPU Core i3', 4, 'Nvidia GTX 460', 10, 'Version 11');
insert into GameRequirements(os, cpu, ram, gpu, storage, directX) VALUES ('Windows 7, 64-bit', 'Intel CPU Core i7', 8, 'Nvidia GPU GeForce GTX 660', 10, 'Version 11');
insert into Game(name, description, releaseDate, numberOfPlayers, ageRating, publisher, minRequirementsID, maxRequirementsID) values ('Little Nightmares', 'Immerse yourself in Little Nightmares, a dark whimsical tale that will confront you with your childhood fears! Help Six escape The Maw – a vast, mysterious vessel inhabited by corrupted souls looking for their next meal. As you progress on your journey, explore the most disturbing dollhouse offering a prison to escape from and a playground full of secrets to discover. Reconnect with your inner child to unleash your imagination and find the way out!', DATETIMEFROMPARTS(2017, 4, 28, 0, 0, 0, 0), 1, 16, 3, 11, 12);

-- Baldurs Gate 3
insert into GameRequirements(os, cpu, ram, gpu, storage, directX) VALUES ('Windows 7 SP1 64-bit', 'Intel i5-4690 / AMD FX 4350', 8, 'Nvidia GTX 780 / AMD Radeon R9 280X', 150, 'Version 11');
insert into GameRequirements(os, cpu, ram, gpu, storage, directX) VALUES ('Windows 10 64-bit', 'Intel i7 4770k / AMD Ryzen 5 1500X', 16, 'Nvidia GTX 1060 6GB / AMD RX580', 150, 'Version 11');
insert into Game(name, description, releaseDate, numberOfPlayers, ageRating, publisher, minRequirementsID, maxRequirementsID) values ('Baldurs Gate 3', 'Gather your party, and return to the Forgotten Realms in a tale of fellowship and betrayal, sacrifice and survival, and the lure of absolute power.', DATETIMEFROMPARTS(2023, 8, 3, 0, 0, 0, 0), 1, 18, 30, 13, 14);


-- Cyberpunk 2077 standard edition
insert into GameRequirements(os, cpu, ram, gpu, storage, directX) VALUES ('Windows 7 or 10 64-bit', 'Intel Core i5-3570K or AMD FX-8310', 8, 'NVIDIA GeForce GTX 780 or AMD Radeon RX 470', 70, 'Version 12');
insert into GameRequirements(os, cpu, ram, gpu, storage, directX) VALUES ('Windows 10 64-bit', 'Intel Core i7-4790 or AMD Ryzen 3 3200G', 12, 'NVIDIA GeForce GTX 1060 or AMD Radeon R9 Fury', 70, 'Version 12');
insert into Game(name, description, releaseDate, numberOfPlayers, ageRating, publisher, minRequirementsID, maxRequirementsID) values ('Cyberpunk 2077', 'Cyberpunk 2077 is an open-world, action-adventure story set in Night City, a megalopolis obsessed with power, glamour and body modification. You play as V, a mercenary outlaw going after a one-of-a-kind implant that is the key to immortality. You can customize your character’s cyberware, skillset and playstyle, and explore a vast city where the choices you make shape the story and the world around you.', DATETIMEFROMPARTS(2020, 12, 10, 0, 0, 0, 0), 1, 18, 31, 15, 16);

-- assign games to genres
-- assign skyrim v to genres
insert into assignGenreToGame(gameID, genreID) values (1,1), (1,2), (1,3), (1,4), (1,5), (1, 6), (1, 7), (1, 9), (1, 10), (1, 11), (1, 12), (2,1), (2,2), (2,3), (2,4), (2,5), (2, 6), (2, 7), (2, 9), (2, 10), (2, 11), (2, 12), (3,1), (3,2), (3,3), (3,4), (3,5), (3, 6), (3, 7), (3, 9), (3, 10), (3, 11), (3, 12), (4,1), (4,2), (4,3), (4,4), (4,5), (4, 6), (4, 7), (4, 9), (4, 10), (4, 11), (4, 12), (5,1), (5,2), (5,3), (5,4), (5,5), (5, 6), (5, 7), (5, 9), (5, 10), (5, 11), (5, 12), (6,1), (6,2), (6,3), (6,4), (6,5), (6, 6), (6, 7), (6, 9), (6, 10), (6, 11), (6, 12), (7,1), (7,2), (7,3), (7,4), (7,5), (7, 6), (7, 7), (7, 9), (7, 10), (7, 11), (7, 12), (8,1), (8,2), (8,3), (8,4), (8,5), (8, 6), (8, 7), (8, 9), (8, 10), (8, 11), (8, 12)
-- assign gta v to genres
insert into assignGenreToGame(gameID, genreID) values (9, 2), (9, 10), (9, 12), (9, 22);
insert into assignGenreToGame(gameID, genreID) values (10, 2), (10, 10), (10, 12), (10, 22);

-- assign God of War to genres
insert into assignGenreToGame(gameID, genreID) values (11, 10), (11, 12), (11, 24), (11, 28);

-- assign Little Nightmares to genres
insert into assignGenreToGame(gameID, genreID) values (12, 4), (12, 10), (12, 11), (12, 21), (12, 24);

-- assign Baldurs Gate 3 to genres
insert into assignGenreToGame(gameID, genreID) values (13, 1), (13, 8), (13, 16), (13, 22);

-- assign Cyberpunk 2077 to genres
insert into assignGenreToGame(gameID, genreID) values (14, 1), (14, 8), (14, 16), (14, 22), (14, 24), (14, 32);


-- assign games to developers
-- assign skyrim v to developers
insert into assignDeveloperToGame(gameID, developerID) values (1,1), (2,1), (3,1), (4,1), (5,1), (6,1), (7,1), (8,1)

-- assign gta v to developers
insert into assignDeveloperToGame(gameID, developerID) values (9, 2);

--asign gta v premium edition to developers
insert into assignDeveloperToGame(gameID, developerID) values (10, 2);

-- assign God of War to developers
insert into assignDeveloperToGame(gameID, developerID) values (11, 3);

-- assign Little Nightmares to developers
insert into assignDeveloperToGame(gameID, developerID) values (12, 4);

-- assign Baldurs Gate 3 to developers
insert into assignDeveloperToGame(gameID, developerID) values (13, 5);

-- assign Cyberpunk 2077 to developers
insert into assignDeveloperToGame(gameID, developerID) values (14, 6);



-- Reviews
insert into Review(userID, SellerID, title, rating, description, DateMade) 
values
(1, 1, 'Hurtig levering og kvalitetsprodukt', '5 stjerner', 'Fantastisk oplevelse! Produktet blev leveret hurtigt og levede op til mine forventninger med hensyn til kvalitet. Jeg er virkelig glad for købet.',GETDATE());

insert into Review(userID, SellerID, title, rating, description, DateMade) 
values (2, 2, 'Fremragende emballering og produkt som beskrevet', '5 stjerner', 'Fem stjerner til denne sælger! Produktet var nøjagtigt som beskrevet, og emballagen var så omhyggelig, at alt ankom i perfekt stand. Tak!', GETDATE());

insert into Review(userID, SellerID, title, rating, description, DateMade)
values (3, 3, 'Pålidelig sælger og problemfri handel', '5 stjerner', 'Jeg kunne ikke være mere tilfreds! Sælgeren var pålidelig, og hele handelsprocessen var let og problemfri. Jeg kan varmt anbefale denne sælger.',GETDATE());

insert into Review
    (userID, SellerID, title, rating, description, DateMade)
values
    (4, 4, 'Pålidelig sælger og problemfri handel', '5 stjerner', 'Jeg kunne ikke være mere tilfreds! Sælgeren var pålidelig, og hele handelsprocessen var let og problemfri. Jeg kan varmt anbefale denne sælger.', GETDATE());


insert into Review
    (userID, SellerID, title, rating, description, DateMade)
values
    (5, 5, 'Pålidelig sælger og problemfri handel', '5 stjerner', 'Jeg kunne ikke være mere tilfreds! Sælgeren var pålidelig, og hele handelsprocessen var let og problemfri. Jeg kan varmt anbefale denne sælger.', GETDATE());
