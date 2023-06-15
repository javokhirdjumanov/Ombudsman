CREATE TABLE info_state_program(
    id SERIAL PRIMARY KEY, 
    serial_number VARCHAR(3) NOT NULL,
    short_name VARCHAR(30) NOT NULL,
    full_name VARCHAR(100) NOT NULL,
    status_id INT NOT NULL,
    CONSTRAINT fk_status_id FOREIGN KEY (status_id) REFERENCES enum_status(id)
);

INSERT INTO
VALUES
    ('001', 'Давлат дастури 2022', 'Давлат дастури 2022', 1),
    ('002', 'Давлат дастури 2023', 'Давлат дастури 2023', 1);