CREATE TABLE public.enum_document_status_translate
(
    id integer NOT NULL,
    owner_id integer NOT NULL,
    language_id integer NOT NULL,
    column_name varchar(30),
    translate_text varchar(100),
    CONSTRAINT pk_enum_document_status_translate PRIMARY KEY (id),
    CONSTRAINT fk_enum_document_status_translate_enum_document_status_owner_id FOREIGN KEY (owner_id)
        REFERENCES public.enum_document_status (id),
    CONSTRAINT fk_enum_document_status_translate_enum_language_language_id FOREIGN KEY (language_id)
        REFERENCES public.enum_language (id)
)
