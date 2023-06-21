CREATE TABLE public.enum_normative_document_translate
(
    id integer NOT NULL,
    owner_id integer NOT NULL,
    language_id integer NOT NULL,
    column_name varchar(30),
    translate_text varchar(300),
    CONSTRAINT pk_enum_normative_document_translate PRIMARY KEY (id),
    CONSTRAINT fk_enum_normative_document_translate_enum_language_language_id FOREIGN KEY (language_id)
        REFERENCES public.enum_language (id),
    CONSTRAINT fk_enum_normative_document_translate_enum_normative_document_o FOREIGN KEY (owner_id)
        REFERENCES public.enum_normative_document (id)
)

