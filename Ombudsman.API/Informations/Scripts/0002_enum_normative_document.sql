CREATE TABLE enum_normative_document(
    id SERIAL PRIMARY KEY,
    order_number VARCHAR(3) NOT NULL,
    short_name VARCHAR(100) NOT NULL,
    full_name VARCHAR(500) NOT NULL,
    short_signature VARCHAR(10) NOT NULL,
    status_id INT NOT NULL,

    CONSTRAINT fk_status_id FOREIGN KEY (status_id) REFERENCES enum_status(id)
);

INSERT INTO enum_normative_document
VALUES
    (1, '001', 'Қонун лойиҳаси', 'Қонун лойиҳаси', 'ҚЛ', 1),
    (2 ,'002', 'Президент фармони', 'Президент фармони', 'ПФ', 1),
    (3, '003', 'Президент Қарори', 'Президент Қарори', 'ПҚ', 2),
    (4, '004', 'Президент Фармойиши', 'Президент Фармойиши', 'ПФр', 1),
    (5, '005', 'Вазирлар маҳкамаси қарори', 'Вазирлар маҳкамаси қарори', 'ВМҚ', 1),
    (6, '006', 'Докладная записка', 'Докладная записка', 'ДЗ', 2);