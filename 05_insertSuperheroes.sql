/* Add 3 superheroes to the database */
INSERT INTO Superhero (Name, Alias, Origin)
VALUES ('Clark Kent', 'Superman', 'From another planet');

INSERT INTO Superhero (Name, Alias, Origin)
VALUES ('Bruce Wayne', 'Batman', 'Rich family, was scared of bats');

INSERT INTO Superhero (Name, Alias, Origin)
VALUES ('Peter Parker', 'Spiderman', 'Got bitten by a spider');

/* check if we added the heroes */
SELECT * FROM Superhero;