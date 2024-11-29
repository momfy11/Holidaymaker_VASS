--
-- PostgreSQL database dump
--

-- Dumped from database version 16.4
-- Dumped by pg_dump version 16.4

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: holidaymaker_database; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE holidaymaker_database WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Swedish_Sweden.1252';


ALTER DATABASE holidaymaker_database OWNER TO postgres;

\connect holidaymaker_database

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Data for Name: adresses; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.adresses (id, street, street_nr, zipcode, city, country) OVERRIDING SYSTEM VALUE VALUES (2, 'Passeig Marítim', '45', '8002', 'Barcelona', 'Spain');
INSERT INTO public.adresses (id, street, street_nr, zipcode, city, country) OVERRIDING SYSTEM VALUE VALUES (3, 'Lungomare Giuseppe', '23', '90139', 'Palermo', 'Italy');
INSERT INTO public.adresses (id, street, street_nr, zipcode, city, country) OVERRIDING SYSTEM VALUE VALUES (4, 'Avenue de la Plage', '8', '6230', 'Saint-Jean', 'France');
INSERT INTO public.adresses (id, street, street_nr, zipcode, city, country) OVERRIDING SYSTEM VALUE VALUES (5, 'Plaka Beach Road', '5', '12012', 'Athens', 'Greece');
INSERT INTO public.adresses (id, street, street_nr, zipcode, city, country) OVERRIDING SYSTEM VALUE VALUES (6, 'Calle del Mar', '17', '29015', 'Malaga', 'Spain');
INSERT INTO public.adresses (id, street, street_nr, zipcode, city, country) OVERRIDING SYSTEM VALUE VALUES (7, 'Obala Kneza', '10', '20000', 'Dubrovnik', 'Croatia');
INSERT INTO public.adresses (id, street, street_nr, zipcode, city, country) OVERRIDING SYSTEM VALUE VALUES (8, 'Corniche Road', '3', '11100', 'Cannes', 'France');
INSERT INTO public.adresses (id, street, street_nr, zipcode, city, country) OVERRIDING SYSTEM VALUE VALUES (9, 'Marina Walk', '7', '21000', 'Split', 'Croatia');
INSERT INTO public.adresses (id, street, street_nr, zipcode, city, country) OVERRIDING SYSTEM VALUE VALUES (10, 'Via del Porto', '1', '20121', 'Milan', 'Italy');
INSERT INTO public.adresses (id, street, street_nr, zipcode, city, country) OVERRIDING SYSTEM VALUE VALUES (1, 'Rua das Ondas', '12', '1100', 'Lisbon', 'Portugal');
INSERT INTO public.adresses (id, street, street_nr, zipcode, city, country) OVERRIDING SYSTEM VALUE VALUES (11, 'Bahnhofstrasse', '20', '8001', 'Zurich', 'Switzerland');
INSERT INTO public.adresses (id, street, street_nr, zipcode, city, country) OVERRIDING SYSTEM VALUE VALUES (12, 'Oxford Street', '55', '1001', 'London', 'United Kingdom');
INSERT INTO public.adresses (id, street, street_nr, zipcode, city, country) OVERRIDING SYSTEM VALUE VALUES (13, 'Rue de Rivoli', '10', '75001', 'Paris', 'France');
INSERT INTO public.adresses (id, street, street_nr, zipcode, city, country) OVERRIDING SYSTEM VALUE VALUES (14, 'Váci Utca', '8', '1052', 'Budapest', 'Hungary');
INSERT INTO public.adresses (id, street, street_nr, zipcode, city, country) OVERRIDING SYSTEM VALUE VALUES (15, 'Via del Corso', '22', '187', 'Rome', 'Italy');
INSERT INTO public.adresses (id, street, street_nr, zipcode, city, country) OVERRIDING SYSTEM VALUE VALUES (16, 'Karl Johans gate', '14', '154', 'Oslo', 'Norway');
INSERT INTO public.adresses (id, street, street_nr, zipcode, city, country) OVERRIDING SYSTEM VALUE VALUES (17, 'Plaza Mayor', '5', '28012', 'Madrid', 'Spain');
INSERT INTO public.adresses (id, street, street_nr, zipcode, city, country) OVERRIDING SYSTEM VALUE VALUES (18, 'Damstraat', '9', '1012', 'Amsterdam', 'Netherlands');
INSERT INTO public.adresses (id, street, street_nr, zipcode, city, country) OVERRIDING SYSTEM VALUE VALUES (19, 'Happy Street', '69', '12345', 'Prag', 'NeverLand');


