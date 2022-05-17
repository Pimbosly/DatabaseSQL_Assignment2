/* update 1 superhero name */
UPDATE Superhero
SET Name='Ben Reilly'
WHERE Id='3';

/* check if we updated the superhero name. Spiderman should be named Ben Reilly and not Peter Parker */
SELECT * FROM Superhero;