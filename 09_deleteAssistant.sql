/* Remove an assistant by their name. Their name has to be unique */
DELETE FROM Assistant WHERE Name='Batwoman';

/* check to see if Batwoman is gone */
SELECT * FROM Assistant;