CREATE TABLE public.enum_state_organization
(
    id integer NOT NULL,
    state_id integer NOT NULL,
    order_number integer NOT NULL,
    short_name varchar(30),
    full_name varchar(100),
    CONSTRAINT pk_enum_state_organization PRIMARY KEY (id),
    CONSTRAINT fk_enum_state_organization_enum_state_state_id FOREIGN KEY (state_id)
        REFERENCES public.enum_state (id)
)