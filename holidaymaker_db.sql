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
INSERT INTO public.adresses (id, street, street_nr, zipcode, city, country) OVERRIDING SYSTEM VALUE VALUES (20, 'Dalhemsvägen', '94', '25752', 'Helsingborg', 'Sweden');
INSERT INTO public.adresses (id, street, street_nr, zipcode, city, country) OVERRIDING SYSTEM VALUE VALUES (21, 'hejgata', '12', '12345', 'hbg', 'Sweden');
INSERT INTO public.adresses (id, street, street_nr, zipcode, city, country) OVERRIDING SYSTEM VALUE VALUES (22, 'Valhallarow', '69', '12345', 'Bergen', 'Norway');


--
-- Data for Name: accommodation; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.accommodation (id, name, distance_beach, distance_centrum, pool, entertainment, kids_club, restaurant, location, gym) OVERRIDING SYSTEM VALUE VALUES (1, 'Cozy Beach B&B', 5000, 2500, false, false, false, false, 1, true);
INSERT INTO public.accommodation (id, name, distance_beach, distance_centrum, pool, entertainment, kids_club, restaurant, location, gym) OVERRIDING SYSTEM VALUE VALUES (2, 'Seaside Ibis Budget', 4000, 1500, false, false, false, true, 2, false);
INSERT INTO public.accommodation (id, name, distance_beach, distance_centrum, pool, entertainment, kids_club, restaurant, location, gym) OVERRIDING SYSTEM VALUE VALUES (3, 'Campanile Oceanfront', 3500, 3000, false, false, false, true, 3, false);
INSERT INTO public.accommodation (id, name, distance_beach, distance_centrum, pool, entertainment, kids_club, restaurant, location, gym) OVERRIDING SYSTEM VALUE VALUES (4, 'NH Coastal Retreat', 3000, 1000, false, false, false, true, 4, false);
INSERT INTO public.accommodation (id, name, distance_beach, distance_centrum, pool, entertainment, kids_club, restaurant, location, gym) OVERRIDING SYSTEM VALUE VALUES (5, 'Mercure Beachfront', 2500, 500, true, false, false, true, 5, false);
INSERT INTO public.accommodation (id, name, distance_beach, distance_centrum, pool, entertainment, kids_club, restaurant, location, gym) OVERRIDING SYSTEM VALUE VALUES (6, 'Novotel Waterfront', 2000, 800, true, true, false, true, 6, false);
INSERT INTO public.accommodation (id, name, distance_beach, distance_centrum, pool, entertainment, kids_club, restaurant, location, gym) OVERRIDING SYSTEM VALUE VALUES (7, 'Radisson Blu Shoreline', 1500, 300, true, true, true, true, 7, false);
INSERT INTO public.accommodation (id, name, distance_beach, distance_centrum, pool, entertainment, kids_club, restaurant, location, gym) OVERRIDING SYSTEM VALUE VALUES (8, 'Hilton Riviera', 1000, 200, true, true, true, true, 8, false);
INSERT INTO public.accommodation (id, name, distance_beach, distance_centrum, pool, entertainment, kids_club, restaurant, location, gym) OVERRIDING SYSTEM VALUE VALUES (9, 'Marriott Marina', 500, 100, true, true, true, true, 9, false);
INSERT INTO public.accommodation (id, name, distance_beach, distance_centrum, pool, entertainment, kids_club, restaurant, location, gym) OVERRIDING SYSTEM VALUE VALUES (10, 'Ritz-Carlton Bayfront', 0, 0, true, true, true, true, 10, false);


