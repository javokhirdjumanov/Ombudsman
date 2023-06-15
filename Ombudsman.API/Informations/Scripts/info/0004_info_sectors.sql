CREATE TABLE IF NOT EXISTS public.info_sectors
(
    id SERIAL PRIMARY KEY,
    sector_number varchar(3) NOT NULL,
    status_id integer NOT NULL,
    order_number integer NOT NULL,
    short_name VARCHAR(30),
    full_name  VARCHAR(100),
    CONSTRAINT fk_info_sectors_status_id FOREIGN KEY (status_id) REFERENCES public.enum_status (id)
)