CREATE TABLE doc_information_letter
(
    id SERIAL PRIMARY KEY,
    information_letter_number integer NOT NULL,
    information_letter_date timestamp with time zone NOT NULL,
    information_letter_text varchar(300),
    state_program_id integer NOT NULL,
    visa_holder varchar(50),
    responsible_employee varchar(300),
    phone_number varchar(50),
    employee_id integer NOT NULL DEFAULT 0,
    CONSTRAINT fk_doc_information_letter_hl_user_employee_id FOREIGN KEY (employee_id)
        REFERENCES public.hl_user (id),
    CONSTRAINT fk_doc_information_letter_info_state_program_state_program_id FOREIGN KEY (state_program_id)
        REFERENCES public.info_state_program (id)
)