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







