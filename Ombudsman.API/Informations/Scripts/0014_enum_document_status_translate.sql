CREATE TABLE enum_document_status_translate
(
    id SERIAL PRIMARY KEY,
    document_status_id integer NOT NULL,
    language_id integer NOT NULL,
    column_name varchar(100),
    translate_text varchar(300),
    CONSTRAINT fk_enum_document_status_translate_enum_document_status_documen FOREIGN KEY (document_status_id)
        REFERENCES public.enum_document_status (id),
    CONSTRAINT fk_enum_document_status_translate_enum_language_language_id FOREIGN KEY (language_id)
        REFERENCES public.enum_language (id)
)