--
-- Data for Name: accommodation; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.accommodation (id, name, distance_beach, distance_centrum, pool, entertainment, kids_club, restaurant, location, gym) VALUES (1, 'Cozy Beach B&B', 5000, 2500, false, false, false, false, 1, true);
INSERT INTO public.accommodation (id, name, distance_beach, distance_centrum, pool, entertainment, kids_club, restaurant, location, gym) VALUES (2, 'Seaside Ibis Budget', 4000, 1500, false, false, false, true, 2, false);
INSERT INTO public.accommodation (id, name, distance_beach, distance_centrum, pool, entertainment, kids_club, restaurant, location, gym) VALUES (3, 'Campanile Oceanfront', 3500, 3000, false, false, false, true, 3, false);
INSERT INTO public.accommodation (id, name, distance_beach, distance_centrum, pool, entertainment, kids_club, restaurant, location, gym) VALUES (4, 'NH Coastal Retreat', 3000, 1000, false, false, false, true, 4, false);
INSERT INTO public.accommodation (id, name, distance_beach, distance_centrum, pool, entertainment, kids_club, restaurant, location, gym) VALUES (5, 'Mercure Beachfront', 2500, 500, true, false, false, true, 5, false);
INSERT INTO public.accommodation (id, name, distance_beach, distance_centrum, pool, entertainment, kids_club, restaurant, location, gym) VALUES (6, 'Novotel Waterfront', 2000, 800, true, true, false, true, 6, false);
INSERT INTO public.accommodation (id, name, distance_beach, distance_centrum, pool, entertainment, kids_club, restaurant, location, gym) VALUES (7, 'Radisson Blu Shoreline', 1500, 300, true, true, true, true, 7, false);
INSERT INTO public.accommodation (id, name, distance_beach, distance_centrum, pool, entertainment, kids_club, restaurant, location, gym) VALUES (8, 'Hilton Riviera', 1000, 200, true, true, true, true, 8, false);
INSERT INTO public.accommodation (id, name, distance_beach, distance_centrum, pool, entertainment, kids_club, restaurant, location, gym) VALUES (9, 'Marriott Marina', 500, 100, true, true, true, true, 9, false);
INSERT INTO public.accommodation (id, name, distance_beach, distance_centrum, pool, entertainment, kids_club, restaurant, location, gym) VALUES (10, 'Ritz-Carlton Bayfront', 0, 0, true, true, true, true, 10, false);


--
-- Data for Name: account; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.account (id, phone, email, adress) VALUES (1, '+446599638', 'liammüller@mail.com', 11);
INSERT INTO public.account (id, phone, email, adress) VALUES (2, '+362113960', 'oliviaschneider@mail.com', 12);
INSERT INTO public.account (id, phone, email, adress) VALUES (3, '+375125011', 'noahrossi@mail.com', 13);
INSERT INTO public.account (id, phone, email, adress) VALUES (4, '+389336588', 'emmadubois@mail.com', 14);
INSERT INTO public.account (id, phone, email, adress) VALUES (5, '+411988392', 'lucasandersson@mail.com', 15);
INSERT INTO public.account (id, phone, email, adress) VALUES (6, '+321145472', 'sophiajensen@mail.com', 16);
INSERT INTO public.account (id, phone, email, adress) VALUES (7, '+346812590', 'miagarcia@mail.com', 17);
INSERT INTO public.account (id, phone, email, adress) VALUES (8, '+401153847', 'olivernovak@mail.com', 18);
INSERT INTO public.account (id, phone, email, adress) VALUES (9, '095837621', 'happy@life.com', 19);


