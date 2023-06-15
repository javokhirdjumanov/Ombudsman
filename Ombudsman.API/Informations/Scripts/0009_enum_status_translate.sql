CREATE TABLE enum_status_translate
(
    id SERIAL PRIMARY KEY,
    status_id integer NOT NULL,
    language_id integer NOT NULL,
    column_name varchar(100),
    translate_text varchar(300),
    CONSTRAINT fk_enum_status_translate_language_id FOREIGN KEY (language_id)
        REFERENCES public.enum_language (id),
    CONSTRAINT fk_enum_status_translate_status_id FOREIGN KEY (status_id)
        REFERENCES public.enum_status (id)
)