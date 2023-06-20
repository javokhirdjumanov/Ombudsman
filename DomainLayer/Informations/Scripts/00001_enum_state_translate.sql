CREATE TABLE public.enum_state_translate
(
    id integer NOT NULL,
    owner_id integer NOT NULL,
    language_id integer NOT NULL,
    column_name varchar(30),
    translate_text varchar(100),
    CONSTRAINT pk_enum_state_translate PRIMARY KEY (id),
    CONSTRAINT fk_enum_state_translate_enum_language_language_id FOREIGN KEY (language_id)
        REFERENCES public.enum_language (id),
    CONSTRAINT fk_enum_state_translate_enum_state_owner_id FOREIGN KEY (owner_id)
        REFERENCES public.enum_state (id)
)
INSERT INTO public."enum_state_translate"
VALUES
  	(1, 1, 1, 'name', 'Активный'),
	(2, 1, 2, 'name', 'Active'),
	(3, 1, 3, 'name', 'Faol'),
    (4, 2, 1, 'name', 'Пассивный'),
	(5, 2, 2, 'name', 'Passive'),
	(6, 2, 3, 'name', 'Nofoal');
  	