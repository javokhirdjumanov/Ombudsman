CREATE TABLE public.enum_document_status
(
    id integer NOT NULL,
    status_id integer NOT NULL,
    order_number integer NOT NULL,
    short_name varchar(30),
    full_name varchar(100),
    CONSTRAINT pk_enum_document_status PRIMARY KEY (id),
    CONSTRAINT fk_enum_document_status_enum_state_status_id FOREIGN KEY (status_id)
        REFERENCES public.enum_state (id)
)




