/* All information from the habitat table. */

SELECT * 
FROM tbl_habitat

/* Retrieve all names from the species_name column that have a species_order value of 3. */

SELECT species_name 
FROM tbl_species
	WHERE species_order = 3

/*  Retrieve only the nutrition_type from the nutrition table that have a nutrition_cost of 600.00 or less. */

SELECT nutrition_type FROM tbl_nutrition
	WHERE nutrition_cost <= 600

/* Retrieve all species_names with the nutrition_id between 2202 and 2206 from the nutrition table. */

SELECT species_name 
FROM tbl_species
	INNER JOIN tbl_nutrition ON tbl_species.species_nutrition = tbl_nutrition.nutrition_id
	WHERE nutrition_id
	BETWEEN 2202 AND 2206

/* Retrieve all names within the species_name column using the alias "Species Name:" 
from the species table and their corresponding nutrition_type under the alias "Nutrition Type:" from the nutrition table. */

SELECT 
	species_name AS 'Species Name:', 
	nutrition_type AS 'Nutrition Type:'
FROM tbl_species
	INNER JOIN tbl_nutrition ON tbl_species.species_nutrition = tbl_nutrition.nutrition_id

/* From the specialist table, retrieve the first and last name and contact number of those 
that provide care for the penguins from the species table. */

SELECT
	specialist_fname,
	specialist_lname,
	specialist_contact
FROM tbl_species
	INNER JOIN tbl_care ON tbl_care.care_id = tbl_species.species_care
	INNER JOIN tbl_specialist ON tbl_care.care_specialist = tbl_specialist.specialist_id
WHERE
	tbl_species.species_name = 'penguin'

/* Create a database with two tables. 
 Assign a foreign key constraint on one table that shares related data with the primary key on the second table.
 Finally, create a statement that queries data from both tables. */

 CREATE TABLE staff (
	staff_id INT PRIMARY KEY,
	staff_fname VARCHAR(30) NOT NULL,
	staff_lname VARCHAR(30)
	);

	INSERT INTO staff (staff_id, staff_fname, staff_lname)
	VALUES
		(1,'Tyler','Gray'),
		(2, 'John','Smith'),
		(3, 'Trey','Walker'),
		(4, 'Jim','Thorpe');


CREATE TABLE contact (
    contact_phone VARCHAR(50) PRIMARY KEY NOT NULL,
    contact_email VARCHAR(50) NOT NULL,
	fkstaff_id INT FOREIGN KEY REFERENCES staff(staff_id) NOT NULL
);

	INSERT INTO contact (contact_phone, contact_email, fkstaff_id)
	VALUES
		('345-234-1123', 'you@mail.com', 1),
		('456-897-4893', 'me@mail.com', 2),
		('345-765-3490', 'him@mail.com', 3),
		('120-248-6129', 'her@mail.com', 4);


SELECT 
	staff_fname AS 'First Name:', 
	staff_lname AS 'Last Name:',
	contact_phone AS 'Phone Number:'

FROM staff
	INNER JOIN contact ON staff.staff_id = contact.fkstaff_id






		DROP TABLE staff;
		DROP TABLE contact;


		SELECT * FROM staff
		SELECT * FROM contact