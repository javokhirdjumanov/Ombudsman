CREATE TABLE enum_performer_type_translate
(
    id SERIAL PRIMARY KEY,
    performer_type_id integer NOT NULL,
    language_id integer NOT NULL,
    column_name varchar(100),
    translate_text varchar(300),
    CONSTRAINT fk_enum_performer_type_translate_enum_language_language_id FOREIGN KEY (language_id)
        REFERENCES public.enum_language (id),
    CONSTRAINT fk_enum_performer_type_translate_enum_performer_type_performer FOREIGN KEY (performer_type_id)
        REFERENCES public.enum_performer_type (id)
)
