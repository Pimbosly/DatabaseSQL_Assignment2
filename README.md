# DatabaseSQL_Assignment2

This assignment consists of two parts. The first part consists of SQL scripts that can be used to create a Superheroes database, with Superhero, Assistant and Power tables. The second part is a C# console app that manipulates SQL Server data, using the SQL CLient library in Visual Studio. For this part an existing database called Chinook is used, which has fictional data of customers of a digital music store.

## Background

This assignment was done for the backend course of Noroff School of Technology and Digital Media. The course is part of the software development traineeship at Experis (Manpower Group). The goal of this assignment is to gain skills in SQL and SQL Client.

## Install

The SQL scripts of part 1 can be run in Microsoft SQL Server Management Studio. The console application of part 2 can be run in Visual Studio 2022.

## Usage

Part 1 contains the following scripts:
1. 01_dbCreate.sql: creates the database.
2. 02_tableCreate.sql: creates the tables.
3. 03_relationshipSuperheroAssistant.sql: configures superhero - assistant relationship.
4. 04_relationshipSuperheroPower.sql: configures superhero - power relationship.
5. 05_insertSuperheroes.sql: inserts three new superheroes into the database.
6. 06_insertAssistants.sql: inserts three assistants. The relationship between superheroes and assistants is one-to-many (a superhero can have multiple assistants).
7. 07_insertPowers.sql: insert four powers. The relationship between superheroes and powers is many-to-many.
8. 08_updateSuperhero.sql: updates a superhero.
9. 09_deleteAssistant.sql: deletes an assistant.

Part 2 contains the following functionality:
1. Get all customers.
2. Get a customer by id.
3. Get a customer by (part of) lastname.
4. Get a page of customers, using limit and offset parameters.
5. Add a customer to the database.
6. Update an existing customer in the database.
7. Get a list of the countries were customers live, in descending order by frequency.
8. Get a list of highest spending customers, in descending order by amount spent.
9. Get the most popular music genre of a given customer, based on the amount of corresponding tracks in the invoices.
All functions can be tested automatically by running the Program.cs file.

## Authors
Pim Westervoort
Dorine van Belzen

## License

MIT

Copyright (c) 2022 Pim Westervoort & Dorine van Belzen

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
