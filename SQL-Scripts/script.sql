--@block Her kan i skrive SQL scripts til at oprette jeres DB
CREATE TABLE USERS (
    ID INT NOT NULL IDENTITY(1,1),
    USERNAME VARCHAR(255) NOT NULL,
    PASSWORD VARCHAR(255) NOT NULL,
    PRIMARY KEY (ID)
);