--
-- Data for Name: rooms; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (1, 2, 'Small', 2, 50, 1);
INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (2, 3, 'Medium', 4, 60, 1);
INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (3, 4, 'Large', 6, 100, 1);
INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (4, 2, 'Small', 2, 50, 1);
INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (5, 3, 'Medium', 4, 120, 2);
INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (6, 4, 'Large', 6, 150, 2);
INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (7, 2, 'Small', 2, 100, 2);
INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (8, 3, 'Medium', 4, 180, 3);
INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (9, 4, 'Large', 6, 300, 3);
INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (10, 2, 'Small', 2, 150, 3);
INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (11, 3, 'Medium', 4, 220, 4);
INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (12, 4, 'Large', 6, 250, 4);
INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (13, 2, 'Small', 2, 180, 4);
INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (14, 3, 'Medium', 4, 300, 5);
INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (15, 4, 'Large', 6, 400, 5);
INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (16, 2, 'Small', 2, 200, 5);
INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (17, 3, 'Medium', 4, 280, 6);
INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (18, 4, 'Large', 6, 350, 6);
INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (19, 2, 'Small', 2, 240, 6);
INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (20, 3, 'Medium', 4, 400, 7);
INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (21, 4, 'Large', 6, 500, 7);
INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (22, 2, 'Small', 2, 300, 7);
INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (23, 3, 'Medium', 4, 350, 8);
INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (24, 4, 'Large', 6, 450, 8);
INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (25, 2, 'Small', 2, 300, 8);
INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (26, 3, 'Medium', 4, 500, 9);
INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (27, 4, 'Large', 6, 600, 9);
INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (28, 2, 'Small', 2, 400, 9);
INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (29, 3, 'Medium', 4, 600, 10);
INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (30, 4, 'Large', 6, 750, 10);
INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (31, 2, 'Small', 2, 500, 10);
INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (32, 2, 'Small', 2, 50, 1);
INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (33, 3, 'Medium', 4, 60, 1);
INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (34, 4, 'Large', 6, 100, 1);
INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (35, 2, 'Small', 2, 50, 1);
INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (36, 3, 'Medium', 4, 120, 2);
INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (37, 4, 'Large', 6, 150, 2);
INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (38, 2, 'Small', 2, 100, 2);
INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (39, 3, 'Medium', 4, 180, 3);
INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (40, 4, 'Large', 6, 300, 3);
INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (41, 2, 'Small', 2, 150, 3);
INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (42, 3, 'Medium', 4, 220, 4);
INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (43, 4, 'Large', 6, 250, 4);
INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (44, 2, 'Small', 2, 180, 4);
INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (45, 3, 'Medium', 4, 300, 5);
INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (46, 4, 'Large', 6, 400, 5);
INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (47, 2, 'Small', 2, 200, 5);
INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (48, 3, 'Medium', 4, 280, 6);
INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (49, 4, 'Large', 6, 350, 6);
INSERT INTO public.rooms (id, beds, size, capacity, price, acommondation) VALUES (50, 2, 'Small', 2, 240, 6);


--
-- Data for Name: bookings; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- Data for Name: extras; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.extras (id, name, price) VALUES (1, 'Bed', 20);
INSERT INTO public.extras (id, name, price) VALUES (2, 'Breakfast', 15);
INSERT INTO public.extras (id, name, price) VALUES (3, 'Half board', 25);
INSERT INTO public.extras (id, name, price) VALUES (4, 'Full board', 35);
INSERT INTO public.extras (id, name, price) VALUES (5, 'Roomservice', 5);
INSERT INTO public.extras (id, name, price) VALUES (6, 'ALl-inclusive', 45);


