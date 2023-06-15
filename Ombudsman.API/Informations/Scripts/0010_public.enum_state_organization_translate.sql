CREATE TABLE enum_state_organization_translate
(
    id SERIAL PRIMARY KEY,
    state_organization_id integer NOT NULL,
    language_id integer NOT NULL,
    column_name varchar(100),
    translate_text varchar(300),
    CONSTRAINT fk_enum_state_organization_translate_enum_language_language_id FOREIGN KEY (language_id)
        REFERENCES public.enum_language (id),
    CONSTRAINT fk_enum_state_organization_translate_enum_state_organization_s FOREIGN KEY (state_organization_id)
        REFERENCES public.enum_state_organization (id)
)