CREATE TABLE doc_visa_holders
(
    id SERIAL PRIMARY KEY,
    document_id integer NOT NULL,
    order_number integer NOT NULL,
    information_letter_id integer,
    organization_id integer NOT NULL,
    fio varchar(300),
    pposition varchar(50),
    responsible_employee varchar(50),
    phone_number varchar(100),,
    create_at timestamp with time zone NOT NULL,
    date_visa_addition timestamp with time zone NOT NULL,
    CONSTRAINT fk_doc_visa_holders_for_doc_doc_documents_document_id FOREIGN KEY (document_id)
        REFERENCES public.doc_documents (id),
    CONSTRAINT fk_doc_visa_holders_for_doc_doc_information_letter_information FOREIGN KEY (information_letter_id)
        REFERENCES public.doc_information_letter (id),
    CONSTRAINT fk_doc_visa_holders_for_doc_info_organization_organization_id FOREIGN KEY (organization_id)
        REFERENCES public.info_organization (id),
)