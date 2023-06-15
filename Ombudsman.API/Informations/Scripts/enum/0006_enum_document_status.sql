CREATE TABLE enum_document_status(
    id SERIAL PRIMARY KEY,
    order_number VARCHAR(3) NOT NULL,
    short_name VARCHAR(30) NOT NULL,
    full_name VARCHAR(100) NOT NULL,
    status_id INT NOT NULL,

    CONSTRAINT fk_status_id FOREIGN KEY (status_id) REFERENCES enum_status(id));

INSERT INTO enum_document_status
VALUES 
    ('001', 'Лойиҳаланган', 'Лойиҳаланган', 1),
    ('002', 'Киритилган', 'Киритилган', 1),
    ('003', 'Рад етилган', 'Рад етилган', 1),
    ('004', 'Тасдиқланган', 'Тасдиқланган', 1),
    ('005', 'Кучга кирган', 'Кучга кирган', 1); 