--
-- Data for Name: account; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.account (id, phone, email, adress) OVERRIDING SYSTEM VALUE VALUES (1, '+446599638', 'liammüller@mail.com', 11);
INSERT INTO public.account (id, phone, email, adress) OVERRIDING SYSTEM VALUE VALUES (2, '+362113960', 'oliviaschneider@mail.com', 12);
INSERT INTO public.account (id, phone, email, adress) OVERRIDING SYSTEM VALUE VALUES (3, '+375125011', 'noahrossi@mail.com', 13);
INSERT INTO public.account (id, phone, email, adress) OVERRIDING SYSTEM VALUE VALUES (4, '+389336588', 'emmadubois@mail.com', 14);
INSERT INTO public.account (id, phone, email, adress) OVERRIDING SYSTEM VALUE VALUES (5, '+411988392', 'lucasandersson@mail.com', 15);
INSERT INTO public.account (id, phone, email, adress) OVERRIDING SYSTEM VALUE VALUES (6, '+321145472', 'sophiajensen@mail.com', 16);
INSERT INTO public.account (id, phone, email, adress) OVERRIDING SYSTEM VALUE VALUES (7, '+346812590', 'miagarcia@mail.com', 17);
INSERT INTO public.account (id, phone, email, adress) OVERRIDING SYSTEM VALUE VALUES (8, '+401153847', 'olivernovak@mail.com', 18);
INSERT INTO public.account (id, phone, email, adress) OVERRIDING SYSTEM VALUE VALUES (9, '095837621', 'happy@life.com', 19);
INSERT INTO public.account (id, phone, email, adress) OVERRIDING SYSTEM VALUE VALUES (10, '0704568978', 'joggen8@hotmail.com', 20);
INSERT INTO public.account (id, phone, email, adress) OVERRIDING SYSTEM VALUE VALUES (11, '07050505', 'hejsan@.com', 21);
INSERT INTO public.account (id, phone, email, adress) OVERRIDING SYSTEM VALUE VALUES (12, '+4775631285', 'Lickit@now.com', 22);


--
-- Data for Name: rooms; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (1, 2, 'Small', 2, 50, 1);
INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (2, 3, 'Medium', 4, 60, 1);
INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (3, 4, 'Large', 6, 100, 1);
INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (4, 2, 'Small', 2, 50, 1);
INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (5, 3, 'Medium', 4, 120, 2);
INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (6, 4, 'Large', 6, 150, 2);
INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (7, 2, 'Small', 2, 100, 2);
INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (8, 3, 'Medium', 4, 180, 3);
INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (9, 4, 'Large', 6, 300, 3);
INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (10, 2, 'Small', 2, 150, 3);
INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (11, 3, 'Medium', 4, 220, 4);
INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (12, 4, 'Large', 6, 250, 4);
INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (13, 2, 'Small', 2, 180, 4);
INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (14, 3, 'Medium', 4, 300, 5);
INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (15, 4, 'Large', 6, 400, 5);
INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (16, 2, 'Small', 2, 200, 5);
INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (17, 3, 'Medium', 4, 280, 6);
INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (18, 4, 'Large', 6, 350, 6);
INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (19, 2, 'Small', 2, 240, 6);
INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (20, 3, 'Medium', 4, 400, 7);
INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (21, 4, 'Large', 6, 500, 7);
INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (22, 2, 'Small', 2, 300, 7);
INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (23, 3, 'Medium', 4, 350, 8);
INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (24, 4, 'Large', 6, 450, 8);
INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (25, 2, 'Small', 2, 300, 8);
INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (26, 3, 'Medium', 4, 500, 9);
INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (27, 4, 'Large', 6, 600, 9);
INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (28, 2, 'Small', 2, 400, 9);
INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (29, 3, 'Medium', 4, 600, 10);
INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (30, 4, 'Large', 6, 750, 10);
INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (31, 2, 'Small', 2, 500, 10);
INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (32, 2, 'Small', 2, 50, 1);
INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (33, 3, 'Medium', 4, 60, 1);
INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (34, 4, 'Large', 6, 100, 1);
INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (35, 2, 'Small', 2, 50, 1);
INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (36, 3, 'Medium', 4, 120, 2);
INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (37, 4, 'Large', 6, 150, 2);
INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (38, 2, 'Small', 2, 100, 2);
INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (39, 3, 'Medium', 4, 180, 3);
INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (40, 4, 'Large', 6, 300, 3);
INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (41, 2, 'Small', 2, 150, 3);
INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (42, 3, 'Medium', 4, 220, 4);
INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (43, 4, 'Large', 6, 250, 4);
INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (44, 2, 'Small', 2, 180, 4);
INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (45, 3, 'Medium', 4, 300, 5);
INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (46, 4, 'Large', 6, 400, 5);
INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (47, 2, 'Small', 2, 200, 5);
INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (48, 3, 'Medium', 4, 280, 6);
INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (49, 4, 'Large', 6, 350, 6);
INSERT INTO public.rooms (id, beds, size, capacity, price, accommodation) OVERRIDING SYSTEM VALUE VALUES (50, 2, 'Small', 2, 240, 6);


