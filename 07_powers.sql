/* add 4 powers */
INSERT INTO Power (Name, Description)
VALUES ('Super strength', 'Being super strong');

INSERT INTO Power (Name, Description)
VALUES ('Laser eyes', 'Can shoot a laser out of their eyes');

INSERT INTO Power (Name, Description)
VALUES ('Spiderwebs', 'Can shoot strings of spiderwebs out of their hands');

INSERT INTO Power (Name, Description)
VALUES ('Money', 'Screw the rules, Ive got money');

/* Check if we added the powers */
SELECT * FROM Power;

/* link powers to superheroes. 1 superhero with many powers, 1 power with many superheroes*/
INSERT INTO Hero_Power (SuperheroId, PowerId)
VALUES ('1', '1');

INSERT INTO Hero_Power (SuperheroId, PowerId)
VALUES ('1', '2');

INSERT INTO Hero_Power (SuperheroId, PowerId)
VALUES ('2', '4');

INSERT INTO Hero_Power (SuperheroId, PowerId)
VALUES ('3', '1');

INSERT INTO Hero_Power (SuperheroId, PowerId)
VALUES ('3', '3');

/* check if we added the powers to the heroes. hero 1 and 3 have 2 powers and power 1 is shared among 2 heroes.*/
SELECT * FROM Hero_Power;