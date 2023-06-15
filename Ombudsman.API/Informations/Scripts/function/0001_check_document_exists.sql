CREATE OR REPLACE FUNCTION check_document_exists
RETURNS BOOLEAN AS $$
    BEGIN
        RETURN EXISTS(SELECT 1 FROM enum_normative_document WHERE full_name = 'Докладная записка');
    END;
    $$
LANGUAGE plpgsql;