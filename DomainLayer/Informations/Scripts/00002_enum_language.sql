CREATE TABLE public.enum_language
(
    id integer NOT NULL,
    short_name text COLLATE pg_catalog."default" NOT NULL,
    full_name text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT pk_enum_language PRIMARY KEY (id)
)
INSERT INTO public."enum_language"
VALUES 
    (1 , 'RU', 'Russia'),(2 , 'EN', 'England'),(3 , 'UZ', 'Uzbekistan');