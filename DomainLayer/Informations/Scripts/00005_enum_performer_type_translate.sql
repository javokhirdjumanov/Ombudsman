CREATE TABLE IF NOT EXISTS public.enum_performer_type_translate
(
    id integer NOT NULL,
    owner_id integer NOT NULL,
    language_id integer NOT NULL,
    column_name varchar(30),
    translate_text varchar(300),
    CONSTRAINT pk_enum_performer_type_translate PRIMARY KEY (id),
    CONSTRAINT fk_enum_performer_type_translate_enum_language_language_id FOREIGN KEY (language_id)
        REFERENCES public.enum_language (id),
    CONSTRAINT fk_enum_performer_type_translate_enum_performer_type_owner_id FOREIGN KEY (owner_id)
        REFERENCES public.enum_performer_type (id)
)
select * from public."enum_performer_type_translate"
INSERT INTO public."enum_performer_type_translate"
VALUES
	-- RUSCHA
	(1, 1, 1, 'full_name',  'Модератор'),
	(2, 2, 1, 'full_name',  'Главный исполнитель'),
	(3, 3, 1, 'full_name',  'Иммигрант'),
	-- ENGLAND
	(4, 1, 2, 'full_name',  'Moderator'),
	(5, 2, 2, 'full_name',  'Main Performer'),
	(6, 3, 2, 'full_name',  'An immigrant'),
	-- UZBEK
	(7, 1, 3, 'full_name',  'Modetator'),
	(8, 2, 3, 'full_name',  'Asosiy Ijrochi'),
	(9, 3, 3, 'full_name',  'Immigrant');