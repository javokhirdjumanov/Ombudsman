CREATE TABLE public.info_sectors
(
    id SERIAL PRIMARY KEY,
    sector_number integer NOT NULL,
    state_id integer NOT NULL,
    order_number integer NOT NULL,
    short_name VARCHAR(30),
    full_name VARCHAR(100),
    CONSTRAINT fk_info_sectors_enum_state_state_id FOREIGN KEY (state_id)
        REFERENCES public.enum_state (id)
)
