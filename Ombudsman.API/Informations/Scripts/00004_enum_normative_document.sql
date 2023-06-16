CREATE TABLE public.enum_normative_document
(
    id integer NOT NULL,
    short_character varchar(10),
    state_id integer NOT NULL,
    order_number integer NOT NULL,
    short_name  varchar(30),
    full_name  varchar(100),
    CONSTRAINT pk_enum_normative_document PRIMARY KEY (id),
    CONSTRAINT fk_enum_normative_document_enum_state_state_id FOREIGN KEY (state_id)
        REFERENCES public.enum_state (id)
)
INSERT INTO public."enum_normative_document"
VALUES
    (1, 'ҚЛ', 1, 1, 'Қонун лойиҳаси', 'Қонун лойиҳаси'),
	(2, 'ПФ', 1, 2, 'Президент фармони', 'Президент фармони'),
	(3, 'ПҚ', 1, 3, 'Президент Қарори', 'Президент Қарори'),
	(4, 'ПФр', 1, 4, 'Президент Фармойиши', 'Президент Фармойиши'),
	(5, 'ВМҚ', 1, 5, 'Вазирлар маҳкамаси қарори', 'Вазирлар маҳкамаси қарори'),
	(6, 'ДЗ', 1, 6, 'Докладная записка', 'Докладная записка');