--
-- Data for Name: bookings; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (1, 12, '2024-12-02 13:00:00', '2024-12-05 10:00:00', 1, 350);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (2, 8, '2024-12-10 13:00:00', '2024-12-13 10:00:00', 3, 420);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (3, 14, '2024-12-06 13:00:00', '2024-12-15 10:00:00', 2, 640);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (4, 5, '2024-12-03 13:00:00', '2024-12-08 10:00:00', 4, 280);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (5, 21, '2024-12-12 13:00:00', '2024-12-16 10:00:00', 1, 750);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (6, 9, '2024-12-15 13:00:00', '2024-12-22 10:00:00', 5, 630);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (7, 18, '2024-12-20 13:00:00', '2024-12-25 10:00:00', 2, 400);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (8, 7, '2024-12-07 13:00:00', '2024-12-10 10:00:00', 3, 270);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (9, 24, '2024-12-22 13:00:00', '2024-12-30 10:00:00', 4, 960);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (10, 11, '2024-12-10 13:00:00', '2024-12-14 10:00:00', 6, 360);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (11, 3, '2024-12-05 13:00:00', '2024-12-09 10:00:00', 7, 400);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (12, 15, '2024-12-27 13:00:00', '2025-01-05 10:00:00', 5, 890);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (13, 4, '2024-12-02 13:00:00', '2024-12-06 10:00:00', 8, 450);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (14, 19, '2024-12-17 13:00:00', '2024-12-21 10:00:00', 3, 370);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (15, 6, '2024-12-24 13:00:00', '2025-01-01 10:00:00', 2, 980);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (16, 10, '2024-12-13 13:00:00', '2024-12-17 10:00:00', 1, 330);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (17, 16, '2024-12-08 13:00:00', '2024-12-14 10:00:00', 7, 550);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (18, 2, '2024-12-15 13:00:00', '2024-12-20 10:00:00', 4, 700);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (19, 20, '2024-12-04 13:00:00', '2024-12-12 10:00:00', 5, 890);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (20, 13, '2024-12-19 13:00:00', '2024-12-23 10:00:00', 6, 620);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (21, 1, '2024-12-06 13:00:00', '2024-12-10 10:00:00', 3, 450);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (22, 25, '2024-12-18 13:00:00', '2024-12-24 10:00:00', 7, 720);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (23, 22, '2024-12-28 13:00:00', '2025-01-02 10:00:00', 1, 650);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (24, 17, '2024-12-14 13:00:00', '2024-12-18 10:00:00', 4, 430);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (25, 23, '2024-12-16 13:00:00', '2024-12-22 10:00:00', 2, 780);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (26, 26, '2024-12-31 13:00:00', '2025-01-05 10:00:00', 8, 830);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (27, 14, '2024-12-25 13:00:00', '2025-01-01 10:00:00', 6, 670);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (28, 5, '2024-12-03 13:00:00', '2024-12-08 10:00:00', 5, 420);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (29, 9, '2024-12-21 13:00:00', '2024-12-27 10:00:00', 4, 620);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (30, 8, '2024-12-11 13:00:00', '2024-12-15 10:00:00', 3, 510);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (31, 12, '2024-12-09 13:00:00', '2024-12-15 10:00:00', 1, 700);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (32, 7, '2024-12-04 13:00:00', '2024-12-07 10:00:00', 2, 240);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (33, 18, '2024-12-13 13:00:00', '2024-12-18 10:00:00', 6, 510);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (34, 3, '2024-12-06 13:00:00', '2024-12-10 10:00:00', 8, 350);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (35, 10, '2024-12-19 13:00:00', '2024-12-25 10:00:00', 5, 660);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (36, 4, '2024-12-27 13:00:00', '2025-01-01 10:00:00', 7, 620);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (37, 11, '2024-12-29 13:00:00', '2025-01-03 10:00:00', 3, 540);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (38, 6, '2024-12-14 13:00:00', '2024-12-20 10:00:00', 2, 650);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (39, 16, '2024-12-12 13:00:00', '2024-12-19 10:00:00', 1, 770);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (40, 15, '2024-12-08 13:00:00', '2024-12-15 10:00:00', 8, 670);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (41, 20, '2024-12-26 13:00:00', '2025-01-01 10:00:00', 4, 780);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (42, 17, '2024-12-10 13:00:00', '2024-12-14 10:00:00', 7, 360);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (43, 19, '2024-12-20 13:00:00', '2024-12-25 10:00:00', 2, 560);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (44, 24, '2024-12-23 13:00:00', '2024-12-30 10:00:00', 5, 850);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (45, 13, '2024-12-28 13:00:00', '2025-01-03 10:00:00', 8, 630);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (46, 14, '2024-12-25 13:00:00', '2024-12-31 10:00:00', 4, 720);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (47, 22, '2024-12-18 13:00:00', '2024-12-22 10:00:00', 7, 450);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (48, 11, '2024-12-26 13:00:00', '2024-12-31 10:00:00', 3, 540);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (49, 25, '2024-12-30 13:00:00', '2025-01-05 10:00:00', 1, 710);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (50, 26, '2024-12-27 13:00:00', '2025-01-02 10:00:00', 6, 670);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (51, 12, '2024-11-03 13:00:00', '2024-11-06 10:00:00', 5, 245);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (52, 29, '2024-11-05 13:00:00', '2024-11-07 10:00:00', 7, 315);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (53, 42, '2024-11-09 13:00:00', '2024-11-12 10:00:00', 2, 390);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (54, 5, '2024-11-10 13:00:00', '2024-11-13 10:00:00', 8, 260);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (55, 33, '2024-11-14 13:00:00', '2024-11-16 10:00:00', 3, 305);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (56, 8, '2024-11-16 13:00:00', '2024-11-19 10:00:00', 1, 280);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (57, 17, '2024-11-18 13:00:00', '2024-11-20 10:00:00', 4, 330);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (58, 24, '2024-11-19 13:00:00', '2024-11-22 10:00:00', 6, 345);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (59, 38, '2024-11-22 13:00:00', '2024-11-25 10:00:00', 2, 320);
INSERT INTO public.bookings (id, room, booking_start, booking_end, account, total_price) OVERRIDING SYSTEM VALUE VALUES (60, 47, '2024-11-24 13:00:00', '2024-11-27 10:00:00', 7, 365);


