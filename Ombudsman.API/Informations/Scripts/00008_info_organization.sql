CREATE TABLE public.info_organization
(
	id SERIAL PRIMARY KEY,    
	state_organization_ids integer NOT NULL,
    is_grouper boolean NOT NULL,
    organization_id integer,
    state_id integer NOT NULL,
    order_number integer NOT NULL,
    short_name varchar(30),
    full_name varchar(100),
    CONSTRAINT fk_info_organization_enum_state_organization_state_organizatio FOREIGN KEY (state_organization_ids)
        REFERENCES public.enum_state_organization (id),
    CONSTRAINT fk_info_organization_enum_state_state_id FOREIGN KEY (state_id)
        REFERENCES public.enum_state (id),
    CONSTRAINT fk_info_organization_info_organization_organization_id FOREIGN KEY (organization_id)
        REFERENCES public.info_organization (id)
)
INSERT INTO public.info_organization
VALUES
    (1, 3, false, NULL, 1, 1, 'Президент Aдминистрацияси', 'Президент Aдминистрацияси'),
    (2, 1,  true, NULL, 1, 2, 'Стратегик ислоҳотлар агентлиги', 'Стратегик ислоҳотлар агентлиги'),
    (3, 1, false, NULL, 1, 3, 'Транспорт вазирлиги', 'Транспорт вазирлиги'),
	(4, 1, false, NULL, 1, 4, 'Иқтисодиёт ва молия вазирлиги', 'Иқтисодиёт ва молия вазирлиги'),
    (5, 6, false, NULL, 1, 5, 'Солиқ қўмитаси', 'Солиқ қўмитаси'),
    (6, 7, false, NULL, 1, 6, 'Ёшлар сиёсати ва спорт вазирлиги', 'Ёшлар сиёсати ва спорт вазирлиги');
