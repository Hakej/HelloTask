CREATE DATABASE HelloTask

USE HelloTask

CREATE TABLE Users (
	Id uniqueidentifier primary key not null,
	Email nvarchar(100) not null,
    Password nvarchar(200) not null,
    Salt nvarchar(200) not null,
    Username nvarchar(100) not null,
    Role nvarchar(10),
	CreatedAt datetime not null,
    UpdatedAt datetime not null
)

SELECT * FROM Users;

DELETE FROM Users;

DROP TABLE Users;