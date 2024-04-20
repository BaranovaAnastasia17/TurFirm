-- Table for Tourists
CREATE TABLE tourists (
    tourist_id SERIAL PRIMARY KEY,
    first_name TEXT,
    last_name TEXT,
    patronymic TEXT,
    
);


CREATE TABLE tourist_information (
    tourist_information_id SERIAL PRIMARY KEY,
	passport_series VARCHAR(24),
    city TEXT,
    country TEXT,
    phone_number VARCHAR(20),
    index_number VARCHAR(10)
	FOREIGN KEY (tourist_information_id) REFERENCES tourists (tourist_id)
);


CREATE TABLE tour_information (
    tour_id SERIAL PRIMARY KEY,
    name TEXT,
    price NUMERIC(10, 2),
    information TEXT
);
-- Table for Seasons
CREATE TABLE seasons (
    season_id SERIAL PRIMARY KEY,
    tour_id INTEGER REFERENCES tour_information(tour_id),
    start_date DATE,
    end_date DATE,
    is_season_open BOOLEAN,
	num_seats INTEGER
	
);

-- Table for Trips
CREATE TABLE trips (
    trip_id SERIAL PRIMARY KEY,
    season_id INTEGER REFERENCES seasons(season_id),
	tourist_id INTEGER REFERENCES tourists(tourist_id)
);

-- Table for Payments
CREATE TABLE payments (
    payment_id SERIAL PRIMARY KEY,
    trip_id INTEGER REFERENCES trips(trip_id),
    payment_date DATE,
    amount NUMERIC(10, 2)
);

INSERT INTO tourists (first_name, last_name, patronymic) VALUES
('Иван', 'Иванов', 'Иванович'),
('Петр', 'Петров', 'Петрович'),
('Светлана', 'Сидорова', 'Алексеевна');

INSERT INTO tourist_information (tourist_information_id, passport_series, city, country, phone_number, index_number) VALUES
(1, '4509 123456', 'Москва', 'Россия', '+7 900 123 45 67', '101000'),
(2, '4510 654321', 'Санкт-Петербург', 'Россия', '+7 950 765 43 21', '190000'),
(3, '4508 987654', 'Новосибирск', 'Россия', '+7 923 456 78 90', '630000');

INSERT INTO tour_information (name, price, information) VALUES
('Золотое кольцо России', 50000.00, 'Экскурсионный тур по городам Золотого кольца'),
('Путешествие по Байкалу', 75000.00, 'Тур вокруг Байкала на автомобиле'),
('Экскурсия в Санкт-Петербург', 30000.00, 'Недельная экскурсия по достопримечательностям Санкт-Петербурга');
INSERT INTO seasons (tour_id, start_date, end_date, is_season_open, num_seats) VALUES
(1, '2024-05-01', '2024-05-15', TRUE, 20),
(2, '2024-07-01', '2024-07-15', TRUE, 15),
(3, '2024-06-01', '2024-06-07', TRUE, 10);
INSERT INTO trips (season_id, tourist_id) VALUES
(1, 1),
(2, 2),
(3, 3);
INSERT INTO payments (trip_id, payment_date, amount) VALUES
(1, '2024-04-20', 50000.00),
(2, '2024-06-20', 75000.00),
(3, '2024-05-25', 30000.00);
