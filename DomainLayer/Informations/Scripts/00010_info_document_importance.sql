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

INSERT INTO public.info_document_importance
VALUES
    (1, 1, 1, 'Nazoratda', 'Nazoratda Olingan'),
    (2, 1, 2, 'Strategik', 'Strategik ahamiyatga ega');