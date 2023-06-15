CREATE TABLE enum_normative_document_translate
(
    id SERIAL PRIMARY KEY,,
    normative_document_type_id integer NOT NULL,
    language_id integer NOT NULL,
    column_name varchar(100),
    translate_text varchar(300),
    CONSTRAINT fk_enum_normative_document_translate_enum_language_language_id FOREIGN KEY (language_id)
        REFERENCES public.enum_language (id),
    CONSTRAINT fk_enum_normative_document_translate_enum_normative_document_n FOREIGN KEY (normative_document_type_id)
        REFERENCES public.enum_normative_document (id)
)