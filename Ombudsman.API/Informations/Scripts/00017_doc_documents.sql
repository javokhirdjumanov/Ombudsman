CREATE TABLE public.doc_documents
(
    id SERIAL primary key,
    order_number integer NOT NULL,
    normative_document_id integer NOT NULL,
    document_importance_id integer NOT NULL,
    state_program_included boolean NOT NULL,
    state_program_id integer,
    document_name varchar(100),
    document_content varchar(100),
    create_at timestamp without time zone NOT NULL,
    send_document_data timestamp without time zone,
    estimated_execution_time timestamp without time zone,
    sector_id integer,
    main_ministry varchar(100),
    orginization_user_id integer NOT NULL,
    initiative_type_id integer NOT NULL,
    performers varchar(100) NOT NULL,
    organization_id integer NOT NULL,
    document_status_id integer NOT NULL,
    normative_doc_number integer,
    normative_doc_date timestamp without time zone,
    file_id integer,
    CONSTRAINT pk_doc_documents PRIMARY KEY (id),
    CONSTRAINT fk_doc_documents_doc_file_model_file_id FOREIGN KEY (file_id)
        REFERENCES public.doc_file_model (id),
    CONSTRAINT fk_doc_documents_enum_document_status_document_status_id FOREIGN KEY (document_status_id)
        REFERENCES public.enum_document_status (id),
    CONSTRAINT fk_doc_documents_enum_initiative_type_initiative_type_id FOREIGN KEY (initiative_type_id)
        REFERENCES public.enum_initiative_type (id) ,
    CONSTRAINT fk_doc_documents_enum_normative_document_normative_document_id FOREIGN KEY (normative_document_id)
        REFERENCES public.enum_normative_document (id),
    CONSTRAINT fk_doc_documents_hl_user_orginization_user_id FOREIGN KEY (orginization_user_id)
        REFERENCES public.hl_user (id),
    CONSTRAINT fk_doc_documents_info_document_importance_document_importance_ FOREIGN KEY (document_importance_id)
        REFERENCES public.info_document_importance (id),
    CONSTRAINT fk_doc_documents_info_organization_organization_id FOREIGN KEY (organization_id)
        REFERENCES public.info_organization (id),
    CONSTRAINT fk_doc_documents_info_sectors_sector_id FOREIGN KEY (sector_id)
        REFERENCES public.info_sectors (id),
    CONSTRAINT fk_doc_documents_info_state_program_state_program_id FOREIGN KEY (state_program_id)
        REFERENCES public.info_state_program (id)
)