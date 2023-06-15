CREATE TABLE info_organization(
    id SERIAL PRIMARY KEY,
    order_number VARCHAR(3) NOT NULL,
    state_organization_id INT NOT NULL,
    is_grouped BOOLEAN NOT NULL DEFAULT FALSE,
    organization_id INT DEFAULT NULL,
    short_name VARCHAR(30) NOT NULL,
    full_name VARCHAR(100) NOT NULL,
    status_id INT NOT NULL,

    CONSTRAINT fk_info_organization_state_organization_state_organizatio FOREIGN KEY (state_organization_id)
        REFERENCES public.enum_state_organization (id),
    CONSTRAINT fk_info_organization_status_status_id FOREIGN KEY (status_id)
        REFERENCES public.enum_status (id),
    CONSTRAINT fk_info_organization_organization_organization_id FOREIGN KEY (organization_id)
        REFERENCES public.info_organization (id)
);

INSERT INTO info_organization
VALUES
    ('001', 1, FALSE, NULL, 'Президент Aдминистрацияси', 'Президент Aдминистрацияси', 1),
    ('002', 1, FALSE, NULL, 'Стратегик ислоҳотлар агентлиги', 'Стратегик ислоҳотлар агентлиги', 1),
    ('003', 1, FALSE, NULL, 'Транспорт вазирлиги', 'Транспорт вазирлиги', 1),
    ('004', 1, FALSE, NULL, 'Иқтисодиёт ва молия вазирлиги', 'Иқтисодиёт ва молия вазирлиги', 1),
    ('005', 1, FALSE, NULL, 'Солиқ қўмитаси', 'Солиқ қўмитаси', 1),
    ('006', 1, FALSE, NULL, 'Ёшлар сиёсати ва спорт вазирлиги', 'Ёшлар сиёсати ва спорт вазирлиги', 1),
    ('007', 1, FALSE, NULL, 'Ёшлар ишлари агентлиги', 'Ёшлар ишлари агентлиги', 1),
    ('008', 1, FALSE, NULL, 'Давлат хафсизлиги хизмати', 'Давлат хафсизлиги хизмати', 1),
    ('009', 1, FALSE, NULL, 'Ўзбекистон банклар уйишмаси', 'Ўзбекистон банклар уйишмаси', 1);