--
-- Data for Name: bookingsxextras; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- Data for Name: guests; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) VALUES (1, 'John', 'Smith', 1, '1985-07-15');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) VALUES (2, 'Alice', 'Johnson', 1, '1990-03-22');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) VALUES (3, 'Mark', 'Brown', 2, '1988-11-11');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) VALUES (4, 'Emily', 'Davis', 2, '1975-04-19');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) VALUES (5, 'Luke', 'Wilson', 2, '1995-08-08');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) VALUES (6, 'Sarah', 'Taylor', 3, '1992-09-10');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) VALUES (7, 'Chris', 'Thomas', 3, '1980-05-30');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) VALUES (8, 'Laura', 'Jackson', 3, '1978-12-25');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) VALUES (9, 'Michael', 'White', 4, '1987-06-20');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) VALUES (10, 'Jessica', 'Harris', 4, '1993-02-14');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) VALUES (11, 'David', 'Martin', 4, '1979-10-01');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) VALUES (12, 'Olivia', 'Thompson', 5, '1982-03-18');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) VALUES (13, 'James', 'Garcia', 5, '1996-07-22');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) VALUES (14, 'Sophia', 'Martinez', 5, '1984-11-02');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) VALUES (15, 'William', 'Robinson', 6, '1977-01-09');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) VALUES (16, 'Mia', 'Clark', 6, '1991-12-11');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) VALUES (17, 'Ethan', 'Lewis', 6, '1989-05-07');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) VALUES (18, 'Isabella', 'Walker', 6, '1983-09-15');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) VALUES (19, 'Daniel', 'Hall', 7, '1990-06-27');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) VALUES (20, 'Grace', 'Allen', 7, '1976-04-08');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) VALUES (21, 'Benjamin', 'Young', 7, '1985-11-19');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) VALUES (22, 'Chloe', 'King', 7, '1988-08-13');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) VALUES (23, 'Lucas', 'Wright', 8, '1975-02-23');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) VALUES (24, 'Emma', 'Scott', 8, '1993-03-03');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) VALUES (25, 'Noah', 'Adams', 8, '1986-10-17');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) VALUES (26, 'Lily', 'Baker', 8, '1981-07-05');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) VALUES (27, 'Mason', 'Gonzalez', 1, '1992-05-21');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) VALUES (28, 'Ava', 'Nelson', 1, '1987-12-30');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) VALUES (29, 'Alexander', 'Carter', 2, '1994-01-19');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) VALUES (30, 'Isabella', 'Mitchell', 2, '1989-06-09');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) VALUES (31, 'Evelyn', 'Perez', 3, '1977-03-12');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) VALUES (32, 'Harper', 'Roberts', 3, '1995-09-25');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) VALUES (33, 'Logan', 'Turner', 4, '1988-08-30');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) VALUES (34, 'Abigail', 'Phillips', 4, '1981-10-15');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) VALUES (35, 'Scarlett', 'Campbell', 5, '1990-11-03');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) VALUES (36, 'Sebastian', 'Parker', 5, '1984-12-01');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) VALUES (37, 'Lily', 'Evans', 6, '1986-02-06');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) VALUES (38, 'Jack', 'Edwards', 7, '1979-04-21');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) VALUES (39, 'Victoria', 'Collins', 7, '1983-07-28');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) VALUES (40, 'Henry', 'Stewart', 8, '1991-11-17');


--
-- Data for Name: ratings; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.ratings (accommodation, "user", rating, comments, id) VALUES (3, 1, 4, ' Amazing experience! Highly recommend.', 1);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) VALUES (4, 2, 3, ' Decent stay', 2);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) VALUES (5, 3, 3, 'Perfect for families', 3);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) VALUES (5, 4, 3, 'Too expensive for what it offers', 4);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) VALUES (4, 5, 1, 'Would not stay here again.', 5);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) VALUES (2, 6, 2, 'Good location but noisy.', 6);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) VALUES (1, 7, 4, 'Friendly staff and great amenities.', 7);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) VALUES (2, 8, 5, 'Excellent service and food!', 8);


--
-- Name: accommodation_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.accommodation_id_seq', 10, true);


--
-- Name: account_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.account_id_seq', 9, true);


--
-- Name: adresses_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.adresses_id_seq', 19, true);


--
-- Name: bookings_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.bookings_id_seq', 1, false);


--
-- Name: extras_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.extras_id_seq', 10, true);


--
-- Name: guests_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.guests_id_seq', 40, true);


--
-- Name: ratings_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.ratings_id_seq', 8, true);


--
-- Name: rooms_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.rooms_id_seq', 50, true);


--
-- PostgreSQL database dump complete
--

