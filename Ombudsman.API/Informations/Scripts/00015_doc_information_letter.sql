CREATE TABLE public.doc_information_letter
(
    id SERIAL primary key,
    information_letter_number integer NOT NULL,
    information_letter_date timestamp without time zone NOT NULL,
    visa_holder varchar(100) NOT NULL,
    information_letter_text varchar(100) NOT NULL,
    state_program_id integer NOT NULL,
    employee_id integer NOT NULL,
    responsible_employee varchar(100) NOT NULL,
    phone_number varchar(100) NOT NULL,
    document_id integer NOT NULL DEFAULT 0,
    CONSTRAINT pk_doc_information_letter PRIMARY KEY (id),
    CONSTRAINT fk_doc_information_letter_doc_documents_document_id FOREIGN KEY (document_id)
        REFERENCES public.doc_documents (id),
    CONSTRAINT fk_doc_information_letter_hl_employee_employee_id FOREIGN KEY (employee_id)
        REFERENCES public.hl_employee (id),
    CONSTRAINT fk_doc_information_letter_info_state_program_state_program_id FOREIGN KEY (state_program_id)
        REFERENCES public.info_state_program (id)
)