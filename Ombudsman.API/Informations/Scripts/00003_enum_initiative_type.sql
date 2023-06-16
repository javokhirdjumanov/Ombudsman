CREATE TABLE public.enum_initiative_type
(
    id integer NOT NULL,
    names varchar(100),
    CONSTRAINT pk_enum_initiative_type PRIMARY KEY (id)
)
INSERT INTO public."enum_initiative_type"
VALUES 
    (1, 'Вазирлик'),(2, 'Ходим'),(3, 'Расман киритилган');