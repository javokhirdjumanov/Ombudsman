CREATE TABLE public.doc_file_model
(
    id SERIAL PRIMARY KEY,
    type varchar(10),
    file_name varchar(100)
)
INSERT INTO doc_file_model
VALUES (1,'PDF', 'example.pdf'),
       (2,'DOCX', 'document.docx'),
       (3,'XLSX', 'spreadsheet.xlsx');