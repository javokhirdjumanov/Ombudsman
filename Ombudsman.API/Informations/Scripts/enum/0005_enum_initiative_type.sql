CREATE TABLE enum_initiative_type(
    id SERIAL PRIMARY KEY,
    order_number VARCHAR(3) NOT NULL,
    short_name VARCHAR(100) NOT NULL,
    full_name VARCHAR(500) NOT NULL,
    status_id INT NOT NULL,

    CONSTRAINT fk_status_id FOREIGN KEY (status_id) REFERENCES enum_status(id)
);

INSERT INTO
VALUES
    ('001', 'Вазирлик', 'Вазирлик', 1),
    ('002', 'Ходим', 'Ходим', 1));