--
-- Data for Name: extras; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.extras (id, name, price) OVERRIDING SYSTEM VALUE VALUES (1, 'Bed', 20);
INSERT INTO public.extras (id, name, price) OVERRIDING SYSTEM VALUE VALUES (2, 'Breakfast', 15);
INSERT INTO public.extras (id, name, price) OVERRIDING SYSTEM VALUE VALUES (3, 'Half board', 25);
INSERT INTO public.extras (id, name, price) OVERRIDING SYSTEM VALUE VALUES (4, 'Full board', 35);
INSERT INTO public.extras (id, name, price) OVERRIDING SYSTEM VALUE VALUES (5, 'Roomservice', 5);
INSERT INTO public.extras (id, name, price) OVERRIDING SYSTEM VALUE VALUES (6, 'ALl-inclusive', 45);


--
-- Data for Name: bookingsxextras; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (1, 1);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (1, 2);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (2, 4);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (3, 3);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (3, 5);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (4, 2);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (5, 6);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (6, 1);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (6, 5);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (7, 4);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (8, 2);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (9, 1);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (10, 5);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (11, 3);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (12, 6);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (13, 1);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (14, 2);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (15, 4);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (16, 5);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (17, 3);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (18, 1);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (19, 6);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (20, 2);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (21, 4);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (22, 1);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (23, 5);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (24, 3);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (25, 6);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (26, 1);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (27, 2);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (28, 4);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (29, 5);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (30, 3);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (31, 6);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (32, 1);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (33, 2);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (34, 5);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (35, 3);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (36, 4);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (37, 6);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (38, 2);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (39, 1);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (40, 5);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (41, 3);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (42, 4);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (43, 6);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (44, 2);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (45, 1);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (46, 5);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (47, 3);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (48, 6);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (49, 1);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (50, 2);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (51, 1);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (51, 5);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (52, 2);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (53, 6);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (54, 3);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (55, 4);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (55, 5);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (56, 1);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (57, 2);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (57, 6);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (58, 3);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (59, 4);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (59, 5);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (60, 2);
INSERT INTO public.bookingsxextras (booking_id, extras_id) VALUES (60, 6);


