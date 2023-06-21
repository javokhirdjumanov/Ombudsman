CREATE TABLE public.enum_normative_document
(
    id integer NOT NULL,
    short_character varchar(10),
    state_id integer NOT NULL,
    order_number integer NOT NULL,
    short_name  varchar(30),
    full_name  varchar(100),
    CONSTRAINT pk_enum_normative_document PRIMARY KEY (id),
    CONSTRAINT fk_enum_normative_document_enum_state_state_id FOREIGN KEY (state_id)
        REFERENCES public.enum_state (id)
)