CREATE OR REPLACE FUNCTION add_documents_with_visaholders( /*o'zgaruvchilar*/)
    RETURNS VOID AS $$
    DECLARE
        doc_id INTEGER;
        error_occurred BOOLEAN := FALSE;
    BEGIN
        BEGIN
				INSERT INTO doc_documents
				VALUES (/*o'zgaruvchilar*/)
            RETURNING id INTO doc_id;
				INSERT INTO doc_visa_holders
				VALUES (/*o'zgaruvchilar*/);
        	COMMIT;
        EXCEPTION
            WHEN OTHERS THEN
                error_occurred := TRUE;
        	ROLLBACK;
        END;
        IF error_occurred THEN
            RAISE EXCEPTION 'Viza egalari va Hujjatlarni qoʻshishda xatolik yuz berdi.';
        END IF;
    END;
    $$
LANGUAGE plpgsql;