--
-- Data for Name: guests; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) OVERRIDING SYSTEM VALUE VALUES (1, 'John', 'Smith', 1, '1985-07-15');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) OVERRIDING SYSTEM VALUE VALUES (2, 'Alice', 'Johnson', 1, '1990-03-22');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) OVERRIDING SYSTEM VALUE VALUES (3, 'Mark', 'Brown', 2, '1988-11-11');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) OVERRIDING SYSTEM VALUE VALUES (4, 'Emily', 'Davis', 2, '1975-04-19');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) OVERRIDING SYSTEM VALUE VALUES (5, 'Luke', 'Wilson', 2, '1995-08-08');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) OVERRIDING SYSTEM VALUE VALUES (6, 'Sarah', 'Taylor', 3, '1992-09-10');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) OVERRIDING SYSTEM VALUE VALUES (7, 'Chris', 'Thomas', 3, '1980-05-30');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) OVERRIDING SYSTEM VALUE VALUES (8, 'Laura', 'Jackson', 3, '1978-12-25');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) OVERRIDING SYSTEM VALUE VALUES (9, 'Michael', 'White', 4, '1987-06-20');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) OVERRIDING SYSTEM VALUE VALUES (10, 'Jessica', 'Harris', 4, '1993-02-14');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) OVERRIDING SYSTEM VALUE VALUES (11, 'David', 'Martin', 4, '1979-10-01');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) OVERRIDING SYSTEM VALUE VALUES (12, 'Olivia', 'Thompson', 5, '1982-03-18');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) OVERRIDING SYSTEM VALUE VALUES (13, 'James', 'Garcia', 5, '1996-07-22');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) OVERRIDING SYSTEM VALUE VALUES (14, 'Sophia', 'Martinez', 5, '1984-11-02');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) OVERRIDING SYSTEM VALUE VALUES (15, 'William', 'Robinson', 6, '1977-01-09');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) OVERRIDING SYSTEM VALUE VALUES (16, 'Mia', 'Clark', 6, '1991-12-11');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) OVERRIDING SYSTEM VALUE VALUES (17, 'Ethan', 'Lewis', 6, '1989-05-07');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) OVERRIDING SYSTEM VALUE VALUES (18, 'Isabella', 'Walker', 6, '1983-09-15');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) OVERRIDING SYSTEM VALUE VALUES (19, 'Daniel', 'Hall', 7, '1990-06-27');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) OVERRIDING SYSTEM VALUE VALUES (20, 'Grace', 'Allen', 7, '1976-04-08');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) OVERRIDING SYSTEM VALUE VALUES (21, 'Benjamin', 'Young', 7, '1985-11-19');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) OVERRIDING SYSTEM VALUE VALUES (22, 'Chloe', 'King', 7, '1988-08-13');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) OVERRIDING SYSTEM VALUE VALUES (23, 'Lucas', 'Wright', 8, '1975-02-23');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) OVERRIDING SYSTEM VALUE VALUES (24, 'Emma', 'Scott', 8, '1993-03-03');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) OVERRIDING SYSTEM VALUE VALUES (25, 'Noah', 'Adams', 8, '1986-10-17');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) OVERRIDING SYSTEM VALUE VALUES (26, 'Lily', 'Baker', 8, '1981-07-05');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) OVERRIDING SYSTEM VALUE VALUES (27, 'Mason', 'Gonzalez', 1, '1992-05-21');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) OVERRIDING SYSTEM VALUE VALUES (28, 'Ava', 'Nelson', 1, '1987-12-30');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) OVERRIDING SYSTEM VALUE VALUES (29, 'Alexander', 'Carter', 2, '1994-01-19');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) OVERRIDING SYSTEM VALUE VALUES (30, 'Isabella', 'Mitchell', 2, '1989-06-09');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) OVERRIDING SYSTEM VALUE VALUES (31, 'Evelyn', 'Perez', 3, '1977-03-12');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) OVERRIDING SYSTEM VALUE VALUES (32, 'Harper', 'Roberts', 3, '1995-09-25');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) OVERRIDING SYSTEM VALUE VALUES (33, 'Logan', 'Turner', 4, '1988-08-30');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) OVERRIDING SYSTEM VALUE VALUES (34, 'Abigail', 'Phillips', 4, '1981-10-15');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) OVERRIDING SYSTEM VALUE VALUES (35, 'Scarlett', 'Campbell', 5, '1990-11-03');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) OVERRIDING SYSTEM VALUE VALUES (36, 'Sebastian', 'Parker', 5, '1984-12-01');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) OVERRIDING SYSTEM VALUE VALUES (37, 'Lily', 'Evans', 6, '1986-02-06');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) OVERRIDING SYSTEM VALUE VALUES (38, 'Jack', 'Edwards', 7, '1979-04-21');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) OVERRIDING SYSTEM VALUE VALUES (39, 'Victoria', 'Collins', 7, '1983-07-28');
INSERT INTO public.guests (id, first_name, last_name, booker, date_of_birth) OVERRIDING SYSTEM VALUE VALUES (40, 'Henry', 'Stewart', 8, '1991-11-17');


