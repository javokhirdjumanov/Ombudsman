CREATE TABLE public.doc_information_letter
(
    id serial primary key,
    information_letter_number integer NOT NULL,
    information_letter_date timestamp with time zone NOT NULL,
    visa_holder varchar(100) NOT NULL,
    information_letter_text varchar(100) NOT NULL,
    state_program_id integer NOT NULL,
    employee_id integer NOT NULL,
    responsible_employee varchar(100) NOT NULL,
    phone_number varchar(100) NOT NULL,
    CONSTRAINT pk_doc_information_letter PRIMARY KEY (id),
    CONSTRAINT fk_doc_information_letter_hl_user_employee_id FOREIGN KEY (employee_id)
        REFERENCES public.hl_user (id),
    CONSTRAINT fk_doc_information_letter_info_state_program_state_program_id FOREIGN KEY (state_program_id)
        REFERENCES public.info_state_program (id)
)