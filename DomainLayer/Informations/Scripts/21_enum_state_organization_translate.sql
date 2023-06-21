CREATE TABLE public.enum_state_organization_translate
(
    id integer NOT NULL,
    owner_id integer NOT NULL,
    language_id integer NOT NULL,
    column_name text COLLATE pg_catalog."default" NOT NULL,
    translate_text text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT pk_enum_state_organization_translate PRIMARY KEY (id),
    CONSTRAINT fk_enum_state_organization_translate_enum_language_language_id FOREIGN KEY (language_id)
        REFERENCES public.enum_language (id),
    CONSTRAINT fk_enum_state_organization_translate_enum_state_organization_o FOREIGN KEY (owner_id)
        REFERENCES public.enum_state_organization (id)
)
