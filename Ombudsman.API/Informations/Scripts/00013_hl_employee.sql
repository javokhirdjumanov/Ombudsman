CREATE TABLE public.hl_employee
(
     id  SERIAL PRIMARY KEY,
    fio varchar(100) NOT NULL,
    phone_number varchar(100) NOT NULL,
    salary double precision NOT NULL,
    email varchar(100) NOT NULL,
    organization_id integer NOT NULL,
    CONSTRAINT pk_hl_employee PRIMARY KEY (id),
    CONSTRAINT fk_hl_employee_info_organization_organization_id FOREIGN KEY (organization_id)
        REFERENCES public.info_organization (id)
)