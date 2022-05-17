/* Create the tables */
CREATE TABLE Superhero(
Id int IDENTITY(1,1) primary key,
Name Nvarchar(32) UNIQUE NOT NULL,
Alias Nvarchar(32),
Origin Nvarchar(100)
);

CREATE TABLE Assistant(
Id int IDENTITY(1,1) primary key,
Name varchar(32) UNIQUE NOT NULL
);

CREATE TABLE Power(
id int IDENTITY(1,1) primary key,
Name varchar(32) UNIQUE NOT NULL,
Description varchar(64)
);

/* We took 32 chars for names, 64 for a power description and 100 for an origin story. 
All of the primary keys are auto incremented with the IDENTITY.
All of the names have been made UNIQUE due to the delete sql script functionality according to the assignment
*/