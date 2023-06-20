CREATE TABLE public.info_state_program
(
    id serial primary key,
    state_id integer NOT NULL,
    order_number integer NOT NULL,
    short_name varchar(100) ,
    full_name varchar(100),
    CONSTRAINT pk_info_state_program PRIMARY KEY (id),
    CONSTRAINT fk_info_state_program_enum_state_state_id FOREIGN KEY (state_id)
        REFERENCES public.enum_state (id)
)
INSERT INTO public.info_state_program
VALUES
    (1, 1, 1, 'Давлат дастури 2022', 'Давлат дастури 2022'),
    (2, 1, 2, 'Давлат дастури 2023', 'Давлат дастури 2023');
