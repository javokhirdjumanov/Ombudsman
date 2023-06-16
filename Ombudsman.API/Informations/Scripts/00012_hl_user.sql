CREATE TABLE IF NOT EXISTS public.hl_user
(
    id  SERIAL PRIMARY KEY,
    fio varchar(100) NOT NULL,
    phone_number varchar(100) NOT NULL,
    email varchar(100) NOT NULL,
    password_hash varchar(255) NOT NULL,
    salt varchar(256) NOT NULL,
    refresh_token varchar(255),
    refresh_token_expired_date timestamp without time zone,
    organization_id integer NOT NULL,
    language_id integer NOT NULL,
    role_id integer NOT NULL,
    create_at timestamp without time zone NOT NULL,
    CONSTRAINT fk_hl_user_enum_language_language_id FOREIGN KEY (language_id)
        REFERENCES public.enum_language (id),
    CONSTRAINT fk_hl_user_enum_user_role_role_id FOREIGN KEY (role_id)
        REFERENCES public.enum_user_role (id),
    CONSTRAINT fk_hl_user_info_organization_organization_id FOREIGN KEY (organization_id)
        REFERENCES public.info_organization (id)
)

