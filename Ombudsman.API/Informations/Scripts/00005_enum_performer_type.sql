CREATE TABLE public.enum_performer_type
(
    id integer NOT NULL,
    state_id integer NOT NULL,
    order_number integer NOT NULL,
    short_name varchar(30),
    full_name varchar(100),
    CONSTRAINT pk_enum_performer_type PRIMARY KEY (id),
    CONSTRAINT fk_enum_performer_type_enum_state_state_id FOREIGN KEY (state_id)
        REFERENCES public.enum_state (id)
)

INSERT INTO public."enum_performer_type"
VALUES
	(1, 1, 1, 'Модератор',  'Модератор'),
	(2, 1, 2, 'Aсосий ижрочи',  'Aсосий ижрочи'),
	(3, 1, 3, 'Ҳамижрочи',  'Ҳамижрочи');