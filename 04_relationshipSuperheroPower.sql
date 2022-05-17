/* 1 superhero can have many powers, many powers can be shared among superheroes */
CREATE TABLE Hero_Power(
SuperheroId int,
PowerId int,

PRIMARY KEY (SuperheroId, PowerId),
CONSTRAINT FK_SuperheroPower FOREIGN KEY (SuperheroId) REFERENCES Superhero(Id),
CONSTRAINT FK_PowerSuperhero FOREIGN KEY (PowerId) REFERENCES Power(Id)
);