CREATE TABLE public.enum_document_status_translate
(
    id integer NOT NULL,
    owner_id integer NOT NULL,
    language_id integer NOT NULL,
    column_name varchar(30),
    translate_text varchar(100),
    CONSTRAINT pk_enum_document_status_translate PRIMARY KEY (id),
    CONSTRAINT fk_enum_document_status_translate_enum_document_status_owner_id FOREIGN KEY (owner_id)
        REFERENCES public.enum_document_status (id),
    CONSTRAINT fk_enum_document_status_translate_enum_language_language_id FOREIGN KEY (language_id)
        REFERENCES public.enum_language (id)
)
INSERT INTO public.enum_document_status_translate
VALUES
	-- rus
    (1, 1, 1, 'full_name', 'Разработанный'),
    (2, 2, 1, 'full_name', 'включено'),
    (3, 3, 1, 'full_name', 'отклоненный'),
	(4, 4, 2, 'full_name', 'Подтвержденный'),
    (5, 5, 1, 'full_name', 'Вступил в силу'),
	-- eng
    (6, 1, 2, 'full_name', 'Designed'),
    (7, 2, 2, 'full_name', 'Entered'),
    (8, 3, 2, 'full_name', 'отклоненный'),
	(9, 4, 2, 'full_name', 'Подтвержденный'),
    (10, 5, 2, 'full_name', 'Вступил в силу'),
	-- uzb
    (11, 1, 3, 'full_name', 'Лойиҳаланган'),
    (12, 2, 3, 'full_name', 'Киритилган'),
    (13, 3, 3, 'full_name', 'Rejected'),
	(14, 4, 3, 'full_name', 'Confirmed'),
    (15, 5, 3, 'full_name', 'Entered into force');



UPDATE public.enum_document_status_translate
SET translate_text = 
    CASE
        -- Russian translations
        WHEN owner_id = 1 AND language_id = 1 AND column_name = 'full_name' THEN 'Разработанный'
        WHEN owner_id = 2 AND language_id = 1 AND column_name = 'full_name' THEN 'включено'
        WHEN owner_id = 3 AND language_id = 1 AND column_name = 'full_name' THEN 'отклоненный'
        WHEN owner_id = 4 AND language_id = 1 AND column_name = 'full_name' THEN 'Подтвержденный'
        WHEN owner_id = 5 AND language_id = 1 AND column_name = 'full_name' THEN 'Вступил в силу'
        
        -- English translations
        WHEN owner_id = 1 AND language_id = 2 AND column_name = 'full_name' THEN 'Designed'
        WHEN owner_id = 2 AND language_id = 2 AND column_name = 'full_name' THEN 'Entered'
        WHEN owner_id = 3 AND language_id = 2 AND column_name = 'full_name' THEN 'Rejected'
        WHEN owner_id = 4 AND language_id = 2 AND column_name = 'full_name' THEN 'Confirmed'
        WHEN owner_id = 5 AND language_id = 2 AND column_name = 'full_name' THEN 'Entered into force'
        
        -- Uzbek translations
        WHEN owner_id = 1 AND language_id = 3 AND column_name = 'full_name' THEN 'Лойиҳаланган'
        WHEN owner_id = 2 AND language_id = 3 AND column_name = 'full_name' THEN 'Киритилган'
        WHEN owner_id = 3 AND language_id = 3 AND column_name = 'full_name' THEN 'Рад етилган'
        WHEN owner_id = 4 AND language_id = 3 AND column_name = 'full_name' THEN 'Тасдиқланган'
        WHEN owner_id = 5 AND language_id = 3 AND column_name = 'full_name' THEN 'Кучга кирган'
        
        -- Add more cases for other translations if needed
        
        ELSE translate_text  -- Keep the existing value if no match
    END;