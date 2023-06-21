CREATE TABLE public.enum_language
(
    id integer NOT NULL,
    short_name text COLLATE pg_catalog."default" NOT NULL,
    full_name text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT pk_enum_language PRIMARY KEY (id)
)
