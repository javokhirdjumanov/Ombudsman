CREATE TABLE public.enum_normative_document_translate
(
    id integer NOT NULL,
    owner_id integer NOT NULL,
    language_id integer NOT NULL,
    column_name varchar(30),
    translate_text varchar(300),
    CONSTRAINT pk_enum_normative_document_translate PRIMARY KEY (id),
    CONSTRAINT fk_enum_normative_document_translate_enum_language_language_id FOREIGN KEY (language_id)
        REFERENCES public.enum_language (id),
    CONSTRAINT fk_enum_normative_document_translate_enum_normative_document_o FOREIGN KEY (owner_id)
        REFERENCES public.enum_normative_document (id)
)

INSERT INTO public."enum_normative_document_translate"
VALUES
  -- Russia
  (1, 1, 1, 'full_name', 'Законо проект'),
  (2, 2, 1, 'full_name', 'Президентский указ'),
  (3, 3, 1, 'full_name', 'Решение президента'),
  (4, 4, 1, 'full_name', 'Президентский указ'),
  (5, 5, 1, 'full_name', 'Решение Кабинета министров'),
  (6, 6, 1, 'full_name', 'Докладная записка'),
   -- ENGLAND
  (7, 1, 2, 'full_name', 'Draft law'),
  (8, 2, 2, 'full_name', 'Presidential Decree'),
  (9, 3, 2, 'full_name', 'Presidents Decision'),
  (10, 4, 2, 'full_name', 'Presidential Order'),
  (11, 5, 2, 'full_name', 'Cabinet Decision'),
  (12, 6, 2, 'full_name', 'Detailed record'),
  -- UZBEK
  (13, 1, 3, 'full_name', 'Qonun Loyihasi'),
  (14, 2, 3, 'full_name', 'Prezedent Farmoni'),
  (15, 3, 3, 'full_name', 'Prezedent Qarori'),
  (16, 4, 3, 'full_name', 'Prezedent Farmoishi'),
  (17, 5, 3, 'full_name', 'Vazirlar mahkamasi qarori'),
  (18, 6, 3, 'full_name', 'Axborot Xati');