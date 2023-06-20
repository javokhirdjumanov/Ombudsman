CREATE TABLE public.enum_state_organization
(
    id integer NOT NULL,
    state_id integer NOT NULL,
    order_number integer NOT NULL,
    short_name varchar(30),
    full_name varchar(100),
    CONSTRAINT pk_enum_state_organization PRIMARY KEY (id),
    CONSTRAINT fk_enum_state_organization_enum_state_state_id FOREIGN KEY (state_id)
        REFERENCES public.enum_state (id)
)
INSERT INTO public.enum_state_organization 
VALUES
(1, 1, 1, 'Vazirlik', 'Vazirlik'),
(2, 1, 2, 'A M E M O', 'Alohida maqomga ega mustaqil organ'),
(3, 1, 3, 'P A X T', 'Prezdent va Admintratsiya xuzuridagi tashkilot'),
(4, 1, 4, 'T B', 'Tijorat banklar jamgarmalar va boshqalar'),
(5, 1, 5, 'Sud I', 'Sud idoralari'),
(6, 1, 6, 'X T', 'Xarbiylashtirish Tizimlari'),
(7, 1, 7, 'Xojalik b', 'Xo`jalik birlashmalar hamda uyushmalar');