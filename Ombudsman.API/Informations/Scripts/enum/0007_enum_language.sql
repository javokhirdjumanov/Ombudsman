CREATE TABLE enum_language
(
    id SERIAL PRIMARY KEY,,
    short_name varchar(30),
    full_name varchar(100)
)
INSERT INTO enum_language
VALUES ('en', 'English'),
       ('uz', 'Uzbek'),
       ('ru', 'Russian');