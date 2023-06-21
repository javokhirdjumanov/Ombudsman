CREATE TABLE  public.enum_initiative_type_translate
(
    id integer NOT NULL,
    owner_id integer NOT NULL,
    language_id integer NOT NULL,
    column_name varchar(30),
    translate_text varchar(300),
    CONSTRAINT pk_enum_initiative_type_translate PRIMARY KEY (id),
    CONSTRAINT fk_enum_initiative_type_translate_enum_initiative_type_owner_id FOREIGN KEY (owner_id)
        REFERENCES public.enum_initiative_type (id),
    CONSTRAINT fk_enum_initiative_type_translate_enum_language_language_id FOREIGN KEY (language_id)
        REFERENCES public.enum_language (id)
)