/* Add 3 assistants to the database and link them to a hero*/
INSERT INTO Assistant (Name, SuperheroId)
VALUES ('Lois Lane', '1');

INSERT INTO Assistant (Name, SuperheroId)
VALUES ('Robin', '2');

INSERT INTO Assistant (Name, SuperheroId)
VALUES ('Batwoman', '2');

/* check if we added the assistants */
SELECT * FROM Assistant;