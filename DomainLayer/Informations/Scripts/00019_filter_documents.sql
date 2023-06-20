CREATE OR REPLACE FUNCTION public.get_documents_by_organization(
    p_organization_id integer,
    p_from_date timestamp without time zone,
    p_to_date timestamp without time zone
)
RETURNS TABLE (
    id integer,
    order_number integer,
    normative_full_name text,
    document_importance_full_name text,
    state_program_included boolean,
    state_program_full_name text,
    document_name text,
    document_content text,
    create_at timestamp without time zone,
    send_document_data timestamp without time zone,
    estimated_execution_time timestamp without time zone,
    sector_full_name text,
    main_ministry text,
    orginization_user_full_name text,
    initiative_type_name text,
    performers text,
    organization_name text,
    document_status_name text,
    normative_doc_number integer,
    normative_doc_date timestamp without time zone,
    file_name text
)
AS $$
BEGIN
    RETURN QUERY
    SELECT
        d.id,
        d.order_number,
        nor.full_name as normative_full_name,
        idi.full_name as document_importance_full_name,
        d.state_program_included,
        isp.full_name as state_program_full_name,
        d.document_name,
        d.document_content,
        d.create_at,
        d.send_document_data,
        d.estimated_execution_time,
        isec.full_name as sector_full_name,
        d.main_ministry,
        hu.fio as orginization_user_full_name,
        eit.names as initiative_type_name,
        d.performers,
        io.full_name as organization_name,
        eds.full_name as document_status_name,
        d.normative_doc_number,
        d.normative_doc_date,
        fm.file_name as file_name
    FROM public.doc_documents AS d
    INNER JOIN public.doc_file_model AS fm ON d.file_id = fm.id
    INNER JOIN public.enum_document_status AS eds ON d.document_status_id = eds.id
    INNER JOIN public.enum_initiative_type AS eit ON d.initiative_type_id = eit.id
    INNER JOIN public.enum_normative_document AS nor ON d.normative_document_id = nor.id
    INNER JOIN public.hl_user AS hu ON d.orginization_user_id = hu.id
    INNER JOIN public.info_document_importance AS idi ON d.document_importance_id = idi.id
    INNER JOIN public.info_organization AS io ON d.organization_id = io.id
    LEFT JOIN public.info_sectors AS isec ON d.sector_id = isec.id
    LEFT JOIN public.info_state_program AS isp ON d.state_program_id = isp.id
    WHERE
        d.organization_id = p_organization_id
         AND DATE(d.create_at) >= DATE(p_from_date)
         AND DATE(d.create_at) <= DATE(p_to_date)
	ORDER BY
    	d.create_at DESC;
    RETURN;
END;
$$ LANGUAGE plpgsql;


SELECT * FROM public.get_documents_by_organization(1, '2023-01-01', '2023-06-30');