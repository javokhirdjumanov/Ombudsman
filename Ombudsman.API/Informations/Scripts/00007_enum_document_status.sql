CREATE TABLE public.enum_document_status
(
    id integer NOT NULL,
    status_id integer NOT NULL,
    order_number integer NOT NULL,
    short_name varchar(30),
    full_name varchar(100),
    CONSTRAINT pk_enum_document_status PRIMARY KEY (id),
    CONSTRAINT fk_enum_document_status_enum_state_status_id FOREIGN KEY (status_id)
        REFERENCES public.enum_state (id)
)

INSERT INTO public.enum_document_status
VALUES
    (1, 1, 1, 'Лойиҳаланган', 'Лойиҳаланган'),
    (2, 1, 2, 'Киритилган', 'Киритилган'),
    (3, 1, 3, 'Рад етилган', 'Рад етилган'),
	(4, 1, 4, 'Тасдиқланган', 'Тасдиқланган'),
    (5, 1, 5, 'Кучга кирган', 'Кучга кирган');



