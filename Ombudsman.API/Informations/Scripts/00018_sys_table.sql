CREATE TABLE  public.sys_tables (
	id serial primary key,
    table_name VARCHAR(255)
);

INSERT INTO sys_tables (table_name)
SELECT table_name
FROM information_schema.tables
WHERE table_schema = 'public'
AND table_type = 'BASE TABLE';