CREATE OR REPLACE FUNCTION check_document_status()
    RETURNS BOOLEAN AS $$
    BEGIN
        RETURN EXISTS(SELECT 1 FROM enum_document_status WHERE full_name = 'Тасдиқланган');
    END;
    $$
    LANGUAGE plpgsql;