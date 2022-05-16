/* Create the tables */
CREATE TABLE Superhero(
Id int primary key,
Name Nvarchar(32) NOT NULL,
Alias Nvarchar(32),
Origin Nvarchar
);

CREATE TABLE Assistant(
Id int primary key,
Name varchar(32) NOT NULL
);

CREATE TABLE Power(
id int primary key,
Name varchar(32) NOT NULL,
Description varchar(64)
);
