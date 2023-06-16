CREATE TABLE  public.enum_initiative_type_translate
(
    id integer NOT NULL,
    owner_id integer NOT NULL,
    language_id integer NOT NULL,
    column_name varchar(30),
    translate_text varchar(300),
    CONSTRAINT pk_enum_initiative_type_translate PRIMARY KEY (id),
    CONSTRAINT fk_enum_initiative_type_translate_enum_initiative_type_owner_id FOREIGN KEY (owner_id)
        REFERENCES public.enum_initiative_type (id),
    CONSTRAINT fk_enum_initiative_type_translate_enum_language_language_id FOREIGN KEY (language_id)
        REFERENCES public.enum_language (id)
)
INSERT INTO enum_initiative_type_translate
VALUES
  --- RUSCHA
  (1, 1, 1, 'names', 'министерство'),
  (2, 2, 1, 'names', 'Сотрудник'),
  (3, 3, 1, 'names', 'Официально включен'),
	--- ENGLAND
  (4, 1, 2, 'names', 'Ministry'),
  (5, 2, 2, 'names', 'Employee'),
  (6, 3, 2, 'names', 'Officially included'),
	--- UZBEK
  (7, 1, 3, 'names', 'Vazirlik'),
  (8, 2, 3, 'names', 'Xodim'),
  (9, 3, 3, 'names', 'Rasman Kiritilgan');