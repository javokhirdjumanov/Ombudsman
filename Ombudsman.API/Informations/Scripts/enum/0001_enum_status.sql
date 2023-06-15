CREATE TABLE enum_status(
	id SERIAL PRIMARY KEY,
    name VARCHAR(30) NOT NULL
);

INSERT INTO enum_status
VALUES 
    (1, 'Aктив'),
    (2, 'Пассив');