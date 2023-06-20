CREATE TABLE public.enum_state_organization_translate
(
    id integer NOT NULL,
    owner_id integer NOT NULL,
    language_id integer NOT NULL,
    column_name text COLLATE pg_catalog."default" NOT NULL,
    translate_text text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT pk_enum_state_organization_translate PRIMARY KEY (id),
    CONSTRAINT fk_enum_state_organization_translate_enum_language_language_id FOREIGN KEY (language_id)
        REFERENCES public.enum_language (id),
    CONSTRAINT fk_enum_state_organization_translate_enum_state_organization_o FOREIGN KEY (owner_id)
        REFERENCES public.enum_state_organization (id)
)

INSERT INTO public.enum_state_organization_translate (id, owner_id, language_id, column_name, translate_text)
VALUES
    -- Rus
    (1, 1, 1, 'full_name', 'Министерство'),
    (2, 2, 1, 'full_name', 'Независимый орган с особым статусом'),
    (3, 3, 1, 'full_name', 'Организация при Президенте и Администрации'),
	(4, 4, 1, 'full_name', 'Коммерческие банки сберегательные и другие'),
	(5, 5, 1, 'full_name', 'Судебные кабинеты'),
	(6, 6, 1, 'full_name', 'Военные системы'),
	(7, 7, 1, 'full_name', 'Экономические ассоциации и ассоциации'),
	-- ENG
    (8, 1, 2, 'full_name', 'Ministry'),
    (9, 2, 2, 'full_name', 'Independent body with special status'),
    (10, 3, 2, 'full_name', 'Organization under the President and Administration'),
	(11, 4, 2, 'full_name', 'Commercial banks savings and others'),
	(12, 5, 2, 'full_name', 'Court Offices'),
	(13, 6, 2, 'full_name', 'Military Systems'),
	(14, 7, 2, 'full_name', 'Economic associations and associations'),
	-- UZb
    (15, 1, 3, 'full_name', 'Vazirlik'),
    (16, 2, 3, 'full_name', 'Alohida maqomga ega mustaqil organ'),
    (17, 3, 3, 'full_name', 'Prezdent va Admintratsiya xuzuridagi tashkilot'),
	(18, 4, 3, 'full_name', 'Tijorat banklar jamgarmalar va boshqalar'),
	(19, 5, 3, 'full_name', 'Sud idoralari'),
	(20, 6, 3, 'full_name', 'Xarbiylashtirish Tizimlari'),
	(21, 7, 3, 'full_name', 'Xo`jalik birlashmalar hamda uyushmalar');