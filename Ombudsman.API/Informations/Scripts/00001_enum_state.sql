CREATE TABLE public.enum_state
(
    id integer NOT NULL,
    name varchar(30),
    CONSTRAINT pk_enum_state PRIMARY KEY (id)
)

INSERT INTO public."enum_state"
VALUES 
    (1, 'Активный'),(2, 'Пассивный');