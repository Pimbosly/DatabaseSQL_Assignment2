/* Create the relations */
/* Assistant has 1 Superhero, 1 superhero can have has many assistants */
ALTER TABLE Assistant
ADD SuperheroId int 

ALTER TABLE Assistant
ADD FOREIGN KEY (SuperheroId) REFERENCES Superhero(Id);