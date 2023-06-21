CREATE TABLE public.info_document_importance
(
    id SERIAL PRIMARY KEY,
    state_id integer NOT NULL,
    order_number integer NOT NULL,
    short_name VARCHAR(30) NOT NULL,
    full_name VARCHAR(100) NOT NULL,
    CONSTRAINT fk_info_document_importance_enum_state_state_id FOREIGN KEY (state_id)
        REFERENCES public.enum_state (id) 
)

