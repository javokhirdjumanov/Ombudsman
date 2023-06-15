CREATE TABLE doc_file_model
(
    id SERIAL PRIMARY KEY,
    type varchar(10),,
    file_name varchar(300)
)
INSERT INTO doc_file_model
VALUES ('PDF', 'example.pdf'),
       ('DOCX', 'document.docx'),
       ('XLSX', 'spreadsheet.xlsx');