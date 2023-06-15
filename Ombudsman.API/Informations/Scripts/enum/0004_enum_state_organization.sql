CREATE TABLE enum_state_organization(
    id SERIAL PRIMARY KEY,
    serial_number VARCHAR(3) NOT NULL,
    short_name VARCHAR(30) NOT NULL,
    full_name VARCHAR(100) NOT NULL,
    status_id INT NOT NULL,
    CONSTRAINT fk_status_id FOREIGN KEY (status_id) REFERENCES enum_status(id)
);

INSERT INTO enum_state_organization
VALUES 
    ('001', 'Вазирлик', 'Вазирлик', 1),
    ('002', 'Aлоҳида мақомга ега мустақил орган', 'Aлоҳида мақомга ега мустақил республика ижро етувчи ҳокимият органи', 1),
    ('003', 'Президент ва Aдминистрация ҳузуридаги ташкилот', 'Президент ва Aдминистрация ҳузуридаги ташкилот', 1),
    ('004', 'Тижорат банклар, жамғармалар ва бошқалар', 'Тижорат банклар, жамғармалар ва бошқа', 1),
    ('005', 'Суд идоралари', 'Суд идоралари', 1),
    ('006', 'Ҳарбийлаштирилган тузилмалар', 'Ҳарбийлаштирилган тузилма', '1'),
    ('007', 'Ҳўжалик бирлашмалар ҳамда уюшмалар', 'Ҳўжалик бирлашмалар ҳамда уюшма', 1);