--
-- Data for Name: ratings; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.ratings (accommodation, "user", rating, comments, id) OVERRIDING SYSTEM VALUE VALUES (3, 1, 4, ' Amazing experience! Highly recommend.', 1);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) OVERRIDING SYSTEM VALUE VALUES (4, 2, 3, ' Decent stay', 2);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) OVERRIDING SYSTEM VALUE VALUES (5, 3, 3, 'Perfect for families', 3);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) OVERRIDING SYSTEM VALUE VALUES (5, 4, 3, 'Too expensive for what it offers', 4);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) OVERRIDING SYSTEM VALUE VALUES (4, 5, 1, 'Would not stay here again.', 5);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) OVERRIDING SYSTEM VALUE VALUES (2, 6, 2, 'Good location but noisy.', 6);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) OVERRIDING SYSTEM VALUE VALUES (1, 7, 4, 'Friendly staff and great amenities.', 7);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) OVERRIDING SYSTEM VALUE VALUES (2, 8, 5, 'Excellent service and food!', 8);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) OVERRIDING SYSTEM VALUE VALUES (1, 1, 5, 'Fantastic place! Truly a gem.', 49);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) OVERRIDING SYSTEM VALUE VALUES (1, 2, 4, 'Very clean and organized.', 50);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) OVERRIDING SYSTEM VALUE VALUES (1, 3, 5, 'Best experience ever! Highly recommend.', 51);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) OVERRIDING SYSTEM VALUE VALUES (1, 4, 4, 'Great stay, but the Wi-Fi was a bit slow.', 52);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) OVERRIDING SYSTEM VALUE VALUES (2, 5, 3, 'Good for the price. Could be cleaner.', 53);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) OVERRIDING SYSTEM VALUE VALUES (2, 6, 4, 'Nice and quiet. Would visit again.', 54);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) OVERRIDING SYSTEM VALUE VALUES (2, 7, 2, 'Not great. Room was a bit musty.', 55);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) OVERRIDING SYSTEM VALUE VALUES (2, 8, 5, 'Amazing service and comfy beds!', 56);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) OVERRIDING SYSTEM VALUE VALUES (3, 9, 5, 'Loved it! Perfect for families.', 57);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) OVERRIDING SYSTEM VALUE VALUES (3, 10, 4, 'Great location. Pool was awesome.', 58);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) OVERRIDING SYSTEM VALUE VALUES (3, 11, 5, 'Everything was perfect, will return.', 59);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) OVERRIDING SYSTEM VALUE VALUES (3, 12, 3, 'Okay, but a bit pricey.', 60);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) OVERRIDING SYSTEM VALUE VALUES (7, 4, 2, 'Too expensive for the quality.', 76);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) OVERRIDING SYSTEM VALUE VALUES (6, 10, 4, 'Really good experience, will come back.', 70);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) OVERRIDING SYSTEM VALUE VALUES (10, 3, 3, 'Decent stay but overpriced for the value.', 87);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) OVERRIDING SYSTEM VALUE VALUES (7, 1, 5, 'Perfect getaway spot!', 73);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) OVERRIDING SYSTEM VALUE VALUES (9, 9, 5, 'Absolutely loved the stay! Exceptional staff.', 81);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) OVERRIDING SYSTEM VALUE VALUES (4, 4, 2, 'Noisy and cramped rooms.', 64);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) OVERRIDING SYSTEM VALUE VALUES (6, 11, 3, 'Okay, but room for improvement.', 71);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) OVERRIDING SYSTEM VALUE VALUES (9, 10, 4, 'Great hotel with a fantastic atmosphere.', 82);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) OVERRIDING SYSTEM VALUE VALUES (4, 3, 4, 'Comfortable beds and helpful staff.', 63);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) OVERRIDING SYSTEM VALUE VALUES (7, 3, 3, 'Good, but not exceptional.', 75);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) OVERRIDING SYSTEM VALUE VALUES (10, 4, 2, 'Service was slow, but location was good.', 88);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) OVERRIDING SYSTEM VALUE VALUES (8, 6, 4, 'Loved it here, will return.', 78);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) OVERRIDING SYSTEM VALUE VALUES (5, 5, 4, 'Decent stay, good location.', 65);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) OVERRIDING SYSTEM VALUE VALUES (5, 7, 3, 'Nice place but overpriced.', 67);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) OVERRIDING SYSTEM VALUE VALUES (5, 8, 4, 'Good experience overall.', 68);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) OVERRIDING SYSTEM VALUE VALUES (4, 2, 3, 'Average at best.', 62);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) OVERRIDING SYSTEM VALUE VALUES (6, 12, 2, 'Not impressed. Poor service.', 72);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) OVERRIDING SYSTEM VALUE VALUES (10, 1, 5, 'Outstanding experience! Will visit again.', 85);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) OVERRIDING SYSTEM VALUE VALUES (9, 11, 3, 'Good for the price, but room quality could improve.', 83);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) OVERRIDING SYSTEM VALUE VALUES (5, 6, 5, 'Amazing service and clean rooms!', 66);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) OVERRIDING SYSTEM VALUE VALUES (8, 5, 5, 'Amazing views and great service!', 77);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) OVERRIDING SYSTEM VALUE VALUES (8, 7, 3, 'Average, but location was good.', 79);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) OVERRIDING SYSTEM VALUE VALUES (10, 2, 4, 'Very good service and clean facilities.', 86);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) OVERRIDING SYSTEM VALUE VALUES (7, 2, 4, 'Very enjoyable stay.', 74);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) OVERRIDING SYSTEM VALUE VALUES (6, 9, 5, 'Fantastic! Couldn’t ask for better.', 69);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) OVERRIDING SYSTEM VALUE VALUES (8, 8, 5, 'Exceptional stay, highly recommend!', 80);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) OVERRIDING SYSTEM VALUE VALUES (9, 12, 2, 'Room was clean but lacked amenities.', 84);
INSERT INTO public.ratings (accommodation, "user", rating, comments, id) OVERRIDING SYSTEM VALUE VALUES (4, 1, 1, 'Terrible experience. Would not recommend.', 61);


--
-- Name: accommodation_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.accommodation_id_seq', 10, true);


--
-- Name: account_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.account_id_seq', 12, true);


--
-- Name: adresses_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.adresses_id_seq', 22, true);


--
-- Name: bookings_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.bookings_id_seq', 60, true);


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

SELECT pg_catalog.setval('public.ratings_id_seq', 88, true);


--
-- Name: rooms_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.rooms_id_seq', 50, true);


--
-- PostgreSQL database dump complete
--

