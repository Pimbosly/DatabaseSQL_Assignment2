/* Create the tables */
CREATE TABLE Superhero(
Id int IDENTITY(1,1) primary key,
Name Nvarchar(32) NOT NULL,
Alias Nvarchar(32),
Origin Nvarchar(100)
);

CREATE TABLE Assistant(
Id int IDENTITY(1,1) primary key,
Name varchar(32) NOT NULL
);

CREATE TABLE Power(
id int IDENTITY(1,1) primary key,
Name varchar(32) NOT NULL,
Description varchar(64)
);
