CREATE TABLE enum_initiative_type_translate
(
    id SERIAL PRIMARY KEY,,
    initiative_type_id integer NOT NULL,
    language_id integer NOT NULL,
    column_name varchar(100),
    translate_text varchar(300),
    CONSTRAINT fk_enum_initiative_type_translate_enum_initiative_type_initiat FOREIGN KEY (initiative_type_id)
        REFERENCES public.enum_initiative_type (id),
    CONSTRAINT fk_enum_initiative_type_translate_enum_language_language_id FOREIGN KEY (language_id)
        REFERENCES public.enum_language (id)
)
