create table roles(
	id 				INT NOT NULL AUTO_INCREMENT,
	role 			VARCHAR(100) NOT NULL,
	pilotQualified 	BOOLEAN NOT NULL,
	PRIMARY KEY ( id )
);

create table crew(
	id 		INT NOT NULL AUTO_INCREMENT,
	fname 	VARCHAR(20),
	lname 	VARCHAR(20),
	age		int,
	roleid int,
	PRIMARY KEY ( id ),
	FOREIGN KEY (roleid)
		REFERENCES roles(id)
		ON UPDATE CASCADE
		ON DELETE SET NULL

);

create table ships (
	id 				INT NOT NULL AUTO_INCREMENT,
	name			VARCHAR(20),
	registration	VARCHAR(20),
	PRIMARY KEY (id)
);

create table roster (
	id		INT NOT NULL AUTO_INCREMENT,
	crewid	INT NOT NULL,
	shipid	INT NOT NULL,
	PRIMARY KEY (id),
	FOREIGN KEY (crewid)
		REFERENCES crew(id)
		ON UPDATE CASCADE
		ON DELETE CASCADE,
	FOREIGN KEY (shipid)
		REFERENCES ships(id)
		ON UPDATE CASCADE
		ON DELETE CASCADE
);


INSERT INTO roles (role, pilotQualified) VALUES ('captain', TRUE);
INSERT INTO roles (role, pilotQualified) VALUES ('first officer', TRUE);
INSERT INTO roles (role, pilotQualified) VALUES ('pilot', TRUE);
INSERT INTO roles (role, pilotQualified) VALUES ('public relations', TRUE);
INSERT INTO roles (role, pilotQualified) VALUES ('doctor', FALSE);
INSERT INTO roles (role, pilotQualified) VALUES ('councilor', FALSE);
INSERT INTO roles (role, pilotQualified) VALUES ('engineer', FALSE);
INSERT INTO roles (role, pilotQualified) VALUES ('crew', FALSE);

INSERT INTO ships (name, registration) VALUES ('Serenity', '404-E-132-4FE274A');
INSERT INTO ships (name, registration) VALUES ('Enterprise', 'NCC-1701-D');

INSERT INTO crew (fname, lname, age, roleid) VALUES ('Malcolm', 'Reynolds', 31, 1);
INSERT INTO crew (fname, lname, age, roleid) VALUES ('Zoe', 'Washburne', 33, 2);
INSERT INTO crew (fname, lname, age, roleid) VALUES ('Hoban', 'Washburne', 30, 3);
INSERT INTO crew (fname, lname, age, roleid) VALUES ('Jayne', 'Cobb', 35, 4);
INSERT INTO crew (fname, lname, age, roleid) VALUES ('Inara', 'Serra', 27, 8);
INSERT INTO crew (fname, lname, age, roleid) VALUES ('Jewel', 'Staite', 21, 7);
INSERT INTO crew (fname, lname, age, roleid) VALUES ('Derrial', 'Book', 55, 6);
INSERT INTO crew (fname, lname, age, roleid) VALUES ('Simon', 'Tam', 27, 5);
INSERT INTO crew (fname, lname, age, roleid) VALUES ('River', 'Tam', 17, 8);

INSERT INTO crew (fname, lname, age, roleid) VALUES ('Jean-Luc', 'Picard', 59, 1);
INSERT INTO crew (fname, lname, age, roleid) VALUES ('William', 'Riker', 29, 2);
INSERT INTO crew (fname, lname, age, roleid) VALUES ('Data', 'Soong', 26, 3);
INSERT INTO crew (fname, lname, age, roleid) VALUES ('Worf', 'Martok', 24, 4);
INSERT INTO crew (fname, lname, age, roleid) VALUES ('Geordi', 'LaForge', 29, 7);
INSERT INTO crew (fname, lname, age, roleid) VALUES ('Guinan', 'N/A', 600, 6);
INSERT INTO crew (fname, lname, age, roleid) VALUES ('Beverly', 'Crusher', 40, 5);
INSERT INTO crew (fname, lname, age, roleid) VALUES ('William', 'Crusher', 16, 8);

INSERT INTO roster (crewid, shipid) VALUES (1, 1);
INSERT INTO roster (crewid, shipid) VALUES (2, 1);
INSERT INTO roster (crewid, shipid) VALUES (3, 1);
INSERT INTO roster (crewid, shipid) VALUES (4, 1);
INSERT INTO roster (crewid, shipid) VALUES (5, 1);
INSERT INTO roster (crewid, shipid) VALUES (6, 1);
INSERT INTO roster (crewid, shipid) VALUES (7, 1);
INSERT INTO roster (crewid, shipid) VALUES (8, 1);
INSERT INTO roster (crewid, shipid) VALUES (9, 1);

INSERT INTO roster (crewid, shipid) VALUES (10, 2);
INSERT INTO roster (crewid, shipid) VALUES (11, 2);
INSERT INTO roster (crewid, shipid) VALUES (12, 2);
INSERT INTO roster (crewid, shipid) VALUES (13, 2);
INSERT INTO roster (crewid, shipid) VALUES (14, 2);
INSERT INTO roster (crewid, shipid) VALUES (15, 2);
INSERT INTO roster (crewid, shipid) VALUES (16, 2);
INSERT INTO roster (crewid, shipid) VALUES (17, 2);

