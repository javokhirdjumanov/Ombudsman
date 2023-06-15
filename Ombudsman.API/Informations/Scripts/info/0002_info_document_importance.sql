CREATE TABLE info_document_importance(
    id SERIAL PRIMARY KEY,
    order_number VARCHAR(3) NOT NULL,
    short_name VARCHAR(30) NOT NULL,
    full_name VARCHAR(100) NOT NULL,
    status_id INT NOT NULL,
    CONSTRAINT fk_status_id FOREIGN KEY (status_id) REFERENCES enum_status(id)
);